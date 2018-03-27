using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace IfuControl

{   [XmlRoot()]
    public class validIntermediateExchanges
    {
        validIntermediateExchanges()
        { Materials = new List<intermediateExchange>(); }
        [XmlElement("intermediateExchange")]
        public List<intermediateExchange> Materials { get; set; }

        
    }

    public class intermediateExchange
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
        [XmlElement("classification")]
        public classification_Value classificationValue=new classification_Value(); 
    }

    public class classification_Value
    {
        [XmlElement("classificationValue"), DefaultValue("")]
        public string classValue;
        public string ClassValue
        {
            get
            {   
                if (classValue == null)
                {
                    return "";    
                }
                return classValue;
            }
            set { classValue = value; }
        }
    }
}
