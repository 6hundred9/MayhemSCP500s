using System.ComponentModel;
using Exiled.API.Interfaces;
using JetBrains.Annotations;
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
        
        public static Scp500B Scp500b = new Scp500B();
        public static SCP500C Scp500c = new SCP500C();
        public static Scp500D Scp500d = new Scp500D();
        public static Scp500Ex Scp500ex = new Scp500Ex();
        public static Scp500H Scp500h = new Scp500H();
        public static Scp500I Scp500i = new Scp500I();
        public static Scp500S Scp500s = new Scp500S();
        public static Scp500T Scp500t = new Scp500T();
        public static Scp500U Scp500u = new Scp500U();
    }
}