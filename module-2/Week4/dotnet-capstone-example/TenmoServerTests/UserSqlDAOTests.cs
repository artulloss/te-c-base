using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TenmoServer.DAO;
using TenmoServer.Models;


namespace TenmoServerTests
{
    [TestClass]
    public class UserSqlDAOTests
    {
        [TestInitialize]
        public void Setup()
        {
            //start a transaction
            //run a script to delete everything from teh database
        }

        [TestCleanup]
        public void Cleanup()
        {
            //rollback the transaction
        }

        [TestMethod]
        public void TestGetUser()
        {
            UserSqlDAO dao = new UserSqlDAO("Server=.\\SQLEXPRESS;Database=tenmo;Trusted_Connection=True;");
            List<User> list = dao.GetUsers();
            Assert.AreEqual(3, list.Count); 
        }
    }
}
