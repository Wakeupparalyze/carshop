using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace carshop
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        private ObservableCollection<Car> carList;
        private ObservableCollection<Wheel> wheelList;
        private ObservableCollection<Type> typeList;
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Car> CarList { get => carList; set { carList = value; SignalChanged(); } }
        public Car SelectedCar { get; set; }
        public ObservableCollection<Wheel> WheelList { get => wheelList; set { wheelList = value; SignalChanged(); } }
        public Wheel SelectedWheel { get; set; }
        public ObservableCollection<Type> TypeList { get => typeList; set { typeList = value; SignalChanged(); } }
        public Type SelectedType { get; set; }
        public DB db { get; set; }
        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
            db = new DB();
            CarList = db.GetCars();
            WheelList = db.GetWheels();
            TypeList = db.GetTypes();
            ChangeList();
            ChangeWheelList(); 
            ChangeTypeList();
            SignalChanged();
        }

        private void AddCar(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PushModalAsync(new EditPage(new Car(), db));
            ChangeList();
        }

        private void EditCar(object sender, EventArgs e)
        {
            if (SelectedCar == null) return;
            Car car = new Car()
            {
                ID = SelectedCar.ID,
                Name = SelectedCar.Name,
                Price = SelectedCar.Price,
                Info = SelectedCar.Info,
                IDWheel = SelectedCar.IDWheel,
                IDType = SelectedCar.IDType
            };
            App.Current.MainPage.Navigation.PushModalAsync(new EditPage(car, db));
            ChangeList();

        }

        private void DeleteCar(object sender, EventArgs e)
        {
            if (SelectedCar != null)
            {
                db.DeleteCar(SelectedCar.ID);
                ChangeList();
            }
            else
                DisplayAlert("Ошибка", "Машина не выбрана", "ОК");
        }

        private void AddWheel(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PushModalAsync(new EditWheelPage(new Wheel(), db));
            ChangeWheelList();
        }

        private void EditWheel(object sender, EventArgs e)
        {

            if (SelectedWheel == null) return;
            Wheel wheel = new Wheel()
            {
                ID = SelectedWheel.ID,
                Name = SelectedWheel.Name,
                Price = SelectedWheel.Price,
                Info = SelectedWheel.Info,
                IDType = SelectedWheel.IDType
            };

            App.Current.MainPage.Navigation.PushModalAsync(new EditWheelPage(wheel, db));
            ChangeWheelList();
        }

        private void DeleteWheel(object sender, EventArgs e)
        {
            if (SelectedWheel != null)
            {
                db.DeleteWheel(SelectedWheel.ID);
                ChangeWheelList();
            }
            else
                DisplayAlert("Ошибка", "Колеса не выбраны", "ОК");
        }

        private void AddType(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PushModalAsync(new EditTypePage(new Type(), db));
            ChangeTypeList();
        }

        private void EditType(object sender, EventArgs e)
        {

            if (SelectedType == null) return;
            Type ty = new Type()
            {
                ID = SelectedType.ID,
                Name = SelectedType.Name,
            };

            App.Current.MainPage.Navigation.PushModalAsync(new EditTypePage(ty, db));
            ChangeTypeList();
        }

        private void DeleteType(object sender, EventArgs e)
        {
            if (SelectedType != null)
            {
                db.DeleteType(SelectedType.ID);
                ChangeTypeList();
            }
            else
                DisplayAlert("Ошибка", "Тип не выбран", "ОК");
        }

        public void ChangeTypeList()
        {
            TypeList = new ObservableCollection<Type>();
            TypeList = db.GetTypes();
        }

        public void ChangeWheelList()
        {
            WheelList = new ObservableCollection<Wheel>();
            WheelList = db.GetWheels();
        }

        public void ChangeList()
        {
            CarList = new ObservableCollection<Car>();
            CarList = db.GetCars();
        }

        public void SignalChanged([CallerMemberName] string prop = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
