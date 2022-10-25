﻿using LemadDb.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemadDb.Domain.User
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Cellphone { get; set; }

        // nav
        public IEnumerable<AddressUser> CivicAddresses { get; set; }
        public IEnumerable<Command> Commands { get; set; }
    }
}
