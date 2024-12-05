using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo1.DataBase
{
    public partial class PartnerProducts
    {
        public string ProductName => Products.Title;
        public string LongDateSale => ((DateTime)DateSale).ToLongDateString();
    }
}
