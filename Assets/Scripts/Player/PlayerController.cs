using UnityEngine;

public class PlayerController : MonoBehaviour
{
   [SerializeField]
   private PlayerMovement playerMovement;
   [SerializeField]
   private Transform cameraPoint;

   public PlayerMovement PlayerMovement { get => playerMovement; }
   public Transform CameraPoint { get => cameraPoint; }
}
