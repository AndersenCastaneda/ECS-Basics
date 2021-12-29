using Unity.Entities;

[GenerateAuthoringComponent]
struct Wave : IComponentData
{
	public float Amplitude;
	public float OffsetX;
	public float OffsetY;
}