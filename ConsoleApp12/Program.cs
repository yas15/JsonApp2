﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ErtapenemJson.Models;

namespace ErtapenemJson
{
    class Program
    {
        static void Main(string[] args)
        {

            string jsonTextPath = @"..\..\JSON\input_BNF_ertapenem.json";
            string json = File.ReadAllText(jsonTextPath);


            //using (var reader = new JsonTextReader(new StringReader(json)))
            //{
            //    while (reader.Read())
            //    {
            //        Console.WriteLine("{0} : {1}", reader.ValueType, reader.Value);
            //        Console.WriteLine();
            //    }
            //}


            var reader2 = new JsonTextReader(new StringReader(json));
            JTokenReader tokenreader = new JTokenReader(JToken.ReadFrom(reader2));

            while (tokenreader.Read())
            {
                Console.WriteLine("{0} : {1} : {2}", tokenreader.TokenType, tokenreader.Value, tokenreader.Value);
            }


            Console.ReadKey();



            string jsonTextObject = File.ReadAllText(@"..\..\JSON\input_BNF_ertapenem.json");
            JObject inputErtapenemJson = JObject.Parse(jsonTextObject);

            string inputName = (string)inputErtapenemJson["drugs"][0]["name"];
            Console.WriteLine(inputName);


            //IList<string> indications = new List<string>() { "Abdominal infections", "Acute gynaecological infections", "Community-acquired pneumonia11"};
            var indicationsDict = inputErtapenemJson["drugs"][0]["indicationsDose"]["indicationAndDoseGroups"][0]["therapeuticIndications"];
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




            // JsonConvert.DeserializeObject<T>(String)
            // Deserializes a JSON string into a .NET object of type <T>
            // You will need to define the class <T>
            var input_BNF_ertapenem = JsonConvert.DeserializeObject<InputErtapenem>(json);


            var therapeuticIndications = input_BNF_ertapenem.drugs[0].indicationsDose.indicationAndDoseGroups[0].therapeuticIndications;
            var therapeuticIndicationsList = indicationsDict.Select(c => c["indication"]).ToString().ToList();


            Console.ReadKey();



            Suggesteddose suggesteddose = new Suggesteddose();
            //suggesteddose.indications = therapeuticIndicationsList;


            Drug drug = new Drug();
            drug.name = inputName;
            drug.suggestedDose = new Suggesteddose[] { suggesteddose };


            OutputErtapenem outputErtapenem = new OutputErtapenem();
            outputErtapenem.drugs = new Drug[] { drug };












            Console.WriteLine("Done");
            Console.ReadKey();

        }
    }
}
