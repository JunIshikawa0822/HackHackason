using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ObstacleList")]
public class ObstacleList : ScriptableObject
{
    [SerializeField] public List<ScriptableObstacle> scriptableObstacles = new List<ScriptableObstacle>();
}
