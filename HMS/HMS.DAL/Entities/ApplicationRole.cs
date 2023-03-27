using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.DAL.Entities
{
    public class ApplicationRole
    {
        public string Name { get; set; }
        public string NormalizedName { get; set; }
    }
}
