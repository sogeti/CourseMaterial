using GreeterApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreeterApplication
{
    public class GreetingEngine
    {
        public GreetingEngine()
        {
        }

        public string SayHello(string language)
        {
            switch (language)
            {
                case "Dutch":
                    var greeter = new DutchHelloGreeter();
                    return greeter.SayHello();
                case "English":
                    var greeterEn = new EnglishHelloGreeter();
                    return greeterEn.SayHello();
                case "German":
                    var greeterGe = new GermanHelloGreeter();
                    return greeterGe.SayHello();
                default:
                    throw new Exception();
            }
        }

        public string SayGoodbye(string language)
        {
            switch (language)
            {
                case "Dutch":
                    var greeter = new DutchGoodbyeGreeter();
                    return greeter.SayHello();
                case "English":
                    var greeterEn = new EnglishGoodbyeGreeter();
                    return greeterEn.SayHello();
                case "German":
                    var greeterGe = new GermanGoodbyeGreeter();
                    return greeterGe.SayHello();
                default:
                    throw new Exception();
            }
        }
    }
}
