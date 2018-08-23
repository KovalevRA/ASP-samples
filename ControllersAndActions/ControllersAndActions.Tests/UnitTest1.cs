using ControllersAndActions.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;

namespace ControllersAndActions.Tests
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{
		}

		[TestMethod]
		public void ControllerTest()
		{
			ExampleController controller = new ExampleController();

			ViewResult result = controller.Index();

			Assert.AreEqual("Homepage", result.ViewName);
		}

		[TestMethod]
		public void ViewSelectionTest()
		{
			ExampleController controller = new ExampleController();

			ViewResult result = controller.Index();

			Assert.AreEqual("", result.ViewName);
			Assert.IsInstanceOfType(result.ViewData.Model, typeof(System.DateTime));
		}
	}
}
