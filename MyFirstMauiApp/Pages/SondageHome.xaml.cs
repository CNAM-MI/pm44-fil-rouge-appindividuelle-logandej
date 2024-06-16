using MyFirstMauiApp.Datas;
using System.Timers;

namespace MyFirstMauiApp.Pages;

public partial class SondageHome : ContentPage
{
    private Sondage currentSondage;
    private DateTime _targetDateTime;

    private System.Timers.Timer _timer;
    private TimeSpan _updateInterval = TimeSpan.FromSeconds(1);
    private int _counter = 0;

    private int stepCounter=0;

    public SondageHome()
	{
		InitializeComponent();
        if(currentSondage == null)
        {
            AddSondageLayout.IsVisible = true;
        }
        
       
	}



 
    private async void OnPopupButtonClicked(object sender, EventArgs e)
    {
        string nomSondage = await DisplayPromptAsync("Créer un nouveau sondage", "Nom du sondage", "Valider", "Annuler");
        if (nomSondage != null)
        {
            // Navigue vers la nouvelle page avec le nom du sondage
            await Navigation.PushAsync(new SondageCreate(nomSondage,this));
        }
    }

    private async void OnProfileButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new LoginPage());
    }

    public void AddSondage(Sondage sondage)
    {
        currentSondage=sondage ?? throw new ArgumentNullException(nameof(sondage));
        AddSondageLayout.IsVisible=false;
        SondageLayout.IsVisible = true;
        TitleSondage.Text = currentSondage.TitleSondage;
        //TimeDay.Text = currentSondage.TimerDay.ToString();
        //TimeHour.Text = currentSondage.TimerHour.ToString();

        //DisplayLayout.AddLogicalChild(currentSondage.DiplaySondage());

        BeginDay();
        
    }

    private void OnTimerElapsed(object sender, ElapsedEventArgs e)
    {
        
        Device.BeginInvokeOnMainThread(UpdateCountdownLabel);
    }

    private void BeginDay()
    {
        _targetDateTime = DateTime.Now.AddMinutes(currentSondage.TimerDay);

        _timer = new System.Timers.Timer((int)_updateInterval.TotalMilliseconds);
        _timer.Elapsed += OnTimerElapsed;
        _timer.AutoReset = true;
        _timer.Enabled = true;
        UpdateCountdownLabel();

    }

    private void BeginHour()
    {
        _targetDateTime = DateTime.Now.AddMinutes(currentSondage.TimerHour);

        _timer = new System.Timers.Timer((int)_updateInterval.TotalMilliseconds);
        _timer.Elapsed += OnTimerElapsed;
        _timer.AutoReset = true;
        _timer.Enabled = true;
        UpdateCountdownLabel();
    }

    private void UpdateCountdownLabel()
    {
        TimeSpan timeToTarget = _targetDateTime - DateTime.Now;
        if (timeToTarget > TimeSpan.Zero)
        {
            countdownLabel.Text = $"Temps restant : {timeToTarget.Hours} heures, {timeToTarget.Minutes} minutes, {timeToTarget.Seconds} secondes";
        }
        else
        {
            stepCounter++;
            if (stepCounter == 1)
            {
                BeginHour();
            }
            else
            {
                VoteSondageButton.IsVisible = false;
            }
            _timer.Enabled = false;
            countdownLabel.Text = "Temps écoulé";
        }
    }


    private async void OnVoteButtonClicked(object sender, EventArgs e)
    {
        if (stepCounter == 0)
        {
            await Navigation.PushAsync(new VoteDay());
        }
        else if(stepCounter == 1)
        {
            await Navigation.PushAsync(new VoteHour());
        }
        // Navigue vers la nouvelle page avec le nom du sondage

    }


}