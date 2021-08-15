using Aerolinea.Models;
using Aerolinea.Models.Entidades;
using Aerolinea.Util;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Aerolinea.Controllers
{
    public class HomeController : Controller
    {
        private const decimal precio = 120.00M;
        private readonly ILogger<HomeController> _logger;
        private readonly ReservaVueloContext context;

        public HomeController(ILogger<HomeController> logger, ReservaVueloContext context)
        {
            _logger = logger;
            this.context = context;
        }

        public IActionResult Index()
        {
            ViewData["Origen"] = new SelectList(context.Aeropuerto.AsEnumerable(), "AeropuertoId", "Ciudad");
            ViewData["Destino"] = new SelectList(context.Aeropuerto.AsEnumerable(), "AeropuertoId", "Ciudad");

            return View();
        }
        [HttpPost]
        public IActionResult Paso2(Paso1 request)
        {
            var model = new Paso2()
            {
                FechaIda = request.FechaIda,
                FechaRetorno = request.FechaRetorno
            };

            var vuelosIda = from x in context.Vuelo
                            where x.AeropuertoOrigen == request.Origen && x.AeropuertoDestino == request.Destino
                            select new Util.Vuelo
                            {
                                OrigenIATA = x.AeropuertoOrigenNavigation.CodigoIata,
                                DestinoIATA = x.AeropuertoDestinoNavigation.CodigoIata,
                                DestinoCiudad = x.AeropuertoDestinoNavigation.Ciudad,
                                OrigenCiudad = x.AeropuertoOrigenNavigation.Ciudad,
                                FechaVuelo = string.Format("{0:dd/MM/yyyy}", request.FechaIda),
                                HoraSalida = x.HoraSalida.ToString(),
                                HoraLlegada = x.HoraLlegada.ToString(),
                                VueloId = x.VueloId,
                                Precio = precio
                            };
            var vuelosRetorno = from x in context.Vuelo
                            where x.AeropuertoDestino == request.Origen && x.AeropuertoOrigen == request.Destino
                            select new Util.Vuelo
                            {
                                OrigenIATA = x.AeropuertoOrigenNavigation.CodigoIata,
                                DestinoIATA = x.AeropuertoDestinoNavigation.CodigoIata,
                                DestinoCiudad = x.AeropuertoDestinoNavigation.Ciudad,
                                OrigenCiudad = x.AeropuertoOrigenNavigation.Ciudad,
                                FechaVuelo = string.Format("{0:dd/MM/yyyy}", request.FechaIda),
                                HoraSalida = x.HoraSalida.ToString(),
                                HoraLlegada = x.HoraLlegada.ToString(),
                                VueloId = x.VueloId,
                                Precio = precio
                            };
            model.VuelosIda = vuelosIda.ToList();
            model.VuelosRetorno = vuelosRetorno.ToList();

            return View(model);
        }

        [HttpPost]
        public IActionResult Paso3(Paso3 request)
        {
            return View(request);
        }

        [HttpPost]
        public IActionResult Paso4(Paso3 request)
        {
            var pasajero = new Pasajero
            {
                Nombres = request.Nombre,
                Apellidos = request.Apellido,
                Email = request.Correo,
                NroDocumento = request.DNI,
                Telefono = request.Telefono
            };
            context.Add(pasajero);
            context.SaveChanges();
            var reserva = new Reserva()
            {
                PasajeroId = pasajero.PasajeroId.Value,
                VueloIda = request.IDVueloIda,
                VueloRetorno = request.IDVueloRetorno,
                FechaIda = request.FechaIda,
                FechaVuelta = request.FechaRetorno
            };
            context.Add(reserva);
            context.SaveChanges();
            ViewData["Pasajero"] = context.Pasajero.Find(reserva.PasajeroId).Nombres + " " +context.Pasajero.Find(reserva.PasajeroId).Apellidos;
            return View(reserva);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
