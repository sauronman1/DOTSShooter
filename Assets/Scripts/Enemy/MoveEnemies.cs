using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;

public class MoveEnemies : SystemBase
{
    protected override void OnUpdate()
    {
        float deltaTime = Time.DeltaTime;

        Entities.WithAll<EnemyTag>().ForEach(
            (Entity entity, ref Translation transform) =>
            {
                transform.Value.y -= 1 * deltaTime;
                if (transform.Value.y < 0)
                {
                    
                } 
            }).Schedule();
        
    }
}
