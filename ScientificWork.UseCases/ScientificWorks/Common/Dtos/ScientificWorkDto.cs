﻿using ScientificWork.Domain.ScientificWorks.Enums;

namespace ScientificWork.UseCases.ScientificWorks.Common.Dtos;

public class ScientificWorkDto
{
    public Guid Id { get; init; }

    public string Name { get; init; }

    public string Description { get; init; }

    public Guid? ProfessorId { get; init; }

    public int Limit { get; init; }

    public int Fullness { get; init; }

    public bool IsFavorite { get; set; }

    public bool CanJoin { get; set; }

    public IList<string> ScientificInterests { get; init; }

    public WorkStatus WorkStatus { get; init; }
}
