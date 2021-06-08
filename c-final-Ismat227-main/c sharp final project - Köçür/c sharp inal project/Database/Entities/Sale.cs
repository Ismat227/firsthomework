
using c_sharp_inal_project.Database.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_inal_project.Database.Entities
{
    class Sale:BaseEntity
    {
        private static int count = 0;
        public double SalePrice { get; set; }
        public DateTime Date { get; set; }
        public List<SaleItem> Items { get; set; }
        public Sale()
        {
            Date = DateTime.Now;
            Items = new();
            count++;
            No = count;

        }

    }
    
}
