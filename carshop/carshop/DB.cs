using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;

namespace carshop
{
    public class DB
    {
        private ObservableCollection<Car> carList = new ObservableCollection<Car>();
        private ObservableCollection<Wheel> wheelList = new ObservableCollection<Wheel>();
        private ObservableCollection<Type> typeList = new ObservableCollection<Type>();
        private int checkidcar = 0;
        private int checkidwheel = 0;
        private int checkidtype = 0;
        public DB()
        {
            Car car1 = new Car()
            {
                ID = ++checkidcar,
                Name = "Nissan Skyline",
                Price = 80000,
                Info = "1",
                IDWheel = 1,
                IDType = 1,
            };
            Car car2 = new Car()
            {
                ID = ++checkidcar,
                Name = "KAMAZ",
                Price = 15000,
                Info = "2",
                IDWheel = 2,
                IDType = 2,
            };
            Car car3 = new Car()
            {
                ID = ++checkidcar,
                Name = "HAMER",
                Price = 45000,
                Info = "3",
                IDWheel = 3,
                IDType = 2,
            };
            carList.Add(car1);
            carList.Add(car2);
            carList.Add(car3);

            Wheel wheel1 = new Wheel()
            {
                ID = ++checkidwheel,
                Name = "1",
                Price = 1000,
                Info = "1",
                IDType = 1,
            };
            Wheel wheel2 = new Wheel()
            {
                ID = ++checkidwheel,
                Name = "2",
                Price = 3000,
                Info = "2",
                IDType = 2,
            };
            Wheel wheel3 = new Wheel()
            {
                ID = ++checkidwheel,
                Name = "3",
                Price = 2500,
                Info = "3",
                IDType = 2,
            };
            wheelList.Add(wheel1);
            wheelList.Add(wheel2);
            wheelList.Add(wheel3);

            Type type1 = new Type()
            {
                ID = ++checkidtype,
                Name = "Sport",
            };
            Type type2 = new Type()
            {
                ID = ++checkidtype,
                Name = "Off-Road",
            };
            typeList.Add(type1);
            typeList.Add(type2);
        }
        public ObservableCollection<Car> GetCars()
        {
            return carList;
        }
        public Car GetCar(int id)
        {
            return carList.FirstOrDefault(x => x.ID == id);
        }

        public ObservableCollection<Wheel> GetWheels()
        {
            return wheelList;
        }
        public Wheel GetWheel(int id)
        {
            return wheelList.FirstOrDefault(x => x.ID == id);
        }
        public ObservableCollection<Type> GetTypes()
        {
            return typeList;
        }
        public Type GetType(int id)
        {
            return typeList.FirstOrDefault(x => x.ID == id);
        }
        public void DeleteCar(int id)
        {
            Car car = GetCar(id);
            if (car != null)
                carList.Remove(car);
        }

        public void EditCar(Car car)
        {
            if (car.ID == 0)
            {
                car.ID = ++checkidcar;
                carList.Add(car);

            }
            else
            {
                Car oldCar = GetCar(car.ID);
                oldCar.Name = car.Name;
                oldCar.Price = car.Price;
                oldCar.Info = car.Info;
                oldCar.IDWheel = car.IDWheel;
                oldCar.IDType = car.IDType;
                carList.Add(oldCar);
                carList.Remove(GetCar(car.ID));

            }
        }

        public void DeleteWheel(int id)
        {
            Wheel wheel = GetWheel(id);
            if (wheel != null)
                wheelList.Remove(wheel);
        }

        public void EditWheel(Wheel wheel)
        {
            if (wheel.ID == 0)
            {
                wheel.ID = ++checkidwheel;
                wheelList.Add(wheel);

            }
            else
            {
                Wheel oldWheel = GetWheel(wheel.ID);
                oldWheel.Name = wheel.Name;
                oldWheel.Price = wheel.Price;
                oldWheel.Info = wheel.Info;
                oldWheel.IDType = wheel.IDType;
                wheelList.Add(wheel);
                wheelList.Remove(GetWheel(wheel.ID));
            }
        }
        public void DeleteType(int id)
        {
            Type ty = GetType(id);
            if (ty != null)
                typeList.Remove(ty);
        }

        public void EditType(Type ty)
        {
            if (ty.ID == 0)
            {
                ty.ID = ++checkidtype;
                typeList.Add(ty);
            }
            else
            {
                Type oldTy = GetType(ty.ID);
                oldTy.Name = ty.Name;
                typeList.Add(ty);
                typeList.Remove(GetType(ty.ID));
            }
        }
    }
}

