using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MyGenomics.Data.Context;

namespace MyGenomics.Services.Services
{
    public class LogService
    {
        public void InsertLog(DomainModel.WebApiLog log)
        {
            using (var context = new MyGenomicsContext())
            {
                var logData = Mapper.Map<DomainModel.WebApiLog, DataModel.WebApiLog>(log);
                if (logData != null)
                {
                    context.WebApiLogs.Add(logData);
                    context.SaveChanges();
                }
                    
            }
            
        }
    }
}
