﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTask.Models
{
    public class SubTaskModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool isCompleted { get; set; }
    }
}
