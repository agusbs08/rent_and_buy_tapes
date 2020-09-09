using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectUAS.Models
{
    using System;
    using System.Collections.Generic;

    public partial class Pengembalian
    {
        public int id { get; set; }
        public Nullable<int> id_peminjaman { get; set; }
        public Nullable<double> denda { get; set; }
        public virtual Peminjaman Peminjaman { get; set; }
    }

}