using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectUAS.Models
{
    using System;
    using System.Collections.Generic;

    public partial class Peminjaman
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Peminjaman()
        {
            this.Pengembalians = new HashSet<Pengembalian>();
        }

        public int id { get; set; }
        public Nullable<int> id_user { get; set; }
        public Nullable<int> id_kaset { get; set; }
        public Nullable<double> harga { get; set; }
        public string tanggal_peminjaman { get; set; }
        public string tanggal_pengembalian { get; set; }
        public string status_kembali { get; set; }

        public virtual Kaset Kaset { get; set; }
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pengembalian> Pengembalians { get; set; }
    }

}