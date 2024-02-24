using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace Project_OOP12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DbManeger dbManeger = new DbManeger();
            Student student = new Student();
            Profesor profesor = new Profesor();
            
            while (true) {
                Console.WriteLine("1: Select from database");
                Console.WriteLine("2: Insert into database");
                Console.WriteLine("3: Edit database");
                Console.WriteLine("4: Delite from database");
                string option = Console.ReadLine();

                // 1) its for just see records into database 
                if (option == "1")
                {
                    Console.WriteLine("1: Coose student");
                    Console.WriteLine("2: Coose profesor");
                    Console.WriteLine("3: Coose course");
                    string option1 = Console.ReadLine();
                    if (option1 == "1")
                    {
                        string TableName = "Students";
                        string ColumnName = "IdStudent";
                        for (int i = 1; i <= dbManeger.GetLastId(TableName, ColumnName); i++)
                        {
                            student.ShowStudent(i);
                        }
                        Console.WriteLine("*************************************");
                    }
                    else if (option1 == "2")
                    {
                        string TableName = "Profesor";
                        string ColumnName = "IdProfesora";
                        for (int i = 1; i <= dbManeger.GetLastId(TableName, ColumnName); i++)
                        {
                            profesor.ShowProfesor (i);
                        }
                        Console.WriteLine("*************************************");
                    }
                    else if (option1 == "3")
                    {
                        for (int i = 1; i < dbManeger.GetLastId("Course", "CourseId"); i++)
                        {
                            Console.WriteLine(dbManeger.GetInfoById("Course", i.ToString(), "CourseId"));
                        }
                        Console.WriteLine("*************************************");
                    }
                }

                // 2) its for insert datas into databases
                else if (option == "2") 
                {
                    Console.WriteLine("1: Zapisat studenta");
                    Console.WriteLine("2: Zapisat profesora");
                    string option1 = Console.ReadLine();
                    if (option1 == "1")
                    {
                        Console.Write("Napisz imie: ");
                        string a = Console.ReadLine();
                        Console.Write("Napisz nazwisko: ");
                        string b = Console.ReadLine();
                        Console.Write("Napisz numer albumu: ");
                        string c = Console.ReadLine();
                        dbManeger.InsertDataIntoTable("Students", a, b, c, "IdStudent", "NumerIndeksu");

                        Console.WriteLine("*************************************");
                    }
                    else if (option1 == "2")
                    {
                        Console.Write("Napisz imie: ");
                        string a = Console.ReadLine();
                        Console.Write("Napisz nazwisko: ");
                        string b = Console.ReadLine();
                        Console.Write("Napisz specjalnosz: ");
                        string c = Console.ReadLine();
                        dbManeger.InsertDataIntoTable("Profesor", a, b, c, "IdProfesora", "Specjalnosc");
                        Console.WriteLine("*************************************");
                    }

                }

                // 3) Editing data into database
                else if (option == "3")
                {
                    Console.WriteLine("1: Edit table students");
                    Console.WriteLine("2: Edit table profesors");
                    string option1 = Console.ReadLine();
                    if (option1 == "1")
                    {
                        Console.Write("Enter student id: ");
                        int a = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter new name: ");
                        string b = Console.ReadLine();
                        Console.Write("Enter new surname: ");
                        string c = Console.ReadLine();
                        Console.Write("Enter new indeks: ");
                        string d = Console.ReadLine();

                        dbManeger.UpdateDataById("Students", "IdStudent", a, b, c, d, "NumerIndeksu");
                        Console.WriteLine("*************************************");
                    }
                    else if (option1 == "2")
                    {
                        Console.Write("Enter profesor id: ");
                        int a = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter new name: ");
                        string b = Console.ReadLine();
                        Console.Write("Enter new surname: ");
                        string c = Console.ReadLine();
                        Console.Write("Enter new specialnosz: ");
                        string d = Console.ReadLine();

                        dbManeger.UpdateDataById("Profesor", "IdProfesora", a, b, c, d, "Specjalnosc");
                        Console.WriteLine("*************************************");
                    }
                }


                else if (option == "4")
                {
                    Console.WriteLine("1: Delite students");
                    Console.WriteLine("2: Delite profesors");
                    string option1 = Console.ReadLine();
                    if (option1 == "1")
                    {
                        Console.Write("Enter student id: ");
                        int a = Convert.ToInt32(Console.ReadLine());

                        dbManeger.DeleteRecordById("Students", "IdStudent", a);
                        Console.WriteLine("*************************************");
                    }
                    else if (option1 == "2")
                    {
                        Console.Write("Enter profesor id: ");
                        int a = Convert.ToInt32(Console.ReadLine());

                        dbManeger.DeleteRecordById("Profesor", "IdProfesora", a);
                        Console.WriteLine("*************************************");
                    }
                }

                else if (option == "8")
                {
                    string name = Console.ReadLine();
                    dbManeger.InsertDataIntoCourse("Course", name, "CourseId");
                    Console.WriteLine("*************************************");
                }

            }
            

            Console.ReadKey();
        }
    }
}