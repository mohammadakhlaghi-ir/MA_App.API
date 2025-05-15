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
        public string Title { get; set; } = default!;
        public string? Description { get; set; } = default!;
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime? ModifyDate { get; set; }
        public Guid? Modifier { get; set; }
        public string Logo { get; set; } = default!;
        public string Favicon { get; set; } = default!;
        public string Language { get; set; } = default!;
        public string Version { get; set; } = default!;
    }
}
