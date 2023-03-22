using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickHandler : MonoBehaviour
{
   [SerializeField]
   private Camera mainCamera;

   private MouseClickData mouseClickData;

   public static event Action<MouseClickData> OnLMB;
   public static event Action<Vector3> OnRMB;

   private void Update()
   {
      if (Input.GetMouseButtonDown(0))
      {
         if (Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
         {
            GetInfoAboutLeftMouseClick(hit, 1);

            if (Input.GetKey(KeyCode.LeftControl))
            {
               GetInfoAboutLeftMouseClick(hit, 3);
            }
         }
      }

      if (Input.GetMouseButton(1))
      {

         OnRMB?.Invoke(Input.mousePosition);
      }
   }

   private void GetInfoAboutLeftMouseClick(RaycastHit hit ,float numberDivisor)
   {
      mouseClickData.hit = hit;
      mouseClickData.numberDivisor = numberDivisor;
      OnLMB?.Invoke(mouseClickData);
   }
}
