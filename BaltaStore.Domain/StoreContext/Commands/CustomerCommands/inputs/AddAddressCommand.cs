using System;
using BaltaStore.Domain.StoreContext.Enums;
using BaltaStore.Shared.Commands;
using FluentValidator;
using FluentValidator.Validation;

namespace BaltaStore.Domain.StoreContext.CustomerCommands.Inputs
{
    // Commands de AddAdress
    public class AddAdressCommand : Notifiable, ICommands
    {
        public Guid Id { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public EAddressType Type { get; set; }

        public bool Valid()
        {
            // Fail Fast Validation
            AddNotifications(new ValidationContract()
                .HasLen(Id.ToString(), 36, "Id", "Identificador do endereço é inválido")
                .HasMaxLen(Street, 50, "Street", "O nome da rua deve conter no máximo 50 caracteres")
                .HasMinLen(Street, 3, "Street", "O nome da rua deve conter pelo menos 3 caracteres")
                .IsNotNullOrEmpty(Street, "Street", "O nome da rua não deve ser nulo")
                .IsNotNullOrEmpty(Number, "Number", "O número não pode ser nulo")
                .HasMinLen(Number, 1, "Number", "O número deve ser no mínimo 1")
                .IsNotNullOrEmpty(District, "District", "O bairro não pode ser nulo")
                .HasMaxLen(District, 50, "District", "O bairro a deve conter no máximo 50 caracteres")
                .HasMinLen(District, 3, "District", "O bairro deve conter pelo menos 3 caracteres")
                .IsNotNullOrEmpty(City, "City", "A cidade não pode ser nulo")
                .HasMaxLen(City, 50, "City", "A cidade a deve conter no máximo 50 caracteres")
                .HasMinLen(City, 3, "City", "A cidade deve conter pelo menos 3 caracteres")
                .IsNotNullOrEmpty(State, "State", "O estado não pode ser nulo")
                .HasMaxLen(State, 20, "State", "O estado deve conter no máximo 20 caracteres")
                .HasMinLen(State, 3, "State", "O estado deve conter pelo menos 3 caracteres")
                .IsNotNullOrEmpty(Country, "Country", "O pais não pode ser nulo")
                .HasMaxLen(Country, 20, "Country", "O pais deve conter no máximo 20 caracteres")
                .HasMinLen(Country, 3, "Country", "O pais deve conter pelo menos 3 caracteres")
                .IsNotNullOrEmpty(ZipCode, "ZipCode", "O estado não pode ser nulo")
                .HasLen(ZipCode, 8, "ZipCode", "CPF inválido")
                
                );
            return IsValid;
        }
    }
}