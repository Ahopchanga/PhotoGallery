using PhotoGallery.Interfaces.Models;

namespace PhotoGallery.Interfaces.Services;

public interface IUserService<TModel> where TModel : IUserModel
{
    Task<bool> Add(TModel model);

    Task<TModel> Get(string id);

    Task<IEnumerable<TModel>> GetAll();

    Task<bool> Update(TModel model);

    Task<bool> Delete(string id);

}