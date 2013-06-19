using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaxySports.Domain.Entities;

namespace GalaxySports.Domain.Abstract
{
    public interface IOrderProcessor
    {
        void ProcessOrder(IOrderRepository orderRepository, IOrderProductRepository orderProductRepository, Cart cart, ShippingDetails shippingInfo);
    }
}
