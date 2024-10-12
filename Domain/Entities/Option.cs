using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Option : EntityBase
    {
        public string Statement { get; set; }

        public string Value { get; set; }

        public int Order { get; set; }

        public Guid QuestionId { get; set; }

        public Question? Question { get; set; }

        public Option() 
        { 
            Statement = string.Empty;
            Value = string.Empty;
        }

    }
}
