using FluentValidation;
using Walks.API.Models.DTOs.Requests;

namespace Walks.API.Validators;

public class MutateWalkDifficultyRequestValidator : AbstractValidator<MutateWalkDifficultyRequest>
{
    public MutateWalkDifficultyRequestValidator()
    {
        RuleFor(x => x.Code).NotEmpty();
    }
}