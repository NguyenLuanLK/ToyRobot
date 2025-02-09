namespace ToyRobot
{
    public class RobotController
    {
        private Robot wallE = new Robot();

        public void ExecuteCommands(string filePath)
        {
            var commands = File.ReadAllLines(filePath);

            foreach (var command in commands)
            {
                ParseAndExecuteCommand(command);
            }
        }

        private void ParseAndExecuteCommand(string command)
        {
            var parts = command.Trim().Split(' ');

            switch (parts[0])
            {
                case "PLACE":
                    if (parts.Length == 2 && TryParsePlaceCommand(parts[1], out int x, out int y, out Direction direction))
                    {
                        wallE.Place(x, y, direction);
                    }
                    break;
                case "MOVE":
                    wallE.Move();
                    break;
                case "LEFT":
                    wallE.RotateLeft();
                    break;
                case "RIGHT":
                    wallE.RotateRight();
                    break;
                case "REPORT":
                    Console.WriteLine(wallE.Report());
                    break;
            }
        }

        private bool TryParsePlaceCommand(string parameter, out int x, out int y, out Direction direction)
        {
            var args = parameter.Split(',');

            x = y = 0;
            direction = Direction.NORTH;

            if (args.Length != 3) return false;
            if (!int.TryParse(args[0], out x) || !int.TryParse(args[1], out y)) return false;
            return Enum.TryParse(args[2], out direction);
        }
    }
}
