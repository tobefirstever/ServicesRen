using Renavi.Application.DTO.Dtos.SimuladorCuotas;
using Renavi.Application.Interfaces;
using Renavi.Domain.Entities.Entities;
using Renavi.Domain.Interfaces;
using Renavi.Transversal.Common;
using Renavi.Transversal.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using System.IO;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Kernel.Colors;

namespace Renavi.Application.Main
{
    public class SimuladorCuotasApplication : ISimuladorCuotasApplication
    {
        private readonly ISimuladorCuotasDomain _simuladorCuotasDomain;

        public SimuladorCuotasApplication(ISimuladorCuotasDomain simuladorCuotasDomain)
        {
            _simuladorCuotasDomain = simuladorCuotasDomain;
        }


        public async Task<SimuladorCuotasComprasResponseDto> GetList(SimuladorCuotasComprasDto request)
        {
            var response = new SimuladorCuotasComprasResponseDto();
            //IEnumerable<SimuladorCuotasEntity> gerenciaEntities = await _simuladorCuotasDomain.GetList();
            response.cuota_mensual = 0.00;
            response.porcentaje_cuota = 0.00;
            response.bono_bbp = 0.00;
            response.total_bbp = 0.00;
            response.tasa_anual = 0.00;
            response.monto_financiar = 0.00;

            var bono_sostenible = 0.00;
            var bbp_integrador = 0.00;


            if (request.Valor_vivienda > 0 && request.Cuota_inicial >= request.Valor_vivienda * 0.075)
            {

                response.porcentaje_cuota = Math.Round(((request.Cuota_inicial * 100) / request.Valor_vivienda), 2);


                if (!request.Flag_apoyoHabitacional)
                {

                    if (request.Valor_vivienda >= 67200 && request.Valor_vivienda <= 96200)
                    {

                        response.bono_bbp = Math.Round(26900.00, 2);
                    }
                    if (request.Valor_vivienda > 96200 && request.Valor_vivienda <= 144000)
                    {

                        response.bono_bbp = Math.Round(22400.00, 2);
                    }
                    if (request.Valor_vivienda > 144000 && request.Valor_vivienda <= 239800)
                    {

                        response.bono_bbp = Math.Round(20500.00, 2);
                    }
                    if (request.Valor_vivienda > 239800 && request.Valor_vivienda <= 355100)
                    {

                        response.bono_bbp = Math.Round(7600.00, 2);
                    }

                    if (request.Flag_sostenible) bono_sostenible = Math.Round(6000.00, 2);
                    if (request.Flag_bppintegrador) bbp_integrador = Math.Round(3400.00, 2);

                    response.total_bbp = Math.Round(response.bono_bbp + bono_sostenible + bbp_integrador, 2);

                }


                response.monto_financiar = request.Valor_vivienda - request.Cuota_inicial - response.bono_bbp;


                if (request.Tasa_efectiva > 0 && request.plazo_meses > 0)
                {

                    response.cuota_mensual = await CalculatCuotaMensual(request.Tasa_efectiva, response.monto_financiar, request.Valor_vivienda, request.plazo_meses);
                    response.tasa_anual = Math.Round(ConvertirTasaMensualaAnual(Financial.Rate(request.plazo_meses, response.cuota_mensual, -response.monto_financiar)), 4);



                }

                //response.Data = Mapping.Map<IEnumerable<SimuladorCuotasEntity>, IEnumerable<SimuladorCuotasResponseDto>>(gerenciaEntities);

            }

            return response;
        }


        public async Task<SimuladorCuotasMejoramientoResponseDto> GetListMejoramiento(SimuladorCuotasMejoramientoDto request)
        {
            var response = new SimuladorCuotasMejoramientoResponseDto();
            //IEnumerable<SimuladorCuotasEntity> gerenciaEntities = await _simuladorCuotasDomain.GetList();
            response.cuota_mensual = 0.00;
            response.tasa_anual = 0.00;
            response.monto_financiar = 0.00;

            var bono_sostenible = 0.00;
            var bbp_integrador = 0.00;


            if (request.Valor_vivienda > 0 && request.valor_obra >= 0)
            {



                response.monto_financiar = request.valor_obra;


                if (request.Tasa_efectiva > 0 && request.plazo_meses > 0)
                {

                    response.cuota_mensual = await CalculatCuotaMensual(request.Tasa_efectiva, response.monto_financiar, request.Valor_vivienda, request.plazo_meses);
                    response.tasa_anual = Math.Round(ConvertirTasaMensualaAnual(Financial.Rate(request.plazo_meses, response.cuota_mensual, -response.monto_financiar)), 4);



                }

                //response.Data = Mapping.Map<IEnumerable<SimuladorCuotasEntity>, IEnumerable<SimuladorCuotasResponseDto>>(gerenciaEntities);

            }

            return response;
        }

        public async Task<SimuladorCuotasConstruccionResponseDto> GetListConstruccion(SimuladorCuotasConstruccionDto request)
        {
            var response = new SimuladorCuotasConstruccionResponseDto();
            response.cuota_mensual = 0.00;
            response.bono_bbp = 0.00;
            response.total_bbp = 0.00;
            response.tasa_anual = 0.00;
            response.monto_financiar = 0.00;

            var bono_sostenible = 0.00;
            var bbp_integrador = 0.00;


            if (request.Valor_vivienda > 0 && request.valor_obra >= request.Valor_vivienda * 0.075)
            {


                if (!request.Flag_apoyoHabitacional)
                {

                    if (request.Valor_vivienda >= 67200 && request.Valor_vivienda <= 96200)
                    {

                        response.bono_bbp = Math.Round(26900.00, 2);
                    }
                    if (request.Valor_vivienda > 96200 && request.Valor_vivienda <= 144000)
                    {

                        response.bono_bbp = Math.Round(22400.00, 2);
                    }
                    if (request.Valor_vivienda > 144000 && request.Valor_vivienda <= 239800)
                    {

                        response.bono_bbp = Math.Round(20500.00, 2);
                    }
                    if (request.Valor_vivienda > 239800 && request.Valor_vivienda <= 355100)
                    {

                        response.bono_bbp = Math.Round(7600.00, 2);
                    }

                    bono_sostenible = Math.Round(6000.00, 2);
                    if (request.Flag_bppintegrador) bbp_integrador = Math.Round(3400.00, 2);

                    response.total_bbp = Math.Round(response.bono_bbp + bono_sostenible + bbp_integrador, 2);

                }


                response.monto_financiar = request.valor_obra - response.total_bbp;


                if (request.Tasa_efectiva > 0 && request.plazo_meses > 0)
                {

                    response.cuota_mensual = await CalculatCuotaMensual(request.Tasa_efectiva, response.monto_financiar, request.Valor_vivienda, request.plazo_meses);
                    response.tasa_anual = Math.Round(ConvertirTasaMensualaAnual(Financial.Rate(request.plazo_meses, response.cuota_mensual, -response.monto_financiar)), 4);



                }

                //response.Data = Mapping.Map<IEnumerable<SimuladorCuotasEntity>, IEnumerable<SimuladorCuotasResponseDto>>(gerenciaEntities);

            }

            return response;
        }



        static double ConvertirTasaAnualAMensual(double tasaAnual)
        {
            return Math.Pow(1 + tasaAnual, 1.0 / 12) - 1; // Convertir a tasa mensual
        }

        static double ConvertirTasaMensualaAnual(double tasaAnual)
        {
            return Math.Pow(1 + tasaAnual, 12) - 1; // Convertir a tasa mensual
        }


        public async Task<double> CalculatCuotaMensual(double tasa_inicial, double? monto_financiar, double monto_total, int plazo)
        {


            double tasa = ConvertirTasaAnualAMensual(tasa_inicial / 100) + (0.035 / 100);
            double total = (double)monto_financiar;

            double pagoCapital = Financial.PPmt(tasa, 1, (double)plazo, -total);



            double segurodesgravamen = total * (0.035 / 100);
            double seguroinmueble = monto_total * 0.00025;

            double perioroActual = 0;
            double pagoInteres = (Financial.IPmt(tasa, 1, (double)plazo - perioroActual, -total)) - segurodesgravamen;



            double CuotaMensual = pagoCapital + pagoInteres;



            return Math.Round(CuotaMensual + segurodesgravamen + seguroinmueble, 2);





        }

        public async Task<SimuladorCronogramaResponseDto> GetCronograma(SimuladorCronogramaDto request)
        {

            var response = new SimuladorCronogramaResponseDto();
            var cuota_mnesual = await CalculatCuotaMensual(request.Tasa_efectiva, request.monto_financiar, request.Valor_vivienda, request.plazo_meses);


            response.archivo = GenerarCronogramaDePagosBase64(request.Valor_vivienda, request.monto_financiar, request.Tasa_efectiva, request.plazo_meses, cuota_mnesual);

            return response;
        }


        static string GenerarCronogramaDePagosBase64(double valor_vivienda, double montofinanciar, double tasaInteresAnual, int n, double cuotamensual)
        {
            double montoFinanciar = montofinanciar; // Monto a financiar
            double r = ConvertirTasaAnualAMensual(tasaInteresAnual / 100) + (0.035 / 100);
            double cuotaPrestamo = cuotamensual; // Cuota del préstamo

            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (PdfWriter writer = new PdfWriter(memoryStream))
                {
                    using (PdfDocument pdf = new PdfDocument(writer))
                    {
                        Document document = new Document(pdf);
                        document.Add(new Paragraph("Cronograma de Pagos").SetFontSize(20).SetTextAlignment(TextAlignment.CENTER));

                        // Encabezados de la tabla
                        Table table = new Table(new float[] { 1, 3, 1, 2, 1, 1, 3, 2 });
                        table.AddHeaderCell("Periodo").SetTextAlignment(TextAlignment.CENTER);
                        table.AddHeaderCell("Saldo Inicial").SetTextAlignment(TextAlignment.CENTER);
                        table.AddHeaderCell("Amortización").SetTextAlignment(TextAlignment.CENTER);
                        table.AddHeaderCell("Interés").SetTextAlignment(TextAlignment.CENTER);
                        table.AddHeaderCell("Seguro Desgravamen").SetTextAlignment(TextAlignment.CENTER);
                        table.AddHeaderCell("Seguro de Inmueble").SetTextAlignment(TextAlignment.CENTER);
                        table.AddHeaderCell("Saldo Final").SetTextAlignment(TextAlignment.CENTER);
                        table.AddHeaderCell("Cuota Mensual").SetTextAlignment(TextAlignment.CENTER);






                        double saldo = montoFinanciar;

                        for (int i = 1; i <= n; i++)
                        {
                            double saldoinicial = saldo;

                            double segurodesgravamen = saldo * (0.035 / 100);
                            double seguroinmueble = valor_vivienda * 0.00025;
                            double interes = (Financial.IPmt(r, i, (double)n, -montoFinanciar)) - segurodesgravamen; ; // Interés del mes
                            double amortizacion = Financial.PPmt(r, i, (double)n, -montoFinanciar); // Amortización del capital
                            saldo -= amortizacion; // Actualizar saldo


                            // Agregar fila a la tabla
                            table.AddCell(i.ToString()).SetFontSize(9).SetTextAlignment(TextAlignment.CENTER);
                            table.AddCell(saldoinicial.ToString("C")).SetFontSize(9).SetTextAlignment(TextAlignment.CENTER);
                            table.AddCell(amortizacion.ToString("C")).SetFontSize(9).SetTextAlignment(TextAlignment.CENTER);
                            table.AddCell(interes.ToString("C")).SetFontSize(9).SetTextAlignment(TextAlignment.CENTER);
                            table.AddCell(segurodesgravamen.ToString("C")).SetFontSize(9).SetTextAlignment(TextAlignment.CENTER);
                            table.AddCell(seguroinmueble.ToString("C")).SetFontSize(9).SetTextAlignment(TextAlignment.CENTER);
                            table.AddCell(saldo.ToString("C")).SetFontSize(9).SetTextAlignment(TextAlignment.CENTER);
                            table.AddCell(cuotamensual.ToString("C")).SetFontSize(9).SetTextAlignment(TextAlignment.CENTER);
                        }

                        document.Add(table);
                        document.Close();
                    }
                }

                // Convertir el MemoryStream a Base64
                byte[] pdfBytes = memoryStream.ToArray();
                return Convert.ToBase64String(pdfBytes);
            }
        }

        public async Task<List<SimuladorBancosTasasResponseDto>> GetTasas()
        {
            var response = new List<SimuladorBancosTasasResponseDto>();


            var bancos = new List<SimuladorBancosTasasResponseDto>();

            var data = await _simuladorCuotasDomain.GetList();

            //bancos.Add(new SimuladorBancosTasasResponseDto
            //{
            //    id = 1,
            //    nombre = "Scotiabank",
            //    tasa = 8.98
            //});

            //bancos.Add(new SimuladorBancosTasasResponseDto
            //{
            //    id = 2,
            //    nombre = "Interbank",
            //    tasa = 9.27
            //});

            //bancos.Add(new SimuladorBancosTasasResponseDto
            //{
            //    id = 3,
            //    nombre = "Financiera Efectiva",
            //    tasa = 9.44
            //});

            //bancos.Add(new SimuladorBancosTasasResponseDto
            //{
            //    id = 4,
            //    nombre = "CMAC Trujillo",
            //    tasa = 11.39
            //});

            //bancos.Add(new SimuladorBancosTasasResponseDto
            //{
            //    id = 5,
            //    nombre = "CMAC Maynas",
            //    tasa = 14.50
            //});

            //bancos.Add(new SimuladorBancosTasasResponseDto
            //{
            //    id = 6,
            //    nombre = "Banco Pichincha",
            //    tasa = 9.72
            //});

            //bancos.Add(new SimuladorBancosTasasResponseDto
            //{
            //    id = 7,
            //    nombre = "Banco de Crédito",
            //    tasa = 9.43
            //});

            //bancos.Add(new SimuladorBancosTasasResponseDto
            //{
            //    id = 8,
            //    nombre = "Banco de Comercio",
            //    tasa = 10.27
            //});


            //bancos.Add(new SimuladorBancosTasasResponseDto
            //{
            //    id = 9,
            //    nombre = "BANBIF",
            //    tasa = 9.62
            //});

            //bancos.Add(new SimuladorBancosTasasResponseDto
            //{
            //    id = 10,
            //    nombre = "BBVA Perú",
            //    tasa = 9.02
            //});


            response = data.ToList();

            return response;
        }
    }
}
