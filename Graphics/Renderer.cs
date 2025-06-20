using Raylib_cs;

namespace Graphics;


class Renderer
{
  public static void Init() { }

  public static void DrawSand(int x, int y, int size, Color color)
  {
    Raylib.DrawRectangle(x, y, size, size, color);
  }
}