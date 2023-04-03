using UnityEngine;

namespace Systems.Mouse
{
   public interface IClickable
   {
      public void OnClick(RaycastHit hit);
   }
}