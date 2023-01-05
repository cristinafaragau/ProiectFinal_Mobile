﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace ProiectFinal_Mobile.Models
{
    public  class AnimalList
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [MaxLength(30), Unique]
        public string Name { get; set; }
        public DateTime Date { get; set; }
    }
}
