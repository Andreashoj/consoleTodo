using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoList
{
    /// <summary>
    /// Et ToDo objekt til brug i en ToDo app
    /// </summary>
    public class ToDoItem
    {
        /// <summary>
        /// ID for opgaven
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Navn for opgaven
        /// </summary>

        public string Name { get; set; }
        /// <summary>
        /// Status for opgaven
        /// </summary>
        public bool IsDone { get; set; }
        /// <summary>
        /// Enkelt constructor hvor status sættes til falsk
        /// </summary>
        public ToDoItem()
        {
            IsDone = false;
        }
        /// <summary>
        /// Constructor hvor opgaven får tildelt et navn
        /// </summary>
        /// <param name="name">Navnet opgaven skal have (valgfrit)</param>
        public ToDoItem(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Constructor med alle værdier sat fra starten
        /// </summary>
        /// <param name="id">Id for opgaven</param>
        /// <param name="name">Navnet for opgaven</param>
        /// <param name="status">Status for opgaven</param>
        public ToDoItem(int id, string name, bool status)
        {
            Id = id;
            Name = name;
            IsDone = status;
        }

        public override string ToString()
        {
            return Id + ")" + Name + " " + ": " + IsDone;
        }
    }
}