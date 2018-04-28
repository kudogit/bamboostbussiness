using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bamboo.Data.EF
{
    public class RoleEntity : IdentityRole<int>
    {
        public string Description { get; set; }
    }
}
