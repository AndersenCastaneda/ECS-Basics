using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

[UpdateInGroup(typeof(System05Group))]
public class MoveSystem05 : SystemBase
{
	protected override void OnUpdate()
	{
		var elapsedTime = (float)Time.ElapsedTime;

		Entities.ForEach((ref Translation translation, in Wave wave, in MoveSpeed moveSpeed, in Component05 c) =>
		{
			var zPosition = wave.Amplitude * math.sin((elapsedTime * moveSpeed.Value) +
				(translation.Value.x * wave.OffsetX) + (translation.Value.y * wave.OffsetY));

			translation.Value = new float3(translation.Value.x, translation.Value.y, zPosition);
		}).Run(); //Run() is performs the job in the main threat
	}
}