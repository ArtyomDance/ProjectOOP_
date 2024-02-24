using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_OOP12
{
    internal class Profesor: Person
    {
        DbManeger dbManeger = new DbManeger();

        public string Specialization { get; set; }




        public void ShowProfesor(int id)
        {
            Console.WriteLine(id + dbManeger.GetInfoById("Profesor", Convert.ToString(id), "IdProfesora"));
        }
    }
}
