using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectUAS.Models
{
    using System;
    using System.Collections.Generic;

    public partial class Pembatalan
    {
        public int id { get; set; }
        public Nullable<int> id_pemesanan { get; set; }
        public Nullable<double> denda { get; set; }
        public Nullable<double> refund { get; set; }

        public virtual Pemesanan Pemesanan { get; set; }
    }

}