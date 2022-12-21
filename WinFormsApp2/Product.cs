using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp2
{
    internal class Product
    {
        private string _name;
        private int _count;
        private int _count_in_pack;
        private int _count_in_shop;
        private double _weight;
        private int _expirationDateInDays;
        private int _expirationDateInDaysStatic;
        private int _price;
        private int _purchasePrice;

        private int _priceWithDiscount;
        bool DiscountFlag;

        //конструктор для продукта, который будет использоваться на складе
        public Product(string name, int count, int count_in_pack, double weight, int expirationDateInDays, int price, int purchasePrice)
        {
            _name = name;
            _count = count;
            _count_in_pack = count_in_pack;
            _weight = weight;
            _expirationDateInDays = expirationDateInDays;
            _expirationDateInDaysStatic = expirationDateInDays;
            _price = price;
            _priceWithDiscount = price;
            DiscountFlag = false;
            _purchasePrice = purchasePrice;

        }

        //конструктор для продукта, который будет использоваться в магазине
        public Product(string name, int count_in_shop)
        {
            _name = name;
            _count_in_shop = count_in_shop;
        }

        public void priceDiscount()
        {
            if(_expirationDateInDays <= 3) {
                double temp_price = Convert.ToDouble(_price);
                _priceWithDiscount = (int)Math.Ceiling(temp_price * 0.7);
                DiscountFlag = true;
            }
        }

        public void addProductInShop(int col)
        {
            this._count_in_shop += col;
        }

        public int getCountInShop()
        {
            return (_count_in_shop);
        }

        public void sellInShop(int col)
        {
            _count_in_shop-= col;
        }

        public string getName()
        {
            return _name;
        }

        public int getCount()
        {
            return _count;

        }

        public int getCountInPack()
        {
            return _count_in_pack;
        }

        public double getWeight()
        {
            return _weight;

        }
        
        public int getExpirationDateInDays()
        {
            return _expirationDateInDays;

        }

        public int getPrice()
        {
            return _priceWithDiscount;
        }

        public bool getDiscountFlag()
        {
            return DiscountFlag;
        }


        //проверяем срок годности
        public void checkExpirationDateInDays()
        {
            if(_expirationDateInDays == 0)
            {
                _count = 0;
            }
        }

        public void getProduct(int col)
        {
            this._count += col;
            this.DiscountFlag = false;
            this._expirationDateInDays = this._expirationDateInDaysStatic;
            this.priceDiscount();
            this._priceWithDiscount = _price;
        }

        public int losses(int sellCount)
        {
            return (sellCount * _price - sellCount * _priceWithDiscount);
        }

        public int sell(int sellCount)
        {
            if(_count < sellCount)
            {
                int temp_count = _count;
                _count -= _count;

                return (temp_count * _price);
            }
            else
            {
                _count -= sellCount;
                return (sellCount * _price);
            }
        }

        public int countExpenses(int col)
        {
            return (this._purchasePrice * col);
        }



        public void onDayOut()
        {
            priceDiscount();
            
            _expirationDateInDays--;
        }


    }
}
