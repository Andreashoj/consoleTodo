using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoList
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();

            bool running = true;

            while (running)
            {
                program.InputFiller();
                Console.WriteLine("\nVil du blive ved med at køre programmet? false = nej, true = ja");
                string input = Console.ReadLine();
                bool state = false;

                try
                {
                    state = bool.Parse(input);
                } catch(Exception)
                {
                    Console.WriteLine("Du er en retard");
                    state = true;
                }

                running = state;
            }
        }

        void InputFiller()
        {
            List<ToDoItem> toDoList = new List<ToDoItem>();

            while (toDoList.Count < 3)
            {
                Console.WriteLine("Tilføj en opgave");
                toDoList.Add(new ToDoItem(
                    toDoList.Count + 1,
                    Console.ReadLine(),
                    false
                    ));
            }

            commandLines(toDoList);
        }

        void commandLines(List<ToDoItem> toDoList)
        {

            // Udskriv listen med opgaver
            Console.WriteLine("Todo liste:");
            foreach (var todo in toDoList)
            {
                Console.WriteLine(todo);
            }

            // Assign string array from the enum to variable commands
            var commands = Enum.GetNames(typeof(TaskList));

            Console.WriteLine("\r\nCommands:");

            // Loop through the names in commands
            int i = 1;
            foreach (var command in commands)
            {
                Console.Write(command + " = " + i + ", ");
                i++;
            }


            Console.WriteLine("\r\nSkriv din næste command..");

            var consoleCommand = int.Parse(Console.ReadLine());
            ToDoItem item = new ToDoItem();



            if (consoleCommand == 1)
            {
                Console.WriteLine("Hvilken opgaves status vil du opdatere?");
                int itemIndex = int.Parse(Console.ReadLine());
                foreach (var itemStatus in toDoList)
                {
                    if (itemStatus.Id == itemIndex)
                        itemStatus.IsDone = !itemStatus.IsDone;
                }
                Console.WriteLine("Change status");

            }
            else if (consoleCommand == 2)
            {
                Console.WriteLine("Hvilken opgave vil du tilføje?");
                item.Id = toDoList.Count + 1;
                item.Name = Console.ReadLine();
                toDoList.Add(item);
            }
            else if (consoleCommand == 3)
            {
                Console.WriteLine("Hvilken opgave vil du fjerne?");
                int itemIndex = int.Parse(Console.ReadLine()) - 1;
                toDoList = remove(itemIndex, toDoList);
            }
            else if (consoleCommand == 4)
            {
                Console.WriteLine("Hvilken af opgaverne vil du ændre?");
                int itemIndex = int.Parse(Console.ReadLine());
                foreach (var itemChange in toDoList)
                {
                    if (itemChange.Id == itemIndex)
                    {
                        Console.WriteLine("Skriv ny tekst...");
                        itemChange.Name = Console.ReadLine().ToString();
                    }
                }
            }

            foreach (var x in toDoList)
            {
                Console.WriteLine(x);
            }
        }

        List<ToDoItem> remove(int itemIndex, List<ToDoItem> toDoList)
        {
            toDoList.RemoveAt(itemIndex);
            List<ToDoItem> newToDoList = new List<ToDoItem>();
            foreach (var item in toDoList)
            {
                item.Id = newToDoList.Count + 1;
                newToDoList.Add(item);
            }

            return newToDoList;
        }

    }

}
