﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Shared.Domain.Helper
{
    public interface IAggregateRoot
    {
        Guid Id { get; }
    }
}
