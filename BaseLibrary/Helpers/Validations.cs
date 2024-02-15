using System.ComponentModel.DataAnnotations;

namespace BaseLibrary.Helpers
{
    public class ValidChars(string validChars) : ValidationAttribute
    {
        private readonly string valChars = validChars;

        public override bool IsValid(object value)
        {
            if (value == null) return false;

            string w = value!.ToString();

            for (int i = 0; i < w.Length; i++)
            {
                if (!valChars.Contains(w[i])) return false;
            }

            return true;
        }
    }
    public class ValidCPF : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null) return false;

            string cpf = value.ToString().Replace(".", "").Replace("-", "");

            if (!cpf.All(char.IsDigit)) return false;
            if (cpf.Length != 11) return false;

            if (cpf[9] != CalculaDigito(cpf, 9)) return false;

            if (cpf[10] != CalculaDigito(cpf, 10)) return false;

            return true;

        }
        private static char CalculaDigito(string cpf, int digito)
        {
            int d = 0;
            for (int i = 0; i < digito; i++)
            {
                d += (cpf[i] - '0') * (digito + 1 - i);
            }
            d = (11 - (d %= 11)) > 9 ? 0 : (11 - (d %= 11));

            return (char)(d + '0');
        }
    }
}
