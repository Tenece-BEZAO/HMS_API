using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.DAL.Dtos.Reponses
{
    public class SuccessResponse
    {
        public bool Success { get; set; }
        public object Data { get; set; }
    }
}
