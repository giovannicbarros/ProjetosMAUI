using AppTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTask.Repositories
{
    public interface iTaskModelRepository
    {
        //CRUD
        IList<TaskModel> getAll();
        TaskModel getById(int id);
        // TaskModel getByName(string name);

        void Add(TaskModel task);
        void Update(TaskModel task);
        void Delete(TaskModel task);

    }
}
