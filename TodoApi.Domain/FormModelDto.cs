using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApi.Domain
{
    public class FormModelDto
    {
        [Required]
        [MinLength(2, ErrorMessage = "Name should be min 2 chars")]
        public string Name { get; set; }

        public string? Description { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}, Description: {Description}";
        }
    }
}
