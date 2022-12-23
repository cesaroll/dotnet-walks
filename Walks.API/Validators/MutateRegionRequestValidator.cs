using System.Data;
using FluentValidation;
using Walks.API.Models.DTOs.Requests;

namespace Walks.API.Validators;

public class MutateRegionRequestValidator : AbstractValidator<MutateRegionRequest>
{
    public MutateRegionRequestValidator()
    {
        RuleFor(x => x.Code).NotEmpty();
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Area).GreaterThan(0);
        RuleFor(x => x.Population).GreaterThanOrEqualTo(0);
    }
}