using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationFundamentals.Services
{
    public interface IMyService
    {
        public string GetMessage();
    }

    public class MyService : IMyService
    {
        public string GetMessage()
        {
            return "Hello from IMyServices!";
        }
    }
}
