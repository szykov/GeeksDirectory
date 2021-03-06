﻿using System;

namespace GeeksDirectory.Domain.Classes
{
    public class QueryOptions
    {
        public string? Query { get; set; }

        public int Limit { get; set; } = 16;

        public int Offset { get; set; } = 0;

        public string? OrderBy { get; set; }

        public OrderDirection OrderDirection { get; set; } = OrderDirection.Asc;

        internal QueryOptions() { }

        public bool IsSortable()
        {
            return !String.IsNullOrEmpty(this.OrderBy);
        }
    }
}
