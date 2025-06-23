using Raylib_cs;

namespace Utils;

public static class ColorUtils
{
  public static Color FromHSV(float h, float s, float v)
  {
    h %= 360;
    if (h < 0) h += 360;
    s = Math.Clamp(s, 0, 1);
    v = Math.Clamp(v, 0, 1);

    float c = v * s;
    float x = c * (1 - Math.Abs((h / 60f) % 2 - 1));
    float m = v - c;

    float r, g, b;

    if (h < 60) { r = c; g = x; b = 0; }
    else if (h < 120) { r = x; g = c; b = 0; }
    else if (h < 180) { r = 0; g = c; b = x; }
    else if (h < 240) { r = 0; g = x; b = c; }
    else if (h < 300) { r = x; g = 0; b = c; }
    else { r = c; g = 0; b = x; }

    byte R = (byte)((r + m) * 255);
    byte G = (byte)((g + m) * 255);
    byte B = (byte)((b + m) * 255);

    return new Color(R, G, B);
  }
}