using System;
using System.ComponentModel;
using Exiled.API.Features.Spawn;
using Exiled.CustomItems.API.Features;
using Exiled.Events.EventArgs.Player;

namespace MayhemSCP500s.Items
{
    public class Scp500H : CustomItem
    {
        public override uint Id { get; set; } = 2127 ;
        public override string Name { get; set; } = "SCP-500-H";
        public override string Description { get; set; } =
            "Increase your max health";
        public override float Weight { get; set; } = 0.5f;
        public override SpawnProperties SpawnProperties { get; set; }
        public override ItemType Type { get; set; } = ItemType.SCP500;
        [Description("Increase of Max Health when SCP-500-H is taken")]
        public int MaxHealthIncrease { get; set; } = 10;
        
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
            if (Check(ev.Item)) ev.Player.MaxHealth += MaxHealthIncrease;
        }
    }
}