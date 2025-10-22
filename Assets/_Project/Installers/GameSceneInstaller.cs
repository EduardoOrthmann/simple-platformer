using _Project.Core.Application;
using _Project.Core.Infrastructure;
using UnityEngine;
using Zenject;

namespace _Project.Installers
{
    public class GameSceneInstaller : MonoInstaller
    {
        [SerializeField] private GameObject playerGameObject;

        public override void InstallBindings()
        {
            Container.Bind<PlayerInputState>().AsSingle();
            Container.Bind<PlayerMovement>().AsSingle();
            Container.Bind<Rigidbody2D>().FromInstance(playerGameObject.GetComponent<Rigidbody2D>()).AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerFacade>().AsSingle();
        }
    }
}