﻿using Zenject;

namespace Content.Features.CameraModule.Scripts {
    public class CameraInstaller : Installer<CameraInstaller> {
        public override void InstallBindings() {
            Container.Bind<PlayerCameraModel>()
                     .AsSingle();
        }
    }
}