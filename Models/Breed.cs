using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace ProiectFinal_Mobile.Models
{
    public class Breed
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        [OneToMany]
        public List<ListBreed> ListBreeds { get; set; }
    }

}
