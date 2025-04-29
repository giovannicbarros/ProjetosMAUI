using AppTask.Models;
using AppTask.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AppTask.Repositories
{
    public class TaskModelRepository : iTaskModelRepository
    {
        private AppTaskContext _db;

        public TaskModelRepository()
        {
            _db = new AppTaskContext();
        }

        public IList<TaskModel> getAll()
        {
            return _db.Tasks.ToList();
        }

        public TaskModel getById(int id)
        {
            return _db.Tasks.Include(a => a.subTasks).FirstOrDefault(a => a.Id == id);
        }
        
        public void Add(TaskModel task)
        {
            _db.Tasks.Add(task);
            _db.SaveChanges();
        }

        public void Update(TaskModel task)

        {
            _db.Tasks.Update(task);
            _db.SaveChanges();
        }

        public void Delete(TaskModel task)
        {
            _db.Tasks.Remove(task);
            _db.SaveChanges();
        }
        
    }
}
