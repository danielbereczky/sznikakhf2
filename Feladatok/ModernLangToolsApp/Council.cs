using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernLangToolsApp
{
    public delegate void CouncilChangedDelegate(string message);
    public class Council
    {
        public event CouncilChangedDelegate CouncilChanged;
        List<Jedi> members;

        bool isJediLowValue(Jedi j){
            return j.MidiChlorianCount < 530;
        }
        public Council() {
            members = new List<Jedi>();
        }
        public void Add(Jedi j)
        {
            members.Add(j);
            CouncilChanged?.Invoke("New member added");
        }
        public void Remove(){
            members.RemoveAt(members.Count - 1);
            CouncilChanged?.Invoke("Member removed");
        }

        public List<Jedi> findLowValJedis()
        {
            return members.FindAll(isJediLowValue);
        }

        public List<Jedi> findUnderThousandMidiChlorian() {
            return members.FindAll(x => x.MidiChlorianCount < 1000);
        }
    }
}
