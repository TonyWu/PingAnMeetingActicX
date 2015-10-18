using Cosmoser.PingAnMeetingRequest.Common.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Cosmoser.PingAnMeetingRequest.Common.ClientService;

namespace Cosmoser.PingAnMeetingActiveX.UnitTest
{
    
    
    /// <summary>
    ///This is a test class for IConferenceHandlerTest and is intended
    ///to contain all IConferenceHandlerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class IConferenceHandlerTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        internal virtual IConferenceHandler CreateIConferenceHandler()
        {
            // TODO: Instantiate an appropriate concrete class.
            IConferenceHandler target = ClientServiceFactory.Create();
            return target;
        }

        /// <summary>
        ///A test for VTXChangeVol
        ///</summary>
        [TestMethod()]
        public void VTXChangeVolTest()
        {
            IConferenceHandler target = CreateIConferenceHandler(); // TODO: Initialize to an appropriate value
            string IP = "192.166.5.100"; // TODO: Initialize to an appropriate value
            int Port = 8081; // TODO: Initialize to an appropriate value
            int cmdId = 2; // TODO: Initialize to an appropriate value
            bool plusAction = true; // TODO: Initialize to an appropriate value
            string error = string.Empty; // TODO: Initialize to an appropriate value
            string errorExpected = string.Empty; // TODO: Initialize to an appropriate value
            bool expected = true; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.VTXChangeVol(IP, Port, cmdId, plusAction, out error);
            Assert.AreEqual(expected, actual);
        }


        /// <summary>
        ///A test for VTXInit
        ///</summary>
        [TestMethod()]
        public void VTXInitTest()
        {
            IConferenceHandler target = CreateIConferenceHandler(); // TODO: Initialize to an appropriate value
            string IP = "192.166.5.100"; // TODO: Initialize to an appropriate value
            int Port = 8081; // TODO: Initialize to an appropriate value
            int cmdId = 1; // TODO: Initialize to an appropriate value
            string logLevel = "DEBUG"; // TODO: Initialize to an appropriate value
            string error = string.Empty; // TODO: Initialize to an appropriate value
            string errorExpected = string.Empty; // TODO: Initialize to an appropriate value
            bool expected = true; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.VTXInit(IP, Port, cmdId, logLevel, out error);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for VTXConfiguration
        ///</summary>
        [TestMethod()]
        public void VTXConfigurationTest()
        {
            IConferenceHandler target = CreateIConferenceHandler(); // TODO: Initialize to an appropriate value
            string IP = "192.166.5.100"; // TODO: Initialize to an appropriate value
            int Port = 8081; // TODO: Initialize to an appropriate value
            int cmdId = 0; // TODO: Initialize to an appropriate value
            string serverIp = "192.166.3.122"; // TODO: Initialize to an appropriate value
            int serverPort = 5060; // TODO: Initialize to an appropriate value
            string sipname = "111112"; // TODO: Initialize to an appropriate value
            string sippassword = "111112"; // TODO: Initialize to an appropriate value
            int height = 800; // TODO: Initialize to an appropriate value
            int width = 800; // TODO: Initialize to an appropriate value
            int pos_x = 50; // TODO: Initialize to an appropriate value
            int pos_y = 50; // TODO: Initialize to an appropriate value
            string displayname = "111112"; // TODO: Initialize to an appropriate value
            string error = string.Empty; // TODO: Initialize to an appropriate value
            string errorExpected = string.Empty; // TODO: Initialize to an appropriate value
            bool expected = true; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.VTXConfiguration(IP, Port, cmdId, serverIp, serverPort, sipname, sippassword, height, width, pos_x, pos_y, displayname, out error);
            Assert.AreEqual(expected, actual);
        }
    }
}
