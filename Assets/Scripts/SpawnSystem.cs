using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class SpawnSystem : SystemBase
{
    
    
    double delay = 2;
    int entityIndex = 0; 
    
    protected override void OnUpdate()
    {
        double time = Time.ElapsedTime;
        
        // There is a single Settings component in the scene.
        var settings = GetSingleton<Settings>();
        var randomArray = World.GetExistingSystem<RandomSystem>().RandomArray;
        // var instances = new NativeArray<Entity>(settings.Count, Allocator.Temp);
        //EntityManager.Instantiate(settings.Prefab, instances);

        if (time > delay && entityIndex < settings.count)
        {
            var random = randomArray[entityIndex];
            Entity instance = EntityManager.Instantiate(settings.enemy);
            EntityManager.SetComponentData(instance, new Translation {Value = new float3(random.NextInt(-8,8), 5.2f, 0)});
            entityIndex++;
            delay += 2;
        }

        
        // Native containers require explicit cleanup. There are special rules around
        // Allocator.Temp that do not require cleanup, but calling Dispose is never wrong.

        // Disabling the system so it only runs once, this one is for initialization only.
    }
}