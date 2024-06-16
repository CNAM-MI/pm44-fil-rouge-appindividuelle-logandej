using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstMauiApp.Datas
{
    public class TimePicker
    {
        private int currentIndex;
        private readonly Dictionary<int, string> timeOptionsDictionary;

        public Button MinusButton { get; private set; }
        public Button PlusButton { get; private set; }
        public Entry TimeEntry { get; private set; }


        public TimePicker(int initialIndex, Dictionary<int, string> timeOptions, Button minusButton, Button plusButton, Entry timeEntry)
        {
            currentIndex = initialIndex;
            timeOptionsDictionary = timeOptions;
            MinusButton = minusButton;
            PlusButton = plusButton;
            TimeEntry = timeEntry;

            MinusButton.Clicked += OnMinusButtonClicked;
            PlusButton.Clicked += OnPlusButtonClicked;

            TimeEntry.Text = GetTimeDisplay();
            UpdateVisibility();
        }

        private void OnMinusButtonClicked(object sender, EventArgs e)
        {
            currentIndex--;
            if (currentIndex < 0)
            {
                currentIndex = 0;
            }

            TimeEntry.Text = GetTimeDisplay();
            UpdateVisibility();

        }

        private void OnPlusButtonClicked(object sender, EventArgs e)
        {
            currentIndex++;
            if (currentIndex > timeOptionsDictionary.Count - 1)
            {
                currentIndex = timeOptionsDictionary.Count - 1;
            }

            TimeEntry.Text = GetTimeDisplay();
            UpdateVisibility();

        }
        public void UpdateVisibility()
        {
           
            MinusButton.IsEnabled = currentIndex > 0;
            PlusButton.IsEnabled = currentIndex < timeOptionsDictionary.Count - 1;
            
        }
        public string GetTimeDisplay()
        {
            if (currentIndex >= 0 && currentIndex < timeOptionsDictionary.Count)
            {
                var timeValue = timeOptionsDictionary.ElementAt(currentIndex).Key;
                return timeOptionsDictionary[timeValue];
            }
            else
            {
                return "0";
            }
        }

        public int GetTimeValue()
        {
            if (currentIndex >= 0 && currentIndex < timeOptionsDictionary.Count)
            {
                int timeValue = timeOptionsDictionary.ElementAt(currentIndex).Key;
                return timeValue;
            }
            else
            {
                return 0;
            }
        }
    }
}
