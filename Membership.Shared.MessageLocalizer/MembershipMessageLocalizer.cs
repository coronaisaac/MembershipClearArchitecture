using Membership.Shared.Constants;
using Membership.Shared.Interfaces;

internal class MembershipMessageLocalizer : IMembershipMessageLocalizer
{
    readonly Dictionary<string, string> Messages_Es = new()
    {
        {MessageKeys.RequiredFirstNameErrorMessage, "El nombre es requerido." },
        {MessageKeys.RequiredLastNameErrorMessage, "El apellido es requerido." },
        {MessageKeys.RequiredEmailErrorMessage, "El correo es requerido." },
        {MessageKeys.RequiredPasswordErrorMessage, "La contraseña es requerida." },
        {MessageKeys.CompareConfirmPasswordErrorMessage, "La contraseña y la confirmación no coinciden." },
        {MessageKeys.PasswordRequiresDigitErrorMessage, "Se requiere al menos un dígito en la contraseña." },
        {MessageKeys.PasswordRequiresLowerErrorMessage,
            "Se requiere al menos un caracter minúscula en la contraseña." },
        {MessageKeys.PasswordRequiresNonAlphanumericErrorMessage,
            "Se requiere al menos un caracter no alfanumérico en la contraseña." },
        {MessageKeys.PasswordRequiresUpperErrorMessage,
            "Se requiere al menos un caracter mayúscula en la contraseña." },
        {MessageKeys.DuplicateEmailErrorMessage,
            "El correo proporcionado ya se encuentra registrado." },
        {MessageKeys.PasswordRequiresToShortErrorMessage,
            "Se requiere al menos 6 caracteres en la contraseña." },
        //{MessageKeys.LoginAlreadyAssociatedErrorMessage,
        //    "El correo proporcionado ya se encuentra asociado a una cuenta de usuario." },
        {MessageKeys.DisplayFirstNameMessage, "Nombre:" },
        {MessageKeys.DisplayLastNameMessage, "Apellidos:" },
        {MessageKeys.DisplayEmailMessage, "Correo:" },
        {MessageKeys.DisplayPasswordMessage, "Contraseña:" },
        {MessageKeys.DisplayConfirmPasswordMessage, "Confirmar contraseña:" },
        {MessageKeys.DisplayRegisterButtonMessage, "Registrar" },
        {MessageKeys.DisplayLoginButtonMessage, "Iniciar sesión" },
        {MessageKeys.DisplayLogoutButtonMessage, "Cerrar sesión" },
        {MessageKeys.RegisterUserExceptionMessage, "Error al registrar el usuario" },
        {MessageKeys.LoginUserExceptionMessage, "Las credenciales proporcionads son incorrectas" },
        {MessageKeys.RefreshTokenCompromisedExceptionMessage, "El token de actualización fue comprometido" },
        {MessageKeys.RefreshTokenExpiredExceptionMessage, "El token de actualización ha expirado" },
        {MessageKeys.RefreshTokenNotFoundExceptionMessage, "El token de actualización no fue encontrado" },

    };

    public string this[string key]
    {
        get
        {
            Messages_Es.TryGetValue(key, out string Message);
            return string.IsNullOrWhiteSpace(Message) ? key : Message;
        }
    }
}
