using System;

namespace eIMIC223925.ViewModels.System.Users
{
    public class UserDeleteRequest
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}