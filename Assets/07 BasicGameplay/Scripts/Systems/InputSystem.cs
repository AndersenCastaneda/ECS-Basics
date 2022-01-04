using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

namespace ECS_Basics_07
{
	[UpdateInGroup(typeof(GameplayGroup))]
	public class InputSystem : SystemBase
	{
		protected override void OnUpdate()
		{
			Entities.ForEach((ref Movement movement, in PlayerInput input) =>
			{
				var up = Input.GetKey(input.Up) ? 1 : 0;
				var down = Input.GetKey(input.Down) ? -1 : 0;
				var left = Input.GetKey(input.Left) ? -1 : 0;
				var right = Input.GetKey(input.Right) ? 1 : 0;

				movement.Value = new float3(left + right, 0f, up + down);
			}).Run();
		}
	}
}