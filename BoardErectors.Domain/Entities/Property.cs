using System;
using System.Collections.Generic;
using System.Text;

namespace BoardErectors.Domain.Entities
{

    public class Property
    {
        public string Id { get; set; }
        public Address Address { get; set; }
        public DateTime ErectedAt { get; set; }
        public ErectedBoardType ErectedBoardType { get; set; }
        public float TotalFeeCharged { get; set; }
    }



}
