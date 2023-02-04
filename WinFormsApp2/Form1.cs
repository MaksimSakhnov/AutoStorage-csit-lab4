using System.Data;

namespace WinFormsApp2
{
    public partial class StorageWindow : Form
    {
        public StorageWindow()
        {
            InitializeComponent();
        }


        Store store = new Store();
        string loaderPath = "./../../../loader.gif";
        bool onHandFlag = true;
        bool onAutoFlag = false;

        // доделать 
        public bool isWaiting = false;

        private void Form1_Load(object sender, EventArgs e)
        {
            StorageInfo.AllowUserToAddRows = false;
            StorageInfo.ReadOnly = true;

            OtgruzkaData.AllowUserToAddRows = false;
            OtgruzkaData.ReadOnly = true;
            OtgruzkaData.Visible = false;

            PriemkaData.AllowUserToAddRows = false;
            PriemkaData.ReadOnly=false;
            PriemkaData.Visible = false;

            StatisticsData.AllowUserToAddRows = false;
            StatisticsData.ReadOnly=false;
            StatisticsData.Visible = false;

            this.store.storageInfoTable.RowChanged += new DataRowChangeEventHandler(storageInfoTable_Changed);
            this.store.shopsInfoTable.RowChanged += new DataRowChangeEventHandler(shopsInfoTable_Changed);
            this.store.priemkaInfoTable.RowChanged += new DataRowChangeEventHandler(priemkaInfoTable_Changed);
            this.store.stats.RowChanged += new DataRowChangeEventHandler(statsInfoTable_Changed);

            StorageInfo.DataSource = this.store.storageInfoTable;
            OtgruzkaData.DataSource = this.store.shopsInfoTable;
            PriemkaData.DataSource = this.store.priemkaInfoTable;
            StatisticsData.DataSource = this.store.stats;
            dayLabel.Text = "0";
            stageLabel.Text = "Начало";

            loaderBox.Image = Image.FromFile(this.loaderPath);
            loaderBox.Visible = false;

            label4.Visible = false;
            textBox1.Visible = false;
            button6.Visible = false;

        }


        public void changeStage(string buttonName)
        {

            if(this.onHandFlag) loaderBox.Visible = true;

            if (buttonName == "button1")
            {
                button1.Enabled = true;
                stageLabel.Text = button1.Text;
                button2.Enabled = true;
                button3.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;

            }
            else if(buttonName == "button2")
            {
                button2.Enabled = true;
                stageLabel.Text = button2.Text;
                button1.Enabled = false;
                button3.Enabled = true;
                button4.Enabled = false;
                button5.Enabled = false;
            }
            else if(buttonName == "button3")
            {
                button3.Enabled = true;
                stageLabel.Text = button3.Text;
                button1.Enabled = false;
                button2.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = true;
            }
            else if(buttonName == "button4")
            {
                button4.Enabled = true;
                stageLabel.Text = button4.Text;
                button1.Enabled = true;
                button2.Enabled = false;
                button3.Enabled = false;
                button5.Enabled = false;
            }
            else if(buttonName == "button5")
            {
                button5.Enabled = true;
                stageLabel.Text = button5.Text;
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = true;
            }
        }

        // handle storageInfoTable_Changed event
        private void statsInfoTable_Changed(object sender, System.Data.DataRowChangeEventArgs e)
        {
            StatisticsData.DataSource = this.store.stats;
        }

        // handle storageInfoTable_Changed event
        private void storageInfoTable_Changed(object sender, System.Data.DataRowChangeEventArgs e)
        {
            StorageInfo.DataSource = this.store.storageInfoTable;
        }



        // handle shopsInfoTable_Changed event
        private void shopsInfoTable_Changed(object sender, System.Data.DataRowChangeEventArgs e)
        {
            OtgruzkaData.DataSource = this.store.shopsInfoTable;
        }

        // handle priemkaInfoTable_Changed event
        private void priemkaInfoTable_Changed(object sender, System.Data.DataRowChangeEventArgs e)
        {
            PriemkaData.DataSource = this.store.priemkaInfoTable;
        }

        /// navigation

        //переход на вкладку склада
        private void storage_btn_Click(object sender, EventArgs e)
        {
            StorageInfo.Visible = true;
            OtgruzkaData.Visible = false;
            PriemkaData.Visible=false;
            StatisticsData.Visible = false;

            label4.Visible = false;
            textBox1.Visible = false;
            button6.Visible = false;
        }


        //переход на вкладку отгрузки
        private void otgruzka_btn_Click(object sender, EventArgs e)
        {
            StorageInfo.Visible = false;
            OtgruzkaData.Visible = true;
            PriemkaData.Visible = false;
            StatisticsData.Visible = false;

            label4.Visible = false;
            textBox1.Visible = false;
            button6.Visible = false;

        }

        //переход на вкладку приемки
        private void priemka_btn_Click(object sender, EventArgs e)
        {
            StorageInfo.Visible = false;
            OtgruzkaData.Visible = false;
            PriemkaData.Visible = true;
            StatisticsData.Visible = false;

            label4.Visible = false;
            textBox1.Visible = false;
            button6.Visible = false;
        }

        //переход на вкладку статистики
        private void StatisticsButton_Click(object sender, EventArgs e)
        {
            StorageInfo.Visible = false;
            OtgruzkaData.Visible = false;
            PriemkaData.Visible = false;
            StatisticsData.Visible = true;

            label4.Visible = false;
            textBox1.Visible = false;
            button6.Visible = false;
        }
        // моделирование
        private void modelButton_Click(object sender, EventArgs e)
        {
            StorageInfo.Visible = false;
            OtgruzkaData.Visible = false;
            PriemkaData.Visible = false;
            StatisticsData.Visible = false;

            label4.Visible = true;
            textBox1.Visible = true;
            button6.Visible = true;

        }

        /// buttons

        //отсылаем запросы
        private void button1_Click(object sender, EventArgs e)
        {
            
            this.changeStage(button1.Name);
            
            this.store.onShopsSendRequestsButtonClick();
            if(!this.onAutoFlag)
            loaderBox.Visible = false;
        }


        //обрабатываем запросы
        private void button2_Click(object sender, EventArgs e)
        {
            this.changeStage(button2.Name);

            this.store.onProcessingRequestsButtonClick();
            if (!this.onAutoFlag)
                loaderBox.Visible = false;
        }

        //отсылаем запросы на фабрику
        private void button3_Click(object sender, EventArgs e)
        {
            this.changeStage(button3.Name);
            this.store.onSendRequestsToFactoryClick();
            if (!this.onAutoFlag)
                loaderBox.Visible = false;
        }

        //обрабатываем ответы от фабрики
        private void button5_Click(object sender, EventArgs e)
        {
            this.changeStage(button5.Name);
            stageLabel.Text = button5.Text;
            this.store.onGetProductsFromFactoryClick();
            if (!this.onAutoFlag)
                loaderBox.Visible = false;
        }

        //следующий день
        private void button4_Click(object sender, EventArgs e)
        {
            this.changeStage(button4.Name);
            this.store.onNextDayClick();
            this.dayLabel.Text = this.store.day.ToString();
            if (!this.onAutoFlag)
                loaderBox.Visible = false;
        }



        //запуск модулирования
        private void button6_Click(object sender, EventArgs e)
        {
            int countDays = 0;
            bool flag = false;
            try
            {
                countDays = int.Parse(this.textBox1.Text);
                flag = true;
                this.onAutoFlag = true;
                this.onHandFlag = false;
            }
            catch (Exception ex)
            {
                textBox1.Text = "Неверные данные";
                
            }

            if (flag)
            {
                this.loaderBox.Visible = true;


                for (int i = 0; i < countDays; i++)
                {
                    
                    this.button1_Click(sender, e);
                    Thread.Sleep(1000);
                    this.button2_Click(sender, e);
                    Thread.Sleep(1000);
                    this.button3_Click(sender, e);
                    Thread.Sleep(1000);
                    this.button5_Click(sender, e);
                    Thread.Sleep(1000);
                    this.button4_Click(sender, e);
                    Thread.Sleep(1000);

                }

                this.onAutoFlag = false;




            }
        }
    }


}