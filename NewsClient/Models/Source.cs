using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsClient.Models
{
    public class Source : BaseEntity
    {
        public string Name { get; set; }

        public override string ToString()
        {
            return $"Title: {Name}\r\n ";
        }
    }
}
