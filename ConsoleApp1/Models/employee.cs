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
    
    public partial class employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public employee()
        {
            this.orders = new HashSet<orders>();
        }
    
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string otchestvo { get; set; }
        public Nullable<int> age { get; set; }
        public string phone_number { get; set; }
        public string email { get; set; }
        public int job_title { get; set; }
        public Nullable<decimal> salary { get; set; }
        public string work_experience { get; set; }
    
        public virtual job_doljnost job_doljnost { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<orders> orders { get; set; }
    }
}
