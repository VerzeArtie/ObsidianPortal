using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObsidianPortal
{
    public static class ONE
    {
        private static GameObject objPlayer;
        private static GameObject objBackpack;
        private static GameObject objSQL = null;
        private static GameObject objWE2 = null;
        private static GameObject objAchieve = null;

        public static List<Unit> UnitList;
        //public static List<Item> BackpackList;

        public static Backpack BP = null; // バックパック
        public static ControlSQL SQL = null; // SQLログ情報
        public static TruthWorldEnvironment WE2 = null; // ゲームストーリー全体のワールド環境フラグ
        public static Achievement ACV = null; // アチーヴ

        public static bool AlreadyInitialize = false; // 既に一度InitializeGroundOneを呼んだかどうか
        public static bool SupportLog = true;

        // HomeTown
        public static int Day = 0;
        public static string HomeTownArea = string.Empty;
        public static int Gold = 0;
        public static int SoulFragment = 0;
        public static int ObsidianStone = 0;

        // BattleField
        public static string CurrentArea = string.Empty;
        public static bool BattleWin = false;
        public static int BattleElimination = 0;
        public static int BattleTacticsPoint = 0;
        public static int BattleTotalTurn = 0;
        public static int BattleDamageDone = 0;
        public static int BattleHealingDone = 0;
        public static int BattleGettingExp = 0;
        public static List<Item> BattleGetItem = new List<Item>();
            
        public static void Initialize()
        {
            // すでに初期化済の場合は、何もせず終了
            if (AlreadyInitialize == false) { AlreadyInitialize = true; }
            else { Debug.Log("already initialize"); return; }

            // オブジェクトを生成
            objPlayer = new GameObject("objPlayer");
            objBackpack = new GameObject("objBackpack");
            objWE2 = new GameObject("objWE2");
            objSQL = new GameObject("objSQL");
            objAchieve = new GameObject("objAchieve");
            UnitList = new List<Unit>();

            // オブジェクトにクラスを付与
            Unit obj = objPlayer.AddComponent<Unit>();
            // デバッグ用データ
            obj.FullName = FIX.NAME_BILLY_RAKI;
            obj.Level = 1;
            obj.Race = FIX.RaceType.Human;
            obj.Job = FIX.JobClass.Fighter;
            obj.BaseStrength = FIX.BILLY_RAKI_INIT_STR;
            obj.BaseAgility = FIX.BILLY_RAKI_INIT_AGL;
            obj.BaseIntelligence = FIX.BILLY_RAKI_INIT_INT;
            obj.BaseStamina = FIX.BILLY_RAKI_INIT_STM;
            obj.BaseMind = FIX.BILLY_RAKI_INIT_MND;
            obj.BaseLife = FIX.BILLY_RAKI_INIT_BASELIFE;

            obj.AvailableCommandName.Add(FIX.STRAIGHT_SMASH);
            obj.AvailableCommandName.Add(FIX.STANCE_OF_THE_BLADE);
            obj.AvailableCommandName.Add(FIX.DOUBLE_SLASH);
            obj.AvailableCommandName.Add(FIX.WAR_SWING);
            obj.AvailableCommandName.Add(FIX.KINETIC_SMASH);
            obj.AvailableCommandName.Add(FIX.STANCE_OF_THE_IAI);
            obj.AvailableCommandName.Add(FIX.DESTROYER_SMASH);
            obj.AvailableCommandLv.Add(3);
            obj.AvailableCommandLv.Add(6);
            obj.AvailableCommandLv.Add(9);
            obj.AvailableCommandLv.Add(12);
            obj.AvailableCommandLv.Add(15);
            obj.AvailableCommandLv.Add(18);
            obj.AvailableCommandLv.Add(21);
            obj.AvailableCommandValue.Add("Damage");
            obj.AvailableCommandValue.Add("Turn");
            obj.AvailableCommandValue.Add("Damage");
            obj.AvailableCommandValue.Add("Range");
            obj.AvailableCommandValue.Add("Damage");
            obj.AvailableCommandValue.Add("Turn");
            obj.AvailableCommandValue.Add("Damage");

            obj.MainWeapon = new Item(FIX.COMMON_FINE_SWORD);
            obj.SubWeapon = new Item(FIX.COMMON_FINE_SHIELD);
            obj.MainArmor = new Item(FIX.COMMON_FINE_ARMOR);
            obj.Accessory = new Item(FIX.COMMON_RED_PENDANT);
            obj.Accessory2 = new Item(FIX.COMMON_BLUE_AMULET);
            //obj.Accessory3 = new Item(FIX.COMMON_YELLOW_CHARM);

            //obj.AddValuables(new Item(FIX.RARE_EARRING_OF_LANA), 1);
            obj.ActionButtonCommand.Add(FIX.NORMAL_ATTACK);
            obj.ActionButtonCommand.Add(FIX.NORMAL_MOVE);
            obj.ActionButtonCommand.Add(FIX.STRAIGHT_SMASH);
            obj.ActionButtonCommand.Add(FIX.STRAIGHT_SMASH);
            obj.ActionButtonCommand.Add(FIX.ZERO_IMMUNITY);
            obj.MaxGain();
            UnitList.Add(obj);

            Unit obj2 = objPlayer.AddComponent<Unit>();
            // デバッグ用データ
            obj2.FullName = FIX.NAME_ANNA_HAMILTON;
            obj2.Level = 1;
            obj2.Race = FIX.RaceType.Human;
            obj2.Job = FIX.JobClass.Ranger;
            obj2.BaseStrength = FIX.ANNA_HAMILTON_INIT_STR;
            obj2.BaseAgility = FIX.ANNA_HAMILTON_INIT_AGL;
            obj2.BaseIntelligence = FIX.ANNA_HAMILTON_INIT_INT;
            obj2.BaseStamina = FIX.ANNA_HAMILTON_INIT_STM;
            obj2.BaseMind = FIX.ANNA_HAMILTON_INIT_MND;
            obj2.BaseLife = FIX.ANNA_HAMILTON_INIT_BASELIFE;

            obj2.MainWeapon = new Item(FIX.COMMON_FINE_BOW);
            obj2.ActionButtonCommand.Add(FIX.NORMAL_MOVE);
            obj2.ActionButtonCommand.Add(FIX.NORMAL_ATTACK);
            obj2.ActionButtonCommand.Add(FIX.ZERO_IMMUNITY);
            obj2.ActionButtonCommand.Add(FIX.ZERO_IMMUNITY);
            obj2.ActionButtonCommand.Add(FIX.ZERO_IMMUNITY);
            obj2.MaxGain();
            UnitList.Add(obj2);

            Unit obj3 = objPlayer.AddComponent<Unit>();
            // デバッグ用データ
            obj3.FullName = FIX.NAME_EONE_FULNEA;
            obj3.Level = 1;
            obj3.Race = FIX.RaceType.Human;
            obj3.Job = FIX.JobClass.Magician;
            obj3.BaseStrength = FIX.EONE_FULNEA_INIT_STR;
            obj3.BaseAgility = FIX.EONE_FULNEA_INIT_AGL;
            obj3.BaseIntelligence = FIX.EONE_FULNEA_INIT_INT;
            obj3.BaseStamina = FIX.EONE_FULNEA_INIT_STM;
            obj3.BaseMind = FIX.EONE_FULNEA_INIT_MND;
            obj3.BaseLife = FIX.EONE_FULNEA_INIT_BASELIFE;
            obj3.MainWeapon = new Item(FIX.COMMON_WOOD_ROD);
            obj3.ActionButtonCommand.Add(FIX.NORMAL_MOVE);
            obj3.ActionButtonCommand.Add(FIX.NORMAL_ATTACK);
            obj3.ActionButtonCommand.Add(FIX.FIRE_BOLT);
            obj3.ActionButtonCommand.Add(FIX.FRESH_HEAL);
            obj3.ActionButtonCommand.Add(FIX.FIRE_BOLT);
            obj3.MaxGain();
            UnitList.Add(obj3);

            //Unit obj4 = objPlayer.AddComponent<Unit>();
            //obj4.FullName = FIX.KARTIN_MAI;
            //obj4.Level = 1;
            //obj4.Job = FIX.JobClass.Apprentice;
            //obj4.BaseStrength = FIX.KARTIN_MAI_INIT_STR;
            //obj4.BaseAgility = FIX.KARTIN_MAI_INIT_AGL;
            //obj4.BaseIntelligence = FIX.KARTIN_MAI_INIT_INT;
            //obj4.BaseStamina = FIX.KARTIN_MAI_INIT_STM;
            //obj4.BaseMind = FIX.KARTIN_MAI_INIT_MND;
            //obj4.MainWeapon = new Item(FIX.COMMON_LIGHT_CLAW);
            //Chara.Add(obj4);

            //Unit obj5 = objPlayer.AddComponent<Unit>();
            //obj5.FullName = FIX.JEDA_ARUS;
            //obj5.Level = 1;
            //obj5.Job = FIX.JobClass.Armorer;
            //obj5.BaseStrength = FIX.JEDA_ARUS_INIT_STR;
            //obj5.BaseAgility = FIX.JEDA_ARUS_INIT_AGL;
            //obj5.BaseIntelligence = FIX.JEDA_ARUS_INIT_INT;
            //obj5.BaseStamina = FIX.JEDA_ARUS_INIT_STM;
            //obj5.BaseMind = FIX.JEDA_ARUS_INIT_MND;
            //obj5.MainWeapon = new Item(FIX.COMMON_LIGHT_CLAW);
            //Chara.Add(obj5);

            // P1.subWeapon = new Item(FIX.COMMON_FINE_SHIELD);
            //P1.MainArmor = new Item(FIX.COMMON_FINE_ARMOR);
            //P1.Accessory = new Item(FIX.COMMON_RED_AMULET);
            //P1.Accessory2 = new Item(FIX.COMMON_BLUE_AMULET);
            //Player.Level = 4;
            //Player.Exp = 65;
            //Player.Race = FIX.Race.Angel;

            // デバッグ用データ（バックパック）
            BP = objBackpack.AddComponent<Backpack>();
            BP.AddBackPack(new Item(FIX.COMMON_GREEN_PENDANT), 1);
            BP.AddBackPack(new Item(FIX.COMMON_BASTARD_SWORD),1);
            BP.AddBackPack(new Item(FIX.COMMON_FINE_SWORD),1);
            BP.AddBackPack(new Item(FIX.COMMON_FINE_ARMOR),1);
            //BP.AddBackPack(new Item(FIX.COMMON_LARGE_RED_POTION),1);
            BP.AddBackPack(new Item(FIX.RARE_STRONG_SERPENT_SHIELD),1);
            BP.AddBackPack(new Item(FIX.RARE_ADERKER_FALSE_ROD),1);
            BP.AddBackPack(new Item(FIX.EPIC_FLOW_FUNNEL_OF_THE_ZVELDOZE),1);
            //BP.AddBackPack(new Item(FIX.COMMON_AOSAME_KENSHI),1);
            BP.AddBackPack(new Item(FIX.COMMON_WOOD_ROD),1);
            //BP.AddBackPack(new Item(FIX.COMMON_LARGE_RED_POTION),1);
            BP.AddBackPack(new Item(FIX.EPIC_SHEZL_MYSTIC_FORTUNE),1);
            BP.AddBackPack(new Item(FIX.COMMON_ONRYOU_HAKO),1);
            BP.AddBackPack(new Item(FIX.COMMON_EVERMIND_OMEN),1);

            // デバッグ用データ（地点）
            Day = 3;
            HomeTownArea = FIX.TOWN_ANSHETT;
            Gold = 150;
            SoulFragment = 2;
            ObsidianStone = 4;

            WE2 = objWE2.AddComponent<TruthWorldEnvironment>();
            SQL = objSQL.AddComponent<ControlSQL>();
            SQL.SetupSql();
            ACV = objAchieve.AddComponent<Achievement>();

            // デバッグ用データ（WE2フラグ）
            WE2.Event_Message100010 = true;
            WE2.Event_Message100020 = true;
            WE2.Event_Message100030 = true;
            WE2.Event_Message100040 = true;
            WE2.Event_Message200010 = true;
            WE2.Event_Message200020 = true;
            WE2.Event_Message200030 = true;
            WE2.Event_Message300010 = true;
            WE2.Event_Message300020 = true;
            WE2.Event_Message300021 = true;
            WE2.Event_Message300022 = true;
            WE2.Event_Message300023 = true;
            WE2.Event_Message300024 = true;
            WE2.Event_Message400010 = true;
            //WE2.Event_Message400020 = true;

            for (int ii = 0; ii < UnitList.Count; ii++)
            {
                UnityEngine.Object.DontDestroyOnLoad(UnitList[ii]);
            }
            UnityEngine.Object.DontDestroyOnLoad(BP);

            Debug.Log("ONE backpack count: " + BP.GetBackPackInfo().Count.ToString());
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