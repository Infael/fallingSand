
using System.Security.Cryptography.X509Certificates;

namespace Core.Model;

class SandSimulatorModel
{
  public readonly int SandSize = 10;
  public int Width { get; }
  public int Height { get; }
  public int[,] Grid { get; private set; }

  public SandSimulatorModel(int width, int height)
  {
    Width = width / SandSize;
    Height = height / SandSize;
    Grid = new int[Width, Height];
  }


  public void AddSand(int x, int y)
  {
    if (x < 0 || x >= Width || y < 0 || y >= Height) return;
    Grid[x, y] = 1; // 1 represents sand
  }

  public void Update()
  {
    int[,] newGrid = new int[Width, Height]; // By default in C# is this array filled with zeros

    // I should really refactor this later...
    for (int x = 0; x < Width; ++x)
    {
      for (int y = 0; y < Height; ++y)
      {
        if (Grid[x, y] == 1)
        {
          // handle last row
          if (y == Height - 1)
          {
            newGrid[x, y] = 1;
          }
          // handle empty space below
          else if (Grid[x, y + 1] == 0)
          {
            newGrid[x, y + 1] = 1;
          }
          // handle random slide
          else if (x != Width - 1 && x != 0 && Grid[x + 1, y + 1] == 0 && Grid[x - 1, y + 1] == 0)
          {
            int dir = Random.Shared.Next(2) == 0 ? -1 : 1;
            newGrid[x + dir, y + 1] = 1;
          }
          // handle slide right
          else if (x != Width - 1 && Grid[x + 1, y + 1] == 0)
          {
            newGrid[x + 1, y + 1] = 1;
          }
          // handle slide left
          else if (x != 0 && Grid[x - 1, y + 1] == 0)
          {
            newGrid[x - 1, y + 1] = 1;
          }
          // handle stop
          else
          {
            newGrid[x, y] = 1;
          }
        }
      }
    }

    Grid = newGrid;
  }
}
