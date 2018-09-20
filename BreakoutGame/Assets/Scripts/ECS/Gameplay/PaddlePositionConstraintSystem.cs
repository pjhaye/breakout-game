using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;
using UnityEngine;

namespace BreakoutGame.ECS
{
    public class PaddlePositionConstraintSystem : JobComponentSystem
    {
        [BurstCompile]
        public struct PaddlePositionConstraint : IJobProcessComponentData<Paddle, Position>
        {
            public void Execute(ref Paddle paddle, ref Position position)
            {
                var unitWidth = (paddle.Width * paddle.UnitSize);                
                var left = position.Value.x - unitWidth * 0.5f;
                var right = position.Value.x + unitWidth * 0.5f;
                var xExtents = paddle.XExtents;
                if (left < paddle.XExtents.x)
                {
                    position.Value.x = xExtents.x + unitWidth * 0.5f;
                }
                else if (right > xExtents.y)
                {
                    position.Value.x = xExtents.y - unitWidth * 0.5f;
                }
            }
        }

        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {            
            var job = new PaddlePositionConstraint();
            return job.Schedule(this, inputDeps);
        }
    }
}