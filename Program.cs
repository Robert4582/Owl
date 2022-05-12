using System;

namespace Owl
{
    class Program
    {
        static void Main(string[] args)
        {
            //DBWriteOperation db = new DBWriteOperation();

            DBReadOperation db = new DBReadOperation();

            db.Connect();
        }
    }
}
