﻿using Zenject;

namespace Content.Features.UIModule
{
    public class UIInstaller : Installer<UIInstaller> {
        public override void InstallBindings() {
            Container.BindInterfacesAndSelfTo<GameUIFactory>().AsSingle();
        }
    }
}