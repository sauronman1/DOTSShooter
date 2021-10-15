using Unity.Entities;
using Unity.Jobs;
using UnityEngine;

[AlwaysSynchronizeSystem]
public class PlayerInputSystem : JobComponentSystem
{
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        Entities.ForEach((ref EntityMovementData movementData, in PlayerInputData inputData) =>
        {
            movementData.direction = 0;
            movementData.direction += Input.GetKey(inputData.rightKey) ? 1 : 0;
            movementData.direction -= Input.GetKey(inputData.leftKey) ? 1 : 0;
        }).Run();

        return default;
    }
}
