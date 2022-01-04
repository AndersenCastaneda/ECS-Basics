using Unity.Entities;
using UnityEngine;

namespace ECS_Basics_06
{
	[UpdateInGroup(typeof(SystemGroup))]
	public class TestExtensionSystem : SystemBase
	{
		protected override void OnStartRunning() => TestGetComponent();

		protected override void OnUpdate() => Entities.ForEach((in Player player) => { }).Run();

		private void TestGetComponent()
		{
			var entity = EntityManager.CreateEntity();
			EntityManager.AddComponentData(entity, new TagComponent());
			if (!EntityManager.TryGetComponent<TagComponent>(entity))
				return;

			Debug.Log("After condition");
		}
	}
}