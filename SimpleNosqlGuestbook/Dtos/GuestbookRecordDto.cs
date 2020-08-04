using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleNosqlGuestbook.Dtos
{
    public class GuestbookRecordDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PostText { get; set; }
        public DateTime AddedOn { get; set; }
    }
}
