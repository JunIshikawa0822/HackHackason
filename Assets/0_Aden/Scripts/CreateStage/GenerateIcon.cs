using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateIcon : CreateStageManager
{
    [SerializeField] private ObstacleList obstacleList;
    [SerializeField] private GameObject icon;
    [SerializeField] private GameObject iconContent;
    
    protected override void GenerateIcons()
    {
        int i = 0;
        foreach (var item in obstacleList.scriptableObstacles)
        {
            GameObject ins = Instantiate(icon);
            ins.AddComponent<IconStatus>();
            //IconStatus iconStatus = new IconStatus(ins, item.obstacleObject);
            ins.GetComponent<Image>().sprite = item.obSprite;
            ins.transform.parent = iconContent.transform;
            i++;
        }
        
    }
}
