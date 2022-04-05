using System;
using System.Collections.Generic;
using System.Text;

namespace BoardErectors.Domain.Entities
{
    public class ErectedBoardType
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ExpiryAge { get; set; }
    }
}
