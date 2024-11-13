using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Interfaces
{
    public interface IOrder
    {
        IUser User { get; }

        List<IProduct> Products { get; }

        decimal TotalPrice { get; }

        void PlaceOrder();
    }
}
