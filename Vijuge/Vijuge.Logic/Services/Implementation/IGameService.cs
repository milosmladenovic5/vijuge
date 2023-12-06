using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vijuge.Logic.Services.Implementation
{
    public interface IGameService
    {
        Task StartWaitingForOponent(int userId);

    }
}
