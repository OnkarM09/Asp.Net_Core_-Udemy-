﻿namespace _12._1_HTTP_client__StockApp_.Models
{
    public class Stock
    {
        public string? StockSymbol { get; set; }
        public double CurrentPrice { get; set; }
        public double LowestPrice { get; set; } 
        public double HighestPrice { get; set; }

        public double OpenPrice { get; set; }
    }
}
