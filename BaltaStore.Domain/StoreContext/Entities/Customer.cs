using System;
using System.Collections.Generic;
using System.Linq;
using BaltaStore.Domain.StoreContext.ValueObjects;
using FluentValidator;

namespace BaltaStore.Domain.StoreContext.Entites
{
    public class Customer : Notifiable
    {
        // 2. Desta forma é preciso criar uma nova privada lista
        //Para adicionar os endereços
        private readonly IList<Address> _addresses;

        public Customer(
            Name name,
            Document document,
            Email email,
            string phone)
        {
            Name = name;
            Document = document;
            Email = email;
            Phone = phone;
            //Aqui posso terei uma lista de endereços
            _addresses = new List<Address>();
        }

        public Name Name { get; set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public string Phone { get; private set; }
                                                    //3.retornando a lista de endereços
        public IReadOnlyCollection<Address> Addresses => _addresses.ToArray();
        public void AddAddress(Address address)
        {

            // Válidao endereço
            // 1. Adicionar( não é possivel adicionar direto pois a classe address não tem add)
            // **Vá para o ponto 2, depois volte aqui.
            _addresses.Add(address);
        }

        public override string ToString()
        {
            return Name.ToString();
        }

    }

}