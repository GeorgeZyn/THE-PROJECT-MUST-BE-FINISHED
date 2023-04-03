using Characters;
using System.Collections;
using Systems.Data;
using Systems.SO;
using UnityEngine;

namespace Systems
{
   public class AttackSystem : MonoBehaviour
   {
      [SerializeField] private Weapon weapon;
      [SerializeField] private Animator animator;
      [SerializeField] private Character character;

      public float WeaponRange { get => weapon.Range; }
      public float Damage { get => weapon.Damage; }

      private float _timeOfLastAttack = 0;
      private bool _attackOnCooldown;

      private Transform _target;

      private void Update()
      {
         float timeSinceLastAttack = Time.time - _timeOfLastAttack;
         _attackOnCooldown = timeSinceLastAttack < weapon.Cooldown / character.AnimationSpeedMultiple;
         character.Agent.isStopped = _attackOnCooldown;
      }

      public void Attack(Transform target)
      {
         _target = target;

         if (Vector3.Distance(transform.position, target.position) > WeaponRange)
         {
            StopAllCoroutines();
            StartCoroutine(PursueAndAttackTarget());
            return;
         }

         if (!_attackOnCooldown)
         {
            transform.LookAt(target.transform);
            _timeOfLastAttack = Time.time;
            animator.SetTrigger("Attack");
         }
      }

      private IEnumerator PursueAndAttackTarget()
      {
         character.SetDestination(_target.transform.position);

         while (Vector3.Distance(transform.position, _target.transform.position) > weapon.Range)
         {
            yield return null;
         }

         character.SetDestination(transform.position);

         Attack(_target);
      }

      public void Hit()
      {
         if (_target.TryGetComponent(out IDamageable target))
            target.TakeDamage(weapon.Damage);
      }

      void OnDrawGizmos()
      {
         // Draw attack sphere 
         Gizmos.color = new Color(255f, 0, 0, .5f);
         Gizmos.DrawWireSphere(transform.position, weapon.Range);
      }
   }
}