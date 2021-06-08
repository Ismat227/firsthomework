using c_sharp_inal_project.Database.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_inal_project.Database.Entities
{
    class SaleItem:BaseEntity
    {
        private static int count = 0;
        public Product products { get; set; }
        public int Quantity { get; set; }
        public SaleItem()
        {
            count++;
            No = count;
        }
    }
}
