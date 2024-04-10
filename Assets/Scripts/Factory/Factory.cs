using System;
using System.Collections.Generic;
using Entities;
using UnityEngine;

namespace Factory
{
	public class Factory : IFactory
	{
		List<MyObject> _prefabs = new();

		public static IFactory Instance { get; private set; } = new Factory();

		public Factory()
		{
			GameObject[] allPrefabs = Resources.LoadAll<GameObject>("");
			foreach (GameObject prefab in allPrefabs)
			{
				MyObject obj = prefab.GetComponent<MyObject>();
				if (obj == null)
					continue;

				if (!_prefabs.Contains(obj))
					_prefabs.Add(obj);
			}
		}

		public T CreateObject<T>() where T : MyObject
		{
			return CreateObject<T>();
		}

		public T CreateObject<T>(int varianId) where T : MyObject
		{
			return CreateObject<T>(varianId);
		}
		public T CreateObject<T>( Transform parent) where T : MyObject
		{
			Type type = typeof(T);
			MyObject? obj = _prefabs.Find(x => x.GetType().Equals(type) );
			if (obj == null)
			{
				Debug.Log($"Object not found: {type.GetType().FullName}");
				return default;
			}

			return (T)UnityEngine.Object.Instantiate(obj, parent);
		}
		public T CreateObject<T>(int varianId, Transform parent) where T : MyObject
		{
			Type type = typeof(T);
			MyObject? obj = _prefabs.Find(x => x.GetType().Equals(type) && x.VariantId == varianId);
			if (obj == null)
			{
				Debug.Log($"Object not found: {type.GetType().FullName}");
				return default;
			}

			return (T)UnityEngine.Object.Instantiate(obj, parent);
		}

	}
}
