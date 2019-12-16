using LaboratoryPipette.Entities;
using LaboratoryPipette.Modules;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LabPippete.UnitTests
{
    [TestClass]
    public class RoboticArmTests
    {
        [TestMethod]
        public void Detect_Pipe_EMPTY()
        {
            Plate plate = new Plate(5,5);
            RoboticArm arm = new RoboticArm(plate);
            string outcome=arm.Detect();
            Assert.AreEqual("EMPTY", outcome);
        }

        [TestMethod]
        public void Detect_Pipe_FULL()
        {
            Plate plate = new Plate(5,5);
            RoboticArm arm = new RoboticArm(plate);
            arm.Drop();
            string outcome=arm.Detect();
            Assert.AreEqual("FULL", outcome);
        }

        [TestMethod]
        public void Detect_StartPosition()
        {
            Plate plate = new Plate(5, 5);
            RoboticArm arm = new RoboticArm(plate);
            arm.Drop();
            string outcome = arm.Detect();
            Assert.AreEqual("FULL", outcome);
        }
        [TestMethod]
        public void Test_Drop()
        {
            Plate plate = new Plate(5, 5);
            RoboticArm arm = new RoboticArm(plate);
            var currentObject = arm.currentPosition;
            Assert.AreEqual(currentObject.Content, false);
            bool outcome = arm.Drop();
            Assert.AreEqual(outcome, true);
        }

        [TestMethod]
        public void Test_Report()
        {
            Plate plate = new Plate(5, 5);
            RoboticArm arm = new RoboticArm(plate);
            var outcome = arm.Report();
            Assert.AreEqual(outcome, "1,1,EMPTY");
        }

        [TestMethod]
        public void Test_Place_11()
        {
            Plate plate = new Plate(5, 5);
            RoboticArm arm = new RoboticArm(plate);
            var outcome = arm.Place(1, 1);
            var report = arm.Report();
            Assert.AreEqual(report, "1,1,EMPTY");
        }

        [TestMethod]
        public void Test_Place_1010()
        {
            Plate plate = new Plate(5, 5);
            RoboticArm arm = new RoboticArm(plate);
            Assert.ThrowsException<IndexOutOfRangeException>(() => arm.Place(10, 10));
        }

        [TestMethod]
        public void Test_MoveN()
        {
            Plate plate = new Plate(5, 5);
            RoboticArm arm = new RoboticArm(plate);
            arm.MoveNorth();
            var outcome = arm.Report();
            Assert.AreEqual(outcome, "2,1,EMPTY");
        }

        [TestMethod]
        public void Test_MoveW()
        {
            Plate plate = new Plate(5, 5);
            RoboticArm arm = new RoboticArm(plate);
            arm.Place(2, 2);
            arm.MoveWest();
            var outcome = arm.Report();
            Assert.AreEqual(outcome, "2,1,EMPTY");
        }

        [TestMethod]
        public void Test_MoveE()
        {
            Plate plate = new Plate(5, 5);
            RoboticArm arm = new RoboticArm(plate);
            arm.Place(2, 2);
            arm.MoveEast();
            var outcome = arm.Report();
            Assert.AreEqual(outcome, "2,3,EMPTY");
        }

        [TestMethod]
        public void Test_MoveS()
        {
            Plate plate = new Plate(5, 5);
            RoboticArm arm = new RoboticArm(plate);
            arm.Place(2,2);
            arm.MoveSouth();
            var outcome = arm.Report();
            Assert.AreEqual(outcome, "1,2,EMPTY");
        }

        [TestMethod]
        public void Test_Fall_North()
        {
            Plate plate = new Plate(5, 5);
            RoboticArm arm = new RoboticArm(plate);
            arm.Place(1, 1);
            for (int i = 0; i < 4; i++)
            {
                arm.MoveNorth();
            }
            Assert.ThrowsException<IndexOutOfRangeException>(() => arm.MoveNorth());
        }

        [TestMethod]
        public void Test_Fall_South()
        {
            Plate plate = new Plate(5, 5);
            RoboticArm arm = new RoboticArm(plate);
            arm.Place(5, 5);
            for (int i = 0; i < 4; i++)
            {
                arm.MoveSouth();
            }
            Assert.ThrowsException<IndexOutOfRangeException>(() => arm.MoveSouth());
        }

        [TestMethod]
        public void Test_Fall_West()
        {
            Plate plate = new Plate(5, 5);
            RoboticArm arm = new RoboticArm(plate);
            arm.Place(5, 5);
            for (int i = 0; i < 4; i++)
            {
                arm.MoveWest();
            }
            Assert.ThrowsException<IndexOutOfRangeException>(() => arm.MoveWest());
        }

        [TestMethod]
        public void Test_Fall_East()
        {
            Plate plate = new Plate(5, 5);
            RoboticArm arm = new RoboticArm(plate);
            arm.Place(1, 1);
            for (int i = 0; i < 4; i++)
            {
                arm.MoveEast();
            }
            Assert.ThrowsException<IndexOutOfRangeException>(() => arm.MoveEast());
        }
    }
}
