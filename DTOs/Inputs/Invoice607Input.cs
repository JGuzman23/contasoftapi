namespace contasoft_api.DTOs.Inputs
{
    public class Invoice607Input
    {
        public int Id { get; set; }
        public string? RNCCedulaPasaporte { get; set; }
        public string? TipoIdentificación { get; set; }
        public string? NumeroComprobanteFiscal { get; set; }
        public string? NumeroComprobanteFiscalModificado { get; set; }
        public string? TipoIngreso { get; set; }
        public string? FechaComprobante { get; set; }
        public string? FechaRetención { get; set; }
        public string? MontoFacturado { get; set; }
        public string? ITBISFacturado { get; set; }
        public string? ITBISRetenidoporTerceros { get; set; }
        public string? ITBISPercibido { get; set; }
        public string? RetenciónRentaporTerceros { get; set; }
        public string? ISRPercibido { get; set; }
        public string? ImpuestoSelectivoalConsumo { get; set; }
        public string? OtrosImpuestos_Tasas { get; set; }
        public string? MontoPropinaLegal { get; set; }
        public string? Efectivo { get; set; }
        public string? Cheque_Transferencia_Depósito { get; set; }
        public string? TarjetaDébito_Crédito { get; set; }
        public string? VentaACrédito { get; set; }
        public string? BonosOCertificadosRegalo { get; set; }
        public string? Permuta { get; set; }
        public string? OtrasFormasVentas { get; set; }
        public int CompanyID { get; set; }

    }
}
