using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Interfaces
{
    public interface IProduct
    {
        int Id { get; }

        string Name { get; }

        decimal Price { get; }

        string Description { get; }

        string GetProductDetails();

    }
}
