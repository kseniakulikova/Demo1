using Demo1.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo1.Classes
{
    internal class Modul4
    {
        public int GetCountMaterial(int productID, int materialTypeID, double length, double width, int countProduct)
        {
            Products product = DemoEntities.GetContext().Products.Where(p => p.ID == productID).FirstOrDefault();

            MaterialType materialType = DemoEntities.GetContext().MaterialType.Where(m => m.ID == materialTypeID).FirstOrDefault();

            if (materialType == null || product == null || length <= 0 || width <= 0 || countProduct <= 0)
            {
                return -1;
            }
            double coeff = (double)product.ProductType.Coefficient;
            double procentDeffect = (double)materialType.ScrapeRate;

            if (coeff <= 0 || procentDeffect < 0 || procentDeffect > 1)
            {
                return -1;
            }
            return (int)Math.Ceiling(length * width * coeff * (1 + procentDeffect) * countProduct);

        }

    }
}
