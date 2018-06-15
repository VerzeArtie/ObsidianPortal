using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObsidianPortal
{
    public static class ONE
    {
        private static GameObject objPlayer;
        private static GameObject objSQL = null;
        private static GameObject objWE2 = null;
        private static GameObject objAchieve = null;

        public static List<MainCharacter> Chara; // キャラクター１

        public static ControlSQL SQL = null; // SQLログ情報
        public static TruthWorldEnvironment WE2 = null; // ゲームストーリー全体のワールド環境フラグ
        public static Achievement ACV = null; // アチーヴ

        public static bool AlreadyInitialize = false; // 既に一度InitializeGroundOneを呼んだかどうか
        public static bool SupportLog = true;

        public static FIX.PortalArea CurrentArea = FIX.PortalArea.Area_Human;
        public static FIX.Stage CurrentStage = FIX.Stage.Stage1_1;
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
            Chara = new List<MainCharacter>();

            // オブジェクトに暮らすを付与
            MainCharacter obj = objPlayer.AddComponent<MainCharacter>();
            // デバッグ用データ
            obj.FullName = FIX.DUEL_EONE_FULNEA;
            obj.Level = 1;
            obj.Job = FIX.JobClass.Magician;
            obj.BaseStrength = FIX.EONE_FULNEA_INIT_STR;
            obj.BaseAgility = FIX.EONE_FULNEA_INIT_AGL;
            obj.BaseIntelligence = FIX.EONE_FULNEA_INIT_INT;
            obj.BaseStamina = FIX.EONE_FULNEA_INIT_STM;
            obj.BaseMind = FIX.EONE_FULNEA_INIT_MND;
            obj.MainWeapon = new Item(FIX.COMMON_WOOD_ROD);
            Chara.Add(obj);

            MainCharacter obj2 = objPlayer.AddComponent<MainCharacter>();
            // デバッグ用データ
            obj2.FullName = FIX.DUEL_MAGI_ZELKIS;
            obj2.Level = 1;
            obj2.Job = FIX.JobClass.Fighter;
            obj2.BaseStrength = FIX.MAGI_ZELKIS_INIT_STR;
            obj2.BaseAgility = FIX.MAGI_ZELKIS_INIT_AGL;
            obj2.BaseIntelligence = FIX.MAGI_ZELKIS_INIT_INT;
            obj2.BaseStamina = FIX.MAGI_ZELKIS_INIT_STM;
            obj2.BaseMind = FIX.MAGI_ZELKIS_INIT_MND;
            obj2.MainWeapon = new Item(FIX.COMMON_FINE_SWORD);
            Chara.Add(obj2);

            MainCharacter obj3 = objPlayer.AddComponent<MainCharacter>();
            // デバッグ用データ
            obj3.FullName = FIX.DUEL_SELMOI_RO;
            obj3.Level = 1;
            obj3.Job = FIX.JobClass.Archer;
            obj3.BaseStrength = FIX.SELMOI_RO_INIT_STR;
            obj3.BaseAgility = FIX.SELMOI_RO_INIT_AGL;
            obj3.BaseIntelligence = FIX.SELMOI_RO_INIT_INT;
            obj3.BaseStamina = FIX.SELMOI_RO_INIT_STM;
            obj3.BaseMind = FIX.SELMOI_RO_INIT_MND;
            obj3.MainWeapon = new Item(FIX.COMMON_FINE_BOW);
            Chara.Add(obj3);

            MainCharacter obj4 = objPlayer.AddComponent<MainCharacter>();
            obj4.FullName = FIX.DUEL_KARTIN_MAI;
            obj4.Level = 1;
            obj4.Job = FIX.JobClass.Apprentice;
            obj4.BaseStrength = FIX.KARTIN_MAI_INIT_STR;
            obj4.BaseAgility = FIX.KARTIN_MAI_INIT_AGL;
            obj4.BaseIntelligence = FIX.KARTIN_MAI_INIT_INT;
            obj4.BaseStamina = FIX.KARTIN_MAI_INIT_STM;
            obj4.BaseMind = FIX.KARTIN_MAI_INIT_MND;
            obj4.MainWeapon = new Item(FIX.COMMON_LIGHT_CLAW);
            Chara.Add(obj4);

            MainCharacter obj5 = objPlayer.AddComponent<MainCharacter>();
            obj5.FullName = FIX.DUEL_JEDA_ARUS;
            obj5.Level = 1;
            obj5.Job = FIX.JobClass.Armorer;
            obj5.BaseStrength = FIX.JEDA_ARUS_INIT_STR;
            obj5.BaseAgility = FIX.JEDA_ARUS_INIT_AGL;
            obj5.BaseIntelligence = FIX.JEDA_ARUS_INIT_INT;
            obj5.BaseStamina = FIX.JEDA_ARUS_INIT_STM;
            obj5.BaseMind = FIX.JEDA_ARUS_INIT_MND;
            obj5.MainWeapon = new Item(FIX.COMMON_LIGHT_CLAW);
            Chara.Add(obj5);

            // P1.subWeapon = new Item(FIX.COMMON_FINE_SHIELD);
            //P1.MainArmor = new Item(FIX.COMMON_FINE_ARMOR);
            //P1.Accessory = new Item(FIX.COMMON_RED_AMULET);
            //P1.Accessory2 = new Item(FIX.COMMON_BLUE_AMULET);
            //Player.Level = 4;
            //Player.Exp = 65;
            //Player.Race = FIX.Race.Angel;

            
            
            WE2 = objWE2.AddComponent<TruthWorldEnvironment>();
            SQL = objSQL.AddComponent<ControlSQL>();
            SQL.SetupSql();
            ACV = objAchieve.AddComponent<Achievement>();

            for (int ii = 0; ii < Chara.Count; ii++)
            {
                UnityEngine.Object.DontDestroyOnLoad(Chara[ii]);
            }
            UnityEngine.Object.DontDestroyOnLoad(WE2);
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