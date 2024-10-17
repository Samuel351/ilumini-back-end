using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class FormInstanceResponse : EntityBase
    {
        public Guid OptionId { get; set; }

        public Option? Option { get; set; }

        public Guid FormInstanceId { get; set; }

        public FormInstance? FormInstance { get; set; }

        public Guid RecipientId { get; set; }

        public Recipient? Recipient { get; set; }
    }
}
