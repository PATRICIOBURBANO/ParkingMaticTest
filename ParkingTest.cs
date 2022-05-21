using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ParkingMatic.Data.BLL;
using ParkingMatic.Data.DAL;
using ParkingMatic.Models;
using System;

namespace ParkingMaticTest
{
    [TestClass]
    public class ParkingTest
    {
        Mock<IRepository<ParkingSpot>> ParkingSpotRepo;
        Mock<IRepository<Pass>> PassRepo;
        PassBusinessLogic PassBL;
        ParkingBusinessLogic ParkingSpotBL;

        [TestMethod]
        public void InitializedTest()
        {
            ParkingSpotRepo = new Mock<IRepository<ParkingSpot>>(); 
            PassRepo = new Mock<IRepository<Pass>>();
            PassBL = new PassBusinessLogic(PassRepo.Object);
            ParkingSpotBL = new ParkingBusinessLogic(ParkingSpotRepo.Object);
        }

        [TestMethod]
        public void CreateParkingLessThreeLetters()
        {
            string purchase = "hello";
            var aPass = new Pass(purchase);
            //PassRepo.Setup(p => p.Create(aPass));
            Assert.ThrowsException<Exception>(() => PassBL.CreatePass(aPass));
        }

        [TestMethod]
        public void CreateParkingZeroOccupancy()
        {
            //int  occupancy = 5 ;
            var newParkingSpot = new ParkingSpot(5);
            Assert.ThrowsException<Exception>(() => ParkingSpotBL.CreateParkingSpace(newParkingSpot)); 
        }
    }
}