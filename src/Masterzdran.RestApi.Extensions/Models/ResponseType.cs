using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Masterzdran.RestApi.Extensions.Models
{
    public sealed class ResponseType<T> where T : class
    {
        public int TotalNumberOfRecords { get; set; }
        public IEnumerable<T> Results { get; set; }
        public bool HasErrors { get { return NumberOfErrors != 0; } }
        public int NumberOfErrors { get { return Errors.Count(); } }
        public IEnumerable<string> Errors { get; set; }


        public ResponseType()
        {
            TotalNumberOfRecords = 0;
            Results = new List<T>();
            Errors = new List<string>();
        }
    }
}
