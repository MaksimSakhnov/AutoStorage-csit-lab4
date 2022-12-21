using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp2
{

    //
    internal class Request
    {
        //дни запроса неккоректно отображаются
        private string _shopName;
        private string _productName;
        private int _col;
        private bool _isWaiting;
        private int _getFromStorage;
        
        public Request(string shopName, string productName, int col)
        {
            this._shopName = shopName;
            this._productName = productName;
            this._col = col;
            this._isWaiting = true;
        }

        public int getFromStorage { get { return _getFromStorage; } }

        public string shopName { get { return _shopName; } }

        public string productName { get { return _productName; } }

        public int col { get { return _col; } }

        public void setGetFromStorage(int col)
        {
            _getFromStorage = col;
        }
        public string getIsWaiting()
        {
            if (this._isWaiting == false)
            {
                return ("Готово");
            }
            else
            {
                return ("Ожидание");
            }
        }

        public void requestDone()
        {
            this._isWaiting = false;

        }

    }


    internal class RequestToFactory
    {
        private string _productName;
        private int _col;
        private int _daysToSend;

        public RequestToFactory(string productName, int col)
        {
            _productName = productName;
            _col = col;
        }

        public void onNextDayClick()
        {
            _daysToSend--;
        }

        public string ProductName { get { return _productName; } }

        public int col { get { return _col; } }

        public int daysToSend
        {
            get { return _daysToSend; }
            set { _daysToSend = value; }
        }

    }
}
