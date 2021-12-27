using Unity.Entities;
using Unity.Mathematics;
using Unity.Rendering;
using Unity.Transforms;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	[SerializeField] private Mesh _mesh;
	[SerializeField] private Material _material;

	private void Start() => CreateEntity();

	private void CreateEntity()
	{
		var entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
		var archetype = entityManager.CreateArchetype(
			typeof(Translation),
			typeof(RenderMesh),
			typeof(RenderBounds),
			typeof(Rotation),
			typeof(LocalToWorld)
		);

		var entity = entityManager.CreateEntity(archetype);
		entityManager.AddComponentData(entity, new Translation { Value = new float3(-6f, 0f, 0f) });

		// For Mesh or materials should use AddSharedComponentData to reduce draw calls
		entityManager.AddSharedComponentData(entity, new RenderMesh { mesh = _mesh, material = _material });
	}
}
