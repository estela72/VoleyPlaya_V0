﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Application.Contracts.Persistence;

public interface IUnitOfWork : IDisposable
{
    Task<int> Complete();
}
