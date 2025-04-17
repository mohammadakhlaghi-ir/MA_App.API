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
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string UserName { get; set; } = default!;
        [Required]
        [StringLength(100, MinimumLength = 6)]
        public string Password { get; set; } = default!;
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = default!;
        [Required]
        [StringLength(50)]
        public string LastName { get; set; } = default!;
        [StringLength(20)]
        public string? PhoneNumber { get; set; }
        [StringLength(200)]
        public string? Address { get; set; }
        public string? Image { get; set; } = default!;
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; } = default!;
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Created { get; set; } = default!;
        public Guid? Creator { get; set; }
        [Required]
        public bool IsDeleted { get; set; } = default!;
        [Required]
        public bool IsLock { get; set; } = default!;
        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; } = default!;
        [DataType(DataType.DateTime)]
        public DateTime? ModifyDate { get; set; }
        public Guid? Modifier { get; set; }
        [StringLength(200)]
        public string? Description { get; set; }
    }
}
