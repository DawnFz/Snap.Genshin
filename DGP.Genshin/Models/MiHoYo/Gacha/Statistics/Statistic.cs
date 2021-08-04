﻿using DGP.Snap.Framework.Data.Behavior;
using System;
using System.Collections.Generic;

namespace DGP.Genshin.Models.MiHoYo.Gacha.Statistics
{
    public class Statistic : Observable
    {
        public string Uid { get; set; }
        public Banner Permanent { get; set; }
        public Banner CharacterEvent { get; set; }
        public Banner WeaponEvent { get; set; }

        public List<Item> Characters { get; set; }
        public List<Item> Weapons { get; set; }
    }
    public class Banner
    {
        public int TotalCount { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public string CurrentName { get; set; }

        public int CountSinceLastStar5 { get; set; }
        public List<Star5Item> Star5List { get; set; }
        public double Star5Prob { get; set; }
        public int Star5Count { get; set; }
        public double Star4Prob { get; set; }
        public int Star4Count { get; set; }
        public double Star3Prob { get; set; }
        public int Star3Count { get; set; }

        public double AverageGetStar5 { get; set; }
        public int MaxGetStar5Count { get; set; }
        public int MinGetStar5Count { get; set; }
    }

    public class Star5Item
    {
        public string Name { get; set; }
        public int Count { get; set; }
        public DateTime Time { get; set; }
    }

    public class Item
    {
        public string StarUrl { get; set; }
        public string Source { get; set; }
        public string Name { get; set; }
        public string Element { get; set; }
        public int Count { get; set; }
    }
}