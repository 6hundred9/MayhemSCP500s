using System;
using Exiled.API.Enums;
using Exiled.API.Extensions;
using Exiled.API.Features.Spawn;
using Exiled.CustomItems.API.Features;
using Exiled.Events.EventArgs.Player;
using MEC;
using PlayerRoles;
using Random = UnityEngine.Random;
namespace MayhemSCP500s.Items
{
    public class Scp500D : CustomItem
    {
        public override uint Id { get; set; } = 2691;
        public override string Name { get; set; } = "SCP-500-D";
        public override string Description { get; set; } =
            "Disguises you as a role of the opposite faction";
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
                RoleTypeId role = ev.Player.Role.Type;
                RoleTypeId funny = RoleTypeId.Tutorial;
                int even_funnier = Random.Range(1, 3);
                if (even_funnier == 1 && ev.Player.Role.Side == Side.ChaosInsurgency)
                {
                    funny = RoleTypeId.Scientist;
                } else if (even_funnier == 2 && ev.Player.Role.Side == Side.ChaosInsurgency)
                {
                    funny = RoleTypeId.NtfPrivate;
                }
                if (even_funnier == 1 && ev.Player.Role.Side == Side.Mtf)
                {
                    funny = RoleTypeId.ClassD;
                } else if (even_funnier == 2 && ev.Player.Role.Side == Side.Mtf)
                {
                    funny = RoleTypeId.ChaosRifleman;
                }
                ev.Player.ChangeAppearance(funny);
                Timing.CallDelayed(20f, () =>
                {
                    ev.Player.ChangeAppearance(role);
                });
            }
            
        }
    }
}