public enum Direction
{
    NORTH, EAST, SOUTH, WEST
}

public class Robot
{
    private int px, py;
    private Direction direction;
    private bool isPlaced;

    private const int TableSize = 5;

    // Dictionaries for rotation logic
    private static readonly Dictionary<Direction, Direction> TurnLeft = new()
    {
        { Direction.NORTH, Direction.WEST },
        { Direction.WEST, Direction.SOUTH },
        { Direction.SOUTH, Direction.EAST },
        { Direction.EAST, Direction.NORTH }
    };

    private static readonly Dictionary<Direction, Direction> TurnRight = new()
    {
        { Direction.NORTH, Direction.EAST },
        { Direction.EAST, Direction.SOUTH },
        { Direction.SOUTH, Direction.WEST },
        { Direction.WEST, Direction.NORTH }
    };

    public void Place(int newX, int newY, Direction newDirection)
    {
        if (IsValidPosition(newX, newY))
        {
            px = newX;
            py = newY;
            this.direction = newDirection;
            isPlaced = true;
        }
    }

    public void Move()
    {
        if (!isPlaced) return;

        int newX = px, newY = py;

        switch (direction)
        {
            case Direction.NORTH: newY++; break;
            case Direction.EAST: newX++; break;
            case Direction.SOUTH: newY--; break;
            case Direction.WEST: newX--; break;
        }

        if (IsValidPosition(newX, newY))
        {
            px = newX;
            py = newY;
        }
    }

    public void RotateLeft()
    {
        if (!isPlaced) return;
        direction = TurnLeft[direction];
    }

    public void RotateRight()
    {
        if (!isPlaced) return;
        direction = TurnRight[direction];
    }

    public string Report()
    {
        if (isPlaced)
        {
            return $"{px},{py},{direction}";
        }
        return "Robot is not placed on table. Please double check your commands file.";
    }

    private bool IsValidPosition(int x, int y)
    {
        return x >= 0 && x < TableSize && y >= 0 && y < TableSize;
    }

}
