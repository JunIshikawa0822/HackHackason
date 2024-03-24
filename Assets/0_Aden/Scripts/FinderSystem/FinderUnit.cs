using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System.IO;
using Unity.VisualScripting;
using UnityEditor;


public class FinderUnit : MonoBehaviour
{
    
    
    private Camera　shootCamera;
    [SerializeField] private float shootTime;
    
    
        // サイズを設定
        public async UniTask<Texture2D> Shoot()
        {
            shootCamera = gameObject.GetComponent<Camera>();
        await UniTask.WaitForSeconds(shootTime);
        Vector2Int size = new Vector2Int((int)Handles.GetMainGameViewSize().x, (int)Handles.GetMainGameViewSize().y);
        RenderTexture render = new RenderTexture(size.x, size.y, 24);
        Texture2D texture = new Texture2D(size.x, size.y, TextureFormat.RGB24, false);
        
        try
        {
            // カメラ画像をRenderTextureに描画
            shootCamera.targetTexture = render;
            shootCamera.Render();

            // RenderTextureの画像を読み取る
            RenderTexture.active = render;
            texture.ReadPixels(new Rect(0, 0, size.x, size.y), 0, 0);
            texture.Apply();
            return texture;

        }
        finally
        {
            shootCamera.targetTexture = null;
            RenderTexture.active = null;
            
        }
    }
}
