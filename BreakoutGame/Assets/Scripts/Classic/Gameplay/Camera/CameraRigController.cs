using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreakoutGame
{
    public class CameraRigController : MonoBehaviour
    {
        private Camera _camera;
        private Vector3 _baseCameraPosition;
        private Vector3 _baseCameraRotation;
        private Vector3 _cameraVelocity;
        private Vector3 _rotationVelocity;

        public Vector3 BaseCameraPosition
        {
            get
            {
                return _baseCameraPosition;
            }
            set
            {
                _baseCameraPosition = value;
            }
        }

        public Vector3 BaseCameraRotation
        {
            get
            {
                return _baseCameraRotation;
            }
            set
            {
                _baseCameraRotation = value;
            }
        }

        public Camera Camera
        {
            get
            {
                return _camera;
            }
        }

        public Transform PaddleTransform
        {
            get;
            set;
        }

        public Transform BallTransform
        {
            get;
            set;
        }

        public float MovementSmoothTime
        {
            get;
            set;
        }

        public float PaddleFollowCoefficient
        {
            get;
            set;
        }

        public float BallFollowCoefficient
        {
            get;
            set;
        }

        public Vector3 DesiredPosition
        {
            get
            {
                if(PaddleTransform == null)
                {
                    return BaseCameraPosition;
                }
                var xDifference = PaddleTransform.transform.position.x - transform.position.x;
                var xOffset = xDifference * PaddleFollowCoefficient;
                return BaseCameraPosition +
                       new Vector3(
                           xOffset, 
                           0.0f, 
                           0.0f);
            }
        }

        public Vector3 DesiredRotation
        {
            get
            {
                if(BallTransform == null)
                {
                    return BaseCameraRotation;
                }
                var toBall = (BallTransform.position - _camera.transform.position).normalized;
                var toBallLook = Quaternion.LookRotation(toBall);
                var interpolated = 
                    Quaternion.Slerp(
                        Quaternion.Euler(BaseCameraRotation), 
                        toBallLook, 
                        BallFollowCoefficient);
                return interpolated.eulerAngles;
            }
        }

        void Awake()
        {
            _camera = GetComponentInChildren<Camera>();
        }

        private void Start()
        {
            SnapCameraToBaseTransforms();
        }

        private void FixedUpdate()
        {            
            var newPosition = 
                Vector3.SmoothDamp(
                    _camera.transform.localPosition, 
                    transform.InverseTransformPoint(DesiredPosition), 
                    ref _cameraVelocity, 
                    MovementSmoothTime);
            _camera.transform.localPosition = newPosition;

            var newRotation = new Vector3
            {
                x = Mathf.SmoothDampAngle(
                    _camera.transform.rotation.eulerAngles.x,
                    DesiredRotation.x,
                    ref _rotationVelocity.x,
                    MovementSmoothTime),
                y = Mathf.SmoothDampAngle(
                    _camera.transform.rotation.eulerAngles.y,
                    DesiredRotation.y,
                    ref _rotationVelocity.y,
                    MovementSmoothTime),
                z = Mathf.SmoothDampAngle(
                    _camera.transform.rotation.eulerAngles.z,
                    DesiredRotation.z,
                    ref _rotationVelocity.z,
                    MovementSmoothTime)
            };

            _camera.transform.localRotation = Quaternion.Euler(newRotation);
        }

        private void SnapCameraToBaseTransforms()
        {
            SnapCameraToBasePosition();
            SnapCameraToBaseRotation();
        }

        private void SnapCameraToBasePosition()
        {
            SnapCameraToPosition(BaseCameraPosition);
        }

        private void SnapCameraToBaseRotation()
        {
            SnapCameraToRotation(BaseCameraRotation);
        }

        private void SnapCameraToPosition(Vector3 position)
        {
            _camera.transform.localPosition = position;
        }

        private void SnapCameraToRotation(Vector3 rotation)
        {
            _camera.transform.localRotation = Quaternion.Euler(rotation);
        }                 
    }
}