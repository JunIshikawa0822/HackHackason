using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SY_UI
{
    public class DisplayPhoto : MonoBehaviour
    {
        [SerializeField] private GameObject photoRawImage;
        [SerializeField] private GameObject photoPlace;
        
        public void Display(List<Texture2D> texture2Ds)
        {
            foreach (var item in texture2Ds)
            { 
                GameObject photo = Instantiate(photoRawImage);
                photo.GetComponent<RawImage>().texture = item;
                photo.transform.parent = photoPlace.transform;
            }
        }
    }
}