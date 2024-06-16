using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstMauiApp.Datas
{
    public class Sondage
    {
        public string TitleSondage { private set; get; } = "";
        public int TimerDay { private set; get; } = 0;
        public int TimerHour { private set; get; } = 0;

        public Sondage(string title, int timerDay, int timerHour)
        {
            TitleSondage = title;
            TimerDay = timerDay;
            TimerHour = timerHour;
        }
    }
}
