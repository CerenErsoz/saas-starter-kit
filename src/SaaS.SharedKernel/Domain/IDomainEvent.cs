namespace SaaS.SharedKernel.Domain;

public interface IDomainEvent
{
    DateTime OccurredOn { get; }
}