using System;
using UnityEngine;
using Zenject;

public class GameManagerContainerInstaller : MonoInstaller
{
   [SerializeField]
   private GameManager gameManager;

   public override void InstallBindings()
   {
      Container.Bind<GameManager>().To<GameManager>().FromInstance(gameManager).AsSingle().NonLazy();
   }
}
