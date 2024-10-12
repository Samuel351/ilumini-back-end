using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Form : EntityBase
    {
        public string Name { get; set; }

        public string Description { get; set; } 

        public List<Question> Questions { get; set; } = [];

        public Form() 
        { 
            Name = string.Empty;
            Description = string.Empty;
        }
    }
}
