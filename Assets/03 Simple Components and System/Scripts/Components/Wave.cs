using Unity.Entities;

[GenerateAuthoringComponent]
public struct Wave : IComponentData
{
	public float Amplitude;
	public float OffsetX;
	public float OffsetY;
}