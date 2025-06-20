namespace Core.View;

using Graphics;
using Core.Model;
using Raylib_cs;

class SandSimulatorView
{
  private readonly SandSimulatorModel _model;
  public SandSimulatorView(SandSimulatorModel model)
  {
    _model = model;
    Window.Init(model.Width * model.SandSize, model.Height * model.SandSize);
    Renderer.Init();
  }

  private void DrawSand()
  {
    // Functional solution
    // I'm little bit disappointed that C# doesn't have a built-in way to iterate over a 2D...
    Enumerable.Range(0, _model.Width)
    .SelectMany(x => Enumerable.Range(0, _model.Height),
                (x, y) => new { x, y, sand = _model.Grid[x, y] })
    .Where(cell => cell.sand != 0)
    .ToList()
    .ForEach(cell => Renderer.DrawSand(cell.x * _model.SandSize, cell.y * _model.SandSize, _model.SandSize, Color.Yellow));

    // Imperative solution
    // for (int x = 0; x < _model.Width; x++)
    // {
    //   for (int y = 0; y < _model.Height; y++)
    //   {
    //     int sand = _model.Grid[x, y];
    //     if (sand != 0)
    //     {
    //       Renderer.DrawSand(x * _model.SandSize, y * _model.SandSize, _model.SandSize, Color.Yellow);
    //     }
    //   }
    // }
  }

  public void Render()
  {
    Window.Clear(Color.Black);
    DrawSand();
    Window.EndDrawing();
  }
}