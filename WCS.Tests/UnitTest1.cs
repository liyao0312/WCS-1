using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WCS.Models;
using WCS.PageModels;
using WCS.Repositories;

using System.Linq;
namespace WCS.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestLoadData()
        {
            var repo = new Repository();
            var pageModel = new PageModel();
            var filename = "../SampleData.json";
            pageModel = repo.PopulatePageModelFromJsonFile(filename);
            Assert.AreEqual(pageModel.Results.Count, 3, 0, "Json file loaded: Results = 3");
            Assert.AreEqual(pageModel.SavedCars.Count, 1, 0, "Json file loaded: SavedCars = 3");
        }

        [TestMethod]
        public void TestAdd()
        {
            var repo = new Repository();
            var pageModel = new PageModel();
            var filename = "../SampleData.json";
            pageModel = repo.PopulatePageModelFromJsonFile(filename);

            var sampleIdToAdd = "1";
            pageModel = repo.AddToSavedCars(sampleIdToAdd, pageModel);
            Assert.AreEqual(pageModel.SavedCars.Count, 2, "SavedCars count is correct");

            var carModel = pageModel.SavedCars.Where(c => c.Id == sampleIdToAdd).First();
            Assert.AreEqual(carModel.Title, "2010 Nissan Dualis +2 Ti J10 Series II Auto AWD MY10", "title are correct");

            sampleIdToAdd = "17";
            pageModel = repo.AddToSavedCars(sampleIdToAdd, pageModel);
            Assert.AreEqual(pageModel.SavedCars.Count, 2, "Car cannot be found, savedcars doesnt change");

        }

        [TestMethod]
        public void TestRemove()
        {
            var repo = new Repository();
            var pageModel = new PageModel();
            var filename = "../SampleData.json";
            pageModel = repo.PopulatePageModelFromJsonFile(filename);

            var sampleIdToRemove = "4";
            pageModel = repo.RemoveFromSavedCars(sampleIdToRemove, pageModel);
            Assert.AreEqual(pageModel.SavedCars.Count, 0, "Car is removed");
           
            pageModel = repo.RemoveFromSavedCars(sampleIdToRemove, pageModel);
            Assert.AreEqual(pageModel.SavedCars.Count, 0, "No error occurs when removing empty list");
        }
    }
}
