using System.Collections;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyObj;
    public int enemyCount;
    public int delay;
    private EntityManager _manager;
    private Entity enemyEntity;
    
    void Start()
    {
        _manager = World.DefaultGameObjectInjectionWorld.EntityManager;
        var settings = GameObjectConversionSettings.FromWorld(World.DefaultGameObjectInjectionWorld,  null);
        enemyEntity = GameObjectConversionUtility.ConvertGameObjectHierarchy(enemyObj, settings);
        StartCoroutine(StartWave(delay));
    }

    private IEnumerator StartWave(float timeBetweenSpawn)
    {
        
        for (int i = 0; i < enemyCount; i++)
        {
            Entity enemyInstance = _manager.Instantiate(enemyEntity);
            Vector3 startPosition = new Vector3(Random.Range(-8, 8), transform.position.y, 0);
            _manager.SetComponentData(enemyInstance, new Translation(){Value = startPosition});
            _manager.SetComponentData(enemyInstance, new Rotation(){Value = transform.rotation});
            yield return new WaitForSeconds(timeBetweenSpawn);
            _manager.DestroyEntity(enemyInstance);
            
        }

    }
}
