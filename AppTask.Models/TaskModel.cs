namespace AppTask.Models
{
    public class TaskModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime PrevisionDate { get; set; }
        public bool isCompleted { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }

        public List<SubTaskModel> subTasks { get; set; } = new List<SubTaskModel>();
    }
}
