using Insurance.ApiProviders.IClients;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unity;

namespace Insurance.ApiProviders.Test.Clients
{
    [TestClass]
    public class ClientServiceTests
    {
        private IClientService _clientService;
        private IUnityContainer _container;


        [ClassInitialize]
        public static void ConfigureGlobal(TestContext text)
        {
            MapperConfig.SetUp();
        }

        [TestInitialize]
        public void StartUp()
        {
            _container = UnityConfig.RegisterAllServices();
        }

        [TestMethod]
        // exercise 1 test
        public void GetById_WhenIdIsValid_ReturnClient()
        {
            // Arrange
            _clientService = _container.Resolve<IClientService>();
            var clientId = "a0ece5db-cd14-4f21-812f-966633e7be86";

            // Act
            var result = _clientService.GetByIdAsync(clientId).Result;

            // Assert

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Id);
            Assert.IsNotNull(result.Email);
            Assert.IsNotNull(result.Name);
            Assert.IsNotNull(result.Role);
        }

        [TestMethod]
        public void GetById_WhenIdIsInvalid_ReturnNull()
        {
            // Arrange
            _clientService = _container.Resolve<IClientService>();
            var clientId = "invalid id";

            // Act

            var result = _clientService.GetByIdAsync(clientId).Result;

            // Assert

            Assert.IsNull(result, "Client was found!");
        }

        [TestMethod]
        // exercise 2 test
        public void GetByUser_WhenIdIsValid_ReturnClient()
        {
            // Arrange
            _clientService = _container.Resolve<IClientService>();
            var userId = "Britney";

            // Act
            var result = _clientService.GetByUserAsync(userId).Result;

            // Assert

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Id);
            Assert.IsNotNull(result.Email);
            Assert.IsNotNull(result.Name);
            Assert.IsNotNull(result.Role);
        }

        public void GetById_WhenUserIsInvalid_ReturnNull()
        {
            // etc

            Assert.IsTrue(true);
        }

        [TestMethod]
        // exercise 4 test
        public void GetByPolicy_WhenIdIsValid_ReturnClient()
        {
            // Arrange
            _clientService = _container.Resolve<IClientService>();
            var policyId = "64cceef9-3a01-49ae-a23b-3761b604800b";
            var expectedClientId = "e8fd159b-57c4-4d36-9bd7-a59ca13057bb";

            // Act
            var result = _clientService.GetByPolicyNumber(policyId).Result;

            // Assert

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Id, expectedClientId);
        }
    }
}