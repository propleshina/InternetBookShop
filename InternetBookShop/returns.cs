//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InternetBookShop
{
    using System;
    using System.Collections.Generic;
    
    public partial class returns
    {
        public int return_id { get; set; }
        public Nullable<int> orderID { get; set; }
    
        public virtual Orders Orders { get; set; }
    }
}
