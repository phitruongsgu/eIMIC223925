﻿namespace eIMIC223925.ViewModels.System.Users
{
    public class LoginRequest
    {
        //[Required]
        public string UserName { get; set; }

        //[Required]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}