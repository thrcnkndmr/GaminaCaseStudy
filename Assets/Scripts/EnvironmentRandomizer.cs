using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnvironmentRandomizer", menuName = "EnvironmentRandomizer", order = 1)]
public class EnvironmentRandomizer : ScriptableObject
{
    public List<GameObject> Maze;
}