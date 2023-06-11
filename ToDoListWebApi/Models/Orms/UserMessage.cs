namespace ToDoListWebApi.Models.Orms
{
    public class UserMessage
    {
        public int Id { get; set; }
        public string Message { get; set; }

        public string UserName { get; set; }
        public User User { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
