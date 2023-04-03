using UnityEngine;

namespace Characters.Enemy
{
   public class PatrolMovement : MonoBehaviour
   {
      [SerializeField] private Character character;
      [SerializeField] private float patrolRadius = 10f;
      [SerializeField] private float patrolDelay = 5f;
      [SerializeField] [Range(0, 3)] private float patrolSpeed;

      private Vector3 centerOfPatrolDistance;
      private Vector3 pointToMove;
      private float timeSinceLastPatrol;

      private void Awake()
      {
         centerOfPatrolDistance = transform.position;
      }

      private void Update()
      {
         if (character.Agent.remainingDistance < character.Agent.stoppingDistance)
         {
            timeSinceLastPatrol += Time.deltaTime;

            if (timeSinceLastPatrol >= patrolDelay)
            {
               pointToMove = GetRandomPointToMove(centerOfPatrolDistance, patrolRadius);
               character.SetDestination(pointToMove, patrolSpeed);
               timeSinceLastPatrol = 0;
            }
         }
      }

      private Vector3 GetRandomPointToMove(Vector3 center, float range)
      {
         Vector3 randomPoint = center + Random.insideUnitSphere * range;
         randomPoint.y = 0;
         return randomPoint;
      }

      private void OnDrawGizmos()
      {
         Gizmos.DrawWireSphere(centerOfPatrolDistance, patrolRadius);
         Gizmos.DrawSphere(pointToMove, 0.5f);
      }
   }
}