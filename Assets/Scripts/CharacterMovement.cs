using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterMovement : MonoBehaviour
{
   [SerializeField] private NavMeshAgent agent;
   [SerializeField] private Animator animator;
   [SerializeField] private Rigidbody rigidBody;
   private float turnAmount;
   private float forwardAmount;

   [Header("Movement")]
   [SerializeField] private float moveSpeedMultiple = 1f;
   [SerializeField] private float animationSpeedMultiple = 1.5f;
   [SerializeField] private float movingTurnSpeed = 360;
   [SerializeField] private float stationaryTurnSpeed = 180;
   [SerializeField] private float moveThreshold = 1;

   private void Start()
   {
      agent.autoBraking = false;
      agent.updateRotation = false;
      agent.updatePosition = true;
      animator.applyRootMotion = false;
   }

   private void Update()
   {
      if (agent.remainingDistance > agent.stoppingDistance)
      {
         Move(agent.desiredVelocity);
      }
      else
      {
         Move(Vector3.zero);
      }
   }

   public void SetDestination(Vector3 worldPos, float agentSpeed)
   {
      agent.destination = worldPos;
      agent.speed = agentSpeed;
   }

   void Move(Vector3 movement)
   {
      SetForwardAndTurn(movement);

      ApplyExtraTurnRotation();
      UpdateAnimator();
   }

   private void SetForwardAndTurn(Vector3 movement)
   {
      if (movement.magnitude > moveThreshold)
         movement.Normalize();

      var localMove = transform.InverseTransformDirection(movement);
      turnAmount = Mathf.Atan2(localMove.x, localMove.z);
      forwardAmount = localMove.z;
   }

   void UpdateAnimator()
   {
      animator.SetFloat("Forward", forwardAmount, 0.1f, Time.deltaTime);
      animator.SetFloat("Turn", turnAmount, 0.1f, Time.deltaTime);
      animator.speed = animationSpeedMultiple;
   }

   void ApplyExtraTurnRotation()
   {
      float turnSpeed = Mathf.Lerp(stationaryTurnSpeed, movingTurnSpeed, forwardAmount);
      transform.Rotate(0, turnAmount * turnSpeed * Time.deltaTime, 0);
   }

   private void OnAnimatorMove()
   {
      if (Time.deltaTime > 0)
      {
         Vector3 velocity = (animator.deltaPosition * moveSpeedMultiple) / Time.deltaTime;

         velocity.y = rigidBody.velocity.y;
         rigidBody.velocity = velocity;
      }
   }
}