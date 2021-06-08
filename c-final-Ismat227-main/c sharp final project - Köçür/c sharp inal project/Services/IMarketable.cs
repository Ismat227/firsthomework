using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_inal_project.Services
{
    interface IMarketable
    {
        #region Product
        public void AddProduCt(string Name, double Price, int Count, string Category)
        {

        }
        public void ChangeProduct(int code, string Name, double Price, int NewCode, int count, string Category)
        {

        }
        public void ClearProduct(int Code)
        {


        }
        public void AllProductsView()
        {

        }
        public void SearchforPriceproduct(double startprice, double endprice)
        {

        }
        public void SearchforCategoryproduct(string Category)
        {

        }
        public void SearchforNameproduct(string Name)
        {

        }
        #endregion
        #region Sell
        public void Addnewsales()
        {
                               

        }
        public void Returnofsale()
        {

        }
        public void Deletesale()
        {

        }
        public void Displayallsale()
        {

        }
        public void Displayrangeofdatesale()
        {

        }
        public void Displayrangeofpricesale()
        {
        }
        public void Displaytheonedaysale()
        {

        }
        public void DisplayofNosale()
        {

        }
        #endregion
    }
}
