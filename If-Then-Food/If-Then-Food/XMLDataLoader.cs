using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace IfThenFoodProgram
{
    class XMLDataLoader
    {
        static string rulesFilePath = "data.xml";

        static public void Serialize(KnowlegeBase kb)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(KnowlegeBase));
            using (FileStream fs = new FileStream(rulesFilePath, FileMode.Create))
            {
                formatter.Serialize(fs, kb);
            }
        }

        static public KnowlegeBase Deserialize()
        {
            KnowlegeBase result = null;
            XmlSerializer formatter = new XmlSerializer(typeof(KnowlegeBase));
            using (FileStream fs = new FileStream(rulesFilePath, FileMode.OpenOrCreate))
            {
                result = (KnowlegeBase)formatter.Deserialize(fs);
            }
            return result;
        }
    }
}