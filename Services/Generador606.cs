using contasoft_api.Models;
using DocumentFormat.OpenXml.Spreadsheet;
using SpreadsheetLight.Drawing;
using SpreadsheetLight;
using contasoft_api.Interfaces;
using System.Reflection;

namespace contasoft_api.Services
{
    public class Generador606 : IGenerador606
    {
        public byte[] Generate606xlsx(List<Invoice606> dataList, O606 data)
        {
            #region Definitions
            //var result = new Result { };
            string msg = default;
            var stream = new MemoryStream();
          
            string basePath = Environment.GetEnvironmentVariable("imagendgii");



            SLDocument sl = new SLDocument();
            SLPicture pic = default;

            //TIPO DOCUMENTOS
            Dictionary<string, int> TipoDocumentos = new Dictionary<string, int>() {
                {"RNC", 1 },
                {"Cédula de Identidad", 2 },
                {"Pasaporte", 3 }
            };

            #endregion

            try
            {



                //NAMING SHEET
                sl.RenameWorksheet(SLDocument.DefaultFirstSheetName, "Herramienta Formato 607");
                //ADDING PIC

                if (Directory.Exists(basePath))
                {
                    byte[] byteList = File.ReadAllBytes(basePath);
                    pic = new SLPicture(byteList, DocumentFormat.OpenXml.Packaging.ImagePartType.Png, false);
                    pic.SetPosition(0, 0);
                    sl.InsertPicture(pic);
                }

                #region Setting SLStyle
                //COLORS
                var green = System.Drawing.Color.FromArgb(0, 128, 0);
                var lightGreen = System.Drawing.Color.FromArgb(204, 255, 204);
                var white = System.Drawing.Color.White;
                var black = System.Drawing.Color.Black;
                var red = System.Drawing.Color.Red;

                //INSTANCES
                var horizontAlignMenteLeft = new SLStyle();
                var styleColumnNo = new SLStyle();
                var styleCellHeader = new SLStyle();
                var styleBackgroundGreen = new SLStyle();
                var styleBackgroundGreenCenter = new SLStyle();
                var styleBackgroundGreenWithoutBorder = new SLStyle();
                var styleBold = new SLStyle();
                var styleCenterMergeCell = new SLStyle();
                var styleOutsideBorder = new SLStyle();
                var styleOutsideBorderCenter = new SLStyle();
                var styleG7 = new SLStyle();


                //SETTINGS
                styleColumnNo.SetHorizontalAlignment(HorizontalAlignmentValues.Center);
                styleColumnNo.SetPatternFill(PatternValues.Solid, lightGreen, black);
                styleColumnNo.SetTopBorder(BorderStyleValues.Thin, black);
                styleColumnNo.SetBottomBorder(BorderStyleValues.Thin, black);
                styleColumnNo.SetLeftBorder(BorderStyleValues.Thin, black);
                styleColumnNo.SetRightBorder(BorderStyleValues.Thin, black);

                styleCellHeader.SetFontColor(white);
                styleCellHeader.SetFontBold(true);
                styleCellHeader.SetWrapText(true);
                styleCellHeader.Font.SetFont("Tahoma", 9);
                styleCellHeader.SetHorizontalAlignment(HorizontalAlignmentValues.Center);
                styleCellHeader.SetVerticalAlignment(VerticalAlignmentValues.Center);
                styleCellHeader.SetPatternFill(PatternValues.Solid, green, white);
                styleCellHeader.SetTopBorder(BorderStyleValues.Thin, black);
                styleCellHeader.SetBottomBorder(BorderStyleValues.Thin, black);
                styleCellHeader.SetLeftBorder(BorderStyleValues.Thin, black);
                styleCellHeader.SetRightBorder(BorderStyleValues.Thin, black);

                styleBackgroundGreen.SetFontColor(white);
                styleBackgroundGreen.SetFontBold(true);
                styleBackgroundGreen.SetPatternFill(PatternValues.Solid, green, white);
                styleBackgroundGreen.SetTopBorder(BorderStyleValues.Thin, black);
                styleBackgroundGreen.SetBottomBorder(BorderStyleValues.Thin, black);
                styleBackgroundGreen.SetLeftBorder(BorderStyleValues.Thin, black);
                styleBackgroundGreen.SetRightBorder(BorderStyleValues.Thin, black);

                styleBackgroundGreenCenter.SetFontColor(white);
                styleBackgroundGreenCenter.SetFontBold(true);
                styleBackgroundGreenCenter.Font.SetFont("Tahoma", 12);
                styleBackgroundGreenCenter.SetPatternFill(PatternValues.Solid, green, white);
                styleBackgroundGreenCenter.SetHorizontalAlignment(HorizontalAlignmentValues.Center);

                styleBold.SetFontBold(true);

                styleCenterMergeCell.SetFontBold(true);
                styleCenterMergeCell.SetHorizontalAlignment(HorizontalAlignmentValues.Center);

                horizontAlignMenteLeft.SetHorizontalAlignment(HorizontalAlignmentValues.Left);
                horizontAlignMenteLeft.SetTopBorder(BorderStyleValues.Thin, black);
                horizontAlignMenteLeft.SetBottomBorder(BorderStyleValues.Thin, black);
                horizontAlignMenteLeft.SetLeftBorder(BorderStyleValues.Thin, black);
                horizontAlignMenteLeft.SetRightBorder(BorderStyleValues.Thin, black);

                styleOutsideBorder.SetTopBorder(BorderStyleValues.Thin, black);
                styleOutsideBorder.SetBottomBorder(BorderStyleValues.Thin, black);
                styleOutsideBorder.SetLeftBorder(BorderStyleValues.Thin, black);
                styleOutsideBorder.SetRightBorder(BorderStyleValues.Thin, black);

                styleOutsideBorderCenter.SetTopBorder(BorderStyleValues.Thin, black);
                styleOutsideBorderCenter.SetBottomBorder(BorderStyleValues.Thin, black);
                styleOutsideBorderCenter.SetLeftBorder(BorderStyleValues.Thin, black);
                styleOutsideBorderCenter.SetRightBorder(BorderStyleValues.Thin, black);
                styleOutsideBorderCenter.SetHorizontalAlignment(HorizontalAlignmentValues.Center);

                styleBackgroundGreenWithoutBorder.SetFontColor(white);
                styleBackgroundGreenWithoutBorder.SetFontBold(true);
                styleBackgroundGreenWithoutBorder.SetPatternFill(PatternValues.Solid, green, white);

                styleG7.SetHorizontalAlignment(HorizontalAlignmentValues.Center);
                styleG7.SetPatternFill(PatternValues.Solid, lightGreen, red);
                styleG7.SetTopBorder(BorderStyleValues.Thin, black);
                styleG7.SetBottomBorder(BorderStyleValues.Thin, black);
                styleG7.SetLeftBorder(BorderStyleValues.Thin, black);
                styleG7.SetRightBorder(BorderStyleValues.Thin, black);
                styleG7.Font.SetFont("Times New Roman", 10);
                styleG7.SetFontColor(red);

                #endregion


                var RNC = data.RNC;
                var periodoValue = data.YearMonth.Replace("/", "");
                var cantidadValue = data.Amount;
                char[] references = "ABCDEFGHIJKLMNOPQRSTUVWXY".ToCharArray();


                #region Adding Rows
                sl.SetCellValue("B1", "Direccion General de Impuestos Internos");
                sl.SetCellValue("B2", "Formato de Envio de Ventas de Bienes y Servicios");
                sl.SetCellValue("B3", "Version 2019.6.2");
                sl.SetCellValue("B4", "RNC o Cédula");
                sl.SetCellValue("B5", "Periodo");
                sl.SetCellValue("B6", "Cantidad");
                sl.SetCellValue("B9", "Detalle");

                sl.SetCellValueNumeric("C4", RNC);
                sl.SetCellValueNumeric("C5", periodoValue);
                sl.SetCellValueNumeric("C6", cantidadValue.ToString());

                sl.SetCellValue("F1", "Herramienta de Distribucion Gratuita");
                sl.SetCellValue("F2", "Derechos Reservados DGII 2018");

                sl.SetCellValue("G6", "Total Errores");
                sl.SetCellValueNumeric("G7", "0");

                //TiposIngresos
                sl.SetCellValue("AA13", "01 - Ingresos por Operaciones(No Financieros)");
                sl.SetCellValue("AA14", "02 - Ingresos Financieros");
                sl.SetCellValue("AA15", "03 - Ingresos Extraordinarios");
                sl.SetCellValue("AA16", "04 - Ingresos por Arrendamientos");
                sl.SetCellValue("AA17", "05 - Ingresos por Venta de Activo Depreciable");
                sl.SetCellValue("AA18", "06 - Otros Ingresos");


                //ROW 10
                for (int i = 0; i < references.Length - 2; i++)
                {
                    string reference = $"{references[i + 1]}10";

                    sl.SetCellValueNumeric(reference, (i + 1).ToString());
                    sl.SetCellStyle(reference, styleCellHeader);
                }

                //ROW 11
                var row11 = new Row { RowIndex = 11 };
                string[] headers11 = { "Líneas", "RNC o Cédula", "Tipo Id", "Tipo Bienes y Servicios Comprados", "NCF", "NCF ó Documento Modificado ", "Fecha Comprobante", "Fecha Pago", "Monto Facturado en Servicios", "Monto Facturado en Bienes", "Total Monto Facturado", "ITBIS Facturado", "ITBIS Retenido", "ITBIS sujeto a Proporcionalidad", "ITBIS llevado al Costo", "ITBIS por adelantar", "ITBIS percibido en compras", "Tipo de Retención en IRS", "Monto Retención Renta", "IRS Percibido en compras", "Impuesto Selectivo al Consumo", "Otros Impuestos/Tasas", "Monto Propina Legar", "Forma de Pago" };

                for (int i = 0; i < references.Length - 1; i++)
                {
                    try
                    {
                        string reference = $"{references[i]}11";
                        sl.SetCellValue(reference, headers11[i]);
                        sl.SetCellStyle(reference, styleCellHeader);
                    }
                    catch (Exception e)
                    {

                        throw;
                    }

                }

                //DATA
                for (int i = 0; i < dataList.Count(); i++)
                {
                    var rowNumber = (i + 12).ToString();
                    var row = new Row { RowIndex = UInt32.Parse(rowNumber) };
                    //ADDING DATA
                    sl.SetCellValueNumeric("A" + rowNumber, (i + 1).ToString());
                    sl.SetCellValue("B" + rowNumber, dataList[i].RNCCedulaPasaporte.ToString().Replace("-", ""));
                    sl.SetCellValueNumeric("C" + rowNumber, dataList[i].TipoID.ToString());

                    var tipobys = TipoBienesyServicios.Where(x=>x.Id == dataList[i].TipoBienesYServiciosComprados).FirstOrDefault();


                    sl.SetCellValue("D" + rowNumber, tipobys.Valor.ToString());
                    sl.SetCellValue("E" + rowNumber, dataList[i].NumeroComprobanteFiscal.ToString());
                    sl.SetCellValueNumeric("F" + rowNumber, dataList[i].NumeroComprobanteFiscalModificado.ToString());
                    sl.SetCellValueNumeric("g" + rowNumber, dataList[i].FechaComprobante.ToString());
                    sl.SetCellValueNumeric("H" + rowNumber, dataList[i].FechaPago.ToString());
                    sl.SetCellValueNumeric("I" + rowNumber, dataList[i].MontoFacturadoEnServicio.ToString());
                    sl.SetCellValueNumeric("J" + rowNumber, dataList[i].MontoFacturadoEnBienes.ToString());
                    sl.SetCellValueNumeric("K" + rowNumber, dataList[i].TotalMontoFacturado.ToString());
                    sl.SetCellValueNumeric("L" + rowNumber, dataList[i].ITBISFacturado.ToString());
                    sl.SetCellValueNumeric("M" + rowNumber, dataList[i].ITBISRetenido.ToString());
                    sl.SetCellValueNumeric("N" + rowNumber, dataList[i].ITBISSujetoaProporcionalidad.ToString());
                    sl.SetCellValueNumeric("O" + rowNumber, dataList[i].ITBISLlevadoAlCosto.ToString());
                    sl.SetCellValueNumeric("P" + rowNumber, dataList[i].ITBISPorAdelantar.ToString());
                    sl.SetCellValueNumeric("Q" + rowNumber, dataList[i].ITBISPersividoEnCompras.ToString());
                    sl.SetCellValueNumeric("R" + rowNumber, dataList[i].TipoRetencionEnISR.ToString());
                    sl.SetCellValueNumeric("S" + rowNumber, dataList[i].MontoRetencionRenta.ToString());
                    sl.SetCellValueNumeric("T" + rowNumber, dataList[i].IRSPercibidoEnCompras.ToString());
                    sl.SetCellValueNumeric("U" + rowNumber, dataList[i].ImpuestoSelectivoAlConsumo.ToString());
                    sl.SetCellValueNumeric("V" + rowNumber, dataList[i].OtrosImpuestosTasa.ToString());
                    sl.SetCellValueNumeric("W" + rowNumber, dataList[i].MontoPropinaLegal.ToString());

                    var formapago = FormaPago.Where(x => x.Id == dataList[i].FormaDePago).FirstOrDefault();

                    sl.SetCellValueNumeric("x" + rowNumber, formapago.Valor.ToString());
                    //SETTING CELL STYLE
                    sl.SetCellStyle("A" + rowNumber, styleColumnNo);
                    sl.SetCellStyle("B" + rowNumber, horizontAlignMenteLeft);
                    sl.SetCellStyle("C" + rowNumber, styleOutsideBorderCenter);
                    sl.SetCellStyle("D" + rowNumber, styleOutsideBorder);
                    sl.SetCellStyle("E" + rowNumber, styleOutsideBorder);
                    sl.SetCellStyle("F" + rowNumber, styleOutsideBorder);
                    sl.SetCellStyle("G" + rowNumber, styleOutsideBorder);
                    sl.SetCellStyle("H" + rowNumber, styleOutsideBorder);
                    sl.SetCellStyle("I" + rowNumber, styleOutsideBorder);
                    sl.SetCellStyle("J" + rowNumber, styleOutsideBorder);
                    sl.SetCellStyle("K" + rowNumber, styleOutsideBorder);
                    sl.SetCellStyle("L" + rowNumber, styleOutsideBorder);
                    sl.SetCellStyle("M" + rowNumber, styleOutsideBorder);
                    sl.SetCellStyle("N" + rowNumber, styleOutsideBorder);
                    sl.SetCellStyle("O" + rowNumber, styleOutsideBorder);
                    sl.SetCellStyle("P" + rowNumber, styleOutsideBorder);
                    sl.SetCellStyle("Q" + rowNumber, styleOutsideBorder);
                    sl.SetCellStyle("R" + rowNumber, styleOutsideBorder);
                    sl.SetCellStyle("S" + rowNumber, styleOutsideBorder);
                    sl.SetCellStyle("T" + rowNumber, styleOutsideBorder);
                    sl.SetCellStyle("U" + rowNumber, styleOutsideBorder);
                    sl.SetCellStyle("V" + rowNumber, styleOutsideBorder);
                    sl.SetCellStyle("W" + rowNumber, styleOutsideBorder);
                    sl.SetCellStyle("X" + rowNumber, styleOutsideBorder);
                    sl.SetCellStyle("Y" + rowNumber, styleColumnNo);
                }
                #endregion

                #region Setting DataValidations
                SLDataValidation dv;

                //CELL C4
                //dv = sl.CreateDataValidation("C4");
                //dv.AllowWholeNumber(true, 100000000, 99999999999, true);
                //dv.SetInputMessage("Validacion RNC o Cedula", "La longitud de Este Campo es la Siguiente:"
                //                                    + "\nRNC = 9 Posiciones"
                //                                    + "\nCedula = 11 posiciones");

                //dv.SetErrorAlert("Validacion RNC o Cedula", "La longitud de Este Campo es la Siguiente:"
                //                                    + "\nRNC = 9 Posiciones"
                //                                    + "\nCedula = 11 posiciones");
                //sl.AddDataValidation(dv);

                ////CELL C6
                //dv = sl.CreateDataValidation("C6");
                //dv.AllowWholeNumber(true, 0, 65000, true);
                //dv.SetInputMessage("Validacion Cantidad de Registros", "El numero de Registros no debe ser mayor a 65,000 ni menor que 1");

                //dv.SetErrorAlert("Validacion Cantidad de Registros", "El numero de Registros no debe ser mayor a 65,000");
                //sl.AddDataValidation(dv);


                ////COLUMN B
                //dv = sl.CreateDataValidation("B12", $"B{dataList.Count + 12}");
                //dv.AllowAnyValue();
                //dv.SetInputMessage("Identificación", "- Tipos de Identificación aceptados:"
                //                                    + "\nRNC"
                //                                    + "\nCédula"
                //                                    + "\nPasaporte");
                //sl.AddDataValidation(dv);

                ////COLUMN C
                //dv = sl.CreateDataValidation("C12", $"C{dataList.Count + 11}");
                //dv.AllowWholeNumber(true, 1, 3, true);
                //dv.SetInputMessage("Tipo de Identificación", "- Numérico"
                //                                    + "\n- Valores Aceptados:"
                //                                    + "\n1 = Rnc"
                //                                    + "\n2 = Cédula"
                //                                    + "\n3 = Pasaporte");
                //dv.SetErrorAlert("Tipo de Identificación", "Debe insertar uno de los valores siguientes:"
                //                                            + "\n1 = Rnc"
                //                                            + "\n2 = Cedula"
                //                                            + "\n3 = Pasaporte");
                //sl.AddDataValidation(dv);


                ////COLUMN D
                //dv = sl.CreateDataValidation("D12", $"D{dataList.Count + 11}");
                //dv.AllowAnyValue();
                //dv.SetInputMessage("Número de Comprobante Fiscal", "Número de comprobante que avala la venta."
                //                                                    + "\n- Cantidad de caracteres:"
                //                                                    + "\n11 ó 19");
                //dv.SetErrorAlert("Error en NCF", "Verifique la cantidad de caracteres de su NCF."
                //                                   + "Debe tener 11 o 19 caracteres.");
                //sl.AddDataValidation(dv);

                ////COLUMN E
                //dv = sl.CreateDataValidation("E12", $"E{dataList.Count + 11}");
                //dv.AllowAnyValue();
                //dv.SetInputMessage("NCF Modificado", "Número de comprobante que avala la venta."
                //                                    + "- Cantidad de caracteres: 11 ó 19");
                //sl.AddDataValidation(dv);

                ////COLUMN F
                //dv = sl.CreateDataValidation("F12", $"F{dataList.Count + 11}");
                //dv.AllowList("$AA$13:$AA$18", true, true);
                //dv.SetInputMessage("Tipo de Ingreso", "-Seleccionar una opción de la Lista");
                //sl.AddDataValidation(dv);

                ////COLUMN G
                //dv = sl.CreateDataValidation("G12", $"G{dataList.Count + 11}");
                //dv.AllowTextLength(SLDataValidationSingleOperandValues.Equal, 8, true);
                //dv.SetInputMessage("Fecha de Comprobante", "Fecha en que se realiza la venta del bien o servicio."
                //                                           + "- Numérico"
                //                                           + "- Formato: AAAAMMDD.Sin separador  \"/\"");

                //dv.SetErrorAlert("Fecha de Comprobante", "- Numérico"
                //                                       + "- Formato: AAAAMMDD.Sin separador  \"/\"");
                //sl.AddDataValidation(dv);

                ////COLUMN H
                //dv = sl.CreateDataValidation("H12", $"H{dataList.Count + 11}");
                //dv.AllowWholeNumber(true, 10000000, 99999999, true);
                //dv.SetInputMessage("Fecha de Retención", "- Opcional"
                //                                        + "\n- Numérico"
                //                                        + "\n- Formato: AAAAMMDD.Sin separador  \"/\"");
                //dv.SetErrorAlert("Fecha de Retención", "- Numérico"
                //                                       + "- Formato: AAAAMMDD.Sin separador  \"/\"");
                //sl.AddDataValidation(dv);

                ////COLUMN K
                //dv = sl.CreateDataValidation("K12", $"K{dataList.Count + 11}");
                //dv.AllowDecimal(SLDataValidationSingleOperandValues.GreaterThanOrEqual, 0.0d, true);
                //dv.SetInputMessage("ITBIS Retenido por Terceros", "- Si Aplica"
                //                                                  + "\n- Numérico"
                //                                                  + "\n- Máximo dígitos: 12"
                //                                                  + "\n- Valor Mínimo: 0");
                //dv.SetErrorAlert("ITBIS Retenido por Terceros", "- Numérico"
                //                                                + "\n- Máximo dígitos: 12"
                //                                                + "\n- Valor Mínimo: 0");
                //sl.AddDataValidation(dv);

                ////COLUMN L
                //dv = sl.CreateDataValidation("L12", $"L{dataList.Count + 11}");
                //dv.AllowWholeNumber(true, 0, 999999999999, true);
                //dv.SetInputMessage("ITEBIS Retenido por Terceros", "- Opcional"
                //                                                 + "\n- Numerico"
                //                                                 + "\n- Maximo digitos: 12"
                //                                                 + "\n- Valor Minimo: 0");
                //dv.SetErrorAlert("ITEBIS Retenido por Terceros", "-Numerico"
                //                                                + "\n- Maximo digitos: 12"
                //                                                + "\n- Valor Minimo: 0");
                //sl.AddDataValidation(dv);

                ////COLUMN M
                //dv = sl.CreateDataValidation("M12", $"M{dataList.Count + 11}");
                //dv.AllowDecimal(SLDataValidationSingleOperandValues.GreaterThanOrEqual, 0.0d, true);
                //dv.SetInputMessage("Retención Renta por Terceros ", "- Si Aplica"
                //                                                    + "\n- Numérico"
                //                                                    + "\n- Máximo dígitos: 12"
                //                                                    + "\n- Valor Mínimo: 0");

                //dv.SetErrorAlert("Retención Renta por Terceros ", "- Numerico"
                //                                                   + "\n- Maximo digitos: 12"
                //                                                   + "\n- Valor Minimo: 0");
                //sl.AddDataValidation(dv);

                ////COLUMN N
                //dv = sl.CreateDataValidation("N12", $"N{dataList.Count + 11}");
                //dv.AllowWholeNumber(true, 0, 9999999999999, true);
                //dv.SetInputMessage("ISR Percibido", "- Opcional"
                //                                    + "\n- Numerico"
                //                                    + "\n- Maximo digitos: 12"
                //                                    + "\n- Valor Minimo: 0");

                //dv.SetErrorAlert("ISR Percibido", "- Numerico"
                //                                    + "\n- Maximo digitos: 12"
                //                                    + "\n- Valor Minimo: 0");
                //sl.AddDataValidation(dv);

                ////COLUMN O
                //dv = sl.CreateDataValidation("O12", $"O{dataList.Count + 11}");
                //dv.AllowDecimal(SLDataValidationSingleOperandValues.GreaterThanOrEqual, 0.0d, true);
                //dv.SetInputMessage("Impuesto Selectivo al Consumo", "- Si Aplica"
                //                                                    + "\n- Numérico"
                //                                                    + "\n- Máximo dígitos: 12"
                //                                                    + "\n- Valor Mínimo: 0");
                //dv.SetErrorAlert("Impuesto Selectivo al Consumo", "- Numérico"
                //                                                    + "\n- Máximo dígitos: 12"
                //                                                    + "\n- Valor Mínimo: 0");
                //sl.AddDataValidation(dv);

                ////COLUMN P
                //dv = sl.CreateDataValidation("P12", $"P{dataList.Count + 11}");
                //dv.AllowDecimal(SLDataValidationSingleOperandValues.GreaterThanOrEqual, 0.0d, true);
                //dv.SetInputMessage("Otros Impuestos/Tasas", "- Si Aplica"
                //                                            + "\n- Numérico"
                //                                            + "\n- Máximo dígitos: 12"
                //                                            + "\n- Valor Mínimo: 0");
                //dv.SetErrorAlert("Otros Impuestos/Tasas", "- Numérico"
                //                                            + "\n- Máximo dígitos: 12"
                //                                            + "\n- Valor Mínimo: 0");
                //sl.AddDataValidation(dv);

                ////COLUMN Q
                //dv = sl.CreateDataValidation("Q12", $"Q{dataList.Count + 11}");
                //dv.AllowDecimal(SLDataValidationSingleOperandValues.GreaterThanOrEqual, 0.0d, true);
                //dv.SetInputMessage("Monto Propina Legal", "- Si Aplica"
                //                                        + "\n- Numérico"
                //                                        + "\n- Máximo dígitos: 12"
                //                                        + "\n- Valor Mínimo: 0");
                //dv.SetErrorAlert("Monto Propina Legal", "- Numérico"
                //                                        + "\n- Máximo dígitos: 12"
                //                                        + "\n- Valor Mínimo: 0");
                //sl.AddDataValidation(dv);

                ////COLUMN R
                //dv = sl.CreateDataValidation("R12", $"R{dataList.Count + 11}");
                //dv.AllowDecimal(SLDataValidationSingleOperandValues.GreaterThanOrEqual, 0.0d, true);
                //dv.SetInputMessage("Efectivo", "- Numérico"
                //                                + "\n- Máximo dígitos: 12"
                //                                + "\n- Valor Mínimo: 0");
                //dv.SetErrorAlert("Efectivo", "- Numérico"
                //                                + "\n- Máximo dígitos: 12"
                //                                + "\n- Valor Mínimo: 0");
                //sl.AddDataValidation(dv);

                ////COLUMN S
                //dv = sl.CreateDataValidation("S12", $"S{dataList.Count + 11}");
                //dv.AllowDecimal(SLDataValidationSingleOperandValues.GreaterThanOrEqual, 0.0d, true);
                //dv.SetInputMessage("Cheque/Transferencia", "- Numérico"
                //                                            + "\n- Máximo dígitos: 12"
                //                                            + "\n- Valor Mínimo: 0");
                //dv.SetErrorAlert("Cheque/Transferencia", "- Numérico"
                //                                            + "\n- Máximo dígitos: 12"
                //                                            + "\n- Valor Mínimo: 0");
                //sl.AddDataValidation(dv);

                ////COLUMN T
                //dv = sl.CreateDataValidation("T12", $"T{dataList.Count + 11}");
                //dv.AllowDecimal(SLDataValidationSingleOperandValues.GreaterThanOrEqual, 0.0d, true);
                //dv.SetInputMessage("Tarjeta Débito/Crédito", "- Numérico"
                //                                            + "\n- Máximo dígitos: 12"
                //                                            + "\n- Valor Mínimo: 0");
                //dv.SetErrorAlert("Tarjeta Débito/Crédito", "- Numérico"
                //                                            + "\n- Máximo dígitos: 12"
                //                                            + "\n- Valor Mínimo: 0");
                //sl.AddDataValidation(dv);

                ////COLUMN U
                //dv = sl.CreateDataValidation("U12", $"U{dataList.Count + 11}");
                //dv.AllowDecimal(SLDataValidationSingleOperandValues.GreaterThanOrEqual, 0.0d, true);
                //dv.SetInputMessage("A Crédito", "- Si Aplica"
                //                                        + "\n- Numérico"
                //                                        + "\n- Máximo dígitos: 12"
                //                                        + "\n- Valor Mínimo: 0");
                //dv.SetErrorAlert("A Crédito", "- Numérico"
                //                                        + "\n- Máximo dígitos: 12"
                //                                        + "\n- Valor Mínimo: 0");
                //sl.AddDataValidation(dv);

                ////COLUMN V
                //dv = sl.CreateDataValidation("V12", $"V{dataList.Count + 11}");
                //dv.AllowDecimal(SLDataValidationSingleOperandValues.GreaterThanOrEqual, 0.0d, true);
                //dv.SetInputMessage("Bonos o Certificados de Regalo", "- Si Aplica"
                //                                        + "\n- Numérico"
                //                                        + "\n- Máximo dígitos: 12"
                //                                        + "\n- Valor Mínimo: 0");
                //dv.SetErrorAlert("Bonos o Certificados de Regalo", "- Numérico"
                //                                        + "\n- Máximo dígitos: 12"
                //                                        + "\n- Valor Mínimo: 0");
                //sl.AddDataValidation(dv);

                ////COLUMN W
                //dv = sl.CreateDataValidation("W12", $"W{dataList.Count + 11}");
                //dv.AllowDecimal(SLDataValidationSingleOperandValues.GreaterThanOrEqual, 0.0d, true);
                //dv.SetInputMessage("Permuta", " - Si Aplica"
                //                                        + "\n- Numérico"
                //                                        + "\n- Máximo dígitos: 12"
                //                                        + "\n- Valor Mínimo: 0");
                //dv.SetErrorAlert("Permuta", "- Numérico"
                //                                        + "\n- Máximo dígitos: 12"
                //                                        + "\n- Valor Mínimo: 0");
                //sl.AddDataValidation(dv);

                ////COLUMN W
                //dv = sl.CreateDataValidation("X12", $"X{dataList.Count + 11}");
                //dv.AllowDecimal(SLDataValidationSingleOperandValues.GreaterThanOrEqual, 0.0d, true);
                //dv.SetInputMessage("Otras Formas de Pago", " - Si Aplica"
                //                                        + "\n- Numérico"
                //                                        + "\n- Máximo dígitos: 12"
                //                                        + "\n- Valor Mínimo: 0");
                //dv.SetErrorAlert("Otras Formas de Pago", "- Numérico"
                //                                        + "\n- Máximo dígitos: 12"
                //                                        + "\n- Valor Mínimo: 0");
                //sl.AddDataValidation(dv);



                #endregion Setting DataValidations

                #region Setting Cells Style
                sl.SetCellStyle("B1", styleBold);
                sl.SetCellStyle("B2", styleBold);
                sl.SetCellStyle("B4", styleBackgroundGreen);
                sl.SetCellStyle("B5", styleBackgroundGreen);
                sl.SetCellStyle("B6", styleBackgroundGreen);
                sl.SetCellStyle("B9", styleBackgroundGreenCenter);
                sl.SetCellStyle("C4", horizontAlignMenteLeft);
                sl.SetCellStyle("C5", horizontAlignMenteLeft);
                sl.SetCellStyle("C6", horizontAlignMenteLeft);
                sl.SetCellStyle("F1", styleCenterMergeCell);
                sl.SetCellStyle("F2", styleCenterMergeCell);

                sl.SetCellStyle("G6", styleCellHeader);
                sl.SetCellStyle("G7", styleG7);

                sl.MergeWorksheetCells("B9", "X9");
                sl.MergeWorksheetCells("F1", "I1");
                sl.MergeWorksheetCells("F2", "I2");

                #endregion

                #region Setting width Columns
                sl.SetColumnWidth("A", 9.11);
                sl.SetColumnWidth("B", 15.56);
                sl.SetColumnWidth("C", 13.61);
                sl.SetColumnWidth("D", 21.11);
                sl.SetColumnWidth("E", 30.22);
                sl.SetColumnWidth("F", 31.11);
                sl.SetColumnWidth("G", 17.22);
                sl.SetColumnWidth("H", 17.89);
                sl.SetColumnWidth("I", 17.89);
                sl.SetColumnWidth("J", 15.67);
                sl.SetColumnWidth("K", 17.89);
                sl.SetColumnWidth("L", 17.89);
                sl.SetColumnWidth("M", 17.89);
                sl.SetColumnWidth("N", 17.89);
                sl.SetColumnWidth("O", 17.89);
                sl.SetColumnWidth("P", 17.89);
                sl.SetColumnWidth("Q", 17.89);
                sl.SetColumnWidth("R", 17.89);
                sl.SetColumnWidth("S", 17.89);
                sl.SetColumnWidth("T", 17.89);
                sl.SetColumnWidth("U", 17.89);
                sl.SetColumnWidth("V", 17.89);
                sl.SetColumnWidth("W", 17.89);
                sl.SetColumnWidth("X", 17.89);
                sl.SetColumnWidth("Y", 100.22);
                sl.SetColumnWidth("Z", 17.89);
                sl.HideColumn("AA");


                #endregion


                // string ruta = @$"{fileSavePath}/{data.Name}.xlsx";
                try
                {

                    sl.SaveAs(stream);



                }
                catch (InvalidOperationException e)
                {

                    throw;
                }


            }
            catch (Exception e)
            {

                return stream.ToArray();


            }
            return stream.ToArray();

        }

        public class FormaPagoItem
        {
            public int Id { get; set; }
            public string Valor { get; set; }
        }
        public class TipoBienesyServiciosItem
        {
            public int Id { get; set; }
            public string Valor { get; set; }
        }

        public List<TipoBienesyServiciosItem> TipoBienesyServicios { get; set; } = new List<TipoBienesyServiciosItem>
    {
             new TipoBienesyServiciosItem { Id = 0, Valor = "" },
        new TipoBienesyServiciosItem { Id = 1, Valor = "01 Gastos de personal" },
        new TipoBienesyServiciosItem { Id = 2, Valor = "02 Gastos por trabajo, suministro o servicios" },
        new TipoBienesyServiciosItem { Id = 3, Valor = "03 Arrendamientos" },
        new TipoBienesyServiciosItem { Id = 4, Valor = "04 Gastos activo fijo" },
        new TipoBienesyServiciosItem { Id = 5, Valor = "05 Gastos de representación" },
        new TipoBienesyServiciosItem { Id = 6, Valor = "06 Otras deducciones administrativas" },
        new TipoBienesyServiciosItem { Id = 7, Valor = "07 Gastos financieros" },
        new TipoBienesyServiciosItem { Id = 8, Valor = "08 Gastos extraordinarios" },
        new TipoBienesyServiciosItem { Id = 9, Valor = "09 Compras y gastos que forman parte del costo de venta" },
        new TipoBienesyServiciosItem { Id = 10, Valor = "10 Adquisiciones de activos" },
        new TipoBienesyServiciosItem { Id = 11, Valor = "11 Gastos de seguros" }
    };


        public List<FormaPagoItem> FormaPago { get; set; } = new List<FormaPagoItem>
            {
            new FormaPagoItem { Id = 0, Valor = "" },
             new FormaPagoItem { Id = 1, Valor = "01 Efectivo" },
             new FormaPagoItem { Id = 2, Valor = "02 Cheque/Transferencia/Depósito" },
             new FormaPagoItem { Id = 3, Valor = "03 Tarjeta crédito/débito" },
             new FormaPagoItem { Id = 4, Valor = "04 Compra a crédito" },
             new FormaPagoItem { Id = 5, Valor = "05 Permuta" },
             new FormaPagoItem { Id = 6, Valor = "06 Nota Crédito" },
             new FormaPagoItem { Id = 7, Valor = "07 Mixto" }
             };
        

        public string Generador606txt(List<Invoice606> dataList, O606 data)
        {

            var archivo = $"606|{data.RNC}|{data.YearMonth.Replace("/", "")}|{data.Amount} \n";
            foreach (var item in dataList)
            {

                var fechaComprobante = DateTime.Parse(item.FechaComprobante);
                var fechaPago = "";
                if (item.FechaPago != "")
                {
                    var fechaPagoParse = DateTime.Parse(item.FechaPago);
                    fechaPago = $"{fechaPagoParse.Year}{fechaPagoParse.Month}{fechaPagoParse.Day}";
                }

                string TotalMontoFacturado = (item.TotalMontoFacturado == 0.00m) ? "" : item.TotalMontoFacturado.ToString();
                string ITBISFacturado = (item.ITBISFacturado == 0.00m) ? "" : item.ITBISFacturado.ToString();

                string ITBISRetenido = (item.ITBISRetenido == 0.00m) ? "" : item.ITBISRetenido.ToString();
                string ITBISSujetoaProporcionalidad = (item.ITBISSujetoaProporcionalidad == 0.00m) ? "" : item.ITBISSujetoaProporcionalidad.ToString();

                string ITBISLlevadoAlCosto = (item.ITBISLlevadoAlCosto == 0.00m) ? "" : item.ITBISLlevadoAlCosto.ToString();

                string ITBISPorAdelantar = (item.ITBISPorAdelantar == 0.00m) ? "" : item.ITBISPorAdelantar.ToString();
                string ITBISPersividoEnCompras = (item.ITBISPersividoEnCompras == 0.00m) ? "" : item.ITBISPersividoEnCompras.ToString();
                string TipoRetencionEnISR = (item.TipoRetencionEnISR == 0.00m) ? "" : item.TipoRetencionEnISR.ToString();
                string MontoRetencionRenta = (item.MontoRetencionRenta == 0.00m) ? "" : item.MontoRetencionRenta.ToString();

                string IRSPercibidoEnCompras = (item.IRSPercibidoEnCompras == 0.00m) ? "" : item.IRSPercibidoEnCompras.ToString();
                string ImpuestoSelectivoAlConsumo = (item.ImpuestoSelectivoAlConsumo == 0.00m) ? "" : item.ImpuestoSelectivoAlConsumo.ToString();
                string OtrosImpuestosTasa = (item.OtrosImpuestosTasa == 0.00m) ? "" : item.OtrosImpuestosTasa.ToString();
                string MontoPropinaLegal = (item.MontoPropinaLegal == 0.00m) ? "" : item.MontoPropinaLegal.ToString();

                string MontoFacturadoEnServicio = (item.MontoFacturadoEnServicio == 0.00m) ? "" : item.MontoFacturadoEnServicio.ToString();
                string MontoFacturadoEnBienes = (item.MontoFacturadoEnBienes == 0.00m) ? "" : item.MontoFacturadoEnBienes.ToString();



                archivo += $"{item.RNCCedulaPasaporte.Replace("-", "")}|" +
                    $"{item.TipoID}|" +
                    $"{item.TipoBienesYServiciosComprados}|" +
                    $"{item.NumeroComprobanteFiscal}" +
                    $"|{item.NumeroComprobanteFiscalModificado}" +
                    $"|{fechaComprobante.Year}{fechaComprobante.Month}{fechaComprobante.Day}" +
                    $"|{fechaPago}" +

                    $"|{MontoFacturadoEnServicio}" +
                    $"|{MontoFacturadoEnBienes}" +
                    $"|{TotalMontoFacturado}" +
                    $"|{ITBISFacturado}" +
                    $"|{ITBISRetenido}" +
                    $"|{ITBISSujetoaProporcionalidad}" +
                    $"|{ITBISLlevadoAlCosto}" +
                    $"|{ITBISPorAdelantar}" +
                    $"|{ITBISPersividoEnCompras}" +
                    $"|{TipoRetencionEnISR}" +
                    $"|{MontoRetencionRenta}" +
                    $"|{IRSPercibidoEnCompras}" +
                    $"|{ImpuestoSelectivoAlConsumo}" +
                    $"|{OtrosImpuestosTasa}" +
                    $"|{MontoPropinaLegal}" +
                    $"|{item.FormaDePago} \n";
            }

            return archivo;

        }

        public void validation()
        {

        }


        public static string GetFechaComprobante(string anoMes)
        {
            int month = int.Parse(anoMes.Substring(4));
            int year = int.Parse(anoMes.Substring(0, 4));
            var firstDayOfMonth = new DateTime(year, month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
            return lastDayOfMonth.ToString("yyyy-MM-dd").Replace("-", "");
        }


        public static string FormatingCedula(string str)
        {
            var cedula = Int64.Parse(str);
            str = string.Format("{0:###-#######-#}", cedula);
            return str;
        }

        public static string FormatingRNC(string str)
        {
            var rnc = Int64.Parse(str);
            str = string.Format("{0:#-##-#####-#}", rnc);
            return FixLength(str, "rnc");
        }

        public static string FormatingData(string str)
        {
            if (str.Length == 9)
                return FormatingRNC(str);
            else
                return FormatingCedula(str);
        }

        public static string FixLength(string str, string type)
        {
            int diff = default;

            if (type == "rnc")
                diff = 12 - str.Length;
            else
                diff = 13 - str.Length;

            for (int i = 0; i != diff; i++)
            {
                str = "0" + str;
            }

            return str;
        }
    }
}
