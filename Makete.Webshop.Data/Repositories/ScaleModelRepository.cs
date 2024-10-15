using Makete.Webshop.Domain.Interfaces;
using Makete.Webshop.Domain.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;




namespace Makete.Webshop.Data.Repositories
{
    public class ScaleModelRepository : IScaleModelRepository
    {
        private static List<ScaleModel> _scaleModels;

        private readonly string _connectionString = string.Empty;

        public ScaleModelRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")!;


            using var connection = new SqlConnection(_connectionString);

            //using var command = new SqlCommand($"SELECT * FROM ScaleModels", connection);

            using var command = new SqlCommand(
                @"SELECT sm.*, b.BrandName 
                  FROM ScaleModels sm
                  JOIN Brands b ON sm.BrandId = b.BrandId",
                connection);

            connection.Open();

            using var reader = command.ExecuteReader();

            _scaleModels = new List<ScaleModel>();


            while (reader.Read())
            {
                _scaleModels.Add(new ScaleModel()
                {
                    Id = reader.GetInt32("Id"),
                    Name = reader.GetString("Name"),
                    ItemBrand = new Brand { BrandId = reader.GetInt32("BrandId"), BrandName = reader.GetString("BrandName") },
                    Category = reader.GetString("Category"),
                    Scale = reader.GetString("Scale"),
                    AmountAvailable = reader.GetInt32("AmountAvailable"),
                    Price = reader.GetDecimal("Price")
                });
            }


        }



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
