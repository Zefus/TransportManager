using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;

namespace testProject
{
    [Export(typeof(ItestClass))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class testClass : ItestClass
    {
        public string get()
        {
            return "Hello MEF";
        }
    }
}
