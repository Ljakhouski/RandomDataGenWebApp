using Newtonsoft.Json;
using RandomDataGenWebApp.Models;
using System.Reflection;
using System.Text.Json;

namespace RandomDataGenWebApp
{
    public static class JsonSelector
    {
        public static void Select()
        {
            //var assembly = Assembly.GetExecutingAssembly();
            //var resourceName = "EmbeddedResource.Data.foreign_names.json";

            /* using (Stream stream = new FileStream(""))
             using (StreamReader reader = new StreamReader(""))
             {
                 var myDeserializedClass = JsonSerializer.DeserializeAsync<List<Root>>(stream);

                 var res = myDeserializedClass.Result;
                 //string jsonFile = reader.ReadToEnd(); //Make string equal to full file
             }*/
            
            using (StreamReader r = new StreamReader("foreign_names.json"))
            {
                string json = r.ReadToEnd();
                List<Root> items = JsonConvert.DeserializeObject<List<Root>>(json);

                var new_ = from item in items where item.origin.Contains("American") select item.name;

                var v = new SourceDataModel();
               // v.UK_names = (List<string>)new_;
                v.USA_names = v.UK_names;


            }


        }
    }

    public class Root
    {
        public int id { get; set; }
        public string name { get; set; }
        public string meaning { get; set; }
        public string gender { get; set; }
        public string origin { get; set; }
        public int PeoplesCount { get; set; }
        public DateTime WhenPeoplesCount { get; set; }
        public string Source { get; set; }
    }
}
