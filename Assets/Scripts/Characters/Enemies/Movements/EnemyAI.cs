using Characters.Player;
using System;
using Systems;
using UnityEngine;

namespace Characters.Enemy
{
   public class EnemyAI : MonoBehaviour
   {
      [SerializeField] private PatrolMovement patrolMovement;
      [SerializeField] private AttackSystem attackSystem;
      [SerializeField] private Character character;

      [SerializeField] private float chaseRadius;
      [SerializeField] [Range(0, 3)] private float walkSpeed;
      [SerializeField] [Range(0, 3)] private float chaseSpeed;

      private Vector3 _startPosition;
      private Character player;
      private float _distanceToPlayer;

      void Awake()
      {
         player = FindObjectOfType<PlayerController>().Character;
         _startPosition = transform.position;
      }

      void Update()
      {
         _distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

         if (_distanceToPlayer < chaseRadius)
         {
            attackSystem.Attack(player.transform);
         }
         else
         {
            if (patrolMovement == null)
            {
               character.SetDestination(_startPosition, walkSpeed);
            }
         }
      }
   }
}