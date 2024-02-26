﻿using ScientificWork.Domain.Common;
using ScientificWork.Domain.Professors;

namespace ScientificWork.Domain.ScientificAreas;

/// <summary>
/// Scientific area.
/// </summary>
public class ScientificArea : Entity<Guid>
{
    public string Name { get; private set; }

    private readonly List<ScientificAreaSubsection> scientificAreaSubsections = new();

    public ICollection<ScientificAreaSubsection> ScientificAreaSubsections => scientificAreaSubsections;

    private readonly List<Professor> professors = new();

    public ICollection<Professor> Professors => professors;

    private readonly List<ScientificWorks.ScientificWork> scientificWorks = new();

    public ICollection<ScientificWorks.ScientificWork> ScientificWorks => scientificWorks;
}
