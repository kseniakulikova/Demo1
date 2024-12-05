using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo1.DataBase
{
    public partial class Partners
    {
        public string TypeName => Type + " | " + Title;
        public string RatingString => "Рейтинг: " + Rating;
        public int GetProductCount()
        {
            return PartnerProducts.Sum(product => product.CountProduct.GetValueOrDefault(0));
        }
        public int GetDiscount()
        {
            var productCount = GetProductCount();

            if (productCount < 10000)
            {
                return 0;
            }
            if (productCount < 49999)
            {
                return 5;
            }
            if (productCount < 300000)
            {
                return 10;
            }
            return 15;
        }
        public string Discount => GetDiscount() + "%";
    }
}
