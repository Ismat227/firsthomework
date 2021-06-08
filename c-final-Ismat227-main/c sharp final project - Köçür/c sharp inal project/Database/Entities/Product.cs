using c_sharp_inal_project.Database.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_inal_project.Database.Entities
   

{
    class Product:BaseEntity
    {
        private static int count = 0;
        public string Name { get; set; }
        public double Price { get; set; }        
        public Categories categories { get; set; }
        public int Count { get; set; }
        public Product()
        {
            count++;
            No = count;
        }
    }
}
