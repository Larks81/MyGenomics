using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.VisualBasic.FileIO;
using MyGenomics.Data.Context;
using MyGenomics.DataModel;
using System.Data.Entity;
using MyGenomics.DomainModel;

namespace MyGenomics.Services.Services
{
    public class SnpService
    {
        private const int _maxItemInPage = 10;

        public SearchList<DomainModel.SnpItemList> GetSnps(int panelId, int? page)
        {
            var result = new SearchList<DomainModel.SnpItemList>();
            var maxItemInPage = _maxItemInPage;

            using (var context = new MyGenomicsContext())
            {
                if (panelId>0)
                {
                    result.TotRec = context.Snps.Count(p => p.PanelId == panelId);

                    if (!page.HasValue)
                    {
                        maxItemInPage = result.TotRec;
                        page = 1;
                    }

                    result.CurrentPage = page.Value;                    
                    result.TotPag = (int)Math.Ceiling((decimal)result.TotRec / (decimal)maxItemInPage);

                    result.Results = context.Snps
                        .OrderBy(o => o.Id)
                        .Skip(maxItemInPage * (page.Value - 1)).Take(maxItemInPage)
                        .Where(s => s.PanelId == panelId)
                        .Select(p => new DomainModel.SnpItemList()
                        {
                            Id = p.Id,
                            Gene = p.Gene,
                            Allelerisk = p.Allelerisk,
                            OR_Beta = p.OR_Beta,
                            P_value = p.P_value,
                            SNPCode = p.SNPCode
                        })
                        .ToList();
                }
                
            }
            return result;
        }


        public int ImportSnpsFromCsv(string csvContent, int panelId)
        {
            var snps = ReadSnpsFromCsv(csvContent);
            AddRangeSnp(snps, panelId);
            return snps.Count();
        }

        public void AddRangeSnp(List<DomainModel.SnpDetail> snps, int panelId)
        {

            var snpMapped = Mapper.Map<List<DomainModel.SnpDetail>, List<DataModel.Snp>>(snps);            

            using (var context = new MyGenomicsContext())
            {
                var panel = context.Panels
                    .Include(i => i.Snps)
                    .FirstOrDefault(p => p.Id == panelId);

                if (panel != null)
                {
                    context.Snps.RemoveRange(context.Snps.Where(s => s.PanelId == panelId));
                    panel.Snps.AddRange(snpMapped);
                    context.SaveChanges();
                }

            }
        }

        public List<DomainModel.SnpDetail> ReadSnpsFromCsv(string csvContent)
        {

            var parser = new TextFieldParser(new StringReader(csvContent));

            parser.HasFieldsEnclosedInQuotes = true;
            parser.SetDelimiters(",");

            var snps = new List<DomainModel.SnpDetail>();

            bool isFirstLine = true;
            while (!parser.EndOfData)
            {
                var row = parser.ReadFields();
                if (isFirstLine)
                {
                    isFirstLine = false;
                }
                else
                {
                    snps.Add(new DomainModel.SnpDetail()
                    {                        
                        SNPCode = row[0],
                        Gene = row[1],
                        Allelerisk = row[2],
                        OR_Beta = Convert.ToDouble(row[3]),
                        P_value = Convert.ToDouble(row[5]),
                        CC = Convert.ToDouble(row[6]),
                        CT = Convert.ToDouble(row[7]),
                        TC = Convert.ToDouble(row[8]),
                        TT = Convert.ToDouble(row[9]),
                        AA = Convert.ToDouble(row[10]),
                        AG = Convert.ToDouble(row[11]),
                        GA = Convert.ToDouble(row[12]),
                        GG = Convert.ToDouble(row[13]),
                        CG = Convert.ToDouble(row[14]),
                        GC = Convert.ToDouble(row[15]),
                        AC = Convert.ToDouble(row[16]),
                        CA = Convert.ToDouble(row[17]),
                        GT = Convert.ToDouble(row[18]),
                        TG = Convert.ToDouble(row[19]),
                        AT = Convert.ToDouble(row[20]),
                        TA = Convert.ToDouble(row[21])
                    });
                }
                
            }

            parser.Close();
            return snps;
        }
    }
}