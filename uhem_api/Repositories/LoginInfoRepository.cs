using MySqlConnector;
using System.Security.Cryptography;
using System.Text;
using uhem_api.Dto;
using uhem_api.Interfaces.Repositories;
using uhem_api.Interfaces.Repository;
using uhem_api.Mappers;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            catch(Exception e)
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

                if(flag == "USER")
                {
                    command2.CommandText = "INSERT INTO `uhem`.`uhem_patient` (`email`) VALUES (@username);";
                }
                else
                {
                    command2.CommandText = "INSERT INTO `uhem`.`uhem_health_facility` (`email`) VALUES (@username);";
                }
                command2.Parameters.AddWithValue("@username", data.Username);

                res = await command2.ExecuteReaderAsync();

                return true;

            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        public async Task<bool> VerifyPassword(MySqlConnection con, string sns, string password, string flag)
        {
            try
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
