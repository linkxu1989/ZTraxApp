using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using Newtonsoft.Json.Linq;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Windows.Media.Imaging;
using Zebra.Sdk.Comm;
using System.Windows;
using System.Windows.Threading;

namespace ZTraxApp.Models
{
    public static class CommonService
    {
        public static BitmapImage GetPrintImage(string theIpAddress, string Command, int Port)
        {
            // Instantiate connection for ZPL TCP port at given address
            Connection thePrinterConn = new TcpConnection(theIpAddress, Port);
            BitmapImage imageSource = new BitmapImage();
            try
            {
                // Open the connection - physical connection is established here.
                thePrinterConn.Open();
                // This example prints "This is a ZPL test." near the top of the label.
                //string Data = Command;

                byte[] byteCommand = Encoding.Default.GetBytes(Command);
                byte[] LinkOsbyteResponse = thePrinterConn.SendAndWaitForResponse(byteCommand, 1000, 2000, "\n\"\"");
                string received_string = Encoding.Default.GetString(LinkOsbyteResponse).TrimStart('"').TrimEnd('"');
                byte[] received_byte = Encoding.Default.GetBytes(received_string);
                //int data_length = Encoding.UTF8.GetBytes(received_data).Length;

                if(received_string.Length > 4)
                {
                    MemoryStream ms = new MemoryStream(received_byte, 0, received_byte.Length);
                    //ms.Position = 0;
                    //ms.Seek(0, SeekOrigin.Begin);
                    imageSource.BeginInit();
                    imageSource.StreamSource = ms;
                    imageSource.EndInit();
                }
                //else
                //{
                //    imageSource.BeginInit();
                //    imageSource.UriSource = new Uri("/Resources/Image/noimage.png", UriKind.Relative);
                //    imageSource.EndInit();
                //}
                
                //return imageSource;
            }
            catch (Exception e)
            {
                // Handle communications error here.
                Console.WriteLine(e.ToString());
            }
            finally
            {
                // Close the connection to release resources.
                thePrinterConn.Close();
            }
            return imageSource;
        }

        public static string GetPrintInfo(string theIpAddress, string Command, int Port)
        {
            // Instantiate connection for ZPL TCP port at given address
            Connection thePrinterConn = new TcpConnection(theIpAddress, Port);
            string received_string = "";
            try
            {
                // Open the connection - physical connection is established here.
                thePrinterConn.Open();
                // This example prints "This is a ZPL test." near the top of the label.
                //string Data = Command;

                byte[] byteCommand = Encoding.Default.GetBytes(Command);
                byte[] LinkOsbyteResponse = thePrinterConn.SendAndWaitForResponse(byteCommand, 1000, 2000, "\n\"\"");

                received_string = Encoding.Default.GetString(LinkOsbyteResponse);

                //int data_length = Encoding.UTF8.GetBytes(received_data).Length;

                //else
                //{
                //    imageSource.BeginInit();
                //    imageSource.UriSource = new Uri("/Resources/Image/noimage.png", UriKind.Relative);
                //    imageSource.EndInit();
                //}

                //return imageSource;
            }
            catch (Exception e)
            {
                // Handle communications error here.
                Console.WriteLine(e.ToString());
            }
            finally
            {
                // Close the connection to release resources.
                thePrinterConn.Close();
            }
            return received_string;
        }

        /// <summary>
        /// InsertContact
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="email"></param>
        /// <param name="employeeNumber"></param>
        /// <returns></returns>
        public static string InsertContact(string firstName, string lastName, string email, string employeeNumber)
        {
            string result;

            Dictionary<string, object> tempDict = new Dictionary<string, object>();
            tempDict.Add("FirstName", firstName);
            tempDict.Add("LastName", lastName);
            tempDict.Add("Email", email);
            tempDict.Add("IMEmployeeNo", employeeNumber);
            string jsonData = JsonConvert.SerializeObject(tempDict);
            result = SendPost("API", jsonData);//API address should be given if it is implement.
            return result;
        }


        // find first and last name of user linked to an asset
        public static string FindLastUserLinkedToAsset(string assetId)
        {
            string api = "TagData" + "?AssetID=" + assetId;
            JObject result = SendGet(api);
            string name = result["name"].ToString();//Need to show fullname
            return name;
        }



        //post changes to centra database server
        public static string PostRFIDData(string assetID, string tagID, string name, string location, string hostName, string typeofEvent, string description, DateTime timeStamp)
        {
            string result;
            Dictionary<string, object> tempDict = new Dictionary<string, object>();
            tempDict.Add("assetID", assetID);
            tempDict.Add("tagID", tagID);
            tempDict.Add("name", name);
            tempDict.Add("location", location);
            tempDict.Add("hostName", hostName);
            tempDict.Add("typfOfEvent", typeofEvent);
            tempDict.Add("description", description);
            tempDict.Add("timeStamp", timeStamp);

            string jsonData = JsonConvert.SerializeObject(tempDict);
            result = SendPost("TagData", jsonData);
            return result;
        }

        /// <summary>
        /// SendGet and response Jobject
        /// </summary>
        /// <param name="api"></param>
        /// <returns></returns>
        public static JObject SendGet(string api)
        {
            string url = ConfigurationManager.AppSettings["zTraxAPI"].ToString() + api;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Host = new Uri(url).Host;
            request.Method = "GET";
            request.ContentType = "application/json; charset=UTF-8";
            request.AllowAutoRedirect = false;
            request.Timeout = 60000;
            var jObject = new JObject();
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream myResponseStream = response.GetResponseStream();
                StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.UTF8);
                string retString = myStreamReader.ReadToEnd();
                myStreamReader.Close();
                myResponseStream.Close();

                if (response != null)
                {
                    response.Close();
                }
                if (request != null)
                {
                    request.Abort();
                }
                jObject = JObject.Parse(retString);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return jObject;
        }



        /// <summary>
        /// SendPost and response string
        /// </summary>
        /// <param name="api"></param>
        /// <param name="jsonData"></param>
        /// <returns></returns>
        public static string SendPost(string api, string jsonData)
        {
            string result = String.Empty;
            string url = ConfigurationManager.AppSettings["zTraxAPI"].ToString() + api;
            try
            {
                CookieContainer cookie = new CookieContainer();
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.Headers.Add("x-requested-with", "XMLHttpRequest");
                request.ServicePoint.Expect100Continue = false;
                request.ContentType = "application/json; charset=UTF-8";
                request.Accept = "*/*";
                request.UserAgent = null;
                request.ContentLength = Encoding.UTF8.GetByteCount(jsonData);
                request.CookieContainer = cookie;
                using (StreamWriter writer = new StreamWriter(request.GetRequestStream()))
                {
                    writer.Write(jsonData);
                }

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                response.Cookies = cookie.GetCookies(response.ResponseUri);
                using (Stream responseStream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(responseStream))
                    {
                        result = reader.ReadToEnd();
                        reader.Close();
                    }
                    responseStream.Close();
                }
                response.Close();
                response = null;
                request = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        

    }
}
     

   

 





