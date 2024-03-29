﻿using System.ComponentModel.DataAnnotations;

namespace contasoft_api.Models
{
    public class Plan : AuditLog
    {
        public int? ID { get; set; }
        public string? Name { get; set; }
        public string? Period { get; set; }
        public decimal? Price { get; set; }
    }
}
