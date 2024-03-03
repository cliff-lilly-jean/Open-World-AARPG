using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Generators/Procedural", fileName = "New Procedural Generator")]
public class ProceduralGenerator : ScriptableObject
{
    public GameObject prefab;
    public Transform parentContainer;

    public int numberOfPrefabInstances;

    public float generationAreaSize;
    public float absoluteGroundLevel;
}
