﻿using Modding;

namespace BingoUI.Counters
{
    public class IntCounter : AbstractCounter
    {
        private readonly string intName;

        public IntCounter(float x, float y, string spriteName, string intName) : base(x, y, spriteName)
        {
            this.intName = intName;
        }
        public override string GetText() => GetText(PlayerData.instance.GetInt(intName));
        public string GetText(int amt) => $"{amt}";
        public override void Hook()
        {
            ModHooks.SetPlayerIntHook += OnSetInt;
        }

        private int OnSetInt(string name, int orig)
        {
            if (name == intName)
            {
                UpdateText(GetText(orig));
            }
            return orig;
        }
    }
}
