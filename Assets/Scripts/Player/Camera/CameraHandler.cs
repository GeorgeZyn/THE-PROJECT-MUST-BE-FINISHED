using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
   [Header("Transforms")]
   [SerializeField]
   private Transform target;
   [SerializeField]
   private Camera mainCamera;
   [SerializeField]
   private Transform cameraPivotTransform;
   [SerializeField]
   private Transform cameraParent;

   [Header("Parameters")]
   [SerializeField]
   private float followingSpeed;
   [SerializeField]
   private float approachSpeed;
   [SerializeField]
   private float scrollSpeed;
   [SerializeField]
   private float maxZoom = 7;

   private float _zoomLevel;
   private float _zoomPosition;

   private void OnEnable()
   {
      ClickHandler.OnRMB += CameraRotate;
   }

   private void OnDisable()
   {
      ClickHandler.OnRMB -= CameraRotate;
   }

   private void Start()
   {
      mainCamera.transform.LookAt(transform);
   }

   void Update()
   {
      transform.position = Vector3.Lerp(transform.position, target.position, followingSpeed * Time.deltaTime);

      ScrollCamera();
   }

   private void CameraRotate(Vector3 mousePosition)
   {
      Quaternion _targetRotation = Quaternion.Euler(0, Input.GetAxis("Mouse X") * approachSpeed * Time.deltaTime, 0) * cameraPivotTransform.rotation;
      cameraPivotTransform.rotation = Quaternion.Slerp(cameraPivotTransform.rotation, _targetRotation, Time.deltaTime * approachSpeed);
   }

   void ScrollCamera()
   {
      _zoomLevel += Input.mouseScrollDelta.y;
      _zoomLevel = Mathf.Clamp(_zoomLevel, 0, maxZoom);
      _zoomPosition = Mathf.MoveTowards(_zoomPosition, _zoomLevel, scrollSpeed * Time.deltaTime);
      mainCamera.transform.position = cameraParent.position + (mainCamera.transform.forward * _zoomPosition);
   }
}
