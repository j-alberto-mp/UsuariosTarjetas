using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace Usuarios.Core.Dtos
{
    public class TarjetaClienteDto
    {
        public int TarjetaClienteID { get; set; }
        public int ClienteID { get; set; }
        public string NumeroTarjeta { get; set; }
        public string FechaVencimiento { get; set; }
        public string Cvv { get; set; }
        public string Emisor { get; set; }

        [JsonExtensionData]
        private IDictionary<string, JToken> _additionalData;

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            NumeroTarjeta = (string)_additionalData["card"];
            FechaVencimiento = (string)_additionalData["expiration_date"];
            Cvv = (string)_additionalData["cvc"];
            Emisor = (string)_additionalData["name"];
        }

        public TarjetaClienteDto()
        {
            _additionalData = new Dictionary<string, JToken>();
        }
    }
}
