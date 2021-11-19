using System.Collections.Generic;
using DefaultNamespace;

public class MazeGenerator
{
    private int _width;
    private int _height;

    public MazeGeneratorCell[,] GenerateNewMaze(int width, int height)
    {
        _width = width;
        _height = height;
        var maze = new MazeGeneratorCell[_width, _height];

        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                maze[x, y] = new MazeGeneratorCell()
                    { 
                        x = x, 
                        y = y, 
                        Visited = false, 
                        WallBottom = true, 
                        WallLeft = true 
                    };
            }
        }

        RemoveWallsWithBacktracker(maze);
        for (int x = 0; x < _width; x++)
        {
            maze[x, _height - 1].WallLeft = false;
        }

        for (int y = 0; y < _height; y++)
        {
            maze[_width - 1, y].WallBottom = false;
        }

        

        return maze;
    }

    private void RemoveWallsWithBacktracker(MazeGeneratorCell[,] maze)
    {
        MazeGeneratorCell current = maze[0, 0];
        current.Visited = true;

        Stack<MazeGeneratorCell> stack = new Stack<MazeGeneratorCell>();
        do
        {
            List<MazeGeneratorCell> unvisitedNeighbours = new List<MazeGeneratorCell>();

            int x = current.x;
            int y = current.y;

            if (x > 0 && !maze[x - 1, y].Visited) unvisitedNeighbours.Add(maze[x - 1, y]);
            if (y > 0 && !maze[x, y - 1].Visited) unvisitedNeighbours.Add(maze[x, y - 1]);
            if (x < _width - 2 && !maze[x + 1, y].Visited) unvisitedNeighbours.Add(maze[x + 1, y]);
            if (y < _height - 2 && !maze[x, y + 1].Visited) unvisitedNeighbours.Add(maze[x, y + 1]);

            if (unvisitedNeighbours.Count > 0)
            {
                MazeGeneratorCell chosen = unvisitedNeighbours[UnityEngine.Random.Range(0, unvisitedNeighbours.Count)];
                RemoveWall(current, chosen);

                chosen.Visited = true;
                stack.Push(chosen);
                current = chosen;
            }
            else
            {
                current = stack.Pop();
            }
        } while (stack.Count > 0);
    }

    private void RemoveWall(MazeGeneratorCell a, MazeGeneratorCell b)
    {
        if (a.x == b.x)
        {
            if (a.y > b.y) a.WallBottom = false;
            else b.WallBottom = false;
        }
        else
        {
            if (a.x > b.x) a.WallLeft = false;
            else b.WallLeft = false;
        }
    }
}