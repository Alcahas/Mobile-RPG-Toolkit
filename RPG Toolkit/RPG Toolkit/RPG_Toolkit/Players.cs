using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RPG_Toolkit
{
    public class Players
    {
        [PrimaryKey, AutoIncrement] //using SQLite
        public int PlID //autoincrementing ID
        {
            get;
            set;
        }
        public string PlName 
        {
            get;
            set;
        }
        public Color PlColors {
            get;
            set;
        }
        public int PlValue
        {
            get;
            set;
        }

    }
}
