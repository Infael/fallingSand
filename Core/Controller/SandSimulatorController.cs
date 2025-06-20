using Core.Model;
using Raylib_cs;

namespace Core.Controller;

class SandSimulatorController(SandSimulatorModel model)
{
  private readonly SandSimulatorModel _model = model;

  public void HandleInput()
  {
    if (Raylib.IsMouseButtonDown(MouseButton.Left))
    {

      var mousePosition = Raylib.GetMousePosition();
      int x = (int)mousePosition.X;
      int y = (int)mousePosition.Y;

      HandleMouseClick(x, y);
    }
  }

  private void HandleMouseClick(int x, int y)
  {

    int gridX = x / _model.SandSize;
    int gridY = y / _model.SandSize;

    // Add sand to the model
    _model.AddSand(gridX, gridY);
  }
}