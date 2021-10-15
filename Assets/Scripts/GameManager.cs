using Unity.Entities;
using UnityEngine;
using UnityEngine.Jobs;

public class GameManager : MonoBehaviour
{
    private EntityManager _manager;

    void Awake()
    {
        _manager = World.DefaultGameObjectInjectionWorld.EntityManager;

        //GameObjectConversionSettings settings = GameObjectConversionSettings.FromWorld(World.DefaultGameObjectInjectionWorld, null);
        
    }

    
}
