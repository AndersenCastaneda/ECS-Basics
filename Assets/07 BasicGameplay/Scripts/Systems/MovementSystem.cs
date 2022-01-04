using Unity.Entities;
using Unity.Transforms;

namespace ECS_Basics_07
{
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
}