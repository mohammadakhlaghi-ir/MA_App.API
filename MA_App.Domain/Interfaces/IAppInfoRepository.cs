using MA_App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA_App.Domain.Interfaces
{
    public interface IAppInfoRepository
    {
        Task<AppInfo> GetAppInfoAsync();
    }
}
