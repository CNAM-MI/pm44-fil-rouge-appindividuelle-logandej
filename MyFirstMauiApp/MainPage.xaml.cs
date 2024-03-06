using System.Numerics;

namespace MyFirstMauiApp
{
    public partial class MainPage : ContentPage
    {
        BigInteger count = 0;

        public MainPage()
        {
            InitializeComponent();
            ChangeName("Je fais du Java");
        }

        private void ChangeName(string name)
        {
            LabelName.Text = name;
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            if(count == 0)
            {
                count++;
            }
            else
            {
                count *= 2;
            }

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }

}
