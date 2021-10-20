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
        var settings = GetSingleton<Settings>();


        Entities.WithAll<PlayerTag>().WithoutBurst().WithStructuralChanges().ForEach((ref Translation trans, ref EntityMovementData data) =>
        {
            trans.Value.x = math.clamp(trans.Value.x + (data.speed * data.direction * deltaTime), -data.xBound,
                data.xBound);
            if (data.hasShot)
            {
                Entity bullet = EntityManager.Instantiate(settings.bullet);

                float3 pos = trans.Value;
                pos.y += pos.y + 3;
                EntityManager.SetComponentData(bullet, new Translation(){Value = pos});
            }
        }).Run();


        
      
    }
}
