﻿namespace Reports.DAL.Entities
{
    public class QueryParameters
    {
        private const int MaxPageSize = 50;
        private int _pageSize = 5;
        public int PageNumber { get; set; } = 1;
        public string Name { get; set; } = string.Empty;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }
    }
}