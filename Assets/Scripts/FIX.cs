using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObsidianPortal
{
    public static class FIX
    {
        // 定数
        public const float HEX_MOVE_X = 1.732f;
        public const float HEX_MOVE_Z = 1.500f;
        public const float HEX_MOVE_X2 = 0.866f;

        public const string LAYER_UNITCOMMAND = "UnitCommand";
        public const string LAYER_STAGEPANEL = "StagePanel";

        // 人間族
        public const string HUMAN_FIGHTER = "ファイター";
        public const string HUMAN_ARCHER = "アーチャー";
        public const string HUMAN_SORCERER = "ソーサラー";
        public const string HUMAN_ENCHANTER = "エンチャンター";
        public const string HUMAN_PRIEST = "プリースト";
        // 機巧族
        public const string MECH_M1 = "";
        public const string MECH_M2 = "";
        public const string MECH_M3 = "";
        public const string MECH_M4 = "";
        public const string MECH_M5 = "";
        // 天使族
        public const string ANGEL_DOMINION = "ドミニオン";
        public const string ANGEL_VALKYRIE = "ヴァルキリー";
        public const string ANGEL_HOLYEYE = "ホーリー・アイ";
        public const string ANGEL_QUPID = "キューピッド";
        public const string ANGEL_ANGEL = "ホワイト・エンジェル";
        // 魔貴族
        public const string DEMON_SKELETON = "スケルトン";
        public const string DEMON_INP = "インプ";
        public const string DEMON_REGION = "レギオン";
        public const string DEMON_GARGOYLE = "ガーゴイル";
        public const string DEMON_VAMPIRE = "ヴァンパイア";
        // 炎霊族
        public const string FIRE_SALAMANDER = "サラマンダー";
        public const string FIRE_ELEMENTAL = "ファイア・エレメンタル";
        public const string FIRE_EFREET = "イフリート";
        public const string FIRE_FLAMEBIRD = "フレイム・バード";
        public const string FIRE_REDBOMB = "レッド・ボム";
        // 氷霊族
        public const string ICE_UNDINE = "ウンディーネ";
        public const string ICE_ELEMENTAL = "アイス・エレメンタル";
        public const string ICE_SIRENE = "セイレーン";
        public const string ICE_I3 = "I3";
        public const string ICE_I4 = "I4";
        public const string ICE_I5 = "I5";

        // 壁
        public const string OBJ_LAVAWALL = "炎の壁";

        // スキル名称
        public const string NORMAL_ATTACK = "攻撃";
        public const string NORMAL_END = "待機";
        public const string DASH = "ダッシュ";
        public const string REACHABLETARGET = "リーチャブル・ターゲット";
        public const string EARTHBIND = "アース・バインド";
        public const string POWERWORD = "ワード・パワー";
        public const string HEALINGWORD = "ヒーリング・ワード";
        public const string NEEDLESPEAR = "ニードル・スピア";
        public const string SILVERARROW = "シルバー・アロー";
        public const string HOLYBULLET = "ホーリー・バレット";
        public const string PROTECTION = "プロテクション";
        public const string FRESHHEAL = "フレッシュ・ヒール";
        public const string FIREBLADE = "ファイア・ブレイド";
        public const string LAVAWALL = "ラーヴァ・ウォール";
        public const string BLAZE = "ブレイズ";
        public const string HEATBOOST = "ヒート・ブースト";
        public const string EXPLOSION = "エクスプロージョン";
        public const string NONE = "";

        public const string SCENE_MAINMENU = "MainMenu";
        public const string SCENE_STAGESELECT = "StageSelect";
        public const string SCENE_BATTLEFIELD = "BattleField";
        public const string SCENE_GAMERESULT = "GameResult";
        public enum Stage
        {
            Stage1_1,
            Stage1_2,
            Stage1_3,
            Stage1_4,
            Stage1_5,
            Stage2_1,
            Stage2_2,
            Stage2_3,
            Stage2_4,
            Stage2_5,
        }

        public enum Race
        {
            Human,
            Mech,
            Angel,
            Demon,
            Fire,
            Ice,
        }

        public enum Direction
        {
            None = -1,
            Top = 0,
            TopRight = 1,
            TopLeft = 2,
            BottomLeft = 3,
            BottomRight = 4,
            Bottom = 5,
        }

        #region "DungeonPlayerからインポート"
        public static int INFINITY = 99999;
        public static int MAX_BACKPACK_SIZE = 20; // 10->20 後編編集
        #region "アイテム名称"
        #region "初期"
        // アイテム名称を各ソースコードに記述すると誤りが発生するため、こちらで記載します。
        public const string RARE_TOOMI_BLUE_SUISYOU = @"遠見の青水晶";
        public const string RARE_EARRING_OF_LANA = @"ラナのイヤリング";
        public const string POOR_PRACTICE_SWORD = @"練習用の剣";
        public const string POOR_PRACTICE_SHILED = @"練習用の盾";
        public const string POOR_COTE_OF_PLATE = @"コート・オブ・プレート";
        public const string POOR_PRACTICE_KNUCKLE = @"練習用のナックル";
        public const string POOR_LIGHT_CROSS = @"軽めの舞踏衣";
        public const string COMMON_SANGO_BRESLET = @"珊瑚のブレスレット";
        #endregion

        #region "１階"
        public const string POOR_HINJAKU_ARMRING = @"貧弱な腕輪";
        public const string POOR_USUYOGORETA_FEATHER = @"薄汚れた付け羽";
        public const string POOR_NON_BRIGHT_ORB = @"輝きの無いオーブ";
        public const string POOR_KUKEI_BANGLE = @"矩形のバングル";
        public const string POOR_SUTERARESHI_EMBLEM = @"捨てられし紋章";
        public const string POOR_ARIFURETA_STATUE = @"ありふれた彫像";
        public const string POOR_NON_ADJUST_BELT = @"調整できないベルト";
        public const string POOR_SIMPLE_EARRING = @"シンプルなイヤリング";
        public const string POOR_KATAKUZURESHITA_FINGERRING = @"型崩れした指輪";
        public const string POOR_IROASETA_CHOKER = @"色褪せたチョーカー";
        public const string POOR_YOREYORE_MANTLE = @"よれよれのマント";
        public const string POOR_NON_HINSEI_CROWN = @"品性のない王冠";
        public const string POOR_TUKAIFURUSARETA_SWORD = @"使い古された剣";
        public const string POOR_TUKAINIKUI_LONGSWORD = @"使いにくい長剣";
        public const string POOR_GATAGAKITERU_ARMOR = @"ガタがきてる鎧";
        public const string POOR_FESTERING_ARMOR = @"フェスタリング・アーマー";
        public const string POOR_HINSO_SHIELD = @"貧粗な盾";
        public const string POOR_MUDANIOOKII_SHIELD = @"無駄に大きい盾";

        public const string COMMON_RED_PENDANT = @"レッド・ペンダント";
        public const string COMMON_BLUE_PENDANT = @"ブルー・ペンダント";
        public const string COMMON_PURPLE_PENDANT = @"パープル・ペンダント";
        public const string COMMON_GREEN_PENDANT = @"グリーン・ペンダント";
        public const string COMMON_YELLOW_PENDANT = @"イエロー・ペンダント";
        public const string COMMON_SISSO_ARMRING = @"質素な腕輪";
        public const string COMMON_FINE_FEATHER = @"ファイン・フェザー";
        public const string COMMON_KIREINA_ORB = @"綺麗なオーブ";
        public const string COMMON_FIT_BANGLE = @"フィット・バングル";
        public const string COMMON_PRISM_EMBLEM = @"プリズム・エムブレム";
        public const string COMMON_FINE_SWORD = @"ファイン・ソード";
        public const string COMMON_TWEI_SWORD = @"ツヴァイ・ソード";
        public const string COMMON_FINE_ARMOR = @"ファイン・アーマー";
        public const string COMMON_GOTHIC_PLATE = @"ゴシック・プレート";
        public const string COMMON_FINE_SHIELD = @"ファイン・シールド";
        public const string COMMON_GRIPPING_SHIELD = @"グリッピング・シールド";

        public const string RARE_JOUSITU_BLUE_POWERRING = @"上質の青いパワーリング";
        public const string RARE_KOUJOUSINYADORU_RED_ORB = @"向上心の宿る赤いオーブ";
        public const string RARE_MAGICIANS_MANTLE = @"マジシャンズ・マント";
        public const string RARE_BEATRUSH_BANGLE = @"ビートラッシュ・バングル";
        public const string RARE_AERO_BLADE = @"エアロ・ブレード";

        public const string POOR_OLD_USELESS_ROD = @"古ぼけた杖";
        public const string POOR_KISSAKI_MARUI_TUME = @"切先が丸い爪";
        public const string POOR_BATTLE_HUMUKI_BUTOUGI = @"戦闘に不向きな舞踏衣";
        public const string POOR_SIZE_AWANAI_ROBE = @"サイズが合わないローブ";
        public const string POOR_NO_CONCEPT_RING = @"特徴が失せている腕輪";
        public const string POOR_HIGHCOLOR_MANTLE = @"ハイカラなマント";
        public const string POOR_EIGHT_PENDANT = @"八角ペンダント";
        public const string POOR_GOJASU_BELT = @"ゴージャスベルト";
        public const string POOR_EGARA_HUMEI_EMBLEM = @"絵柄不明のペンダント";
        public const string POOR_HAYATOTIRI_ORB = @"はやとちりなオーブ";

        public const string COMMON_COPPER_RING_TORA = @"銅の腕輪『虎』";
        public const string COMMON_COPPER_RING_IRUKA = @"銅の腕輪『イルカ』";
        public const string COMMON_COPPER_RING_UMA = @"銅の腕輪『馬』";
        public const string COMMON_COPPER_RING_KUMA = @"銅の腕輪『熊』";
        public const string COMMON_COPPER_RING_HAYABUSA = @"銅の腕輪『隼』";
        public const string COMMON_COPPER_RING_TAKO = @"銅の腕輪『タコ』";
        public const string COMMON_COPPER_RING_USAGI = @"銅の腕輪『兎』";
        public const string COMMON_COPPER_RING_KUMO = @"銅の腕輪『蜘蛛』";
        public const string COMMON_COPPER_RING_SHIKA = @"銅の腕輪『鹿』";
        public const string COMMON_COPPER_RING_ZOU = @"銅の腕輪『象』";
        public const string COMMON_RED_AMULET = @"アミュレット『赤』";
        public const string COMMON_BLUE_AMULET = @"アミュレット『青』";
        public const string COMMON_PURPLE_AMULET = @"アミュレット『紫』";
        public const string COMMON_GREEN_AMULET = @"アミュレット『緑』";
        public const string COMMON_YELLOW_AMULET = @"アミュレット『黄』";
        public const string COMMON_SHARP_CLAW = @"シャープ・クロー";
        public const string COMMON_LIGHT_CLAW = @"ライト・クロー";
        public const string COMMON_WOOD_ROD = @"ウッド・ロッド";
        public const string COMMON_SHORT_SWORD = @"ショート・ソード";
        public const string COMMON_BASTARD_SWORD = @"バスタード・ソード";
        public const string COMMON_LETHER_CLOTHING = @"レザー・クロス";
        public const string COMMON_COTTON_ROBE = @"コットン・ローブ";
        public const string COMMON_COPPER_ARMOR = @"銅の鎧";
        public const string COMMON_HEAVY_ARMOR = @"ヘヴィ・アーマー";
        public const string COMMON_IRON_SHIELD = @"アイアン・シールド";

        public const string RARE_SINTYUU_RING_KUROHEBI = @"真鍮の腕輪『黒蛇』";
        public const string RARE_SINTYUU_RING_HAKUTYOU = @"真鍮の腕輪『白鳥』";
        public const string RARE_SINTYUU_RING_AKAHYOU = @"真鍮の腕輪『赤豹』";
        public const string RARE_ICE_SWORD = @"アイシクル・ソード";
        public const string RARE_RISING_KNUCKLE = @"ライジング・ナックル";
        public const string RARE_AUTUMN_ROD = @"オータムン・ロッド";
        public const string RARE_SUN_BRAVE_ARMOR = @"サン・ブレイブアーマー";
        public const string RARE_ESMERALDA_SHIELD = @"シールド・オブ・エスメラルダ";
        #endregion

        #region "ダンジョン１階の宝箱"
        public const string POOR_HARD_SHOES = @"硬質シューズ";
        public const string COMMON_SIMPLE_BRACELET = @"簡素なブレスレット";
        public const string COMMON_SEAL_OF_POSION = @"シール・オブ・ポイズン";
        public const string COMMON_GREEN_EGG_KAIGARA = @"緑卵の貝殻";
        public const string COMMON_CHARM_OF_FIRE_ANGEL = @"炎授天使の護符";
        public const string COMMON_DREAM_POWDER = @"ドリーム・パウダー";
        public const string COMMON_VIKING_SWORD = @"バイキング・ソード";
        public const string COMMON_NEBARIITO_KUMO = @"土蜘蛛の粘り糸";
        public const string COMMON_SUN_PRISM = @"太陽のプリズム";
        public const string COMMON_POISON_EKISU = @"ポイズン・エキス";
        public const string COMMON_SOLID_CLAW = @"ソリッド・クロー";
        public const string COMMON_GREEN_LEEF_CHARM = @"緑葉の魔除け";
        public const string COMMON_WARRIOR_MEDAL = @"戦士の刻印";
        public const string COMMON_PALADIN_MEDAL = @"パラディンの刻印";
        public const string COMMON_KASHI_ROD = @"樫の杖";
        public const string COMMON_HAYATE_ORB = @"疾風の宝珠";
        public const string COMMON_BLUE_COPPER = @"青銅石";
        public const string COMMON_ORANGE_MATERIAL = @"オレンジ・マテリアル";
        public const string RARE_TOTAL_HIYAKU_KASSEI = @"統合秘薬『活性』";
        public const string RARE_ZEPHER_FETHER = @"ゼフィール・フェザー";
        public const string RARE_LIFE_SWORD = @"ソード・オブ・ライフ";
        public const string RARE_PURE_WATER = @"清透水";
        public const string RARE_PURE_GREEN_SILK_ROBE = @"純緑のシルクローブ";
        #endregion

        #region "２階のランダムドロップ"
        public const string POOR_HUANTEI_RING = @"不安定なリング";
        public const string POOR_DEPRESS_FEATHER = @"デプレス・フェザー";
        public const string POOR_DAMAGED_ORB = @"傷アリのオーブ";
        public const string POOR_SHIMETSUKE_BELT = @"締め付けベルト";
        public const string POOR_NOGENKEI_EMBLEM = @"原型の無い紋章";
        public const string POOR_MAGICLIGHT_FIRE = @"マジックライト『火』";
        public const string POOR_MAGICLIGHT_ICE = @"マジックライト『水』";
        public const string POOR_MAGICLIGHT_SHADOW = @"マジックライト『闇』";
        public const string POOR_MAGICLIGHT_LIGHT = @"マジックライト『聖』";
        // 武器のPoorは不要。
        public const string COMMON_RED_CHARM = @"レッド・チャーム";
        public const string COMMON_BLUE_CHARM = @"ブルー・チャーム";
        public const string COMMON_PURPLE_CHARM = @"パープル・チャーム";
        public const string COMMON_GREEN_CHARM = @"グリーン・チャーム";
        public const string COMMON_YELLOW_CHARM = @"イエロー・チャーム";
        public const string COMMON_THREE_COLOR_COMPASS = @"３色コンパス";
        public const string COMMON_SANGO_CROWN = @"珊瑚の冠";
        public const string COMMON_SMOOTHER_BOOTS = @"スムーザー・ブーツ";
        public const string COMMON_SHIOKAZE_MANTLE = @"潮風の外套";
        public const string COMMON_SMART_SWORD = @"スマート・ソード";
        public const string COMMON_SMART_CLAW = @"スマート・クロー";
        public const string COMMON_SMART_ROD = @"スマート・ロッド";
        public const string COMMON_SMART_SHIELD = @"スマート・シールド";
        public const string COMMON_RAUGE_SWORD = @"ラウジェ・ソード";
        public const string COMMON_SMART_CLOTHING = @"スマート・クロス";
        public const string COMMON_SMART_ROBE = @"スマート・ローブ";
        public const string COMMON_SMART_PLATE = @"スマート・プレート";

        public const string RARE_WRATH_SERVEL_CLAW = @"ラス・サーヴェル・クロー";
        public const string RARE_BLUE_LIGHTNING = @"ブルー・ライトニング";
        public const string RARE_DIRGE_ROBE = @"ダージェ・ローブ";
        public const string RARE_DUNSID_PLATE = @"ダンシッド・プレート";
        public const string RARE_BURNING_CLAYMORE = @"バーニング・クレイモア";

        public const string POOR_CURSE_EARRING = @"カース・イヤリング";
        public const string POOR_CURSE_BOOTS = @"呪われたブーツ";
        public const string POOR_BLOODY_STATUE = @"血染めの彫像";
        public const string POOR_FALLEN_MANTLE = @"堕ちたるマント";
        public const string POOR_SIHAIRYU_SIKOTU = @"支配竜の指骨";
        public const string POOR_OLD_TREE_KAREHA = @"古代栄樹の枯れ葉";
        public const string POOR_GALEWIND_KONSEKI = @"ゲイル・ウィンドの痕跡";
        public const string POOR_SIN_CRYSTAL_KAKERA = @"シン・クリスタルの欠片";
        public const string POOR_EVERMIND_ZANSHI = @"エバー・マインドの残思";
        // 武器のPoorは不要。

        public const string COMMON_BRONZE_RING_KIBA = @"青銅の腕輪『牙』";
        public const string COMMON_BRONZE_RING_SASU = @"青銅の腕輪『刺』";
        public const string COMMON_BRONZE_RING_KU = @"青銅の腕輪『駆』";
        public const string COMMON_BRONZE_RING_NAGURI = @"青銅の腕輪『殴』";
        public const string COMMON_BRONZE_RING_TOBI = @"青銅の腕輪『飛』";
        public const string COMMON_BRONZE_RING_KARAMU = @"青銅の腕輪『絡』";
        public const string COMMON_BRONZE_RING_HANERU = @"青銅の腕輪『跳』";
        public const string COMMON_BRONZE_RING_TORU = @"青銅の腕輪『補』";
        public const string COMMON_BRONZE_RING_MIRU = @"青銅の腕輪『視』";
        public const string COMMON_BRONZE_RING_KATAI = @"青銅の腕輪『堅』";
        public const string COMMON_RED_KOKUIN = @"赤の刻印";
        public const string COMMON_BLUE_KOKUIN = @"青の刻印";
        public const string COMMON_PURPLE_KOKUIN = @"紫の刻印";
        public const string COMMON_GREEN_KOKUIN = @"緑の刻印";
        public const string COMMON_YELLOW_KOKUIN = @"黄の刻印";
        public const string COMMON_SISSEI_MANTLE = @"執政のマント";
        public const string COMMON_KAISEI_EMBLEM = @"快晴の紋章";
        public const string COMMON_SAZANAMI_EARRING = @"さざなみイヤリング";
        public const string COMMON_AMEODORI_STATUE = @"雨踊りの彫像";
        public const string COMMON_SMASH_BLADE = @"スマッシュ・ブレード";
        public const string COMMON_POWERED_BUSTER = @"パワード・バスター";
        public const string COMMON_STONE_CLAW = @"ストーン・クロー";
        public const string COMMON_DENDOU_ROD = @"電導ロッド";
        public const string COMMON_SERPENT_ARMOR = @"サーペント・アーマー";
        public const string COMMON_SWIFT_CROSS = @"スウィフト・クロス";
        public const string COMMON_CHIFFON_ROBE = @"シフォン・ローブ";
        public const string COMMON_PURE_BRONZE_SHIELD = @"純青銅の盾";

        public const string RARE_RING_BRONZE_RING_KONSHIN = @"燐青銅の腕輪『渾身』";
        public const string RARE_RING_BRONZE_RING_SYUNSOKU = @"燐青銅の腕輪『俊足』";
        public const string RARE_RING_BRONZE_RING_JUKURYO = @"燐青銅の腕輪『熟慮』";
        public const string RARE_RING_BRONZE_RING_SOUGEN = @"燐青銅の腕輪『爽源』";
        public const string RARE_RING_BRONZE_RING_YUUDAI = @"燐青銅の腕輪『雄大』";
        public const string RARE_MEIUN_BOX = @"命運のプリズムボックス";
        public const string RARE_WILL_HOLY_HAT = @"ウィル・ホーリーズ・ハット";
        public const string RARE_EMBLEM_BLUESTAR = @"エムブレム・オブ・ブルースター";
        public const string RARE_SEAL_OF_DEATH = @"シール・オブ・デス";
        public const string RARE_DARKNESS_SWORD = @"ソード・オブ・ダークネス";
        public const string RARE_BLUE_RED_ROD = @"赤蒼授の杖";
        public const string RARE_SHARKSKIN_ARMOR = @"シャークスキン・アーマー";
        public const string RARE_RED_THUNDER_ROBE = @"ローブ・オブ・レッドサンダー";
        public const string RARE_BLACK_MAGICIAN_CROSS = @"黒魔術師の舞踏衣";
        public const string RARE_BLUE_SKY_SHIELD = @"ブルースカイ・シールド";
        #endregion

        #region "ダンジョン２階の宝箱"
        public const string COMMON_PUZZLE_BOX = @"パズル・ボックス";
        public const string COMMON_CHIENOWA_RING = @"知恵の輪リング";
        public const string RARE_MASTER_PIECE = @"マスター・ピース";
        public const string COMMON_TUMUJIKAZE_BOX = @"つむじ風の箱";
        public const string COMMON_ROCKET_DASH = @"ロケット・ダッシュ";
        public const string COMMON_CLAW_OF_SPRING = @"春風の爪";
        public const string COMMON_SOUKAI_DRINK_WATER = @"爽快ドリンクの原液";
        public const string COMMON_BREEZE_CROSS = @"そよ風の舞踏衣";
        public const string COMMON_GUST_SWORD = @"ソード・オブ・ガスト";
        //public const string RARE_PURE_GREEN_WATER = @"活湧水"; // Duel、ジェダ・アルスの持ち物はここで入手可能とする。
        public const string COMMON_BLANK_BOX = @"空白の箱";
        public const string RARE_SPIRIT_OF_HEART = @"心の聖杯【ハート】";
        public const string COMMON_FUSION_BOX = @"フュージョン・ボックス";
        public const string COMMON_WAR_DRUM = @"ウォードラム";
        public const string COMMON_KOBUSHI_OBJE = @"拳型のオブジェ";
        public const string COMMON_TIGER_BLADE = @"タイガー・ブレイド";
        public const string COMMON_TUUKAI_DRINK_WATER = @"痛快ドリンクの原液";
        public const string RARE_ROD_OF_STRENGTH = @"力の杖";
        public const string RARE_SOUJUTENSHI_NO_GOFU = @"蒼授天使の護符";
        #endregion

        #region "３階のランダムドロップ"
        // 武器のPoorは不要。
        public const string POOR_DIRTY_ANGEL_CONTRACT = @"ボロボロになった天使の契約書";
        public const string POOR_JUNK_TARISMAN_FROZEN = @"ジャンク・タリスマン【凍結】";
        public const string POOR_JUNK_TARISMAN_PARALYZE = @"ジャンク・タリスマン【麻痺】";
        public const string POOR_JUNK_TARISMAN_STUN = @"ジャンク・タリスマン【スタン】";
        public const string COMMON_RED_STONE = @"レッド・ストーン";
        public const string COMMON_BLUE_STONE = @"ブルー・ストーン";
        public const string COMMON_PURPLE_STONE = @"パープル・ストーン";
        public const string COMMON_GREEN_STONE = @"グリーン・ストーン";
        public const string COMMON_YELLOW_STONE = @"イエロー・ストーン";
        public const string COMMON_EXCELLENT_SWORD = @"エクセレント・ソード";
        public const string COMMON_EXCELLENT_KNUCKLE = @"エクセレント・ナックル";
        public const string COMMON_EXCELLENT_ROD = @"エクセレント・ロッド";
        public const string COMMON_EXCELLENT_BUSTER = @"エクセレント・バスター";
        public const string COMMON_EXCELLENT_ARMOR = @"エクセレント・アーマー";
        public const string COMMON_EXCELLENT_CROSS = @"エクセレント・クロス";
        public const string COMMON_EXCELLENT_ROBE = @"エクセレント・ローブ";
        public const string COMMON_EXCELLENT_SHIELD = @"エクセレント・シールド";
        public const string RARE_MENTALIZED_FORCE_CLAW = @"メンタライズド・フォース・クロー";
        public const string RARE_ADERKER_FALSE_ROD = @"アダーカー・フォルス・ロッド";
        public const string RARE_BLACK_ICE_SWORD = @"黒氷刀";
        public const string RARE_CLAYMORE_ZUKS = @"クレイモア・オブ・ザックス";
        public const string RARE_DRAGONSCALE_ARMOR = @"ドラゴンスケイル・アーマー";
        public const string RARE_LIGHT_BLIZZARD_ROBE = @"ライトブリザード・ローブ";

        public const string POOR_MIGAWARI_DOOL = @"身代わり人形";
        public const string POOR_ONE_DROPLET_KESSYOU = @"一滴の雫結晶";
        public const string POOR_MOMENTARY_FLASH_LIGHT = @"モーメンタリ・フラッシュ";
        public const string POOR_SUN_YUME_KAKERA = @"寸の夢の欠片";
        public const string COMMON_STEEL_RING_1 = @"鋼の腕輪『パワー』";
        public const string COMMON_STEEL_RING_2 = @"鋼の腕輪『センス』";
        public const string COMMON_STEEL_RING_3 = @"鋼の腕輪『タフ』";
        public const string COMMON_STEEL_RING_4 = @"鋼の腕輪『ロック』";
        public const string COMMON_STEEL_RING_5 = @"鋼の腕輪『ファスト』";
        public const string COMMON_STEEL_RING_6 = @"鋼の腕輪『シャープ』";
        public const string COMMON_STEEL_RING_7 = @"鋼の腕輪『ハイ』";
        public const string COMMON_STEEL_RING_8 = @"鋼の腕輪『ディープ』";
        public const string COMMON_STEEL_RING_9 = @"鋼の腕輪『バウンド』";
        public const string COMMON_STEEL_RING_10 = @"鋼の腕輪『エモート』";
        public const string COMMON_RED_MASEKI = @"赤の魔石";
        public const string COMMON_BLUE_MASEKI = @"青の魔石";
        public const string COMMON_PURPLE_MASEKI = @"紫の魔石";
        public const string COMMON_GREEN_MASEKI = @"緑の魔石";
        public const string COMMON_YELLOW_MASEKI = @"黄の魔石";
        public const string COMMON_DESCENED_BLADE = @"ディッセンド・ブレード";
        public const string COMMON_FALSET_CLAW = @"ファルセットの爪";
        public const string COMMON_SEKIGAN_ROD = @"隻眼の杖";
        public const string COMMON_ROCK_BUSTER = @"ロック・バスター";
        public const string COMMON_COLD_STEEL_PLATE = @"コールド・スチール・プレート";
        public const string COMMON_AIR_HARE_CROSS = @"空晴の舞踏衣";
        public const string COMMON_FLOATING_ROBE = @"フローティング・ローブ";
        public const string COMMON_SNOW_CRYSTAL_SHIELD = @"雪結晶の盾";
        public const string COMMON_WING_STEP_FEATHER = @"ウィングステップ・フェザー";
        public const string COMMON_SNOW_FAIRY_BREATH = @"スノーフェアリーの息吹";
        public const string COMMON_STASIS_RING = @"ステイシス・リング";
        public const string COMMON_SIHAIRYU_KIBA = @"支配竜の牙";
        public const string COMMON_OLD_TREE_JUSHI = @"古代栄樹の樹脂";
        public const string COMMON_GALEWIND_KIZUATO = @"ゲイル・ウィンドの傷跡";
        public const string COMMON_SIN_CRYSTAL_QUATZ = @"シン・クリスタル・クォーツ";
        public const string COMMON_EVERMIND_OMEN = @"エバー・マインド・オーメン";
        public const string RARE_FROZEN_LAVA = @"凍結した溶岩";
        public const string RARE_WHITE_TIGER_ANGEL_GOHU = @"珀虎天使の護符";
        public const string RARE_POWER_STEEL_RING_SOLID = @"強芯鋼の腕輪『ソリッド』";
        public const string RARE_POWER_STEEL_RING_VAPOR = @"強芯鋼の腕輪『ヴェイパー』";
        public const string RARE_POWER_STEEL_RING_ERASTIC = @"強芯鋼の腕輪『エラスト』";
        public const string RARE_POWER_STEEL_RING_TORAREITION = @"強芯鋼の腕輪『トラレイス』";
        public const string RARE_SYUURENSYA_KUROOBI = @"修練者の黒帯";
        public const string RARE_SHIHANDAI_KUROOBI = @"師範代の黒帯";
        public const string RARE_SYUUDOUSOU_KUROOBI = @"修道僧の黒帯";
        public const string RARE_KUGYOUSYA_KUROOBI = @"苦行者の黒帯";
        public const string RARE_TEARS_END = @"ティアーズ・エンド";
        public const string RARE_SKY_COLD_BOOTS = @"スカイ・コールド・ブーツ";
        public const string RARE_EARTH_BREAKERS_SIGIL = @"アース・ブレイカーズ・シギル";
        public const string RARE_AERIAL_VORTEX = @"エアリアル・ヴォルテックス";
        public const string RARE_LIVING_GROWTH_SEED = @"リヴィング・グロース・シード";
        public const string RARE_SHARPNEL_SPIN_BLADE = @"シャープネル・スピン・ブレイド";
        public const string RARE_BLUE_LIGHT_MOON_CLAW = @"薄青く光る蒼月爪";
        public const string RARE_BLIZZARD_SNOW_ROD = @"ブリザード・スノー・ロッド";
        public const string RARE_SHAERING_BONE_CRUSHER = @"シアリング・ボーン・クラッシャー";
        public const string RARE_SCALE_BLUERAGE = @"スケイル・オブ・ブルーレイジ";
        public const string RARE_BLUE_REFLECT_ROBE = @"ブルー・リフレクト・ローブ";
        public const string RARE_SLIDE_THROUGH_SHIELD = @"スライド・スルー・シールド";
        public const string RARE_ELEMENTAL_STAR_SHIELD = @"エレメンタル・スター・シールド";
        #endregion

        #region "ダンジョン３階の宝箱"
        public const string COMMON_ESSENCE_OF_EARTH = @"エッセンス・オブ・アース";
        public const string COMMON_KESSYOU_SEA_WATER_SALT = @"結晶化した海水塩";
        public const string COMMON_STAR_DUST_RING = @"スターダスト・リング";
        public const string COMMON_RED_ONION = @"赤タマネギ";
        public const string RARE_TAMATEBAKO_AKIDAMA = @"玉手箱『秋玉』";
        public const string RARE_HARDEST_FIT_BOOTS = @"ハーデスト・フィット・ブーツ";
        public const string COMMON_WATERY_GROBE = @"ウォータリー・グローヴ";
        public const string COMMON_WHITE_POWDER = @"ホワイト・パウダー";
        public const string COMMON_SILENT_BOWL = @"サイレント・ボール";
        public const string RARE_SEAL_OF_ICE = @"シール・オヴ・アイス";
        public const string RARE_SWORD_OF_DIVIDE = @"ソード・オブ・ディバイド";
        public const string EPIC_OLD_TREE_MIKI_DANPEN = @"古代栄樹の幹の断片";
        #endregion

        #region "４階のランダムドロップ"
        // 武器のPoorは不要。
        //public const string RARE_PURPLE_ABYSSAL_SWORD = @"パープル・アヴィッサル・ソード";
        //public const string RARE_BLACK_HIEN_CLAW = @"黒飛燕の爪";
        //public const string POOR_DIRTY_ANGEL_CONTRACT = @"ボロボロになった天使の契約書";
        //public const string POOR_JUNK_TARISMAN_FROZEN = @"ジャンク・タリスマン【凍結】";
        //public const string POOR_JUNK_TARISMAN_PARALYZE = @"ジャンク・タリスマン【麻痺】";
        //public const string POOR_JUNK_TARISMAN_STUN = @"ジャンク・タリスマン【スタン】";
        public const string COMMON_RED_MEDALLION = @"レッド・メダリオン";
        public const string COMMON_BLUE_MEDALLION = @"ブルー・メダリオン";
        public const string COMMON_PURPLE_MEDALLION = @"パープル・メダリオン";
        public const string COMMON_GREEN_MEDALLION = @"グリーン・メダリオン";
        public const string COMMON_YELLOW_MEDALLION = @"イエロー・メダリオン";
        public const string COMMON_SOCIETY_SYMBOL = @"ソサエティ・シンボル";
        public const string COMMON_SILVER_FEATHER_BRACELET = @"銀羽飾りの腕輪";
        public const string COMMON_BIRD_SONG_LUTE = @"バード・ソング・リュート";
        public const string COMMON_MAZE_CUBE = @"メイズ・キューブ";
        public const string COMMON_LIGHT_SERVANT = @"ライト・サーヴァント";
        public const string COMMON_SHADOW_SERVANT = @"シャドウ・サーヴァント";
        public const string COMMON_ROYAL_GUARD_RING = @"ロイヤル・ガード・リング";
        public const string COMMON_ELEMENTAL_GUARD_RING = @"エレメンタル・ガード・リング";
        public const string COMMON_HAYATE_GUARD_RING = @"ハヤテ・ガード・リング";
        public const string RARE_SPELL_COMPASS = @"詠唱の羅針盤";
        public const string RARE_SHADOW_BIBLE = @"闇のバイブル";
        public const string RARE_DETACHMENT_ORB = @"デタッチメント・オーブ";
        public const string RARE_BLIND_NEEDLE = @"盲目者の針";
        public const string RARE_CORE_ESSENCE_CHANNEL = @"コア・エッセンス・チャネル";
        public const string COMMON_MASTER_SWORD = @"マスター・ソード";
        public const string COMMON_MASTER_KNUCKLE = @"マスター・ナックル";
        public const string COMMON_MASTER_ROD = @"マスター・ロッド";
        public const string COMMON_MASTER_AXE = @"マスター・アックス";
        public const string COMMON_MASTER_ARMOR = @"マスター・アーマー";
        public const string COMMON_MASTER_CROSS = @"マスター・クロス";
        public const string COMMON_MASTER_ROBE = @"マスター・ローブ";
        public const string COMMON_MASTER_SHIELD = @"マスター・シールド";
        public const string RARE_ASTRAL_VOID_BLADE = @"アストラル・ヴォイド・ブレード";
        public const string RARE_VERDANT_SONIC_CLAW = @"ヴェルダント・ソニック・クロー";
        public const string RARE_PRISONER_BREAKING_AXE = @"プリズナー・ブレイキング・アックス";
        public const string RARE_INVISIBLE_STATE_ROD = @"インヴィジブル・ステイト・ロッド";
        public const string RARE_DOMINATION_BRAVE_ARMOR = @"ドミネーション・ブレイブ・アーマー";

        public const string COMMON_RED_FLOAT_STONE = @"赤の浮遊石";
        public const string COMMON_BLUE_FLOAT_STONE = @"青の浮遊石";
        public const string COMMON_PURPLE_FLOAT_STONE = @"紫の浮遊石";
        public const string COMMON_GREEN_FLOAT_STONE = @"緑の浮遊石";
        public const string COMMON_YELLOW_FLOAT_STONE = @"黄の浮遊石";
        public const string COMMON_SILVER_RING_1 = @"銀の腕輪【業火】";
        public const string COMMON_SILVER_RING_2 = @"銀の腕輪【津波】";
        public const string COMMON_SILVER_RING_3 = @"銀の腕輪【秋雨】";
        public const string COMMON_SILVER_RING_4 = @"銀の腕輪【熱波】";
        public const string COMMON_SILVER_RING_5 = @"銀の腕輪【雷鳴】";
        public const string COMMON_SILVER_RING_6 = @"銀の腕輪【吹雪】";
        public const string COMMON_SILVER_RING_7 = @"銀の腕輪【幻日】";
        public const string COMMON_SILVER_RING_8 = @"銀の腕輪【竜巻】";
        public const string COMMON_SILVER_RING_9 = @"銀の腕輪【主虹】";
        public const string COMMON_SILVER_RING_10 = @"銀の腕輪【陽炎】";
        public const string COMMON_MUKEI_SAKAZUKI = @"無形の盃";
        public const string COMMON_RAINBOW_TUBE = @"レインボー・チューブ";
        public const string COMMON_ELDER_PERSPECTIVE_GRASS = @"エルダー・パースペクティブ・グラス";
        public const string COMMON_DEVIL_SEALED_VASE = @"悪魔封じの壺";
        public const string COMMON_FLOATING_WHITE_BALL = @"フローティング・ホワイト・ボール";
        public const string RARE_SEAL_OF_ASSASSINATION = @"シール・オブ・アサシネーション";
        public const string RARE_EMBLEM_OF_VALKYRIE = @"エムブレム・オブ・ヴァルキリー";
        public const string RARE_EMBLEM_OF_HADES = @"エムブレム・オブ・ハデス";
        public const string RARE_SIHAIRYU_KATAUDE = @"支配竜の片腕";
        public const string RARE_OLD_TREE_SINKI = @"古代栄樹の芯木";
        public const string RARE_GALEWIND_IBUKI = @"ゲイル・ウィンドの息吹";
        public const string RARE_SIN_CRYSTAL_SOLID = @"シン・クリスタル・ソリッド";
        public const string RARE_EVERMIND_SENSE = @"エバー・マインド・センス";
        public const string RARE_DEVIL_SUMMONER_TOME = @"デビル・サモナーズ・トーム";
        public const string RARE_ANGEL_CONTRACT = @"天使の契約書";
        public const string RARE_ARCHANGEL_CONTRACT = @"大天使の契約書";
        public const string RARE_DARKNESS_COIN = @"暗黒の通貨";
        public const string RARE_SOUSUI_HIDENSYO = @"総帥の秘伝書";
        public const string RARE_MEEK_HIDENSYO = @"弱者の秘伝書";
        public const string RARE_JUKUTATUSYA_HIDENSYO = @"熟達者の秘伝書";
        public const string RARE_KYUUDOUSYA_HIDENSYO = @"求道者の秘伝書";
        public const string RARE_DANZAI_ANGEL_GOHU = @"断罪天使の護符";
        public const string EPIC_ETERNAL_HOMURA_RING = @"不死なる焔火のリング";

        public const string COMMON_INITIATE_SWORD = @"イニシエイト・ソード";
        public const string COMMON_BULLET_KNUCKLE = @"バレット・ナックル";
        public const string COMMON_KENTOUSI_SWORD = @"剣闘士の大剣";
        public const string COMMON_ELECTRO_ROD = @"エレクトロ・ロッド";
        public const string COMMON_FORTIFY_SCALE = @"フォーティファイ・スケイル";
        public const string COMMON_MURYOU_CROSS = @"無量の舞踏衣";
        public const string COMMON_COLORLESS_ROBE = @"カラレス・ローブ";
        public const string COMMON_LOGISTIC_SHIELD = @"ロジスティック・シールド";
        public const string RARE_ETHREAL_EDGE_SABRE = @"イスリアル・エッジ・サーベル";
        public const string RARE_SHINGETUEN_CLAW = @"深月淵の爪";
        public const string RARE_BLOODY_DIRTY_SCYTHE = @"ブラッディ・ダーティ・サイ";
        public const string RARE_ALL_ELEMENTAL_ROD = @"オール・エレメンタル・ロッド";
        public const string RARE_BLOOD_BLAZER_CROSS = @"ブラッド・ブレイザー・クロス";
        public const string RARE_DARK_ANGEL_ROBE = @"ダーク・エンジェル・ローブ";
        public const string RARE_MAJEST_HAZZARD_SHIELD = @"マジェスト・ハザード・シールド";
        public const string RARE_WHITE_DIAMOND_SHIELD = @"白泊色のダイヤ・シールド";
        public const string RARE_VAPOR_SOLID_SHIELD = @"ヴェイパー・ソリッド・シールド";
        #endregion

        #region "ダンジョン４階の宝箱"
        public const string COMMON_BLACK_SALT = @"黒く変色した岩状の塊";
        public const string COMMON_FEBL_ANIS = @"フェブル・アニス";
        public const string COMMON_SMORKY_HUNNY = @"スモーキー・ハニー";
        public const string COMMON_ANGEL_DUST = @"エンジェル・ダスト";
        public const string COMMON_SUN_TARAGON = @"サン・タラゴン";
        public const string COMMON_ECHO_BEAST_MEAT = @"エコービーストのもも肉";
        public const string COMMON_CHAOS_TONGUE = @"カオス・ワーデンの舌";
        public const string RARE_JOUKA_TANZOU = @"浄火の鍛造";
        public const string RARE_ESSENCE_OF_ADAMANTINE = @"エッセンス・オブ・アダマンティ";
        #endregion

        #region "５階のランダムドロップ"
        public const string COMMON_RED_CRYSTAL = @"真紅のクリスタル";
        public const string COMMON_BLUE_CRYSTAL = @"瑠璃のクリスタル";
        public const string COMMON_PURPLE_CRYSTAL = @"紫苑のクリスタル";
        public const string COMMON_GREEN_CRYSTAL = @"翡翠のクリスタル";
        public const string COMMON_YELLOW_CRYSTAL = @"琥珀のクリスタル";
        public const string COMMON_PLATINUM_RING_1 = @"白金の腕輪【白虎】";
        public const string COMMON_PLATINUM_RING_2 = @"白金の腕輪【ヴァルキリー】";
        public const string COMMON_PLATINUM_RING_3 = @"白金の腕輪【ナイトメア】";
        public const string COMMON_PLATINUM_RING_4 = @"白金の腕輪【ナラシンハ】";
        public const string COMMON_PLATINUM_RING_5 = @"白金の腕輪【朱雀】";
        public const string COMMON_PLATINUM_RING_6 = @"白金の腕輪【ウロボロス】";
        public const string COMMON_PLATINUM_RING_7 = @"白金の腕輪【ナインテイル】";
        public const string COMMON_PLATINUM_RING_8 = @"白金の腕輪【ベヒモス】";
        public const string COMMON_PLATINUM_RING_9 = @"白金の腕輪【青龍】";
        public const string COMMON_PLATINUM_RING_10 = @"白金の腕輪【玄武】";
        #endregion

        #region "ダンジョン現実世界の宝箱"
        public const string EPIC_GOLD_POTION = @"黄金樹の秘薬";
        public const string EPIC_OVER_SHIFTING = @"オーバーシフティング";
        #endregion

        #region "各階のボス撃破時"
        public const string EPIC_ORB_GROW_GREEN = @"新成緑の宝珠";
        public const string EPIC_ORB_GROUNDSEA_STAR = @"海星源の宝珠";
        public const string EPIC_ORB_SILENT_COLD_ICE = @"氷絶零の宝珠";
        public const string EPIC_ORB_DESTRUCT_FIRE = @"焔浄痕の宝珠"; // "闇厳焔の宝珠"
        #endregion

        #region "EPIC"
        // EPIC１
        public const string EPIC_RING_OF_OSCURETE = @"Ring of the Oscurete";
        public const string EPIC_MERGIZD_SOL_BLADE = @"Mergizd Sol Blade";
        // EPIC２
        public const string EPIC_GARVANDI_ADILORB = @"AdilOrb of the Garvandi";
        public const string EPIC_MAXCARN_X_BUSTER = @"Maxcarn the X-BUSTER";
        public const string EPIC_JUZA_ARESTINE_SLICER = @"Arestine-Slicer of Juza";
        // EPIC３
        public const string EPIC_SHEZL_MYSTIC_FORTUNE = @"Shezl the Mystic Fortune";
        public const string EPIC_FLOW_FUNNEL_OF_THE_ZVELDOZE = @"Flow Funnel of the Zveldose";
        public const string EPIC_MERGIZD_DAV_AGITATED_BLADE = @"Mergizd DAV-Agitated Blade";
        // EPIC４
        public const string EPIC_EZEKRIEL_ARMOR_SIGIL = @"Ezekriel the Armor of Sigil";
        public const string EPIC_SHEZL_THE_MIRAGE_LANCER = @"Shezl the Mirage Lancer";
        public const string EPIC_JUZA_THE_PHANTASMAL_CLAW = @"Juza the Phantasmal Claw";
        public const string EPIC_ADILRING_OF_BLUE_BURN = @"AdilRing of the Blue Burn";
        #endregion

        // ジェム
        // ストーン
        // ジュエル
        // フランベルジュ
        #region "成長剤"
        // 成長剤（１階）
        public const string GROWTH_LIQUID_STRENGTH = @"成長リキッド【力】";
        public const string GROWTH_LIQUID_AGILITY = @"成長リキッド【技】";
        public const string GROWTH_LIQUID_INTELLIGENCE = @"成長リキッド【知】";
        public const string GROWTH_LIQUID_STAMINA = @"成長リキッド【体】";
        public const string GROWTH_LIQUID_MIND = @"成長リキッド【心】";
        // 成長剤（２階）
        public const string GROWTH_LIQUID2_STRENGTH = @"成長リキッドⅡ【力】";
        public const string GROWTH_LIQUID2_AGILITY = @"成長リキッドⅡ【技】";
        public const string GROWTH_LIQUID2_INTELLIGENCE = @"成長リキッドⅡ【知】";
        public const string GROWTH_LIQUID2_STAMINA = @"成長リキッドⅡ【体】";
        public const string GROWTH_LIQUID2_MIND = @"成長リキッドⅡ【心】";
        // 成長剤（３階）
        public const string GROWTH_LIQUID3_STRENGTH = @"成長リキッドⅢ【力】";
        public const string GROWTH_LIQUID3_AGILITY = @"成長リキッドⅢ【技】";
        public const string GROWTH_LIQUID3_INTELLIGENCE = @"成長リキッドⅢ【知】";
        public const string GROWTH_LIQUID3_STAMINA = @"成長リキッドⅢ【体】";
        public const string GROWTH_LIQUID3_MIND = @"成長リキッドⅢ【心】";
        // 成長剤（４階）
        public const string GROWTH_LIQUID4_STRENGTH = @"成長リキッドⅣ【力】";
        public const string GROWTH_LIQUID4_AGILITY = @"成長リキッドⅣ【技】";
        public const string GROWTH_LIQUID4_INTELLIGENCE = @"成長リキッドⅣ【知】";
        public const string GROWTH_LIQUID4_STAMINA = @"成長リキッドⅣ【体】";
        public const string GROWTH_LIQUID4_MIND = @"成長リキッドⅣ【心】";
        // 成長剤（５階）
        public const string GROWTH_LIQUID5_STRENGTH = @"成長リキッドⅤ【力】";
        public const string GROWTH_LIQUID5_AGILITY = @"成長リキッドⅤ【技】";
        public const string GROWTH_LIQUID5_INTELLIGENCE = @"成長リキッドⅤ【知】";
        public const string GROWTH_LIQUID5_STAMINA = @"成長リキッドⅤ【体】";
        public const string GROWTH_LIQUID5_MIND = @"成長リキッドⅤ【心】";
        #endregion

        #region "無価値アイテム"
        public const string POOR_BLACK_MATERIAL = @"ブラックマテリアル";
        public const string POOR_BLACK_MATERIAL2 = @"ブラックマテリアル【改】";
        public const string POOR_BLACK_MATERIAL3 = @"ブラックマテリアル【密】";
        public const string POOR_BLACK_MATERIAL4 = @"ブラックマテリアル【試】";
        public const string POOR_BLACK_MATERIAL5 = @"ブラックマテリアル【還】";
        #endregion

        public const string RARE_SEAL_AQUA_FIRE = @"シールオブアクア＆ファイア";

        #region "後編、１階の素材系ドロップアイテム"
        public const string COMMON_BEATLE_TOGATTA_TUNO = @"ビートルの尖った角";
        public const string COMMON_HENSYOKU_KUKI = @"変色した茎";
        public const string COMMON_GREEN_SIKISO = @"緑化色素";
        public const string COMMON_MANTIS_TAIEKI = @"マンティスの体液";
        public const string COMMON_WARM_NO_KOUKAKU = @"ワームの甲殻";
        public const string COMMON_MANDORAGORA_ROOT = @"マンドラゴラの根";

        public const string COMMON_SUN_LEAF = @"太陽の葉";
        public const string COMMON_INAGO = @"蝗";
        public const string COMMON_SPIDER_SILK = @"スパイダーシルク";
        public const string COMMON_ANT_ESSENCE = @"アントのエキス";
        public const string COMMON_YELLOW_MATERIAL = @"イエロー・マテリアル";
        public const string COMMON_ALRAUNE_KAHUN = @"アルラウネの花粉";
        public const string RARE_MARY_KISS = @"マリーキッス";

        public const string COMMON_RABBIT_KEGAWA = @"ウサギの毛皮";
        public const string COMMON_RABBIT_MEAT = @"ウサギの肉";
        public const string COMMON_TAKA_FETHER = @"鷹の白羽";
        public const string COMMON_ASH_EGG = @"薄灰色の卵";
        public const string COMMON_SNEAK_UROKO = @"ヘビの鱗";
        public const string COMMON_PLANTNOID_SEED = @"プラントノイドの種";
        public const string COMMON_TOGE_HAETA_SYOKUSYU = @"刺の生えた触手";
        public const string RARE_HYUI_SEED = @"ヒューイの種";

        public const string COMMON_OOKAMI_FANG = @"狼の牙";
        public const string COMMON_BRILLIANT_RINPUN = @"輝きの燐粉";
        public const string COMMON_MIST_CRYSTAL = @"霧の結晶";
        public const string COMMON_DRYAD_RINPUN = @"ドライアドの鱗粉";
        public const string COMMON_RED_HOUSI = @"赤い胞子";
        public const string RARE_MOSSGREEN_EKISU = @"モスグリーンのエキス";
        #endregion

        #region "後編、２階、素材ドロップ"
        public const string COMMON_DAGGERFISH_UROKO = @"牙魚の鱗";
        public const string COMMON_SIPPUU_HIRE = @"疾魚のヒレ";
        public const string COMMON_WHITE_MAGATAMA = @"白の勾玉";
        public const string COMMON_BLUE_MAGATAMA = @"青の勾玉";
        public const string COMMON_KURIONE_ZOUMOTU = @"クリオネの臓物";
        public const string COMMON_BLUEWHITE_SHARP_TOGE = @"青白の鋭いトゲ";
        public const string RARE_TRANSPARENT_POWDER = @"透明なパウダー";

        public const string COMMON_RENEW_AKAMI = @"新鮮な赤身";
        public const string COMMON_SEA_WASI_KUTIBASI = @"海鷲のくちばし";
        public const string COMMON_WASI_BLUE_FEATHER = @"鷲の青羽";
        public const string COMMON_BRIGHT_GESO = @"光るゲソ";
        public const string COMMON_GANGAME_EGG = @"頑亀の卵";
        public const string RARE_JOE_TONGUE = @"ジョーの舌";
        public const string RARE_JOE_ARM = @"ジョーの腕";
        public const string RARE_JOE_LEG = @"ジョーの足";

        public const string COMMON_SOFT_BIG_HIRE = @"柔らかい大ヒレ";
        public const string COMMON_PURE_WHITE_BIGEYE = @"真っ白な大目玉";
        public const string COMMON_GOTUGOTU_KARA = @"ゴツゴツした殻";
        public const string COMMON_SAME_NANKOTSU = @"サメの軟骨";
        public const string COMMON_HALF_TRANSPARENT_ROCK_ASH = @"半透明の石灰";
        public const string RARE_SEKIKASSYOKU_HASAMI = @"赤褐色のハサミ";

        public const string COMMON_KOUSITUKA_MATERIAL = @"硬質化素材";
        public const string COMMON_NANAIRO_SYOKUSYU = @"七色の触手";
        public const string COMMON_PUREWHITE_KIMO = @"真っ白なキモ";
        public const string COMMON_AOSAME_KENSHI = @"青鮫の剣歯";
        public const string COMMON_AOSAME_UROKO = @"青鮫の鱗";
        public const string COMMON_EIGHTEIGHT_KUROSUMI = @"エイト・エイトの黒墨";
        public const string COMMON_EIGHTEIGHT_KYUUBAN = @"エイト・エイトの吸盤";
        #endregion

        #region "後編、３階、素材ドロップ"
        public const string COMMON_ORC_MOMONIKU = @"オークのもも肉";
        public const string COMMON_SNOW_CAT_KEGAWA = @"雪猫の毛皮";
        public const string COMMON_BIG_HIZUME = @"大きな蹄";
        public const string COMMON_FAIRY_POWDER = @"妖精パウダー";
        public const string RARE_GRIFFIN_WHITE_FEATHER = @"グリフィンの白い羽";

        public const string COMMON_GOTUGOTU_KONBOU = @"ゴツゴツした棍棒";
        public const string COMMON_LIZARD_UROKO = @"リザードの鱗";
        public const string COMMON_EMBLEM_OF_PENGUIN = @"エムブレム・オブ・ペンギン";
        public const string COMMON_KINKIN_ICE = @"キンキンに冷えた氷";
        public const string COMMON_SHARPNESS_TIGER_TOOTH = @"鋭く尖った虎牙";
        public const string RARE_BEAR_CLAW_KAKERA = @"ベアクローの欠片";

        public const string COMMON_TOUMEI_SNOW_CRYSTAL = @"透明な雪結晶";
        public const string COMMON_WHITE_AZARASHI_MEAT = @"白アザラシの肉";
        public const string COMMON_CENTAURUS_LEATHER = @"ケンタウルスの皮";
        public const string COMMON_ARGONIAN_PURPLE_UROKO = @"アルゴニアンの紫鱗";
        public const string COMMON_BLUE_DANGAN_KAKERA = @"蒼い弾丸の欠片";
        public const string RARE_PURE_CRYSTAL = @"ピュア・クリスタル";

        public const string COMMON_WOLF_KEGAWA = @"ウルフの毛皮";
        public const string COMMON_FROZEN_HEART = @"凍結した心臓";
        public const string COMMON_CLAW_HEART = @"グリズリーの心臓";
        public const string COMMON_ESSENCE_OF_WIND = @"エッセンス・オヴ・ウィンド";
        public const string RARE_TUNDRA_DEER_HORN = @"古代ツンドラ鹿の角";
        #endregion

        #region "後編、４階、素材ドロップ"
        public const string COMMON_HUNTER_SEVEN_TOOL = @"ハンターの七つ道具";
        public const string COMMON_BEAST_KEGAWA = @"猛獣の毛皮";
        public const string RARE_BLOOD_DAGGER_KAKERA = @"血塗られたダガーの破片";
        public const string COMMON_SABI_BUGU = @"錆付いたガラクタ武具";
        public const string RARE_MEPHISTO_BLACKLIGHT = @"メフィストの黒い灯";

        public const string COMMON_SEEKER_HEAD = @"シーカーの頭蓋骨";
        public const string RARE_ESSENCE_OF_DARK = @"エッセンス・オブ・ダーク";
        public const string COMMON_EXECUTIONER_ROBE = @"執行人の汚れたローブ";
        public const string COMMON_NEMESIS_ESSENCE = @"ネメシス・エッセンス";
        public const string RARE_MASTERBLADE_KAKERA = @"マスターブレイドの破片";
        public const string RARE_MASTERBLADE_FIRE = @"マスターブレイドの残り火";
        public const string COMMON_GREAT_JEWELCROWN = @"豪華なジュエルクラウン";

        public const string RARE_ESSENCE_OF_SHINE = @"エッセンス・オブ・シャイン";
        public const string RARE_DEMON_HORN = @"デーモンホーン";
        public const string COMMON_KUMITATE_TENBIN = @"組み立て素材　天秤";
        public const string COMMON_KUMITATE_TENBIN_DOU = @"組み立て素材　天分銅";
        public const string COMMON_KUMITATE_TENBIN_BOU = @"組み立て素材　天秤棒";
        public const string COMMON_WYVERN_BONE = @"ワイバーン・ボーン";
        public const string RARE_ESSENCE_OF_FLAME = @"エッセンス・オブ・フレイム";
        public const string RARE_BLACK_SEAL_IMPRESSION = @"黒の印鑑";

        public const string COMMON_ONRYOU_HAKO = @"怨霊箱";
        public const string RARE_ANGEL_SILK = @"天使のシルク";
        public const string RARE_CHAOS_SIZUKU = @"混沌の雫";
        public const string RARE_DREAD_EXTRACT = @"ドレッド・エキス";
        public const string RARE_DOOMBRINGER_TUKA = @"ドゥームブリンガーの柄";
        public const string RARE_DOOMBRINGER_KAKERA = @"ドゥームブリンガーの欠片";
        #endregion

        #region "後編、ガンツの武具屋１階"
        // 初版
        public const string COMMON_BRONZE_SWORD = @"ブロンズ・ソード";
        public const string COMMON_FIT_ARMOR = @"フィット・アーマー";
        public const string COMMON_LIGHT_SHIELD = @"ライト・シールド";
        public const string COMMON_FINE_SWORD_1 = @"ファイン・ソード【＋１】";
        public const string COMMON_FINE_ARMOR_1 = @"ファイン・アーマー【＋１】";
        public const string COMMON_FINE_SHIELD_1 = @"ファイン・シールド【＋１】";
        public const string COMMON_LIGHT_CLAW_1 = @"ライト・クロー【＋１】";
        public const string COMMON_KASHI_ROD_1 = @"樫の杖【＋１】";
        public const string COMMON_LETHER_CLOTHING_1 = @"レザー・クロス【＋１】";
        public const string COMMON_BASTARD_SWORD_1 = @"バスタード・ソード【＋１】";
        public const string COMMON_IRON_SWORD = @"アイアン・ソード【＋２】";
        public const string COMMON_KUSARI_KATABIRA = @"鎖かたびら【＋１】";
        public const string RARE_FLOWER_WAND = @"フラワー・ワンド";
        public const string COMMON_SUPERIOR_CROSS = @"スペリオル・クロス";
        public const string COMMON_SILK_ROBE = @"シルク・ローブ";
        public const string COMMON_SURVIVAL_CLAW = @"サバイバル・クロー";
        public const string COMMON_BLACER_OF_SYOJIN = @"精進のブレスレット";
        public const string COMMON_ZIAI_PENDANT = @"慈愛のペンダント";
        // 合成
        public const string COMMON_KOUKAKU_ARMOR = @"甲殻の鎧";
        public const string COMMON_SISSO_TUKEHANE = @"質素な付け羽";
        public const string RARE_WAR_WOLF_BLADE = @"ワーウルフ・ブレード";
        public const string COMMON_BLUE_COPPER_ARMOR_KAI = @"青銅の鎧【改】";
        public const string COMMON_RABBIT_SHOES = @"ラビット・シューズ";
        public const string RARE_MISTSCALE_SHIELD = @"ミストスケイル・シールド";
        #endregion
        #region "後編、ガンツの武具屋２階"
        // ２階
        // 初版
        public const string COMMON_SMART_SWORD_2 = @"スマート・ソード【＋２】";
        public const string COMMON_SMART_PLATE_2 = @"スマート・プレート【＋２】";
        public const string COMMON_SMART_SHIELD_2 = @"スマート・シールド【＋２】";
        public const string COMMON_RAUGE_SWORD_2 = @"ラウジェ・ソード【＋２】";
        public const string COMMON_SMART_CLAW_2 = @"スマート・クロー【＋２】";
        public const string COMMON_SMART_ROD_2 = @"スマート・ロッド【＋２】";
        public const string COMMON_SMART_CLOTHING_2 = @"スマート・クロス【＋２】";
        public const string COMMON_SMART_ROBE_2 = @"スマート・ローブ【＋２】";
        public const string COMMON_STEEL_SWORD = @"スチール・ソード【＋３】";
        public const string COMMON_FACILITY_CLAW = @"ファシリティ・クロー【＋３】";
        public const string COMMON_MIX_HINOKI_ROD = @"合成檜の杖";
        public const string COMMON_BERSERKER_PLATE = @"バーサーカープレート";
        public const string COMMON_BRIGHTNESS_ROBE = @"ブライトネス・ローブ";
        public const string RARE_WILD_HEART_SPADE = @"ワイルド・ハート【スペード】";

        // 合成
        public const string COMMON_WHITE_WAVE_RING = @"白波の指輪";
        public const string COMMON_NEEDLE_FEATHER = @"ニードルフェザー";
        public const string COMMON_KOUSHITU_ORB = @"硬質のオーブ";
        public const string RARE_RED_ARM_BLADE = @"レッドアームブレード";
        public const string RARE_STRONG_SERPENT_CLAW = @"強靭なサーペントクロー";
        public const string RARE_STRONG_SERPENT_SHIELD = @"強靭なサーペントシールド";
        #endregion
        #region "後編、ガンツの武具屋３階"
        // 初版
        public const string COMMON_EXCELLENT_SWORD_3 = @"エクセレント・ソード【＋３】";
        public const string COMMON_EXCELLENT_KNUCKLE_3 = @"エクセレント・ナックル【＋３】";
        public const string COMMON_EXCELLENT_ROD_3 = @"エクセレント・ロッド【＋３】";
        public const string COMMON_EXCELLENT_BUSTER_3 = @"エクセレント・バスター【＋３】";
        public const string COMMON_EXCELLENT_ARMOR_3 = @"エクセレント・アーマー【＋３】";
        public const string COMMON_EXCELLENT_CROSS_3 = @"エクセレント・クロス【＋３】";
        public const string COMMON_EXCELLENT_ROBE_3 = @"エクセレント・ローブ【＋３】";
        public const string COMMON_EXCELLENT_SHIELD_3 = @"エクセレント・シールド【＋３】";
        public const string COMMON_WINTERS_HORN = @"ウィンターズ・ホーン";
        public const string RARE_CHILL_BONE_SHIELD = @"チル・ボーン・シールド";
        // 合成
        public const string COMMON_STEEL_BLADE = @"スチール・ブレード【＋４】";
        public const string COMMON_SNOW_GUARD = @"スノーガード";
        public const string COMMON_LIZARDSCALE_ARMOR = @"リザードスケイル・アーマー【＋４】";
        public const string COMMON_PENGUIN_OF_PENGUIN = @"ペンギン・オブ・ペンギン";
        public const string COMMON_ARGNIAN_TUNIC = @"アルゴニアン・チュニック";
        public const string COMMON_ANIMAL_FUR_CROSS = @"アニマル・ファークロス";
        public const string RARE_SPLASH_BARE_CLAW = @"スプラッシュ・ベアクロー";
        public const string EPIC_GATO_HAWL_OF_GREAT = @"ガトゥ・ハウル・オブ・グレイト";
        #endregion
        #region "後編、ガンツの武具屋４階"
        // 初版
        public const string COMMON_MASTER_SWORD_4 = @"マスター・ソード【＋４】";
        public const string COMMON_MASTER_KNUCKLE_4 = @"マスター・ナックル【＋４】";
        public const string COMMON_MASTER_ROD_4 = @"マスター・ロッド【＋４】";
        public const string COMMON_MASTER_AXE_4 = @"マスター・アックス【＋４】";
        public const string COMMON_MASTER_ARMOR_4 = @"マスター・アーマー【＋４】";
        public const string COMMON_MASTER_CROSS_4 = @"マスター・クロス【＋４】";
        public const string COMMON_MASTER_ROBE_4 = @"マスター・ローブ【＋４】";
        public const string COMMON_MASTER_SHIELD_4 = @"マスター・シールド【＋４】";
        public const string RARE_SUPERIOR_CHOSEN_ROD = @"スペリオル・チューズン・ロッド";
        public const string RARE_TYOU_KOU_SWORD = @"超硬の剣【＋６】";
        public const string RARE_TYOU_KOU_ARMOR = @"超硬の鎧【＋６】";
        public const string RARE_TYOU_KOU_SHIELD = @"超硬の盾【＋６】";
        public const string RARE_WHITE_GOLD_CROSS = @"ホワイト・ゴールド・クロス";
        // 合成
        public const string RARE_HUNTERS_EYE = @"ハンターズ・アイ";
        public const string RARE_ONEHUNDRED_BUTOUGI = @"百獣皮の舞踏衣";
        public const string RARE_DARKANGEL_CROSS = @"ダークエンジェル・クロス";
        public const string RARE_DEVIL_KILLER = @"デビル・キラー";
        public const string RARE_TRUERED_MASTER_BLADE = @"真紅炎・マスターブレイド";
        public const string RARE_VOID_HYMNSONIA = @"ヴォイド・ヒムソニア";
        public const string RARE_SEAL_OF_BALANCE = @"シール・オブ・バランス";
        public const string RARE_DOOMBRINGER = @"ドゥーム・ブリンガー";
        public const string EPIC_MEIKOU_DOOMBRINGER = @"冥光・ドゥームブリンガー";
        #endregion
        #region "後編、ガンツの武具屋５階"
        #endregion
        #region "真実世界"
        #endregion

        #region "後編、ラナのポーション店１階"
        // ポーション系 前編からあるのも混じっているが、後編ではここで宣言
        // 初版
        public const string POOR_SMALL_RED_POTION = @"小さい赤ポーション";
        public const string POOR_SMALL_BLUE_POTION = @"小さい青ポーション";
        public const string POOR_SMALL_GREEN_POTION = @"小さい緑ポーション";
        public const string POOR_POTION_CURE_POISON = @"解毒薬";
        public const string COMMON_REVIVE_POTION_MINI = @"リヴァイヴポーション・ミニ";
        public const string RARE_REVIVE_POTION = @"リヴァイヴポーション";

        // 合成
        public const string COMMON_POTION_NATURALIZE = @"ナチュラライズ・ポーション";
        public const string COMMON_POTION_RESIST_FIRE = @"耐熱ポーション";
        public const string COMMON_POTION_MAGIC_SEAL = @"マジック・シール薬";
        public const string COMMON_POTION_ATTACK_SEAL = @"アタック・シール薬";
        public const string COMMON_POTION_CURE_BLIND = @"キュア・ブラインド";
        public const string RARE_POTION_MOSSGREEN_DREAM = @"モスグリーン・ドリーム";
        public const string RARE_DRYAD_SAGE_POTION = @"ドライアドの秘薬";
        #endregion
        #region "後編、ラナのポーション店２階"
        // ２階
        // 初版
        public const string COMMON_NORMAL_RED_POTION = @"赤ポーション【通常】";
        public const string COMMON_NORMAL_BLUE_POTION = @"青ポーション【通常】";
        public const string COMMON_NORMAL_GREEN_POTION = @"緑ポーション【通常】";
        public const string COMMON_RESIST_POISON = @"耐解毒ポーション"; // ダンジョン２階進む所でラナより景品
        // 合成
        public const string COMMON_POTION_OVER_GROWTH = @"オーバー・グロース";
        public const string COMMON_POTION_RAINBOW_IMPACT = @"レインボー・インパクト";
        public const string COMMON_POTION_BLACK_GAST = @"ブラック・ガスト";
        public const string COMMON_SOUKAI_DRINK_SS = @"爽快ドリンク【Ｓ＆Ｓ】";
        public const string COMMON_TUUKAI_DRINK_DD = @"痛快ドリンク【Ｄ＆Ｄ】";
        #endregion
        #region "後編、ラナのポーション店３階"
        // ３階
        // 初版
        public const string COMMON_LARGE_RED_POTION = @"赤ポーション【大】";
        public const string COMMON_LARGE_BLUE_POTION = @"青ポーション【大】";
        public const string COMMON_LARGE_GREEN_POTION = @"緑ポーション【大】";
        // 合成
        public const string COMMON_FAIRY_BREATH = @"フェアリー・ブレス";
        public const string COMMON_HEART_ACCELERATION = @"ハート・アクセラレーション";
        public const string RARE_SAGE_POTION_MINI = @"賢者の秘薬【ミニ】";
        #endregion
        #region "後編、ラナのポーション店４階"
        // ４階
        // 初版
        public const string COMMON_HUGE_RED_POTION = @"赤ポーション【特大】";
        public const string COMMON_HUGE_BLUE_POTION = @"青ポーション【特大】";
        public const string COMMON_HUGE_GREEN_POTION = @"緑ポーション【特大】";
        // 合成
        public const string RARE_POWER_SURGE = @"パワー・サージ";
        public const string RARE_ELEMENTAL_SEAL = @"エレメンタル・シール";
        public const string RARE_GENSEI_MAGIC_BOTTLE = @"源正の魔力剤";
        public const string RARE_GENSEI_TAIMA_KUSURI = @"源正の退魔薬";
        public const string RARE_MIND_ILLUSION = @"マインド・イリュージョン";
        public const string RARE_SHINING_AETHER = @"シャイニング・エーテル";
        public const string RARE_ZETTAI_STAMINAUP = @"確約の体力増強剤";
        public const string RARE_BLACK_ELIXIR = @"ブラック・エリクシール";
        public const string RARE_ZEPHER_BREATH = @"ゼフィール・ブレス";
        public const string RARE_COLORLESS_ANTIDOTE = @"カラレス・アンチドーテ";

        #endregion
        #region "後編、ラナのポーション店５階"
        // ５階
        // 初版
        public const string COMMON_GORGEOUS_RED_POTION = @"赤ポーション【豪華版】";
        public const string COMMON_GORGEOUS_BLUE_POTION = @"青ポーション【豪華版】";
        public const string COMMON_GORGEOUS_GREEN_POTION = @"緑ポーション【豪華版】";
        #endregion
        #region "真実世界"
        public const string RARE_PERFECT_RED_POTION = @"赤ポーション【完全版】";
        public const string RARE_PERFECT_BLUE_POTION = @"青ポーション【完全版】";
        public const string RARE_PERFECT_GREEN_POTION = @"緑ポーション【完全版】";
        #endregion
        #endregion
        #endregion
    }
}