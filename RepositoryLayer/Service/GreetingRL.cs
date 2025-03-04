using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer.Model;

namespace RepositoryLayer.Service
{
    public class GreetingRL : IGreetingRL
    {
        public string GetGreeting(UserNameRequestModel request)
        {
            if (!string.IsNullOrEmpty(request.FirstName) && !string.IsNullOrEmpty(request.LastName))
                return $"Hello, {request.FirstName} {request.LastName}!";

            if (!string.IsNullOrEmpty(request.FirstName))
                return $"Hello, {request.FirstName}!";

            if (!string.IsNullOrEmpty(request.LastName))
                return $"Hello, {request.LastName}!";

            return "Hello World!";
        }
    }
}
