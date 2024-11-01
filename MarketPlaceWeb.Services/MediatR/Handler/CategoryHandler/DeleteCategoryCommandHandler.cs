using MarketPlaceWeb.DataAccess.Repositories.IRepository;
using MarketPlaceWeb.Services.MediatR.Commands.CategoryQuery;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlaceWeb.Services.MediatR.Handler.CategoryHandler
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommands, bool>
    {
        private readonly ICateogryRepository _repository;
        public DeleteCategoryCommandHandler(ICateogryRepository repository)
        {
            _repository = repository;   
        }
        public async Task<bool> Handle(DeleteCategoryCommands request, CancellationToken cancellationToken)
        {
            var category=await _repository.GetCategoryById(request.Id);

            if (category == null) throw new Exception("Category not found!");
            
            await _repository.DeleteCategory(category);
            return true;
        }
    }
}
