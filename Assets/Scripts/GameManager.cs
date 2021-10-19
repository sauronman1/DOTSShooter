using Unity.Entities;
using UnityEngine;
using UnityEngine.Jobs;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    
    public EntityManager _manager;
    public GameObject bulletPrefab;
    public GameObjectConversionSettings settings;
    void Awake()
    {
        gameManager = this;
        _manager = World.DefaultGameObjectInjectionWorld.EntityManager;
        settings = GameObjectConversionSettings.FromWorld(World.DefaultGameObjectInjectionWorld,  null);
        
    }

    
}
