﻿using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ScientificWork.Domain.Professors;
using ScientificWork.Domain.Requests;
using ScientificWork.Domain.Requests.Enums;
using ScientificWork.Domain.Students;
using ScientificWork.Infrastructure.Abstractions.Interfaces;

namespace ScientificWork.UseCases.Requests.RequestToOrFromProfessor;

public class RequestToOrFromProfessorCommandHandler : IRequestHandler<RequestToOrFromProfessorCommand>
{
    private readonly UserManager<Student> studentManager;
    private readonly UserManager<Professor> professorManager;
    private readonly IAppDbContext dbContext;

    /// <summary>
    /// Constructor.
    /// </summary>
    public RequestToOrFromProfessorCommandHandler(UserManager<Student> studentManager,
        UserManager<Professor> professorManager, IAppDbContext dbContext)
    {
        this.studentManager = studentManager;
        this.professorManager = professorManager;
        this.dbContext = dbContext;
    }

    public async Task Handle(RequestToOrFromProfessorCommand request, CancellationToken cancellationToken)
    {
        var professor = await professorManager.FindByIdAsync(request.ProfessorId.ToString());
        var student = await studentManager.FindByIdAsync(request.StudentId.ToString());
        var scientificWork = await dbContext.ScientificWorks
            .Include(sw => sw.Students)
            .FirstOrDefaultAsync(x => x.Id == request.ScientificWorkId, cancellationToken);

        if (professor == null)
        {
            throw new Exception($"Не существует профессора с id: {request.ProfessorId}");
        }

        if (student == null)
        {
            throw new Exception($"Не существует студента с id: {request.StudentId}");
        }

        if (scientificWork == null)
        {
            throw new Exception($"Не существует иследования с id: {request.ScientificWorkId}");
        }

        // Разве заявку не должен создавать только участник (ну или создатель)?
        //
        // if (request.RequestEnum is RequestEnum.FromProfessor)
        // {
        //     if (scientificWork.ProfessorId != request.ProfessorId)
        //         throw new DomainException("Вы не являетесь профессором в этой научной работе");
        // }
        // else if (request.RequestEnum is RequestEnum.FromStudent)
        // {
        //     if (scientificWork.Students.All(s => s.Id != request.StudentId))
        //         throw new DomainException("Вы не являетесь участником этой научной работы");
        // }
        // else
        // {
        //     throw new NotImplementedException();
        // }

        var r = new StudentRequestProfessor(professor, professor.Id, student, student.Id, scientificWork,
            scientificWork.Id, request.RequestEnum, GetMessage(request.RequestEnum, scientificWork));

        await dbContext.StudentRequestProfessors.AddAsync(r, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    private string GetMessage(RequestEnum requestEnum, Domain.ScientificWorks.ScientificWork scientificWork)
    {
        var messages = new List<KeyValuePair<bool, string>>
        {
            new(
                requestEnum == RequestEnum.FromProfessor && scientificWork.Professor != null &&
                scientificWork.Limit > 1,
                "Вас приглашают в команду"
            ),
            new(
                requestEnum == RequestEnum.FromProfessor && scientificWork.Professor != null &&
                scientificWork.Limit == 1,
                "Вам предложили тему"
            ),
            new(
                requestEnum == RequestEnum.FromProfessor && scientificWork.Professor == null,
                "Над Вашим исследованием хотят поработать"
            ),
            new(
                requestEnum == RequestEnum.FromStudent && scientificWork.Professor == null,
                "Вам предложили тему"
            ),
            new(
                requestEnum == RequestEnum.FromStudent && scientificWork.Professor != null,
                $"Студент хочет попасть в научную работу : {scientificWork.Name}"
            )
        };
        return messages.FirstOrDefault(x => x.Key).Value;
    }
}