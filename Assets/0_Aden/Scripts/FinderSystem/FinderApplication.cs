using System.Collections;
using System.Collections.Generic;
using SY_Data;
using UnityEngine;
using Cysharp.Threading.Tasks;
using SY_UI;

namespace SY_Camera
{
    public class FinderApplication : MonoBehaviour
    {
        private List<FinderUnit> finderUnits = new List<FinderUnit>();
        [SerializeField] private PhotoData photoData;
        [SerializeField] private DisplayPhoto displayPhoto;
        
        async UniTask Start()
        {
            var cameras = GameObject.FindGameObjectsWithTag("ShootCamera");
            int i = 0;
            foreach (var item in cameras)
            {
                finderUnits.Add(item.GetComponent<FinderUnit>());
                
                photoData.texture2Ds.Add(await finderUnits[i].Shoot());
            }
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public void Display()
        {
            displayPhoto.Display(photoData.texture2Ds);
        }

    } 
}

