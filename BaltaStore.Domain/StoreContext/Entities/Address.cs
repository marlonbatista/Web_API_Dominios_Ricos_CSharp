using System;
using BaltaStore.Domain.StoreContext.Enums;
using BaltaStore.Domain.StoreContext.ValueObjects;
using FluentValidator;

namespace BaltaStore.Domain.StoreContext.Entites
{
    public class Address : Notifiable
    {
        public Address(
            string street,
            string number,
            string district,
            string city,
            string state,
            string country,
            string zipcode,
            EAddressType type)
        {
            Street = street;
            Number = number;
            District = district;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipcode;
            Type = type;

        }
        public string Street { get; private set; }
        public string Number { get; private set; }
        public string District { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
        public string ZipCode { get; private set; }
        public EAddressType Type { get; private set; }

        

        public override string ToString()
        {
            return $"{Street}, {Number} - {City}/{State}";
        }

    }

}