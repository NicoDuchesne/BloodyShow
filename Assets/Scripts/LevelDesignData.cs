using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/LevelDesignData", order = 1)]
public class LevelDesignData : ScriptableObject
{
    [Header("MATRIX")]
    public int matrixX;
    public int matrixY;

    [Header("VALVES")]
    public String[] valvePositions;
    public String[] valveOrientation;

    [Header("STARTS")]
    public String[] startPositions;
    public String[] startDirections;
    public String[] startSprites;

    [Header("END")]
    public String endPosition;

}
