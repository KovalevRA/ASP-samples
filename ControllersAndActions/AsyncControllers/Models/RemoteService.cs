using System.Threading;

namespace AsyncControllers.Models
{
	public class RemoteService
	{
		public string GetRemoteData()
		{
			Thread.Sleep(2000);
			return "Hello world";
		}
	}
}