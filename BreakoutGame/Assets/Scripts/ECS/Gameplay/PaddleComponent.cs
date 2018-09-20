using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace BreakoutGame.ECS
{
    [System.Serializable]
    public struct Paddle : IComponentData
    {
        public float2 XExtents;
        public float Width;
        public float UnitSize;
    }

    public class PaddleComponent : ComponentDataWrapper<Paddle>
    {

    }
}