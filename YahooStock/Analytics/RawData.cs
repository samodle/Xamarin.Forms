using System;

using System.Net;
using System.IO;
using System.Threading.Tasks;

namespace Analytics
{

    public static class StockReporting
    {

  
        public async static Task<string> GetQuoteLatest(string pstrSymbol)
        {
            string strURL = null;
            string strBuffer = null;

            //Creates the request URL for Yahoo
            strURL = "http://quote.yahoo.com/d/quotes.csv?" + "s=" + pstrSymbol + "&d=t" + "&f=sl1d1t1c1ohgvj1pp2wern";

            strBuffer = RequestWebData(strURL);

            return strBuffer;
            //Loop through the lines returned and transform it to a XML string
            var strReturn = new System.Text.StringBuilder();
            //  strReturn.Append("<StockQuoteLatest>" & Environment.NewLine)



            /*
            foreach (string strLine in strBuffer.Split(ControlChars.Lf))
            {
                if (strLine.Length > 0)
                {
                    //   strReturn.Append(TransformLatestLine(strLine) & Environment.NewLine)
                }
            }
            //    strReturn.Append("</StockQuoteLatest>" & Environment.NewLine)
            */


            return strReturn.ToString();
        }

        private static void GetQuoteLatest(string pstrSymbol, ref string Price, ref string Delta, ref string sDate, ref string sTime)
        {
            string strURL = null;
            string strBuffer = null;
            //  Dim WE_HAVE_INTERNET As Boolean = True
            //Creates the request URL for Yahoo
            strURL = "http://quote.yahoo.com/d/quotes.csv?" + "s=" + pstrSymbol + "&d=t" + "&f=sl1d1t1c1ohgvj1pp2wern";
            try
            {
                strBuffer = RequestWebData(strURL);
            }
            catch (Exception ex)
            {
                strBuffer = "";
                Price = "";
                Delta = "";
                sDate = "";
                sTime = "";
                //  WE_HAVE_INTERNET = False
                return;
            }
            //Loop through the lines returned and transform it to a XML string
            //   If WE_HAVE_INTERNET Then

/* commented out because control chars?
            foreach (string strLine in strBuffer.Split(ControlChars.Lf))
            {
                if (strLine.Length > 0)
                {
                    TransformLatestLine(strLine, ref Price, ref Delta, ref sDate, ref sTime);
                }
            }
*/


            //  End If
        }


        private static string TransformLatestLine(string pstrLine, ref string Price, ref string Delta, ref string sDate, ref string sTime)
        {
            string[] arrLine = null;
            var strXML = new System.Text.StringBuilder();

            arrLine = pstrLine.Split(',');

            //  Return (arrLine[1] & vbCrLf & arrLine[2].Replace(Chr(34), "") & vbCrLf & arrLine(3).Replace(Chr(34), ""))
            try
            {
                Price = arrLine[1];
                Delta = arrLine[4];
                sTime = arrLine[3]; //C# removal    .Replace((char)34, "");
                sDate = arrLine[2]; //C# removal   .Replace((char)34, "");
            }
            catch 
            {
                //oops...no internet?
            }
            return "";
        }

        private static string RequestWebData(string pstrURL)
        {
            WebRequest objWReq = default(WebRequest);
            WebResponse objWResp = default(WebResponse);
            string strBuffer = null;

            //Contact the website
            objWReq = HttpWebRequest.Create(pstrURL);
            objWResp = objWReq.GetResponse();

            //Read the answer from the Web site and store it into a stream
            StreamReader objSR = default(StreamReader);
            objSR = new StreamReader(objWResp.GetResponseStream());
            strBuffer = objSR.ReadToEnd();
            objSR.Close();

            objWResp.Close();

            return strBuffer;
        }
        //End Class
    }

}