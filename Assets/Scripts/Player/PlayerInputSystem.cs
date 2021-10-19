using Unity.Entities;
using Unity.Jobs;
using UnityEngine;

[AlwaysSynchronizeSystem]
public class PlayerInputSystem : SystemBase
{
    protected override void OnUpdate()
    {
        Entities.ForEach((ref EntityMovementData movementData, in PlayerInputData inputData) =>
        {
            movementData.direction = 0;
            movementData.direction += Input.GetKey(inputData.rightKey) ? 1 : 0;
            movementData.direction -= Input.GetKey(inputData.leftKey) ? 1 : 0;
            movementData.hasShot = Input.GetKeyDown(inputData.ShootKey);
        }).Run();

        
    }
}
