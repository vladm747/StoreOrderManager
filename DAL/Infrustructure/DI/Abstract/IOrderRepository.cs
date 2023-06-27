using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Infrustructure.DI.Abstract
{
    public interface IOrderRepository: IRepositoryBase<Order, int>
    {
    }
}
