using Characters.Player;
using Systems.Mouse;
using UnityEngine;

namespace Systems
{
   public class GameManager : MonoBehaviour
   {
      [SerializeField]
      private ClickHandler clickHandler;
      [SerializeField]
      private PlayerController playerController;
      [SerializeField]
      private CameraHandler cameraHandler;

      public ClickHandler ClickHandler { get => clickHandler; }
      public CameraHandler CameraHandler { get => cameraHandler; }
      public PlayerController PlayerController { get => playerController; }
   }
}