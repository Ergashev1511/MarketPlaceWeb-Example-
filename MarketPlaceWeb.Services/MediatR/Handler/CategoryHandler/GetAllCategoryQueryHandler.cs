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
    public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQuery, List<CategoryViewModel>>
    {
        private readonly ICateogryRepository _repository;
        public GetAllCategoryQueryHandler(ICateogryRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<CategoryViewModel>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            var categories = await _repository.GetAllCategory();

            return categories.Select(a => new CategoryViewModel()
            {
                Id = a.Id,
                Name = a.Name,
                Description = a.Describtion,
                ParentCategory = a.ParentCategory != null ? new CategoryViewModel
                {
                    Id = a.ParentCategory.Id,
                    Name = a.ParentCategory.Name,
                    Description = a.Describtion,
                } : null
            }).ToList();
        }
    }
}
