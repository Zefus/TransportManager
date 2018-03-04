using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportManager.DataAccess.Infrastructure.Helpers
{
    internal class InternalHelper
    {
        internal static Task CompletedTask { get; } = Task.FromResult(1);
    }
}
