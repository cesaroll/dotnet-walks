using FluentValidation;
using Walks.API.Models.DTOs.Requests;

namespace Walks.API.Validators;

public class MutateWalkRequestValidator : AbstractValidator<MutateWalkRequest>
{
    public MutateWalkRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Length).GreaterThan(0);
    }
}