using Microsoft.AspNetCore.Mvc;
using WebMvc.Models;

namespace WebMvc.Controllers
{
    public class AssetController : Controller
    {
        public static List<AssetViewModel> _assetViewModels = new List<AssetViewModel>()
        {
            new AssetViewModel(1,"Asus ROG","66616",2020,"Project"),
            new AssetViewModel(2,"Alienware","66617",2020,"Project"),
        };

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Save([Bind("Id, Name, SerialNumber, PurchaseYear, Location")] AssetViewModel asset)
        {
            _assetViewModels.Add(asset);
            return Redirect("List");
        }

        public IActionResult List()
        {
            return View(_assetViewModels);
        }

        public IActionResult Edit(int? id)
        {
            AssetViewModel asset = _assetViewModels.Find(x=>x.Id.Equals(id));
            return View(asset);
        }

        [HttpPost]
        public IActionResult Update(int id, [Bind("Id, Name, SerialNumber, PurchaseYear, Location")] AssetViewModel asset)
        {
            AssetViewModel assetOld = _assetViewModels.Find(x => x.Id.Equals(id));
            _assetViewModels.Remove(assetOld);

            _assetViewModels.Add(asset);
            return Redirect("List");
        }

        public IActionResult Details(int id)
        {
            AssetViewModel asset =(
                from p in _assetViewModels
                where p.Id.Equals(id)
                select p
                ).SingleOrDefault(new AssetViewModel());
            return View(asset);
        }

        public IActionResult Delete(int? id)
        {
            AssetViewModel asset = _assetViewModels.Find(x => x.Id.Equals(id));
            _assetViewModels.Remove(asset);

            return Redirect("/Asset/List");
        }
    }
}
