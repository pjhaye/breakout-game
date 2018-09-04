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

        void Awake()
        {
            _camera = GetComponentInChildren<Camera>();
        }

        private void Start()
        {
            SnapCameraToBaseTransforms();
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