using System.Data.SqlClient;
using System.Collections.Generic;
using Dapper;
public static class BD {
    private static string _connectionString = @"Server=localhost;DataBase=ModuloLogin;Trusted_Connection=True;";

    public static void Register(User user) {
        string sql = "INSERT INTO Usuario(UserName,Contraseña,Telefono,Email,Nombre,Personal,PreguntaPersonal) VALUES (@pUserName,@pContraseña,@pTelefono,@pEmail,@pNombre,@pPersonal,@pPreguntaPersonal)";
        using(SqlConnection db = new SqlConnection(_connectionString)) {
            db.Execute(sql, new {pUserName = user.UserName, pContraseña = user.Contraseña, pTelefono = user.Telefono, pEmail = user.Email, pNombre = user.Nombre, pPersonal = user.Personal, pPreguntaPersonal = user.PreguntaPersonal});
        }
    }
    public static User Login(string username, string contraseña) {
        User MiUser = new User();
        using(SqlConnection db = new SqlConnection(_connectionString)) {
            string sql = "SELECT * FROM Usuario WHERE UserName = @pUserName AND Contraseña = @pContraseña";
            MiUser = db.QueryFirstOrDefault<User>(sql, new {pUserName = username, pContraseña = contraseña });
        }
        return MiUser;
    }
    public static User Username(string username) {
        User MiUser = new User();
        using(SqlConnection db = new SqlConnection(_connectionString)) {
            string sql = "SELECT * FROM Usuario WHERE UserName = @pUserName";
            MiUser = db.QueryFirstOrDefault<User>(sql, new {pUserName = username});
        }
        return MiUser;
    }
      public static User Email(string email) {
        User MiUser = new User();
        using(SqlConnection db = new SqlConnection(_connectionString)) {
            string sql = "SELECT * FROM Usuario WHERE Email = @pemail";
            MiUser = db.QueryFirstOrDefault<User>(sql, new {pemail = email});
        }
        return MiUser;
    }
     public static User Olvide(string mail, string personal) {
        User MiUser = new User();
        using(SqlConnection db = new SqlConnection(_connectionString)) {
            string sql = "SELECT * FROM Usuario WHERE Email = @pmail AND Personal = @pPersonal";
            MiUser = db.QueryFirstOrDefault<User>(sql, new {pmail = mail, pPersonal = personal });
        }
        return MiUser;
    }

}