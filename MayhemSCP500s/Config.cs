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
        public Scp500B Scp500b { get; set; } = new Scp500B();
        public SCP500C Scp500c { get; set; } = new SCP500C();
        public Scp500D Scp500d { get; set; } = new Scp500D();
        public Scp500Ex Scp500ex { get; set; } = new Scp500Ex();
        public Scp500H Scp500h { get; set; } = new Scp500H();
        public Scp500I Scp500i { get; set; } = new Scp500I();
        public Scp500S Scp500s { get; set; } = new Scp500S();
        public Scp500T Scp500t { get; set; } = new Scp500T();
        public Scp500U Scp500u { get; set; } = new Scp500U();
    }
}