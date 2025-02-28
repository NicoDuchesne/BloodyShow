using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRotatable
{
    public abstract int GetRotation();
    public abstract GameObject GetNextPrefab(GameObject prefab);
}
