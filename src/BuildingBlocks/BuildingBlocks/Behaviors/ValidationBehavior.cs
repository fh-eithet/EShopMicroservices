

using BuildingBlocks.CQRS;
using FluentValidation;
using MediatR;

namespace BuildingBlocks.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators) 
        : IPipelineBehavior<TRequest, TResponse>
    where TRequest : ICommand<TResponse>
    where TResponse : notnull
    {
        public async Task<TResponse> Handle(
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            // Here you can add validation logic for the request
            // For example, using FluentValidation or any other validation library
            // Call the next delegate/middleware in the pipeline

            var context = new ValidationContext<TRequest>(request);
            var validatonResults = await Task.WhenAll(validators.Select(v => v.ValidateAsync(context, cancellationToken))); 
            
            var failures = validatonResults
                .Where(r => r.Errors.Any())
                .SelectMany(r => r.Errors)
                .ToList();

            if ( (failures.Any()))
            {
                throw new ValidationException(failures);
              
            }
            return await next();
        }
    }
}
