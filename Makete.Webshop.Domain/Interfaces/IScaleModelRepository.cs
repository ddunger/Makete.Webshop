using Makete.Webshop.Domain.Models;

namespace Makete.Webshop.Domain.Interfaces
{
    public interface IScaleModelRepository
    {
        List<ScaleModel> GetScaleModels();
        ScaleModel? GetById(int id);
        void Create(ScaleModel scaleModel);
        void Delete(ScaleModel scaleModel);
        void Update(ScaleModel scaleModel);


    }
}

