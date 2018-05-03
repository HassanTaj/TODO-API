using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
//using System.Web.Script.Serialization;

namespace ConsoleClient {


    class Todo {
        public int Id { get; set; }
        public string Task { get; set; }
        public bool IsDone { get; set; }
    }
    class Program {
        static void Main(string[] args) {

            string baseurl = "http://www.todoapi.somee.com/api/";

            // object
            Todo t = new Todo {
                Id = 1,
                IsDone = false,
                Task = "do something special"
            };

            // serialization
            // do when you need to upload something in json format to an api
            //var serializedString = new JavaScriptSerializer().Serialize(t);
            //Console.WriteLine(serializedString);

            // deserialization
            //WebClient client = new WebClient();

            //Console.WriteLine(client.DownloadString($"{baseurl}todos"));
            //try {

            //    var deserializedList = new JavaScriptSerializer().Deserialize<List<Todo>>(client.DownloadString($"{baseurl}todos"));
            //    Console.WriteLine(deserializedList);

            //    foreach (Todo item in deserializedList) {
            //        Console.WriteLine($"Task : {item.Task} \n");
            //    }
            //}
            //catch (Exception ex) {

            //    Console.WriteLine(ex.Message);
            //}
           
            Console.ReadKey();

        }
    }

  
}
