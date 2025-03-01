﻿using System;
using System.Collections.Generic;
using Exiled.API.Extensions;
using Exiled.API.Features.Spawn;
using Exiled.CustomItems.API.Features;
using Exiled.Events.EventArgs.Player;
using PlayerRoles;
using Random = UnityEngine.Random;

namespace MayhemSCP500s.Items
{
    public class SCP500C : CustomItem
    {
        public override uint Id { get; set; } = 8667;
        public override string Name { get; set; } = "SCP-500-C";
        public override string Description { get; set; } =
            "Disguises you as an SCP";
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
                List<RoleTypeId> roles = new()
                {
                    RoleTypeId.Scp049,
                    RoleTypeId.Scp096,
                    RoleTypeId.Scp106,
                    RoleTypeId.Scp173,
                    RoleTypeId.Scp939,
                    RoleTypeId.Scp3114
                };
                int rand = Random.Range(0, 6);
                RoleTypeId funny = roles[rand];
                ev.Player.ChangeAppearance(funny);
            }
        }
    }
}