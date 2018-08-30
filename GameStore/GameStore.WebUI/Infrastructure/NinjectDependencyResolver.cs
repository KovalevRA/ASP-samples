using GameStore.Domain.Abstract;
using GameStore.Domain.Concrete;
using GameStore.Domain.Entities;
using Moq;
using Ninject;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace GameStore.WebUI.Infrastructure
{
	public class NinjectDependencyResolver : IDependencyResolver
	{
		IKernel kernel;

		public NinjectDependencyResolver(IKernel kernelParam)
		{
			kernel = kernelParam;
			AddBindings();
		}

		public object GetService(Type serviceType)
		{
			return kernel.TryGet(serviceType);
		}

		public IEnumerable<object> GetServices(Type serviceType)
		{
			return kernel.GetAll(serviceType);
		}

		void AddBindings()
		{
			Mock<IGameRepository> mock = new Mock<IGameRepository>();
			var mockGames = mock.Setup(m => m.Games);
			mockGames.Returns(new List<Game>
			{
				new Game {Name = "SimCity", Price = 1499, Category = "Симулятор"},
				new Game { Name = "TITANFALL", Price=2299, Category = "Action" },
				new Game { Name = "Battlefield 4", Price=899.4M, Category = "Action" },
				new Game {  Name = "GTA 4", Price = 899, Category = "Action"},
				new Game {Name = "SimCity 2", Price = 1499, Category = "Симулятор"},
				new Game { Name = "TITANFALL 2", Price=2299, Category = "Action" },
				new Game { Name = "Battlefield 5", Price=899.4M, Category = "Action" },
				new Game {Name = "SimCity 3 ", Price = 1499, Category = "Симулятор"},
				new Game { Name = "TITANFALL 3", Price=2299, Category = "Action" },
				new Game { Name = "Battlefield 6", Price=899.4M, Category = "Action" },
			});
			kernel.Bind<IGameRepository>().ToConstant(mock.Object);
			//kernel.Bind<IGameRepository>().To<EFGameRepository>();
		}
	}
}