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

        public static List<CustomItem> customItems = new List<CustomItem>()
        {
            new Scp500B(),
            new SCP500C(),
            new Scp500D(),
            new Scp500Ex(),
            new Scp500H(),
            new Scp500I(),
            new Scp500S(),
            new Scp500T(),
            new Scp500U(),
        };
        public override void OnEnabled()
        {
            Instance = this;
            foreach (CustomItem item in customItems)
            {
                item.Register();
            }
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            foreach (CustomItem item in customItems)
            {
                item.Unregister();
            }
            base.OnDisabled();
        }
    }
}