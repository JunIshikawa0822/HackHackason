using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ObstacleObject")]
public class ScriptableObstacle : ScriptableObject
{
    [Header("障害物オブジェクト")]
    [SerializeField] public GameObject obstacleObject;
    [Header("障害物のイメージ")]
    [SerializeField] public Sprite obSprite;
}
