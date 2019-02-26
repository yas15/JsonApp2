using System;

namespace ErtapenemJson.Models
{

    public class OutputBnfDrug
    {
        public Drug[] drugs { get; set; }
    }

    public class Drug
    {
        public string name { get; set; }
        public Suggesteddose[] suggestedDose { get; set; }
    }

    public class Suggesteddose
    {
        public string[] indications { get; set; }
        public Doseadministration[] doseAdministrations { get; set; }
    }

    public class Doseadministration
    {
        public string route { get; set; }
        public string method { get; set; }
        public Dose[] doses { get; set; }
    }

    public class Dose
    {
        public Ageband ageBand { get; set; }
        public Quantity quantity { get; set; }
        public Flags flags { get; set; }
    }

    public class Ageband
    {
        public Agelow ageLow { get; set; }
        public Agehigh ageHigh { get; set; }
    }

    public class Agelow
    {
        public int value { get; set; }
        public string unit { get; set; }
    }

    public class Agehigh
    {
        public int value { get; set; }
        public string unit { get; set; }
    }

    public class Quantity
    {
        public int value { get; set; }
        public string unit { get; set; }
    }

    public class Flags
    {
        public string frequency { get; set; }
    }

}
