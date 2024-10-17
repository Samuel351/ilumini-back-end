using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class FormInstance : EntityBase
    {
        public Guid FormId { get; set; }

        public Form? Form { get; set; }

        public string LaunchName { get; set; }

        public DateTime ExpirationDate { get; set; }

        public List<FormInstanceResponse> Responses { get; set; } = [];
    }
}
