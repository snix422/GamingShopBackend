using FootballShopBackend.Application.Contracts.Persistance;
using FootballShopBackend.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballShopBackend.Application.Features.Products.Commands.DeleteProduct
{
    public class DeleteCourseCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IAsyncRepository<Product> _asyncRepository;

        public DeleteCourseCommandHandler(IAsyncRepository<Product> asyncRepository)
        {
            _asyncRepository = asyncRepository;
        }

        public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var productToDelete = await _asyncRepository.GetByIdAsync(request.ProductId);
            await _asyncRepository.DeleteAsync(productToDelete);
        }
    }
}
