using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace ProiectFinal_Mobile.Models
{
    public class ListBreed
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [ForeignKey(typeof(AnimalList))]
        public int AnimalListID { get; set; }
        public int BreedID { get; set; }
    }
}
