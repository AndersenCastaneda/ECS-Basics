using Unity.Entities;
using Unity.Mathematics;
using Unity.Rendering;
using Unity.Transforms;
using UnityEngine;

public class Spawner01 : MonoBehaviour
{
	[SerializeField] private Mesh _mesh;
	[SerializeField] private Material _material;

	private void Start() => CreateEntity();

	// Previous way to create entities
	private void CreateEntity()
	{
		// Get Entity manager from world
		var entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;

		// Create an archetype (if is necessary)
		var archetype = entityManager.CreateArchetype(
			typeof(Translation),
			typeof(RenderMesh),
			typeof(RenderBounds),
			typeof(Rotation),
			typeof(LocalToWorld)
		);

		// Create the entity with the specific archetype
		var entity = entityManager.CreateEntity(archetype);

		// Set the value to the components that the entity has
		entityManager.AddComponentData(entity, new Translation { Value = new float3(-1.5f, 0f, 0f) });

		// For Mesh or materials should use AddSharedComponentData to reduce draw calls
		entityManager.AddSharedComponentData(entity, new RenderMesh { mesh = _mesh, material = _material });
	}
}