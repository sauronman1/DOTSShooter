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
            (Entity entity, ref Translation trans) =>
            {
                trans.Value.y -= 1 * deltaTime;
                if (trans.Value.y < 0)
                {
                  
                } 
            }).Schedule();
        
    }
}
