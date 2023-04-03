using Systems;
using UnityEngine;
using Zenject;

namespace Depedency.Containers
{
   public class GameManagerContainerInstaller : MonoInstaller
   {
      [SerializeField]
      private GameManager gameManager;

      public override void InstallBindings()
      {
         Container.Bind<GameManager>().To<GameManager>().FromInstance(gameManager).AsSingle().NonLazy();
      }
   }
}