using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApi.Domain.Dtos
{
    public class LoginFormDto
    {
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
