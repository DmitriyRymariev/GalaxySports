using GalaxySports.Domain.Abstract;
using GalaxySports.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySports.Domain.Concrete
{
    public class EFOrderProductRepository : IOrderProductRepository
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<OrderProduct> OrderProducts
        {
            get { return context.OrderProducts; }
        }

        public void SaveOrderProduct(OrderProduct orderProduct)
        {
            if (orderProduct.ID == 0)
            {
                context.OrderProducts.Add(orderProduct);
            }
            else
            {
            }
            context.SaveChanges();
        }


        public void DeleteOrderProduct(OrderProduct orderProduct)
        {
            context.OrderProducts.Remove(orderProduct);
            context.SaveChanges();
        }
    }
}
