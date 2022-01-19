namespace CQRS.RestApi.Concurrency
{
    public interface IConcurrencyAware
    {
        string ConcurrencyVersion { get; set; }
    }
}