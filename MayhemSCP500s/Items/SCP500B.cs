﻿using System;
using Exiled.API.Enums;
using Exiled.API.Features.Spawn;
using Exiled.CustomItems.API.Features;
using Exiled.Events.EventArgs.Player;
using PlayerRoles;
namespace MayhemSCP500s.Items
{
    public class Scp500B : CustomItem
    {
        public override uint Id { get; set; } = 9448;
        public override string Name { get; set; } = "SCP-500-B";
        public override string Description { get; set; } =
            "Betray your own side";
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
                if (ev.Player.Role.Side == Side.Mtf)
                {
                    ev.Player.Role.Set(RoleTypeId.ChaosConscript, RoleSpawnFlags.None);
                }
                else if (ev.Player.Role.Side == Side.ChaosInsurgency)
                {
                    ev.Player.Role.Set(RoleTypeId.NtfSpecialist, RoleSpawnFlags.None);
                }
            }
        }
    }
}