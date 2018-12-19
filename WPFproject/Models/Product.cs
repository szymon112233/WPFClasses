using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseWPF.Models
{
    public class Products : ICollection
    {
        public string collectionName;
        private ArrayList products = new ArrayList();

        public Product this[int index]
        {
            get { return (Product)products[index]; }
        }

        public ArrayList ProductsArray { set => products = value; }

        public void CopyTo(Array a, int index)
        {
            products.CopyTo(a, index);
        }
        public int Count
        {
            get { return products.Count; }
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
            return products.GetEnumerator();
        }

        public void Add(Product product)
        {
            products.Add(product);
        }

        public ArrayList GetProducts()
        {
            return this.products;
        }
    }

    public class Product
    {
        private string name;
        private float price;
        private string desc;
        private int quantity;
        private Status status;

        public Product()
        {
        }

        public Product(string name, float price, string desc, int quantity, Status status)
        {
            this.Name = name;
            this.Price = price;
            this.Desc = desc;
            this.Quantity = quantity;
            this.Status = status;
        }

        public string Name { get => name; set => name = value; }
        public float Price { get => price; set => price = value; }
        public string Desc { get => desc; set => desc = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public Status Status { get => status; set => status = value; }

        public override string ToString()
        {
            return String.Format("Product: {0} for {1}, in quantity: {2}, status: {3} ", this.name, this.price, this.quantity, this.status);
        }
    }

    public enum Status
    {
        SALE = 0,
        DISCOUNT,
        REMOVED,
        WAREHOUSE,
        COUNT
    }
}
