using Unity.Entities;

namespace ECS_Basics_06
{
	[GenerateAuthoringComponent]
	public struct TagComponent : IComponentData
	{
		public float Value;
	}
}