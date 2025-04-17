using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA_App.Domain.Entities
{
    public class AppInfo
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Title { get; set; } = default!;
        [StringLength(200)]
        public string? Description { get; set; } =default!;
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Created { get; set; } = DateTime.Now;
        [DataType(DataType.DateTime)]
        public DateTime? ModifyDate { get; set; }
        public Guid? Modifier { get; set; }
        [Required]
        public string Logo { get; set; } = default!;
        [Required]
        public string Favicon { get; set; } = default!;
        [Required]
        public string Language { get; set; } = default!;
    }
}
