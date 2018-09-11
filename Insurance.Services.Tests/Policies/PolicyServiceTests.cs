using Insurance.ApiProviders.IPolicies;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unity;

namespace Insurance.ApiProviders.Test.Policies
{
    /// <summary>
    ///     Summary description for PolicyServiceTests
    /// </summary>
    [TestClass]
    public class PolicyServiceTests
    {
        private IUnityContainer _container;

        private IPolicyService _policyService;


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
        // exercise 3 test
        public void GetByUser_WhenUserIsValid_ReturnPolicy()
        {
            // Arrange

            _policyService = _container.Resolve<IPolicyService>();
            var user = "Britney";

            // Act

            var result = _policyService.GetByUsernameAsync(user).Result;

            // Assert

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
        }
    }
}