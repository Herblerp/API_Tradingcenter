using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This is the class that should be called whenever an interaction with the BitMEX API is required, as it implements all other BitMEX classes
//This class should only be called at most once every 2 seconds per account, or BitMEX will start to limit your rate
namespace BitMEX_API
{
    class BitMEX
    {
        //Returntype should probably be something else, to prevent a clusterfuck of conversions between different Order classes in the class where this method gets called
        public static List<BitMEXOrder> getAllOrders(string apiKey, string apiSecret)
        {
            BitMEXApi bitmex = new BitMEXApi(apiKey, apiSecret);
            List<BitMEXOrder> orderlist = new List<BitMEXOrder>();
            var jsonStream = bitmex.GetOrders();
            
            //When multiple values are returned, they get encompassed by [], which the deserializer doesn't like. The following code gets rid of them
            if (jsonStream.IndexOf("[") == 0)
            {
                jsonStream = jsonStream.Substring(1);
                jsonStream = jsonStream.Remove(jsonStream.Length - 1);
            }
            if (jsonStream.IndexOf("error") == 2)
            {
                jsonStream = jsonStream.Substring(9);
                jsonStream = jsonStream.Remove(jsonStream.Length - 1);
                //Error handling code should be implemented here
            }
            jsonStream = jsonStream.Replace("},", "}");

            //For debugging
            /*
            var temp = jsonStream;
            temp = temp.Replace("}", "}\n\n");
            Console.WriteLine(temp);
            */

            JsonTextReader reader = new JsonTextReader(new StringReader(jsonStream));
            reader.SupportMultipleContent = true;

            while (true)
            {
                if (!reader.Read())
                {
                    break;
                }

                JsonSerializer serializer = new JsonSerializer
                {
                    NullValueHandling = NullValueHandling.Ignore
                };
                BitMEXOrder order = serializer.Deserialize<BitMEXOrder>(reader);

                orderlist.Add(order);
            }
            return orderlist;
        }

        //Returntype should probably be something else, to prevent a clusterfuck of conversions between different Order classes in the class where this method gets called
        public static List<BitMEXOrder> getOrdersSince(string apiKey, string apiSecret, DateTime dt)
        {
            BitMEXApi bitmex = new BitMEXApi(apiKey, apiSecret);
            List<BitMEXOrder> orderlist = new List<BitMEXOrder>();
            var jsonStream = bitmex.GetOrders(dt);

            //When multiple values are returned, they get encompassed by [], which the deserializer doesn't like. The following code gets rid of them
            if (jsonStream.IndexOf("[") == 0)
            {
                jsonStream = jsonStream.Substring(1);
                jsonStream = jsonStream.Remove(jsonStream.Length - 1);
            }
            if (jsonStream.IndexOf("error") == 2)
            {
                jsonStream = jsonStream.Substring(9);
                jsonStream = jsonStream.Remove(jsonStream.Length - 1);
                //Error handling code should be implemented here
            }
            jsonStream = jsonStream.Replace("},", "}");

            //For debugging
            /*
            var temp = jsonStream;
            temp = temp.Replace("}", "}\n\n");
            Console.WriteLine(temp);
            */

            JsonTextReader reader = new JsonTextReader(new StringReader(jsonStream));
            reader.SupportMultipleContent = true;

            while (true)
            {
                if (!reader.Read())
                {
                    break;
                }

                JsonSerializer serializer = new JsonSerializer
                {
                    NullValueHandling = NullValueHandling.Ignore
                };
                BitMEXOrder order = serializer.Deserialize<BitMEXOrder>(reader);

                orderlist.Add(order);
            }
            return orderlist;
        }

        //Returntype should probably be something else, to prevent a clusterfuck of conversions between different Order classes in the class where this method gets called
        public static List<BitMEXPosition> getAllPositions(string apiKey, string apiSecret)
        {
            BitMEXApi bitmex = new BitMEXApi(apiKey, apiSecret);
            List<BitMEXPosition> positionlist = new List<BitMEXPosition>();
            var jsonStream = bitmex.GetPositions();

            //When multiple values are returned, they get encompassed by [], which the deserializer doesn't like. The following code gets rid of them
            if (jsonStream.IndexOf("[") == 0)
            {
                jsonStream = jsonStream.Substring(1);
                jsonStream = jsonStream.Remove(jsonStream.Length - 1);
            }
            if (jsonStream.IndexOf("error") == 2)
            {
                jsonStream = jsonStream.Substring(9);
                jsonStream = jsonStream.Remove(jsonStream.Length - 1);
                //Error handling code should be implemented here
            }
            jsonStream = jsonStream.Replace("},", "}");

            //For debugging
            /*
            var temp = jsonStream;
            temp = temp.Replace("}", "}\n\n");
            Console.WriteLine(temp);
            */

            JsonTextReader reader = new JsonTextReader(new StringReader(jsonStream));
            reader.SupportMultipleContent = true;

            while (true)
            {
                if (!reader.Read())
                {
                    break;
                }

                JsonSerializer serializer = new JsonSerializer
                {
                    NullValueHandling = NullValueHandling.Ignore
                };
                BitMEXPosition position = serializer.Deserialize<BitMEXPosition>(reader);

                positionlist.Add(position);
            }
            return positionlist;
        }

        //Returntype should probably be something else, to prevent a clusterfuck of conversions between different Order classes in the class where this method gets called
        public static List<BitMEXPosition> getPositionsSince(string apiKey, string apiSecret, DateTime dt)
        {
            BitMEXApi bitmex = new BitMEXApi(apiKey, apiSecret);
            List<BitMEXPosition> positionlist = new List<BitMEXPosition>();
            var jsonStream = bitmex.GetPositions(dt);

            //When multiple values are returned, they get encompassed by [], which the deserializer doesn't like. The following code gets rid of them
            if (jsonStream.IndexOf("[") == 0)
            {
                jsonStream = jsonStream.Substring(1);
                jsonStream = jsonStream.Remove(jsonStream.Length - 1);
            }
            if (jsonStream.IndexOf("error") == 2)
            {
                jsonStream = jsonStream.Substring(9);
                jsonStream = jsonStream.Remove(jsonStream.Length - 1);
                //Error handling code should be implemented here
            }
            jsonStream = jsonStream.Replace("},", "}");

            //For debugging
            /*
            var temp = jsonStream;
            temp = temp.Replace("}", "}\n\n");
            Console.WriteLine(temp);
            */

            JsonTextReader reader = new JsonTextReader(new StringReader(jsonStream));
            reader.SupportMultipleContent = true;

            while (true)
            {
                if (!reader.Read())
                {
                    break;
                }

                JsonSerializer serializer = new JsonSerializer
                {
                    NullValueHandling = NullValueHandling.Ignore
                };
                BitMEXPosition position = serializer.Deserialize<BitMEXPosition>(reader);

                positionlist.Add(position);
            }
            return positionlist;
        }

        //Returntype should probably be something else, to prevent a clusterfuck of conversions between different Order classes in the class where this method gets called
        public static List<BitMEXWallet> getWallets(string apiKey, string apiSecret)
        {
            BitMEXApi bitmex = new BitMEXApi(apiKey, apiSecret);
            List<BitMEXWallet> walletlist = new List<BitMEXWallet>();
            var jsonStream = bitmex.GetWallets();

            //When multiple values are returned, they get encompassed by [], which the deserializer doesn't like. The following code gets rid of them
            if (jsonStream.IndexOf("[") == 0)
            {
                jsonStream = jsonStream.Substring(1);
                jsonStream = jsonStream.Remove(jsonStream.Length - 1);
            }
            if (jsonStream.IndexOf("error") == 2)
            {
                jsonStream = jsonStream.Substring(9);
                jsonStream = jsonStream.Remove(jsonStream.Length - 1);
                //Error handling code should be implemented here
            }
            jsonStream = jsonStream.Replace("},", "}");

            //For debugging
            /*
            var temp = jsonStream;
            temp = temp.Replace("}", "}\n\n");
            Console.WriteLine(temp);
            */

            JsonTextReader reader = new JsonTextReader(new StringReader(jsonStream));
            reader.SupportMultipleContent = true;

            while (true)
            {
                if (!reader.Read())
                {
                    break;
                }

                JsonSerializer serializer = new JsonSerializer
                {
                    NullValueHandling = NullValueHandling.Ignore
                };
                BitMEXWallet wallet = serializer.Deserialize<BitMEXWallet>(reader);

                walletlist.Add(wallet);
            }
            return walletlist;
        }
    }
}
