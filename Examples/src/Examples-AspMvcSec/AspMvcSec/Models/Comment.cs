using System;
using System.Web.Mvc;

namespace AspMvcSec.Models
{
  public class Comment
  {
    public DateTime Date { get; set; } = DateTime.Now;
    public string Who { get; set; }
    //// XSS
    [AllowHtml]
    public string Text { get; set; }

  }
}