//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConsoleApp1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class suppliers
    {
        public int id { get; set; }
        public string company_suppliers { get; set; }
        public int id_contract { get; set; }
        public int oborudivanie_id { get; set; }
    
        public virtual contract contract { get; set; }
        public virtual oborudivanie oborudivanie { get; set; }
    }
}
