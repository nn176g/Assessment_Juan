
using Assessment_Juan.Commands.Handlers;
using Assessment_Juan.Model.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inventory.Api.Events.Handlers
{
    public class ProductStockEventHandler : IHandlerEvents<IEnumerable<Producto>>
    {
        public async Task Execute(IEnumerable<Producto> @event)
        {
            // Do something awesome with your event
        }
    }
}
