using Raylib_cs;
using Utils;

namespace Core.Model;

class SandSimulatorModel
{
  public readonly int SandSize = 5;
  public int Width { get; }
  public int Height { get; }
  public Sand?[,] Grid { get; private set; }

  private float _hue = 0f;
  public SandSimulatorModel(int width, int height)
  {
    Width = width / SandSize;
    Height = height / SandSize;
    Grid = new Sand?[Width, Height];
  }

  public Color GetColor()
  {
    return ColorUtils.FromHSV(_hue += 1f, 1f, 1f);
  }


  public void AddSand(int x, int y, Color color)
  {
    if (x < 0 || x >= Width || y < 0 || y >= Height) return;
    Grid[x, y] = new Sand { Speed = 1, Color = color };
  }

  private void HandleSlide(int x, int y, int dir, ref Sand?[,] newGrid)
  {
    if (Grid[x + dir, y + 1] != null) return;
    newGrid[x + dir, y + 1] = Grid[x, y];
    Grid[x, y] = null;
  }

  public void Update()
  {
    Sand?[,] newGrid = new Sand?[Width, Height];

    bool random = Random.Shared.Next(2) == 0;
    int startX = random ? Width - 1 : 0;
    int endX = random ? -1 : Width;
    int stepX = random ? -1 : 1;

    // I should really refactor this later...
    for (int x = startX; x != endX; x += stepX)
    {
      for (int y = Height - 1; y >= 0; --y)
      {
        if (Grid[x, y] != null)
        {
          // handle last row
          if (y == Height - 1)
          {
            newGrid[x, y] = Grid[x, y];
          }
          // handle empty space below
          else if (Grid[x, y + 1] == null)
          {
            newGrid[x, y + 1] = Grid[x, y];
            Grid[x, y] = null;
          }
          // handle random slide
          else if (x != Width - 1 && x != 0 && (Grid[x + 1, y + 1] == null || Grid[x - 1, y + 1] == null))
          {
            int dir = Random.Shared.Next(2) == 0 ? -1 : 1;
            HandleSlide(x, y, dir, ref newGrid);
            HandleSlide(x, y, -dir, ref newGrid);
          }
          // handle stop
          else
          {
            newGrid[x, y] = Grid[x, y];
          }
        }
      }
    }

    Grid = newGrid;
  }
}
