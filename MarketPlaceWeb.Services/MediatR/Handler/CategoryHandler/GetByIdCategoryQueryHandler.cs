using MarketPlaceWeb.DataAccess.Repositories.IRepository;
using MarketPlaceWeb.Services.MediatR.Commands.CategoryQuery;
using MarketPlaceWeb.Services.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlaceWeb.Services.MediatR.Handler.CategoryHandler
{
    public class GetByIdCategoryQueryHandler : IRequestHandler<GetByIdCategoryQuery, CategoryViewModel>
    {
        private readonly ICateogryRepository _repository;
        public GetByIdCategoryQueryHandler(ICateogryRepository repository)
        {
            _repository = repository;
        }
        public async Task<CategoryViewModel> Handle(GetByIdCategoryQuery request, CancellationToken cancellationToken)
        {
            var cateogry = await _repository.GetCategoryById(request.Id);

            CategoryViewModel categorydto = new CategoryViewModel()
            {
                Id = cateogry.Id,
                Name = cateogry.Name,
                Description = cateogry.Describtion,
                ParentCategory = cateogry.ParentCategory != null ? new CategoryViewModel
                {
                    Id = cateogry.ParentCategory.Id,
                    Name = cateogry.ParentCategory.Name,
                    Description = cateogry.Describtion,
                } : null
            };
            return categorydto;
        }
    }
}
