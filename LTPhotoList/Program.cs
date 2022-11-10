using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LTPhotoList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var builder = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                IConfiguration config = builder.Build();
                Console.WriteLine("Enter the Gallery ID:  ");
                string? strInput = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(strInput) == false)
                { 
                    bool blnIsNumber = Int32.TryParse(strInput.Trim(), out int intGalleryID);
                    if (blnIsNumber == true) 
                    {
                        string strURL = config["BaseUrl"] + "?" + config["GalleryParam"] + "=" + strInput;
                        HttpClient myWebClient = new HttpClient();
                        string myResponse = myWebClient.GetStringAsync(strURL).Result;
                        if (string.IsNullOrEmpty(myResponse) == false) 
                        {
                            JArray jaImages = JsonConvert.DeserializeObject<JArray>(myResponse);
                            if (jaImages != null && jaImages.Count > 0) 
                            {

                                foreach (JToken jtItem in jaImages) 
                                {
                                    Console.WriteLine(string.Format("[{0}] {1}", jtItem["id"].Value<string>(), jtItem["title"].Value<string>()));

                                }

                            }

                            else //jaImages == null || jaImages.Count <= 0
                            {
                                Exception ex = new Exception("No Images Found.");
                                throw ex;

                            }

                        }

                        else //string.IsNullOrEmpty(myResponse) == true
                        {
                            Exception ex = new Exception("Empty web response.");
                            throw ex;

                        }

                    }

                    else //blnIsNumber == false
                    {
                        Exception ex = new ArgumentException("Non-numeric string provided as input.");
                        throw ex;

                    }

                }

                else //string.IsNullOrEmpty(strInput) == true
                {
                    Exception ex = new ArgumentException("Null or Empty string provided as input.");
                    throw ex;

                }

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }

            Console.WriteLine("Press any key to exit");
            Console.ReadLine();

        }

    }

}