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

        public async Task<bool> Post(MySqlConnection con, LoginInfoDto data)
        {
            try
            {
                await con.OpenAsync();

                byte[] salt = RandomNumberGenerator.GetBytes(keySize);

                var command12 = con.CreateCommand();
                command12.CommandText = "INSERT INTO UHEM.UHEM_SALT (username, salt) VALUES (@id, @salt);";
                command12.Parameters.AddWithValue("@id", data.Username);
                command12.Parameters.AddWithValue("@salt", salt);

                var res = await command12.ExecuteReaderAsync();

                var hash = Rfc2898DeriveBytes.Pbkdf2(
                    Encoding.UTF8.GetBytes(data.EncryptedPassword),
                    salt,
                    iterations,
                    hashAlgorithm,
                    keySize);
                var password = Convert.ToHexString(hash);

                await con.CloseAsync();
                await con.OpenAsync();

                var command = con.CreateCommand();
                command.CommandText = "INSERT INTO `uhem`.`uhem_login_info` (`username`, `encrypted_password`) VALUES (@username, @pwd);";
                command.Parameters.AddWithValue("@username", data.Username);
                command.Parameters.AddWithValue("@pwd", password);

                var res22 = await command.ExecuteReaderAsync();

                await con.CloseAsync();
                await con.OpenAsync();

                var command2 = con.CreateCommand();

                command2.CommandText = "INSERT INTO `uhem`.`uhem_health_facility` (`email`) VALUES (@username);";
                command2.Parameters.AddWithValue("@username", data.Username);

                res = await command2.ExecuteReaderAsync();

                return true;

            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        public async Task<bool> VerifyPassword(MySqlConnection con, string username, string password)
        {
            try
            {
                
                await con.OpenAsync();

                var command = con.CreateCommand();
                command.CommandText = "SELECT * FROM uhem.uhem_login_info WHERE username = @user;";
                command.Parameters.AddWithValue("@user", username);

                var res = await command.ExecuteReaderAsync();

                var pwd_hash = LoginInfoMapper.MapToLoginInfoDto(res).EncryptedPassword;

                await con.CloseAsync();
                await con.OpenAsync();
                var command2 = con.CreateCommand();
                command2.CommandText = "SELECT * FROM uhem.uhem_salt where username = @user;";
                command2.Parameters.AddWithValue("@user", username);

                var res2 = await command2.ExecuteReaderAsync();

                var mysalt = SaltMapper.MapToSaltDto(res2).Salt;
      
                var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(password, Encoding.ASCII.GetBytes(mysalt), iterations, hashAlgorithm, keySize);

                var pos = hashToCompare.SequenceEqual(Convert.FromHexString(pwd_hash));

                return pos ? true : false;

            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        const int keySize = 64;
        const int iterations = 350000;
        HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;
        public async Task<string> HashPasword(MySqlConnection c, string password, string id)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(keySize);

            await c.OpenAsync();

            var command = c.CreateCommand();
            command.CommandText = "INSERT INTO UHEM.UHEM_SALT (ID_LOGIN_INFO, SALT) VALUES (@id, @salt);";
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@salt", salt.ToString());

            var res = await command.ExecuteReaderAsync();

            var hash = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(password),
                salt,
                iterations,
                hashAlgorithm,
                keySize);
            return Convert.ToHexString(hash);

            await c.CloseAsync();
        }

    }
}
