using Microsoft.Maui.Controls.Shapes;
using Microsoft.Maui.Devices.Sensors;

using Syncfusion.Maui.Charts;
using Syncfusion.Maui.Core.Internals;
using System.Collections.ObjectModel;
using MyFirstMauiApp.Datas;
using System.ComponentModel;



namespace MyFirstMauiApp.Pages;
public partial class TestGyroscope : ContentPage
{
    private string[] datas;

    public TestGyroscope(string[] datas)
    {
        this.datas = datas;
        InitializeComponent();
        InitializeData();   
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        
        Accelerometer.Default.ReadingChanged += Accelerometer_ReadingChanged;

        Accelerometer.Default.Start(SensorSpeed.Game);
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();

        Accelerometer.Default.ReadingChanged -= Accelerometer_ReadingChanged;

        Accelerometer.Default.Stop();
    }

  
    void SelectIndex(float angle)
    {
        // Convertissez l'angle de la plage [-1, 1] à la plage [0, 6]
        int index = (int)Math.Round((angle + 1) * (datas.Length-1) / 2);
        index= (datas.Length - 1) - index;

        // Assurez-vous que l'index est dans la plage [0, 6]
        index = Math.Max(0, Math.Min((datas.Length - 1), index));

        // Définissez l'index explosé sur la série de graphiques circulaires
        pieSeries.ExplodeIndex = index;
        SelectedDay.Text =datas[index];
    }

    void Accelerometer_ReadingChanged(object sender, AccelerometerChangedEventArgs e)
    {

        //// Calcule la nouvelle position du point
        double newDotPosition = (-e.Reading.Acceleration.X + 1) / 2 * bar.Width;

        //// Interpole linéairement entre la position actuelle et la nouvelle position
        double lerpFactor = 0.1; // Facteur d'interpolation (entre 0 et 1)
        double dotPosition = lerp(dot.TranslationX + dot.Width / 2, newDotPosition, lerpFactor);

        //// Met à jour la position du point
        dot.TranslationX = dotPosition - dot.Width / 2;

        // Rayon du demi-cercle
        double radius = 200;

        // Calcule l'angle d'inclinaison en radians
        double inclination = e.Reading.Acceleration.X;
        double angle = Math.PI/2+inclination; // L'angle est décalé de 90 degrés pour que la flèche soit à la verticale lorsque l'inclinaison est nulle

        // Calcule la nouvelle position de la flèche
        double newX = radius * Math.Cos(angle);
        double newY = radius * Math.Sin(angle);

        // Interpole linéairement entre la position actuelle et la nouvelle position
        double dotX = lerp(arrow.TranslationX, newX, lerpFactor);
        double dotY = lerp(arrow.TranslationY, -newY*1.5, lerpFactor);

        // Met à jour la position de la flèche
        arrow.TranslationX = dotX;
        arrow.TranslationY = dotY+45;

        // Fonction d'interpolation linéaire
        double lerp(double a, double b, double t)
        {
            return a + t * (b - a);
        }
        arrow.Rotation=inclination*80*-1;
        // Met à jour le texte de l'angle
        angleLabel.Text = inclination.ToString("0.00");
        SelectIndex((float)inclination);
      
    }


    private void InitializeData()
    {
        // Liste des jours de la semaine
        ObservableCollection<DataItem> data = new();
        for (int i = 0; i < datas.Length; i++)
        {
            data.Add(new DataItem { Item = datas[i], Value = 1 });
        }
        DataViewItemChart.Items = data;
    }
}

