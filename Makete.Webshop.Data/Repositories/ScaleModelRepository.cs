using Makete.Webshop.Domain.Interfaces;
using Makete.Webshop.Domain.Models;
using Microsoft.Extensions.Configuration;




namespace Makete.Webshop.Data.Repositories
{
    public class ScaleModelRepository : IScaleModelRepository
    {

        private readonly string _connectionString = string.Empty;

        public ScaleModelRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")!;
        }


        private static List<ScaleModel> _scaleModels;

        // simulacija baze podataka

        //public ScaleModelRepository(IConfiguration configuration)
        //{
        //    if (_scaleModels == null)
        //    {
        //        var airfix = new Brand(1, "Airfix");
        //        var italeri = new Brand(2, "Italeri");
        //        var revell = new Brand(3, "Revell");

        //        _scaleModels = new List<ScaleModel>
        //        {
        //        new ScaleModel {Id = 1, Name = "Hawker Hurricane", ItemBrand = airfix, Category = "Zrakoplovi", Scale = "1/35", AmountAvailable = 8, Price = 20},
        //        new ScaleModel {Id = 2, Name = "BMW Mini Cooper S", ItemBrand = italeri, Category = "Vozila", Scale = "1/71", AmountAvailable = 3, Price = 43},
        //        new ScaleModel {Id = 3, Name = "HMS Victory", ItemBrand = revell, Category = "Jedrenjaci", Scale = "1/225", AmountAvailable = 6, Price = 124},
        //        };
        //    }
        //}


        public void Create(ScaleModel scaleModel)
        {
            _scaleModels.Add(scaleModel);
        }

        public void Delete(ScaleModel scaleModel)
        {
            var data = _scaleModels.SingleOrDefault(x => x.Id == scaleModel.Id);
            if (data != null)
            {
                _scaleModels.Remove(data);
            }
        }

        public ScaleModel GetById(int id)
        {
            var data = _scaleModels.SingleOrDefault(x => x.Id == id);

            return data;
        }

        public List<ScaleModel> GetScaleModels()
        {
            return _scaleModels;
        }

        public void Update(ScaleModel updatedScaleModel)
        {
            var currentModel = _scaleModels.SingleOrDefault(x => x.Id == updatedScaleModel.Id);

            if (currentModel != null)
            {
                // Update properties
                //currentModel.Name = updatedScaleModel.Name;
                //currentModel.Brand = updatedScaleModel.Brand;
                //currentModel.Category = updatedScaleModel.Category;
                //currentModel.Scale = updatedScaleModel.Scale;
                //currentModel.AmountAvailable = updatedScaleModel.AmountAvailable;
            }
        }


    }
}
