using c_sharp_inal_project.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace c_sharp_inal_project.Services
{
    class Market : IMarketable
    {
        public List<Product> Products { get; set; }
        public List<Sale> Sales { get; set; }
        public Market()
        {
            Products = new();
            Sales = new();
        }
        #region ProductsMethods
        //Mehsulun elave olunmasi metodu
        public void AddProduct(string name, double price, int count, Categories category)
        {
            Product product = new();
            product.Name = name;
            product.Price = price;
            product.categories = category;
            product.Count = count;
            Products.Add(product);
        }
        //Mehsullarin adini,sayini,katiqoriyasini ve qiymeytini deyisen metod
        public void ChangeProduct(int no)
        {           
            int b = 0;
            double c = 0;
            int d = 0;          
            var change =Products.FirstOrDefault(i => i.No == no);
            if (change==null)
            {
                throw new ArgumentNullException("Bele bir mehsul yoxdu");
            }
            do
            {
                Console.WriteLine("1-Change the name");
                Console.WriteLine("2-Change the category");
                Console.WriteLine("3-Change the price");
                Console.WriteLine("4-Change the count");
                Console.WriteLine("5-Exit");
                Console.WriteLine("What surgery do you want to do");
                string strb = Console.ReadLine();
                while (!int.TryParse(strb, out b))
                {
                    Console.WriteLine("Please enter number correct");
                    strb = Console.ReadLine();
                }
                if (b<=0||b>=6)
                {
                    throw new ArgumentOutOfRangeException("Bele emeliyyat yoxdu");
                }
                switch (b)
                {
                    case 1:
                        Console.WriteLine("Enter new name");
                        string newname = Console.ReadLine();
                        change.Name = newname;
                        break;
                    case 2:
                        Console.WriteLine("Enter new category");
                        Console.WriteLine("Categories");
                        int index = 1;
                        foreach (var item in Enum.GetValues(typeof(Categories)))
                        {

                            Console.WriteLine($"{index}. {item}");
                            index++;

                        }
                        int pick = 0;
                        Console.WriteLine("Please select the catigories");
                        string strpick = Console.ReadLine();
                        while (!int.TryParse(strpick,out pick))
                        {
                            Console.WriteLine("Please enter the correct number");
                            strpick = Console.ReadLine();
                        }
                        if (pick <= 0 || pick >= 6)
                        {
                            throw new ArgumentNullException("Bele katiqoriya yoxdu");
                        }
                        Categories sort = new();
                        switch (pick)
                        {
                            case (int)Categories.FoodFlour:
                                sort = Categories.FoodFlour;

                                break;
                            case (int)Categories.Chocolate:
                                sort = Categories.Chocolate;

                                break;
                            case (int)Categories.Fruit:
                                sort = Categories.Fruit;

                                break;
                            case (int)Categories.Vegtables:
                                sort = Categories.Vegtables;

                                break;
                            case (int)Categories.Meat:
                                sort = Categories.Meat;

                                break;
                            default:
                                break;
                        }
                        break;                     
                    case 3:
                        Console.WriteLine("Enter new price");
                        string doubl = Console.ReadLine();
                        while (!double.TryParse(doubl, out c))
                        {
                            Console.WriteLine("Please enter number correct");
                            doubl = Console.ReadLine();
                        }
                        change.Price = c;
                        break;
                    case 4:
                        Console.WriteLine("Enter the new count");
                        string newcount = Console.ReadLine();
                        while (!int.TryParse(newcount, out d))
                        {
                            Console.WriteLine("Please enter number correct");
                            newcount = Console.ReadLine();
                        }
                        change.Count = d;
                        break;
                    default:
                        break;
                }

            } while (b != 5);
        }
        //Mehsullari silen metod
        public void ClearProduct(int no)
        {
            int index = Products.FindIndex(a => a.No == no);
            if (index==-1)
            {
                throw new ArgumentOutOfRangeException("Bele mehsul yoxdu");
            }
            Products.RemoveAt(index);
        }
        //Katiqoriyasina gore mehsullari gosteren metod
        public List<Product> SerchforCategoryProduct(Categories category)
        {
            List<Product> products = Products.Where(a => a.categories == category).ToList();           
            return products;            
        }
        //Qiymet araligina gore mehsullari gosteren metod
        public List<Product> SearchforPriceProduct(double startprice,double endprice)
        {
            var result = Products.FindAll(a => a.Price >= startprice && a.Price <= endprice);
            return result;
        }
        //Ada gore mehsullari gosteren metod
        public List<Product> SearchforNameProduct(string name)
        {
            var result = Products.FindAll(a => a.Name == name);
            return result;
        }
        #endregion
        #region SellMethods
        //Mehsulu ve Mehsullari satmaq ucun metod
        public void AddSell(int no, int count,Sale sale)
        {
            SaleItem saleItem = new();
            
            int index = Products.FindIndex(a => a.No == no);
            if (index==-1)
            {
                throw new ArgumentNullException("Bele mehsul yoxdu");
            }
            var result = Products.ElementAt(index);
            result.Count = result.Count - count;
            if (result.Count<0)
            {
                throw new ArgumentNullException("Bu qeder mehsul bazada yoxdu");
            }
            double b = (double)(result.Price * count);
            sale.SalePrice += b;
            saleItem.products = result;
            saleItem.Quantity += count;
            sale.Items.Add(saleItem);           
            
        }
        //Satilmis mehsulu geri qaytaran metod
        public void ReturnofProduct(int no,string name,int count)
        {
            Sale sale = Sales.FirstOrDefault(a=>a.No==no);
            if (sale==null)
            {
                throw new ArgumentNullException("Bele satis yoxdu");
            }
            SaleItem saleitem = sale.Items.FirstOrDefault(a => a.Quantity>=count);
            Product product = Products.FirstOrDefault(a => a.Name == name);
            if (product==null)
            {
                throw new ArgumentNullException("Bele mehsul yoxdu");
            }
            sale.Items.Remove(saleitem);
            product.Count += count;
            sale.SalePrice -= product.Price * count;
            if (sale.SalePrice<=-1)
            {
                throw new ArgumentOutOfRangeException("Aldiginiz malin qiymeti qaytarilan malin qiymetinden azdir");
            }            
            if (saleitem.Quantity-count<=-1)
            {
                throw new ArgumentNullException("Secdiyiniz satisda bu qeder mehsul yoxdu");
            }
            sale.Items.Add(saleitem);
           
           
                        
        }
        //Olmus satisi silmek ucun metod
        public void DeleteSale(int no)
        {
            int index = Sales.FindIndex(a => a.No == no);
            if (index==-1)
            {
                throw new ArgumentNullException("Bele bir satis yoxdu");
            }
            Sales.RemoveAt(index);
        }
        //Tarix araligina gore satisi gosteren metod
        public List<Sale> DisplayRangeOfDateSale(DateTime date1,DateTime date2)
        {
            var result = Sales.FindAll(a => a.Date >= date1 && a.Date <= date2);          
            return result.ToList();
        }
        //Qiymet araligina gore satisi gosteren metod
        public List<Sale> Displayrangeofpricesale(double price1,double price2)
        {
            var result = Sales.FindAll(a => a.SalePrice >= price1 && a.SalePrice <= price2);
            return result.ToList();
        }
        //Tex tarixe gore satisi gosteren metod
        public List<Sale> DisplayTheOneDaySale(DateTime day)
        {
            var result = Sales.FindAll(a => a.Date.Day == day.Day&&a.Date.Month==day.Month&&a.Date.Year==day.Year);
            return result.ToList();
        }
        //Nomreye gore satisi gosteren metod
        public List<Sale> DisplayTheNoSale(int no)
        {
            var result = Sales.FindAll(a => a.No == no);
            if (result.Count==0)
            {
                throw new ArgumentNullException($"{no} nomreli satis yoxdu");
            }
            return result;
        }


        #endregion


    }
}
