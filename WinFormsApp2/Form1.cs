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

            this.store.storageInfoTable.RowChanged += new DataRowChangeEventHandler(storageInfoTable_Changed);
            this.store.shopsInfoTable.RowChanged += new DataRowChangeEventHandler(shopsInfoTable_Changed);
            this.store.priemkaInfoTable.RowChanged += new DataRowChangeEventHandler(priemkaInfoTable_Changed);
            StorageInfo.DataSource = this.store.storageInfoTable;
            OtgruzkaData.DataSource = this.store.shopsInfoTable;
            PriemkaData.DataSource = this.store.priemkaInfoTable;
            dayLabel.Text = "0";

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

        //переход на вкладку склада
        private void storage_btn_Click(object sender, EventArgs e)
        {
            StorageInfo.Visible = true;
            OtgruzkaData.Visible = false;
            PriemkaData.Visible=false;
        }


        //переход на вкладку отгрузки
        private void otgruzka_btn_Click(object sender, EventArgs e)
        {
            StorageInfo.Visible = false;
            OtgruzkaData.Visible = true;
            PriemkaData.Visible = false;

        }

        //переход на вкладку приемки
        private void priemka_btn_Click(object sender, EventArgs e)
        {
            StorageInfo.Visible = false;
            OtgruzkaData.Visible = false;
            PriemkaData.Visible = true;
        }

        //отсылаем запросы
        private void button1_Click(object sender, EventArgs e)
        {
            this.store.onShopsSendRequestsButtonClick();
            
        }

        

        //обрабатываем запросы
        private void button2_Click(object sender, EventArgs e)
        {
            this.store.onProcessingRequestsButtonClick();
        }

        //отсылаем запросы на фабрику
        private void button3_Click(object sender, EventArgs e)
        {
            this.store.onSendRequestsToFactoryClick();
        }

        //обрабатываем ответы от фабрики
        private void button5_Click(object sender, EventArgs e)
        {
            this.store.onGetProductsFromFactoryClick();
        }

        //следующий день
        private void button4_Click(object sender, EventArgs e)
        {
            this.store.onNextDayClick();
            this.dayLabel.Text = this.store.day.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.store.test();
        }
    }


}