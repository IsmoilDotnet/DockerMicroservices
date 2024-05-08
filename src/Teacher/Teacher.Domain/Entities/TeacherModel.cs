using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teacher.Domain.Entities
{
    public class TeacherModel 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int age { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
