//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfApp3
{
    using System;
    using System.Collections.Generic;
    
    public partial class Accounting
    {
        public int records_id { get; set; }
        public Nullable<int> company_id { get; set; }
        public string nameProduct { get; set; }
        public Nullable<int> quantity { get; set; }
        public Nullable<int> price { get; set; }
    
        public virtual Reference Reference { get; set; }
    }
}
