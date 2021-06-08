using c_sharp_inal_project.Database.Entities;
using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_inal_project.Services
{
    
    class MenuService
    {

        static Market market = new();
        #region ProductMethods
        //Mehsulun elave olunmasi metodu
        public static void AddProduct()
        {
            int count = 0;
            double price = 0;
            Console.WriteLine("Please enter products name");
            string name = Console.ReadLine();
            if (name==null)
            {
                throw new ArgumentNullException("Mehsulun adin daxil edin   `");
            }
            Console.WriteLine("Please enter products price");
            string pricestr = Console.ReadLine();
            while (!double.TryParse(pricestr,out price))
            {
                Console.WriteLine("Please enter the correct number ");
                pricestr = Console.ReadLine();
            }
            Console.WriteLine("Categories");
            if (price<=0)
            {
                throw new ArgumentOutOfRangeException("Qiymeti menfi daxil ede bilmersen");
            }
            int index = 1;
            foreach (var item in Enum.GetValues(typeof(Categories)))
            {

                Console.WriteLine($"{index}. {item}");
                index++;

            }
            int pick = 0;
            string strpick = Console.ReadLine();
            while (!int.TryParse(strpick,out pick))
            {
                Console.WriteLine("Please enter the correct number");
                strpick = Console.ReadLine();
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
            if (pick>=6||pick<=0)
            {
                throw new ArgumentNullException("Bele katiqoriya yoxdu");
            }
          
            Console.WriteLine("Please enter products count");
            string countstr = Console.ReadLine();
            while (!Int32.TryParse(countstr,out count))
            {
                Console.WriteLine("Please enter the correct number");
                countstr = Console.ReadLine();
            }
            if (count<=0)
            {
                throw new ArgumentOutOfRangeException("Mehsulun sayi menfi ola bilmez");
            }
            market.AddProduct(name, price, count, sort);

        }
        //Mehsullarin adini,sayini,katiqoriyasini ve qiymeytini deyisen metod
        public static void ChangeProducts()
        {
            int code = 0;
           
           
            var table = new ConsoleTable("No","Name", "Category", "Price","Count");
            foreach (var products in market.Products)
            {
                table.AddRow(products.No,products.Name, products.categories, products.Price, products.Count);
            }
            table.Write();
            Console.WriteLine();
            Console.WriteLine("Which the change product No ");
            string codestr = Console.ReadLine();
            while (!int.TryParse(codestr, out code))
            {
                Console.WriteLine("Please enter number correct");
                codestr = Console.ReadLine();
            }         
                      
            market.ChangeProduct(code);
        }
        //Mehsullari silen metod
        public static void ClearProduct()
        {
            int no = 0;
            var table = new ConsoleTable("No", "Name", "Category", "Price", "Count");
            foreach (var products in market.Products)
            {
                table.AddRow(products.No, products.Name, products.categories, products.Price, products.Count);
            }
            table.Write();
            Console.WriteLine();
            Console.WriteLine("Please write the delete product No");
            string strno = Console.ReadLine();
            while (!int.TryParse(strno,out no))
            {
                Console.WriteLine("Please enter number correctly");
                strno = Console.ReadLine();
            }
            market.ClearProduct(no);
        }
        //Umumi mehsullari gosteren metod
        public static void AllProductsView()
        {
            var table = new ConsoleTable("No", "Name", "Category", "Price", "Count");
            foreach (var products in market.Products)
            {
                table.AddRow(products.No, products.Name, products.categories, products.Price, products.Count);
            }
            table.Write();
            Console.WriteLine();
            
        }
        //Katiqoriyasina gore mehsullari gosteren metod
        public static void SerachforCategoryproduct()
        {
            var table = new ConsoleTable("No", "Name", "Category", "Price", "Count");
            int index = 1;
            foreach (var item in Enum.GetValues(typeof(Categories)))
            {

                Console.WriteLine($"{index}. {item}");
                index++;

            }

            int pick = 0;
            Console.WriteLine("Please select category");
            string strpick = Console.ReadLine();
            while (!int.TryParse(strpick, out pick))
            {
                Console.WriteLine("Please enter the correct numer");
                strpick = Console.ReadLine();
            }
            if (pick<=0||pick>=6)
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
                     
            foreach (var products in market.SerchforCategoryProduct(sort))
            {
                table.AddRow(products.No, products.Name, products.categories, products.Price, products.Count);

            }
            table.Write();
            Console.WriteLine();

        }
        //Qiymet araligina gore mehsullari gosteren metod
        public static void SearchforPricCeProduct()
        {
            double startprice = 0;
            double endprice = 0;
            Console.WriteLine("Please enter the start price");
            string strstartprice = Console.ReadLine();
           
            while (!double.TryParse(strstartprice,out startprice))
            {
                Console.WriteLine("Please enter the number correctly");
                strstartprice = Console.ReadLine();
            }
            if (startprice<=0)
            {
                throw new ArgumentOutOfRangeException("Mehsulun qiymeti menfi ola bilmez");
            }
            Console.WriteLine("please enter the end price");
            string strendprice = Console.ReadLine();
            while (!double.TryParse(strendprice,out endprice))
            {
                Console.WriteLine("Please enter the number correctly");
                strendprice = Console.ReadLine();
            }
            if (endprice<=0)
            {
                throw new ArgumentOutOfRangeException("Mehsulun qiymeti menfi ola bilmez");
            }
            var table = new ConsoleTable("No", "Name", "Category", "Price", "Count");
            foreach (var products in market.SearchforPriceProduct(startprice,endprice))
            {
                table.AddRow(products.No, products.Name, products.categories, products.Price, products.Count);
            }
            table.Write();
            Console.WriteLine();
        }
        //Ada gore mehsullari gosteren metod
        public static void SearchforNameProduct()
        {
            var table = new ConsoleTable("No", "Name", "Category", "Price", "Count");
            Console.WriteLine("Please enter the product name");
            string name = Console.ReadLine();
            foreach (var products in market.SearchforNameProduct(name))
            {
                table.AddRow(products.No, products.Name, products.categories, products.Price, products.Count);
            }
            table.Write();
            Console.WriteLine();
        }
        #endregion
        #region SellMethods
        //Mehsulu ve Mehsullari satmaq ucun metod
        public static void AddSell()
        {
            Sale sale = new();
            int sell = 0;
            do
            {
                Console.WriteLine("1-Add Product");
                Console.WriteLine("2-Exit");
                Console.WriteLine("Which operation do you want to do");
                string strsell = Console.ReadLine();
                while (!int.TryParse(strsell, out sell))
                {
                    Console.WriteLine("Please enter the correct number");
                    strsell = Console.ReadLine();
                }
                if (sell<=0||sell>=3)
                {
                    throw new ArgumentOutOfRangeException("Bele emeliyyat yoxdu");
                }
                switch (sell)
                {
                    case 1:
                        int no = 0;
                        var table = new ConsoleTable("No", "Name", "Category", "Price", "Count");
                        foreach (var products in market.Products)
                        {
                            table.AddRow(products.No, products.Name, products.categories, products.Price, products.Count);
                        }
                        table.Write();
                        Console.WriteLine();
                        Console.WriteLine("Choose the sell product No");
                        string strno = Console.ReadLine();
                        while (!int.TryParse(strno,out no))
                        {
                            Console.WriteLine("Please enter the correct number");
                            strno = Console.ReadLine();
                        }
                        int count = 0;
                        Console.WriteLine("How much do you want to sell");
                        string strcount = Console.ReadLine();
                        while (!int.TryParse(strcount,out count))
                        {
                            Console.WriteLine("Please enter the correct number");
                            strcount = Console.ReadLine();
                        }
                        market.AddSell(no, count, sale);
                        
                        break;
                    case 2:
                        market.Sales.Add(sale);
                        break;                   
                }
                
            } while (sell != 2);
        }
        //Satilmis mehsulu geri qaytaran metod
        public static void ReturnOfProduct()
        {
            int no = 0;
            int count = 0;
            var table = new ConsoleTable("No", "Sale Price", "Count", "Date");
            foreach (var sale in market.Sales)
            {
                table.AddRow(sale.No, sale.SalePrice, sale.Items.Count, sale.Date);
            }
            table.Write();
            Console.WriteLine();
            Console.WriteLine("Please enter the return sale NO");
            string strno = Console.ReadLine();
            while (!int.TryParse(strno,out no))
            {
                Console.WriteLine("Please enter the correct NO");
                strno = Console.ReadLine();
            }
            Console.WriteLine("Please write the return product name");
            string name = Console.ReadLine();
            Console.WriteLine("Please enter the return product count");
            string strcount = Console.ReadLine();
            while (!int.TryParse(strcount,out count))
            {
                Console.WriteLine("Please enter the correct count");
                strcount = Console.ReadLine();
            }
            market.ReturnofProduct(no, name, count);
        }
        //Olmus satisi silmek ucun metod
        public static void DeleteSale()
        {
            int no = 0;
            var table = new ConsoleTable("No", "Sale Price", "Count", "Date");
            foreach (var sale in market.Sales)
            {
                table.AddRow(sale.No, sale.SalePrice, sale.Items.Count, sale.Date);
            }            
            table.Write();
            Console.WriteLine();
            Console.WriteLine("Please write the delete sale No");
            string strno = Console.ReadLine();
            while (!int.TryParse(strno,out no))
            {
                Console.WriteLine("Please enter the number correctly");
                strno = Console.ReadLine();
            }
            market.DeleteSale(no);
        }
        //Butun satislari gosteren metod
        public static void AllSaleView()
        {
            var table = new ConsoleTable("No", "Sale Price", "Count", "Date");
            foreach (var sale in market.Sales)
            {
                table.AddRow(sale.No, sale.SalePrice, sale.Items.Count, sale.Date);
            }
            table.Write();
            Console.WriteLine();
        }
        //Tarix araligina gore satisi gosteren metod
        public static void DisplayRangeOfDateSale()
        {
            Console.WriteLine("Please enter start time (dd.mm.yyyy)");
            string strdate1 = Console.ReadLine();
            Console.WriteLine("Please enter the end time (dd.mm.yyyy)");
            string strdate2 = Console.ReadLine();
            DateTime date1 = DateTime.Parse(strdate1);
            DateTime date2 = DateTime.Parse(strdate2);
            var table = new ConsoleTable("No", "Sale Price", "Count", "Date");
            foreach (var sale in market.DisplayRangeOfDateSale(date1,date2))
            {
                table.AddRow(sale.No, sale.SalePrice, sale.Items.Count, sale.Date);
            }
            table.Write();
            Console.WriteLine();
           
        }
        //Qiymet araligina gore satisi gosteren metod
        public static void Displayrangeofpricesale()
        {
            double price1 = 0;
            double price2 = 0;
            Console.WriteLine("Please enter the start price ");
            string strprice1 = Console.ReadLine();
            while (!double.TryParse(strprice1,out price1))
            {
                Console.WriteLine("Please enter the correct number");
                strprice1= Console.ReadLine();
            }
            Console.WriteLine("Please enter the end price");
            string endprice2 = Console.ReadLine();
            while (!double.TryParse(endprice2,out price2))
            {
                Console.WriteLine("Please enter the correct number");
                endprice2 = Console.ReadLine();
            }
            var table = new ConsoleTable("No", "Sale Price", "Count", "Date");
            foreach (var sale in market.Displayrangeofpricesale(price1,price2))
            {
                table.AddRow(sale.No, sale.SalePrice, sale.Items.Count, sale.Date);
            }
            table.Write();
            Console.WriteLine();

        }
        //Tex tarixe gore satisi gosteren metod
        public static void DisplayTheOneDaySale()
        {
            Console.WriteLine("Please enter time(dd.mm.yyyy)");
            string strday = Console.ReadLine();
            DateTime day = DateTime.Parse(strday);
            var table = new ConsoleTable("No", "Sale Price", "Count", "Date");
            foreach (var sale in market.DisplayTheOneDaySale(day))
            {
                table.AddRow(sale.No, sale.SalePrice, sale.Items.Count, sale.Date);
            }
            table.Write();
            Console.WriteLine();
           
        }
        //Nomreye gore satisi gosteren metod
        public static void DisplayTheNoSale()
        {
            int no = 0;
            Console.WriteLine("Please enter the No");
            string strno = Console.ReadLine();
            while (!int.TryParse(strno,out no))
            {
                Console.WriteLine("Please enter the correct number");
                strno = Console.ReadLine();
            }
            var table = new ConsoleTable("No", "Sale Price", "Count", "Date");
            foreach (var sale in market.DisplayTheNoSale(no))
            {
                table.AddRow(sale.No, sale.SalePrice, sale.Items.Count, sale.Date);
            }
            table.Write();
            Console.WriteLine();
        }

        #endregion
    }
}
