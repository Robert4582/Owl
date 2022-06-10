using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Owl_V2
{
    public interface DBOperation
    {
        public void Connect() { }

        public void FindAllData() { }

        public void FindDataByFilterAndInt() { }

        public void FindDataByFilterAndSting() { }

        public void InsetData() { }
    }
}
