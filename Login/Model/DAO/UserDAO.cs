using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Login.Model.DTO;

namespace Login.Model.DAO
{
    class UserDAO
    {
        private SqlDataReader reader;
        private readonly ConexionDB Conexion = new ConexionDB();

        public UserDTO GetUserByUsernameOrEmail(string Username, string Email = "")
        {
            SqlConnection Cnn = Conexion.Connection();
            UserDTO user = null;
            try
            {
                Email = Email.Length == 0 ? Username : Email;
                SqlCommand command = new SqlCommand($"SELECT * FROM Users WHERE Username = '{Username}' OR Email = '{Email}'", Cnn);
                Cnn.Open();
                reader = command.ExecuteReader();
                if(reader.Read())
                {
                    user = new UserDTO
                    {
                        Id = reader.GetGuid(0).ToString(),
                        Username = reader.GetString(1),
                        Fullname = reader.GetString(2),
                        Email = reader.GetString(3),
                        Password = reader.GetString(4)
                    }; 
                }
                return user;
            }
            catch
            {
                user = null;
                return user;
            } finally
            {
                reader.Close();
                Cnn.Dispose();
            }
        }

        public UserDTO Save(string Username, string Fullname, string Email, string Password)
        {
            SqlConnection Cnn = Conexion.Connection();
            UserDTO user = null;
            try
            {
                SqlCommand command = new SqlCommand($"INSERT INTO Users (Id, Username, Fullname, Email, Password) VALUES (NEWID(), '{Username}', '{Fullname}', '{Email}', '{Password}')", Cnn);
                Cnn.Open();
                int rows = command.ExecuteNonQuery();
                if (rows > 0)
                {
                    command = new SqlCommand($"SELECT Id FROM Users WHERE Username = '{Username}'", Cnn);
                    reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        user = new UserDTO
                        {
                            Id = reader.GetGuid(0).ToString(),
                            Username = Username,
                            Fullname = Fullname,
                            Email = Email,
                            Password = Password
                        };
                    }
                }
                return user;
            }
            catch
            {
                user = null;
                return user;
            }
            finally
            {
                reader.Close();
                Cnn.Dispose();
            }
        }

    }
}
