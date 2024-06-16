using MyFirstMauiApp.Datas;
using MyFirstMauiApp.Views;
namespace MyFirstMauiApp.Pages;

public partial class VoteHour : ContentPage
{
    SelectDataView selectHourView;
    public VoteHour()
	{
        InitializeComponent();
        string[] datas = { "12h", "13h", "14h", "15h", "16h", "17h", "18h", "19h", "20h", "21h", "22h", "23h" };
        selectHourView = new SelectDataView(datas, DataManager.GetInstance().dataHour);
        // Ajoutez le ContentView au ContentPage
        selectDataView.Content = selectHourView;
    }

    private void OnVoteButtonClicked(object sender, EventArgs e)
    {
        // Navigue vers la nouvelle page avec le nom du sondage
        //await Navigation.PushAsync(new VoteHour());
        selectHourView.VoteIndex();
        Navigation.PopAsync();

    }
}