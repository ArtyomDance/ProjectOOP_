using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_OOP12
{
    internal class Student: Person
    {
        DbManeger dbManeger = new DbManeger();


        public int NumerIndeksu { get; set; }





        public void ShowStudent(int id)
        {
            Console.WriteLine(id + dbManeger.GetInfoById("Students", Convert.ToString(id), "IdStudent"));
        }






    }
}
