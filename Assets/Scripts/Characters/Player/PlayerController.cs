using Systems;
using UnityEngine;

namespace Characters.Player
{
   public class PlayerController : MonoBehaviour
   {
      [SerializeField]
      private Transform cameraPoint;
      [SerializeField]
      private Character character;
      [SerializeField]
      private AttackSystem attackSystem;

      public Transform CameraPoint { get => cameraPoint; }
      public Character Character { get => character; }
      public AttackSystem AttackSystem { get => attackSystem; }
   }
}