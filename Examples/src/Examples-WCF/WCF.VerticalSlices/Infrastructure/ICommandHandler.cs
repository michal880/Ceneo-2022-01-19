namespace WCF.VerticalSlices.Infrastructure
{
  internal interface ICommandHandler<in T>
  {
    void Handle(T request);
  }
}