using System;
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

            //  Console.ReadKey();


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

            //    Console.ReadKey();

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


            // JsonConvert.DeserializeObject<T>(String)
            // Deserializes a JSON string into a .NET object of type <T>
            var input_BNF_ertapenem = JsonConvert.DeserializeObject<InputBnfDrug>(json);

            Doseadministration doseAdministration = new Doseadministration();
            doseAdministration.route = input_BNF_ertapenem.drugs[0].indicationsDose
                .indicationAndDoseGroups[0].routesAndPatientGroups[0].routesOfAdministration[0].routeOfAdministration.Replace("By intravenous infusion", "Intravenous");

            doseAdministration.method = input_BNF_ertapenem.drugs[0].indicationsDose
                .indicationAndDoseGroups[0].routesAndPatientGroups[0].routesOfAdministration[0].routeOfAdministration.Replace("By intravenous infusion", "Infusion");


            doseAdministration.doses = new List<Dose>{
                new Dose {ageBand = new Ageband {
                    ageLow = new Agelow{
                        value = Int32.Parse(input_BNF_ertapenem.drugs[0].indicationsDose.indicationAndDoseGroups[0].routesAndPatientGroups[0].patientGroups[0].age.from),
                        unit = input_BNF_ertapenem.drugs[0].indicationsDose.indicationAndDoseGroups[0].routesAndPatientGroups[0].patientGroups[0].age.fromUnit } ,
                    ageHigh = new Agehigh{
                        value = Int32.Parse(input_BNF_ertapenem.drugs[0].indicationsDose.indicationAndDoseGroups[0].routesAndPatientGroups[0].patientGroups[0].age.to),
                        unit = input_BNF_ertapenem.drugs[0].indicationsDose.indicationAndDoseGroups[0].routesAndPatientGroups[0].patientGroups[0].age.toUnit}},

                    quantity = new Quantity{
                        value = float.Parse(input_BNF_ertapenem.drugs[0].indicationsDose.indicationAndDoseGroups[0].routesAndPatientGroups[0]
                        .patientGroups[0].doseStatement.doseInstruction[0].doseQuantity.value),
                        unit = input_BNF_ertapenem.drugs[0].indicationsDose.indicationAndDoseGroups[0].routesAndPatientGroups[0]
                        .patientGroups[0].doseStatement.doseInstruction[0].doseQuantity.unit.Replace("gram(s)", "g")},

                    flags = new Flags{
                        frequency = string.Format("{0} {1}",
                        input_BNF_ertapenem.drugs[0].indicationsDose.indicationAndDoseGroups[0].routesAndPatientGroups[0]
                        .patientGroups[0].doseStatement.doseInstruction[0].frequency.value.ToString(),
                        input_BNF_ertapenem.drugs[0].indicationsDose.indicationAndDoseGroups[0].routesAndPatientGroups[0]
                        .patientGroups[0].doseStatement.doseInstruction[0].frequency.unit)
                    } },


                new Dose {ageBand = new Ageband { ageLow = new Agelow{value = 13, unit = "year" } , ageHigh = new Agehigh{value = 17, unit = "year"}},
                quantity = new Quantity{ value = 1.0F, unit = "g"}, flags = new Flags{frequency="12" }} }
            .ToArray();


            Suggesteddose suggesteddose1 = new Suggesteddose();
            suggesteddose1.indications = input_BNF_ertapenem.drugs[0].indicationsDose.indicationAndDoseGroups[0].therapeuticIndications.Select(c => c.indication).ToArray();
            suggesteddose1.doseAdministrations = new List<Doseadministration>{
                new Doseadministration {
                    route = "Intravenous",
                    method = "Infusion",
                    doses = new List<Dose>{new Dose {
                        ageBand = new Ageband {
                            ageLow = new Agelow{value = 13, unit = "year" },
                            ageHigh = new Agehigh{value = 17, unit = "year"}},
                        quantity = new Quantity{ value = 1.0F, unit = "g"},
                        flags = new Flags{frequency="12" }},
                    new Dose {
                        ageBand = new Ageband {
                            ageLow = new Agelow{value = 13, unit = "year" },
                            ageHigh = new Agehigh{value = 17, unit = "year"}},
                        quantity = new Quantity{ value = 1.0F, unit = "g"},
                        flags = new Flags{frequency="12" }}
                    }.ToArray()}}.ToArray();


            Suggesteddose suggesteddose2 = new Suggesteddose();
            suggesteddose2.indications = input_BNF_ertapenem.drugs[0].indicationsDose.indicationAndDoseGroups[0].therapeuticIndications.Select(c => c.indication).ToArray();
            suggesteddose2.doseAdministrations = new List<Doseadministration>{
                new Doseadministration {
                    route = "Intravenous",
                    method = "Infusion",
                    doses = new List<Dose>{new Dose {
                        ageBand = new Ageband {
                            ageLow = new Agelow{value = 13, unit = "year" },
                            ageHigh = new Agehigh{value = 17, unit = "year"}},
                        quantity = new Quantity{ value = 1.0F, unit = "g"},
                        flags = new Flags{frequency="12" }}
                    }.ToArray()}}.ToArray();


            OutputBnfDrug outputBnfDrug = new OutputBnfDrug();
            Drug ertapenem = new Drug();
            outputBnfDrug.drugs = new List<Drug> { { ertapenem } }.ToArray();


            ertapenem.name = input_BNF_ertapenem.drugs[0].name;
            ertapenem.suggestedDose = new Suggesteddose[] { suggesteddose1, suggesteddose2 };


            OutputBnfDrug outputErtapenem = new OutputBnfDrug();
            outputErtapenem.drugs = new Drug[] { ertapenem };


            Console.WriteLine("- Using the JsonSerializer with the Indent settings on");

            JsonSerializer jsonSerializer = new JsonSerializer();
            jsonSerializer.Formatting = Formatting.Indented;

            using (StreamWriter sw = new StreamWriter(@"..\..\JSON\test.json"))
            {
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    jsonSerializer.Serialize(writer, outputBnfDrug);
                }
            }




            Console.WriteLine("Done");
            Console.ReadKey();

        }
    }
}
