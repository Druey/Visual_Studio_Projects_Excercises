using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace IfuControl
{
    [XmlRoot("validElementaryExchanges")]
    public class Exchanges
    {
        public Exchanges()
        {
            Materials = new List<elementaryExchange>();
        }

        [XmlElement("elementaryExchange")]
        public List<elementaryExchange> Materials { get; set; }
        
    }
    
    public class elementaryExchange
    {
        [XmlElement()]
        public string name, unitName;
        public string Name
        {
            get
            {
                if (name == null)
                {
                    return "";
                }
                return name;
            }
            set { name = value; }
        }
        public string UnitName
        {
            get
            {
                if (unitName == null)
                {
                    return "";
                }
                return unitName;
            }
            set { unitName = value; }
        }

        [XmlElement("compartment")]
        public compartments classificationCompartment=new compartments();
        public compartments Classification_Compartment
        {
            get { return classificationCompartment; }
            set { }
        }

    }


    public class compartments
    {
        [XmlElement("compartment")]
        public string compartment;
        [XmlElement()]
        public string subcompartment;
        public string Compartment
        {
            get
            {
                if (compartment == null)
                {
                    return "";
                }
                return compartment;
            }
            set { compartment = value; }
        }
        public string Subcompartment
        {
            get
            {
                if (subcompartment == null)
                {
                    return "";
                }
                return subcompartment;
            }
            set { subcompartment = value; }
        }
    }
    
    

}
