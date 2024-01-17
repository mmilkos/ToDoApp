using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApi.Domain.Dtos
{
    public class TaskFormDto
    {

        [Required]
        [MinLength(2, ErrorMessage = "The field Name must be a string type with a minimum length of 2")]
        public string Name { get; set; }

        public string? Description { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}, Description: {Description}";
        }
    }
}
