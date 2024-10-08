using Makete.Webshop.Data.Repositories;
using Makete.Webshop.Domain.Interfaces;
using Makete.Webshop.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Makete.Webshop.Controllers
{
    public class ScaleModelController : Controller
    {
        private readonly IScaleModelRepository _repository;

        public ScaleModelController(IScaleModelRepository repository)
        {
            if (repository == null) throw new ArgumentNullException(nameof(repository));

            _repository = repository;
        }


        // GET: ScaleModelController
        public ActionResult Index()
        {
            return View(_repository.GetScaleModels());
        }

        // GET: ScaleModelController/Details/5
        public ActionResult Details(int id)
        {

            return View(_repository.GetById(id));
        }

        // GET: ScaleModelController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ScaleModelController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ScaleModel scaleModel)
        {
            try
            {
                var idInUse = _repository.GetById(scaleModel.Id);

                if (idInUse == null)
                {
                    _repository.Create(scaleModel);

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return RedirectToAction(nameof(Index));

                }

            }
            catch
            {
                return View();
            }
        }

        // GET: ScaleModelController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_repository.GetById(id));
        }

        // POST: ScaleModelController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ScaleModel scaleModel)
        {
            try
            {
                _repository.Update(scaleModel);


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ScaleModelController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ScaleModelController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
