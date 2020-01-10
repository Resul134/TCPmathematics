using Microsoft.VisualStudio.TestTools.UnitTesting;
using EchoServer;
using EchoClient;

namespace ServerClientUnitTest
{
    [TestClass]
    public class ServerClientUnitTest
    {
        [TestInitialize]
        public void BeforeTest()
        {
            ServerWorker server = new ServerWorker();
            ClientWorker client = new ClientWorker();

            server.Start();
        }

        [TestMethod]
        public void TestServerStart()
        {

        }
    }
}
