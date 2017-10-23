using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreeterApplication.Models
{
    public class DutchHelloGreeter
    {
        public string SayHello()
        {
            var sb = new StringBuilder();
            sb.AppendLine("<<Clear Throat>>");
            sb.AppendLine("<<Smile>>");
            sb.AppendLine("Hoi, alles goed?");
            sb.AppendLine("<<Extend hand>>");
            return sb.ToString();
        }
    }
}
