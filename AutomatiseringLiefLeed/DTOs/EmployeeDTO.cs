using System.Xml.Serialization;

namespace AutomatiseringLiefLeed.DTOs
{
    [XmlRoot("AfasGetConnector")]
    public class AfasGetConnector
    {
        [XmlElement("LiefenLeed")]
        public List<EmployeeDto>? Employees { get; set; }
    }

    public class EmployeeDto
    {
        public string? Medewerker { get; set; }
        public string? Roepnaam { get; set; }
        public string? Voorvoegsel { get; set; }
        public string? Achternaam { get; set; }

        [XmlElement("E-mail_werk")]
        public string? EmailWerk { get; set; }

        [XmlElement("Geboortedatum")]
        public DateTime? GeboorteDatum { get; set; }

        [XmlElement("AOW-datum")]
        public DateTime? AOWDatum { get; set; }

        [XmlElement("In_dienst_ivm_dienstjaren")]
        public DateTime? InDienstIVMDienstJaren { get; set; }
    }
}
