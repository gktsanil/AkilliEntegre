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
using System.Xml;
using RestSharp;
using System.Net;
using System.Xml.Linq;

namespace AkilliEntegre
{
    public partial class HBSection : MetroForm
    {
        Functions func = new Functions();
        HBAPi hb = new HBAPi();
        Export exp = new Export();

        private String userName = "akilliphone_dev";
        private String password = "Ak12345!";
        //String merchantId = "1ecc8c0a-df6d-4f5f-8463-e6ea8ec6673d";
        private String merchantId = "b23af4c1-395a-4a82-b6fd-07eea0dd51b2";
        private String listingHost = "https://listing-external-sit.hepsiburada.com/";

        public HBSection()
        {
            InitializeComponent();
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
                MessageBox.Show(urunListe.StatusCode.ToString());
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

        private void xlsxExport_Click(object sender, EventArgs e)
        {
            exp.ExcellExport(metroGrid1);
        }

    }
}
