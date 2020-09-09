using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectUAS.Models
{
    using System;
    using System.Collections.Generic;

    public partial class Pemesanan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pemesanan()
        {
            this.Pembatalans = new HashSet<Pembatalan>();
        }

        public int id { get; set; }
        public Nullable<int> id_user { get; set; }
        public Nullable<int> id_kaset { get; set; }
        public Nullable<int> jumlah { get; set; }
        public string tanggal_pemesanan { get; set; }
        public Nullable<double> harga { get; set; }
        public string status { get; set; }

        public virtual Kaset Kaset { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pembatalan> Pembatalans { get; set; }
        public virtual User User { get; set; }
    }

}