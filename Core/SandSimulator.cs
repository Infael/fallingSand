
namespace Core;

using Graphics;
using Core.View;
using Core.Model;
using Core.Controller;

class SandSimulator
{
  private readonly SandSimulatorModel _model;
  private readonly SandSimulatorView _view;
  private readonly SandSimulatorController _controller;

  public SandSimulator(int width = 800, int height = 600)
  {
    _model = new SandSimulatorModel(width, height);
    _view = new SandSimulatorView(_model);
    _controller = new SandSimulatorController(_model);
  }

  public void Run()
  {
    while (!Window.ShouldClose())
    {
      Update();
      Render();
    }
    Window.Close();
  }

  private void Update()
  {
    _controller.HandleInput();
    _model.Update();
  }

  private void Render()
  {
    _view.Render();
  }
}