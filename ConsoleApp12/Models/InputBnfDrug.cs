using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErtapenemJson.Models
{

    public class InputBnfDrug
    {
        public InputDrug[] drugs { get; set; }
    }

    public class InputDrug
    {
        public string name { get; set; }
        public Indicationsdose indicationsDose { get; set; }
    }

    public class Indicationsdose
    {
        public string potName { get; set; }
        public Indicationanddosegroup[] indicationAndDoseGroups { get; set; }
    }

    public class Indicationanddosegroup
    {
        public Therapeuticindication[] therapeuticIndications { get; set; }
        public Routesandpatientgroup[] routesAndPatientGroups { get; set; }
    }

    public class Therapeuticindication
    {
        public string indication { get; set; }
    }

    public class Routesandpatientgroup
    {
        public Routesofadministration[] routesOfAdministration { get; set; }
        public Patientgroup[] patientGroups { get; set; }
    }

    public class Routesofadministration
    {
        public string routeOfAdministration { get; set; }
        public string routeForm { get; set; }
    }

    public class Patientgroup
    {
        public Age age { get; set; }
        public Dosestatement doseStatement { get; set; }
    }

    public class Age
    {
        public string from { get; set; }
        public string fromUnit { get; set; }
        public string to { get; set; }
        public string toUnit { get; set; }
        public string levelOfSupervision { get; set; }
    }

    public class Dosestatement
    {
        public Doseinstruction[] doseInstruction { get; set; }
    }

    public class Doseinstruction
    {
        public string doseType { get; set; }
        public Dosequantity doseQuantity { get; set; }
        public Frequency frequency { get; set; }
        public string emergency { get; set; }
    }

    public class Dosequantity
    {
        public string value { get; set; }
        public string frequencyType { get; set; }
        public string unit { get; set; }
        public string siType { get; set; }
        public string name { get; set; }
    }

    public class Frequency
    {
        public string value { get; set; }
        public string frequencyType { get; set; }
        public string unit { get; set; }
        public string siType { get; set; }
        public string name { get; set; }
    }

}
