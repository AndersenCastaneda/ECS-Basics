using UnityEngine;
using Unity.Entities;

[GenerateAuthoringComponent]
public struct PlayerInput : IComponentData
{
	public KeyCode Up;
	public KeyCode Down;
	public KeyCode Left;
	public KeyCode Right;
}