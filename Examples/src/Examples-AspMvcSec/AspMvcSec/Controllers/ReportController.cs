using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace AspMvcSec.Controllers
{
  public class CspReportRequest
  {
    [JsonProperty(PropertyName = "csp-report")]
    public CspReport CspReport { get; set; }
  }

  public class CspReport
  {
    [JsonProperty(PropertyName = "document-uri")]
    public string DocumentUri { get; set; }

    [JsonProperty(PropertyName = "referrer")]
    public string Referrer { get; set; }

    [JsonProperty(PropertyName = "violated-directive")]
    public string ViolatedDirective { get; set; }

    [JsonProperty(PropertyName = "effective-directive")]
    public string EffectiveDirective { get; set; }

    [JsonProperty(PropertyName = "original-policy")]
    public string OriginalPolicy { get; set; }

    [JsonProperty(PropertyName = "blocked-uri")]
    public string BlockedUri { get; set; }

    [JsonProperty(PropertyName = "status-code")]
    public int StatusCode { get; set; }
  }

  public class ReportController : Controller
  {
    // GET: Report
    public ActionResult Index(CspReportRequest request)
    {
      Request.InputStream.Position = 0;
      using (StreamReader inputStream = new StreamReader(Request.InputStream))
      {
        string s = inputStream.ReadToEnd();
        if (!string.IsNullOrWhiteSpace(s))
        {
          CspReportRequest cspPost = JsonConvert.DeserializeObject<CspReportRequest>(s);
          //now you can access properties of cspPost.CspReport
          
        }
      }

      return base.Json(new { });
    }
  }
}