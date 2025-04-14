using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp3;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;
namespace SecondTask
{
    class KursComUa : CurrencyAPI
    {
        private static List<HtmlNode> currencyDocumentListHtml;
        public override string[] GetDollar()
        {
            Task task = Task.Factory.StartNew(() => SendRequest());
            task.Wait();
            System.Threading.Thread.Sleep(1500);
            if (currencyDocumentListHtml != null)
            {
                var dollarPurchaseString = currencyDocumentListHtml[0].InnerHtml.ToString();
                string[] dollarPurchaseStringArray = dollarPurchaseString.Split(new[] { '<' },
                StringSplitOptions.RemoveEmptyEntries);
                var dollarPurchaseKursComUa = dollarPurchaseStringArray[0];
                var dollarSaleString = currencyDocumentListHtml[1].InnerHtml.ToString();
                string[] dollarSaleStringArray = dollarSaleString.Split(new[] { '<' },
                StringSplitOptions.RemoveEmptyEntries);
                var dollarSaleKursComUa = dollarSaleStringArray[0];
                return new string[] { dollarPurchaseKursComUa, dollarSaleKursComUa };
            }
            else
            {
                return null;
            }
        }
        public override string[] GetEuro()
        {
            if (currencyDocumentListHtml != null)
            {
                var euroPurchaseString = currencyDocumentListHtml[4].InnerHtml.ToString();
                string[] euroPurchaseStringArray = euroPurchaseString.Split(new[] { '<' },
                StringSplitOptions.RemoveEmptyEntries);
                var euroPurchaseKursComUa = euroPurchaseStringArray[0];
                var euroSaleString = currencyDocumentListHtml[5].InnerHtml.ToString();
                string[] euroSaleStringArray = euroSaleString.Split(new[] { '<' },
                StringSplitOptions.RemoveEmptyEntries);
                var euroSaleKursComUa = euroSaleStringArray[0];
                return new string[] { euroPurchaseKursComUa, euroSaleKursComUa };
            }
            else
            {
                return null;
            }
        }
       
        private static async void SendRequest()
        {
            try
            {
                var httpClient = new HttpClient();
                var html = await httpClient.GetStringAsync(Constants.KursComUaUrl);
                var htmlDocument = new HtmlDocument();
                htmlDocument.LoadHtml(html);
                currencyDocumentListHtml = htmlDocument.DocumentNode.Descendants("div")
                .Where(node => node.GetAttributeValue("class", "")
                .Equals("course")).ToList();
            }
            catch
            {
                MessageBox.Show(Properties.Resources.WarningMessage, Properties.Resources.WarningTitle,
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
