using RestSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AkilliEntegre.Model
{
    class HBAPi
    {
        //Real APi
  //      $merchantid = "1ecc8c0a-df6d-4f5f-8463-e6ea8ec6673d";
		//$username = "akıllıphone_dev";
		//$password = "zrUN6tk5!";

        private String userName = Properties.Settings.Default.APiUser.ToString();//"akilliphone_dev";
        private String password = Properties.Settings.Default.APiPass.ToString();//"Ak12345!";
        //String merchantId = "1ecc8c0a-df6d-4f5f-8463-e6ea8ec6673d";
        private String merchantId = Properties.Settings.Default.APiKey.ToString();//"b23af4c1-395a-4a82-b6fd-07eea0dd51b2";
        private String listingHost = Properties.Settings.Default.APiUrl.ToString(); //"https://listing-external-sit.hepsiburada.com/";
        public List<Array> listingsList;
        public DataGridView table;

        public HBAPi(String user, String pass, String merchantId, String host)
        {
            this.userName = user;
            this.password = pass;
            this.merchantId = merchantId;
            this.listingHost = host;
        }

        private String CreateUpdatePost()
        {
            /*
             Headers
             Authorization: Basic base64(username:password)
             Content-Type: application/xml
            */
            return this.listingHost + "listings/merchantid/" + this.merchantId + "/inventory-uploads";
        }

        private String InventoryUploadResultGet(String inventoryId)
        {
            /*
             Headers
             Authorization: Basic base64(username:password)
             Content-Type: application/xml
            */
            return this.listingHost + "listings/merchantid/" + this.merchantId + "/inventory-uploads/id/" + inventoryId;
        }

        private String ListOfListingsGet()
        {
            /*
             Headers
             Authorization: Basic base64(username:password)
             Content-Type: application/xml
            */
            return this.listingHost + "listings/merchantid/" + this.merchantId;
        }

        private String MakeXMLString(List<Array> ProductList)
        {
            String xmlString = "";

            //String baseListingStr = @"
            //<listings>
            //  <listing>
            //    <UniqueIdentifier></UniqueIdentifier>
            //    <HepsiburadaSku>HBV000004WVJQ</HepsiburadaSku>
            //    <MerchantSku>HBV000004WVJQ</MerchantSku>
            //    <ProductName>iPhone 8 Ekran ve DOkunmatik</ProductName>
            //    <Price>1045</Price>
            //    <AvailableStock>100</AvailableStock>
            //    <DispatchTime>1</DispatchTime>
            //    <CargoCompany1>Yurtiçi Kargo</CargoCompany1>
            //    <CargoCompany2>Aras Kargo</CargoCompany2>
            //    <CargoCompany3>Horoz Lojistik</CargoCompany3>
            //    <MaximumPurchasableQuantity>4</MaximumPurchasableQuantity>
            //  </listing>
            //</listings>
            //";


            return xmlString;
        }

        private String StringXMLToDatatable(String content)
        {
            StringReader theReader = new StringReader(content);
            DataSet theDataSet = new DataSet();
            theDataSet.ReadXml(theReader);

            this.table.DataSource = theDataSet.Tables[0];

            return theReader.ToString();
        }

        private String baseListingStr = @"
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
        </listings>
        ";

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

        private void btnHb_Click(object sender, EventArgs e)
        {
            //this.UrunListeGetir();
            this.UrunGuncelle(this.strXml);
        }
        
        IRestResponse UrunListesiGetir()
        {
            var client = new RestClient("https://listing-external-sit.hepsiburada.com/listings/merchantid/" + this.merchantId);

            String svcCredentials = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(this.userName + ":" + this.password));

            var request = new RestRequest(Method.GET);
            request.AddHeader("merchantid", this.merchantId);
            request.AddHeader("content-type", "application/xml");
            request.AddHeader("Authorization", "Basic " + svcCredentials);
            IRestResponse response = client.Execute(request) as RestResponse;

            return response;
        }
        
        public String UrunListeGetir()
        {

            IRestResponse urunListe = this.UrunListesiGetir();

            if (urunListe.StatusCode == HttpStatusCode.OK)
            {
                //MessageBox.Show(urunListe.Content);
                //dataGridView1.DataSource = urunListe.Content;
                return urunListe.Content;
            }
            else
            {
                MessageBox.Show(urunListe.StatusCode.ToString());
                return "0";
            }
        }

        public String UrunGuncelle(String strXml)
        {
            var uri = Properties.Settings.Default.APiUrl.ToString() + "listings/merchantId/" + merchantId + "/inventory-uploads";

            var client = new RestClient(uri);
            var request = new RestRequest(Method.POST);
            string svcCredentials = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(this.userName + ":" + this.password));

            request.AddHeader("merchantid", this.merchantId);
            request.AddHeader("Authorization", "Basic " + svcCredentials);
            request.RequestFormat = RestSharp.DataFormat.Xml;

            if (!string.IsNullOrEmpty(strXml))
            {
                request.AddParameter("application/xml", strXml, ParameterType.RequestBody);

                var result = "";
                var response = client.Execute(request);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    result = response.Content;
                    Console.WriteLine(result);
                    MessageBox.Show(result);
                }
                else
                {
                    result = response.StatusCode.ToString();
                }

                return result;
            }
            return null;
        }
    }
}
