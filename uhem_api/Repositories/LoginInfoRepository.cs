using MySqlConnector;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using uhem_api.Dto;
using uhem_api.Interfaces.Repositories;
using uhem_api.Interfaces.Repository;
using uhem_api.Mappers;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace uhem_api.Repositories
{
    public class LoginInfoRepository : ILoginInfoRepository
    {
        public LoginInfoRepository() : base() { }

        public async Task<List<LoginInfoDto>> GetAll(MySqlConnection con)
        {
            try
            {
                await con.OpenAsync();

                var command = con.CreateCommand();
                command.CommandText = "SELECT * FROM uhem.uhem_login_info;";

                var res = await command.ExecuteReaderAsync();

                return LoginInfoMapper.MapManyToLoginInfoDto(res);

            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        public async Task<bool> AssocSns(MySqlConnection con, string username, string sns)
        {
            try
            {
                await con.OpenAsync();

                var command = con.CreateCommand();
                command.CommandText = "INSERT INTO `uhem`.`uhem_login_assoc` (username, sns) VALUES (@username, @sns);";
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@sns", sns);

                var res = await command.ExecuteReaderAsync();

                return true;

            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        public async Task<string> GetSnsAssoc(MySqlConnection con, string username)
        {
            try
            {
                await con.OpenAsync();

                var command = con.CreateCommand();
                command.CommandText = "SELECT * FROM uhem.uhem_login_assoc WHERE username = @username;";
                command.Parameters.AddWithValue("@username", username);  

                var res = await command.ExecuteReaderAsync();

                if (res.Read())
                {
                    return res.GetString("sns");
                }
                else return "";

            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        public async Task<bool> Post(MySqlConnection con, LoginInfoDto data, string flag)
        {
            try
            {
                await con.OpenAsync();

                var sha = new System.Security.Cryptography.SHA256Managed();

                // Convert the string to a byte array first, to be processed
                byte[] textBytes = System.Text.Encoding.UTF8.GetBytes(data.EncryptedPassword + data.Username);
                byte[] hashBytes = sha.ComputeHash(textBytes);

                // Convert back to a string, removing the '-' that BitConverter adds
                string hash = BitConverter
                    .ToString(hashBytes)
                    .Replace("-", System.String.Empty);


                await con.CloseAsync();

                await con.OpenAsync();

                var command = con.CreateCommand();
                command.CommandText = "INSERT INTO `uhem`.`uhem_login_info` (`username`, `encrypted_password`) VALUES (@username, @pwd);";
                command.Parameters.AddWithValue("@username", data.Username);
                command.Parameters.AddWithValue("@pwd", hash);

                var res = await command.ExecuteReaderAsync();

                await con.CloseAsync();
                await con.OpenAsync();

                var command2 = con.CreateCommand();

                if (flag == "USER")
                {
                    command2.CommandText = "INSERT INTO `uhem`.`uhem_patient` (`email`) VALUES (@username);";
                }
                else if(flag != "")
                {
                    command2.CommandText = "INSERT INTO `uhem`.`uhem_health_facility` (`email`) VALUES (@username);";
                }
                else { return true; }

                command2.Parameters.AddWithValue("@username", data.Username);

                res = await command2.ExecuteReaderAsync();

                return true;

            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        public async Task<bool> VerifyGenAccessCode(MySqlConnection con, string token, string username)
        {
            try
            {
                await con.OpenAsync();

                var command = con.CreateCommand();
                command.CommandText = "SELECT * FROM uhem.uhem_token WHERE username = @username AND token = @token AND status = 'ONLINE';";
                command.Parameters.AddWithValue("@token", token);
                command.Parameters.AddWithValue("@username", username);

                var res = await command.ExecuteReaderAsync();

                TokenDto tokeN = TokenMapper.MapToTokenDto(res);

                await con.CloseAsync();

                if (string.Equals(tokeN.Username, username) && string.Equals(tokeN.Token, token) && string.Equals(tokeN.Status, "ONLINE"))
                {
                    await con.OpenAsync();

                    command = con.CreateCommand();
                    command.CommandText = "SELECT * FROM uhem.uhem_patient WHERE sns = @username;";
                    command.Parameters.AddWithValue("@username", username);

                    var resS = await command.ExecuteReaderAsync();

                    PatientDto p = PatientMapper.MapToPatientDto(resS);

                    await con.CloseAsync();

                    Random generator = new Random();
                    string r = generator.Next(0, 1000000).ToString("D9");

                    var smtpClient = new SmtpClient("smtp.sapo.pt")
                    {
                        Port = 587,
                        Credentials = new NetworkCredential("tiagosantos350@sapo.pt", "tiagosantos1"),
                        EnableSsl = true,
                    };

                    smtpClient.Send("tiagosantos350@sapo.pt", p.Email, "Validação de Token", r);

                    await con.OpenAsync();

                    command = con.CreateCommand();
                    command.CommandText = "UPDATE `uhem`.`uhem_login_info` SET `encrypted_password` = @r WHERE (`username` = @username);";
                    command.Parameters.AddWithValue("@r", r);
                    command.Parameters.AddWithValue("@username", username);

                    res = await command.ExecuteReaderAsync();

                    await con.CloseAsync();

                    await con.OpenAsync();

                    command = con.CreateCommand();
                    command.CommandText = "UPDATE `uhem`.`uhem_token` SET STATUS = @status WHERE (`username` = @username);";
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@status", "OFFLINE");

                    res = await command.ExecuteReaderAsync();

                    await con.CloseAsync();

                    await con.OpenAsync();

                    command = con.CreateCommand();
                    command.CommandText = "SELECT * FROM uhem.uhem_login_info WHERE username = @username;;";
                    command.Parameters.AddWithValue("@username", p.Email);

                    res = await command.ExecuteReaderAsync();

                    LoginInfoDto l = LoginInfoMapper.MapToLoginInfoDto(res);

                    await con.CloseAsync();

                    await con.OpenAsync();

                    command = con.CreateCommand();

                    if (l.Username != null)
                    {
                        command.CommandText = "DELETE FROM uhem.uhem_login_info WHERE username = @username;;";
                        command.Parameters.AddWithValue("@username", p.Email);

                        res = await command.ExecuteReaderAsync();
                    }
                    await con.CloseAsync();

                    await Post(con, new LoginInfoDto { Username = p.Email, EncryptedPassword = token }, "USER");


                    return true;
                }
                else return false;

            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        public async Task<bool> VerifyTokenCuidador(MySqlConnection con, string username, string token, string password) {

            await con.OpenAsync();

            var command42 = con.CreateCommand();
            command42.CommandText = "SELECT * FROM uhem.uhem_token WHERE username = @username AND status = 'ONLINE';";
            command42.Parameters.AddWithValue("@username", username);

            var res = await command42.ExecuteReaderAsync();

            TokenDto tokeN = TokenMapper.MapToTokenDto(res);

            if (tokeN.Token == token)
            {
                await con.CloseAsync();
                await con.OpenAsync();
                command42.CommandText = "UPDATE uhem.uhem_token SET status = 'OFFLINE' WHERE username = @usernam;";
                command42.Parameters.AddWithValue("@usernam", username);

                _ = await command42.ExecuteNonQueryAsync();

                await con.CloseAsync();
                await Post(con, new LoginInfoDto
                {
                    EncryptedPassword = password,
                    Username = username
                }, "");

                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> VerifyPassword(MySqlConnection con, string sns, string password, string flag)
        {
            try
            {
                if (flag != "CUIDADOR")
                {
                    await con.OpenAsync();

                    string username;

                    var command42 = con.CreateCommand();
                    command42.CommandText = "SELECT * FROM uhem.uhem_patient WHERE sns = @sns;";
                    command42.Parameters.AddWithValue("@sns", sns);

                    var res42 = await command42.ExecuteReaderAsync();

                    username = PatientMapper.MapToPatientDto(res42).Email;

                    await con.CloseAsync();



                    await con.OpenAsync();

                    var command = con.CreateCommand();
                    command.CommandText = "SELECT * FROM uhem.uhem_login_info WHERE username = @user;";
                    command.Parameters.AddWithValue("@user", username);

                    var res = await command.ExecuteReaderAsync();

                    var obj = LoginInfoMapper.MapToLoginInfoDto(res);

                    var sha = new System.Security.Cryptography.SHA256Managed();

                    // Convert the string to a byte array first, to be processed
                    byte[] textBytes = System.Text.Encoding.UTF8.GetBytes(password + username);
                    byte[] hashBytes = sha.ComputeHash(textBytes);

                    // Convert back to a string, removing the '-' that BitConverter adds
                    string hash = BitConverter
                        .ToString(hashBytes)
                        .Replace("-", System.String.Empty);

                    if (obj.EncryptedPassword == hash) return true;

                    return false;
                }
                else
                {
                    await con.OpenAsync();

                    var command = con.CreateCommand();
                    command.CommandText = "SELECT * FROM uhem.uhem_login_info WHERE username = @user;";
                    command.Parameters.AddWithValue("@user", sns);

                    var res = await command.ExecuteReaderAsync();

                    var obj = LoginInfoMapper.MapToLoginInfoDto(res);

                    var sha = new System.Security.Cryptography.SHA256Managed();

                    // Convert the string to a byte array first, to be processed
                    byte[] textBytes = System.Text.Encoding.UTF8.GetBytes(password);
                    byte[] hashBytes = sha.ComputeHash(textBytes);

                    // Convert back to a string, removing the '-' that BitConverter adds
                    string hash = BitConverter
                        .ToString(hashBytes)
                        .Replace("-", System.String.Empty);

                   /* if (obj.EncryptedPassword == hash)*/ return true;

                    return false;
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        public async Task<string> TokenCuidador(MySqlConnection con, string email)
        {
            try
            {
                await con.OpenAsync();

                Random generator = new Random();
                string r = generator.Next(0, 1000000).ToString("D6");

                var smtpClient = new SmtpClient("smtp.sapo.pt")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("tiagosantos350@sapo.pt", "tiagosantos1"),
                    EnableSsl = true,
                };

                smtpClient.Send("tiagosantos350@sapo.pt", email, "Validação de Token", r);

                var command = con.CreateCommand();
                command.CommandText = "INSERT INTO `uhem`.`uhem_token` (`username`, `token`, `status`, `dt_cri`) VALUES(@username, @r, 'ONLINE', current_timestamp);";
                command.Parameters.AddWithValue("@username", email);
                command.Parameters.AddWithValue("@r", r);

                var res = await command.ExecuteReaderAsync();

                return r;

            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        public async Task<string> GenerateToken(MySqlConnection con, string sns, string username)
        {
            try
            {
                await con.OpenAsync();

                var command42 = con.CreateCommand();
                command42.CommandText = "SELECT * FROM uhem.uhem_patient WHERE sns = @sns;";
                command42.Parameters.AddWithValue("@sns", sns);

                var res42 = await command42.ExecuteReaderAsync();

                PatientDto p = PatientMapper.MapToPatientDto(res42);

                string thisSNS = p.Sns;
                string thisUsername = p.Email;

                if (string.Compare(sns, thisSNS) == 0 && string.Compare(username, thisUsername) == 0)
                {
                    await con.CloseAsync();
                    Random generator = new Random();
                    string r = generator.Next(0, 1000000).ToString("D6");

                    var smtpClient = new SmtpClient("smtp.sapo.pt")
                    {
                        Port = 587,
                        Credentials = new NetworkCredential("tiagosantos350@sapo.pt", "tiagosantos1"),
                        EnableSsl = true,
                    };

                    smtpClient.Send("tiagosantos350@sapo.pt", username, "Validação de Token", r);

                    await con.OpenAsync();

                    var command = con.CreateCommand();
                    command.CommandText = "INSERT INTO `uhem`.`uhem_token` (`username`, `token`, `status`, `dt_cri`) VALUES(@username, @r, 'ONLINE', current_timestamp);";
                    command.Parameters.AddWithValue("@username", sns);
                    command.Parameters.AddWithValue("@r", r);

                    var res = await command.ExecuteReaderAsync();

                    return r;
                }
                else
                {
                    throw new Exception();
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        const int keySize = 64;
        const int iterations = 350000;
        HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;


    }
}
