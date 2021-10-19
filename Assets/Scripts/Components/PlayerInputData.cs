using UnityEngine;
using Unity.Entities;

[GenerateAuthoringComponent]
public struct PlayerInputData : IComponentData
{
    public KeyCode rightKey;
    public KeyCode leftKey;
    public KeyCode ShootKey;
}
