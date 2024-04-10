using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Masterzdran.RestApi.Extensions.Models
{
    public sealed class ApiPaging
    {
        private int _pagenumber;
        private int _pagesize;
        private readonly short _defaultPageSize = 20;
        private readonly short _defaultPage = 0;
        private readonly short _maxPageSize = 50;

        public ApiPaging()
        {
            _pagenumber = _defaultPage;
            _pagesize = _defaultPageSize;
        }

        /// <summary>
        /// Number of the page you want to return. It is a Zero based index. Default is page 0.
        /// </summary>
        public int PageNumber
        {
            get { return _pagenumber; }
            set { _pagenumber = (value < _defaultPage) ? _defaultPage : value; }
        }
        /// <summary>
        /// Number of items you want to return in a page. Default is 20 items per page.
        /// </summary>
        public int PageSize
        {
            get { return _pagesize; }
            set
            {
                if (value <= 0 || value > _maxPageSize)
                {
                    _pagesize = _defaultPageSize;
                }
                else
                {
                    _pagesize = value;
                }
            }
        }
        /// <summary>
        /// Index of the first item of the page.
        /// </summary>
        public int FirstRecord
        {
            get
            {
                int recordNumber = _pagenumber * _pagesize;
                return recordNumber;

            }
        }

        /// <summary>
        /// Name of the field you want to order by.
        /// </summary>
        public string OrderedField { get; set; }
        /// <summary>
        /// Define which order should the results be returned.
        /// </summary>
        public ApiPagingOrdered OrderedBy { get; set; }
    }
}
