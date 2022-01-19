namespace CQRS.WCF.Concurrency
{
    public interface IConcurrencyAware
    {
        string ConcurrencyVersion { get; set; }
    }
}