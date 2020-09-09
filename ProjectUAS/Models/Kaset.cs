using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectUAS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public partial class Kaset
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Kaset()
        {
            this.Pembelians = new HashSet<Pembelian>();
            this.Pemesanans = new HashSet<Pemesanan>();
            this.Peminjamen = new HashSet<Peminjaman>();
        }

        [Key]
        public int id { get; set; }
        public string nama { get; set; }
        public Nullable<double> harga_sewa { get; set; }
        public Nullable<double> harga_beli { get; set; }
        public Nullable<int> stok { get; set; }
        public Nullable<int> jumlah_pencarian { get; set; }
        public Nullable<double> diskon { get; set; }
        public string imagepath { get; set; }

        [NotMapped]
        public HttpPostedFileBase imageFile { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pembelian> Pembelians { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pemesanan> Pemesanans { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Peminjaman> Peminjamen { get; set; }
    }

}