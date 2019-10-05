using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jurify.Autenticador.Web.UseCases.Advogados.CriarUsuarioInicial
{
    public class CriarUsuarioNovoCommandMessage
    {
        public static void Publish(Object oab)
        {
            var factory = new ConnectionFactory() { Uri = new Uri("amqp://vcyzhpzr:GnyseoVEaDMLarLRnf0OlkKLV5eADyyw@prawn.rmq.cloudamqp.com/vcyzhpzr") };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "validar-oab",
                                     durable: true,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var oabJson = JsonConvert.SerializeObject(oab);
                var body = Encoding.UTF8.GetBytes(oabJson);

                channel.BasicPublish(exchange: "",
                                     routingKey: "validar-oab",
                                     basicProperties: null,
                                     body: body);
            }


        }
    }
}
