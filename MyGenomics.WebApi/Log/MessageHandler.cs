using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using MyGenomics.Services.Services;

namespace MyGenomics.Log
{
    public class MessageHandler : DelegatingHandler
    {
        private LogService _logService = new LogService();

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            string requestMessage = "";
            string responseMessage = "";

            var stopWatch = new Stopwatch();
            stopWatch.Start();
            try
            {
                requestMessage = SafeReadContentFrom(request);
            }catch{}

            var response = await base.SendAsync(request, cancellationToken);

            try
            {
                responseMessage = response.Content.ReadAsStringAsync().Result;
            }
            catch{}


            Task.Factory.StartNew(() =>
                                  {
                                      var webApiLog = new DomainModel.WebApiLog();
                                      webApiLog.HttpVerb = request.Method.Method;
                                      webApiLog.Date = DateTime.Now;
                                      webApiLog.RequestUri = request.RequestUri.AbsoluteUri;

                                      if (response.IsSuccessStatusCode)
                                      {
                                          webApiLog.ResponseBody = responseMessage;
                                      }
                                      else
                                      {
                                          webApiLog.Exception = responseMessage;
                                      }

                                      webApiLog.RequestBody = requestMessage;
                                      webApiLog.Status = response.StatusCode.ToString();

                                      stopWatch.Stop();
                                      webApiLog.Duration = stopWatch.ElapsedMilliseconds;
                                      _logService.InsertLog(webApiLog);
                                  });
            return response;
        }
       
        private string SafeReadContentFrom(HttpRequestMessage request)
        {
            var contentType = request.Content.Headers.ContentType;
            var contentInString = request.Content.ReadAsStringAsync().Result;
            request.Content = new StringContent(contentInString);
            request.Content.Headers.ContentType = contentType;
            return contentInString;
        }
    }

         
}