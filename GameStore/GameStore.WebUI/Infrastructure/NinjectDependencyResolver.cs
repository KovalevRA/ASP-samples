using GameStore.Domain.Abstract;
using GameStore.Domain.Concrete;
using GameStore.Domain.Entities;
using Moq;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
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

			int i = 1;
			foreach (var game in mock.Object.Games)
			{
				game.GameId = i++;
				game.Description = @"Мы добавили блок Razor, который создает небольшую HTML-форму для каждого товара в списке. Отправка этой формы приводит к вызову метода действия AddToCart() из контроллера Cart (который вскоре будет реализован).

По умолчанию вспомогательный метод BeginForm() создает форму, которая использует HTTP - метод POST.Это можно изменить, обеспечив работу формы с HTTP - методом GET, но следует соблюдать осторожность.В спецификации HTTP указано, что запросы GET не должны быть изменяющими, а добавление товара в корзину определенно считается изменением.

Использование вспомогательного метода Html.BeginForm() в списке товаров означает, что каждая кнопка ""Добавить в корзину"" визуализируется в собственном отдельном HTML - элементе<form>.Это может поначалу удивить, если вам ранее приходилось разрабатывать приложения с помощью ASP.NET Web Forms.В ASP.NET Web Forms существует ограничение, допускающее определение только одной формы на странице, если требуется наличие средства состояния представления или сложных элементов управления(которые обычно полагаются на состояние представления).";
			}
			kernel.Bind<IGameRepository>().ToConstant(mock.Object);
			//kernel.Bind<IGameRepository>().To<EFGameRepository>();
		}
	}
}