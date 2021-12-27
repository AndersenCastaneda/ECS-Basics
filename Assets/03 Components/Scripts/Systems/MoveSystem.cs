using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public class MoveSystem : SystemBase
{
	protected override void OnUpdate()
	{
		var elapsedTime = (float)Time.ElapsedTime;
		Entities.ForEach((ref Translation translation, in MoveSpeed moveSpeed) =>
		{
			var zPosition = math.sin(elapsedTime);
			var position = translation.Value;
			position.z = zPosition;
			translation.Value = position;
		}).Run();
	}
}