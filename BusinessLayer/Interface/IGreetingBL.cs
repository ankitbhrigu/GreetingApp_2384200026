﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer.Model;
using RepositoryLayer.Entity;

namespace BusinessLayer.Interface
{
    public interface IGreetingBL
    {
        string GetGreet();
        string GetGreeting(UserNameRequestModel request);
        GreetingEntity AddGreeting(GreetingEntity greeting);
    }

}
