using System.ComponentModel;
using Exiled.API.Interfaces;
using MayhemSCP500s.Items;

namespace MayhemSCP500s
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;
        [Description("Time you're invisible for when you take SCP-500-I")]
        public int InvisTime { get; set; } = 12;
        [Description("Increase of Max Health when SCP-500-H is taken")]
        public int MaxHealthIncrease { get; set; } = 10;

        public byte MinSpeedIntensity { get; set; } = 10;
        public byte MaxSpeedIntensity { get; set; } = 205;
        public float SpeedBoostTime { get; set; } = 20;
        
        // 500s
    }
}