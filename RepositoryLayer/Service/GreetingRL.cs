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

        public GreetingEntity GetGreetingById(int id)
        {
            return _context.Greetings.Find(id);
        }

        public List<GreetingEntity> GetAllGreetings()
        {
            return _context.Greetings.ToList();
        }

        public GreetingEntity UpdateGreeting(GreetingEntity greeting) // New Method
        {
            var existingGreeting = _context.Greetings.Find(greeting.Id);
            if (existingGreeting != null)
            {
                existingGreeting.Message = greeting.Message;
                _context.SaveChanges();
            }
            return existingGreeting;
        }

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
