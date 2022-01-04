using Unity.Entities;

namespace ECS_Basics_03
{
	[GenerateAuthoringComponent]
	public struct MoveSpeed : IComponentData
	{
		public float Value;
	}
}