using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Xml;
using System.Xml.Linq;
using YahooFantasyFootball.Models;

namespace YahooFantasyFootball.Services
{
    public class TempConvertApiService : ITempConvertApiService
    {
        public string ConvertTemperature(string temp, string fromUnits, string toUnits)
        {
            string _url = "http://www.webservicex.net/ConvertTemperature.asmx";
            string _action = "http://www.webserviceX.NET/ConvertTemp";

            XmlDocument soapEnvelopeXml = CreateSoapEnvelope(temp, fromUnits, toUnits);
            HttpWebRequest webRequest = CreateWebRequest(_url, _action);
            InsertSoapEnvelopeIntoWebRequest(soapEnvelopeXml, webRequest);

            // begin async call to web request.
            IAsyncResult asyncResult = webRequest.BeginGetResponse(null, null);

            asyncResult.AsyncWaitHandle.WaitOne();

            // get the response from the completed web request.
            string soapResult;
            using (WebResponse webResponse = webRequest.EndGetResponse(asyncResult))
            {
                using (StreamReader rd = new StreamReader(webResponse.GetResponseStream()))
                {
                    soapResult = rd.ReadToEnd();
                }
            }

            XDocument xDoc = XDocument.Load(new StringReader(soapResult));
            var newTemp = xDoc.Root.Value;

            return newTemp;
        }

        private static HttpWebRequest CreateWebRequest(string url, string action)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.Headers.Add("SOAPAction", action);
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
            return webRequest;
        }

        private static XmlDocument CreateSoapEnvelope(string temp, string fromUnits, string toUnits)
        {
            XmlDocument soapEnvelop = new XmlDocument();
            string soapMsg = String.Format(@"<soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/""><soap:Body><ConvertTemp xmlns=""http://www.webserviceX.NET/""><Temperature>{0}</Temperature><FromUnit>{1}</FromUnit><ToUnit>{2}</ToUnit></ConvertTemp></soap:Body></soap:Envelope>", temp, fromUnits, toUnits);
            soapEnvelop.LoadXml(soapMsg);
            return soapEnvelop;
        }

        private static void InsertSoapEnvelopeIntoWebRequest(XmlDocument soapEnvelopeXml, HttpWebRequest webRequest)
        {
            using (Stream stream = webRequest.GetRequestStream())
            {
                soapEnvelopeXml.Save(stream);
            }
        }
    }
}
