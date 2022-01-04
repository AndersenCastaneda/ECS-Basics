using UnityEngine;
using Unity.Entities;

namespace ECS_Basics_07
{
	[GenerateAuthoringComponent]
	public struct PlayerInput : IComponentData
	{
		public KeyCode Up;
		public KeyCode Down;
		public KeyCode Left;
		public KeyCode Right;
	}
}