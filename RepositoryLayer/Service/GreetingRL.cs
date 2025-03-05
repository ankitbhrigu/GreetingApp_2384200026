using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer.Model;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;

namespace RepositoryLayer.Service
{
    public class GreetingRL : IGreetingRL


    {
        private readonly GreetingDbContext _context;
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

        public GreetingEntity AddGreeting(GreetingEntity greeting)
        {
            _context.Greetings.Add(greeting);
            _context.SaveChanges();
            return greeting;
        }
    }
}
