using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEditor;

[AlwaysSynchronizeSystem]
public class PlayerMovementSystem : SystemBase
{
    protected override void OnUpdate()
    {
        float deltaTime = Time.DeltaTime;
        GameManager gManager = GameManager.gameManager;
        

        Entities.WithAll<PlayerTag>().WithoutBurst().WithStructuralChanges().ForEach((ref Translation trans, ref EntityMovementData data) =>
        {
            trans.Value.x = math.clamp(trans.Value.x + (data.speed * data.direction * deltaTime), -data.xBound,
                data.xBound);
            if (data.hasShot)
            {
                Entity enemyEntity = GameObjectConversionUtility.ConvertGameObjectHierarchy(gManager.bulletPrefab, gManager.settings);
                Entity enemyInstance = gManager._manager.Instantiate(enemyEntity);

                float3 pos = trans.Value;
                pos.y += pos.y + 3;
                gManager._manager.SetComponentData(enemyInstance, new Translation(){Value = pos});
            }
        }).Run();

        Entities.WithAll<BulletTag>().WithoutBurst().ForEach((ref Translation trans, in EntityMovementData data) =>
        {
            trans.Value.y = trans.Value.y + (data.speed * data.direction * deltaTime);
            
        }).Schedule();
    }
}
