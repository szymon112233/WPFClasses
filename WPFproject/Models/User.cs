using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace DatabaseWPF.Models
{
    public class Users : ICollection
    {
        public string collectionName;
        private ArrayList users = new ArrayList();

        public User this[int index]
        {
            get { return (User)users[index]; }
        }

        public ArrayList UserArray { set => users = value; }

        public void CopyTo(Array a, int index)
        {
            users.CopyTo(a, index);
        }
        public int Count
        {
            get { return users.Count; }
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
            return users.GetEnumerator();
        }

        public void Add(User newUser)
        {
            users.Add(newUser);
        }

        public ArrayList GetUsers()
        {
            return this.users;
        }
    }

    public class User
    {
        private int id;
        private string login;
        private string password;

        public int Id { get => id; set => id = value; }
        public string Login { get => login; set => login = value; }
        public string Password { get => password; set => password = value; }

        public User(string login, string password, int id = 0)
        {
            this.login = login;
            this.password = password;
            this.id = id;
        }

        public User() { }
    }
}
