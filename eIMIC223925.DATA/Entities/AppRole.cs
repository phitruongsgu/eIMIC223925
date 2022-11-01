﻿using Microsoft.AspNetCore.Identity;
using System;

namespace eIMIC223925.DATA.Entities
{
    public class AppRole : IdentityRole<Guid>
    {
        public string Description { get; set; }
    }
}
