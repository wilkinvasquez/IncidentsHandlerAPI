﻿using IncidentsHandler.Domain.BaseEntity;
using System.Collections.Generic;

namespace IncidentsHandler.Domain.Models
{
    public class Position : Entity
    {
        public string Name { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
