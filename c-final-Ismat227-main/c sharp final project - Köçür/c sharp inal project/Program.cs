using c_sharp_inal_project.Services;
using System;

namespace c_sharp_inal_project
{
    class Program
    {
        static void Main(string[] args)
        {
            {

                int a = 0;
                int b = 0;
                int c = 0;

                do
                {
                    Console.WriteLine("========İsmetin Marketi========");
                    Console.WriteLine("1-Mehsullar uzerinde emeliyyat aparmaq");
                    Console.WriteLine("2-Satislar uzerinde emeliyyat aparmaq");
                    Console.WriteLine("3-Sistemden cixmaq");
                    Console.WriteLine("Hansi emeliyati etmek isteyirsen");
                    string stra = Console.ReadLine();
                    while (!int.TryParse(stra, out a))
                    {
                        Console.WriteLine("Please enter the correct number");
                        stra = Console.ReadLine();
                    }
                    if (a <= 0 || a >= 4)
                    {
                        throw new ArgumentOutOfRangeException("Bele emeliyat yoxdu");
                    }
                    switch (a)
                    {
                        case 1:
                            do
                            {
                                Console.WriteLine("1-Add products");
                                Console.WriteLine("2-Change products");
                                Console.WriteLine("3-Clear products");
                                Console.WriteLine("4-All products");
                                Console.WriteLine("5-Show category product");
                                Console.WriteLine("6-Price range show product");
                                Console.WriteLine("7-Search name for products");
                                Console.WriteLine("0-Exit");
                                Console.WriteLine("What surgery do you want to do");
                                string strb = Console.ReadLine();
                                while (!int.TryParse(strb, out b))
                                {
                                    Console.WriteLine("Please enter the number correct");
                                    strb = Console.ReadLine();
                                }
                                if (b <= -1 || b >= 8)
                                {
                                    throw new ArgumentOutOfRangeException("Bele emeliyat yoxdu");
                                }
                                switch (b)
                                {
                                    case 1:
                                        MenuService.AddProduct();
                                        break;
                                    case 2:
                                        MenuService.ChangeProducts();
                                        break;
                                    case 3:
                                        MenuService.ClearProduct();
                                        break;
                                    case 4:
                                        MenuService.AllProductsView();
                                        break;
                                    case 5:
                                        MenuService.SerachforCategoryproduct();
                                        break;
                                    case 6:
                                        MenuService.SearchforPricCeProduct();
                                        break;
                                    case 7:
                                        MenuService.SearchforNameProduct();
                                        break;

                                    default:
                                        break;
                                }
                            } while (b != 0);
                            break;
                        case 2:
                            do
                            {
                                Console.WriteLine("1-Add new sales");
                                Console.WriteLine("2-Return of sale");
                                Console.WriteLine("3-Delete sale");
                                Console.WriteLine("4-Display all sale");
                                Console.WriteLine("5-Display range of date sale");
                                Console.WriteLine("6-Display range of price sale");
                                Console.WriteLine("7-Display o the one day sale");
                                Console.WriteLine("8-Display of No sale");
                                Console.WriteLine("0-Exit");
                                Console.WriteLine("=================================");
                                Console.WriteLine("Which operation do you want to do");

                                string strc = Console.ReadLine();
                                while (!int.TryParse(strc, out c))
                                {
                                    Console.WriteLine("Ededi duzgun daxil edin");
                                    strc = Console.ReadLine();
                                }
                                if (c <= -1 || c >= 9)
                                {
                                    throw new ArgumentOutOfRangeException("Bele emeliyat yoxdu");
                                }
                                switch (c)
                                {
                                    case 1:
                                        MenuService.AddSell();
                                        break;
                                    case 2:
                                        MenuService.ReturnOfProduct();
                                        break;
                                    case 3:
                                        MenuService.DeleteSale();
                                        break;
                                    case 4:
                                        MenuService.AllSaleView();
                                        break;
                                    case 5:
                                        MenuService.DisplayRangeOfDateSale();
                                        break;
                                    case 6:
                                        MenuService.Displayrangeofpricesale();
                                        break;
                                    case 7:
                                        MenuService.DisplayTheOneDaySale();
                                        break;
                                    case 8:
                                        MenuService.DisplayTheNoSale();
                                        break;
                                    default:
                                        break;
                                }
                            
                                break;
                            } while (b != 0);
                            break;

                        
                    }

                } while (a != 3);
            }
        }

    }
}
