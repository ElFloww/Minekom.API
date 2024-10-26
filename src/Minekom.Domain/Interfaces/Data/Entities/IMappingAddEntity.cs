﻿using Minekom.Domain.Bo;

namespace Minekom.Domain.Interfaces.Data.Entities;

/// <summary>
/// Object for map Entity between BO and DTO Entity
/// </summary>
/// <typeparam name="T"></typeparam>
/// <typeparam name="TT"></typeparam>
public interface IMappingAddEntity<out T, out TT>
    where T : class, IBOEntity
    where TT : class, IEntity
{
    /// <summary>
    /// Get set BO Entity
    /// </summary>
    T BoEntity { get; }

    /// <summary>
    /// Get set DTO Entity
    /// </summary>
    TT DtoEntity { get; }

    /// <summary>
    /// Get set BO Entity from DTO with mapping
    /// </summary>
    T MapBoEntity { get; }

    /// <summary>
    /// Get set DTO Entity from BO with mapping
    /// </summary>
    TT MapDtoEntity { get; }
}