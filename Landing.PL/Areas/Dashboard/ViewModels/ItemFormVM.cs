using Microsoft.AspNetCore.Mvc.Rendering;

namespace Landing.PL.Areas.Dashboard.ViewModels
{
    public class ItemFormVM
	{
        public string Name { get; set; }
        public string Description { get; set; }

        public int Id { get; set; } 
        public bool IsDeleted {  get; set; }
        

        public int? PortfoiloId { get; set; } // تابعة PortfoilosVM هي لاي  ItemFormVM تحديد لكل 
        public SelectList? Portfoilos { get; set; }
        // OR : by IEnumerable
        //public IEnumerable<PortfoilosVM>? Portfoilos { get; set; }

        /*
        public IFormFile Image {  get; set; } 
        public string? ImageName { get; set; } 
        */
    }
}
