using MediatR;

namespace ProductManager.Application.Queries
{
	public class GetProductByIdQuery: IRequest<GetProductByIdResponse>
	{
		public Guid Id { get; set; }

		public GetProductByIdQuery(Guid id)
		{
			Id = id;
		}
	}
}
