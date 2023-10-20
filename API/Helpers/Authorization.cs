namespace API.Helpers;

public class Authorization
{
    public enum Roles
    {
        Admi,
        Empleado,
        SinRolAsignado
    }
    public const Roles rol_default = Roles.SinRolAsignado;
}
