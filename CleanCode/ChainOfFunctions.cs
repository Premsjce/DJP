using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode
{
    class ChainOfFunctions
    {
        public static void Driver()
        {
            var temp = new WebBuilder().AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().AllowCredentials();
        }
    }

    public class WebBuilder
    {
        public bool AnyHeader { get; private set; }
        public bool AnyMethod { get; private set; }
        public bool AnyOrigin { get; private set; }
        public bool Credentials { get; private set; }

        public WebBuilder AllowAnyHeader()
        {
            AnyHeader = true;
            return this;
        }

        public WebBuilder AllowAnyMethod()
        {
            AnyMethod = true;
            return this;
        }

        public WebBuilder AllowAnyOrigin()
        {
            AnyOrigin = true;
            return this;
        }
        public WebBuilder AllowCredentials()
        {
            Credentials = true;
            return this;
        }

        //Some other class logic and validation when needed
    }
}
