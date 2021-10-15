using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;

[AlwaysSynchronizeSystem]
public class PlayerMovementSystem : JobComponentSystem
{
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        float deltaTime = Time.DeltaTime;

        Entities.WithAll<PlayerTag>().WithoutBurst().ForEach((ref Translation trans, in EntityMovementData data) =>
        {
            trans.Value.x = math.clamp(trans.Value.x + (data.speed * data.direction * deltaTime), -data.xBound,
                data.xBound);
        }).Run();

        return default;
    }
}
