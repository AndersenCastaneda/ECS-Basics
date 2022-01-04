using Unity.Entities;

namespace ECS_Basics_05
{
	[GenerateAuthoringComponent]
	public struct MoveSpeed : IComponentData
	{
		public float Value;
	}
}