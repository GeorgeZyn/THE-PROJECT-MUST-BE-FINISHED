using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickPointShow : MonoBehaviour
{
   [SerializeField]
   private Transform point;

   private void OnEnable()
   {
      ClickHandler.OnLMB += ShowPoint;
   }

   private void OnDisable()
   {
      ClickHandler.OnLMB -= ShowPoint;
   }


   private void ShowPoint(MouseClickData mouseClickData)
   {
      Transform s = Instantiate(point, mouseClickData.hit.point, point.rotation);
      point.GetChild(0).gameObject.SetActive(true);
      Destroy(s.gameObject, 0.4f);
   }
}
