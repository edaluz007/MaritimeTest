using MaritimeTest.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MaritimeTest.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class RangesController : ControllerBase {

        private readonly ILogger<RangesController> _logger;
        private readonly SIDbContext _context;

        public RangesController(ILogger<RangesController> logger, SIDbContext context) {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public Entities.Range Get() {  
            var range = new Entities.Range();
            var ranges = _context.Set<Entities.Range>().ToList();
            if (ranges == null) {
                var path = @"C:\Users\EzequielDaluz\Downloads\SampleData.csv";
                ranges = ReadCsvData(path);
            }

            int total = ranges.Count();
            int sumTotal = 0;
            foreach (var item in ranges) {
                sumTotal += (int)item.Value;
            }
            float average = sumTotal / total;

            double[] vs = new double[total];
            int va = 2;
            double sum = 0;
            foreach (var item in ranges) {
                var rest = (double)average - item.Value;
                double exp = Math.Pow(rest, va);
                sum += exp;
            }
            var sia = (int)sum / total;
            range.Avarage = average;
            range.Deviation = Math.Pow(sia, 0);

            return range;
        }
        public List<Entities.Range> ReadCsvData(string path) {
            List<Entities.Range> ranges = new();
            string[] lines = System.IO.File.ReadAllLines(path);
            foreach (string line in lines) {
                string[] columns = line.Split(',');
                foreach (string column in columns) {
                    ranges.Add(new Entities.Range { 
                        Value = float.Parse(column)
                    });
                }
            }
            foreach (var item in ranges) {
                var lalo = _context.Set<Entities.Range>().Add(item);
            }
            _context.SaveChanges();
            return ranges;

        }
    }
}
