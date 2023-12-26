using carshop;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace carshop
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditPage : ContentPage
    {
        public ObservableCollection<Wheel> Wheels { get; set; }
        public ObservableCollection<Type> Types { get; set; }

        public Wheel Wheel { get; set; }
        public Type Type { get; set; }
        public Car Car1 { get; set; }
        public DB DB { get; set; }
        public EditPage(Car car, DB db)
        {
            InitializeComponent();
            Car1 = car;
            DB = db;
            Wheels = db.GetWheels();
            Types = db.GetTypes();
            Wheel = Wheels.FirstOrDefault(s => s.ID == Car1.IDWheel);
            Type = Types.FirstOrDefault(s => s.ID == Car1.IDType);
            BindingContext = this;
        }

        public void SaveCar(object sender, EventArgs e)
        {
            if (Car1.ID != 0)
            {
                Wheel = Wheels.FirstOrDefault(s => s.ID == Car1.IDWheel);
                Type = Types.FirstOrDefault(s => s.ID == Car1.IDType);
            }

            if (string.IsNullOrWhiteSpace(Car1.Name) || string.IsNullOrWhiteSpace(Car1.Info))
                DisplayAlert("Ошибка", "Не все поля заполнены", "ОК");
            else
            {
                Car1.IDWheel = Wheel.ID;
                Car1.IDType = Type.ID;
                DB.EditCar(Car1);
                Navigation.PopModalAsync();
            }
        }
        public void Cancel(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

    }
}