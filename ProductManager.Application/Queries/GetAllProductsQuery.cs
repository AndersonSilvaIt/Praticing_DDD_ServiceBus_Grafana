using MediatR;

namespace ProductManager.Application.Queries
{
	public class GetAllProductsQuery: IRequest<IEnumerable<GetProductByIdResponse>>
	{
	}
}
