using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace ECS_Basics_05
{
	public class Spawner : MonoBehaviour
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
			for (var i = 0; i < width; ++i)
			{
				for (var j = 0; j < height; ++j)
				{
					InstantiateEntity(new float3(i * spacing, j * spacing, 0f));
				}
			}
		}
	}
}