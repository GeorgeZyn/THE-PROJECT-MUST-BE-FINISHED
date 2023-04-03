using Characters.Player;
using Systems;
using Systems.Mouse;
using UnityEngine;

namespace Characters.Enemies
{
   public class EnemyClickAction : MonoBehaviour, IClickable
   {
      private AttackSystem playerAttackSystem;

      private void Awake()
      {
         playerAttackSystem = FindObjectOfType<PlayerController>().AttackSystem;
      }

      public void OnClick(RaycastHit hit)
      {
         print(gameObject.name);
         playerAttackSystem.Attack(transform);
      }
   }
}