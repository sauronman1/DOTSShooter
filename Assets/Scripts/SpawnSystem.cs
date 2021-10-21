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
        
        var settings = GetSingleton<Settings>();
        var randomArray = World.GetExistingSystem<RandomSystem>().RandomArray;

        if (time > delay && entityIndex < settings.count)
        {
            var random = randomArray[entityIndex];
            Entity instance = EntityManager.Instantiate(settings.enemy);
            EntityManager.SetComponentData(instance, new Translation {Value = new float3(random.NextInt(-8,8), 5.2f, 0)});
            entityIndex++;
            delay += 2;
        }
        
    }
}