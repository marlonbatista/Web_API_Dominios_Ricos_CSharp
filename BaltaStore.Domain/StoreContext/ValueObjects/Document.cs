using FluentValidator;
using FluentValidator.Validation;

namespace BaltaStore.Domain.StoreContext.ValueObjects
{
    public class Document : Notifiable
    {
        public Document(string number)
        {
            Number = number;

            AddNotifications(new ValidationContract()
                .IsTrue(Validate(Number), "Document", "CPF inválido")
            );
        }
        public string Number { get; private set; }

        public override string ToString()
        {
            return Number;
        }

        public bool Validate(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCPF;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCPF = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCPF[i].ToString()) * multiplicador1[1];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCPF = tempCPF + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCPF[i].ToString()) * multiplicador2[1];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);

        }
    }
}