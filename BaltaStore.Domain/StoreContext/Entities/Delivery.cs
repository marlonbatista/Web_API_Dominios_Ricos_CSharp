using System;
using BaltaStore.Domain.StoreContext.Enums;

namespace BaltaStore.Domain.StoreContext.Entites
{
    public class Delivery
    {
        public Delivery(DateTime estimateDeliveryDate)
        {
            CreateDate = DateTime.Now;
            EstimateDeliveryDate = estimateDeliveryDate;
            Status = EDeliveryStatus.Waiting;
        }
        public DateTime CreateDate { get; private set; }
        public DateTime EstimateDeliveryDate { get; private set; }
        public EDeliveryStatus Status { get; private set; }

        public void Ship()
        {
            //Se a Data estimada de entrega for no passado, não entregar
            Status = EDeliveryStatus.Shipped;
        }
        public void Cancel()
        {
            // Se o Status já estiver entregue, não pode cancelar   
            Status = EDeliveryStatus.Canceled;
        }
    }
}