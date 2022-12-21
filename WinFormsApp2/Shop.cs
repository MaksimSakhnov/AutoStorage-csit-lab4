using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp2
{
    internal class Shop
    {
        private string _name;
        public List<string> _itemsList;
        private List<Product> shopStorage = new List<Product>();
        private List<Request> productRequestList = new List<Request>();
        public string Name { get { return _name; } }

        public Shop(string name, List<string> itemsList, List<Product> products)
        {
            _name = name;
            _itemsList = itemsList;
            shopStorage = products;
        }

        //отправляем запросы, если какого то товара меньше 10
        public List<Request> sendProductRequest()
        {
            this.productRequestList.Clear();
            Random rand = new Random();
            for (int i = 0; i < shopStorage.Count; i++)
            {
                if(shopStorage[i].getCountInShop() < 10)
                {
                    int count = rand.Next(10, 20);
                    Request req = new Request(this.Name, shopStorage[i].getName(), count);
                    this.productRequestList.Add(req);
                }
                
            }
            return this.productRequestList;
        }

        //получаем продукты из запроса
        public void getProducts(string productName, int productCol)
        {
            for (int i = 0; i < shopStorage.Count; i++)
            {
                if (shopStorage[i].getName().Equals(productName))
                {
                    shopStorage[i].addProductInShop(productCol);
                }
            }
        }

        public void onNextDayClick()
        {
            Random rand = new Random();
            for (int i = 0; i < shopStorage.Count; i++)
            {
                int currentColInShop = shopStorage[i].getCountInShop();
                shopStorage[i].sellInShop(rand.Next(0, currentColInShop));
            }
        }


    }

    


    




}
