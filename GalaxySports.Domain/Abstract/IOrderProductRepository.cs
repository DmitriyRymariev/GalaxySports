using GalaxySports.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySports.Domain.Abstract
{
    public interface IOrderProductRepository
    {
        IQueryable<OrderProduct> OrderProducts { get; }
        void SaveOrderProduct(OrderProduct orderProduct);
        void DeleteOrderProduct(OrderProduct orderProduct);
    }
}
