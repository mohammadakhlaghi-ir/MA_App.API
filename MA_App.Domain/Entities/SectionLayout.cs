using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA_App.Domain.Entities
{
    public class SectionLayout
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public int LayoutId { get; set; }
        public bool IsDeleted { get; set; }
        public bool MobileVisible { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime? ModifyDate { get; set; }
        public Guid? Creator { get; set; }
        public Guid? Modifier { get; set; }
        public byte SectionLayoutTypeId { get; set; }
        public string? Description { get; set; }

        public Layout Layout { get; set; } = default!;
        public SectionLayoutType SectionLayoutType { get; set; } = default!;
        public ICollection<SectionItemLayout> SectionItemLayouts { get; set; } = new List<SectionItemLayout>();
    }
}
