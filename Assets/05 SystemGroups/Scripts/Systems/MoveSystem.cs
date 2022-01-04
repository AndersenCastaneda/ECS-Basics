using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace ECS_Basics_05
{
	[UpdateInGroup(typeof(SystemGroup))]
	public class MoveSystem : SystemBase
	{
		protected override void OnStartRunning() => UnityEngine.Debug.Log("05 MoveSystem");

		protected override void OnUpdate()
		{
			var elapsedTime = (float)Time.ElapsedTime;

			Entities.ForEach((ref Translation translation, in Wave wave, in MoveSpeed moveSpeed) =>
			{
				var zPosition = wave.Amplitude * math.sin((elapsedTime * moveSpeed.Value) +
					(translation.Value.x * wave.OffsetX) + (translation.Value.y * wave.OffsetY));

				translation.Value = new float3(translation.Value.x, translation.Value.y, zPosition);
			}).Run(); //Run() is performs the job in the main threat
		}
	}
}