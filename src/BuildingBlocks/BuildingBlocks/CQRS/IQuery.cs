﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.CQRS
{
    public interface IQuery<out TResponse> : MediatR.IRequest<TResponse>
        where TResponse : notnull
    {
    } 
}
