using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;

namespace Owl
{
    public abstract class DBOperation
    {
        public abstract void Connect();
    }
}
