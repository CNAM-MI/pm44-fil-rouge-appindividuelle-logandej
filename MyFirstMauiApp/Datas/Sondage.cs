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

        //public Frame DiplaySondage()
        //{
        //    Label titleLabel = new Label
        //    {
        //        Text = TitleSondage,
        //        HorizontalOptions = LayoutOptions.Center
        //    };

        //    Label timerDayLabel = new Label
        //    {
        //        Text = TimerDay.ToString(),
        //        HorizontalOptions = LayoutOptions.Center
        //    };
        //    Label timerHourLabel = new Label
        //    {
        //        Text = TimerHour.ToString(),
        //        HorizontalOptions = LayoutOptions.Center
        //    };

        //    StackLayout stackLayout = new StackLayout
        //    {
        //        Children = { titleLabel, timerDayLabel, timerHourLabel },
        //        VerticalOptions = LayoutOptions.CenterAndExpand,
        //        HorizontalOptions = LayoutOptions.CenterAndExpand
        //    };

        //    Frame frame = new Frame
        //    {
        //        Content = stackLayout,
        //        Padding = new Thickness(20),

        //        CornerRadius = 10
        //    };

        //    return frame;
        //}
    }
}
