public class User {
    public int IdUser { set;  get;}
    public string UserName { set;  get;}
    public string Contraseña { set;  get;}
    public string Telefono { set;  get;}
    public string Email { set;  get;}
    public string Nombre {set; get;}
    public string Personal {set; get;}
   
   // constructor
    public User() {
        IdUser = 0;
        UserName = "";
        Contraseña = "";
        Telefono = "";
        Email = "";
        Nombre = "";
        Personal = "";
    }
    public User(string userName, string contraseña, string telefono, string email, string nombre, string personal) {
        UserName = userName;
        Contraseña = contraseña;
        Telefono = telefono;
        Email = email;
        Nombre = nombre;
        Personal = personal;
    }
}