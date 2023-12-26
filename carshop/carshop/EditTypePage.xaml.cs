using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace carshop
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditTypePage : ContentPage
    {
        public Type Type1 { get; set; }
        public DB DB { get; set; }
        public EditTypePage(Type type, DB db)
        {
            InitializeComponent();
            Type1 = type;
            DB = db;
            BindingContext = this;
        }

        
        private void SaveType(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Type1.Name))
                DisplayAlert("Ошибка", "Не все поля заполнены", "ОК");
            else
            {
                DB.EditType(Type1);
                Navigation.PopModalAsync();
            }
        }

        private void Cancel(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}