using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.DAL.Configuration
{
    public class JwtConfig
    {
        public string Secret { get; set; }
        public DateTime Issued { get; set; }
        public DateTime? Expires { get; set; }
    }
}
