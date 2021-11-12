using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assessment_Juan.Commands.Handlers
{
    public interface IHandlerEvents<TEvent> where TEvent : class
    {
        Task Execute(TEvent @event);
    }
}
