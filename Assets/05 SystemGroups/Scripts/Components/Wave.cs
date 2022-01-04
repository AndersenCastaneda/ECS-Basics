using Unity.Entities;

namespace ECS_Basics_05
{
	[GenerateAuthoringComponent]
	public struct Wave : IComponentData
	{
		public float Amplitude;
		public float OffsetX;
		public float OffsetY;
	}
}