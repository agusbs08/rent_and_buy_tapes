using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectUAS.Models;

namespace ProjectUAS.Models
{
    public class HomeModel
    {
        public List<Kaset> allKaset { set; get; }
        public List<Kaset> topTenKaset { set; get; }

        public HomeModel()
        {
            allKaset = new List<Kaset>();
            topTenKaset = new List<Kaset>();
        }

        public HomeModel(List<Kaset> allKaset, List<Kaset> topTenKaset)
        {
            this.allKaset = allKaset;
            this.topTenKaset = topTenKaset;
        }
    }
}