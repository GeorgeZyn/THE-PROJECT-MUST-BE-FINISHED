using UnityEngine;

namespace Systems.Mouse
{
   public interface IInteractable
   {
      public void OnInteract(RaycastHit hit);
   }
}