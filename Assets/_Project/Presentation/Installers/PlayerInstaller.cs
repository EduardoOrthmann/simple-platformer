using _Project.Core.Application.Facades;
using Zenject;

namespace _Project.Presentation.Installers
{
    public class PlayerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<PlayerFacade>().AsSingle();
        }
    }
}