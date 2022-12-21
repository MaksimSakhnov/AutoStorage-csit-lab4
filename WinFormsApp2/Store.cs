using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp2
{
    /*
     * 1)неккоректно отображаются дни в приемке, нужно КОГДА-НИБУДЬ добавить поле день в запрос
        2) Склад отсылает запросы, когда количество конкретного продукта = 0

     */

    internal class Store
    {

        //таблицы
        public DataTable storageInfoTable = new DataTable();
        public DataTable shopsInfoTable = new DataTable();
        public DataTable priemkaInfoTable = new DataTable();
        public DataTable stats = new DataTable();

        public int day = 0;

        //очередь из запросов магазинов
        public Queue<Request> requestQueue = new Queue<Request>();
        //список всех запросов
        public ObservableCollection<Request> requestList = new ObservableCollection<Request>();
        //список магазинов
        public List<Shop> shopList = new List<Shop>();
        //список продуктов склада
        public ObservableCollection<Product> productsList = new ObservableCollection<Product>();
        //список статистик за каждый день
        public ObservableCollection<Statistics> statistics = new ObservableCollection<Statistics>();

        //поставщик
        public Factory factory = new Factory();

        public Store()
        {
            onLoad init = new onLoad();
            this.productsList = init.getProductsOnLoad();
            this.storageInfoTableInit();
            this.shopList = init.getShopsOnLoad();
            this.shopsInfoTableInit();
            this.priemkaInfoTableInit();
            this.statsInfoTableInit();
            this.requestList.CollectionChanged += onRequestListChanged;
            this.productsList.CollectionChanged += onProductsListChanged;
            this.factory.requestsList.CollectionChanged += onFactoryListChanged;

            this.statistics.Add(new Statistics(this.day));

        }

        //иницилизация таблиц статистики
        private void statsInfoTableInit()
        {
            this.stats.Columns.Add("День", typeof(int));
            this.stats.Columns.Add("Заработано", typeof(int));
            this.stats.Columns.Add("Потрачено", typeof(int));
            this.stats.Columns.Add("Прибыль", typeof(int));
            this.stats.Columns.Add("Продуктов продано", typeof(int));
            this.stats.Columns.Add("Потери", typeof(int));
        }

        //иницилизация таблиц приемки 
        private void priemkaInfoTableInit()
        {
            this.priemkaInfoTable.Columns.Add("Название продукта", typeof(string));
            this.priemkaInfoTable.Columns.Add("Количество", typeof(int));
            this.priemkaInfoTable.Columns.Add("Дней до поставки", typeof(int));
        }

        //обработка изменения листа с статистикой 
        public void onStatsListChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            this.onUpdStatsList();
        }

        public void onUpdStatsList()
        {
            this.stats.Rows.Clear();
            for (int i = 0; i < this.statistics.Count; i++)
            {
                this.stats.Rows.Add(
                    this.statistics[i].Day,
                    this.statistics[i].Earn,
                    this.statistics[i].Spend,
                    this.statistics[i].Profit(),
                    this.statistics[i].ItemsSold,
                    this.statistics[i].Looses
                    );
            }
        }


        //обработка изменения листа с запросами на фабрику
        public void onFactoryListChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            this.onUpdFactoryList();
        }

        //обновление таблицы фабрики при изменении содержимого
        public void onUpdFactoryList()
        {
            this.priemkaInfoTable.Rows.Clear();
            for (int i = 0; i < this.factory.requestsList.Count; i++)
            {
                this.priemkaInfoTable.Rows.Add(
                    this.factory.requestsList[i].ProductName,
                    this.factory.requestsList[i].col,
                    this.factory.requestsList[i].daysToSend
                    );
            }
        }


        //иницилизация таблиц отгрузки
        private void shopsInfoTableInit()
        {
            shopsInfoTable.Columns.Add("День", typeof(int));
            shopsInfoTable.Columns.Add("Название магазина", typeof(string));
            shopsInfoTable.Columns.Add("Продукты", typeof(string));
            shopsInfoTable.Columns.Add("Количество", typeof(int));
            shopsInfoTable.Columns.Add("Статус", typeof(string));

        }

        //обработка события изменения списка продуктов
        public void onProductsListChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            this.onUpdProductList();
        }

        //перерисовка при обновлении элементов списка продуктов
        public void onUpdProductList()
        {
            storageInfoTable.Rows.Clear();
            for (int i = 0; i < this.productsList.Count; i++)
            {
                this.storageInfoTable.Rows.Add(
                    this.productsList[i].getName(),
                    this.productsList[i].getCount(),
                    this.productsList[i].getCountInPack(),
                    this.productsList[i].getWeight(),
                    this.productsList[i].getExpirationDateInDays(),
                    this.productsList[i].getPrice()
                    );
            }
        }

        //обработка события изменения списка запросов
        public void onRequestListChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            this.onUpdRequestList();

        }

        //перерисовка при обновлении списка очереди
        public void onUpdRequestList()
        {
            shopsInfoTable.Rows.Clear();


            for (int i = 0; i < requestList.Count; i++)
            {
                shopsInfoTable.Rows.Add(
                    this.day,
                    this.requestList[i].shopName,
                this.requestList[i].productName,
                this.requestList[i].col,
                this.requestList[i].getIsWaiting()
                );
            }
        }

        //инициализация таблицы Склада
        private void storageInfoTableInit()
        {

            this.storageInfoTable.Columns.Add("Название", typeof(string));
            this.storageInfoTable.Columns.Add("Количество упаковок", typeof(int));
            this.storageInfoTable.Columns.Add("Количество в упаковке", typeof(int));
            this.storageInfoTable.Columns.Add("Вес пачки, кг", typeof(double));
            this.storageInfoTable.Columns.Add("Годен дней", typeof(int));
            this.storageInfoTable.Columns.Add("Цена за оптовую упаковку", typeof(int));
            for (int i = 0; i < this.productsList.Count; i++)
            {
                this.storageInfoTable.Rows.Add(
                    this.productsList[i].getName(),
                    this.productsList[i].getCount(),
                    this.productsList[i].getCountInPack(),
                    this.productsList[i].getWeight(),
                    this.productsList[i].getExpirationDateInDays(),
                    this.productsList[i].getPrice()
                    );
            }


        }

        //добавление в очередь
        public void addToQueue(Request temp)
        {
            this.requestQueue.Enqueue(temp);
            this.requestList.Add(temp);
        }

        //добавляем запросы в очередь на обработку
        public void onShopsSendRequestsButtonClick()
        {
            List<Request> temp = new List<Request>();
            //магазины отправляют запросы
            for (int i = 0; i < shopList.Count; i++)
            {
                temp = shopList[i].sendProductRequest();
                for (int j = 0; j < temp.Count; j++)
                {
                    this.addToQueue(temp[j]);
                }
            }

        }

        //выполнить запрос
        public void RequestDone(Request temp)
        {
            for (int i = 0; i < requestList.Count; i++)
            {
                if ((this.requestList[i].shopName == temp.shopName)
                    & (this.requestList[i].productName == temp.productName)
                    & (this.requestList[i].col == temp.col))
                {
                    for (int j = 0; j < this.shopList.Count; j++)
                    {
                        if (this.requestList[i].shopName == shopList[j].Name)
                        {
                            
                            this.shopList[j].getProducts(temp.productName, temp.getFromStorage);
                        }
                    }
                    this.requestList[i].requestDone();
                    this.onUpdRequestList();
                    this.onUpdProductList();
                }
            }
        }

        // склад обрабатывает очередь запросов от магазинов
        public void onProcessingRequestsButtonClick()
        {

            for (int i = 0; i < requestQueue.Count; i++)
            {
                Request temp = requestQueue.Peek();
                for (int j = 0; j < productsList.Count; j++)
                {
                    if (temp.productName == productsList[j].getName())
                    {
                        int tempCol = temp.col;
                        int onPack = productsList[j].getCountInPack();
                        int packs = productsList[j].getCount();
                        int price = productsList[j].getPrice();
                        if (packs != 0)
                        {
                            if (tempCol % onPack == 0)
                            {
                                int col = tempCol / onPack;


                                

                                int earn = productsList[j].sell(col);
                                temp.setGetFromStorage(col * onPack);
                                this.RequestDone(temp);

                                this.statistics[this.day].addEarn(earn);
                                this.statistics[this.day].addItemsSold(col * onPack);
                                this.statistics[this.day].addLooses(productsList[j].losses(col));
                            }
                            else
                            {
                                int col = tempCol / onPack + 1;
                                int earn = productsList[j].sell(col);




                                temp.setGetFromStorage(col * onPack);
                                this.RequestDone(temp);

                                this.statistics[this.day].addEarn(earn);
                                this.statistics[this.day].addItemsSold(col);
                                this.statistics[this.day].addLooses(productsList[j].losses(col));
                            }

                            

                            requestQueue.Dequeue();
                            i--;
                            break;
                        }
                        else
                        {
                            requestQueue.Dequeue();
                            requestQueue.Enqueue(temp);

                        }

                    }
                }
            }



        }

        //отсылаем запросы поставщику
        public void onSendRequestsToFactoryClick()
        {
            Random random = new Random();
            for (int i =0; i < this.productsList.Count; i++)
            {
                if (productsList[i].getCount() == 0)
                {
                    int count = random.Next(10, 20);
                    RequestToFactory req = new RequestToFactory(productsList[i].getName(), count);
                    //добавляем в статистику затраты на закупку товара
                    this.statistics[this.day].addSpend(productsList[i].countExpenses(count));
                    this.factory.getRequest(req);
                }
            }
        }

        //обрабатываем ответ от фабрики
        public void onGetProductsFromFactoryClick()
        {
            List<RequestToFactory> response = this.factory.sendProducts();
            for(int i =0;i < response.Count; i++)
            {
                for(int j = 0; j < this.productsList.Count; j++)
                {
                    if(productsList[j].getName() == response[i].ProductName)
                    {
                        productsList[j].getProduct(response[i].col);
                        this.onUpdProductList();
                        break;
                    }
                }
            }
            
        }

        //Следующий день
        public void onNextDayClick()
        {
            this.onUpdStatsList();

            for (int i =0; i < this.productsList.Count; i++)
            {
                this.productsList[i].checkExpirationDateInDays();
                this.productsList[i].onDayOut();
                this.onUpdProductList();
            }

            for (int i =0; i < this.shopList.Count; i++)
            {
                this.shopList[i].onNextDayClick();

            }

            this.factory.onNextDayClick();
            this.onUpdFactoryList();

            this.day++;
            this.statistics.Add(new Statistics(this.day));
        }


        /*public void test()
        {
            Random random = new Random();
            for (int i = 0; i < this.productsList.Count; i++)
            {
                if (productsList[i].getCount() != 0)
                {
                    int count = random.Next(10, 20);
                    RequestToFactory req = new RequestToFactory(productsList[i].getName(), count);
                    this.factory.getRequest(req);
                }
            }
        }*/
    }


    
}
