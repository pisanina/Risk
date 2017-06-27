using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ActiveRiskInterviewTest;
using System.Collections.Generic;

namespace RiskServiceTest
{
    [TestClass]

    public class RiskServiceTest
    {

        FindRisk Search;


    [TestInitialize]
        public void Initialize()
        {
            Search = new FindRisk();
        }
    
   
        [TestMethod]
        public void TestIfNoUser()
        {
            Search.GetRiskByUser("nazwa");
            Assert.AreEqual(0, Search.ResultsOfSearch().Count);
        }

        [TestMethod]
        public void TestIfNullUser()
        {
            Search.GetRiskByUser(null);
            Assert.AreEqual(0, Search.ResultsOfSearch().Count);
        }

        [TestMethod]
        public void TestIfOneUser()
        {
            Search.GetRiskByUser("Julian Jelfs");
            var Find = Search.ResultsOfSearch();
            Assert.AreEqual(1, Find.Count);
            Assert.AreEqual("Julian Jelfs", Find[0].Owner.Name);
        }

        [TestMethod]
        public void TestIfMoreUser()
        {
            Search.GetRiskByUser("Jon Moore");
            var Find = Search.ResultsOfSearch();    
            Assert.AreEqual(3, Search.ResultsOfSearch().Count);
            Assert.AreEqual("Jon Moore", Find[0].Owner.Name);
            Assert.AreEqual("Jon Moore", Find[1].Owner.Name);
            Assert.AreEqual("Jon Moore", Find[2].Owner.Name);
        }


        [TestMethod]
        public void TestStatusUnapproved()
        {
            Search.GetRiskWithOtherStatus(RiskStatus.Unapproved);

            Assert.AreEqual(8, Search.ResultsOfSearch().Count);
        }

        [TestMethod]
        public void TestStatusUnapproved1()
        {
            Search.GetRiskWithOtherStatus(RiskStatus.Approved);

            Assert.AreEqual(7, Search.ResultsOfSearch().Count);
        }

        [TestMethod]
        public void TestIfTitleContains()
        {
            Search.GetRiskByTitle("fire");
            var Find = Search.ResultsOfSearch();
            Assert.AreEqual(4, Find.Count);
            Assert.IsTrue(Find[0].Title.ToLower().Contains("fire"));
            Assert.IsTrue(Find[1].Title.ToLower().Contains("fire"));
            Assert.IsTrue(Find[2].Title.ToLower().Contains("fire"));
            Assert.IsTrue(Find[3].Title.ToLower().Contains("fire"));
        }

        [TestMethod]
        public void TestIfTitleContainsNothing()
        {
            Search.GetRiskByTitle("");
            var Find = Search.ResultsOfSearch();
            Assert.AreEqual(10, Find.Count);
        }

        [TestMethod]
        public void TestIfTitleContainsPlantAndSecondParametrIsEmpty()
        {
            Search.GetRiskByUser("Nobody");
            Search.GetRiskByTitle("Plant");
            var Find = Search.ResultsOfSearch();
            Assert.AreEqual(0, Find.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentNullException))]
        public void TestIfTitleContainsNull()
        {
            Search.GetRiskByTitle(null);
            var Find = Search.ResultsOfSearch();
            Assert.AreEqual(0, Find.Count);
        }

        [TestMethod]
        public void TestTitleAndUser()
        {
            Search.GetRiskByTitle("fire");
            Search.GetRiskByUser("John Hillhouse");
            var Find = Search.ResultsOfSearch();
            Assert.AreEqual(1, Find.Count);
        }

        [TestMethod]
        public void TestTitleAndUserAndOtherStatus()
        {
            Search.GetRiskByTitle("fire");
            Search.GetRiskByUser("John Hillhouse");
            Search.GetRiskWithOtherStatus(RiskStatus.Approved);
            var Find = Search.ResultsOfSearch();
            Assert.AreEqual(1, Find.Count);
        }
    }
}
