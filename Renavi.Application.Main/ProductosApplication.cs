using Renavi.Application.DTO.Dtos.Productos;
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

namespace Renavi.Application.Main
{
    public class ProductosApplication : IProductosApplication
    {
        private readonly IProductosDomain _productosDomain;

        public ProductosApplication(IProductosDomain productosDomain)
        {
            _productosDomain = productosDomain;
        }

        public async Task<IEnumerable<ProductosResponseDto>> GetList(ProductosDto request)
        {
            var response = new List<ProductosResponseDto>();
            // IEnumerable<ProductosEntity> gerenciaEntities = await _productosDomain.GetList();

            var productos = new List<ProductosResponseDto>();


            if (request.Tipo_producto == 1)
            {
                /////Comprar
                if (request.opcion == 1)
                {
                    productos.Add(new ProductosResponseDto
                    {
                        nroOrden = 1,
                        texto = "Cumple el sueño de la casa propia con los beneficios del Crédito Mivivienda.",
                        tipo = "descripcion"
                    });
                }

                /////Construir
                if (request.opcion == 2)
                {
                    productos.Add(new ProductosResponseDto
                    {
                        nroOrden = 1,
                        texto = "Construye la vivienda que tu familia merece con el Crédito Mivivienda.",
                        tipo = "descripcion"
                    });
                }

                /////Mejorar
                if (request.opcion == 3)
                {
                    productos.Add(new ProductosResponseDto
                    {
                        nroOrden = 1,
                        texto = "Mejora y renueva tu vivienda con el Crédito Mivivienda.",
                        tipo = "descripcion"
                    });

                }


            }

            if (request.Tipo_producto == 2)
            {
                /////Comprar
                if (request.opcion == 1)
                {
                    productos.Add(new ProductosResponseDto
                    {
                        nroOrden = 1,
                        texto = "Requisitos",
                        tipo = "titulo"
                    });

                    productos.Add(new ProductosResponseDto
                    {
                        nroOrden = 2,
                        texto = "Entérate los requisitos que debes cumplir para acceder al Crédito Mivivienda.",
                        tipo = "descripcion"
                    });

                    productos.Add(new ProductosResponseDto
                    {
                        nroOrden = 3,
                        texto = "Beneficios",
                        tipo = "titulo"
                    });

                    productos.Add(new ProductosResponseDto
                    {
                        nroOrden = 4,
                        texto = "Descubre los beneficios únicos que te ayudan a comprar tu vivienda con el Crédito Mivivienda.",
                        tipo = "descripcion"
                    });

                    productos.Add(new ProductosResponseDto
                    {
                        nroOrden = 5,
                        texto = "Simulador de Cuotas",
                        tipo = "titulo"
                    });

                    productos.Add(new ProductosResponseDto
                    {
                        nroOrden = 6,
                        texto = "Calcula tus cuotas de pago con el Crédito Mivivienda.",
                        tipo = "descripcion"
                    });


                    productos.Add(new ProductosResponseDto
                    {
                        nroOrden = 7,
                        texto = "Paso a Paso",
                        tipo = "titulo"
                    });

                    productos.Add(new ProductosResponseDto
                    {
                        nroOrden = 8,
                        texto = "Te explicamos que pasos debes de seguir hasta comprar tu vivienda con el Crédito Mivivienda.",
                        tipo = "descripcion"
                    });

                }

                /////Construir
                if (request.opcion == 2)
                {
                    productos.Add(new ProductosResponseDto
                    {
                        nroOrden = 1,
                        texto = "Requisitos",
                        tipo = "titulo"
                    });

                    productos.Add(new ProductosResponseDto
                    {
                        nroOrden = 2,
                        texto = "Entérate los requisitos que debes cumplir para acceder al Crédito Mivivienda.",
                        tipo = "descripcion"
                    });

                    productos.Add(new ProductosResponseDto
                    {
                        nroOrden = 3,
                        texto = "Beneficios",
                        tipo = "titulo"
                    });

                    productos.Add(new ProductosResponseDto
                    {
                        nroOrden = 4,
                        texto = "Descubre los beneficios para construir con el Crédito Mivivienda.",
                        tipo = "descripcion"
                    });

                    productos.Add(new ProductosResponseDto
                    {
                        nroOrden = 5,
                        texto = "Simulador de Cuotas",
                        tipo = "titulo"
                    });

                    productos.Add(new ProductosResponseDto
                    {
                        nroOrden = 6,
                        texto = "Calcula tus cuotas de pago con el Crédito Mivivienda.",
                        tipo = "descripcion"
                    });


                    productos.Add(new ProductosResponseDto
                    {
                        nroOrden = 7,
                        texto = "Paso a Paso",
                        tipo = "titulo"
                    });

                    productos.Add(new ProductosResponseDto
                    {
                        nroOrden = 8,
                        texto = "Te explicamos que pasos debes de seguir para construir tu vivienda con el Crédito Mivivienda.",
                        tipo = "descripcion"
                    });

                }
  
                    /////Mejorar
                if (request.opcion == 3)
                    {
                    productos.Add(new ProductosResponseDto
                    {
                        nroOrden = 1,
                        texto = "Requisitos",
                        tipo = "titulo"
                    });

                    productos.Add(new ProductosResponseDto
                    {
                        nroOrden = 2,
                        texto = "Entérate los requisitos que debes cumplir para acceder al Crédito Mivivienda.",
                        tipo = "descripcion"
                    });

                    productos.Add(new ProductosResponseDto
                    {
                        nroOrden = 3,
                        texto = "Beneficios",
                        tipo = "titulo"
                    });

                    productos.Add(new ProductosResponseDto
                    {
                        nroOrden = 4,
                        texto = "Descubre los beneficios para mejorar tu vivienda con ayuda del Crédito Mivivienda.",
                        tipo = "descripcion"
                    });

                    productos.Add(new ProductosResponseDto
                    {
                        nroOrden = 5,
                        texto = "Simulador de Cuotas",
                        tipo = "titulo"
                    });

                    productos.Add(new ProductosResponseDto
                    {
                        nroOrden = 6,
                        texto = "Calcula tus cuotas de pago con el Crédito Mivivienda.",
                        tipo = "descripcion"
                    });


                    productos.Add(new ProductosResponseDto
                    {
                        nroOrden = 7,
                        texto = "Paso a Paso",
                        tipo = "titulo"
                    });

                    productos.Add(new ProductosResponseDto
                    {
                        nroOrden = 8,
                        texto = "Te explicamos que pasos debes de seguir para construir tu vivienda con el Crédito Mivivienda.",
                        tipo = "descripcion"
                    });

                }


                


            }

            if (request.Tipo_producto == 3)
            {
                /////Comprar
                if (request.opcion == 1)
                {
                    productos.Add(new ProductosResponseDto
                    {
                        nroOrden = 1,
                        texto = "Tus cuotas de pago serán fijas y en soles.",
                        tipo = "descripcion"
                    });

                    productos.Add(new ProductosResponseDto
                    {
                        nroOrden = 2,
                        texto = "Financiamos hasta el 90% del valor de la vivienda.",
                        tipo = "descripcion"
                    });

                    productos.Add(new ProductosResponseDto
                    {
                        nroOrden = 3,
                        texto = "Podrás realizar prepagos parciales en cualquier momento y prepagos totales a partir del año 5.",
                        tipo = "descripcion"
                    });

                    productos.Add(new ProductosResponseDto
                    {
                        nroOrden = 4,
                        texto = "Podrás pagar tu crédito en un plazo de 5 a 25 años.",
                        tipo = "descripcion"
                    });

                    productos.Add(new ProductosResponseDto
                    {
                        nroOrden = 5,
                        texto = "Obtén el Bono del Buen Pagador dependiendo el valor de la vivienda.",
                        tipo = "descripcion"
                    });
                }

                /////Construir
                if (request.opcion == 2)
                {
                    productos.Add(new ProductosResponseDto
                    {
                        nroOrden = 1,
                        texto = "Tus cuotas de pago serán fijas y en soles.",
                        tipo = "descripcion"
                    });

                    productos.Add(new ProductosResponseDto
                    {
                        nroOrden = 2,
                        texto = "Considera como cuota inicial el valor del terreno o aires para la construcción de tu vivienda.",
                        tipo = "descripcion"
                    });

                    productos.Add(new ProductosResponseDto
                    {
                        nroOrden = 3,
                        texto = "Podrás realizar prepagos parciales en cualquier momento y prepagos totales a partir del año 5.",
                        tipo = "descripcion"
                    });

                    productos.Add(new ProductosResponseDto
                    {
                        nroOrden = 4,
                        texto = "Plazo de Pago de 5 a 25 años.",
                        tipo = "descripcion"
                    });

                    productos.Add(new ProductosResponseDto
                    {
                        nroOrden = 5,
                        texto = "Obtén el Bono del Buen Pagador dependiendo el valor de la vivienda.",
                        tipo = "descripcion"
                    });


                }

                /////Mejorar
                if (request.opcion == 3)
                {
                    productos.Add(new ProductosResponseDto
                    {
                        nroOrden = 1,
                        texto = "Tus cuotas de pago serán fijas y en soles.",
                        tipo = "descripcion"
                    });

                    productos.Add(new ProductosResponseDto
                    {
                        nroOrden = 2,
                        texto = "Considera como cuota inicial el valor de la vivienda.",
                        tipo = "descripcion"
                    });

                    productos.Add(new ProductosResponseDto
                    {
                        nroOrden = 3,
                        texto = "Podrás realizar prepagos parciales o totales en cualquier momento.",
                        tipo = "descripcion"
                    });

                    productos.Add(new ProductosResponseDto
                    {
                        nroOrden = 4,
                        texto = "Plazo de Pago de 5 a 25 años.",
                        tipo = "descripcion"
                    });

                }


            }

            if (request.Tipo_producto == 4)
            {
                /////Comprar
                if (request.opcion == 1)
                {
                    productos.Add(new ProductosResponseDto
                    {
                        nroOrden = 1,
                        texto = "Ser mayor de edad.",
                        tipo= "descripcion"
                    });

                    productos.Add(new ProductosResponseDto
                    {
                        nroOrden = 2,
                        texto = "Ser evaluado por una institución Financiera.",
                        tipo = "descripcion"
                    });

                    productos.Add(new ProductosResponseDto
                    {
                        nroOrden = 3,
                        texto = "Contar con una cuota inicial mínima desde el 7.5% del valor de la vivienda.",
                        tipo = "descripcion"
                    });

                    productos.Add(new ProductosResponseDto
                    {
                        nroOrden = 4,
                        texto = "No tener vivienda inscrita en Registros Públicos, aplica a cónyuge e hijos menores de edad.",
                        tipo = "descripcion"
                    });

                    productos.Add(new ProductosResponseDto
                    {
                        nroOrden = 5,
                        texto = "Para acceder al Bono de Buen Pagador, no debes haber recibido apoyo habitacional del Estado.",
                        tipo = "descripcion"
                    });
                }

                /////Construir
                if (request.opcion == 2)
                {
                    productos.Add(new ProductosResponseDto
                    {
                        nroOrden = 1,
                        texto = "Ser mayor de edad.",
                        tipo = "descripcion"
                    });

                    productos.Add(new ProductosResponseDto
                    {
                        nroOrden = 2,
                        texto = "Ser evaluado por una institución Financiera.",
                        tipo = "descripcion"
                    });

                    productos.Add(new ProductosResponseDto
                    {
                        nroOrden = 3,
                        texto = "Contar con un terreno o aires independizados inscrito en Registros Públicos, sin cargas ni gravámenes.",
                        tipo = "descripcion"
                    });

                    productos.Add(new ProductosResponseDto
                    {
                        nroOrden = 4,
                        texto = "El terreno o aires debe contar con acceso a los servicios de luz, agua y desagüe o una solución alternativa (tanques, reservorios, pozo séptico, entre otros).",
                        tipo = "descripcion"
                    });

                    productos.Add(new ProductosResponseDto
                    {
                        nroOrden = 5,
                        texto = "Para acceder al Bono de Buen Pagador, no debes haber recibido apoyo habitacional del Estado.",
                        tipo = "descripcion"
                    });


                }

                /////Mejorar
                if (request.opcion == 3)
                {
                    productos.Add(new ProductosResponseDto
                    {
                        nroOrden = 1,
                        texto = "Ser mayor de edad.",
                        tipo = "descripcion"
                    });

                    productos.Add(new ProductosResponseDto
                    {
                        nroOrden = 2,
                        texto = "Ser evaluado por una institución Financiera.",
                        tipo = "descripcion"
                    });

                    productos.Add(new ProductosResponseDto
                    {
                        nroOrden = 3,
                        texto = "Contar con una vivienda inscrita en Registros Públicos, sin cargas ni gravámenes.",
                        tipo = "descripcion"
                    });

                    productos.Add(new ProductosResponseDto
                    {
                        nroOrden = 4,
                        texto = "La vivienda debe contar con acceso a los servicios de luz, agua y desagüe o solución alternativa (tanques, reservorios, pozo séptico, entre otros).",
                        tipo = "descripcion"
                    });

                }


            }



            // response.Data = Mapping.Map<IEnumerable<ProductosEntity>, IEnumerable<ProductosDto>>(gerenciaEntities);
            response = productos;
            return response;
        }

        public async Task<IEnumerable<ProductosWebResponseDto>> GetListWeb(ProductosWebDto request)
        {
   
            var prodcutoslistado = await _productosDomain.GetList(request);

            return prodcutoslistado;
        }
    }
}
