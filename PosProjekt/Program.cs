using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PosProjekt
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Podaj sciezke: ");
            string path = Console.ReadLine();

            XmlTextWriter writer = new XmlTextWriter("gpx_" + DateTime.Now.ToString("s").Replace(":", "_") + ".xml", Encoding.UTF8);
            writer.Formatting = Formatting.Indented;
            writer.WriteProcessingInstruction("xml", "version='1.0' encoding='UTF-8'");
            writer.WriteStartElement("gpx");
            writer.WriteAttributeString("version", "1.1");
            writer.WriteAttributeString("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
            writer.WriteAttributeString("xmlns", "http://www.topografix.com/GPX/1/1");
            writer.WriteAttributeString("xsi:schemaLocation", "http://www.topografix.com/GPX/1/1http://www.topografix.com/GPX/1/1/gpx.xsd");
            writer.WriteStartElement("trk");
            writer.WriteStartElement("trkseg");

            foreach (TrackPoint tp in GpsReader.getGpsInfo(path))
            {
                writer.WriteStartElement("trkpt");
                writer.WriteAttributeString("lat", tp.lat);
                writer.WriteAttributeString("lon", tp.lon);
                writer.WriteStartElement("time");
                writer.WriteString(tp.time);
                writer.WriteEndElement();
                writer.WriteStartElement("speed");
                writer.WriteString(tp.speed);
                writer.WriteEndElement();
                writer.WriteStartElement("course");
                writer.WriteString(tp.course);
                writer.WriteEndElement();
                writer.WriteStartElement("ele");
                writer.WriteString(tp.ele);
                writer.WriteEndElement();
                writer.WriteEndElement();
            }

            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.Flush();
            writer.Close();
        }
    }
}
