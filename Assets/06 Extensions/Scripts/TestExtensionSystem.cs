using Unity.Entities;
using UnityEngine;

public class TestExtensionSystem : SystemBase
{
	protected override void OnStartRunning() => TestGetComponent();

	protected override void OnUpdate() { }

	private void TestGetComponent()
	{
		var entity = EntityManager.CreateEntity();
		EntityManager.AddComponentData(entity, new Movement());
		if (!EntityManager.TryGetComponent<Movement>(entity))
			return;

		Debug.Log("After condition");
	}
}