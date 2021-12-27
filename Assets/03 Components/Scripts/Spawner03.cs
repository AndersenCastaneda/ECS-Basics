using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class Spawner03 : MonoBehaviour
{
	[SerializeField] private GameObject _gameObjectPrefab;

	[SerializeField] private int _gridXSize;
	[SerializeField] private int _gridYSize;
	[SerializeField] private float _spacing;

	private Entity _entityPrefab;
	private World _defaultWorld;
	private EntityManager _entityManager;

	private void Start()
	{
		_defaultWorld = World.DefaultGameObjectInjectionWorld;
		_entityManager = _defaultWorld.EntityManager;

		var settings = GameObjectConversionSettings.FromWorld(_defaultWorld, null);
		_entityPrefab = GameObjectConversionUtility.ConvertGameObjectHierarchy(_gameObjectPrefab, settings);

		// Instancing one entity
		// InstantiateEntity(new float3(4f, 0f, 4f));

		// Instancing multiple entities of the same type (archetype)
		InstantiateEntityGrid(_gridXSize, _gridYSize, _spacing);
	}

	private void InstantiateEntity(float3 position)
	{
		var myEntity = _entityManager.Instantiate(_entityPrefab);

		// We are using ConvertToEntity script attached to the prefab, so we don't need to use AddComponentData
		// because ConvertToEntity already does this work for us, instead we need to use SetComponentData to modify
		// the default value that ConvertToEntity assigned to the component.
		_entityManager.SetComponentData(myEntity, new Translation { Value = position });
	}

	private void InstantiateEntityGrid(int width, int height, float spacing = 1.1f)
	{
		for (int i = 0; i < width; ++i)
		{
			for (int j = 0; j < height; ++j)
			{
				InstantiateEntity(new float3(i * spacing, j * spacing, 0f));
			}
		}
	}
}
