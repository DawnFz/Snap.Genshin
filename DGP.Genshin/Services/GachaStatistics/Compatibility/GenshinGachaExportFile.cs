﻿using DGP.Genshin.MiHoYoAPI.Gacha;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace DGP.Genshin.Services.GachaStatistics.Compatibility
{
    public class GenshinGachaExportFile
    {
        [JsonProperty("gachaType")] public List<ConfigType>? Types { get; set; }
        [JsonProperty("gachaLog")] public GachaData? Data { get; set; }
        [JsonProperty("uid")] public string? Uid { get; set; }
    }
}
