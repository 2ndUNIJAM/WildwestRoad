using UnityEngine;

public static class ColorExtensions
{
    private static readonly System.Random rand = new();
    public static Color SetAlpha(this Color value, float a)
    {
        var toReturn = new Color(value.r, value.g, value.b, a);
        return toReturn;
    }

    public static Vector3 ToVector3(this Color value)
    {
        return new Vector3(value.r, value.g, value.b);
    }

    public static Color GetForeColor(this Color value) => GetForeColor(value, Color.black, Color.white);

    public static Color GetForeColor(this Color value, Color onBright, Color onDark)
    {
        var brightness = .2126f * value.r + .7152f * value.g + .0722f * value.b;

        return brightness > .5f ? onBright : onDark;
    }

    public static Vector3 ToLAB(this Color color)
    {
        float Fxyz1(float t)
        {
            return t > 0.04045f ? Mathf.Pow((t + 0.055f) / 1.055f, 2.4f) : t / 12.92f;
        }

        float Fxyz2(float t)
        {
            return t > 0.008856f ? Mathf.Pow(t, 1f / 3f) : 7.787f * t + 16f / 116f;
        }

        float r = Fxyz1(color.r);
        float g = Fxyz1(color.g);
        float b = Fxyz1(color.b);

        // sRGB를 XYZ로 변환합니다.
        float x = r * 0.4124f + g * 0.3576f + b * 0.1805f;
        float y = r * 0.2126f + g * 0.7152f + b * 0.0722f;
        float z = r * 0.0193f + g * 0.1192f + b * 0.9505f;

        // XYZ를 L*a*b*로 변환합니다.
        x = Fxyz2(x / 0.9505f);
        y = Fxyz2(y);
        z = Fxyz2(z / 1.089f);

        float l = 116f * y - 16f;
        float a = 500f * (x - y);
        float _b = 200f * (y - z);

        return new Vector3(l, a, _b);
    }

    public static float DeltaE2000(this Color a, Color b)
    {
        return Vector3.Distance(a.ToLAB(), b.ToLAB());
    }

    public static float DeltaE2000(this Vector3 a, Color b)
    {
        return Vector3.Distance(a, b.ToLAB());
    }

    public static float DeltaE2000(this Vector3 a, Vector3 b)
    {
        return Vector3.Distance(a, b);
    }
}
