﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CleanArchitectureCQRS.Domain.Library.Base.Domain.Entities;

/// Ref: Coverience in C#
/// <summary>
/// Interface for Base Entity
/// </summary>
/// <typeparam name="TKey"></typeparam>
public interface IBaseEntity<out TKey>
{
    TKey Id { get; }
}
