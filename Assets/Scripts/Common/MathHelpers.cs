using UnityEngine;

namespace Common
{
    public static class MathHelpers
    {
        
        public static Quaternion Vector2ToQuaternion(Vector2 vector2)
        {
            var rad2Deg = Mathf.Atan2(vector2.y, vector2.x) * Mathf.Rad2Deg;

            Quaternion quaternion = Quaternion.AngleAxis(rad2Deg, Vector3.forward);
            return quaternion;
        }   
        
        public static Vector2 QuaternionToVector2(Quaternion quaternion)
        {
            Vector2 vector2 = quaternion * Vector3.right;
            return vector2;
        }   
        
        public static Vector2 RadianToVector2(float radian)
        {
            return new Vector2(Mathf.Cos(radian), Mathf.Sin(radian));
        }

        public static Vector2 RadianToVector2(float radian, float length)
        {
            return RadianToVector2(radian) * length;
        }

        public static Vector2 DegreeToVector2(float degree)
        {
            return RadianToVector2(degree * Mathf.Deg2Rad);
        }

        public static Vector2 DegreeToVector2(float degree, float length)
        {
            return RadianToVector2(degree * Mathf.Deg2Rad) * length;
        }
    }
}