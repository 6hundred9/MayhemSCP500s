﻿using System;
using Exiled.API.Features.Items;
using Exiled.API.Features.Spawn;
using Exiled.CustomItems.API.Features;
using Exiled.Events.EventArgs.Player;
using MEC;


namespace MayhemSCP500s.Items
{
    public class Scp500Ex  : CustomItem
    {
        public override uint Id { get; set; } = 0474  ;
        public override string Name { get; set; } = "SCP-500-EX";
        public override string Description { get; set; } =
            "Kaboom";
        public override float Weight { get; set; } = 0.5f;
        public override SpawnProperties SpawnProperties { get; set; }
        public override ItemType Type { get; set; } = ItemType.SCP500;
        
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
                ev.Player.IsGodModeEnabled = true;
                ExplosiveGrenade grenade = (ExplosiveGrenade)Item.Create(ItemType.GrenadeHE);
                grenade.FuseTime = 0.1f;
                grenade.SpawnActive(ev.Player.Position, ev.Player);
                grenade.Projectile.IsLocked = true;
                Timing.CallDelayed(0.2f, () =>
                {
                    ev.Player.IsGodModeEnabled = false;
                });
            }
        }
    }
}