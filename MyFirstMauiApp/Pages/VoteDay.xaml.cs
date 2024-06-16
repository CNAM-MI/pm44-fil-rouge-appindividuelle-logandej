using MyFirstMauiApp.Datas;
using MyFirstMauiApp.Views;

namespace MyFirstMauiApp.Pages;

public partial class VoteDay : ContentPage
{
    SelectDataView selectDayView;
	public VoteDay()
	{
		InitializeComponent();
        string[] datas = { "Lundi", "Mardi", "Mercredi", "Jeudi", "Vendredi", "Samedi", "Dimanche" };
        selectDayView = new SelectDataView(datas, DataManager.GetInstance().dataDay);
        // Ajoutez le ContentView au ContentPage
        selectDataView.Content = selectDayView;
    }


    private void OnVoteButtonClicked(object sender, EventArgs e)
    {
        // Navigue vers la nouvelle page avec le nom du sondage
        //await Navigation.PushAsync(new VoteHour());
        selectDayView.VoteIndex();
        Navigation.PopAsync();

    }
}