using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AkilliEntegre.Model;
using System.IO;
using System.Data.OleDb;
using System.Xml;
using RestSharp;
using System.Net;
using System.Xml.Linq;
using System.Threading;
using System.Text.RegularExpressions;

namespace AkilliEntegre
{
    public partial class HBSection : MetroForm
    {
        Functions func = new Functions();
        HBAPi hb;
        Export exp = new Export();
        static MySQLConnect mysql = new MySQLConnect();
        String filePathExp = "";

        List<Listing> items = new List<Listing>();
        SaveFileDialog save = new SaveFileDialog();


        private string Excel03ConString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'";
        private string Excel07ConString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'";

        private String userName = "akilliphone_dev";
        private String password = "Ak12345!";
        //String merchantId = "1ecc8c0a-df6d-4f5f-8463-e6ea8ec6673d";
        private String merchantId = "b23af4c1-395a-4a82-b6fd-07eea0dd51b2";
        private String listingHost = "https://listing-external-sit.hepsiburada.com/";

        public HBSection()
        {
            InitializeComponent();
            this.hb = new HBAPi(apiUserBox.Text.ToString(),apiPassBox.Text.ToString(),apiKeyBox.Text.ToString(),apiUrlBox.Text.ToString());
        }

        private void backTile_Click(object sender, EventArgs e)
        {
            MainMenu main = new MainMenu();
            func.ShowForm(main, this);
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            this.UrunListeGetir();
        }

        private void StringXMLToDatatable(String content)
        {
            StringReader theReader = new StringReader(content);
            DataSet theDataSet = new DataSet();
            theDataSet.ReadXml(theReader);

            metroGrid1.DataSource = theDataSet.Tables[0];

        }

        IRestResponse UrunListesiGetir(String username, String password, String merchantId)
        {
            var client = new RestClient("https://listing-external-sit.hepsiburada.com/listings/merchantid/" + merchantId);

            String svcCredentials = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(username + ":" + password));

            var request = new RestRequest(Method.GET);
            request.AddHeader("merchantid", merchantId);
            request.AddHeader("content-type", "application/xml");
            request.AddHeader("Authorization", "Basic " + svcCredentials);
            Console.WriteLine(request.ToString());
            IRestResponse response = client.Execute(request) as RestResponse;

            return response;
        }

        public void UrunListeGetir()
        {

            IRestResponse urunListe = this.UrunListesiGetir(this.userName, this.password, this.merchantId);

            if (urunListe.StatusCode == HttpStatusCode.OK)
            {
                //MessageBox.Show(urunListe.Content);
                Console.WriteLine(urunListe.Content);
                listBox2.Items.Add(urunListe.Content);
                //dataGridView1.DataSource = urunListe.Content;
                //this.StringXMLToDatatable(urunListe.Content);

                string path = @"C:\Users\Lenovo\Desktop\text.xml";

                StreamWriter file = new StreamWriter(path);
                file.Write(urunListe.Content);
                file.Close();
                string files = path;
                DataSet ds = new DataSet();
                ds.ReadXml(files);
                metroGrid1.DataSource = ds.Tables["Listing"].DefaultView;
            }
            else
            {
                listBox2.Items.Add(urunListe.StatusCode.ToString());
            }
        }


        private String strXml = @"
        <listings>
          <listing>
            <UniqueIdentifier></UniqueIdentifier>
            <HepsiburadaSku>HBV000004WVJQ</HepsiburadaSku>
            <MerchantSku>HBV000004WVJQ</MerchantSku>
            <ProductName>iPhone 8 Ekran ve DOkunmatik</ProductName>
            <Price>1045</Price>
            <AvailableStock>100</AvailableStock>
            <DispatchTime>1</DispatchTime>
            <CargoCompany1>Yurtiçi Kargo</CargoCompany1>
            <CargoCompany2>Aras Kargo</CargoCompany2>
            <CargoCompany3>Horoz Lojistik</CargoCompany3>
            <MaximumPurchasableQuantity>4</MaximumPurchasableQuantity>
          </listing>
          <listing>
            <UniqueIdentifier></UniqueIdentifier>
            <HepsiburadaSku>OTYAGMBL0031</HepsiburadaSku>
            <MerchantSku>XX-31</MerchantSku>
            <ProductName>iPhone 8 Ekran ve DOkunmatik</ProductName>
            <Price>254</Price>
            <AvailableStock>100</AvailableStock>
            <DispatchTime>1</DispatchTime>
            <CargoCompany1>Yurtiçi Kargo</CargoCompany1>
            <CargoCompany2>Aras Kargo</CargoCompany2>
            <CargoCompany3>Horoz Lojistik</CargoCompany3>
            <MaximumPurchasableQuantity>4</MaximumPurchasableQuantity>
          </listing>
          <listing>
            <UniqueIdentifier></UniqueIdentifier>
            <HepsiburadaSku>OTYAGMBL0021</HepsiburadaSku>
            <MerchantSku>XX-21</MerchantSku>
            <ProductName>iPhone 8 Ekran ve DOkunmatik</ProductName>
            <Price>254</Price>
            <AvailableStock>100</AvailableStock>
            <DispatchTime>1</DispatchTime>
            <CargoCompany1>Yurtiçi Kargo</CargoCompany1>
            <CargoCompany2>Aras Kargo</CargoCompany2>
            <CargoCompany3>Horoz Lojistik</CargoCompany3>
            <MaximumPurchasableQuantity>4</MaximumPurchasableQuantity>
          </listing>
          <listing>
            <UniqueIdentifier></UniqueIdentifier>
            <HepsiburadaSku>OTYAGMBL0011</HepsiburadaSku>
            <MerchantSku>XX-11</MerchantSku>
            <ProductName>iPhone 8 Ekran ve DOkunmatik</ProductName>
            <Price>254</Price>
            <AvailableStock>100</AvailableStock>
            <DispatchTime>1</DispatchTime>
            <CargoCompany1>Yurtiçi Kargo</CargoCompany1>
            <CargoCompany2>Aras Kargo</CargoCompany2>
            <CargoCompany3>Horoz Lojistik</CargoCompany3>
            <MaximumPurchasableQuantity>4</MaximumPurchasableQuantity>
          </listing>
        </listings>
        ";

        //DataGrid deki datayı excell e aktarır
        private void xlsxExport_Click(object sender, EventArgs e)
        {
            exp.ExcellExport(metroGrid1);
        }

        //DataGrid e excell import eder
        private void button1_Click(object sender, EventArgs e)
        {
            //exp.ImportExcell(metroGrid1);
            filePathExp = exp.GetFilePath();
            listBox1.Items.Clear();
            foreach (var item in exp.GetExcelSheetNames(filePathExp))
            {
                listBox1.Items.Add(item);
            }
            
        }

        private void GetSheetName()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();  //create openfileDialog Object
            openFileDialog1.Filter = "XML Files (*.xml; *.xls; *.xlsx; *.xlsm; *.xlsb) |*.xml; *.xls; *.xlsx; *.xlsm; *.xlsb";//open file format define Excel Files(.xls)|*.xls| Excel Files(.xlsx)|*.xlsx| 
            openFileDialog1.FilterIndex = 3;

            openFileDialog1.Multiselect = false;        //not allow multiline selection at the file selection level
            openFileDialog1.Title = "Open Text File-R13";   //define the name of openfileDialog
            openFileDialog1.InitialDirectory = @"Desktop"; //define the initial directory

            if (openFileDialog1.ShowDialog() == DialogResult.OK)        //executing when file open
            {
                string pathName = openFileDialog1.FileName;
                string fileName = System.IO.Path.GetFileNameWithoutExtension(openFileDialog1.FileName);
                DataTable tbContainer = new DataTable();
                string strConn = string.Empty;
                string sheetName = "Sayfa1";

                FileInfo file = new FileInfo(pathName);
                listBox2.Items.Add(file + " - " + pathName);
                //foreach (var item in GetExcelSheetNames(pathName))
                //{
                //    MessageBox.Show(item);
                //}


            }
        }
        

        class Listing
        {
            public String UniqueIdentifier { get; set; }
            public String HepsiburadaSku { get; set; }
            public String MerchantSku { get; set; }
            public String ProductName { get; set; }
            public Double Price { get; set; }
            public int AvailableStock { get; set; }
            public int DispatchTime { get; set; }
            public String CargoCompany1 { get; set; }
            public int MaximumPurchasableQuantity { get; set; }
            public bool IsSalable { get; set; }

        }

        //HB DB sindeki ürünleri çekerek uygun olanları XML liste yaparak hb ye yükler
        private void button2_Click(object sender, EventArgs e)
        {
            //exportXml();
            
            createXMLandListing();
        }

        private void createXMLandListing()
        {
            if (textBox1.Text.ToString() != "")
            {
                mysql.FillDatatable("SELECT * FROM hb_products WHERE merchant_sku != '' AND hb_sku != '' AND akilli_barcode='" + textBox1.Text.ToString() + "'", metroGrid1);
                Console.WriteLine("1");
            }
            else
            {
                if (limitCheck.Checked)
                {
                    mysql.FillDatatable("SELECT * FROM hb_products WHERE merchant_sku != '' AND hb_sku != '' LIMIT " + firstNum.Value.ToString() + "," + lastNum.Value.ToString(), metroGrid1);
                    Console.WriteLine("2");

                }
                else
                {
                    mysql.FillDatatable("SELECT * FROM hb_products WHERE merchant_sku != '' AND hb_sku != '' ", metroGrid1);
                    Console.WriteLine("3");

                }
            }
            Thread.Sleep(1000);
            int count = 0;
            int stok = 0;
            progressBar1.Value = 0;
            var dt = new DataTable("listing");
            dt.Columns.Add("UniqueIdentifier");
            dt.Columns.Add("HepsiburadaSku");
            dt.Columns.Add("MerchantSku");
            dt.Columns.Add("ProductName");
            dt.Columns.Add("Price");
            dt.Columns.Add("AvailableStock");
            dt.Columns.Add("DispatchTime");
            dt.Columns.Add("CargoCompany1");
            dt.Columns.Add("MaximumPurchasableQuantity");

            var ds = new DataSet("listings");
            ds.Tables.Add(dt);
            string fileName = "";
            var settings = new XmlWriterSettings { Indent = true };

            progressBar1.Maximum = metroGrid1.Rows.Count;
            foreach (DataGridViewRow row in metroGrid1.Rows)
            {
                progressBar1.Value++;
                Console.WriteLine(progressBar1.Value);
                try
                {
                    if (Convert.ToInt32(row.Cells[4].Value) <= minStockNum.Value || Convert.ToInt32(row.Cells[4].Value) < 0 || stockZero.Checked)
                    {
                        stok = 0;
                    }
                    else
                    {
                        stok = Convert.ToInt32(row.Cells[4].Value);
                        count++;
                    }

                    dt.Rows.Add("", row.Cells[6].Value.ToString(), row.Cells[5].Value.ToString(), row.Cells[3].Value.ToString(), Convert.ToDouble(row.Cells[8].Value) * Convert.ToDouble(1 + (hbComission.Value / 100)) * Convert.ToDouble(exRateNum.Value) * (1.18), Convert.ToInt32(stok), dispatchTime.Value, cargoCompany.Text.ToString(), maxPurchese.Value);
                    items.Add(new Listing
                    {
                        HepsiburadaSku = row.Cells[6].Value.ToString(),
                        MerchantSku = row.Cells[5].Value.ToString(),
                        ProductName = row.Cells[3].Value.ToString(),
                        Price = Convert.ToDouble(row.Cells[8].Value) * Convert.ToDouble(1 + (hbComission.Value / 100)) * Convert.ToDouble(exRateNum.Value) * (1.18),
                        AvailableStock = Convert.ToInt32(stok), //row.Cells[4].Value),
                        DispatchTime = Convert.ToInt32(dispatchTime.Value),
                        CargoCompany1 = cargoCompany.Text.ToString(),
                        MaximumPurchasableQuantity = Convert.ToInt32(maxPurchese.Value)
                    });
                }
                catch (Exception ex)
                {
                    listBox1.Items.Add(ex.Message);
                }
            }


            if (xmlCheck.Checked)
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "XML Dosyası|*.xml";
                save.OverwritePrompt = true;
                save.CreatePrompt = false;

                if (save.ShowDialog() == DialogResult.OK)
                {
                    fileName = save.FileName;
                }
                try
                {
                    var writer = XmlWriter.Create(fileName, settings);

                    ds.WriteXml(writer);
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                    listBox2.Items.Add(ex.Message);
                }
            }

            listBox2.Items.Add(count + " Ürün Listeye Eklendi");
            Console.WriteLine(ds.GetXml());
            //MessageBox.Show(ds.GetXml());
            hb.UrunGuncelle(ds.GetXml());
        }

        private void exportXml()
        {
            progressBar1.Value = 0;
            var dt = new DataTable("listing");
            dt.Columns.Add("UniqueIdentifier");
            dt.Columns.Add("HepsiburadaSku");
            dt.Columns.Add("MerchantSku");
            dt.Columns.Add("ProductName");
            dt.Columns.Add("Price");
            dt.Columns.Add("AvailableStock");
            dt.Columns.Add("DispatchTime");
            dt.Columns.Add("CargoCompany1");
            dt.Columns.Add("MaximumPurchasableQuantity");
            dt.Columns.Add("IsSalable");

            //dt.Rows.Add("", "HBV000004WVJQ", "HBV000004WVJQ", "iPhone 10 Ekran ve Dokunmatik", 250, 80, 1, "Yurtiçi Kargo", 3);
            //dt.Rows.Add("", "HBV000004WVJQ", "HBV000004WVJQ", "iPhone 11 Ekran ve Dokunmatik", 125, 10, 1, "Yurtiçi Kargo", 3);
            //dt.Rows.Add("", "HBV000004WVJQ", "HBV000004WVJQ", "iPhone 12 Ekran ve Dokunmatik", 1570, 200, 1, "Yurtiçi Kargo", 3);
            //dt.Rows.Add("", "HBV000004WVJQ", "HBV000004WVJQ", "iPhone 13 Ekran ve Dokunmatik", 1650, 199, 1, "Yurtiçi Kargo", 3);

            var ds = new DataSet("listings");
            ds.Tables.Add(dt);
            string fileName = "";
            var settings = new XmlWriterSettings { Indent = true };
   
                progressBar1.Maximum = metroGrid1.Rows.Count;
                foreach (DataGridViewRow row in metroGrid1.Rows)
                {
                    progressBar1.Value++;
                    Console.WriteLine(progressBar1.Value);
                    try
                    {
                        dt.Rows.Add("", row.Cells[5].Value.ToString(), row.Cells[2].Value.ToString() + "-" + row.Cells[4].Value.ToString(), row.Cells[7].Value.ToString(), Convert.ToDouble(row.Cells[9].Value) * Convert.ToDouble(1 + (hbComission.Value / 100)) * Convert.ToDouble(exRateNum.Value), Convert.ToInt32(row.Cells[3].Value), dispatchTime.Value, cargoCompany.Text.ToString(), maxPurchese.Value);
                        items.Add(new Listing
                        {
                            HepsiburadaSku = row.Cells[5].Value.ToString(),
                            MerchantSku = row.Cells[2].Value.ToString() + "-" + row.Cells[4].Value.ToString(),
                            ProductName = row.Cells[7].Value.ToString(),
                            Price = Convert.ToDouble(row.Cells[9].Value) * Convert.ToDouble(1 + (hbComission.Value / 100)) * Convert.ToDouble(exRateNum.Value),
                            AvailableStock = Convert.ToInt32(row.Cells[3].Value),
                            DispatchTime = Convert.ToInt32(dispatchTime.Value),
                            CargoCompany1 = cargoCompany.Text.ToString(),
                            MaximumPurchasableQuantity = Convert.ToInt32(maxPurchese.Value)
                        });

                        listBox2.Items.Add("HB SKU: " + row.Cells[5].Value.ToString());
                        listBox2.Items.Add("MC SKU 1: " + row.Cells[2].Value.ToString());
                        listBox2.Items.Add("MC SKU 2: " + row.Cells[4].Value.ToString());
                        listBox2.Items.Add("PR Name: " + row.Cells[7].Value.ToString());
                        listBox2.Items.Add("Price: " + row.Cells[9].Value.ToString());
                        listBox2.Items.Add("AVB Stock: " + row.Cells[3].Value.ToString());


                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            listBox2.Items.Add(row.Cells[i].Value.ToString());
                            //MessageBox.Show(row.HeaderCell.Value.ToString() + " - " + row.Cells[i].Value.ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        listBox1.Items.Add(ex.Message);
                    }
                }

                if (xmlCheck.Checked)
                {
                    SaveFileDialog save = new SaveFileDialog();
                    save.Filter = "XML Dosyası|*.xml";
                    save.OverwritePrompt = true;
                    save.CreatePrompt = false;

                    if (save.ShowDialog() == DialogResult.OK)
                    {
                        //MessageBox.Show(save.FileName.ToString());
                        fileName = save.FileName;
                    }
                    var writer = XmlWriter.Create(fileName, settings);

                    ds.WriteXml(writer);
                }
                Console.WriteLine(ds.GetXml());
                //MessageBox.Show(ds.GetXml());
                hb.UrunGuncelle(ds.GetXml());

            string cml = @"
            <listings>
              <listing>
                <UniqueIdentifier></UniqueIdentifier>
                <HepsiburadaSku>HBV000004WVJQ</HepsiburadaSku>
                <MerchantSku>HBV000004WVJQ</MerchantSku>
                <ProductName>iPhone 9 Ekran ve DOkunmatik</ProductName>
                <Price>1045</Price>
                <AvailableStock>100</AvailableStock>
                <DispatchTime>1</DispatchTime>
                <CargoCompany1>Yurtiçi Kargo</CargoCompany1>
                <CargoCompany2>Aras Kargo</CargoCompany2>
                <CargoCompany3>Horoz Lojistik</CargoCompany3>
                <MaximumPurchasableQuantity>4</MaximumPurchasableQuantity>
              </listing>
            </listings>";
        }

        //DataGrid e seçilen XML dosyayı yükler
        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "XML Dosyası|*.xml";

            if (open.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DataSet dataSet = new DataSet();
                    dataSet.ReadXml(open.FileName);
                    metroGrid1.DataSource = dataSet.Tables[0];
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                    listBox2.Items.Add(ex.Message);
                }
            }           
        }

        private void HBSection_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            label12.Text = Properties.Settings.Default.LastUpdate.ToString();
            apiKeyBox.Text = Properties.Settings.Default.APiKey.ToString();
            apiPassBox.Text = Properties.Settings.Default.APiPass.ToString();
            apiUserBox.Text = Properties.Settings.Default.APiUser.ToString();
            apiUrlBox.Text = Properties.Settings.Default.APiUrl.ToString();
            cargoCompany.Text = Properties.Settings.Default.CargoCompany.ToString();
            maxPurchese.Value = Properties.Settings.Default.MaxPurchase;
            exRateNum.Value = Properties.Settings.Default.ExRate;
            hbComission.Value = Properties.Settings.Default.HBComision;
            minStockNum.Value = Properties.Settings.Default.MinStock;

        }

        private void metroTabPage3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void metroGrid6_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            int rowIndex = e.RowIndex;
            DataGridViewRow row = metroGrid6.Rows[rowIndex];
            //MessageBox.Show(metroGrid6.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());// row.Cells[1].Value;
            //MessageBox.Show(row.Cells[5].Value.ToString());
            listBox2.Items.Add(row.Cells[5].Value.ToString());
            mysql.FillDatatable("SELECT * FROM product WHERE idProductCategory=179 LIMIT 1", metroGrid6);

            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    mysql.FillDatatable("SELECT * FROM category LIMIT 100", metroGrid6);
            //    //mysql.FetchDataToList("SELECT * FROM category LIMIT 10");
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //    throw;
            //}

            //exp.ImportExcell(metroGrid1);
            filePathExp = exp.GetFilePath();
            listBox1.Items.Clear();
            foreach (var item in exp.GetExcelSheetNames(filePathExp))
            {
                listBox3.Items.Add(item);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(hb.UrunListeGetir());
            mysql.FillDatatable("SELECT product.id,product.productCode,product.productName,product.salePrice,product.marketPrice,product_amount.idx,product_amount.idProduct,product_amount.amount,product_amount.barcode,product_amount.state FROM product LEFT JOIN product_amount ON product.id = product_amount.idProduct LIMIT " + lastNum.Value, metroGrid1);
            listBox2.Items.Add("Ürünler Database'den getirildi.");
            
        }

        //Yeni Ürünleri HB DB sine ekler
        private void button6_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            mysql.FillDatatable("SELECT pa.idProduct,pa.amount,pa.barcode,p.productName,p.salePrice FROM product_amount AS pa INNER JOIN product AS p WHERE pa.idProduct = p.id AND pa.barcode != ''", metroGrid1);
            listBox2.Items.Add(metroGrid1.Rows.Count.ToString());
            progressBar1.Maximum = metroGrid1.Rows.Count;
            foreach (DataGridViewRow row in metroGrid1.Rows)
            {

                try
                {
                    //dt.Rows.Add(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString(), row.Cells[2].Value.ToString(), row.Cells[3].Value.ToString(), row.Cells[4].Value.ToString(), row.Cells[5].Value.ToString(), row.Cells[6].Value.ToString(), row.Cells[7].Value.ToString(), row.Cells[8].Value.ToString(), row.Cells[9].Value.ToString());
                    //items.Add(new Listing { UniqueIdentifier = row.Cells[0].Value.ToString(), HepsiburadaSku = row.Cells[1].Value.ToString(), MerchantSku = row.Cells[2].Value.ToString(), ProductName = row.Cells[3].Value.ToString(), Price = Convert.ToDouble(row.Cells[4].Value), 
                    //row.Cells[5].Value), DispatchTime = Convert.ToInt32(row.Cells[6].Value), CargoCompany1 = row.Cells[7].Value.ToString(), MaximumPurchasableQuantity = Convert.ToInt32(row.Cells[8].Value), IsSalable = Convert.ToBoolean(row.Cells[9].Value) });

                    //for (int i = 0; i < metroGrid1.RowCount; i++)
                    //{
                    //MessageBox.Show(row.Cells[0].Value.ToString() + " - " + row.Cells[1].Value.ToString() + " - " + row.Cells[2].Value.ToString() + " - " + row.Cells[8].Value.ToString() + " - " + Convert.ToInt32(row.Cells[7].Value));
                    String query = "INSERT INTO hb_products(akilli_id, akilli_barcode, akilli_name,stock,price) VALUES('" + row.Cells[0].Value.ToString() + "','" + row.Cells[2].Value.ToString() + "','" + row.Cells[3].Value.ToString() + "','" + Convert.ToInt32(row.Cells[1].Value) + "','" + Convert.ToDecimal(row.Cells[4].Value) + "')";
                    progressBar1.Value++; // Convert.ToDouble(100 / metroGrid1.Rows.Count);
                    Thread.Sleep(10);
                    //MessageBox.Show(row.Cells[4].Value.ToString());
                    mysql.InsertData(query);
                    //}
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                    listBox2.Items.Add(ex.Message);
                }
            }
            MessageBox.Show("Datalar Güncellendi");
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            mysql.FillDatatable(metroTextBox1.Text.ToString(), metroGrid2);
        }

        //HB DB sindeki tüm ürünleri getirir
        private void button7_Click(object sender, EventArgs e)
        {
            mysql.FillDatatable("SELECT * FROM hb_products", metroGrid1);

        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            //MessageBox.Show(listBox1.SelectedItem.ToString());
            exp.ImportExcellFile(metroGrid1, listBox1.SelectedItem.ToString(), filePathExp);
        }

        //Eklenen excell deki HBSKU ve MerchantSKU alanlarını doldurur
        private void button8_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            progressBar1.Maximum = metroGrid1.Rows.Count;
            int sayi = 0;

            foreach (DataGridViewRow row in metroGrid1.Rows)
            {
                try
                {
                    //if (sayi>100)
                    //{
                    //    mysql.baglan.Close();
                    //    mysql.baglan.Open();
                    //    MessageBox.Show("Connection Reset");
                    //}
                    //dt.Rows.Add(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString(), row.Cells[2].Value.ToString(), row.Cells[3].Value.ToString(), row.Cells[4].Value.ToString(), row.Cells[5].Value.ToString(), row.Cells[6].Value.ToString(), row.Cells[7].Value.ToString(), row.Cells[8].Value.ToString(), row.Cells[9].Value.ToString());
                    //items.Add(new Listing { UniqueIdentifier = row.Cells[0].Value.ToString(), HepsiburadaSku = row.Cells[1].Value.ToString(), MerchantSku = row.Cells[2].Value.ToString(), ProductName = row.Cells[3].Value.ToString(), Price = Convert.ToDouble(row.Cells[4].Value), 
                    //row.Cells[5].Value), DispatchTime = Convert.ToInt32(row.Cells[6].Value), CargoCompany1 = row.Cells[7].Value.ToString(), MaximumPurchasableQuantity = Convert.ToInt32(row.Cells[8].Value), IsSalable = Convert.ToBoolean(row.Cells[9].Value) });

                    //for (int i = 0; i < metroGrid1.RowCount; i++)
                    //{
                        String merchantSku = row.Cells[8].Value.ToString();
                        String HBSku = row.Cells[7].Value.ToString();
                        String prBarcode = row.Cells[2].Value.ToString().Split('-')[1];
                        mysql.UpdateData("UPDATE hb_products SET merchant_sku='" + merchantSku + "', hb_sku='" + HBSku + "' WHERE akilli_barcode='" + prBarcode +"'");
                        Console.WriteLine(merchantSku);
                        Console.WriteLine(HBSku);
                        Console.WriteLine(prBarcode);
                        progressBar1.Value++; //= progressBar1.Value + Convert.ToInt32(100 / metroGrid1.Rows.Count);
                        sayi += mysql.count;
                        Thread.Sleep(10);

                        //MessageBox.Show("UPDATE hp_products SET hb_id=" + merchantSku + ", hb_sku=" + HBSku + " WHERE akilli_barcode =" + prBarcode);
                        //MessageBox.Show(row.Cells[2].Value.ToString() + " - " + row.Cells[3].Value.ToString() + " - " + row.Cells[4].Value.ToString() + " - " + row.Cells[8].Value.ToString());
                        //mysql.InsertData("INSERT INTO hb_products(akilli_id, akilli_prcode, akilli_barcode, akilli_name) VALUES('" + row.Cells[0].Value.ToString() + "','" + row.Cells[1].Value.ToString() + "','" + row.Cells[8].Value.ToString() + "','" + row.Cells[2].Value.ToString() + "')");

                    //}
                }
                catch (Exception ex)
                {
                    listBox2.Items.Add(ex.Message);
                }
            }
            listBox2.Items.Add(sayi + " Alan Güncellendi.");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //mysql.FillDatatable("SELECT * FROM AMOUNT WHERE barcode > 0", metroGrid1);
            mysql.FillDatatable("SELECT * FROM AMOUNT WHERE hepsiCode != '' LIMIT " + lastNum.Value, metroGrid1);
            listBox2.Items.Add(metroGrid1.Rows.Count.ToString());
        }

        //HB DB sindeki ürünleri aralığa göre getirir
        private void button10_Click(object sender, EventArgs e)
        {
            hbGetir(Convert.ToInt32(firstNum.Value), Convert.ToInt32(lastNum.Value));
        }

        private void hbGetir(int first, int per)
        {
            foreach (DataGridViewRow row in metroGrid1.Rows)
            {
                //MessageBox.Show(row.Cells[0].Value.ToString());
            }
            //mysql.FillDatatable("SELECT product_amount.productCode,product_amount.idx,product_amount.idProduct,product_amount.amount,product_amount.barcode,product_amount.hepsiCode,product_amount.hepsiMerkant,product.productName,product.id,product.salePrice FROM product_amount RIGHT JOIN product ON product_amount.productCode = product.productCode WHERE product_amount.barcode != '' LIMIT " + first + "," + per, metroGrid1);
            mysql.FillDatatable("SELECT pa.idProduct,pa.amount,pa.barcode,p.productName,p.salePrice FROM product_amount AS pa INNER JOIN product AS p WHERE pa.idProduct = p.id AND pa.barcode != '' LIMIT " + firstNum.Value.ToString() + "," + lastNum.Value.ToString(), metroGrid1);
            listBox2.Items.Add(metroGrid1.Rows.Count.ToString());
        }

        private void getExRate_Click(object sender, EventArgs e)
        {
            dolarGetir();
        }

        private void dolarGetir()
        {
            double Dolar = 0.0;
            DataSet dsDovizKur;

            dsDovizKur = new DataSet();
            dsDovizKur.ReadXml(@"http://www.tcmb.gov.tr/kurlar/today.xml");

            DataRow dr = dsDovizKur.Tables[1].Rows[0];
            Dolar = Convert.ToDouble(dr[4].ToString().Replace('.', ','));

            Properties.Settings.Default.ExRate = Convert.ToInt32(exRateNum.Value);
            Properties.Settings.Default.Save();

            exRateNum.Value = Convert.ToDecimal(Dolar);
        }

        private void settingSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.APiKey = apiKeyBox.Text.ToString();
            Properties.Settings.Default.APiUser = apiUserBox.Text.ToString();
            Properties.Settings.Default.APiPass = apiPassBox.Text.ToString();
            Properties.Settings.Default.APiUrl = apiUrlBox.Text.ToString();
            Properties.Settings.Default.HBComision = Convert.ToInt32(hbComission.Value);
            Properties.Settings.Default.ExRate = Convert.ToDecimal(exRateNum.Value);
            Properties.Settings.Default.CargoCompany = cargoCompany.Text.ToString();
            Properties.Settings.Default.MaxPurchase = Convert.ToInt32(maxPurchese.Value);
            Properties.Settings.Default.MinStock = Convert.ToInt32(minStockNum.Value);
            Properties.Settings.Default.Save();
        }


        public void updateStock()
        {
            //mysql.FillDatatable("SELECT pa.amount AS Product_Stock,hb.stock AS HB_Stock,pa.barcode AS Product_Barcode,hb.akilli_barcode AS HB_Barcode FROM product_amount AS pa INNER JOIN hb_products AS hb WHERE hb.akilli_barcode = pa.barcode AND hb.hb_sku != '' AND hb.stock != pa.amount", metroGrid1);
            //Thread.Sleep(100);
            //progressBar1.Value = 0;
            //progressBar1.Maximum = metroGrid1.Rows.Count;
            //foreach (DataGridViewRow row in metroGrid1.Rows)
            //{
            //    Console.WriteLine("emrhaba");
            //    try
            //    {

            //        //String query = "INSERT INTO hb_products(akilli_id, akilli_barcode, akilli_name,stock,price) VALUES('" + row.Cells[0].Value.ToString() + "','" + row.Cells[2].Value.ToString() + "','" + row.Cells[3].Value.ToString() + "','" + Convert.ToInt32(row.Cells[1].Value) + "','" + Convert.ToDecimal(row.Cells[4].Value) + "')";
            //        String query = "UPDATE hb_products SET stock=" + Convert.ToDouble(row.Cells[1].Value.ToString()) + ", price=" + Convert.ToDouble(row.Cells[4].Value) + " WHERE akilli_barcode='" + row.Cells[2].Value.ToString() + "'";
            //        Console.WriteLine(query);
            //        progressBar1.Value++; // Convert.ToDouble(100 / metroGrid1.Rows.Count);
            //        Thread.Sleep(10);
            //        mysql.UpdateData(query);
            //    }
            //    catch (Exception ex)
            //    {
            //        //MessageBox.Show(ex.Message);
            //        listBox2.Items.Add(ex.Message);
            //    }


            //}

            progressBar1.Value = 0;
            mysql.FillDatatable("SELECT pa.idProduct,pa.amount,pa.barcode,p.productName,p.salePrice FROM product_amount AS pa INNER JOIN product AS p ON pa.idProduct = p.id INNER JOIN hb_products AS hb ON hb.akilli_barcode = pa.barcode WHERE pa.barcode != '' AND hb.hb_sku != ''", metroGrid1);
            Thread.Sleep(10000);
            listBox2.Items.Add(metroGrid1.Rows.Count.ToString());
            progressBar1.Maximum = metroGrid1.Rows.Count;
            Console.WriteLine(metroGrid1.Rows.Count);
            foreach (DataGridViewRow row in metroGrid1.Rows)
            {

                try
                {
                    //String query = "INSERT INTO hb_products(akilli_id, akilli_barcode, akilli_name,stock,price) VALUES('" + row.Cells[0].Value.ToString() + "','" + row.Cells[2].Value.ToString() + "','" + row.Cells[3].Value.ToString() + "','" + Convert.ToInt32(row.Cells[1].Value) + "','" + Convert.ToDecimal(row.Cells[4].Value) + "')";
                    String query = "UPDATE hb_products SET stock=" + Convert.ToDouble(row.Cells[1].Value.ToString()) + ", price='" + row.Cells[4].Value.ToString() + "' WHERE akilli_barcode='" + row.Cells[2].Value.ToString() + "'";
                    Console.WriteLine(query);
                    progressBar1.Value++; // Convert.ToDouble(100 / metroGrid1.Rows.Count);
                    Thread.Sleep(10);
                    mysql.UpdateData(query);
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                    listBox2.Items.Add("2" + ex.Message);
                }
            }
            listBox2.Items.Add("Datalar Güncellendi");


        }

        private static void MyFunction()
        {
            //Task task = Task.Run((Action)MyFunction);

        }

        private void elementsTurnStatus(bool status)
        {
            sureNum.Enabled = status;
            xmlCheck.Enabled = status;
            stockZero.Enabled = status;

            button1.Enabled = status;
            button2.Enabled = status;
            button3.Enabled = status;
            button6.Enabled = status;
            button7.Enabled = status;
            button8.Enabled = status;
            button9.Enabled = status;
            button10.Enabled = status;
            firstNum.Enabled = status;
            lastNum.Enabled = status;
            xlsxExport.Enabled = status;
        }

        //Task updateTask = new Task(updateStock);

        //Oto günlleme başlatır
        private void autoUpdate_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.LastUpdate = DateTime.UtcNow.ToLocalTime();
            label12.Text = Properties.Settings.Default.LastUpdate.ToString();
            this.WindowState = FormWindowState.Minimized;

            elementsTurnStatus(false);
            xmlCheck.Checked = false;
            stockZero.Checked = false;
            timer1.Start();
            timer1.Interval = Convert.ToInt32(sureNum.Value) * 3600000;
            stopUpdate.Enabled = true;
            autoUpdate.Enabled = false;
            
            updateStock();
            createXMLandListing();

            //to minimize window

            //to hide from taskbar
            //this.Hide();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Properties.Settings.Default.LastUpdate = DateTime.UtcNow.ToLocalTime();
            label12.Text = Properties.Settings.Default.LastUpdate.ToString();
            updateStock();

            createXMLandListing();
        }

        //Oto güncelleme durdurur
        private void stopUpdate_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(updateTask.Status.ToString());
            timer1.Stop();
            stopUpdate.Enabled = false;
            autoUpdate.Enabled = true;

            elementsTurnStatus(true);
            //MessageBox.Show(updateTask.Status.ToString());

        }

        private void button11_Click(object sender, EventArgs e)
        {
            DownloadData(); //DownloadData metodunu çağırıyoruz…
        }

        private async void button12_Click(object sender, EventArgs e)
        {
            string getdata = await DownloadDataAsync(); //await keyword’üne dikkat!
            listBox2.Items.Add(getdata);
        }

        private void DownloadData()
        {
            WebClient wc = new WebClient(); //WebClient Sınıfından yeni bir WebClient nesnesi türetiliyor…
            string data = wc.DownloadString("https://ferhatkortak.wordpress.com/2014/06/11/c-asenkron-programlamaasync-ve-await-anahtar-kelimeleri/");
            listBox2.Items.Add(data);
        }

        async Task<string> DownloadDataAsync() //DownloadDataAsync Task’inin asenkron olduğunu async keyword’ü ile belirtiyoruz. Asenkron kullanmak istediğimiz için Task oluşturduk.
        {
            WebClient wc = new WebClient(); //WebClient Sınıfından yeni bir WebClient nesnesi türetiliyor…
            string data = await wc.DownloadStringTaskAsync("https://ferhatkortak.wordpress.com/2014/06/11/c-asenkron-programlamaasync-ve-await-anahtar-kelimeleri/");
            //Ürettiğimiz wc isimli nesnenin DownloadString metoduyla w3schools kaynağındaki html kodlarını çekip değişkene aktarıyoruz
            return data; //Veri kaynağından çektiği verileri tekrar döndürüyor. Böylece bu metodu çağıran yere bu bilgi ulaşmış oluyor.
        }

        private void button13_Click(object sender, EventArgs e)
        {

            listBox2.Items.Add(cargoCombo.SelectedIndex.ToString());
            
            comboSet(uniqueIdentifier, "Unique ID");
            comboSet(hbSkuCombo, "HB SKU");
            comboSet(merchantSkuCombo, "Merchant SKU");
            comboSet(prNameCombo, "Ürün Adı");
            comboSet(priceCombo, "Fiyat");
            comboSet(stockCombo, "Stok");
            comboSet(dispatchTimeCombo, "Kargo Süresi");
            comboSet(cargoCombo, "Kargo");
        }

        private void comboSet(ComboBox combo ,string firstItem)
        {
            combo.Items.Clear();
            combo.Items.Add(firstItem);

            for (int i = 0; i < metroGrid1.Columns.Count; i++)
            {
                combo.Items.Add(metroGrid1.Columns[i].HeaderText);
            }
        }

        private void uniqueIdentifier_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void metroButton2_Click(object sender, EventArgs e)
        {

        }

        private void listBox3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            exp.ImportExcellFile(metroGrid6, listBox3.SelectedItem.ToString(), filePathExp);
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            WriteExcelFile();
        }

        private string GetConnectionString()
        {
            Dictionary<string, string> props = new Dictionary<string, string>();
            //XLSX Excel File
            props["Provider"] = "Microsoft.ACE.OLEDB.12.0;";
            props["Extended Properties"] = "Excel 12.0 XML";
            props["Data Source"] = filePathExp;

            //XLS Excel File
            //props["Provider"] = "Microsoft.JET.OLEDB.4.0;";
            //props["Extended Properties"] = "Excel 8.0";
            //props["Data Source"] = filePathExp;

            StringBuilder sb = new StringBuilder();

            foreach (KeyValuePair<string, string> prop in props)
            {
                sb.Append(prop.Key);
                sb.Append('=');
                sb.Append(prop.Value);
                sb.Append(';');
            }
            return sb.ToString();
        }

        private void WriteExcelFile()
        {
            string connectionString = GetConnectionString();

            using (var con = new OleDbConnection(connectionString))
            {
                con.Open();
                using (var cmd = new OleDbCommand("select * from [" + listBox3.SelectedItem.ToString() + "]", con))
                using (var reader = cmd.ExecuteReader(CommandBehavior.SchemaOnly))
                {
                    var table = reader.GetSchemaTable();
                    var nameCol = table.Columns["ColumnName"];
                    foreach (DataRow row in table.Rows)
                    {
                        Console.WriteLine(row[nameCol]);
                    }
                }
            }

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = conn;

                    //cmd.CommandText = "CREATE TABLE [table1] (id INT, name VARCHAR, datecol DATE );";
                    //cmd.ExecuteNonQuery();
                    try
                    {
                        foreach (DataGridViewRow row in metroGrid6.Rows)
                        {
                            string query = "INSERT INTO [" + listBox3.SelectedItem.ToString() + "](Temel, NoName, NoName1, NoName3, NoName4, NoName5, NoName6, NoName7, NoName8, NoName9) VALUES('" + row.Cells[0].Value.ToString() + "', '" + row.Cells[1].Value.ToString() + "-" + row.Cells[2].Value.ToString() + "', '" + row.Cells[2].Value.ToString() + "', '" + row.Cells[2].Value.ToString() + "', '" + brandTxt.Text.ToString() + "', '" + desiTxt.Text.ToString() + "', '" + taxNum.Value.ToString() + "', '" + warantyTxt.Text.ToString() + "', '" + row.Cells[5].Value.ToString() + "', '" + row.Cells[4].Value.ToString() + "');";
                            Console.WriteLine(query);
                            cmd.CommandText = query;
                            cmd.ExecuteNonQuery();
                        }
                    }
                    catch (Exception ex)
                    {
                        listBox2.Items.Add(ex.Message);
                    }


                    conn.Close();
                }
                catch (Exception ex)
                {
                    listBox2.Items.Add(ex.Message);
                }
            }
        }

        class ExcellList
        {
            public string ProductName { get; set; }
            public string MerchantSku { get; set; }
            public string Barcode { get; set; }
            public int VariantGrId { get; set; }
            public string ProductDescriptiom { get; set; }
            public string BrandName { get; set; }
            public int Desi { get; set; }
            public int Vax { get; set; }
            public int Waranty { get; set; }
            public string Img1 { get; set; }
            public string Img2 { get; set; }
            public string Img3 { get; set; }
            public string Img4 { get; set; }
            public string Img5 { get; set; }
            public string Color { get; set; }
            public string CompModel { get; set; }
            public int MyProperty { get; set; }
            //Product Specs

        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            mysql.FillDatatable("SELECT p.productName, p.productCode, pa.barcode, p.productDescription, pp.picture, pa.amountImage, p.id " +
                "FROM product AS p " +
                "INNER JOIN product_amount AS pa " +
                "ON p.id = pa.idProduct " +
                "INNER JOIN product_pictures AS pp " +
                "ON pa.idProduct = pp.idProduct " +
                "WHERE pa.amountImage != ''", metroGrid6);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(filePathExp);
            Microsoft.Office.Interop.Excel.Worksheet xlWorksheet = xlWorkbook.Sheets[1]; // assume it is the first sheet
            int columnCount = xlWorksheet.UsedRange.Columns.Count;
            List<string> columnNames = new List<string>();
            for (int c = 1; c < columnCount; c++)
            {
                if (xlWorksheet.Cells[1, c].Value2 != null)
                {
                    string columnName = xlWorksheet.Columns[c].Address;
                    Regex reg = new Regex(@"(\$)(\w*):");
                    if (reg.IsMatch(columnName))
                    {
                        Match match = reg.Match(columnName);
                        columnNames.Add(match.Groups[2].Value);
                    }
                    Console.WriteLine(columnName.ToString());

                }

            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            //hepsiburada.com /
            progressBar1.Value = 0;
            mysql.FillDatatable("SELECT pa.idProduct,pa.amount,pa.barcode,p.productName,p.salePrice FROM product_amount AS pa INNER JOIN product AS p ON pa.idProduct = p.id INNER JOIN hb_products AS hb ON hb.akilli_barcode = pa.barcode WHERE pa.barcode != '' AND hb.hb_sku != ''", metroGrid1);
            Thread.Sleep(1000);
            listBox2.Items.Add(metroGrid1.Rows.Count.ToString());
            progressBar1.Maximum = metroGrid1.Rows.Count;
            Console.WriteLine(metroGrid1.Rows.Count);
            foreach (DataGridViewRow row in metroGrid1.Rows)
            {

                try
                {
                    //String query = "INSERT INTO hb_products(akilli_id, akilli_barcode, akilli_name,stock,price) VALUES('" + row.Cells[0].Value.ToString() + "','" + row.Cells[2].Value.ToString() + "','" + row.Cells[3].Value.ToString() + "','" + Convert.ToInt32(row.Cells[1].Value) + "','" + Convert.ToDecimal(row.Cells[4].Value) + "')";
                    String query = "UPDATE hb_products SET stock=" + Convert.ToDouble(row.Cells[1].Value.ToString()) + ", price='" + row.Cells[4].Value.ToString() + "' WHERE akilli_barcode='" + row.Cells[2].Value.ToString() + "'";
                    Console.WriteLine(query);
                    progressBar1.Value++; // Convert.ToDouble(100 / metroGrid1.Rows.Count);
                    Thread.Sleep(10);
                    mysql.UpdateData(query);
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                    listBox2.Items.Add("2" + ex.Message);
                }
            }
            listBox2.Items.Add("Datalar Güncellendi");
        }

        private async void button16_Click(object sender, EventArgs e)
        {
            Task<int> task = new Task<int>(CountChracter);
            task.Start();

            int count = await task;
            MessageBox.Show(count.ToString());
        }

        private int CountChracter()
        {
            int count = 0;
            using(StreamReader reader = new StreamReader(@"C:\Users\Lenovo\Desktop\Yeni\test.txt"))
            {
                string content = reader.ReadToEnd();
                count = content.Length;
                Thread.Sleep(5000);
            }

            return count;
        }

        private async void button17_ClickAsync(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                Thread.Sleep(1000);
            });
            MessageBox.Show("Hi from the UI thread! 1");
        }

        private void button16_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}