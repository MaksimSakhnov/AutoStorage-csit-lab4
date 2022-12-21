using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace WinFormsApp2
{
    internal class Factory
    {
        public ObservableCollection<RequestToFactory> requestsList = new ObservableCollection<RequestToFactory>();
        public Factory()
        {

        }

        //полуяаем запрос
        public void getRequest(RequestToFactory temp)
        {
            bool flag = false;
            //обработка запроса, если такой товар уже есть, то не добавляем запрос
            for (int i = 0; i < requestsList.Count; i++)
            {
                if(requestsList[i].ProductName == temp.ProductName)
                {
                    flag = true;
                }
            }
            if (!flag)
            {
                Random rand = new Random();
                int daysToSend = rand.Next(1, 3);
                temp.daysToSend = daysToSend;
                requestsList.Add(temp);
            }
            

        }

        public List<RequestToFactory> sendProducts()
        {
            List<RequestToFactory> products = new List<RequestToFactory>();
            for(int i = 0; i < requestsList.Count; i++)
            {
                if(requestsList[i].daysToSend == 0)
                {
                    products.Add(requestsList[i]);
                    requestsList.RemoveAt(i);
                    i--;
                }
            }
            return products;
        }

        public void onNextDayClick()
        {
            for (int i = 0; i < requestsList.Count; i++)
            {
                requestsList[i].onNextDayClick();
            }
        }
    }
}
