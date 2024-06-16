namespace MyFirstMauiApp.Pages;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
	}


	public void CreateVote(object sender, EventArgs e)
	{
		CreateVoteButton.Text = "Clicked";

		DisplayAlert("Display Alrer", "Message bozo ", "Annuler", FlowDirection.LeftToRight);
	}
}