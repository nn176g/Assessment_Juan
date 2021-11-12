using Assessment_Juan.Model.Entities;
using System.Threading.Tasks;

namespace Assessment_Juan.Commands.Handlers
{
    public interface IHandler<TCommand> where TCommand : class
    {
        public Task Execute(TCommand command);
        //Task Execute(Compra model);
    }
}
