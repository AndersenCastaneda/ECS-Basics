using UnityEngine;
using Unity.Entities;

[GenerateAuthoringComponent]
struct PlayerInput : IComponentData
{
	public KeyCode Up;
	public KeyCode Down;
	public KeyCode Left;
	public KeyCode Right;
}