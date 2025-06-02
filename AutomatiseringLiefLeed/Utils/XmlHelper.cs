using System.Xml.Serialization;
using AutomatiseringLiefLeed.DTOs;

namespace AutomatiseringLiefLeed.Utils
{
    public class XmlHelper
    {
        public static AfasGetConnector DeserialiseEmployees(string xml)
        {
            //try to deserialise xml file
            try
            {
                var serialiser = new XmlSerializer(typeof(AfasGetConnector));
                using var reader = new StringReader(xml);
                return (AfasGetConnector)serialiser.Deserialize(reader);
            }

            //return error message if it fails to deserialise
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
    }
}
