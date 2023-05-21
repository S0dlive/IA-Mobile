using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IA_Blazor.Models
{
    record MessageFront(string Content, MessageType Type);
    enum MessageType
    {
        Question = 0,
        Response = 1,
    }
}
