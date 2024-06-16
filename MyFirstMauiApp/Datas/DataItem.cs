using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstMauiApp.Datas
{
    public class DataItem
    {
        public string Item { get; set; } = "";
        public double Value { get; set; }

        public int VoteCount { get; set; } = 0;
    }
}
