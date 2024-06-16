using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstMauiApp.Datas
{
    public class DataManager
    {
        public static DataManager Instance { get; private set; }

        public ObservableCollection<DataItem> dataDay { get; set; }
        public ObservableCollection<DataItem> dataHour { get; set; }

        public static DataManager GetInstance()
        {
            if (Instance == null)
            {
                Instance = new DataManager();
                Instance.dataDay = new();
                Instance.dataHour = new();
            }

            return Instance;
        }

    }

    
}
