using Unity.Entities;
using Unity.Transforms;

[UpdateInGroup(typeof(GameplayGroup))]
[UpdateAfter(typeof(InputSystem))]
public class MovementSystem : SystemBase
{
	protected override void OnUpdate()
	{
		var deltaTime = Time.DeltaTime;

		Entities.ForEach((ref Translation translation, in Movement movement, in Speed speed) =>
		{
			translation.Value = translation.Value + movement.Value * (speed.Value * deltaTime);
		}).Run();
	}
}