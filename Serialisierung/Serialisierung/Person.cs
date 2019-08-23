using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Serialisierung
{
    //[Serializable]
    //[XmlRoot("DasPersonenObjekt")]
    public class Person
    {
        //[XmlAttribute("DerVorname")]
        //[JsonProperty("vorname")]
        public string Vorname { get; set; }
        //[XmlAttribute("DerNachname")]
        public string Nachname { get; set; }
        public byte Alter { get; set; }
        // [field: NonSerialized]
        decimal Kontostand { get; set; }
    }
}
