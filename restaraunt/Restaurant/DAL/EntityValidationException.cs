using System;

namespace Restaurant.DAL
{
    public class EntityValidationException : Exception
    {
        public EntityValidationException(string message) : base(message)
        {
        }
    }
}
