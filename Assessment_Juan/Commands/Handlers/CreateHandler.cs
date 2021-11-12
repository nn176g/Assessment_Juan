using Assessment_Juan.Business.Interfaces;
using Assessment_Juan.Impl;
using Assessment_Juan.Model.Entities;
using Assessment_Juan.ServiceBus;
using Microsoft.Azure.ServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Assessment_Juan.Commands.Handlers
{
    public class CreateHandler : IHandler<CreateCommand>
    {
        private readonly IServiceBus _serviceBus;
        private readonly ICompraBusiness _compraBusiness;

        public CreateHandler(IServiceBus serviceBus, ICompraBusiness compraBusiness)
        {
            _serviceBus = serviceBus;
            _compraBusiness = compraBusiness;
        }

        public async Task Execute(CreateCommand model)
        {
            // 01. Your logic to order creation
            Compra compra = new Compra
            {
                Id = model.Inventario.Id,
                Cantidad = model.Inventario.Cantidad,
                FechaCompra = model.Inventario.FechaCompra,
                ProductoId = model.Inventario.ProductoId,
                Usuario = model.Inventario.Usuario
            };
            await _compraBusiness.Insert(compra);
            // 02. Azure Service Bus
            var client = _serviceBus.GetQueueClient("inventory-stock");

            var json = JsonSerializer.Serialize(
                new Producto
                {
                    Id = model.Inventario.ProductoId,
                    Cantidad = Convert.ToInt32(model.Inventario.Cantidad)
                });

            await client.SendAsync(
                new Message(Encoding.UTF8.GetBytes(json))
            );

            await client.CloseAsync();
        }
    }
}
