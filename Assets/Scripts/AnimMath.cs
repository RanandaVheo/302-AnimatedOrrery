using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AnimMath
{
    public static float Map(float v, float minIn, float maxIn, float minOut, float maxOut)
    {
        float p = (v - minIn) / (maxIn - minIn);
        return Lerp(minOut, maxOut, p);
    }

    public static float Lerp(float a, float b, float p, bool allowExtrap = true)
    {
        if (!allowExtrap)
        {
            if (p > 1) p = 1;
            if (p < 0) p = 0;
        }

        return (b - a) * p + a;
    }

    public static Vector3 Lerp(Vector3 a, Vector3 b, float p, bool allowExtrap = true)
    {
        if (!allowExtrap)
        {
            if (p > 1) p = 1;
            if (p < 0) p = 0;
        }

        return (b - a) * p + a;
    }

    public static Quaternion Lerp(Quaternion a, Quaternion b, float p, bool allowExtrap = false)
    {
        Quaternion rot = Quaternion.identity;

        rot.x = Lerp(a.x, b.x, p, allowExtrap);
        rot.y = Lerp(a.y, b.y, p, allowExtrap);
        rot.z = Lerp(a.z, b.z, p, allowExtrap);
        rot.x = Lerp(a.w, b.w, p, allowExtrap);

        return rot;
    }

    public static float FEase(float current, float target, float percentAfter1Sec, float dt = -1)
    {
        if (dt < 0) dt = Time.deltaTime;
        float p = 1 - Mathf.Pow(percentAfter1Sec, dt);
        return Lerp(current, target, p);
    }

    public static Vector3 VEase(Vector3 current, Vector3 target, float percentAfter1Sec, float dt = -1)
    {
        if (dt < 0) dt = Time.deltaTime;
        float p = 1 - Mathf.Pow(percentAfter1Sec, dt);
        return Lerp(current, target, p);
    }

}
