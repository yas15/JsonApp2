using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace ConsoleApp12
{
    class Program
    {
        static void Main(string[] args)
        {

            //List<Post> posts = GetPosts();
            JObject rss =
                new JObject(
                    new JProperty("channel",
                        new JObject(
                            new JProperty("title", "James Newton-King"),
                            new JProperty("link", "http://james.newtonking.com"),
                            new JProperty("description", "James Newton-King's blog."),
                            new JProperty("item",
                                new JArray(
                                    new JObject(
                                        new JProperty("title", "p.Title"),
                                        new JProperty("description", "p.Description"),
                                        new JProperty("link", "p.Link"),
                                        new JProperty("category",
                                            new JArray(1, 2, 3
                                                ))))))));


            Console.WriteLine(rss.ToString());
            Console.ReadKey();


            JObject outputJ =
                new JObject(
                    new JProperty("drugs", "ertapenem"),
                    new JProperty("suggestedDose",
                        new JArray(
                            new JObject(
                                new JProperty("indications",
                                    new JArray("Abdominal infections", "Acute gynaecological infections", "Community-acquired pneumonia")),
                                new JProperty("doseAdministrations",
                                    new JArray(
                                        new JObject(
                                            new JProperty("route", "Intravenous"),
                                            new JProperty("method", "Infusion"),
                                            new JProperty("doses",
                                                new JArray(
                                                    new JObject(
                                                        new JProperty("ageBand",
                                                            new JObject(
                                                                new JProperty("ageLow",
                                                                    new JObject(
                                                                        new JProperty("value", "13"),
                                                                        new JProperty("unit", "year"))),
                                                                new JProperty("ageHigh",
                                                                    new JObject(
                                                                        new JProperty("value", "17"),
                                                                        new JProperty("unit", "year")
                                                                        )))),
                                                        new JProperty("quantity",
                                                            new JObject(
                                                                new JProperty("value", 1.0),
                                                                new JProperty("unit", "g"))),
                                                        new JProperty("flags",
                                                            new JObject(
                                                                new JProperty("frequency", "1 times daily as a single dose")))),
                                
                                                    new JObject(
                                                        new JProperty("ageBand",
                                                            new JObject(
                                                                new JProperty("ageLow",
                                                                    new JObject(
                                                                        new JProperty("value", "3"),
                                                                        new JProperty("unit", "months"))),
                                                                new JProperty("ageHigh",
                                                                    new JObject(
                                                                        new JProperty("value", "12"),
                                                                        new JProperty("unit", "year")
                                                                        )))),
                                                        new JProperty("quantity",
                                                            new JObject(
                                                                new JProperty("value", 15.0),
                                                                new JProperty("unit", "mg/kg"))),
                                                        new JProperty("flags",
                                                            new JObject(
                                                                new JProperty("frequency", "Every 12 hour(s)")))))))))),

            new JObject(
                new JProperty("indications",
                    new JArray("Diabetic foot infections of the skin and soft-tissue")),
                new JProperty("doseAdministrations",
                    new JArray(
                        new JObject(
                            new JProperty("route", "Intravenous"),
                            new JProperty("method", "Infusion"),
                            new JProperty("doses",
                                new JArray(
                                    new JObject(
                                        new JProperty("ageBand",
                                            new JObject(
                                                new JProperty("ageLow",
                                                    new JObject(
                                                        new JProperty("value", "13"),
                                                        new JProperty("unit", "year"))),
                                                new JProperty("ageHigh",
                                                    new JObject(
                                                        new JProperty("value", "17"),
                                                        new JProperty("unit", "year")
                                                        )))),
                                        new JProperty("quantity",
                                            new JObject(
                                                new JProperty("value", 1.0),
                                                new JProperty("unit", "g"))),
                                        new JProperty("flags",
                                            new JObject(
                                                new JProperty("frequency", "1 times daily as a single dose")))))))))))));

            Console.WriteLine(outputJ.ToString());
            Console.ReadKey();

        }
    }
}
