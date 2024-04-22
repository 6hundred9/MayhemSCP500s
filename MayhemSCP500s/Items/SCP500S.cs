using System;
using Exiled.API.Enums;
using Exiled.API.Features.Spawn;
using Exiled.CustomItems.API.Features;
using Exiled.Events.EventArgs.Player;
namespace MayhemSCP500s.Items
{
    public class Scp500S : CustomItem
    {
        public override uint Id { get; set; } = 1921;
        public override string Name { get; set; } = "SCP-500-S";
        public override string Description { get; set; } =
            "Increase your speed";
        public override float Weight { get; set; } = 0.5f;
        public override SpawnProperties SpawnProperties { get; set; }
        public override ItemType Type { get; set; } = ItemType.SCP500;
        private MEC.CoroutineHandle _ok;
        
        
        protected override void SubscribeEvents()
        {
            Exiled.Events.Handlers.Player.UsedItem += UsedItem;
            base.SubscribeEvents();
        }

        protected override void UnsubscribeEvents()
        {
            Exiled.Events.Handlers.Player.UsedItem -= UsedItem;
            base.UnsubscribeEvents();
        }

        private void UsedItem(UsedItemEventArgs ev)
        {
            if (Check(ev.Item))
            {
                Random random = new Random();
                ev.Player.EnableEffect(EffectType.MovementBoost, (byte)random.Next(Plugin.Instance.Config.MinSpeedIntensity, Plugin.Instance.Config.MaxSpeedIntensity), Plugin.Instance.Config.SpeedBoostTime);
            }
        }
    }
}