using System;

namespace BLL
{
    public class DomainException : Exception
    {
        public DomainException(string message): base(message) {}
    }
}
