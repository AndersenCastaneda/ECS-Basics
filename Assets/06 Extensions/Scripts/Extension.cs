﻿using System;
using Unity.Entities;
using UnityEngine;

public static class Extension
{
	public static bool TryGetComponent<T>(this EntityManager entityManager, Entity entity) where T : struct, IComponentData
	{
		try
		{
			var unused = entityManager.GetComponentData<T>(entity);
			return true;
		}
		catch (Exception e)
		{
			Debug.Log(e);
			return false;
		}
	}
}