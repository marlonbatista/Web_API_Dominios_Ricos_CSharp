

using BaltaStore.Shared.Commands;
using FluentValidator;
using FluentValidator.Validation;

namespace BaltaStore.Domain.StoreContext.CustomerCommands.Inputs
{
    public class CreateCustomerCommand : Notifiable, ICommands
    {
        // Aqui é onde é feita a estruturação do json
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string phone { get; set; }

        public bool Valid()
        {
            // Fail Fast Validation
            AddNotifications(new ValidationContract()
                .HasMinLen(FirstName, 3, "FirstName", "O nome deve conter pelo menos 3 caracteres")
                .HasMaxLen(FirstName, 40, "FirstName", "O nome deve conter no máximo 40 caracteres")
                .HasMinLen(LastName, 3, "FirstName", "O sobrenome deve conter pelo menos 3 caracteres")
                .HasMaxLen(LastName, 40, "FirstName", "O sonbrenome deve conter no máximo 40 caracteres")
                .IsEmail(Email, "Email", "O E-mail é inválido")
                .HasLen(Document, 11, "Document", "CPF inválido")
                );
            return IsValid;
        }
    }

    // Se o usuário existe no banco (Email)
    // Se o usuário existe no banco (CPF)

}