﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApi.Domain.Entities
{
    public class UserTask
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string? Description { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now.Date;

        public bool Complited { get; set; } = false;

        public string AuthorName { get; set; }
    }
}
