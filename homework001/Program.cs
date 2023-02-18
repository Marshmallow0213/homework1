using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace homework001
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var list = CreatList();
            Console.WriteLine("選擇分頁以查看資料(共4頁)");
            var page = "";

            page = Console.ReadLine();
            if (page == "1")
            {
                var totalprice = list.Sum((x) => x.price);
                Console.WriteLine($"1.商品的總價格: {totalprice}");

                var averageprice = list.Average((x) => x.price);
                Console.WriteLine($"2.所有商品的平均價格: {averageprice}");

                var totalnumber = list.Sum((x) => x.number);
                Console.WriteLine($"3.商品的總數量: {totalnumber}");

                var averagenumber = list.Average((x) => x.price);
                Console.WriteLine($"4.商品的平均數量: {averagenumber}");

            }
            else if (page == ("2"))
            {
                var expensive = list.Max((x) => x.price);
                var expensivenumber = list.SingleOrDefault((x) => x.price == expensive);
                Console.WriteLine($"5.最貴的商品是: {expensivenumber.name}");

                var Cheap = list.Min((x) => x.price);
                var Cheapname = list.SingleOrDefault((x) => x.price == Cheap);
                Console.WriteLine($"6.最便宜的商品是: {Cheapname.name}");

                var total3C = list.GroupBy((x) => x.category);
                foreach (var item in total3C)
                {
                    if (item.Key == "3C")
                    {
                        var totalprice3C = item.Sum((x) => x.price);
                        Console.WriteLine($"7.產品類別為 3C 的商品總價: {totalprice3C}");
                    }
                }

                var totalother = list.GroupBy((x) => x.category);
                foreach (var item in totalother)
                {
                    if (item.Key == "3C")
                    { }
                    else if (item.Key == "飲料")
                    {
                        var totalpricedrink = item.Sum((x) => x.price);
                        Console.WriteLine($"8(1)飲料的商品價格: {totalpricedrink}");
                    }
                    else if (item.Key == "食品")
                    {
                        var totalpricefood = item.Sum((x) => x.price);
                        Console.WriteLine($"8(2)食品的商品價格: {totalpricefood}");
                    }
                }
            }
            else if (page == ("3"))
            {
                var totalfood = list.GroupBy((x) => x.category);
                foreach (var item in totalfood)
                {
                    if (item.Key == "食品")
                    {
                        foreach(var food in item)
                        {
                            if(food.number > 100)
                            {
                                Console.WriteLine($"9.商品類別為食品，而且商品數量大於 100 的商品: {food.name}");
                            }
                        }
                    }
                }

                var totalitem = list.GroupBy((x) => x.category);
                foreach (var item in totalfood)
                {
                        foreach (var food in item)
                        {
                            if (food.price > 1000)
                            {
                                Console.WriteLine($"10.各個商品類別底下有這些商品的價格是大於1000的: {food.name}");
                            }
                        }
                }


                var totalaverage = list.GroupBy((x) => x.category);
                foreach (var item in totalaverage)
                {
                    foreach (var Price in item)
                    {
                        if (Price.price > 1000)
                        {
                            var totalofaverage = item.Average((x) => x.price);
                            Console.WriteLine($"11.大於1000的平均價格為{totalofaverage}");
                        }
                    }
                }

                var pricehtol = list.OrderByDescending((x) => x.price).ThenBy((x) => x.name);
                Console.WriteLine("12.照商品價格由高到低:");
                Display(pricehtol);









            }

            else if (page == ("4"))
            {
                var priceltoh = list.OrderBy((x) => x.price).ThenBy((x) => x.name);
                Console.WriteLine("13.照商品價格由低到高:");
                Display(priceltoh);

                var allmax = list.GroupBy((x) => x.category);
                foreach (var item in allmax)
                {
                    Console.WriteLine("14.最貴的商品是:");
                    var maxprice = item.Max((x) => x.price);
                    foreach (var product in item)
                    {
                        if (product.price == maxprice)
                        {
                            Console.WriteLine(product.name);
                        }
                    }
                }


                var allmin = list.GroupBy((x) => x.category);
                foreach (var item in allmin)
                {
                    Console.WriteLine("15.最便宜的商品是:");
                    var minprice = item.Min((x) => x.price);
                    foreach (var product in item)
                    {
                        if (product.price == minprice)
                        {
                            Console.WriteLine(product.name);
                        }
                    }
                }

                Console.WriteLine("16.價格小於等於 10000 的商品是:");
                foreach(var item in list)
                {
                    if(item.price <= 10000)
                    {
                        Console.WriteLine(item.name);
                    }
                }

            }
            else
            {
                Console.WriteLine("輸入錯誤的頁碼噢");
            }









            Console.ReadLine();

        }
        static void Display(IOrderedEnumerable<Product> source)
        {
            foreach (var item in source)
            {
                Console.WriteLine(item.name + item.price);
            }
            Console.WriteLine("-------------");
        }

        static List<Product> CreatList()
        {
            return new List<Product>()
            {
                new Product{ name = "Iphone 14", number = 23 , price = 45000 , category = "3C" },
                new Product{ name = "SamSung A52", number = 10 , price = 23000 , category = "3C" },
                new Product{ name = "SamSung S20", number = 15 , price = 35200 , category = "3C" },
                new Product{ name = "青森頻果原汁", number = 100 , price = 370, category = "飲料" },
                new Product{ name = "綠茶(瓶裝)", number = 1000 , price = 25 , category = "飲料" },
                new Product{ name = "辛拉麵(袋裝)", number = 1000 , price = 50 , category = "食品" },
                new Product{ name = "台酒麻油雞泡麵(碗裝)", number = 5000 , price = 53 , category = "食品" },
                new Product{ name = "台酒花雕雞泡麵(碗裝)", number = 10000 , price = 53 , category = "食品" },
                new Product{ name = "台酒酸菜牛肉泡麵(碗裝)", number = 12000 , price = 53 , category = "食品" },
                new Product{ name = "滿漢大餐珍味牛肉麵(碗裝)", number = 25080 , price = 53 , category = "食品" },
                new Product{ name = "烏龍茶(瓶裝)", number = 10000 , price = 35 , category = "飲料" },
                new Product{ name = "錫蘭奶茶(瓶裝)", number = 5000 , price = 20 , category = "飲料" },
                new Product{ name = "紅茶(瓶裝)", number = 1230 , price = 25 , category = "飲料" },
                new Product{ name = "台酒花雕雞泡麵(碗裝)", number = 10000 , price = 53 , category = "食品" },
                new Product{ name = "台酒花雕雞泡麵(袋裝)", number = 250000 , price = 45, category = "食品" },
                new Product{ name = "Ipad Pro ", number = 1000 , price =  53420 , category = "3C" },
                new Product{ name = "筆記型電腦", number = 1235 , price = 33023 , category = "3C" },
                

            };
        }
    }
}
