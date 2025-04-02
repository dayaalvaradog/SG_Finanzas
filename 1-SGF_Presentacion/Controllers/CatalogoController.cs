using _1_SGF_Presentacion.Helpers;
using _1_SGF_Presentacion.Models;
using _2_SGF_Modelo.Entidades;
using _6_SGF_Entidades.Catalogos;
using _6_SGF_Entidades.Login;
using _8_SGF_Log;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Collections.Generic;

namespace _1_SGF_Presentacion.Controllers
{
    public class CatalogoController : Controller
    {
        private readonly List<SpecialDate> _SpecialDates;
        public CatalogoController(IOptionsMonitor<List<SpecialDate>> options)
        {
            _SpecialDates = options.CurrentValue;
        }

        public static ListaCatalogos CargarCatalogos()
        {
            ListaCatalogos catalogos = new ListaCatalogos();

            catalogos.Categorias = CatalogoModel.ObtenerCategorias().Result.Result;
            catalogos.Clasificaciones = CatalogoModel.ObtenerClasificaciones().Result.Result;
            catalogos.PermisoUsuario = CatalogoModel.ObtenerTiposPermiso().Result.Result;
            catalogos.TiposUsuario = CatalogoModel.ObtenerTiposUsuario().Result.Result;
            catalogos.TiposMenu = CatalogoModel.ObtenerTiposMenu().Result.Result;

            return catalogos;
        }

        [HttpGet]
        public async Task<Respuesta<List<Categoria>>> ObtenerCategorias()
        {
            Respuesta<List<Categoria>> resultado = new Respuesta<List<Categoria>>();
            try
            {
                resultado = await CatalogoModel.ObtenerCategorias();

                if (resultado.Result != null)
                {
                    return resultado;
                }
                else
                {
                    WriteLog.Log("ObtenerCategorias", resultado.TextError, DatosAppSettings.GetData("Url:Log"), "");
                    resultado.TextError = "Ocurrió un error obteniendo los datos del usuario";
                    resultado.NumError = 1;
                    return resultado;
                }
            }
            catch (Exception ex)
            {
                WriteLog.Log("ObtenerCategorias", (ex.InnerException != null ? ex.InnerException.Message : ex.Message),
                    DatosAppSettings.GetData("Url:Log"), "");
                resultado.TextError = "Ocurrió un error al consultar la información";
                resultado.NumError = 2;
                resultado.Result = null;

                return resultado;
            }
        }

        [HttpGet]
        public async Task<Respuesta<List<Clasificacion>>> ObtenerClasificaciones()
        {
            Respuesta<List<Clasificacion>> resultado = new Respuesta<List<Clasificacion>>();
            try
            {
                resultado = await CatalogoModel.ObtenerClasificaciones();

                if (resultado.Result != null)
                {
                    return resultado;
                }
                else
                {
                    WriteLog.Log("ObtenerClasificaciones", resultado.TextError, DatosAppSettings.GetData("Url:Log"), "");
                    resultado.TextError = "Ocurrió un error obteniendo los datos del usuario";
                    resultado.NumError = 1;
                    return resultado;
                }
            }
            catch (Exception ex)
            {
                WriteLog.Log("ObtenerClasificaciones", (ex.InnerException != null ? ex.InnerException.Message : ex.Message),
                    DatosAppSettings.GetData("Url:Log"), "");
                resultado.TextError = "Ocurrió un error al consultar la información";
                resultado.NumError = 2;
                resultado.Result = null;

                return resultado;
            }

        }

        [HttpGet]
        public async Task<Respuesta<List<TiposUsuario>>> ObtenerTiposUsuario()
        {
            Respuesta<List<TiposUsuario>> resultado = new Respuesta<List<TiposUsuario>>();
            try
            {
                resultado = await CatalogoModel.ObtenerTiposUsuario();

                if (resultado.Result != null)
                {
                    return resultado;
                }
                else
                {
                    WriteLog.Log("ObtenerTiposUsuario", resultado.TextError, DatosAppSettings.GetData("Url:Log"), "");
                    resultado.TextError = "Ocurrió un error obteniendo los datos del usuario";
                    resultado.NumError = 1;
                    return resultado;
                }
            }
            catch (Exception ex)
            {
                WriteLog.Log("ObtenerTiposUsuario", (ex.InnerException != null ? ex.InnerException.Message : ex.Message),
                    DatosAppSettings.GetData("Url:Log"), "");
                resultado.TextError = "Ocurrió un error al consultar la información";
                resultado.NumError = 2;
                resultado.Result = null;

                return resultado;
            }

        }

        [HttpGet]
        public async Task<Respuesta<List<PermisoUsuario>>> ObtenerTiposPermiso()
        {
            Respuesta<List<PermisoUsuario>> resultado = new Respuesta<List<PermisoUsuario>>();
            try
            {
                resultado = await CatalogoModel.ObtenerTiposPermiso();

                if (resultado.Result != null)
                {
                    return resultado;
                }
                else
                {
                    WriteLog.Log("ObtenerTiposPermiso", resultado.TextError, DatosAppSettings.GetData("Url:Log"), "");
                    resultado.TextError = "Ocurrió un error obteniendo los datos del usuario";
                    resultado.NumError = 1;
                    return resultado;
                }
            }
            catch (Exception ex)
            {
                WriteLog.Log("ObtenerTiposPermiso", (ex.InnerException != null ? ex.InnerException.Message : ex.Message),
                    DatosAppSettings.GetData("Url:Log"), "");
                resultado.TextError = "Ocurrió un error al consultar la información";
                resultado.NumError = 2;
                resultado.Result = null;

                return resultado;
            }

        }

        [HttpGet]
        public async Task<Respuesta<List<TipoMenu>>> ObtenerTiposMenu()
        {
            Respuesta<List<TipoMenu>> resultado = new Respuesta<List<TipoMenu>>();
            try
            {
                resultado = await CatalogoModel.ObtenerTiposMenu();

                if (resultado.Result != null)
                {
                    return resultado;
                }
                else
                {
                    WriteLog.Log("ObtenerTiposMenu", resultado.TextError, DatosAppSettings.GetData("Url:Log"), "");
                    resultado.TextError = "Ocurrió un error obteniendo los datos del usuario";
                    resultado.NumError = 1;
                    return resultado;
                }
            }
            catch (Exception ex)
            {
                WriteLog.Log("ObtenerTiposMenu", (ex.InnerException != null ? ex.InnerException.Message : ex.Message),
                    DatosAppSettings.GetData("Url:Log"), "");
                resultado.TextError = "Ocurrió un error al consultar la información";
                resultado.NumError = 2;
                resultado.Result = null;

                return resultado;
            }

        }
    }
}
