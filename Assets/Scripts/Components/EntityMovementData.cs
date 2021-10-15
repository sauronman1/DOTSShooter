using Unity.Entities;

[GenerateAuthoringComponent]
public struct EntityMovementData : IComponentData
{
    public int direction;
    public float speed;
    public float xBound;
}
