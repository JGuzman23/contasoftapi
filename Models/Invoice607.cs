namespace contasoft_api.Models
{
    public class Invoice607 : AuditLog
    {
        public int Id { get; set; }
        public string? RNCCedulaPasaporte { get; set; }
        public int? TipoIdentificación { get; set; }
        public string? NumeroComprobanteFiscal { get; set; }
        public string? NumeroComprobanteFiscalModificado { get; set; }
        public int? TipoIngreso { get; set; }
        public string? FechaComprobante { get; set; }
        public string? FechaRetención { get; set; }
        public decimal? MontoFacturado { get; set; }
        public decimal? ITBISFacturado { get; set; }
        public decimal? ITBISRetenidoporTerceros { get; set; }
        public decimal? ITBISPercibido { get; set; }
        public decimal? RetenciónRentaporTerceros { get; set; }
        public decimal? ISRPercibido { get; set; }
        public decimal? ImpuestoSelectivoalConsumo { get; set; }
        public decimal? OtrosImpuestos_Tasas { get; set; }
        public decimal? MontoPropinaLegal { get; set; }
        public decimal? Efectivo { get; set; }
        public decimal? Cheque_Transferencia_Depósito { get; set; }
        public decimal? TarjetaDébito_Crédito { get; set; }
        public decimal? VentaACrédito { get; set; }
        public decimal? BonosOCertificadosRegalo { get; set; }
        public decimal? Permuta { get; set; }
        public decimal? OtrasFormasVentas { get; set; }
        public int? O607Id { get; set; }
        public bool Deleted { get; set; }
        public string? Status { get; set; }
        public virtual O607 O607 { get; set; }
    }
}
