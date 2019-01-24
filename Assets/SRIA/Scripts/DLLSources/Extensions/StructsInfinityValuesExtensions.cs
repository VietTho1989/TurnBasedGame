using UnityEngine;

namespace frame8.Logic.Misc.Other.Extensions
{
    public static class StructsInfinityValuesExtensions
    {
        public static Vector2 SetToInfinity(this Vector2 val)
        {
            val.x = val.y = Mathf.Infinity;

            return val;
        }
        public static Vector2 SetToNegativeInfinity(this Vector2 val)
        {
            val.x = val.y = Mathf.NegativeInfinity;

            return val;
        }

        public static Vector3 SetToInfinity(this Vector3 val)
        {
            val.x = val.y = val.z = Mathf.Infinity;

            return val;
        }
        public static Vector3 SetToNegativeInfinity(this Vector3 val)
        {
            val.x = val.y = val.z = Mathf.NegativeInfinity;

            return val;
        }

        public static Vector4 SetToInfinity(this Vector4 val)
        {
            val.x = val.y = val.z = val.w = Mathf.Infinity;

            return val;
        }
        public static Vector4 SetToNegativeInfinity(this Vector4 val)
        {
            val.x = val.y = val.z = val.w = Mathf.NegativeInfinity;

            return val;
        }

        public static Bounds SetToInfinity(this Bounds val)
        {
            val.center = val.size = new Vector3().SetToInfinity();

            return val;
        }
        public static Bounds SetToNegativeInfinity(this Bounds val)
        {
            val.center = val.size = new Vector3().SetToNegativeInfinity();

            return val;
        }

        public static Rect SetToInfinity(this Rect val)
        {
            val.x = val.y = val.width = val.height = Mathf.Infinity;

            return val;
        }
        public static Rect SetToNegativeInfinity(this Rect val)
        {
            val.x = val.y = val.width = val.height = Mathf.NegativeInfinity;

            return val;
        }
    }
}