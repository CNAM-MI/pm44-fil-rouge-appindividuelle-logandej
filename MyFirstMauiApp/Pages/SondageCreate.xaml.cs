using MyFirstMauiApp.Datas;

namespace MyFirstMauiApp.Pages;
public partial class SondageCreate : ContentPage
{
    public string Titre { get; }
    private int currentStep = 1;
    private SondageHome sondageHome;

    private readonly Dictionary<int, string> dayTimeOptionsDictionary = new Dictionary<int, string>
    {
        { 1, "1min" },
        { 15, "15 min" },
        { 30, "30 min" },
        { 60, "1h" },
        { 120, "2h" },
        { 300, "5h" }
    };

    private readonly Dictionary<int, string> hourTimeOptionsDictionary = new Dictionary<int, string>
    {
        { 1, "1 min" },
        { 5, "5 min" },
        { 10, "10 min" },
        { 30, "30min" },
        { 60, "1h" },
        { 120, "2h" }
    };
  

    private Datas.TimePicker dayTimePicker;
    private Datas.TimePicker hourTimePicker;


    public SondageCreate(string nomSondage, SondageHome sondageHome)
    {
        Titre = nomSondage;
        InitializeComponent();
        dayTimePicker = new Datas.TimePicker(0, dayTimeOptionsDictionary,minusButton1,plusButton1,timeEntry1);
     

        hourTimePicker = new Datas.TimePicker(0, hourTimeOptionsDictionary,minusButton2,plusButton2,timeEntry2);

        TitleText.Text = "Création du sondage : "+Titre;
        this.sondageHome = sondageHome;
        
    }
 

    private async void OnCancelButtonClicked(object sender, EventArgs e)
    {
        bool result = await DisplayAlert("Annuler le sondage", "Êtes-vous sûr de vouloir annuler le sondage ?", "Oui", "Non");

        if (result)
        {
            await Navigation.PopAsync();
        }
    }




    private void OnNextClicked(object sender, EventArgs e)
    {
        if (currentStep < 3)
        {
            currentStep++;
            UpdateStepVisibility();

            if(currentStep == 3)
            {
                TitleSondageReminder.Text = Titre;
                TimeDayReminder.Text = dayTimePicker.GetTimeDisplay().ToString();
                TimeHourReminder.Text = hourTimePicker.GetTimeDisplay().ToString();
            }
        }
    }

    private void OnPreviousClicked(object sender, EventArgs e)
    {
        if (currentStep > 1)
        {
            currentStep--;
            UpdateStepVisibility();
        }
    }

    private void UpdateStepVisibility()
    {
        step1Layout.IsVisible = currentStep == 1;
        step2Layout.IsVisible = currentStep == 2;
        step3Layout.IsVisible = currentStep == 3;

        previousButton.IsEnabled = currentStep > 1;
        nextButton.IsEnabled = currentStep < 3;
    }

    private void OnSaveButtonClicked(object sender, EventArgs e)
    {
        // Créer le sondage
        Sondage newSondage = new Sondage(Titre, dayTimePicker.GetTimeValue(), hourTimePicker.GetTimeValue());

        // Appeler la fonction AddSondage de SondageHome avec le nouveau sondage
        sondageHome.AddSondage(newSondage);

        // Retourner à SondageHome ou effectuer toute autre action nécessaire
        Navigation.PopAsync();
    }


}