using Systems.Mouse;
using UnityEngine;

namespace Characters.Player
{
   public class MoveableObject : MonoBehaviour, IClickable
   {
      [SerializeField] private Transform point;
      [SerializeField] [Range(0, 3)] private float walkSpeed = 3;

      private Character _player;

      private void Awake()
      {
         _player = FindObjectOfType<PlayerController>().Character;
      }

      public void OnClick(RaycastHit hit)
      {
         print(gameObject.name);
         _player.SetDestination(hit.point, walkSpeed);
         ShowPoint(hit);
      }

      private void ShowPoint(RaycastHit hit)
      {
         Transform spot = Instantiate(point, hit.point, point.rotation);
         point.GetChild(0).gameObject.SetActive(true);
         Destroy(spot.gameObject, 0.4f);
      }
   }
}