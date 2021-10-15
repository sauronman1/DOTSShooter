using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;

public class MoveEnemies : JobComponentSystem
{
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        float deltaTime = Time.DeltaTime;

        return Entities.WithAll<EnemyTag>().ForEach(
            (Entity entity, ref Translation transform) =>
            {
                transform.Value.y -= 1 * deltaTime;
                if (transform.Value.y < 0)
                {
                    
                }
            }).Schedule(inputDeps);
        
    }
}
