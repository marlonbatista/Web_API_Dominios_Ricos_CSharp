using System;
using System.Collections.Generic;
using System.Linq;
using BaltaStore.Domain.StoreContext.Enums;

namespace BaltaStore.Domain.StoreContext.Entites
{
    public class Order
    {
        private readonly IList<OrderItem> _items;
        private readonly IList<Delivery> _deliverys;
        public Order(Customer customer)
        {
            Customer = customer;
            Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 8).ToUpper();
            CreateDate = DateTime.Now;
            Status = EOrderStatus.Created;
            _items = new List<OrderItem>();
            _deliverys = new List<Delivery>();
        }
        public Customer Customer { get; private set; }
        public string Number { get; private set; }
        public DateTime CreateDate { get; private set; }
        public EOrderStatus Status { get; private set; }
        //IReadOnlyCollection não deixa que seja adicionado itens a essa lista fora da classe
        // ou quando a classe é instânciada
        public IReadOnlyCollection<OrderItem> Items => _items.ToArray(); // aqui só é possivel utlizar o ( get )
        //por isso o retorno é o array de items
        // para fazero "set" tem que ser através do AddItem
        public IReadOnlyCollection<Delivery> Deliveries => _deliverys.ToArray();

        //Métodos para adicionar pedidos
        public void AddItem(OrderItem item)
        {
            //Adicionando Pedido
            _items.Add(item);
            //Valida o item

            //Adiciona ao pedido
        }
        public void AddDelivery(Delivery delivery)
        {
            //Adicionando Entrega
            _deliverys.Add(delivery);
            //Valida o item
        }
        //To Place An Order
        public void Place()
        {

        }

    }
}