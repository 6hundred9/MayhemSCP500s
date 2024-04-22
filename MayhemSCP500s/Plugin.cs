using System;
using System.Collections.Generic;
using Exiled.API.Features;
using Exiled.CustomItems.API;
using Exiled.CustomItems.API.Features;
using MayhemSCP500s.Items;
namespace MayhemSCP500s
{
    public class Plugin : Plugin<Config>
    {
        public override string Author { get; } = "6hundred9";
        public override string Name { get; } = "Mayhem SCP 500s";
        public override string Prefix { get; } = "mSCP500";
        public override Version Version { get; } = new Version(1, 0, 0);
        public override Version RequiredExiledVersion { get; } = new Version(8, 8, 1);
        public override bool IgnoreRequiredVersionCheck { get; } = true;

        public static Plugin Instance;

        
        public override void OnEnabled()
        {
            Instance = this;
            Config.Scp500b.Register();
            Config.Scp500c.Register();
            Config.Scp500d.Register();
            Config.Scp500ex.Register();
            Config.Scp500h.Register();
            Config.Scp500i.Register();
            Config.Scp500s.Register();
            Config.Scp500t.Register();
            Config.Scp500u.Register();
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Config.Scp500b.Unregister();
            Config.Scp500c.Unregister();
            Config.Scp500d.Unregister();
            Config.Scp500ex.Unregister();
            Config.Scp500h.Unregister();
            Config.Scp500i.Unregister();
            Config.Scp500s.Unregister();
            Config.Scp500t.Unregister();
            Config.Scp500u.Unregister();
            base.OnDisabled();
        }
    }
}