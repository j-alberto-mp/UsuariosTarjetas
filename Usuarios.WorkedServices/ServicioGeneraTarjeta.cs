using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Usuarios.Core.Contratos.Factories;
using Usuarios.Core.Entidades;

namespace Usuarios.WorkedServices
{
    public class ServicioGeneraTarjeta : BackgroundService
    {
        private readonly ILogger<ServicioGeneraTarjeta> _logger;

        public ServicioGeneraTarjeta(ILogger<ServicioGeneraTarjeta> logger, IServiceProvider services)
        {
            _logger = logger;
            Services = services;
        }

        public IServiceProvider Services { get; }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    using (var scope = Services.CreateScope())
                    {
                        _logger.LogInformation("Consultando clientes sin tarjeta generada");

                        HttpClient httpClient = new HttpClient();
                        IServiceFactory servicio = scope.ServiceProvider.GetRequiredService<IServiceFactory>();

                        var clientes = await servicio.ServicioCliente.ObtenerUsuariosSinTarjetaAsync();

                        if (clientes.Correcto)
                        {
                            foreach (var cliente in clientes.Datos)
                            {
                                var respuesta = await httpClient.GetStringAsync("https://api.generadordni.es/v2/bank/card?results=1&include_fields=card,cvc,expiration_date,name");

                                var tarjeta = JsonConvert.DeserializeObject<Core.Dtos.TarjetaClienteDto[]>(respuesta)[0];

                                tarjeta.ClienteID = cliente.ClienteID;

                                bool correcto = await servicio.ServicioTarjetaCliente.CrearAsync(tarjeta);

                                if (correcto)
                                {
                                    cliente.TarjetaAsignada = true;

                                    await servicio.ServicioCliente.ActualizarAsync(cliente);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                }

                await Task.Delay(TimeSpan.FromSeconds(60), stoppingToken);
            }
        }
    }
}
