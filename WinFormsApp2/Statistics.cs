using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp2
{
    internal class Statistics
    {
        private int _day;
        private int _earn=0;
        private int _spend=0;
        private int _profit=0;
        private int _itemsSold=0;
        private int _looses=0;
        public Statistics(int day)
        {
            this._day = day;
        }

        public int Day { get { return _day; } }

        public int Earn { get { return _earn; } }

        public int Spend { get { return _spend; } }

        public int Profit()
        {
            return (this._earn - this._spend);
        }

        public int ItemsSold { get { return _itemsSold; } }

        public int Looses { get { return _looses; } }

        public void addEarn(int money)
        {
            this._earn += money;
        }

        public void addSpend(int money)
        {
            this._spend += money;
        }

        public void addItemsSold(int cItems)
        {
            this._itemsSold+=cItems;
        }

        public void addLooses(int lose)
        {
            this._looses += lose;
        }

        


    }
}
