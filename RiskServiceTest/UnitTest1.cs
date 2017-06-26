using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ActiveRiskInterviewTest;
using System.Collections.Generic;

namespace RiskServiceTest
{
    [TestClass]

   
    public class RiskServiceTest
    {

        RiskService Search;


        public RiskServiceTest()
        {
            Search = new RiskService();
        }
    
   
        [TestMethod]
        public void TestIfNoUser()
        {
 
            Assert.AreEqual(0, Search.GetRiskByUser("nazwa").Count);
        }

        [TestMethod]
        public void TestIfNullUser()
        {
           
            Assert.AreEqual(0, Search.GetRiskByUser(null).Count);
        }

        [TestMethod]
        public void TestIfOneUser()
        {
           
            var Find = Search.GetRiskByUser("Julian Jelfs");
            Assert.AreEqual(1, Find.Count);
            Assert.AreEqual("Julian Jelfs", Find[0].Owner.Name);
        }

        [TestMethod]
        public void TestIfMoreUser()
        {
          
            var Find = Search.GetRiskByUser("Jon Moore");
            Assert.AreEqual(3, Search.GetRiskByUser("Jon Moore").Count);
            Assert.AreEqual("Jon Moore", Find[0].Owner.Name);
            Assert.AreEqual("Jon Moore", Find[1].Owner.Name);
            Assert.AreEqual("Jon Moore", Find[2].Owner.Name);
        }

        [TestMethod]
        public void TestStatusUnapproved()
        {
          
            Assert.AreEqual(8, Search.GetRiskWithOtherStatus(RiskStatus.Unapproved).Count);
        }

        [TestMethod]
        public void TestStatusUnapproved1()
        {
           
            Assert.AreEqual(7, Search.GetRiskWithOtherStatus(RiskStatus.Approved).Count);
        }

        [TestMethod]
        public void TestIfTitleContains()
        {
           
            var Find = Search.GetRiskByTitle("fire");
            Assert.AreEqual(4, Find.Count);
            Assert.IsTrue(Find[0].Title.ToLower().Contains("fire"));
            Assert.IsTrue(Find[1].Title.ToLower().Contains("fire"));
            Assert.IsTrue(Find[2].Title.ToLower().Contains("fire"));
            Assert.IsTrue(Find[3].Title.ToLower().Contains("fire"));
        }

        [TestMethod]
        public void TestIfTitleContainsNothing()
        {
           
            var Find = Search.GetRiskByTitle("");
            Assert.AreEqual(10, Find.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentNullException))]
        public void TestIfTitleContainsNull()
        {
          
            var Find = Search.GetRiskByTitle(null);
            Assert.AreEqual(0, Find.Count);
        }
    }
}
