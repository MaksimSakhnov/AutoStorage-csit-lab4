using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp2
{
    //класс используемый при инициализации приложения
    internal class onLoad
    {
        private ObservableCollection<Product> products = new ObservableCollection<Product>();
        private List<string> itemsList = new List<string>();
        public onLoad()
        {

        }

        public ObservableCollection<Product> getProductsOnLoad()
        {
            string path = "./../../../items.txt";
            StreamReader sr = new StreamReader(path);
            List <string> items = new List<string>();
            for(int i = 0; i < 100; i++)
            {
                string line = sr.ReadLine();
                if(i!= 0)
                {
                    items.Add(line);
                }
            }

            sr.Close();
            Random rand = new Random();
            List<int> usedItems = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                bool flag = false;

                    int idx = rand.Next(0, 99);
                    for (int j = 0; j < usedItems.Count; j++)
                    {
                        if (usedItems[j] == idx)
                        {
                            flag = true;
                        }
                    }

                if (!flag)
                {
                    usedItems.Add(idx);
                    string name = items[idx];
                    int count = rand.Next(10, 35);
                    int countInPack = rand.Next(10, 40);
                    double weight = Convert.ToDouble(Convert.ToInt32(rand.NextDouble() * 10)) / 10;
                    int experationInDays = rand.Next(5, 15);
                    int price = rand.Next(50, 200);
                    Product temp = new Product(name, count, countInPack, weight, experationInDays, price);
                    this.itemsList.Add(name);
                    this.products.Add(temp);
                    flag = true;
                }
                else
                {
                    i--;
                }
                

            }
            return (this.products);

        }

        public List<Shop> getShopsOnLoad()
        {

            string path = "./../../../Shops.txt";
            int itemsCount = this.itemsList.Count;
            StreamReader sr = new StreamReader(path);
            List <string> shopNames = new List<string>();
            List<Shop> shops = new List<Shop>();

            //считываем названия из файла
            for (int i = 0; i < 15; i++)
            {
                string line = sr.ReadLine();
                if (i != 0)
                {
                    shopNames.Add(line);
                }
            }
            sr.Close();
            List<bool> usedShopNames = new List<bool>();
            for(int i = 0; i < 15; i++)
            {
                usedShopNames.Add(false);
            }
            Random rand = new Random();
            for (int i = 0; i < 5; i++)
            {
                int idx = rand.Next(0, 14);
                if(usedShopNames[idx] == false)
                {
                    usedShopNames[idx] = true;
                    string name = shopNames[idx];
                    List<string> shopItems = new List<string>();
                    List<Product> tempProducts = new List<Product>();
                    List<bool> usedItems = new List<bool>();
                    for (int j =0; j < itemsCount; j++)
                    {
                        usedItems.Add(false);
                    }

                    //добавляем 4 разных товара, для каждого магазина
                    for(int j = 0;j< 4; j++)
                    {
                        int itemIdx = rand.Next(0, itemsCount - 1);
                        if(usedItems[itemIdx] == false)
                        {
                            usedItems[itemIdx] = true;
                            shopItems.Add(this.itemsList[itemIdx]);
                        }
                        else
                        {
                            j--;
                        }
                    }

                    for (int j = 0; j < shopItems.Count; j++)
                    {
                        int count = rand.Next(20, 50);
                        Product temp = new Product(shopItems[j],count);
                        tempProducts.Add(temp);
                    }
                    Shop tempShop = new Shop(name, shopItems, tempProducts);
                    shops.Add(tempShop);
                }
                else
                {
                    i--;
                }
            }
            return (shops);
        }


    }
}
