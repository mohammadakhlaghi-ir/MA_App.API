using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA_App.Application.AppInfos.DTOs
{
    public class AppInfoDto
    {
        public string Title { get; set; } = default!;
        public string? Description { get; set; }
        public string Favicon { get; set; } = default!;
        public string Logo { get; set; } = default!;
        public string Language { get; set; } = default!;
        public string Created { get; set; } = default!;
        public string? ModifyDate { get; set; }
    }
}
