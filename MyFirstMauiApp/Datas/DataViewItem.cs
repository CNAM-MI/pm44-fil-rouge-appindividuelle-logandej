using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstMauiApp.Datas
{
    public class DataViewItem : INotifyPropertyChanged
    {
        private ObservableCollection<DataItem> items;
        public ObservableCollection<DataItem> Items
        {
            get => items;
            set
            {
                if (items != value)
                {
                    items = value;
                    OnPropertyChanged(nameof(Items));
                }
            }
        }
        public List<Brush> CustomBrushes { get; set; }


        public DataViewItem()
        {
            //AddBrushesToList(1);
            //AddBrushesToList(1);
            //AddBrushesToList(2);
            //AddBrushesToList(4);
            //AddBrushesToList(3);
            //AddBrushesToList(1);
            //AddBrushesToList(1);

            Items = new ObservableCollection<DataItem>();

            CustomBrushes = new List<Brush>();

   

                //,
                //new SolidColorBrush(Color.FromRgb(197, 223, 248)),
                //new SolidColorBrush(Color.FromRgb(160, 191, 224)),
                //new SolidColorBrush(Color.FromRgb(120, 149, 203)),
                //new SolidColorBrush(Color.FromRgb(74, 85, 162)),
                //new SolidColorBrush(Color.FromRgb(197, 223, 248)),
                //new SolidColorBrush(Color.FromRgb(197, 223, 248)),


        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void AddBrushesToList(int input)
        {
            switch (input)
            {
                case 0:
                    CustomBrushes.Add(new SolidColorBrush(Color.FromRgb(197, 223, 248)));
                    break;
                case 1:
                    CustomBrushes.Add(new SolidColorBrush(Color.FromRgb(160, 191, 224)));
                    break;
                case 2:
                    CustomBrushes.Add(new SolidColorBrush(Color.FromRgb(120, 149, 203)));
                    break;
                case 3:
                    CustomBrushes.Add(new SolidColorBrush(Color.FromRgb(74, 85, 162)));
                    break;
                default:
                    Console.WriteLine("Valeur d'entrée invalide");
                    break;
            }
        }


        public void UpdateCount()
        {
            foreach (var item in Items)
            {
                AddBrushesToList(item.VoteCount);
            }
        }


    }
}
