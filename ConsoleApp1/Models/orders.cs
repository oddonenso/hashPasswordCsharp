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
    
    public partial class orders
    {
        public int id { get; set; }
        public int id_clients { get; set; }
        public int id_employee { get; set; }
        public int id_product { get; set; }
        public int id_contract { get; set; }
    
        public virtual clients clients { get; set; }
        public virtual contract contract { get; set; }
        public virtual employee employee { get; set; }
        public virtual product product { get; set; }
    }
}
