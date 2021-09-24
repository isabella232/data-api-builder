using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.Json;
using System.Threading.Tasks;

namespace Cosmos.GraphQL.Service.Tests
{
    [TestClass, TestCategory(TestCategory.Cosmos)]
    public class MutationTests : TestBase
    {


        [TestMethod]
        public async Task TestMutationRun()
        {

            // Add mutation resolver
            this.controller.addMutationResolver(TestHelper.SampleMutationResolver());

            // Run mutation;
            controller.ControllerContext.HttpContext = GetHttpContextWithBody(TestHelper.SampleMutation);
            JsonDocument response = await controller.Post();

            // Validate results
            Assert.IsFalse(response.ToString().Contains("Error"));
        }

        /* [ClassInitialize]
         public void Init()
         {

         }
        */

    }
}
