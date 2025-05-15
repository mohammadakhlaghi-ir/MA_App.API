using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA_App.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string UserName { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? Image { get; set; } = default!;
        public DateTime DateOfBirth { get; set; } = default!;
        public DateTime Created { get; set; } = default!;
        public Guid? Creator { get; set; }
        public bool IsDeleted { get; set; } = default!;
        public bool IsLock { get; set; } = default!;
        public string Email { get; set; } = default!;
        public DateTime? ModifyDate { get; set; }
        public Guid? Modifier { get; set; }
        public string? Description { get; set; }
    }
}
