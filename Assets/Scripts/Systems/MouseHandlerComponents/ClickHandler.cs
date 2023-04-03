using System;
using UnityEngine;

namespace Systems.Mouse
{
   public class ClickHandler : MonoBehaviour
   {
      [SerializeField] private Camera mainCamera;
      [SerializeField] private LayerMask layerMaskForRaycast;

      public static event Action<Vector3> OnLMB;
      public static event Action<Vector3> OnRMB;

      private void Update()
      {
         if (Input.GetMouseButtonDown(0))
         {
            if (Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, Mathf.Infinity, layerMaskForRaycast))
            {
               if (hit.transform.TryGetComponent(out IClickable clickable))
                  clickable.OnClick(hit);
            }
         }

         if (Input.GetMouseButtonDown(1))
         {
            if (Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, Mathf.Infinity, layerMaskForRaycast))
            {
               if (hit.transform.TryGetComponent(out IInteractable interactable))
                  interactable.OnInteract(hit);
            }
         }

         if (Input.GetMouseButton(0))
         {
            OnLMB?.Invoke(Input.mousePosition);
         }

         if (Input.GetMouseButton(1))
         {
            OnRMB?.Invoke(Input.mousePosition);
         }
      }
   }
}