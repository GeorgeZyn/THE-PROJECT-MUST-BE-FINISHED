using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandomMovement : MonoBehaviour
{
   [SerializeField]
   private NavMeshAgent agent;
   [SerializeField]
   private float range;

   private void Update()
   {
      if (!agent.hasPath)
      {
         agent.SetDestination(GetRandomPoint(transform, range));
      }
   }

   private bool RandomPoint(Vector3 center, float range, out Vector3 result)
   {
      for (int i = 0; i < 30; i++)
      {
         Vector3 randomPoint = center + Random.insideUnitSphere * range;
         NavMeshHit hit;
         if (NavMesh.SamplePosition(randomPoint, out hit, 1f, NavMesh.AllAreas))
         {
            result = hit.position;
            return true;
         }
      }
      result = Vector3.zero;
      return false;
   }

   public Vector3 GetRandomPoint(Transform point = null, float radius = 0)
   {
      Vector3 _point;
      if (RandomPoint(point == null ? transform.position : point.position, radius == 0 ? range : radius, out _point))
      {
         return _point;
      }

      return point == null ? Vector3.zero : point.position;
   }

#if UNITY_EDITOR
   private void OnDrawGizmos()
   {
      Gizmos.DrawWireSphere(transform.position, range);
   }
#endif
}
