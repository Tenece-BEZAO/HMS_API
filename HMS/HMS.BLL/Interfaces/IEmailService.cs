using HMS.DAL.Dtos.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.BLL.Interfaces
{
    public interface IEmailService
    {
        void sendEmail(Message message);
    }
}
