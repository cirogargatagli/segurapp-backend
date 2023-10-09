using System.Text.RegularExpressions;

namespace SegurApp.Validations
{
    public class Validations
    {
        public static bool IsValidName(string name)
        {
            // Utiliza una expresión regular para verificar que el nombre no contenga números
            return Regex.IsMatch(name, "^[A-Za-záéíóúÁÉÍÓÚñÑüÜ\\s]+$");
        }

        public static bool IsValidDni(string dni)
        {
            // Utiliza una expresión regular para verificar que el DNI contenga solo números y tenga una longitud de 8 dígitos
            return Regex.IsMatch(dni, "^[0-9]{8}$");
        }

        public static bool IsValidEmail(string email)
        {
            // Utiliza una expresión regular para verificar que el email tenga un formato válido
            return Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
        }

        public static bool IsValidPhoneNumber(string phoneNumber)
        {
            // Utiliza una expresión regular para verificar que el teléfono contenga solo números
            return Regex.IsMatch(phoneNumber, "^[0-9]+$");
        }

        public static bool IsValidPassword(string password)
        {
            // Verifica que la contraseña tenga al menos 8 caracteres
            if (password.Length < 8)
            {
                return false;
            }

            // Verifica si la contraseña contiene al menos una letra mayúscula y al menos un número
            if (!password.Any(char.IsUpper) || !password.Any(char.IsDigit))
            {
                return false;
            }

            return true;
        }
    }
}
