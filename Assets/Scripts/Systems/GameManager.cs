using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameManager : MonoBehaviour
{
   [SerializeField]
   private ClickHandler clickHandler;
   [SerializeField]
   private PlayerController playerController;
   [SerializeField]
   private CameraHandler cameraHandler;

   public ClickHandler ClickHandler { get => clickHandler; }
   public CameraHandler CameraHandler { get => cameraHandler; }
   public PlayerController PlayerController { get => playerController; }
}
