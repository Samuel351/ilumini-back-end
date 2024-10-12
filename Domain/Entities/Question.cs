using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Question : EntityBase
    {
        public string Statement { get; set; }

        public int Order { get; set; }

        public bool IsOptional { get; set; }
         
        public QuestionType QuestionType { get; set; }

        public Guid FormId { get; set; }

        public Form? Form { get; set; }

        public List<Option> Options { get; set; } = [];

        public Question() 
        { 
            Statement = string.Empty;
        }
    }
}
