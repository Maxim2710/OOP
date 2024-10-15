using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Interfaces
{
    public interface ICategory
    {
        string CategoryName { get; }

        List<IProduct> Products { get; }

        void AddProduct(IProduct product);
    }
}
