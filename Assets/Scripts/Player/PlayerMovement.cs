using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

public class PlayerMovement : MonoBehaviour
{
   [SerializeField]
   private Camera mainCamera;
   [SerializeField]
   private Animator animator;
   [SerializeField]
   private NavMeshAgent agent;

   [SerializeField]
   private float agentSpeed;

   public Vector3 pointMove;
   private void Awake()
   {
      agent.speed = agentSpeed;
   }

   private void OnEnable()
   {
      ClickHandler.OnLMB += Move;
   }

   private void OnDisable()
   {
      ClickHandler.OnLMB -= Move;
   }

   private void Update()
   {
      float velocity = agent.velocity.magnitude;
      animator.SetFloat("Velocity", velocity);

      if (pointMove != Vector3.zero)
      {
         agent.SetDestination(pointMove);
      }
   }

   private void Move(object sender, MouseClickData mouseClickData)
   {
      pointMove = mouseClickData.hit.point;
      agent.speed = agentSpeed / mouseClickData.numberDivisor;
   }
}
