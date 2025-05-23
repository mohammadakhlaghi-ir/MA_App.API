using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA_App.Domain.Entities
{
    public class Layout
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public bool Main { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime? ModifyDate { get; set; }
        public Guid? Creator { get; set; }
        public Guid? Modifier { get; set; }
        public string? Description { get; set; }

        public ICollection<SectionLayout> SectionLayouts { get; set; } = new List<SectionLayout>();
    }
}
