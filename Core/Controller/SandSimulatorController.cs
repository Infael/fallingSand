using Core.Model;
using Raylib_cs;

namespace Core.Controller;

class SandSimulatorController(SandSimulatorModel model)
{
  private readonly SandSimulatorModel _model = model;

  public void HandleInput()
  {
    if (Raylib.IsMouseButtonPressed(MouseButton.Left))
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

    Color color = _model.GetColor();

    // Add sand to the model
    for (int I = -3; I < 3; I++)
    {
      for (int II = -3; II < 3; II++)
      {
        _model.AddSand(gridX + I, gridY + II, color);
      }
    }
    // _model.AddSand(gridX, gridY);
  }
}