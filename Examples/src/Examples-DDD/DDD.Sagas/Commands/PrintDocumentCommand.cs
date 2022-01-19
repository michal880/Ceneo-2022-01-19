namespace DDD.Sagas.Commands
{
  public class PrintDocumentCommand : ICommand
  {
    public string DocumentId { get; set; }

    public PrintDocumentCommand(string documentId)
    {
      DocumentId = documentId;
    }

    public string CorrelationId { get; set; }
  }
}