using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Generators/Procedural", fileName = "New Procedural Generator")]
public class ProceduralGeneratorSO : ScriptableObject
{
    public GameObject prefab;
    public int numberOfPrefabInstances;
    public float generationAreaSize;
    public Transform parentContainer;
    public float absoluteGroundLevel;
}
