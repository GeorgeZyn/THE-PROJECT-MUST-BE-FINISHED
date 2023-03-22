using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

public class PlayerMovement : MonoBehaviour
{
   [SerializeField] private CharacterMovement characterMovement;

   [SerializeField]
   private float agentSpeed;

   private void OnEnable()
   {
      ClickHandler.OnLMB += Move;
   }

   private void OnDisable()
   {
      ClickHandler.OnLMB -= Move;
   }

   private void Move(MouseClickData mouseClickData)
   {
      characterMovement.SetDestination(mouseClickData.hit.point, mouseClickData.numberDivisor);
   }
}
