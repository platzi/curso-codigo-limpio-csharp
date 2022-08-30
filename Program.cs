using System;
using System.Collections.Generic;

namespace ToDo
{
    internal class Program
    {
        public static List<string> TL { get; set; }

        static void Main(string[] args)
        {
            TL = new List<string>();
            int variable = 0;
            do
            {
                variable = ShowMainMenu();
                if (variable == 1)
                {
                    ShowMenuAdd();
                }
                else if (variable == 2)
                {
                    ShowMenuDos();
                }
                else if (variable == 3)
                {
                    ShowMenuTres();
                }
            } while (variable != 4);
        }
        /// <summary>
        /// Show the main menu 
        /// </summary>
        /// <returns>Returns option indicated by user</returns>
        public static int ShowMainMenu()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Ingrese la opción a realizar: ");
            Console.WriteLine("1. Nueva tarea");
            Console.WriteLine("2. Remover tarea");
            Console.WriteLine("3. Tareas pendientes");
            Console.WriteLine("4. Salir");

            // Read line
            string line = Console.ReadLine();
            return Convert.ToInt32(line);
        }

        public static void ShowMenuDos()
        {
            try
            {
                Console.WriteLine("Ingrese el número de la tarea a remover: ");
                // Show current taks
                for (int i = 0; i < TL.Count; i++)
                {
                    Console.WriteLine((i + 1) + ". " + TL[i]);
                }
                Console.WriteLine("----------------------------------------");

                string line = Console.ReadLine();
                // Remove one position
                int indexToRemove = Convert.ToInt32(line) - 1;
                if (indexToRemove > -1)
                {
                    if (TL.Count > 0)
                    {
                        string task = TL[indexToRemove];
                        TL.RemoveAt(indexToRemove);
                        Console.WriteLine("Tarea " + task + " eliminada");
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        public static void ShowMenuAdd()
        {
            try
            {
                Console.WriteLine("Ingrese el nombre de la tarea: ");
                string task = Console.ReadLine();
                TL.Add(task);
                Console.WriteLine("Tarea registrada");
            }
            catch (Exception)
            {
            }
        }

        public static void ShowMenuTres()
        {
            if (TL == null || TL.Count == 0)
            {
                Console.WriteLine("No hay tareas por realizar");
            } 
            else
            {
                Console.WriteLine("----------------------------------------");
                for (int i = 0; i < TL.Count; i++)
                {
                    Console.WriteLine((i + 1) + ". " + TL[i]);
                }
                Console.WriteLine("----------------------------------------");
            }
        }
    }
}
