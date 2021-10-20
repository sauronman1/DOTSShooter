using Unity.Entities;
using Unity.Entities.CodeGeneratedJobForEach;
using Unity.Transforms;

public class MoveEnemies : SystemBase
{
    private EndSimulationEntityCommandBufferSystem endSimulationEcbSystem;

    protected override void OnCreate()
    {
        endSimulationEcbSystem = World.GetExistingSystem<EndSimulationEntityCommandBufferSystem>();
    }

    protected override void OnUpdate()
    {
        float deltaTime = Time.DeltaTime;

        var ecb = endSimulationEcbSystem.CreateCommandBuffer().AsParallelWriter();
        
        Entities.WithAll<EnemyTag>().ForEach(
            (Entity entity, int entityInQueryIndex, ref Translation trans) =>
            {
                trans.Value.y -= 1 * deltaTime;
                if (trans.Value.y < -5)
                {
                  ecb.DestroyEntity(entityInQueryIndex, entity);
                } 
            }).Schedule();
        endSimulationEcbSystem.AddJobHandleForProducer(this.Dependency);
    }
}
