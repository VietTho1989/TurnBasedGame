using UnityEngine;

namespace frame8.Logic.Misc.Other.Extensions
{
    public static class StructsToNumArraysExtensions
    {

        public static float[] GetValues(this Vector2 val)
        {
            return new float[] { val.x, val.y };
        }
        public static float[] GetValues(this Vector3 val)
        {
            return new float[] { val.x, val.y, val.z };
        }
        public static float[] GetValues(this Vector4 val)
        {
            return new float[] { val.x, val.y, val.z, val.w };
        }
        public static float[] GetValues(this Color val)
        {
            return new float[] { val.r, val.g, val.b, val.a };
        }
        public static float[] GetValues(this Rect val)
        {
            return new float[] { val.x, val.y, val.width, val.height };
        }
        public static float[] GetMinMaxValues(this Bounds val)
        {
            var array = val.min.GetValues();
            System.Array.Resize(ref array, 6);
            System.Array.ConstrainedCopy(val.max.GetValues(), 0, array, 3, 3);

            return array;
        }
        public static float[] GetCenterAndSizeValues(this Bounds val)
        {
            var array = val.center.GetValues();
            System.Array.Resize(ref array, 6);
            System.Array.ConstrainedCopy(val.size.GetValues(), 0, array, 3, 3);

            return array;
        }
    }
}