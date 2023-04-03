using System;
using Systems.Data;
using UnityEngine;

namespace Systems
{
   public class HealthSystem : MonoBehaviour, IDamageable
   {
      public event Action<DamageData> OnLostHealth;
      public event Action<DamageData> OnDied;

      [SerializeField]
      private float healthPoints = 3;
      [SerializeField]
      private float _currentHealthPoints;

      private DamageData damageData;

      public float HealthPoints { get => healthPoints; }
      public float CurrentHealthPoints { get => _currentHealthPoints; set => _currentHealthPoints = value; }

      private void OnEnable()
      {
         _currentHealthPoints = HealthPoints;
      }

      public DamageData TakeDamage(float damage)
      {
         damageData.damageReceived = damage;
         damageData.oldHP = _currentHealthPoints;
         _currentHealthPoints -= damageData.damageReceived;
         damageData.newHP = _currentHealthPoints;

         OnLostHealth?.Invoke(damageData);

         if (_currentHealthPoints <= 0)
         {
            OnDied?.Invoke(damageData);
         }
         return damageData;
      }
   }
}