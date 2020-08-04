using SimpleNosqlGuestbook.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleNosqlGuestbook.Models
{
    public class GuestbookViewModel
    {
        public List<GuestbookRecordDto> Records { get; set; }
    }
}
