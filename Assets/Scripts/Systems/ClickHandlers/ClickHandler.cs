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

   public static event EventHandler<MouseClickData> OnLMB;

   private void Update()
   {
      if (Input.GetKey(KeyCode.LeftControl))
      {
         if (Input.GetMouseButtonDown(0))
         {
            if (Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
            {
               GetInfoAboutMouseClick(hit, 3);
            }
         }
      }
      else if (Input.GetMouseButtonDown(0))
      {
         if (Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
         {
            GetInfoAboutMouseClick(hit, 1);
         }
      }
   }

   private void GetInfoAboutMouseClick(RaycastHit hit ,float numberDivisor)
   {
      mouseClickData.hit = hit;
      mouseClickData.numberDivisor = numberDivisor;
      OnLMB?.Invoke(this, mouseClickData);
   }
}
