using Zenject;

namespace Content.Features.PrefabSpawner.Scripts {
    public class PrefabSpawnerInstaller : Installer<PrefabSpawnerInstaller> {
        public override void InstallBindings() {
            Container.BindInterfacesTo<PrefabsFactory>()
                     .AsSingle();
        }
    }
}