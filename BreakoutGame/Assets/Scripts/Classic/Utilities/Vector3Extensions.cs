using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreakoutGame
{
    public static class Vector3Extensions
    {
        public static float SignedHeadingAngleTo(this Vector3 vectorA, Vector3 vectorB)
        {
            var vectorANormalized = vectorA.normalized;
            var vectorBNormalized = vectorB.normalized;

            var angleBetweenDot = Vector3.Dot(Vector3.Cross(vectorANormalized, vectorBNormalized), Vector3.up);
            var angleRad = Mathf.Atan2(angleBetweenDot, Vector3.Dot(vectorANormalized, vectorBNormalized));
            var angleDeg = Mathf.Rad2Deg * angleRad;
            return angleDeg;
        }
    }
}