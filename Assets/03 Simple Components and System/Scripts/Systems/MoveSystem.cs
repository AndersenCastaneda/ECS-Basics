using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public class MoveSystem : SystemBase
{
	protected override void OnUpdate()
	{
		var elapsedTime = (float)Time.ElapsedTime;

		Entities.ForEach((ref Translation translation, ref Wave wave, in MoveSpeed moveSpeed) =>
		{
			var zPosition = wave.Amplitude * math.sin((elapsedTime * moveSpeed.Value) +
				(translation.Value.x * wave.OffsetX) + (translation.Value.y * wave.OffsetY));

			translation.Value = new float3(translation.Value.x, translation.Value.y, zPosition);
		}).Run();
	}
}