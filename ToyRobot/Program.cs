namespace ToyRobot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the path to the command file:");
            string filePath = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(filePath))
            {
                Console.WriteLine("Invalid file path.");
                return;
            }

            var robotControl = new RobotController();
            robotControl.ExecuteCommands(filePath);
        }
    }
}
