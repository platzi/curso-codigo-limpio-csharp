List<string> TaskList =  new List<string>();

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
                    ShowMenuTaskList();
                }
            } while ((Menu)menuSelected != Menu.Exit);

        /// <summary>
        /// Show the main menu 
        /// </summary>
        /// <returns>Returns option indicated by user</returns>
        int ShowMainMenu()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Ingrese la opción a realizar: ");
            Console.WriteLine("1. Nueva tarea");
            Console.WriteLine("2. Remover tarea");
            Console.WriteLine("3. Tareas pendientes");
            Console.WriteLine("4. Salir");

            // Read line
            string menuSelected = Console.ReadLine();
            return Convert.ToInt32(menuSelected);
        }

        void ShowMenuRemove()
        {
            try
            {
                Console.WriteLine("Ingrese el número de la tarea a remover: ");
                // Show current taks
                ShowMenuTaskList();

                string taskNumberToDelete = Console.ReadLine();
                // Remove one position
                int indexToRemove = Convert.ToInt32(taskNumberToDelete) - 1;

                if(indexToRemove > (TaskList.Count -1) || indexToRemove <0) 
                    Console.WriteLine("Numero de tarea selecionado no es valido");
                else
                {
                    if (indexToRemove > -1 && TaskList.Count > 0)
                    {
                            string taskToRemove = TaskList[indexToRemove];
                            TaskList.RemoveAt(indexToRemove);
                            Console.WriteLine("Tarea " + taskToRemove + " eliminada");
                    }
                }
               
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ha ocurrido un error al eliminar la tarea");
            }
        }

        void ShowMenuAdd()
        {
            try
            {
                Console.WriteLine("Ingrese el nombre de la tarea: ");
                string newTask = Console.ReadLine();
                TaskList.Add(newTask);
                Console.WriteLine("Tarea registrada");
            }
            catch (Exception)
            {
            }
        }

        void ShowMenuTaskList()
        {
            if (TaskList?.Count > 0)
            {
                Console.WriteLine("----------------------------------------");
                var indexTask=1;
                TaskList.ForEach(p=> Console.WriteLine($"{indexTask++} . {p}"));
                
                Console.WriteLine("----------------------------------------");
            } 
            else
            {
                Console.WriteLine("No hay tareas por realizar");
            }
        }

    public enum Menu
    {
        Add = 1,
        Remove = 2,
        List = 3,
        Exit = 4
    }

