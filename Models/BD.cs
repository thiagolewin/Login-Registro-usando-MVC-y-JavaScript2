using System.Data.SqlClient;
using System.Collections.Generic;
using Dapper;
public static class BD {
    
    private static string _connectionString = @"Server=localhost;DataBase=ModuloLogin;Trusted_Connection=True;";

    public static void Register() {
        string sql = "";
        using(SqlConnection db = new SqlConnection(_connectionString)) {
            db.Execute(sql, new {});
        }
    }
}