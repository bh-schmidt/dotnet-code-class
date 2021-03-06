﻿using DotnetCodeClass.Models;
using System;
using System.Collections.Generic;

namespace DotnetCodeClass.Factories
{
    public static class UserFactory
    {
        public static User Generate()
        {
            return new User()
            {
                Guid = Guid.NewGuid(),
                Username = StringFactory.Randomize(16),
                Password = StringFactory.Randomize(7),
                Name = StringFactory.Randomize(20)
            };
        }

        public static IEnumerable<User> Generate(long count)
        {
            for (long i = 0; i < count; i++)
            {
                yield return Generate();
            }
        }
    }
}
