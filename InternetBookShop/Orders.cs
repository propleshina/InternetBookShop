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
    
    public partial class Orders
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Orders()
        {
            this.returns = new HashSet<returns>();
        }
    
        public int order_id { get; set; }
        public Nullable<int> client_id { get; set; }
        public Nullable<int> cartID { get; set; }
        public Nullable<int> addressID { get; set; }
        public Nullable<int> paymentID { get; set; }
        public Nullable<int> orderstatusID { get; set; }
    
        public virtual addresses addresses { get; set; }
        public virtual Client Client { get; set; }
        public virtual order_status order_status { get; set; }
        public virtual shopping_cart shopping_cart { get; set; }
        public virtual payment payment { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<returns> returns { get; set; }
    }
}
