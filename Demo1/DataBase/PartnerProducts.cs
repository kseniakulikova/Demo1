//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Demo1.DataBase
{
    using System;
    using System.Collections.Generic;
    
    public partial class PartnerProducts
    {
        public int ID { get; set; }
        public Nullable<int> CountProduct { get; set; }
        public Nullable<System.DateTime> DateSale { get; set; }
        public Nullable<int> ProductID { get; set; }
        public Nullable<int> PartnerID { get; set; }
    
        public virtual Partners Partners { get; set; }
        public virtual Products Products { get; set; }
    }
}