using Microsoft.VisualStudio.TestTools.UnitTesting;
using Testing.MockUpDAL;
using BackEnd.Controllers;

namespace Testing
{
    [TestClass]
    public class DALTests
    {
        [TestInitialize]
        public void NewDAL()
        {
            Rating review = new Rating();
        }
    }
}
