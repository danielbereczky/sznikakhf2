using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ModernLangToolsApp
{
    [Serializable]
    public class Jedi
    {        
        int midiChlorianCount;
        [XmlAttribute("nev")]
        public string Name { get; set; }
        [XmlAttribute("midichlorianSzam")]
        public int MidiChlorianCount {
            get {
                return midiChlorianCount;
            }
            set {
                if (value <= 35) {
                    throw new ArgumentException("You are not a true jedi!");
                }
                midiChlorianCount = value;
            }
        }
    }
}
