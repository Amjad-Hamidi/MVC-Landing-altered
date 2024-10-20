using AutoMapper;
using Landing.DAL.Data;
using Landing.DAL.Models;
using Landing.PL.Areas.Dashboard.ViewModels;
using Landing.PL.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Landing.PL.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]

    public class PortfoilosController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public PortfoilosController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }


        public IActionResult Index()
        {
            // Index.cshtml ارسال متغيرين الى 
            ViewData["userName"] = "Amjad Hamidi";
            ViewBag.Email = "amjad@gmail.com";
            
            // convert from Service to ServicesVM
            var services = context.Portfoilos.ToList();
            var servicesVM = mapper.Map<IEnumerable<PortfoilosVM>>(services);
            return View(servicesVM);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PortfoiloFormVM vm)
        {   // Mapping

            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            
            var portfoilo = mapper.Map<Portfoilo>(vm); // <Destination> (Source)

            context.Add(portfoilo); // OR :  context.Portfoilo.Add(service);
			context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var service = context.Services.Find(id);
            if (service is null)
            {
                return NotFound();
            }

            //Mapping (M to VM)
            var serviceModel = mapper.Map<ServiceDetailsVM>(service);

            return View(serviceModel);
        }

        /*

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var service = context.Services.Find(id);
            if(service is null)
            {
                return NotFound();
            }

            //Mapping (with ServicesVM) => just (Name,IsDeleted)
            var serviceVM = mapper.Map<ServicesVM>(service);
            return View(serviceVM);
        }
        */
        //[HttpPost,ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var service = context.Services.Find(id);
            if(service is null)
            {
                return RedirectToAction(nameof(Index));
            }

            // لازم احذف الصورة الي فيها service كل ما احذف 
            FilesSettings.DeleteFile(service.ImageName, "images"); // وبحذف الصورة الي جواها images بوصل مجلد

            context.Services.Remove(service);
            context.SaveChanges();
            return Ok(new {message="service deleted"}); // json ملاحظة : بدون المسج رح يرجعلي الرقم 200 فقط , لازم اعطيه مسح عشان يرجعلي
			//return RedirectToAction(nameof(Index));
		}

        public IActionResult Edit(int id)
        {
            var service = context.Services.Find(id);
            if(service is null)
            {
                return NotFound();
            }

            var serviceVm = mapper.Map<ServiceFormVM>(service);
            return View(serviceVm);
        }
        [HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(ServiceFormVM vm)
        {
			var service = context.Services.Find(vm.Id);
			if (service is null)
			{
				return NotFound();
			}

			// if (!ModelState.IsValid) الي رح نستعملها تحت لما نقول ModelState من ال Image بتضمن في حال ما عدلنا الصورة يمشي الوضع طبيعي لانو رح يستثني if هاي ال
			if (vm.Image is null) // معناها هو ما عدل على الصورة , خلاها فاضية null اذا كانت هاي 
            {
                ModelState.Remove("Image"); // Image : الصورة الي بدو يبعثها
            }                               // ImageName : الصورة الموجودة قبل ما تعدلت
            else // معناها انو عدل الصورة وغيرها
            {
                FilesSettings.DeleteFile(service.ImageName, "Images"); // تعني : اذا عدل الصورة , يحذف الصورة القديمة من المجلد
				vm.ImageName = FilesSettings.UploadFile(vm.Image, "images"); // ثم يوضع الصورة الجديدة
			}


			if (!ModelState.IsValid)
            {
                return View(vm);
            }
                           


            mapper.Map(vm,service); // Mapping from VM to M
            context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
