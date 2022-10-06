using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PovarenokApp.Data.Enum;

namespace PovarenokApp.Data
{
    public class TableCounterEntity
    {
        public int id;
        public int counter;

        public int GetNext()
        {
            counter++;
            return counter - 1;
        }
    }
}
