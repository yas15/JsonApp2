using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using ErtapenemJson.Models;

namespace ErtapenemJson
{
    class Program
    {
        static void Main(string[] args)
        {

            string jsonTextPath = @"..\..\JSON\input_BNF_ertapenem.json";

            string inputJson = File.ReadAllText(jsonTextPath);

            var input_BNF_ertapenem = JsonConvert.DeserializeObject<InputBnfDrug>(inputJson);

            Suggesteddose suggesteddose1 = new Suggesteddose();
            suggesteddose1.indications = input_BNF_ertapenem.drugs[0].indicationsDose.indicationAndDoseGroups[0].therapeuticIndications.Select(c => c.indication).ToArray();
            suggesteddose1.doseAdministrations = new List<Doseadministration>{
                new Doseadministration {
                    route = input_BNF_ertapenem.drugs[0].indicationsDose.indicationAndDoseGroups[0].routesAndPatientGroups[0].routesOfAdministration[0]
                    .routeOfAdministration.Replace("By intravenous infusion", "Intravenous"),
                    method = input_BNF_ertapenem.drugs[0].indicationsDose.indicationAndDoseGroups[0].routesAndPatientGroups[0]
                    .routesOfAdministration[0].routeOfAdministration.Replace("By intravenous infusion", "Infusion"),
                    doses = new List<Dose>{
                        new Dose {ageBand = new Ageband {
                            ageLow = new Agelow{
                                value = Int32.Parse(input_BNF_ertapenem.drugs[0].indicationsDose.indicationAndDoseGroups[0].routesAndPatientGroups[0].patientGroups[0].age.from),
                                unit = input_BNF_ertapenem.drugs[0].indicationsDose.indicationAndDoseGroups[0].routesAndPatientGroups[0].patientGroups[0].age.fromUnit.Replace("years", "year") } ,
                            ageHigh = new Agehigh{
                                value = Int32.Parse(input_BNF_ertapenem.drugs[0].indicationsDose.indicationAndDoseGroups[0].routesAndPatientGroups[0].patientGroups[0].age.to),
                                unit = input_BNF_ertapenem.drugs[0].indicationsDose.indicationAndDoseGroups[0].routesAndPatientGroups[0].patientGroups[0].age.toUnit.Replace("years", "year")}},
                            quantity = new Quantity{
                                value = Int32.Parse(input_BNF_ertapenem.drugs[0].indicationsDose.indicationAndDoseGroups[0].routesAndPatientGroups[0]
                                .patientGroups[0].doseStatement.doseInstruction[0].doseQuantity.value),
                                unit = input_BNF_ertapenem.drugs[0].indicationsDose.indicationAndDoseGroups[0].routesAndPatientGroups[0]
                                .patientGroups[0].doseStatement.doseInstruction[0].doseQuantity.unit.Replace("gram(s)", "g")},
                            flags = new Flags{
                                frequency = string.Format("{0} {1}",input_BNF_ertapenem.drugs[0].indicationsDose.indicationAndDoseGroups[0].routesAndPatientGroups[0]
                                .patientGroups[0].doseStatement.doseInstruction[0].frequency.value.ToString(),
                                input_BNF_ertapenem.drugs[0].indicationsDose.indicationAndDoseGroups[0].routesAndPatientGroups[0]
                                .patientGroups[0].doseStatement.doseInstruction[0].frequency.unit) }
                        },
                        new Dose {ageBand = new Ageband {
                            ageLow = new Agelow{
                                value = Int32.Parse(input_BNF_ertapenem.drugs[0].indicationsDose.indicationAndDoseGroups[0].routesAndPatientGroups[0].patientGroups[1].age.from),
                                unit = input_BNF_ertapenem.drugs[0].indicationsDose.indicationAndDoseGroups[0].routesAndPatientGroups[0].patientGroups[1].age.fromUnit.Replace("years", "year") } ,
                            ageHigh = new Agehigh{
                                value = Int32.Parse(input_BNF_ertapenem.drugs[0].indicationsDose.indicationAndDoseGroups[0].routesAndPatientGroups[0].patientGroups[1].age.to),
                                unit = input_BNF_ertapenem.drugs[0].indicationsDose.indicationAndDoseGroups[0].routesAndPatientGroups[0].patientGroups[1].age.toUnit.Replace("years", "year")}},
                            quantity = new Quantity{
                                value = Int32.Parse(input_BNF_ertapenem.drugs[0].indicationsDose.indicationAndDoseGroups[0].routesAndPatientGroups[0].patientGroups[1]
                                .doseStatement.doseInstruction[0].doseQuantity.value),
                                unit = input_BNF_ertapenem.drugs[0].indicationsDose.indicationAndDoseGroups[0].routesAndPatientGroups[0].patientGroups[1]
                                .doseStatement.doseInstruction[0].doseQuantity.unit.Replace("mg(s)/kilogram", "mg/kg")},
                            flags = new Flags{
                                frequency = string.Format("{0} {1} {2}",
                                input_BNF_ertapenem.drugs[0].indicationsDose.indicationAndDoseGroups[0].routesAndPatientGroups[0].patientGroups[1]
                                .doseStatement.doseInstruction[0].frequency.frequencyType,
                                input_BNF_ertapenem.drugs[0].indicationsDose.indicationAndDoseGroups[0].routesAndPatientGroups[0].patientGroups[1]
                                .doseStatement.doseInstruction[0].frequency.value.ToString(),
                                input_BNF_ertapenem.drugs[0].indicationsDose.indicationAndDoseGroups[0].routesAndPatientGroups[0].patientGroups[1]
                                .doseStatement.doseInstruction[0].frequency.unit)
                            } }
                    }.ToArray()}}.ToArray();


            Suggesteddose suggesteddose2 = new Suggesteddose();
            suggesteddose2.indications = input_BNF_ertapenem.drugs[0].indicationsDose.indicationAndDoseGroups[1].therapeuticIndications.Select(c => c.indication).ToArray();
            suggesteddose2.doseAdministrations = new List<Doseadministration>{
                new Doseadministration {
                    route = input_BNF_ertapenem.drugs[0].indicationsDose.indicationAndDoseGroups[1].routesAndPatientGroups[0].routesOfAdministration[0]
                    .routeOfAdministration.Replace("By intravenous infusion", "Intravenous"),
                    method = input_BNF_ertapenem.drugs[0].indicationsDose.indicationAndDoseGroups[1].routesAndPatientGroups[0]
                    .routesOfAdministration[0].routeOfAdministration.Replace("By intravenous infusion", "Infusion"),
                    doses = new List<Dose>{new Dose {
                        ageBand = new Ageband {
                            ageLow = new Agelow{
                                value = Int32.Parse(input_BNF_ertapenem.drugs[0].indicationsDose.indicationAndDoseGroups[1].routesAndPatientGroups[0].patientGroups[0].age.from),
                                unit = input_BNF_ertapenem.drugs[0].indicationsDose.indicationAndDoseGroups[0].routesAndPatientGroups[0].patientGroups[0].age.fromUnit.Replace("years", "year")},
                            ageHigh = new Agehigh{
                                value = Int32.Parse(input_BNF_ertapenem.drugs[0].indicationsDose.indicationAndDoseGroups[1].routesAndPatientGroups[0].patientGroups[0].age.to),
                                unit = input_BNF_ertapenem.drugs[0].indicationsDose.indicationAndDoseGroups[0].routesAndPatientGroups[0].patientGroups[0].age.toUnit.Replace("years", "year")}},
                            quantity = new Quantity{
                                value = Int32.Parse(input_BNF_ertapenem.drugs[0].indicationsDose.indicationAndDoseGroups[1].routesAndPatientGroups[0]
                                .patientGroups[0].doseStatement.doseInstruction[0].doseQuantity.value),
                                unit = input_BNF_ertapenem.drugs[0].indicationsDose.indicationAndDoseGroups[1].routesAndPatientGroups[0]
                                .patientGroups[0].doseStatement.doseInstruction[0].doseQuantity.unit.Replace("gram(s)", "g")},
                            flags = new Flags{
                                frequency = string.Format("{0} {1}",input_BNF_ertapenem.drugs[0].indicationsDose.indicationAndDoseGroups[1].routesAndPatientGroups[0]
                                .patientGroups[0].doseStatement.doseInstruction[0].frequency.value.ToString(),
                                input_BNF_ertapenem.drugs[0].indicationsDose.indicationAndDoseGroups[1].routesAndPatientGroups[0]
                                .patientGroups[0].doseStatement.doseInstruction[0].frequency.unit) } }
                    }.ToArray()}}.ToArray();


            OutputBnfDrug outputBnfDrug = new OutputBnfDrug();
            Drug ertapenem = new Drug();
            outputBnfDrug.drugs = new List<Drug> { { ertapenem } }.ToArray();


            ertapenem.name = input_BNF_ertapenem.drugs[0].name;
            ertapenem.suggestedDose = new Suggesteddose[] { suggesteddose1, suggesteddose2 };


            OutputBnfDrug outputErtapenem = new OutputBnfDrug();
            outputErtapenem.drugs = new Drug[] { ertapenem };


            JsonSerializer jsonSerializer = new JsonSerializer();
            jsonSerializer.Formatting = Formatting.Indented;


            using (StreamWriter sw = new StreamWriter(@"..\..\JSON\output.json"))
            {
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    jsonSerializer.Serialize(writer, outputBnfDrug);
                }
            }


            Console.WriteLine(string.Format("Check folder {0}{1} for the output JSON file.", Path.GetFullPath(@"..\..\"), "JSON"));
            Console.WriteLine("Done");
            Console.ReadKey();

        }
    }
}
