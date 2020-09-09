using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectUAS.Models
{
    using System;
    using System.Collections.Generic;

    public partial class Pembelian
    {
        public int id { get; set; }
        public Nullable<int> id_user { get; set; }
        public Nullable<int> id_kaset { get; set; }
        public Nullable<int> jumlah { get; set; }
        public string tanggal_pembelian { get; set; }
        public Nullable<double> harga { get; set; }

        public virtual Kaset Kaset { get; set; }
        public virtual User User { get; set; }
    }

}