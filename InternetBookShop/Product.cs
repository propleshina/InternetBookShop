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
    
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            this.Favourities = new HashSet<Favourities>();
            this.Products_in_order = new HashSet<Products_in_order>();
        }
    
        public int product_id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public Nullable<decimal> weight { get; set; }
        public Nullable<decimal> cost { get; set; }
        public Nullable<int> authorID { get; set; }
        public Nullable<int> publisherID { get; set; }
        public Nullable<int> reviewID { get; set; }
        public Nullable<int> storageID { get; set; }
        public Nullable<int> genreID { get; set; }
        public Nullable<int> categoryID { get; set; }
    
        public virtual Author Author { get; set; }
        public virtual Category Category { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Favourities> Favourities { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual Publisher Publisher { get; set; }
        public virtual Review Review { get; set; }
        public virtual storage storage { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Products_in_order> Products_in_order { get; set; }
    }
}