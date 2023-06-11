namespace ToDoListWebApi.Models.Orms
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CreateUserid { get; set; }
        public User User { get; set; }
        public DateTime CreatedDate { get; set; }   
        public DateTime? UpdatedDate { get; set;}

    }
}
