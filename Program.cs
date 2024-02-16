using System;
using System.Collections.Generic;

namespace ToDo
{
    internal class Program
    {
        public static List<string> taskList { get; set; }

        static void Main(string[] args)
        {
            taskList = new List<string>();
            int menuSelected = 0;
            do
            {
                menuSelected = ShowMainMenu();
                if ((Menu)menuSelected == Menu.Add)
                {
                    ShowMenuAdd();
                }
                else if ((Menu)menuSelected == Menu.Remove)
                {
                    ShowMenuRemove();
                }
                else if ((Menu)menuSelected == Menu.List)
                {
                    ShowTaskList();
                }
            } while ((Menu)menuSelected != Menu.Exit);
        }
        
        /// <summary>
        /// Show the main menu 
        /// </summary>
        /// <returns>Returns option indicated by user</returns>
        public static int ShowMainMenu()
        {
            PrintSeparator();
            Console.WriteLine("Ingrese la opción a realizar: ");
            Console.WriteLine("1. Nueva tarea");
            Console.WriteLine("2. Remover tarea");
            Console.WriteLine("3. Tareas pendientes");
            Console.WriteLine("4. Salir");

            // Read line
            string option = Console.ReadLine();
            return Convert.ToInt32(option);
        }

        public static void ShowMenuRemove()
        {
            try
            {
                Console.WriteLine("Ingrese el número de la tarea a remover: ");
                // Show current taks
                ShowTaskList();

                string line = Console.ReadLine();

                // Remove one position
                int indexToRemove = Convert.ToInt32(line) - 1;

                if (indexToRemove > -1 && taskList.Count > 0)
                {
                    string task = taskList[indexToRemove];
                    taskList.RemoveAt(indexToRemove);
                    Console.WriteLine("Tarea " + task + " eliminada");
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
                taskList.Add(task);
                Console.WriteLine("Tarea registrada");
            }
            catch (Exception)
            {
            }
        }

        public static void ShowTaskList()
        {
            if (taskList == null || taskList.Count == 0)
            {
                Console.WriteLine("No hay tareas por realizar");
            } 
            else
            {
                PrintSeparator();
                var indexTask = 1;
                taskList.ForEach(task => Console.WriteLine((indexTask++) + ". " + task));
                PrintSeparator();
            }
        }

        public enum Menu{
            Add = 1,
            Remove = 2,
            List = 3,
            Exit = 4
        }

        private static void PrintSeparator(){
            Console.WriteLine("----------------------------------------");
        }
    }
}
