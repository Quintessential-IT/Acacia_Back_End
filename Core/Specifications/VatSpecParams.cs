﻿namespace Acacia_Back_End.Core.Specifications
{
    public class VatSpecParams
    {
        private const int MaxPageSize = 50;

        public int PageIndex { get; set; } = 1;

        private int _pageSize = 6;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }

        public bool? IsActive { get; set; }

        public string sort { get; set; }
    }
}
