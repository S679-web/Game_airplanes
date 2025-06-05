using System;
using System.Collections.Generic;

namespace Game
{
    internal class AppDbContext
    {
        internal readonly object users;
        internal object Roles;
        internal IEnumerable<object> GameResult;
        internal object user;

        internal void SaveChanges()
        {
            throw new NotImplementedException();
        }

        internal object Users(Func<object, object> value)
        {
            throw new NotImplementedException();
        }
    }
}