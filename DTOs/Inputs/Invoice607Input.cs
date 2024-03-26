namespace contasoft_api.DTOs.Inputs
{
    public class Invoice607Input
    {
        public int Id { get; set; }
        public string? RNCCedulaPasaporte { get; set; }
        public int? TipoIdentificacion { get; set; }
        public string? NumeroComprobanteFiscal { get; set; }
        public string? NumeroComprobanteFiscalModificado { get; set; }
        public int? TipoIngreso { get; set; }
        public string? FechaComprobante { get; set; }
        public string? FechaRetencion { get; set; }
        public decimal? MontoFacturado { get; set; }
        public decimal? ITBISFacturado { get; set; }
        public decimal? ITBISRetenidoporTerceros { get; set; }
        public decimal? ITBISPercibido { get; set; }
        public decimal? RetencionRentaporTerceros { get; set; }
        public decimal? ISRPercibido { get; set; }
        public decimal? ImpuestoSelectivoalConsumo { get; set; }
        public decimal? OtrosImpuestos_Tasas { get; set; }
        public decimal? MontoPropinaLegal { get; set; }
        public decimal? Efectivo { get; set; }
        public decimal? Cheque_Transferencia_Deposito { get; set; }
        public decimal? TarjetaDebito_Credito { get; set; }
        public decimal? VentaACredito { get; set; }
        public decimal? BonosOCertificadosRegalo { get; set; }
        public decimal? Permuta { get; set; }
        public decimal? OtrasFormasVentas { get; set; }
  

    }
}
