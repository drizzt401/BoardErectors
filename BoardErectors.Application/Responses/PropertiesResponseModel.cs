using BoardErectors.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoardErectors.Application.Responses
{
    public class PropertiesResponseModel
    {
        public IEnumerable<Property> Properties { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
