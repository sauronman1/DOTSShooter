using Unity.Entities;
using UnityEngine;
using UnityEngine.Jobs;
using Random = Unity.Mathematics.Random;

[GenerateAuthoringComponent]
public struct Settings : IComponentData
{
    public Entity enemy;
    public Entity bullet;
    public int count;
}


public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    
    void Awake()
    {

    }

    
}
