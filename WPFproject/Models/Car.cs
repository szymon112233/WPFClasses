using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseWPF.Models
{
    public class Cars : ICollection
    {
        public string collectionName;
        private ArrayList cars = new ArrayList();

        public Car this[int index]
        {
            get { return (Car)cars[index]; }
        }

        public ArrayList CarsArray { set => cars = value; }

        public void CopyTo(Array a, int index)
        {
            cars.CopyTo(a, index);
        }
        public int Count
        {
            get { return cars.Count; }
        }
        public object SyncRoot
        {
            get { return this; }
        }
        public bool IsSynchronized
        {
            get { return false; }
        }
        public IEnumerator GetEnumerator()
        {
            return cars.GetEnumerator();
        }

        public void Add(Car car)
        {
            cars.Add(car);
        }

        public ArrayList GetCars()
        {
            return this.cars;
        }
    }

    public class Car
    {
        private string name;
        private string brand;
        private string type;
        private string plates;
        private string notes;
        private DateTime dateBought;

        public Car()
        {
        }

        public Car(string name, string brand, string type, string plates, string notes, DateTime dateBought)
        {
            this.Name = name;
            this.Brand = brand;
            this.Type = type;
            this.Plates = plates;
            this.Notes = notes;
            this.DateBought = dateBought;
        }

        public string Name { get => name; set => name = value; }
        public string Brand { get => brand; set => brand = value; }
        public string Type { get => type; set => type = value; }
        public string Plates { get => plates; set => plates = value; }
        public string Notes { get => notes; set => notes = value; }
        public DateTime DateBought { get => dateBought; set => dateBought = value; }

        public override string ToString()
        {
            return String.Format("Car: {0} by {1}, type: {2}, plates: {3}, bought: {4}", this.name, this.brand, this.type, this.plates, this.dateBought.ToShortDateString());
        }
    }

}
