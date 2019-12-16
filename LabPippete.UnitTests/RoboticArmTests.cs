using LaboratoryPipette.Entities;
using LaboratoryPipette.Modules;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LabPippete.UnitTests
{
    [TestClass]
    public class RoboticArmTests
    {
        /*
         * This method tests the Detect method of the Console project.
         * Checks if the newly formed wells are empty.
         */
        [TestMethod]
        public void Detect_Pipe_EMPTY()
        {
            Plate plate = new Plate(5,5);
            RoboticArm arm = new RoboticArm(plate);
            string outcome=arm.Detect();
            Assert.AreEqual("EMPTY", outcome);
        }

        /*
         * This method tests the Detect method of the Console project.
         * Checks if the newly dropped wells are Full.
         */
        [TestMethod]
        public void Detect_Pipe_FULL()
        {
            Plate plate = new Plate(5,5);
            RoboticArm arm = new RoboticArm(plate);
            arm.Drop();
            string outcome=arm.Detect();
            Assert.AreEqual("FULL", outcome);
        }

        /*
         * This method tests the Place method of the Console project.
         * Checks if the start position is 1,1.
         */
        [TestMethod]
        public void Detect_StartPosition()
        {
            Plate plate = new Plate(5, 5);
            RoboticArm arm = new RoboticArm(plate);
            string outcome = arm.Report();
            Assert.AreEqual("1,1,EMPTY", outcome);
        }

        /*
         * This method tests the Drop method of the Console project.
         * Checks if the newly dropped wells are Full.
         */
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

        /*
         * This method tests the Report method of the Console project.
         * Checks if the Report command outputs correct result.
         */
        [TestMethod]
        public void Test_Report()
        {
            Plate plate = new Plate(5, 5);
            RoboticArm arm = new RoboticArm(plate);
            var outcome = arm.Report();
            Assert.AreEqual(outcome, "1,1,EMPTY");
        }

        /*
         * This method tests the Place method of the Console project.
         * Checks if the Place command places the pipe on correct well.
         */
        [TestMethod]
        public void Test_Place_11()
        {
            Plate plate = new Plate(5, 5);
            RoboticArm arm = new RoboticArm(plate);
            arm.Place(1, 1);
            var report = arm.Report();
            Assert.AreEqual(report, "1,1,EMPTY");
        }

        /*
         * This method tests the ability of the arm to determine incorrect place commands method of the Console project.
         * Checks if the arm placed over incorrect values is determined and corresponding error(IndexOutOfRangeException) exception is raised.
         */
        [TestMethod]
        public void Test_Place_1010()
        {
            Plate plate = new Plate(5, 5);
            RoboticArm arm = new RoboticArm(plate);
            Assert.ThrowsException<IndexOutOfRangeException>(() => arm.Place(10, 10));
        }

        /*
         * This method tests the Move North method of the Console project.
         * Checks if the Move N command moves the pipe 1 well to the north direction.
         */
        [TestMethod]
        public void Test_MoveN()
        {
            Plate plate = new Plate(5, 5);
            RoboticArm arm = new RoboticArm(plate);
            arm.MoveNorth();
            var outcome = arm.Report();
            Assert.AreEqual(outcome, "2,1,EMPTY");
        }

        /*
         * This method tests the Move West method of the Console project.
         * Checks if the Move W command moves the pipe 1 well to the west direction.
         */
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

        /*
         * This method tests the Move East method of the Console project.
         * Checks if the Move E command moves the pipe 1 well to the east direction.
         */
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

        /*
         * This method tests the Move South method of the Console project.
         * Checks if the Move S command moves the pipe 1 well to the South direction.
         */
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

        /*
         * This method tests the ability of the arm to detect overflow in northern direction.
         * Checks if the Move N command can handle the fall.
         * Moves 4 times in the desired direction and then raises an error to prevent fall.
         */
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

        /*
         * This method tests the ability of the arm to detect overflow in Southern direction.
         * Checks if the Move S command can handle the fall.
         * Moves 4 times in the desired direction and then raises an error to prevent fall.
         */
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

        /*
         * This method tests the ability of the arm to detect overflow in westward direction.
         * Checks if the Move W command can handle the fall.
         * Moves 4 times in the desired direction and then raises an error to prevent fall.
         */
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

        /*
         * This method tests the ability of the arm to detect overflow in Eastern direction.
         * Checks if the Move E command can handle the fall.
         * Moves 4 times in the desired direction and then raises an error to prevent fall.
         */
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
