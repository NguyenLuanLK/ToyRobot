namespace ToyRobot.Tests
{
    public class RobotTests
    {
        [Fact]
        public void TestPlaceAndReport()
        {
            var robot = new Robot();
            robot.Place(0, 0, Direction.NORTH);
            Assert.Equal("0,0,NORTH", robot.Report());
        }

        [Fact]
        public void TestMoveAndReport()
        {
            var robot = new Robot();
            robot.Place(0, 0, Direction.NORTH);
            robot.Move();
            Assert.Equal("0,1,NORTH", robot.Report());
        }

        [Fact]
        public void TestRotateLeft()
        {
            var robot = new Robot();
            robot.Place(0, 0, Direction.NORTH);
            robot.RotateLeft();
            Assert.Equal("0,0,WEST", robot.Report());
        }

        [Fact]
        public void TestRotateRight()
        {
            var robot = new Robot();
            robot.Place(0, 0, Direction.NORTH);
            robot.RotateRight();
            Assert.Equal("0,0,EAST", robot.Report());
        }

        [Fact]
        public void TestInvalidMoveOffTableIgnored()
        {
            var robot = new Robot();
            robot.Place(0, 4, Direction.NORTH);
            robot.Move();
            Assert.Equal("0,4,NORTH", robot.Report());
        }

        [Fact]
        public void TestIgnoreCommandsBeforePlace()
        {
            var robot = new Robot();
            robot.Move();
            robot.RotateLeft();
            Assert.Equal("Robot is not placed on table. Please double check your commands file.", robot.Report());
        }
    }
}
