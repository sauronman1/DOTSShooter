using Unity.Entities;
using UnityEngine;


[GenerateAuthoringComponent]
public struct Settings : IComponentData
{
    public Entity enemy;
    public Entity bullet;
    public int count;
}


public class GameManager : MonoBehaviour
{
   

    
}
