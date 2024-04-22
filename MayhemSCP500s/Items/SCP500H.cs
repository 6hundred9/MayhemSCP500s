using System;
using Exiled.API.Features;
using Exiled.API.Features.Items;
using Exiled.API.Features.Spawn;
using Exiled.CustomItems.API.Features;
using Exiled.Events.EventArgs.Player;
using MEC;

namespace MayhemSCP500s.Items
{
    public class Scp500H : CustomItem
    {
        private readonly ItemType _type = ItemType.SCP500;
        
        public override uint Id { get; set; } = 2127 ;
        public override string Name { get; set; } = "SCP-500-H";
        public override string Description { get; set; } =
            "Increase your max health";
        public override float Weight { get; set; } = 0.5f;
        public override SpawnProperties SpawnProperties { get; set; }
        public override ItemType Type { get => _type; set => throw new ArgumentException("Do you really think I'll allow you to change the item type?"); }
        
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
            ev.Player.MaxHealth += Plugin.Instance.Config.MaxHealthIncrease;
        }
    }
}