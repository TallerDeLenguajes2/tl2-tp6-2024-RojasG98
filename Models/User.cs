using System.Security.Principal;

public class User
{
    
    public int Id{get;set;}
    public string Username{get;set;} = string.Empty;
    public string Password{get;set;} = string.Empty;
    public AccessLevels AccessLevels {get;set;}

}

public enum AccessLevels{
    Admin,
    Editor,
    Invitado,
    Empleado
}