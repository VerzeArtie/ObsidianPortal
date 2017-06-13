using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObsidianPortal
{
    public static class ONE
    {
        public static FIX.Stage CurrentStage = FIX.Stage.Stage2_4;
        private static GameObject objPlayer;
        private static GameObject objSQL = null;
        private static GameObject objWE2 = null;
        private static GameObject objAchieve = null;

        public static MainCharacter Player; // プレイヤー情報
        public static ControlSQL SQL = null; // SQLログ情報
        public static TruthWorldEnvironment WE2 = null; // ゲームストーリー全体のワールド環境フラグ
        public static Achievement ACV = null; // アチーヴ

        public static bool AlreadyInitialize = false; // 既に一度InitializeGroundOneを呼んだかどうか
        public static bool SupportLog = true;

        public static bool BattleWin = false;
        public static int BattleElimination = 0;
        public static int BattleTacticsPoint = 0;
        public static int BattleTotalTurn = 0;
        public static int BattleDamageDone = 0;
        public static int BattleHealingDone = 0;
        public static int BattleGettingExp = 0;
            
        public static void Initialize()
        {
            // すでに初期化済の場合は、何もせず終了
            if (AlreadyInitialize == false) { AlreadyInitialize = true; }
            else { Debug.Log("already initialize"); return; }

            // オブジェクトを生成
            objPlayer = new GameObject("objPlayer");
            objWE2 = new GameObject("objWE2");
            objSQL = new GameObject("objSQL");
            objAchieve = new GameObject("objAchieve");

            // オブジェクトに暮らすを付与
            Player = objPlayer.AddComponent<MainCharacter>();
            WE2 = objWE2.AddComponent<TruthWorldEnvironment>();
            SQL = objSQL.AddComponent<ControlSQL>();
            SQL.SetupSql();
            ACV = objAchieve.AddComponent<Achievement>();

            // デバッグ用データ
            Player.FullName = "Altomo";
            Player.ObsidianStone = 1;
            //Player.Level = 4;
            //Player.Exp = 65;
            //Player.Race = FIX.Race.Angel;

            UnityEngine.Object.DontDestroyOnLoad(Player);
        }

        public static void ResetBattleData()
        {
            BattleWin = false;
            BattleElimination = 0;
            BattleTacticsPoint = 0;
            BattleTotalTurn = 0;
            BattleDamageDone = 0;
            BattleHealingDone = 0;
            BattleGettingExp = 0;
        }
    }
}