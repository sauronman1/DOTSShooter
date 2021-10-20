using System.Collections;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyObj;
    public int enemyCount;
    public int delay;
    private Entity _enemyEntity;
    private GameManager _gManager;
    void Awake()
    {
        // _gManager = GameManager.gameManager;
        // _enemyEntity = GameObjectConversionUtility.ConvertGameObjectHierarchy(enemyObj, _gManager.settings);
        // StartCoroutine(StartWave(delay));
    }

  //  private IEnumerator StartWave(float timeBetweenSpawn)
   // {
        
        // for (int i = 0; i < enemyCount; i++)
        // {
        //     
        //     Entity enemyInstance = _gManager._manager.Instantiate(_enemyEntity);
        //     Vector3 startPosition = new Vector3(Random.Range(-8, 8), transform.position.y, 0);
        //     _gManager._manager.SetComponentData(enemyInstance, new Translation(){Value = startPosition});
        //     yield return new WaitForSeconds(timeBetweenSpawn);
        //     _gManager._manager.DestroyEntity(enemyInstance);
        //     
        // }

   // }
}
