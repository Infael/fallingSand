using Raylib_cs;

namespace Graphics;


public class Window
{
  private const string Title = "Falling sand simulator";

  public static void Init(int width, int height)
  {
    Raylib.InitWindow(width, height, Title);
    Raylib.SetTargetFPS(60);
  }

  public static void Close()
  {
    Raylib.CloseWindow();
  }
  public static bool ShouldClose() => Raylib.WindowShouldClose();

  public static void Clear(Color color)
  {
    Raylib.BeginDrawing();
    Raylib.ClearBackground(color);
  }

  public static void EndDrawing()
  {
    Raylib.EndDrawing();
  }
}
