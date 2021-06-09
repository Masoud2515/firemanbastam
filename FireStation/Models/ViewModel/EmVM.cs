using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FireStation.Models.ViewModel
{
    public class EmVM
    {
        public string Name { get; set; }
        public string Status { get; set; }

        public string Id { get; set; }
    }
    public class MaterialViewModel
    {
        public int Id { get; set; }

        public string name { get; set; }
        public string code { get; set; }
    }
}