using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObsidianPortal
{
    public static class ONE
    {
        public static FIX.Stage CurrentStage = FIX.Stage.Stage2_4;
        private static GameObject objPlayer;
        public static MainCharacter Player;
        public static bool AlreadyInitialize = false; // 既に一度InitializeGroundOneを呼んだかどうか

        public static void Initialize()
        {
            if (AlreadyInitialize == false) { AlreadyInitialize = true; }
            else { Debug.Log("already initialize"); return; }

            objPlayer = new GameObject("objPlayer");
            Player = objPlayer.AddComponent<MainCharacter>();

            Player.FullName = "Altomo";
            Player.ObsidianStone = 3;
            Player.Level = 4;
            Player.Exp = 65;
            Player.Race = FIX.Race.Angel;
            UnityEngine.Object.DontDestroyOnLoad(Player);
        }
    }
}