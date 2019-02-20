using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace ErtapenemJson
{
    class Program
    {
        static void Main(string[] args)
        {

            string jsonTextObject = File.ReadAllText(@"..\..\JSON\input_BNF_ertapenem.json");
            JObject inputErtapenemJson = JObject.Parse(jsonTextObject);

            string inputName = (string)inputErtapenemJson["drugs"][0]["name"];
            Console.WriteLine(inputName);


            //IList<string> indications = new List<string>() { "Abdominal infections", "Acute gynaecological infections", "Community-acquired pneumonia11"};
            var indicationsDict= inputErtapenemJson["drugs"][0]["indicationsDose"]["indicationAndDoseGroups"][0]["therapeuticIndications"];
            Console.WriteLine(indicationsDict);

            var indicationsList = indicationsDict.Select(c => c["indication"]).ToList();
            foreach (var item in indicationsList)
            {
                Console.WriteLine(item);
            }

            var indications = string.Join(", ", indicationsList);
            Console.WriteLine(indications);

            Console.ReadKey();

            JObject outputJ =
                new JObject(
                    new JProperty("name", (string)inputErtapenemJson["drugs"][0]["name"]),
                    new JProperty("suggestedDose",
                        new JArray(
                            new JObject(
                                new JProperty("indications",
                                    //new JArray("Abdominal infections", "Acute gynaecological infections", "Community-acquired pneumonia")),
                                    indications),
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

            Console.WriteLine("Done");
            Console.ReadKey();

        }
    }
}
