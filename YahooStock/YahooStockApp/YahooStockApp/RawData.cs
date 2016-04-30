using System;

using System.Net;
using System.IO;
using System.Threading.Tasks;

namespace YahooStockApp
{

    public static class StockReporting
    {

  
        public async static Task<string> GetQuoteLatest(string pstrSymbol)
        {
            string strURL = null;
            string strBuffer = null;

            //Creates the request URL for Yahoo
            strURL = "http://quote.yahoo.com/d/quotes.csv?" + "s=" + pstrSymbol + "&d=t" + "&f=sl1d1t1c1ohgvj1pp2wern";

            strBuffer = await RequestWebData(strURL);

            return strBuffer;
        }

        private async static Task<string> RequestWebData(string pstrURL)
        {
            WebRequest objWReq = default(WebRequest);
            WebResponse objWResp = default(WebResponse);
            string strBuffer = null;

            //Contact the website
            objWReq = HttpWebRequest.Create(pstrURL);
            objWResp = await objWReq.GetResponseAsync();

            //Read the answer from the Web site and store it into a stream
            StreamReader objSR = default(StreamReader);
            objSR = new StreamReader(objWResp.GetResponseStream());
            strBuffer = objSR.ReadToEnd();
           // objSR.Close();

           // objWResp.Close();

            return strBuffer;
        }
        //End Class
    }

}