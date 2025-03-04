using BusinessLayer.Interface;
using ModelLayer.Model;
using RepositoryLayer.Interface;
using RepositoryLayer.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Service
{
    public class GreetingBL : IGreetingBL
    {
       private readonly IGreetingRL _greetingRL;
        public GreetingBL(IGreetingRL greetingRL)
        {
            _greetingRL = greetingRL;
        }

        public string GetGreeting(UserNameRequestModel request)
        {
            return  _greetingRL.GetGreeting(request);
        }

        public string GetGreet()
        {
            return "Hello World";
        }
    }
}
