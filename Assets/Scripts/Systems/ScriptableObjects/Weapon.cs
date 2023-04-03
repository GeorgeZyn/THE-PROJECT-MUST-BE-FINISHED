using UnityEngine;

namespace Systems.SO
{
   [CreateAssetMenu(fileName = "New Weapon", menuName = "Personal/Weapon")]
   public class Weapon : ScriptableObject
   {
      [SerializeField] private float damage;
      [SerializeField] private float range;
      [SerializeField] private GameObject weaponPrefab;
      [SerializeField] private Transform gripTransform;
      [SerializeField] private AnimationClip attackAnimation;

      public float Damage { get => damage; }
      public float Cooldown { get => attackAnimation.length; }
      public float Range { get => range; }
      public GameObject WeaponPrefab { get => weaponPrefab; }
      public Transform GripTransform { get => gripTransform; }
      public AnimationClip AttackAnimation { get => attackAnimation; }
   }
}