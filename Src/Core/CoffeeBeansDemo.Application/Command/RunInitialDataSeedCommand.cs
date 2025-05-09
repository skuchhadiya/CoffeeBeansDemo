using MediatR;

namespace CoffeeBeansDemo.Application.Command
{
    public class RunInitialDataSeedCommand: IRequest<bool>
    {
    }
}
