using Unity.Entities;

namespace ECS_Basics_07
{
	[GenerateAuthoringComponent]
	public struct Speed : IComponentData
	{
		public float Value;
	}
}