using contasoft_api.Data;
using contasoft_api.DTOs.Inputs;
using contasoft_api.DTOs.Outputs;
using contasoft_api.DTOs;
using contasoft_api.Interfaces;
using contasoft_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace contasoft_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class O607Controller : ControllerBase
    {
        private readonly ContaSoftDbContext _context;
        private readonly IGenerador607 _generador607;

        public O607Controller(ContaSoftDbContext context, IGenerador607 generador607)
        {
            _context = context;
            _generador607 = generador607;
        }

        [HttpGet("invoice607/{companyID}")]
        public async Task<IActionResult> GetAllInvoice607ByCompany(int companyID)
        {

            var response = new DefaultResponse();
            var ListaDeFacturas = new List<Invoice607>();
            if (_context.O607 == null)
            {
                return NotFound();
            }

            try
            {
                var Operacion607 = await _context.O607.Where(x => x.CompanyId == companyID).ToListAsync();

                foreach (var maestro in Operacion607)
                {
                    var facturas = await _context.Invoice607
                        .Where(x => x.O607Id == maestro.Id && x.Deleted == false)
                        .ToListAsync();


                    ListaDeFacturas.AddRange(facturas);
                }

                response.Data = ListaDeFacturas;
                response.Message = "Success";
                response.StatusCode = 1;
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = "Error al obtener las facturas.";
                response.StatusCode = 0;
                response.Success = false;

            }
            return Ok(response);
        }

        [HttpPost("invoice607")]
        public async Task<IActionResult> CreateInvoice607(Invoice607Input input)
        {
            var response = new DefaultResponse();
            var anomesFactura = DateTime.Parse(input.FechaComprobante).ToString("yyyy/MM");
            var Operacion607 = new O607();
            if (_context.O607 == null)
            {
                return NotFound();
            }
            try
            {
                VerificarPropiedadesNulas(input);
                var company = await _context.Company.FindAsync(input.CompanyID);
                Operacion607 = await _context.O607.Where(x => x.CompanyId == company.Id && x.YearMonth == anomesFactura).OrderBy(x => x.Id).FirstOrDefaultAsync();


                if (Operacion607 == null)
                {
                    Operacion607 = new O607();
                    Operacion607.YearMonth = anomesFactura;

                    Operacion607.RNC = company.RNC;
                    Operacion607.CompanyId = (int)input.CompanyID;
                    Operacion607.Name = $@"607-{company.Name}-{Operacion607.YearMonth.Replace("/", "")}";
                    Operacion607.CreateDate = DateTime.Now;
                    Operacion607.UserCode = "root";
                    Operacion607.IsActive = false;

                    await _context.O607.AddAsync(Operacion607);
                    await _context.SaveChangesAsync();
                }



                Invoice607 Invoice = new Invoice607()
                {
                    RNCCedulaPasaporte = input.RNCCedulaPasaporte,
                    TipoIdentificación = input.TipoIdentificacion,
                    NumeroComprobanteFiscal = input.NumeroComprobanteFiscal,
                    NumeroComprobanteFiscalModificado = input.NumeroComprobanteFiscalModificado,
                    TipoIngreso = input.TipoIngreso,
                    FechaComprobante = input.FechaComprobante,
                    FechaRetención = input.FechaRetencion,
                    MontoFacturado = input.MontoFacturado,
                    ITBISFacturado = input.ITBISFacturado,
                    ITBISRetenidoporTerceros = input.ITBISRetenidoporTerceros,
                    ITBISPercibido = input.ITBISPercibido,
                    RetenciónRentaporTerceros = input.RetencionRentaporTerceros,
                    ISRPercibido = input.ITBISPercibido,
                    ImpuestoSelectivoalConsumo = input.ImpuestoSelectivoalConsumo,
                    OtrosImpuestos_Tasas = input.OtrosImpuestos_Tasas,
                    MontoPropinaLegal = input.MontoPropinaLegal,
                    Efectivo = input.Efectivo,
                    Cheque_Transferencia_Depósito = input.Cheque_Transferencia_Deposito,
                    TarjetaDébito_Crédito = input.TarjetaDebito_Credito,
                    VentaACrédito = input.VentaACredito,
                    BonosOCertificadosRegalo = input.BonosOCertificadosRegalo,
                    Permuta = input.Permuta,
                    OtrasFormasVentas = input.OtrasFormasVentas,
                    UserCode = "root",
                    CreateDate = DateTime.Now,
                    IsActive = true,
                    Deleted = false,
                    O607Id = Operacion607.Id

                };

                await _context.Invoice607.AddAsync(Invoice);
                await _context.SaveChangesAsync();

                response.Message = "Factura registrada con éxito";
                response.StatusCode = 1;
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = "Error al registrar esta factura.";
                response.StatusCode = 0;
                response.Success = false;

            }
            return Ok(response);
        }


        [HttpGet("607/{companyID}")]
        public async Task<IActionResult> GetAll607ByCompany(int companyID)
        {

            var response = new DefaultResponse();
            var ListaDeFacturas = new List<Invoice607>();
            if (_context.O607 == null)
            {
                return NotFound();
            }

            try
            {
                List<O607Output> result = new List<O607Output>();

                var Operacion607s = await _context.O607.Where(x => x.CompanyId == companyID && x.IsActive).ToListAsync();


                foreach (var Operacion607 in Operacion607s)
                {
                    var totalInvoiced = 0.00m;
                    var ItbisTotal = 0.00m;

                    var Invoices = await _context.Invoice607.Where(x => x.O607Id == Operacion607.Id && x.IsActive && x.Deleted == false).ToListAsync();

                    foreach (var invoice in Invoices)
                    {
                        totalInvoiced += (decimal)invoice.MontoFacturado;
                        ItbisTotal += (decimal)invoice.ITBISFacturado;
                    }

                    O607Output output = new O607Output
                    {
                        Id = Operacion607.Id,
                        Name = Operacion607.Name,
                        YearMonth = Operacion607.YearMonth,
                        Amount = Invoices.Count(),
                        ITBISTotal = ItbisTotal,
                        InvoicedAmount = totalInvoiced,
                        RNC = Operacion607.RNC,
                        IsActive = Operacion607.IsActive,
                        CreateDate = Operacion607.CreateDate,



                    };

                    result.Add(output);

                }

                response.Data = result;
                response.Message = "Success";
                response.StatusCode = 1;
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = "Error al obtener las facturas.";
                response.StatusCode = 0;
                response.Success = false;

            }
            return Ok(response);
        }

        [HttpPost("607")]
        public async Task<IActionResult> Create607(Generar607Input data)
        {
            var response = new DefaultResponse();
            var ListaDeFacturas = new List<Invoice606>();
            if (_context.O606 == null)
            {
                return NotFound();
            }

            try
            {
                var Operacion607 = await _context.O607.Where(x => x.CompanyId == data.CompanyID && x.YearMonth == data.Anomes).FirstOrDefaultAsync();
                var company = await _context.Company.FindAsync(data.CompanyID);

                if (Operacion607 == null)
                {
                    Operacion607 = new O607();
                    Operacion607.RNC = data.RNC;
                    Operacion607.YearMonth = data.Anomes;
                    Operacion607.CompanyId = data.CompanyID;
                    Operacion607.Name = $@"607-{company.Name}-{Operacion607.YearMonth.Replace("/", "")}";
                    Operacion607.CreateDate = DateTime.Now;
                    Operacion607.UserCode = "root";
                    Operacion607.IsActive = true;

                    await _context.O607.AddAsync(Operacion607);
                    await _context.SaveChangesAsync();

                    response.Message = "607 creado con éxito!";
                    response.StatusCode = 1;
                    response.Success = true;
                }
                else
                {
                    if (Operacion607.IsActive)
                    {
                        response.Message = "Este 607 ya existe!";
                        response.StatusCode = 0;
                        response.Success = false;
                    }
                    else
                    {
                        Operacion607.IsActive = true;
                        _context.O607.Update(Operacion607);
                        await _context.SaveChangesAsync();
                        response.Message = "6067 creado con éxito!";
                        response.StatusCode = 1;
                        response.Success = true;
                    }


                }
            }
            catch (Exception ex)
            {
                response.Message = "Error generar el 607.";
                response.StatusCode = 0;
                response.Success = false;

            }
            return Ok(response);
        }

        [HttpPost("descargar/607")]
        public async Task<IActionResult> Descargar607(DescargarInput model)
        {
            var response = new DefaultResponse();
            var ListaDeFacturas = new List<Invoice607>();
            if (_context.O607 == null)
            {
                return NotFound();
            }

            try
            {
                var Operacion607 = await _context.O607.Where(x => x.Id == model.Id && x.IsActive).FirstOrDefaultAsync();


                if (Operacion607 != null)
                {
                    var invoices = await _context.Invoice607.Where(x => x.O607Id == model.Id && x.IsActive).ToListAsync();
                    if (invoices == null)
                    {
                        invoices = new List<Invoice607> { };
                    }
                    if (model.Formato == 23)
                    {
                        try
                        {
                            var document = _generador607.Generate607xlsx(invoices, Operacion607);
                            response.Data = File(document, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", Operacion607.Name + ".xlsx");


                        }
                        catch (Exception r)
                        {

                            throw;
                        }

                    }
                    else if (model.Formato == 19)
                    {

                        string archivo = _generador607.Generador607txt(invoices, Operacion607);
                        response.Data = archivo;
                    }

                }
                else
                {
                    response.Message = $"607 no encontrado id:{model.Id},formato:{model.Formato} ";
                }


                // response.Data = Operacion606;
                response.Message = "607 descargado con éxito!";
                response.StatusCode = 1;
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = $"Error descargar el 607. {ex.Message}";
                response.StatusCode = 0;
                response.Success = false;

            }
            return Ok(response);
        }

        [HttpPut("invoice607/{id}")]
        public async Task<IActionResult> UpdateInvoice607(int id, Invoice607Input input)
        {
            if (id != input.Id)
            {
                return BadRequest();
            }
            var response = new DefaultResponse();
            var anomesFactura = DateTime.Parse(input.FechaComprobante).ToString("yyyy/MM");

            if (_context.Invoice607 == null)
            {
                return NotFound();
            }
            try
            {
                var Operacion606 = await _context.O607.Where(x => x.CompanyId == input.CompanyID && x.YearMonth == anomesFactura).OrderBy(x => x.Id).FirstOrDefaultAsync();
                var invoice = await _context.Invoice607.FindAsync(id);


                try
                {
                    if (invoice != null)
                    {
                        invoice.RNCCedulaPasaporte = input.RNCCedulaPasaporte;
                        invoice.TipoIdentificación = input.TipoIdentificacion;
                        invoice.NumeroComprobanteFiscal = input.NumeroComprobanteFiscal;
                        invoice.NumeroComprobanteFiscalModificado = input.NumeroComprobanteFiscalModificado;
                        invoice.TipoIngreso = input.TipoIngreso;
                        invoice.FechaComprobante = input.FechaComprobante;
                        invoice.FechaRetención = input.FechaRetencion;
                        invoice.MontoFacturado = input.MontoFacturado;
                        invoice.ITBISFacturado = input.ITBISFacturado;
                        invoice.ITBISRetenidoporTerceros = input.ITBISRetenidoporTerceros;
                        invoice.ITBISPercibido = input.ITBISPercibido;
                        invoice.RetenciónRentaporTerceros = input.RetencionRentaporTerceros;
                        invoice.ISRPercibido = input.ITBISPercibido;
                        invoice.ImpuestoSelectivoalConsumo = input.ImpuestoSelectivoalConsumo;
                        invoice.OtrosImpuestos_Tasas = input.OtrosImpuestos_Tasas;
                        invoice.MontoPropinaLegal = input.MontoPropinaLegal;
                        invoice.Efectivo = input.Efectivo;
                        invoice.Cheque_Transferencia_Depósito = input.Cheque_Transferencia_Deposito;
                        invoice.TarjetaDébito_Crédito = input.TarjetaDebito_Credito;
                        invoice.VentaACrédito = input.VentaACredito;
                        invoice.BonosOCertificadosRegalo = input.BonosOCertificadosRegalo;
                        invoice.Permuta = input.Permuta;
                        invoice.OtrasFormasVentas = input.OtrasFormasVentas;
                        invoice.UserCode = "root";
                        invoice.UpdateDate = DateTime.Now;

                        _context.Invoice607.Update(invoice);
                        await _context.SaveChangesAsync();
                    }


                }
                catch (Exception)
                {

                    throw;
                }


                response.Message = "Factura Actualizada con éxito";
                response.StatusCode = 1;
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = "Error al Actualizar esta factura.";
                response.StatusCode = 0;
                response.Success = false;

            }
            return Ok(response);
        }

        [HttpDelete("invoice607/{id}")]
        public async Task<IActionResult> DeleteInvoice607(int id)
        {
            var response = new DefaultResponse();

            try
            {
                var invoice = await _context.Invoice607.FindAsync(id);
                invoice.Deleted = true;
                invoice.UpdateDate = DateTime.Now;
                _context.Invoice607.Update(invoice);
                await _context.SaveChangesAsync();


                response.Message = "Factura Eliminada con éxito";
                response.StatusCode = 1;
                response.Success = true;

            }
            catch (Exception)
            {
                response.Message = "Success";
                response.StatusCode = 1;
                response.Success = true;

            }

            return Ok(response);
        }
        public static void VerificarPropiedadesNulas<T>(T entidad)
        {
            var propiedades = typeof(T).GetProperties();

            foreach (var propiedad in propiedades)
            {

                if (propiedad.PropertyType == typeof(string) && propiedad.GetValue(entidad) == null)
                {
                    propiedad.SetValue(entidad, "");
                }
                else if (propiedad.PropertyType == typeof(int) && propiedad.GetValue(entidad) == null)
                {
                    propiedad.SetValue(entidad, 0);
                }
                else if (propiedad.PropertyType == typeof(decimal) && propiedad.GetValue(entidad) == null)
                {
                    propiedad.SetValue(entidad, 0m);
                }
                else if (propiedad.PropertyType == typeof(double) && propiedad.GetValue(entidad) == null)
                {
                    propiedad.SetValue(entidad, 0.0);
                }
            }
        }
    }
    public class Generar607Input
    {
        public int CompanyID { get; set; }
        public string Anomes { get; set; }
        public string RNC { get; set; }
    }

}
