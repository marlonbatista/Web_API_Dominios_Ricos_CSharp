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

        //Criar um Pedido
        public void Place()
        {
            //Gerando número do Pedido
            Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 8).ToUpper();
            //Validar
        }
        //Pagar um Pedido
        public void Pay()
        {
            Status = EOrderStatus.Paid;
            //5 dias úteis para entregar

        }
        //Enviar um Pedido
        public void Ship()
        {
            // A cada 5 produtos é uma entrega
            var deliveries = new List<Delivery>();
            deliveries.Add(new Delivery(DateTime.Now.AddDays(5)));
            var count = 1;

            //Quebra  as entregas
            foreach (var item in _items)
            {
                if (count == 5)
                {
                    count = 0;
                    deliveries.Add(new Delivery(DateTime.Now.AddDays(5)));
                }
                count++;
            }

            //Envia todas as entregas
            deliveries.ForEach(e => e.Ship());

            //adiciona as entregas ao pedido
            deliveries.ForEach(e => _deliverys.Add(e));

        }
        //Cancelar um Pedido
        public void Cancel()
        {
            Status = EOrderStatus.Canceled;
            _deliverys.ToList().ForEach(x => x.Cancel());
        }
    }
}