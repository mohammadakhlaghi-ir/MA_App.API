using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA_App.Domain.Entities
{
    public class ItemLayoutType
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }

        public ICollection<SectionItemLayout> SectionItemLayouts { get; set; } = new List<SectionItemLayout>();
    }
}
