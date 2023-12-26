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
    public partial class EditWheelPage : ContentPage
    {
        public ObservableCollection<Type> Types { get; set; }
        public Wheel Wheel1 { get; set; }
        public Type Type { get; set; }
        public DB DB { get; set; }
        public EditWheelPage(Wheel wheel, DB db)
        {
            InitializeComponent();
            Wheel1 = wheel;
            DB = db;
            Types = db.GetTypes();
            Type = Types.FirstOrDefault(s => s.ID == Wheel1.IDType);
            BindingContext = this;
        }

        
        private void SaveWheel(object sender, EventArgs e)
        {
            if (Wheel1.ID != 0)
            {
                Type = Types.FirstOrDefault(s => s.ID == Wheel1.IDType);
            }

            if (string.IsNullOrEmpty(Wheel1.Name) || string.IsNullOrEmpty(Wheel1.Info) || Type.Name == string.Empty)
                DisplayAlert("Ошибка", "Не все поля заполнены", "ОК");
            else
            {
                Wheel1.IDType = Type.ID;
                DB.EditWheel(Wheel1);
                Navigation.PopModalAsync();
            }
        }

        private void Cancel(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}