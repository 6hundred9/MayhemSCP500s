using System;
using Exiled.API.Features.Spawn;
using Exiled.CustomItems.API.Features;
using Exiled.Events.EventArgs.Player;
using MEC;
using UnityEngine;
namespace MayhemSCP500s.Items
{
    public class Scp500U : CustomItem
    {
        public override uint Id { get; set; } = 9575;
        public override string Name { get; set; } = "SCP-500-U";
        public override string Description { get; set; } =
            "Flips the player, if taken more than once you get sent to hell";
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
                ev.Player.Scale = new Vector3(1, -1, 1);
                ev.Player.Position += Vector3.up;
                Timing.CallDelayed(20, () =>
                {
                    ev.Player.Scale = new Vector3(1, 1, 1);
                });
            }
        }
    }
}