using System;

namespace eIMIC223925.Utilities.Exceptions
{
    public class eIMIC223925Exception : Exception
    {
        public eIMIC223925Exception()
        {
        }

        public eIMIC223925Exception(string message)
            : base(message)
        {
        }

        public eIMIC223925Exception(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
