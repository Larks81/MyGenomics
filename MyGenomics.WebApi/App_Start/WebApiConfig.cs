using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;
using MyGenomics.Data.Context;

namespace MyGenomics
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Per abilitare il supporto query per le azioni con tipo restituito IQueryable o IQueryable<T>, rimuovere il commento dalla seguente riga di codice.
            // Per evitare l'elaborazione di query dannose o impreviste, utilizzare le impostazioni di convalida definite in QueryableAttribute per convalidare le query in ingresso.
            // Per ulteriori informazioni, visitare il sito Web all'indirizzo http://go.microsoft.com/fwlink/?LinkId=279712.
            //config.EnableQuerySupport();

            // Per disabilitare la funzionalità di traccia nell'applicazione, impostare come commento o rimuovere la seguente riga di codice
            // Per ulteriori informazioni, visitare: http://www.asp.net/web-api
            //config.EnableSystemDiagnosticsTracing();

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MyGenomicsContext,MyGenomics.Data.Migrations.Configuration>());
            //config.EnableSystemDiagnosticsTracing();
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
        }
    }
}
