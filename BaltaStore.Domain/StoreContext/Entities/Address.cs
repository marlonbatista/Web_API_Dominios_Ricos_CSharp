using System;
using BaltaStore.Domain.StoreContext.Enums;
using BaltaStore.Domain.StoreContext.ValueObjects;

namespace BaltaStore.Domain.StoreContext.Entites
{
    public class Address
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
        public string Street { get; set; }
        public string Number { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public EAddressType Type { get; private set; }

        

        public override string ToString()
        {
            return $"{Street}, {Number} - {City}/{State}";
        }

    }

}