


   
    List<string> TaskList = new List<string>();

      
            
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
        /// Show the option for task, 1. nueva tarea
        /// </summary>
        /// <returns>Returns option selected by user</returns>
        int ShowMainMenu()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Ingrese la opción a realizar: ");
            Console.WriteLine("1. Nueva tarea");
            Console.WriteLine("2. Remover tarea");
            Console.WriteLine("3. Tareas pendientes");
            Console.WriteLine("4. Salir");

            
            string optionChoseUser = Console.ReadLine();
            return Convert.ToInt32(optionChoseUser);
        }

        void ShowMenuRemove()
        {
            try
            {
                Console.WriteLine("Ingrese el número de la tarea a remover: ");
                
                ShowTaskList();

                string optionChoseUser = Console.ReadLine();
                // Remove one position because the array starts in 0
                int indexToRemove = Convert.ToInt32(optionChoseUser) - 1;
                if(indexToRemove > (TaskList.Count -1) || indexToRemove <0)
                {
                    Console.WriteLine("Numero de tareas seleccionado no es valido");

                }
                else
                {
                    if (indexToRemove > -1 && TaskList.Count > 0)
                    {
                    
                        string task = TaskList[indexToRemove];
                        TaskList.RemoveAt(indexToRemove);
                        Console.WriteLine($"Tarea {task} eliminada");
                        
                    }

                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ha ocurrido un error al elemininar la tarea");
            }
        }

        void ShowMenuAdd()
        {
            try
            {
                Console.WriteLine("Ingrese el nombre de la tarea: ");
                string task = Console.ReadLine();
                if(string.IsNullOrEmpty(task)== true)
                {
                    Console.WriteLine("No capturaste nada");

                }
                else
                {
                    TaskList.Add(task);
                    Console.WriteLine("Tarea registrada");

                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ha ocurrido un error al capturar la tarea");
            }
        }

        void ShowMenuTaskList()
        {
            if (TaskList?.Count > 0)
            {
                ShowTaskList();
            } 
            else
            {
                Console.WriteLine("No hay tareas por realizar");
                
            }
        }

        void ShowTaskList()
        {
            
            
            Console.WriteLine("----------------------------------------");
            var indexTask=1;
            TaskList.ForEach(p=> Console.WriteLine($"{indexTask++}  .   {p}"));
            Console.WriteLine("----------------------------------------");
            
        }
    

    enum Menu 
    {
        Add = 1,

        Remove = 2,

        List = 3,

        Exit = 4

    }

