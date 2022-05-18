using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;

namespace Owl
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
