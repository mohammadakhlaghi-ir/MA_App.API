using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA_App.Domain.Entities
{
    public class SectionItemLayout
    {
        public int Id { get; set; }
        public int SectionLayoutId { get; set; }
        public bool IsDeleted { get; set; }
        public bool MobileVisible { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime? ModifyDate { get; set; }
        public Guid? Creator { get; set; }
        public Guid? Modifier { get; set; }
        public int ItemLayoutTypeId { get; set; }
        public string? Description { get; set; }

        public SectionLayout SectionLayout { get; set; } = default!;
        public ItemLayoutType ItemLayoutType { get; set; } = default!;
    }
}
