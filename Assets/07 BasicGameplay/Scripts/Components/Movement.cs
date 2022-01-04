using Unity.Entities;
using Unity.Mathematics;

namespace ECS_Basics_07
{
	[GenerateAuthoringComponent]
	public struct Movement : IComponentData
	{
		public float3 Value;
	}
}