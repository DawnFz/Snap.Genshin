﻿using DGP.Snap.Framework.Attributes.DataModel;
using DGP.Snap.Framework.Data.Behavior;
using Newtonsoft.Json;

namespace DGP.Genshin.Models.MiHoYo.Sign
{
    [JsonModel]
    public class SignInAward : Observable
    {
        private double opacity = 1;

        [JsonProperty("icon")] public string Icon { get; set; }
        [JsonProperty("name")] public string Name { get; set; }
        [JsonProperty("cnt")] public string Count { get; set; }
        public double Opacity { get => this.opacity; set => Set(ref this.opacity, value); }
    }
}