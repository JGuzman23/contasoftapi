namespace contasoft_api.Models
{
    public class Invoice606 : AuditLog
    {
        public int Id { get; set; }
        public string? RNCCédulaPasaporte { get; set; }
        public int TipoID { get; set; }
        public int TipoBienesYServiciosComprados { get; set; }
        public string? NumeroComprobanteFiscal { get; set; }
        public string? NumeroComprobanteFiscalModificado { get; set; }
        public string? FechaComprobante { get; set; }
        public string? FechaPago { get; set; }
        public decimal? MontoFacturadoEnServicio { get; set; }
        public decimal? MontoFacturadoEnBienes { get; set; }
        public decimal? TotalMontoFacturado { get; set; }
        public decimal? ITBISFacturado { get; set; }
        public decimal? ITBISRetenido { get; set; }
        public decimal? ITBISSujetoaProporcionalidad { get; set; }
        public decimal? ITBISLlevadoAlCosto { get; set; }
        public decimal? ITBISPorAdelantar { get; set; }
        public decimal? ITBISPersividoEnCompras { get; set; }
        public int? TipoRetencionEnISR { get; set; }
        public decimal? MontoRetencionRenta { get; set; }
        public decimal? IRSPercibidoEnCompras { get; set; }
        public decimal? ImpuestoSelectivoAlConsumo  { get; set; }
        public string? OtrosImpuestosTasa { get; set; }
        public decimal? MontoPropinaLegal { get; set; }
        public int? FormaDePago { get; set; }
        public int O606Id { get; set; }

        public virtual O606 O606 { get; set; }











    }
}
