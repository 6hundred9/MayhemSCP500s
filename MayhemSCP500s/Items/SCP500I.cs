﻿using System;
using System.Collections.Generic;
using System.Linq;
using Exiled.API.Features;
using Exiled.API.Features.Roles;
using Exiled.API.Features.Spawn;
using Exiled.CustomItems.API.Features;
using Exiled.Events.EventArgs.Player;
using PlayerRoles;
using MEC;

namespace MayhemSCP500s.Items
{
    public class Scp500I : CustomItem
    {
        public override uint Id { get; set; } = 7510;
        public override string Name { get; set; } = "SCP-500-I";
        public override string Description { get; set; } =
            $"Turns you invisible";
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
                if (Player.List.FirstOrDefault(player => player.Role.Type == RoleTypeId.Scp096) != null)
                {
                    IEnumerable<Player> scp096S = Player.List.Where(player => player.Role.Type == RoleTypeId.Scp096);
                    foreach (Player scp in scp096S)
                    {
                        if (scp.Role is Scp096Role scp096)
                        {
                            if (scp096.HasTarget(ev.Player))
                                scp096.RemoveTarget(ev.Player);
                        }
                    }
                }

                if (ev.Player.Role is FpcRole fpc)
                {
                    fpc.IsInvisible = true;

                    Timing.CallDelayed(Plugin.Instance.Config.InvisTime, () =>
                    {
                        fpc.IsInvisible = false;
                    });
                }
            }
        }
    }
}