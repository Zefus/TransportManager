﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportManager.DataAccess.Operations
{
    public interface IRemoveUserOperation
    {
        Task<bool> ExecuteAsync(params object[] keyValues);
    }
}
