using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SY_Player
{
    public class PlayerInput : MonoBehaviour
    {
        
        [SerializeField] private float _moveForce = 5;
        [SerializeField] private float _dashForce = 5;
        [SerializeField] private float _rotateSpeed = 5;

        private Rigidbody _pRigidbody;
        private PlayerInputActionAsset _pInputAction;
        private Vector2 _moveInputValue;

        [SerializeField] PlayerPurge playerPurge;

        [SerializeField] private Camera camera;
        [SerializeField] private GameObject mouseObj;

        private void Awake()
        {
            _pRigidbody = GetComponent<Rigidbody>();

            // Actionスクリプトのインスタンス生成
            _pInputAction = new PlayerInputActionAsset();

            // Actionイベント登録
            _pInputAction.PlayerMove.Move.started += OnMove;
            _pInputAction.PlayerMove.Move.performed += OnMove;
            _pInputAction.PlayerMove.Move.canceled += OnMove;
            _pInputAction.PlayerMove.Dash.performed += OnDash;

            // Input Actionを機能させるためには、
            // 有効化する必要がある
            _pInputAction.Enable();

            camera = Camera.main;
            playerPurge.LineRendererInit();
        }

        private void OnDestroy()
        {
            // 自身でインスタンス化したActionクラスはIDisposableを実装しているので、
            // 必ずDisposeする必要がある
            _pInputAction?.Dispose();
        }

        private void OnMove(InputAction.CallbackContext context)
        {
            // Moveアクションの入力取得
            _moveInputValue = context.ReadValue<Vector2>();
        }

        private void OnDash(InputAction.CallbackContext context)
        {
            // ジャンプする力を与える
            _pRigidbody.AddForce(transform.forward * _dashForce, ForceMode.Impulse);
        }

        private void Update()
        {
            playerPurge.LineDraw(transform.position, camera);
            //Debug.Log(Input.mousePosition);
            //Debug.Log(playerPurge.MousePoint(camera));
            //mouseObj.transform.position = camera.ScreenToWorldPoint(Input.mousePosition);
        }

        private void FixedUpdate()
        {
            MoveSet();        
        }

        private void MoveSet()
        {
            // 移動方向の力を与える
            _pRigidbody.AddForce(new Vector3(_moveInputValue.x, 0, _moveInputValue.y) * _moveForce);
            //transform.Rotate(0, _moveInputValue.x * _rotateSpeed, 0);

            if (_moveInputValue.x != 0 || _moveInputValue.y != 0)
            {
                transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                Quaternion.Euler(0, Mathf.Atan2(_moveInputValue.x, _moveInputValue.y) * Mathf.Rad2Deg, 0),
                _rotateSpeed
                );
            }
        }

        
    }
}
