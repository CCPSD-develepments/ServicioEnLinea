using System.ComponentModel;

namespace CamaraComercio.WebServices.Usuarios
{
    public enum RegisterUserResult
    {
        [Description("No se pudo crear el usuario.")]
        UsuarioNoCreado = 0,
        [Description("Usuario creado satisfactoriamente")]
        UsuarioCreado = 1,
        [Description("El tamaño del nombre de usuario debe ser 4 caracteres.")]
        FormatoUsuarioInvalido = 2,
        [Description("Nombre de usuario ya existe.")]
        UsuarioExiste = 3,
        [Description("El formato de email es inválido.")]
        FormatoEmailInvalido = 4,
        [Description("El email ya existe en el sistema.")]
        EmailExiste = 5
    }
}