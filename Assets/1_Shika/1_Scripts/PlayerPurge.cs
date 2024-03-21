using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SY_Player
{
    public class PlayerPurge : MonoBehaviour
    {
        public LayerMask rayHitLayer = 1 << 6;

        private LineRenderer lineRenderer;
        [SerializeField] private float _zValue = 10;
        [SerializeField] private float rayLength = 40;


        //マウスカーソルを置いた場所のWorld座標を返す（クリックしているか否かはこのメソッドでは扱わない）
        public Vector3 MousePoint(Camera camera)
        {
            //Debug.Log(Input.mousePosition);
            //マウスの現在地をmousePointと呼称
            Vector3 pos = Input.mousePosition;
            pos.z = 1;
            Vector3 mousePoint = camera.ScreenToWorldPoint(pos);
            //Debug.Log(mousePoint);
            return mousePoint;
        }

        //マウスで指定したい方向を取得
        private Vector3 MouseVector(Vector3 _rayOrigin, Camera camera)
        {
            //Vector3 mousePos = new Vector3(MousePoint(camera, mousePos2d).x, MousePoint(camera, mousePos2d).y, zValue);
            Vector3 mousePos = new Vector3(MousePoint(camera).x, _zValue, MousePoint(camera).z);

            //Debug.Log(mousePos);
            //プレイヤーからマウスへ向かうベクトルを標準化
            Vector3 mouseVector = (mousePos - _rayOrigin).normalized;

            return mouseVector; 
        }

        private Vector3 RayCheck(Vector3 _rayOrigin, Camera camera)
        {
            //当たらない
            Vector3 _directionVec = MouseVector(_rayOrigin, camera);
            float maxDistance = rayLength;

            if (!Physics.Raycast(_rayOrigin, _directionVec, out RaycastHit hitInfo, maxDistance, rayHitLayer))
            {
                //マウスの先
                //Debug.Log(mouseVec);
                return _rayOrigin + new Vector3(_directionVec.x * maxDistance, _directionVec.y, _directionVec.z * maxDistance);
            }
            else
            {
                //できる
                return hitInfo.point;
            }
        }

        public void LineRendererInit()
        {
            lineRenderer = GetComponent<LineRenderer>();
        }

        public void LineDraw(Vector3 _rayOrigin, Camera camera)
        {
            Vector3 endPos = RayCheck(_rayOrigin, camera);

            Vector3[] positions = new Vector3[] { _rayOrigin, endPos };

            lineRenderer.SetPositions(positions);
        }

        //private void Update()
        //{
        //    Debug.Log(Input.mousePosition);
        //}
    }
}
