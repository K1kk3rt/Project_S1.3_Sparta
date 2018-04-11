using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta.Dal
{
    public static class DALProgramma
    {       
        public static List<string> GetTestLijst()
        {
            List<string> TestLijst = new List<string>();

            string naam1 = "Eugenie Heijn";
            string naam2 = "Tim van Vliet";
            string naam3 = "Job Vermeulen";

            TestLijst.Add(naam1);
            TestLijst.Add(naam2);
            TestLijst.Add(naam3);

            return TestLijst;
        }        
    }          
}
