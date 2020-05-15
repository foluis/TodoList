using System;

namespace Na.TodoList.Domain
{
    public class Todo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime DueDate { get; set; }
        public bool Finished { get; set; }
    }
}
