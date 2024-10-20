using AutoMapper;
using Landing.DAL.Models;
using Landing.PL.Areas.Dashboard.ViewModels;

namespace Landing.PL.Mapping
{
	public class MappingProfile : Profile
	{
		public MappingProfile() 
		{
			CreateMap<ServiceFormVM, Service>().ReverseMap(); // from VM to M and from M to VM
			CreateMap<Service, ServicesVM>(); // from M to VM
			CreateMap<Service, ServiceDetailsVM>(); // from M to VM




			CreateMap<PortfoiloFormVM, Portfoilo>().ReverseMap(); // from VM to M and from M to VM
			CreateMap<Portfoilo, PortfoilosVM>(); // from M to VM
			CreateMap<Portfoilo, PortfoiloDetailsVM>(); // from M to VM




			CreateMap<ItemFormVM, Item>().ReverseMap(); // from VM to M and from M to VM
			CreateMap<Item, ItemsVM>(); // from M to VM
			CreateMap<Item, ItemDetailsVM>(); // from M to VM
		}
	}
}
