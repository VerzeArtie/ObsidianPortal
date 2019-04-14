using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

namespace ObsidianPortal
{
    public class Item
    {
        public enum ItemType
        {
            None,
            Weapon_Light,
            Weapon_Middle,
            Weapon_Heavy,
            Weapon_TwoHand,
            Weapon_Rod,
            Weapon_Bow,
            Weapon_Lance,
            Weapon_Axe,
            Weapon_Staff,
            Weapon_Book,
            Weapon_Shield,
            Weapon_Orb,
            Armor_Light,
            Armor_Middle,
            Armor_Heavy,
            Shield,
            Accessory,
            Material_Equip,
            Material_Potion,
            Material_Food,
            Use_Potion,
            Use_Item,
            Use_BlueOrb, // add unity
            Useless,
        }

        public enum Equipable
        {
            All,
            Ein,
            Lana,
            Verze,
            Ol, // 後編追加
            Kahl, // 後編追加
        }
        public enum RareLevel
        {
            Poor,
            Common,
            Rare,
            Epic,
            Legendary,
        }

        public Item(string createName)
        {
            this.ItemName = createName;

            switch (createName)
            {

                #region "ポーション系"
                case FIX.POOR_SMALL_RED_POTION:
                    description = "小さめに作られたライフ回復用の薬。回復量２００～３５０";
                    PhysicalAttackMinValue = 200;
                    PhysicalAttackMaxValue = 350;
                    cost = 100;
                    AdditionalDescription(ItemType.Use_Potion);
                    rareLevel = RareLevel.Common;
                    limitValue = USING_ITEM_STACK_SIZE;
                    break;
                case "普通の赤ポーション":
                    description = "標準的な大きさで作られたライフ回復用の薬。回復量１４０～２１０";
                    PhysicalAttackMinValue = 140;
                    PhysicalAttackMaxValue = 210;
                    cost = 500;
                    AdditionalDescription(ItemType.Use_Potion);
                    rareLevel = RareLevel.Common;
                    limitValue = USING_ITEM_STACK_SIZE;
                    break;
                case "大きな赤ポーション":
                    description = "比較的大きめに作られたライフ回復用の薬。回復量３３０～４５０";
                    PhysicalAttackMinValue = 330;
                    PhysicalAttackMaxValue = 450;
                    cost = 2500;
                    AdditionalDescription(ItemType.Use_Potion);
                    rareLevel = RareLevel.Common;
                    limitValue = USING_ITEM_STACK_SIZE;
                    break;
                case "特大赤ポーション":
                    description = "特大サイズで作られたライフ回復用の薬。回復量８１０～１０２０";
                    PhysicalAttackMinValue = 810;
                    PhysicalAttackMaxValue = 1020;
                    cost = 7000;
                    AdditionalDescription(ItemType.Use_Potion);
                    rareLevel = RareLevel.Common;
                    limitValue = USING_ITEM_STACK_SIZE;
                    break;
                case "豪華な赤ポーション":
                    description = "豪華な大瓶で作られたライフ回復用の薬。回復量１５００～２５００";
                    PhysicalAttackMinValue = 1500;
                    PhysicalAttackMaxValue = 2500;
                    cost = 22000;
                    AdditionalDescription(ItemType.Use_Potion);
                    rareLevel = RareLevel.Common;
                    limitValue = USING_ITEM_STACK_SIZE;
                    break;

                case "小さい青ポーション":
                    description = "小さめに作られたマナ回復用の薬。回復量５０～８０";
                    PhysicalAttackMinValue = 50;
                    PhysicalAttackMaxValue = 80;
                    cost = 100;
                    AdditionalDescription(ItemType.Use_Potion);
                    rareLevel = RareLevel.Common;
                    limitValue = USING_ITEM_STACK_SIZE;
                    break;
                case "普通の青ポーション":
                    description = "標準的な大きさで作られたマナ回復用の薬。回復量１４０～２１０";
                    PhysicalAttackMinValue = 140;
                    PhysicalAttackMaxValue = 210;
                    cost = 500;
                    AdditionalDescription(ItemType.Use_Potion);
                    rareLevel = RareLevel.Common;
                    limitValue = USING_ITEM_STACK_SIZE;
                    break;
                case "大きな青ポーション":
                    description = "比較的大きめに作られたマナ回復用の薬。回復量３３０～４５０";
                    PhysicalAttackMinValue = 330;
                    PhysicalAttackMaxValue = 450;
                    cost = 2500;
                    AdditionalDescription(ItemType.Use_Potion);
                    rareLevel = RareLevel.Common;
                    limitValue = USING_ITEM_STACK_SIZE;
                    break;
                case "特大青ポーション":
                    description = "特大サイズで作られたマナ回復用の薬。回復量８１０～１０２０";
                    PhysicalAttackMinValue = 810;
                    PhysicalAttackMaxValue = 1020;
                    cost = 7000;
                    AdditionalDescription(ItemType.Use_Potion);
                    rareLevel = RareLevel.Common;
                    limitValue = USING_ITEM_STACK_SIZE;
                    break;
                case "豪華な青ポーション":
                    description = "豪華な大瓶で作られたマナ回復用の薬。回復量１５００～２５００";
                    PhysicalAttackMinValue = 1500;
                    PhysicalAttackMaxValue = 2500;
                    cost = 22000;
                    AdditionalDescription(ItemType.Use_Potion);
                    rareLevel = RareLevel.Common;
                    limitValue = USING_ITEM_STACK_SIZE;
                    break;

                case "名前がとても長いわりにはまったく役に立たず、何の効果も発揮しない役立たずであるにもかかわらずデコレーションが長い超豪華なスーパーミラクルポーション":
                    description = "デバッグ用。回復量０～１";
                    PhysicalAttackMinValue = 0;
                    PhysicalAttackMaxValue = 1;
                    cost = 99999999;
                    AdditionalDescription(ItemType.Use_Potion);
                    rareLevel = RareLevel.Poor;
                    limitValue = USING_ITEM_STACK_SIZE;
                    break;

                case "リーベストランクポーション":
                    description = "巷で話題となった毒薬（？）。飲まされた相手は誘惑にかられてしまう。　戦闘中専用。「誘惑」を付与";
                    PhysicalAttackMinValue = 100;
                    PhysicalAttackMaxValue = 100;
                    cost = 2000;
                    AdditionalDescription(ItemType.Use_Potion);
                    rareLevel = RareLevel.Common;
                    limitValue = USING_ITEM_STACK_SIZE;
                    break;

                case "リヴァイヴポーション":
                    description = "毎日１度だけ、ダンジョン内で死亡したパーティメンバーを復活させる薬。";
                    PhysicalAttackMinValue = 0;
                    PhysicalAttackMaxValue = 0;
                    cost = 40000;
                    AdditionalDescription(ItemType.Use_Potion);
                    rareLevel = RareLevel.Rare;
                    limitValue = RARE_EPIC_ITEM_STACK_SIZE;
                    break;

                case FIX.EPIC_GOLD_POTION:
                    description = "ライフ／マナ／スキルをすべて、全回復する。";
                    cost = 0;
                    AdditionalDescription(ItemType.Use_Potion);
                    rareLevel = RareLevel.Epic;
                    limitValue = RARE_EPIC_ITEM_STACK_SIZE;
                    break;
                #endregion
                #region "前編：ダンジョン宝・ガンツ武具屋アイテム"
                case "ブルーマテリアル": // １階アイテム
                    description = "純青色の立方体。";
                    cost = 1000;
                    AdditionalDescription(ItemType.None);
                    rareLevel = RareLevel.Common;
                    limitValue = OTHER_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_CHARM_OF_FIRE_ANGEL: // １階アイテム
                    description = "炎を司る業を背負った天使の護符。力＋３、体＋６、火耐性１５";
                    ResistFire = 15;
                    buffUpStrength = 3;
                    BuffUpStamina = 6;
                    cost = 350;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case "チャクラオーブ": // １階アイテム
                    description = "精神チャクラを映し出すオーブ。知＋５";
                    BuffUpIntelligence = 5;
                    cost = 400;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case "些細なパワーリング": // ガンツの武具屋販売（ダンジョン１階）
                    description = "装着者のやる気を引き立たせるリング。力＋５";
                    BuffUpStrength = 5;
                    cost = 500;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case "鷹の刻印": // ２階アイテム
                    description = "鷹の姿が描かれている刻印。力＋１０　知＋１０";
                    BuffUpStrength = 10;
                    BuffUpIntelligence = 10;
                    cost = 2900;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case "神聖水": // ２階アイテム
                    description = "約束された回復薬。毎日１度だけライフ、スキル、マナをそれぞれ30%回復。";
                    cost = 5200;
                    AdditionalDescription(ItemType.Use_Potion);
                    rareLevel = RareLevel.Rare;
                    limitValue = RARE_EPIC_ITEM_STACK_SIZE;
                    break;
                case "身かわしのマント": // ２階アイテム
                    description = "本人の意思に関係なく、極まれに敵の攻撃を避けるマント。";
                    PhysicalAttackMinValue = 30;
                    PhysicalAttackMaxValue = 30;
                    cost = 1700;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case "紺碧のスターエムブレム": // ガンツの武具屋販売（ダンジョン２階）
                    description = "星型に紺碧のイメージを乗せたエムブレム。知＋１０、心＋１０";
                    buffUpIntelligence = 10;
                    buffUpMind = 10;
                    cost = 2800;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case "闘魂バンド": // ガンツの武具屋販売（ダンジョン２階）
                    description = "装着者のやる気を引き立たせるバンド。力＋１８";
                    BuffUpStrength = 18;
                    cost = 4200;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case "レッドマテリアル": // ３階アイテム
                    description = "純赤色の立方体。";
                    cost = 10000;
                    AdditionalDescription(ItemType.None);
                    rareLevel = RareLevel.Common;
                    limitValue = OTHER_ITEM_STACK_SIZE;
                    break;
                case "ライオンハート": // ３階アイテム
                    description = "百獣の王の力が宿されているペンダント。腕＋２５、技＋２５";
                    buffUpStrength = 25;
                    BuffUpAgility = 25;
                    cost = 5600;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case "オーガの腕章": // ３階アイテム
                    description = "オーガの体力が湧き出る腕章。腕＋２０、体＋１２";
                    buffUpStrength = 20;
                    buffUpStamina = 12;
                    cost = 6600;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case "鋼鉄の石像": // ３階アイテム
                    description = "鋼鉄の精神が宿っている石像。たまにスタン効果を防いだり、スタン状態から復帰する。";
                    PhysicalAttackMinValue = 30;
                    PhysicalAttackMaxValue = 30;
                    cost = 4800;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Rare;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case "ファラ様信仰のシール": // ３階アイテム
                    description = "王妃ファラ様への信仰（妄信）の証を示すシール。心＋５０";
                    buffUpMind = 50;
                    cost = 7600;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case "プレート・アーマー": // ３階アイテム
                    description = "強い鋼素材を元にして、折り目を無くすように作られた鎧。物理防御２４～３１";
                    PhysicalDefenseMinValue = 24;
                    PhysicalDefenseMaxValue = 31;
                    cost = 9600;
                    AdditionalDescription(ItemType.Armor_Heavy);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case "ラメラ・アーマー": // ３階アイテム
                    description = "薄めの鋼板を繋ぎ合わせ、着こなしの良さと貫通系に対する防御を両立させた鎧。物理防御２１～２７";
                    PhysicalDefenseMinValue = 21;
                    PhysicalDefenseMaxValue = 27;
                    cost = 8100;
                    AdditionalDescription(ItemType.Armor_Middle);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case "シャムシール": // ３階アイテム
                    description = "貫通系攻撃ではなく、曲線に流れる力が引き出されるように作られた剣。物理攻撃４０～６５";
                    PhysicalAttackMinValue = 40;
                    PhysicalAttackMaxValue = 65;
                    cost = 9000;
                    AdditionalDescription(ItemType.Weapon_Middle);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case "ウェルニッケの腕輪": // ガンツの武具屋販売（ダンジョン３階）
                    description = "昆虫ウェルニッケの素材を使って生成された腕輪。体＋２０";
                    buffUpStamina = 20;
                    cost = 7200;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case "賢者の眼鏡": // ガンツの武具屋販売（ダンジョン３階）
                    description = "ヴァスタ爺から送られてきた貴重な一品。技＋３０、知＋２５";
                    buffUpAgility = 30;
                    buffUpIntelligence = 25;
                    cost = 9500;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case "七色プリズムバンド": // ガンツの武具屋販売（ダンジョン４階）
                    description = "装着者の全体的な能力を引き出すために生成されたアクセサリ。力＋２０、知＋２０、技＋２０、体＋２０、心＋２０";
                    buffUpStrength = 20;
                    buffUpAgility = 20;
                    buffUpIntelligence = 20;
                    buffUpStamina = 20;
                    buffUpMind = 20;
                    cost = 53000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Rare;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case "再生の紋章": // ガンツの武具屋販売（ダンジョン４階）
                    description = "装着者の生命線を引き出すアクセサリ。体＋４０、ターン終了時、ライフを幾ばくか回復する。";
                    // after 自然回復７％
                    buffUpStamina = 40;
                    information = "自然回復＋７％";
                    cost = 52000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Rare;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case "シールオブアクア＆ファイア": // ガンツの武具屋販売（ダンジョン４階）
                    description = "【爽快！アクア＆ファイア】ジュースが発案の元となっているアクセサリ。　火耐性３０％、水耐性３０％";
                    // after
                    cost = 48000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case "ドラゴンのベルト": // ガンツの武具屋販売（ダンジョン４階）
                    description = "ドラゴンの鱗で生成されたベルト。　力＋３５、知＋４０";
                    buffUpStrength = 35;
                    buffUpIntelligence = 40;
                    cost = 65000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Rare;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case "エスパダス": // ダンジョン４階のアイテム
                    description = "太古のエスパーダ種族が栄えた時代に作られた剣。物理攻撃１３１～１４５";
                    PhysicalAttackMinValue = 131;
                    PhysicalAttackMaxValue = 145;
                    cost = 9200;
                    AdditionalDescription(ItemType.Weapon_Heavy);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case "グリーンマテリアル": // ダンジョン４階のアイテム
                    description = "純緑色の立方体。";
                    cost = 22000;
                    AdditionalDescription(ItemType.None);
                    rareLevel = RareLevel.Common;
                    limitValue = OTHER_ITEM_STACK_SIZE;
                    break;
                case "アヴォイド・クロス": // ダンジョン４階のアイテム
                    description = "戦闘中の回避を主眼において作成された舞踏衣。物理防御２４～２９";
                    PhysicalDefenseMinValue = 24;
                    PhysicalDefenseMaxValue = 29;
                    cost = 14000;
                    AdditionalDescription(ItemType.Armor_Light);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case "ブリガンダィン": // ダンジョン４階のアイテム
                    description = "薄型軽装でかつ耐久性を高める金属片で縫われた鎧。物理防御２６～３１";
                    PhysicalDefenseMinValue = 26;
                    PhysicalDefenseMaxValue = 31;
                    cost = 11000;
                    AdditionalDescription(ItemType.Armor_Middle);
                    rareLevel = RareLevel.Rare;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case "ソード・オブ・ブルールージュ": // ダンジョン４階のアイテム
                    description = "青い宝玉と赤い刀帯が付与されている剣。物理攻撃１２７～１６１";
                    PhysicalAttackMinValue = 127;
                    PhysicalAttackMaxValue = 161;
                    cost = 78000;
                    AdditionalDescription(ItemType.Weapon_Middle);
                    rareLevel = RareLevel.Rare;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case "夢見の印章": // ダンジョン４階のアイテム
                    description = "空想力を養うために付けられるシール。 知＋３５、心＋３０";
                    buffUpIntelligence = 35;
                    buffUpMind = 30;
                    cost = 9400;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case "天使の契約書": // ダンジョン４階のアイテム
                    description = "天使の加護を得るための契約書。体＋５００";
                    description += "\r\n【常備能力】　ターン終了時、スタン/沈黙/猛毒/誘惑/凍結/麻痺/恐怖/鈍化/暗闇から即時復帰できる。"; // 後編編集（状態解除と体＋５００を追記）
                    // after
                    buffUpStamina = 500;
                    cost = 61000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Rare;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case "ロリカ・セグメンタータ": // ダンジョン４階のアイテム
                    description = "強烈な打撃・殴打系に耐えられる鎧。物理防御３５～３９";
                    PhysicalDefenseMinValue = 35;
                    PhysicalDefenseMaxValue = 39;
                    cost = 13000;
                    AdditionalDescription(ItemType.Armor_Heavy);
                    rareLevel = RareLevel.Rare;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_SANGO_BRESLET: // ラナ初期装備
                    description = "珊瑚の材質で作られたブレスレット。知＋２、体＋２、心＋２";
                    buffUpIntelligence = 2;
                    buffUpStamina = 2;
                    buffUpMind = 2;
                    cost = 100;
                    AdditionalDescription(ItemType.Accessory);
                    equipablePerson = Equipable.Lana;
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case "天空の翼（レプリカ）": // ヴェルゼ初期装備
                    description = "ヴェルゼが疾風の動きを得るために自前で作成したレプリカ。技＋５０";
                    BuffUpAgility = 50;
                    cost = 0;
                    AdditionalDescription(ItemType.Accessory);
                    equipablePerson = Equipable.Verze;
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case "遠見の青水晶": // 初期ラナ会話イベントで入手アイテム
                    description = "ダンジョン離脱する事ができる青水晶。何度使っても無くならない。";
                    cost = 0;
                    AdditionalDescription(ItemType.Use_BlueOrb);
                    rareLevel = RareLevel.Rare;
                    limitValue = RARE_EPIC_ITEM_STACK_SIZE;
                    break;

                case "剣紋章ペンダント": // ラナレベルアップ時でもらえるアイテム
                    description = "ラナが徹夜で製作した剣の紋章が入ったペンダント。力＋１５、心＋１５";
                    buffUpStrength = 15;
                    buffUpMind = 15;
                    cost = 8500;
                    AdditionalDescription(ItemType.Accessory);
                    equipablePerson = Equipable.Ein;
                    rareLevel = RareLevel.Rare;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                // s 後編編集
                case "エルミ・ジョルジュ　ファージル王家の刻印":
                    description = "FiveSeekerの一人エルミ・ジョルジュ専用刻印が彫られているリング。力＋１０５２、知＋１０５２、技＋１０５２、体＋１０５２、心＋１０５２";
                    buffUpStrength = 1052;
                    buffUpAgility = 1052;
                    buffUpIntelligence = 1052;
                    buffUpStamina = 1052;
                    buffUpMind = 1052;
                    cost = 0;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Epic;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case "ファラ・フローレ　天使のペンダント":
                    description = "FiveSeekerの一人ファラ・フローレが身に着けている半透明のペンダント。心＋５８９２";
                    buffUpMind = 5892;
                    cost = 0;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Epic;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case "シニキア・カールハンツ　魔道デビルアイ":
                    description = "FiveSeekerの一人シニキア・カールハンツが直接眼に装着している闇の擬眼。知＋５４６８";
                    buffUpIntelligence = 5468;
                    cost = 0;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Epic;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case "ヴェルゼ・アーティ　天空の翼":
                    description = "FiveSeekerの一人ヴェルゼ・アーティが空中を走るために用いているブーツ。技＋５６９１";
                    BuffUpAgility = 5691;
                    cost = 0;
                    AdditionalDescription(ItemType.Accessory);
                    equipablePerson = Equipable.Verze;
                    rareLevel = RareLevel.Epic;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                // e 後編編集

                case FIX.POOR_PRACTICE_SWORD: // アイン初期装備
                    description = "初心者向けの剣。威力はほとんどなく、剣を振る練習に向いている。物理攻撃１～３";
                    PhysicalAttackMinValue = 1;
                    PhysicalAttackMaxValue = 3;
                    cost = 100;
                    AdditionalDescription(ItemType.Weapon_Heavy);
                    rareLevel = RareLevel.Poor;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.POOR_PRACTICE_KNUCKLE: // ラナ初期装備
                    description = "初心者向けのナックル。殺傷力は極めて低い。物理攻撃１～２";
                    PhysicalAttackMinValue = 1;
                    PhysicalAttackMaxValue = 2;
                    cost = 100;
                    AdditionalDescription(ItemType.Weapon_Light);
                    rareLevel = RareLevel.Poor;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case "白銀の剣（レプリカ）": // ヴェルゼ初期装備
                    description = "ヴェルゼが以前装備していた剣を自前で作成したレプリカ。物理攻撃３７～５８";
                    PhysicalAttackMinValue = 37;
                    PhysicalAttackMaxValue = 58;
                    cost = 0;
                    AdditionalDescription(ItemType.Weapon_Middle);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case "ショートソード": // ガンツの武具屋販売（ダンジョン１階）
                    description = "小回りがよく利く標準的な剣。物理攻撃４～９";
                    PhysicalAttackMinValue = 4;
                    PhysicalAttackMaxValue = 9;
                    cost = 500;
                    AdditionalDescription(ItemType.Weapon_Heavy);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case "洗練されたロングソード": // ガンツの武具屋販売（ダンジョン１階）
                    description = "ある一定の力を持たせる事で十分な力を発揮できる剣。物理攻撃１０～２０";
                    PhysicalAttackMinValue = 10;
                    PhysicalAttackMaxValue = 20;
                    cost = 1200;
                    AdditionalDescription(ItemType.Weapon_Heavy);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case "青銅の剣": // ガンツの武具屋販売（ダンジョン２階）
                    description = "青銅の材質を良好に引き出した剣。物理攻撃２５～３７";
                    PhysicalAttackMinValue = 25;
                    PhysicalAttackMaxValue = 37;
                    cost = 3200;
                    AdditionalDescription(ItemType.Weapon_Heavy);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case "メタルフィスト": // ガンツの武具屋販売（ダンジョン２階）
                    description = "メタル製の材料をグローブの形に仕立て上げた一品。物理攻撃２２～３３";
                    PhysicalAttackMinValue = 22;
                    PhysicalAttackMaxValue = 33;
                    cost = 2600;
                    AdditionalDescription(ItemType.Weapon_Light);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case "プラチナソード": // ガンツの武具屋販売（ダンジョン３階）
                    description = "プラチナ製で作成された剣。物理攻撃４２～６８";
                    PhysicalAttackMinValue = 42;
                    PhysicalAttackMaxValue = 68;
                    cost = 7700;
                    AdditionalDescription(ItemType.Weapon_Heavy);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case "ファルシオン": // ガンツの武具屋販売（ダンジョン３階）
                    description = "繊細な切れ味よりも、叩き斬る事に特化した剣。物理攻撃３５～７７";
                    PhysicalAttackMinValue = 35;
                    PhysicalAttackMaxValue = 77;
                    cost = 8200;
                    AdditionalDescription(ItemType.Weapon_Heavy);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case "アイアンクロー": // ガンツの武具屋販売（ダンジョン３階）
                    description = "鉄製のかぎ爪が付与されているグローブ。物理攻撃４５～５５";
                    PhysicalAttackMinValue = 45;
                    PhysicalAttackMaxValue = 55;
                    cost = 6900;
                    AdditionalDescription(ItemType.Weapon_Light);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case "ライトプラズマブレード": // ガンツの武具屋販売（ダンジョン４階）
                    description = "光と稲妻を剣の中に宿らせた。ガンツ自慢の一品。物理攻撃１２３～１５１";
                    PhysicalAttackMinValue = 123;
                    PhysicalAttackMaxValue = 151;
                    cost = 32000;
                    AdditionalDescription(ItemType.Weapon_Heavy);
                    rareLevel = RareLevel.Rare;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case "イスリアルフィスト": // ガンツの武具屋販売（ダンジョン４階）
                    description = "空想物理学をモチーフにした純オリハルコン製グローブ。物理攻撃１４４～１６７";
                    PhysicalAttackMinValue = 144;
                    PhysicalAttackMaxValue = 167;
                    cost = 28000;
                    AdditionalDescription(ItemType.Weapon_Light);
                    rareLevel = RareLevel.Rare;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                // s 後編編集
                case "双剣  ジュノセレステ":
                    description = "鍛冶屋ヴァスタ三剣の一つ。逆・順、前・後、遠・近、相反の剣。双の視点が必要。【特殊能力：有】物理攻撃１０５７～２８９６";
                    UseSpecialAbility = true;
                    PhysicalAttackMinValue = 1057;
                    PhysicalAttackMaxValue = 2896;
                    cost = 1120520;
                    AdditionalDescription(ItemType.Weapon_Heavy);
                    rareLevel = RareLevel.Epic;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case "極剣  ゼムルギアス":
                    description = "鍛冶屋ヴァスタ三剣の一つ。力・技・知・体・心、五の剣。全能力が必要。【特殊能力：有】物理攻撃１６１６～１６２０";
                    UseSpecialAbility = true;
                    PhysicalAttackMinValue = 1616;
                    PhysicalAttackMaxValue = 1620;
                    cost = 1053170;
                    AdditionalDescription(ItemType.Weapon_Heavy);
                    rareLevel = RareLevel.Epic;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case "クロノス・ロマティッド・ソード":
                    description = "鍛冶屋ガンツの最高傑作の一つ。時間軸を超えた攻撃を可能とする剣。【特殊能力：有】物理攻撃２０１２～２５９３";
                    UseSpecialAbility = true;
                    PhysicalAttackMinValue = 2012;
                    PhysicalAttackMaxValue = 2593;
                    cost = 1299420;
                    AdditionalDescription(ItemType.Weapon_Heavy);
                    rareLevel = RareLevel.Epic;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case "ヘパイストス・パナッサロイニ":
                    description = "鍛冶屋ガンツの最高傑作の一つ。時間軸に関する魔法とスキルを無効化する鎧。【特殊能力：有】物理防御１２４１～１３０９";
                    UseSpecialAbility = true;
                    PhysicalDefenseMinValue = 1241;
                    PhysicalDefenseMaxValue = 1309;
                    cost = 1516190;
                    AdditionalDescription(ItemType.Armor_Heavy);
                    rareLevel = RareLevel.Epic;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                // e 後編編集

                case "タイム・オブ・ルーセ": // ダンジョン５階の隠しアイテム
                    description = "鍛冶屋ガンツの最高傑作を生み出すための素材。";
                    cost = 0;
                    AdditionalDescription(ItemType.Material_Equip);
                    rareLevel = RareLevel.Epic;
                    limitValue = RARE_EPIC_ITEM_STACK_SIZE;
                    break;

                case FIX.POOR_COTE_OF_PLATE: // アイン初期装備
                    description = "初心者がまず初めに装備するチュニック。物理防御１～２";
                    PhysicalDefenseMinValue = 1;
                    PhysicalDefenseMaxValue = 2;
                    cost = 100;
                    AdditionalDescription(ItemType.Armor_Heavy);
                    rareLevel = RareLevel.Poor;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.POOR_LIGHT_CROSS: // ラナ初期装備
                    description = "身軽に動け、かつ、戦闘向けに作成される衣類は舞踏衣と呼ばれている。物理防御１～２";
                    PhysicalDefenseMinValue = 1;
                    PhysicalDefenseMaxValue = 2;
                    cost = 100;
                    AdditionalDescription(ItemType.Armor_Light);
                    rareLevel = RareLevel.Poor;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case "黒真空の鎧（レプリカ）": // ヴェルゼ初期装備
                    description = "ヴェルゼが以前装備していた鎧を自前で作成したレプリカ。物理防御１５～１８";
                    PhysicalDefenseMinValue = 15;
                    PhysicalDefenseMaxValue = 18;
                    cost = 0;
                    AdditionalDescription(ItemType.Armor_Middle);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case "冒険者用の鎖かたびら": // ガンツの武具屋販売（ダンジョン１階）
                    description = "冒険者がよく好んで使う鎖かたびら。物理防御１～３";
                    PhysicalDefenseMinValue = 1;
                    PhysicalDefenseMaxValue = 3;
                    cost = 400;
                    AdditionalDescription(ItemType.Armor_Heavy);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case "青銅の鎧": // ガンツの武具屋販売（ダンジョン１階）
                    description = "手頃な重さであり、モンスターの攻撃をよく受け止められる鎧。物理防御３～５";
                    PhysicalDefenseMinValue = 3;
                    PhysicalDefenseMaxValue = 5;
                    cost = 1500;
                    AdditionalDescription(ItemType.Armor_Heavy);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case "真鍮の鎧": // ２階アイテム
                    description = "真鍮製で出来た鎧。物理防御４～８";
                    PhysicalDefenseMinValue = 4;
                    PhysicalDefenseMaxValue = 8;
                    cost = 1900;
                    AdditionalDescription(ItemType.Armor_Heavy);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case "光沢のある鉄のプレート": // ガンツの武具屋販売（ダンジョン２階）
                    description = "若干の光沢が採用されており、着ているものを安心させる鎧プレート。物理防御１１～１５";
                    PhysicalDefenseMinValue = 11;
                    PhysicalDefenseMaxValue = 15;
                    cost = 3700;
                    AdditionalDescription(ItemType.Armor_Heavy);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case "シルクの武道衣": // ガンツの武具屋販売（ダンジョン２階）
                case "シルクローブ": // スパイダーシルク、１階で入手した素材が２階ラナ参加以降でガンツ武具販売になる。
                    description = "シルク製で生成された頑丈な武道衣。物理防御５～９";
                    PhysicalDefenseMinValue = 5;
                    PhysicalDefenseMaxValue = 9;
                    cost = 3100;
                    AdditionalDescription(ItemType.Armor_Light);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case "シルバーアーマー": // ガンツの武具屋販売（ダンジョン３階）
                    description = "純銀へのこだわりで生成された鎧。物理防御２２～３０";
                    PhysicalDefenseMinValue = 22;
                    PhysicalDefenseMaxValue = 30;
                    cost = 7600;
                    AdditionalDescription(ItemType.Armor_Heavy);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case "獣皮製の舞踏衣": // ガンツの武具屋販売（ダンジョン３階）
                    description = "獣の皮を縫って作成された舞踏衣。物理防御１８～２５";
                    PhysicalDefenseMinValue = 18;
                    PhysicalDefenseMaxValue = 25;
                    cost = 7100;
                    AdditionalDescription(ItemType.Armor_Light);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case "フィスト・クロス": // ガンツの武具屋販売（ダンジョン３階）
                    description = "主に打撃系に対して強化されている衣。物理防御２２～２７";
                    PhysicalDefenseMinValue = 22;
                    PhysicalDefenseMaxValue = 27;
                    cost = 10000;
                    AdditionalDescription(ItemType.Armor_Light);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case "プリズマティックアーマー": // ガンツの武具屋販売（ダンジョン４階）
                    description = "プリズムの仕組みを純水晶に組み合わせて作成された自慢の一品。物理防御３６～４１";
                    PhysicalDefenseMinValue = 36;
                    PhysicalDefenseMaxValue = 41;
                    cost = 36000;
                    AdditionalDescription(ItemType.Armor_Heavy);
                    rareLevel = RareLevel.Rare;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case "極薄合金製の羽衣": // ガンツの武具屋販売（ダンジョン４階）
                    description = "合金材質を極力薄くして羽衣にした自慢の一品。物理防御３２～３７";
                    PhysicalDefenseMinValue = 32;
                    PhysicalDefenseMaxValue = 37;
                    cost = 40000;
                    AdditionalDescription(ItemType.Armor_Light);
                    rareLevel = RareLevel.Rare;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.EPIC_OVER_SHIFTING: //"オーバーシフティング": // ダンジョン５階
                    description = "対象の人が本来持ちうる能力を変更する。ＬＶ時のパラメタ割り振りを再セットする。";
                    cost = 0;
                    AdditionalDescription(ItemType.Use_Potion);
                    rareLevel = RareLevel.Epic;
                    limitValue = RARE_EPIC_ITEM_STACK_SIZE;
                    break;

                case "ラナのイヤリング": // ダンジョン５階（ラナのイベント）
                    description = "ラナがいつも付けていたお気に入りのイヤリング。用途不明。";
                    cost = 0;
                    AdditionalDescription(ItemType.Accessory);
                    equipablePerson = Equipable.Lana;
                    rareLevel = RareLevel.Rare;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case "レジェンド・レッドホース": // ダンジョン５階
                    description = "赤の闘馬の意志が宿っている伝説の紋章。戦闘中絶対先攻となる。";
                    // after
                    cost = 120000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Epic;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case "ルナ・エグゼキュージョナー": // ダンジョン５階
                    description = "月の輝きを宿らせた剣。斬撃のたびに、光が輝いて見えるという。物理攻撃２１１～２４８";
                    PhysicalAttackMinValue = 211;
                    PhysicalAttackMaxValue = 248;
                    cost = 140000;
                    AdditionalDescription(ItemType.Weapon_Heavy);
                    rareLevel = RareLevel.Rare;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case "蒼黒・氷大蛇の爪": // ダンジョン５階
                    description = "外来国から伝承されている大蛇の血と鱗を素材として作られたかぎ爪。物理攻撃２３９～２６１";
                    PhysicalAttackMinValue = 239;
                    PhysicalAttackMaxValue = 261;
                    cost = 170000;
                    AdditionalDescription(ItemType.Weapon_Light);
                    rareLevel = RareLevel.Rare;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case "ファージル・ジ・エスペランザ": // ダンジョン５階
                    description = "ファージル宮殿内の数ある国宝の一つとして飾られている剣。物理攻撃２０７～２４４";
                    PhysicalAttackMinValue = 207;
                    PhysicalAttackMaxValue = 244;
                    cost = 150000;
                    AdditionalDescription(ItemType.Weapon_Middle);
                    rareLevel = RareLevel.Rare;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case "プライド・オブ・シーカー": // ガンツの武具屋販売（ダンジョン５階）
                    description = "ダンジョン求道者が求める容を結晶化した物。心＋９９";
                    buffUpMind = 99;
                    cost = 98000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Rare;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case "詩聖水宝の勾玉": // ガンツの武具屋販売（ダンジョン５階）
                    description = "ダンジョン探求者が求める容を結晶化した物。知＋９９";
                    buffUpIntelligence = 99;
                    cost = 98000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Rare;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case "ディセンションブーツ": // ガンツの武具屋販売（ダンジョン５階）
                    description = "ダンジョン探求者が求める容を結晶化した物。技＋９９";
                    buffUpAgility = 99;
                    cost = 98000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Rare;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case "ハートブレーカー": // ガンツの武具屋販売（ダンジョン５階）
                    description = "ダンジョン探求者が求める容を結晶化した物。力＋９９";
                    buffUpStrength = 99;
                    cost = 98000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Rare;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;


                // s 後編追加
                case FIX.POOR_PRACTICE_SHILED: // アイン初期装備（後編）
                    description = "初心者向けの盾。軽くて持ちやすいが耐久性は無い。物理防御１～１";
                    PhysicalDefenseMinValue = 1;
                    PhysicalDefenseMaxValue = 1;
                    cost = 100;
                    AdditionalDescription(ItemType.Shield);
                    rareLevel = RareLevel.Poor;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                #endregion
                #region "１階：ランダムドロップ"
                // 単一UP
                case FIX.POOR_HINJAKU_ARMRING: // １階：エリア１：ランダムドロップ
                    description = "ほんのりパワーを感じ取れる腕輪。力＋２";
                    BuffUpStrength = 2;
                    cost = 210;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Poor;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.POOR_USUYOGORETA_FEATHER: // １階：エリア１：ランダムドロップ
                    description = "みすぼらしい付け羽。少しだけ軽さを感じ取れる。技＋２";
                    BuffUpAgility = 2;
                    cost = 210;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Poor;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.POOR_NON_BRIGHT_ORB: // １階：エリア１：ランダムドロップ
                    description = "知性が枯渇しているオーブ。知＋２";
                    BuffUpIntelligence = 2;
                    cost = 210;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Poor;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.POOR_KUKEI_BANGLE: // １階：エリア１：ランダムドロップ
                    description = "丸みを帯びてないため、装着しにくいバングル。体＋１";
                    BuffUpStamina = 1;
                    cost = 180;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Poor;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.POOR_SUTERARESHI_EMBLEM: // １階：エリア１：ランダムドロップ
                    description = "惨敗した者が捨てていった名もなき紋章。心＋３";
                    BuffUpMind = 3;
                    cost = 210;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Poor;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                // ２箇所UP
                case FIX.POOR_ARIFURETA_STATUE: // １階：エリア１：ランダムドロップ
                    description = "特にこれといった特徴の無い彫像。技＋１、心＋１";
                    BuffUpAgility = 1;
                    BuffUpMind = 1;
                    cost = 240;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Poor;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.POOR_NON_ADJUST_BELT: // １階：エリア１：ランダムドロップ
                    description = "付け心地の悪いベルト。力＋１、技＋１";
                    BuffUpStrength = 1;
                    BuffUpAgility = 1;
                    cost = 240;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Poor;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.POOR_SIMPLE_EARRING: // １階：エリア１：ランダムドロップ
                    description = "単に丸い形をしてるイヤリング。知＋１、心＋１";
                    BuffUpIntelligence = 1;
                    BuffUpMind = 1;
                    cost = 240;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Poor;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.POOR_KATAKUZURESHITA_FINGERRING: // １階：エリア１：ランダムドロップ
                    description = "すでに型が崩れているはめにくい指輪。技＋１、知＋１";
                    BuffUpAgility = 1;
                    BuffUpIntelligence = 1;
                    cost = 240;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Poor;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                // ３箇所UP
                case FIX.POOR_IROASETA_CHOKER: // １階：エリア１：ランダムドロップ
                    description = "元の色が分からないぐらいに色褪せたチョーカー。力＋１、知＋１、体＋１";
                    BuffUpStrength = 1;
                    BuffUpIntelligence = 1;
                    BuffUpStamina = 1;
                    cost = 310;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Poor;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.POOR_YOREYORE_MANTLE: // １階：エリア１：ランダムドロップ
                    description = "特に手入れがされていないマント。僅かな何かを感じられる。技＋１、知＋１、心＋１";
                    BuffUpAgility = 1;
                    BuffUpIntelligence = 1;
                    BuffUpMind = 1;
                    cost = 310;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Poor;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.POOR_NON_HINSEI_CROWN: // １階：エリア１：ランダムドロップ
                    description = "付けているとダサイが、ほんのりパワーを感じる。力＋１、技＋１、知＋１";
                    BuffUpStrength = 1;
                    BuffUpAgility = 1;
                    BuffUpIntelligence = 1;
                    cost = 310;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Poor;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                // 単一：Common
                case FIX.COMMON_RED_PENDANT: // １階：エリア１：ランダムドロップ
                    description = "赤色をしたペンダント。ほのかに【力】を感じ取ることが出来る。力＋５";
                    BuffUpStrength = 5;
                    cost = 520;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_BLUE_PENDANT: // １階：エリア１：ランダムドロップ
                    description = "青色をしたペンダント。ほのかに【技】を感じ取ることが出来る。技＋５";
                    BuffUpAgility = 5;
                    cost = 520;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_PURPLE_PENDANT: // １階：エリア１：ランダムドロップ
                    description = "紫色をしたペンダント。ほのかに【知】を感じ取ることが出来る。知＋５";
                    BuffUpIntelligence = 5;
                    cost = 520;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_GREEN_PENDANT: // １階：エリア１：ランダムドロップ
                    description = "黄色をしたペンダント。ほのかに【体】を感じ取ることが出来る。体＋５";
                    BuffUpStamina = 5;
                    cost = 520;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_YELLOW_PENDANT: // １階：エリア１：ランダムドロップ
                    description = "黄色をしたペンダント。ほのかに【心】を感じ取ることが出来る。心＋５";
                    BuffUpMind = 5;
                    cost = 520;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_SISSO_ARMRING: // １階：エリア１：ランダムドロップ
                    description = "質素ではあるが、確かな作りが施されている腕輪。力＋３、体＋１";
                    BuffUpStrength = 3;
                    BuffUpStamina = 1;
                    cost = 400;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_FINE_FEATHER: // １階：エリア１：ランダムドロップ
                    description = "付けていると、技の切れ味が上昇する感じがする。技＋３、心＋１";
                    BuffUpAgility = 3;
                    BuffUpMind = 1;
                    cost = 400;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_KIREINA_ORB: // １階：エリア１：ランダムドロップ
                    description = "オーブとしての基本特性が備わっている。技＋１、知＋３";
                    BuffUpAgility = 1;
                    BuffUpIntelligence = 3;
                    cost = 400;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_FIT_BANGLE: // １階：エリア１：ランダムドロップ
                    description = "弾力があり、フィットしやすいバングル。力＋２、体＋２";
                    BuffUpStrength = 2;
                    BuffUpStamina = 2;
                    cost = 400;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_PRISM_EMBLEM: // １階：エリア１：ランダムドロップ
                    description = "特徴は無いが、ほど良い形をしたエムブレム。力＋１、技＋１、知＋１、体＋１、心＋１";
                    BuffUpStrength = 1;
                    BuffUpAgility = 1;
                    BuffUpIntelligence = 1;
                    BuffUpStamina = 1;
                    BuffUpMind = 1;
                    cost = 450;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                // Rare
                case FIX.RARE_JOUSITU_BLUE_POWERRING:
                    description = "基本的な質の高さを感じさせるパワーリング。力＋７、技＋４、心＋３";
                    BuffUpStrength = 7;
                    BuffUpAgility = 4;
                    BuffUpMind = 3;
                    cost = 880;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Rare;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.RARE_KOUJOUSINYADORU_RED_ORB:
                    description = "基本的な向上心を高めてくれるオーブ。知＋７、体＋２、心＋４";
                    BuffUpIntelligence = 7;
                    BuffUpStamina = 2;
                    BuffUpMind = 4;
                    cost = 880;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Rare;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.RARE_MAGICIANS_MANTLE:
                    description = "基本魔法に熟達した者が装着するマント。知＋１２、魔法攻撃５～１０";
                    BuffUpIntelligence = 12;
                    MagicAttackMinValue = 5;
                    MagicAttackMaxValue = 10;
                    cost = 980;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Rare;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.RARE_BEATRUSH_BANGLE:
                    description = "攻撃性を高める獣をモチーフにした戦闘バングル。力＋９、技＋５、知＋２";
                    BuffUpStrength = 9;
                    BuffUpAgility = 5;
                    BuffUpIntelligence = 2;
                    cost = 960;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Rare;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                // 武器：Poor
                case FIX.POOR_TUKAIFURUSARETA_SWORD: // １階：エリア１：ランダムドロップ
                    description = "刃こぼれが酷く、扱い辛くなっている剣。物理攻撃２～４";
                    PhysicalAttackMinValue = 2;
                    PhysicalAttackMaxValue = 4;
                    cost = 150;
                    AdditionalDescription(ItemType.Weapon_Heavy);
                    rareLevel = RareLevel.Poor;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.POOR_TUKAINIKUI_LONGSWORD: // １階：エリア１：ランダムドロップ
                    description = "長くしただけで調節の効いてない長剣。物理攻撃０～１２";
                    PhysicalAttackMinValue = 0;
                    PhysicalAttackMaxValue = 12;
                    cost = 200;
                    AdditionalDescription(ItemType.Weapon_TwoHand);
                    rareLevel = RareLevel.Poor;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                // 武器：Common
                case FIX.COMMON_FINE_SWORD: // １階：エリア１：ランダムドロップ
                    description = "標準的な剣。物理攻撃５～８";
                    PhysicalAttackMinValue = 5;
                    PhysicalAttackMaxValue = 8;
                    cost = 580;
                    AdditionalDescription(ItemType.Weapon_Heavy);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_FINE_LANCE:
                    description = "標準的な槍。バランス良く突き刺す事ができる。物理攻撃６～７";
                    PhysicalAttackMinValue = 6;
                    PhysicalAttackMaxValue = 7;
                    cost = 570;
                    AdditionalDescription(ItemType.Weapon_Lance);
                    rareLevel = RareLevel.Common;
                    limitValue = USING_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_FINE_CLAW:
                    description = "標準的な爪。バランス良く殴る事ができる。物理攻撃４～６";
                    PhysicalAttackMinValue = 4;
                    PhysicalAttackMaxValue = 6;
                    cost = 560;
                    AdditionalDescription(ItemType.Weapon_Lance);
                    rareLevel = RareLevel.Common;
                    limitValue = USING_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_FINE_AXE:
                    description = "標準的な斧。バランス良く振り回す事ができる。物理攻撃３～１０";
                    PhysicalAttackMinValue = 3;
                    PhysicalAttackMaxValue = 10;
                    cost = 600;
                    AdditionalDescription(ItemType.Weapon_Axe);
                    rareLevel = RareLevel.Common;
                    limitValue = USING_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_FINE_BOW:
                    description = "標準的な弓。バランス良く矢が当たる。物理攻撃３～５";
                    PhysicalAttackMinValue = 3;
                    PhysicalAttackMaxValue = 5;
                    cost = 550;
                    AdditionalDescription(ItemType.Weapon_Bow);
                    rareLevel = RareLevel.Common;
                    limitValue = USING_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_FINE_ROD:
                    description = "標準的な杖。バランス良く魔法が打てる。魔法攻撃４～８";
                    MagicAttackMinValue = 4;
                    MagicAttackMaxValue = 8;
                    cost = 580;
                    AdditionalDescription(ItemType.Weapon_Staff);
                    rareLevel = RareLevel.Common;
                    limitValue = USING_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_FINE_BOOK:
                    description = "標準的な魔導書。バランス良く魔法が詠唱できる。魔法攻撃６～７";
                    MagicAttackMinValue = 6;
                    MagicAttackMaxValue = 7;
                    cost = 570;
                    AdditionalDescription(ItemType.Weapon_Staff);
                    rareLevel = RareLevel.Common;
                    limitValue = USING_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_FINE_SHIELD:
                    description = "標準的な盾。バランス良く防ぐ事ができる。物理防御２～４";
                    PhysicalDefenseMinValue = 2;
                    PhysicalDefenseMaxValue = 4;
                    cost = 540;
                    AdditionalDescription(ItemType.Weapon_Shield);
                    rareLevel = RareLevel.Common;
                    limitValue = USING_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_FINE_ORB:
                    description = "標準的なオーブ。バランス良く魔法を弾く事ができる。魔法防御２～４";
                    MagicDefenseMinValue = 2;
                    MagicDefenseMaxValue = 4;
                    cost = 540;
                    AdditionalDescription(ItemType.Weapon_Orb);
                    rareLevel = RareLevel.Common;
                    limitValue = USING_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_TWEI_SWORD: // １階：エリア１：ランダムドロップ
                    description = "両手剣専用。重量感があり、振り方に一工夫が必要。物理攻撃３～１８";
                    PhysicalAttackMinValue = 3;
                    PhysicalAttackMaxValue = 18;
                    cost = 610;
                    AdditionalDescription(ItemType.Weapon_TwoHand);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                // 武器：Rare
                case FIX.RARE_AERO_BLADE: // １階：エリア１：ランダムドロップ
                    description = "疾駆の振りで、一癖ある切り方が可能なブレード。【特殊能力：有】物理攻撃１０～１５";
                    useSpecialAbility = true;
                    PhysicalAttackMinValue = 10;
                    PhysicalAttackMaxValue = 15;
                    cost = 1600;
                    AdditionalDescription(ItemType.Weapon_Heavy);
                    rareLevel = RareLevel.Rare;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                // 防具(Poor)
                case FIX.POOR_GATAGAKITERU_ARMOR:
                    description = "本来の性能を出せていない鎧。物理防御２～３";
                    PhysicalDefenseMinValue = 2;
                    PhysicalDefenseMaxValue = 3;
                    cost = 300;
                    AdditionalDescription(ItemType.Armor_Heavy);
                    rareLevel = RareLevel.Poor;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.POOR_FESTERING_ARMOR:
                    description = "胴の一部が破損している、ただれた鎧。物理防御０～４";
                    PhysicalDefenseMinValue = 0;
                    PhysicalDefenseMaxValue = 4;
                    cost = 300;
                    AdditionalDescription(ItemType.Armor_Heavy);
                    rareLevel = RareLevel.Poor;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                // 防具(Common)
                case FIX.COMMON_FINE_ARMOR: // １階：エリア１：ランダムドロップ
                    description = "そつなく使える鎧。物理防御３～６";
                    PhysicalDefenseMinValue = 3;
                    PhysicalDefenseMaxValue = 6;
                    cost = 590;
                    AdditionalDescription(ItemType.Armor_Heavy);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_GOTHIC_PLATE: // １階：エリア１：ランダムドロップ
                    description = "格式を重んじる飾り用の鎧。物理防御４～７";
                    PhysicalDefenseMinValue = 4;
                    PhysicalDefenseMaxValue = 7;
                    cost = 800;
                    AdditionalDescription(ItemType.Armor_Heavy);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                // 盾(Poor)
                case FIX.POOR_HINSO_SHIELD: // １階：エリア１：ランダムドロップ
                    description = "突進されると、すぐに壊れそうな盾。物理防御１～２";
                    PhysicalDefenseMinValue = 1;
                    PhysicalDefenseMaxValue = 2;
                    cost = 150;
                    AdditionalDescription(ItemType.Shield);
                    rareLevel = RareLevel.Poor;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.POOR_MUDANIOOKII_SHIELD: // １階：エリア１：ランダムドロップ
                    description = "大きくしてはあるが、薄っぺらい盾。物理防御０～３";
                    PhysicalDefenseMinValue = 0;
                    PhysicalDefenseMaxValue = 3;
                    cost = 140;
                    AdditionalDescription(ItemType.Shield);
                    rareLevel = RareLevel.Poor;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_GRIPPING_SHIELD: // １階：エリア１：ランダムドロップ
                    description = "攻撃に備えた体制で持たないと、使いにくさが残る盾。物理防御２～６";
                    PhysicalDefenseMinValue = 2;
                    PhysicalDefenseMaxValue = 6;
                    cost = 550;
                    AdditionalDescription(ItemType.Shield);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;


                // １階：エリア３－４ // ランダムドロップ
                // バラバラの４色
                case FIX.POOR_NO_CONCEPT_RING:
                    description = "これといった特徴が無く、中途半端なパワーを感じる。力＋３、技＋２、体＋４、心＋３";
                    BuffUpStrength = 3;
                    BuffUpAgility = 2;
                    BuffUpStamina = 4;
                    BuffUpMind = 3;
                    cost = 800;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Poor;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.POOR_HIGHCOLOR_MANTLE:
                    description = "さまざまな色を混ぜたが、どの色も冴えないマント。技＋３、知＋４、体＋３、心＋２";
                    BuffUpAgility = 3;
                    BuffUpIntelligence = 4;
                    BuffUpStamina = 3;
                    BuffUpMind = 2;
                    cost = 800;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Poor;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.POOR_EIGHT_PENDANT:
                    description = "８角形のペンダントだが、特定の力を感じられない。力＋４、知＋２、体＋３、心＋３";
                    BuffUpStrength = 4;
                    BuffUpIntelligence = 2;
                    BuffUpStamina = 3;
                    BuffUpMind = 3;
                    cost = 800;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Poor;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.POOR_GOJASU_BELT:
                    description = "煌びやかで非常に目立つベルトだが、ややこしい力を感じる。力＋２、技＋３、知＋４、体＋３";
                    BuffUpStrength = 2;
                    BuffUpAgility = 3;
                    BuffUpIntelligence = 4;
                    BuffUpStamina = 3;
                    cost = 800;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Poor;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.POOR_EGARA_HUMEI_EMBLEM:
                    description = "後上書きの部分が元のデザインを悪化させてる紋章。力＋２、技＋４、知＋２、心＋４";
                    BuffUpStrength = 2;
                    BuffUpAgility = 4;
                    BuffUpIntelligence = 2;
                    BuffUpMind = 4;
                    cost = 800;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Poor;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.POOR_HAYATOTIRI_ORB:
                    description = "全耐性が感じられるオーブだが、基礎能力が無い。火耐性５、水耐性５、聖耐性５、闇耐性５";
                    ResistFire = 5;
                    ResistIce = 5;
                    ResistLight = 5;
                    ResistShadow = 5;
                    cost = 800;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Poor;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                // 一般名称で２種類ＵＰ
                case FIX.COMMON_COPPER_RING_TORA:
                    description = "銅素材で作られた腕輪。虎の刻印がしてある。力＋９、技＋１２";
                    buffUpStrength = 9;
                    buffUpAgility = 12;
                    cost = 1650;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_COPPER_RING_IRUKA:
                    description = "銅素材で作られた腕輪。イルカの刻印がしてある。力＋１２、知＋９";
                    buffUpStrength = 12;
                    buffUpIntelligence = 9;
                    cost = 1650;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_COPPER_RING_UMA:
                    description = "銅素材で作られた腕輪。馬の刻印がしてある。力＋１２、体＋９";
                    buffUpStrength = 12;
                    buffUpStamina = 9;
                    cost = 1650;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_COPPER_RING_KUMA:
                    description = "銅素材で作られた腕輪。熊の刻印がしてある。力＋１２、心＋９";
                    buffUpStrength = 12;
                    buffUpMind = 9;
                    cost = 1650;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_COPPER_RING_HAYABUSA:
                    description = "銅素材で作られた腕輪。隼の刻印がしてある。技＋１２、知＋９";
                    buffUpAgility = 12;
                    buffUpIntelligence = 9;
                    cost = 1650;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_COPPER_RING_TAKO:
                    description = "銅素材で作られた腕輪。タコの刻印がしてある。技＋１２、体＋９";
                    buffUpAgility = 12;
                    buffUpStamina = 9;
                    cost = 1650;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_COPPER_RING_USAGI:
                    description = "銅素材で作られた腕輪。兎の刻印がしてある。技＋９、心＋１２";
                    buffUpAgility = 9;
                    buffUpMind = 12;
                    cost = 1650;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_COPPER_RING_KUMO:
                    description = "銅素材で作られた腕輪。蜘蛛の刻印がしてある。知＋９、体＋１２";
                    buffUpIntelligence = 9;
                    buffUpStamina = 12;
                    cost = 1650;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_COPPER_RING_SHIKA:
                    description = "銅素材で作られた腕輪。鹿の刻印がしてある。知＋１２、心＋９";
                    buffUpIntelligence = 12;
                    buffUpMind = 9;
                    cost = 1650;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_COPPER_RING_ZOU:
                    description = "銅素材で作られた腕輪。象の刻印がしてある。体＋１２、心＋９";
                    buffUpStamina = 12;
                    buffUpMind = 9;
                    cost = 1650;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_RED_AMULET:
                    description = "純赤色のアミュレット。それなりに【力】を感じ取ることが出来る。力＋１８";
                    buffUpStrength = 18;
                    cost = 2000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_BLUE_AMULET:
                    description = "純青色のアミュレット。それなりに【技】を感じ取ることが出来る。技＋１８";
                    buffUpAgility = 18;
                    cost = 2000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_PURPLE_AMULET:
                    description = "純紫色のアミュレット。それなりに【知】を感じ取ることが出来る。知＋１８";
                    buffUpIntelligence = 18;
                    cost = 2000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_GREEN_AMULET:
                    description = "純緑色のアミュレット。それなりに【体】を感じ取ることが出来る。体＋１８";
                    buffUpStamina = 18;
                    cost = 2000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_YELLOW_AMULET:
                    description = "純黄色のアミュレット。それなりに【心】を感じ取ることが出来る。心＋１８";
                    buffUpMind = 18;
                    cost = 2000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                // 武器：Poor
                case FIX.POOR_OLD_USELESS_ROD:
                    description = "本来の魔力を失っている状態の古ぼけた杖。魔法攻撃１～３";
                    MagicAttackMinValue = 1;
                    MagicAttackMaxValue = 3;
                    cost = 160;
                    AdditionalDescription(ItemType.Weapon_Rod);
                    rareLevel = RareLevel.Poor;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.POOR_KISSAKI_MARUI_TUME:
                    description = "切りかかった時の切れ味が悪い爪。物理攻撃２～４";
                    PhysicalAttackMinValue = 2;
                    PhysicalAttackMaxValue = 4;
                    cost = 200;
                    AdditionalDescription(ItemType.Weapon_Light);
                    rareLevel = RareLevel.Poor;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                // 防具(Poor)
                case FIX.POOR_BATTLE_HUMUKI_BUTOUGI:
                    description = "戦闘ではなく、踊り子向けの舞踏衣。物理防御１～２";
                    PhysicalDefenseMinValue = 1;
                    PhysicalDefenseMaxValue = 2;
                    cost = 600;
                    AdditionalDescription(ItemType.Armor_Light);
                    rareLevel = RareLevel.Poor;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.POOR_SIZE_AWANAI_ROBE:
                    description = "適当なサイズで作成されたローブ。物理防御０～２。闇耐性１０";
                    PhysicalDefenseMinValue = 0;
                    PhysicalDefenseMaxValue = 2;
                    this.ResistShadow = 10;
                    cost = 650;
                    AdditionalDescription(ItemType.Armor_Light);
                    rareLevel = RareLevel.Poor;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                // 武器：Common
                case FIX.COMMON_SHORT_SWORD:
                    description = "そつなく使える剣。物理攻撃９～１２";
                    PhysicalAttackMinValue = 9;
                    PhysicalAttackMaxValue = 12;
                    cost = 1050;
                    AdditionalDescription(ItemType.Weapon_Heavy);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_BASTARD_SWORD:
                    description = "両手剣専用。ふり幅は大きく、威力を出すにはある程度の力が必要。物理攻撃７～４０";
                    PhysicalAttackMinValue = 7;
                    PhysicalAttackMaxValue = 40;
                    cost = 1000;
                    AdditionalDescription(ItemType.Weapon_TwoHand);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_LIGHT_CLAW:
                    description = "普通の研ぎ方で作成された爪。物理攻撃５～７";
                    PhysicalAttackMinValue = 5;
                    PhysicalAttackMaxValue = 7;
                    cost = 550;
                    AdditionalDescription(ItemType.Weapon_Light);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_SHARP_CLAW:
                    description = "通常の爪より少しだけ重量感を軽くした爪。物理攻撃５～１３";
                    PhysicalAttackMinValue = 5;
                    PhysicalAttackMaxValue = 13;
                    cost = 1030;
                    AdditionalDescription(ItemType.Weapon_Light);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_WOOD_ROD:
                    description = "樹木の一部を切り取って作成された杖。魔法攻撃５～１０";
                    MagicAttackMinValue = 12;
                    MagicAttackMaxValue = 15;
                    cost = 1400;
                    AdditionalDescription(ItemType.Weapon_Rod);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                // 防具(Common)
                case FIX.COMMON_LETHER_CLOTHING:
                    description = "標準的なサイズで作成されたレザー製の衣。物理防御４～７";
                    PhysicalDefenseMinValue = 4;
                    PhysicalDefenseMaxValue = 7;
                    cost = 500;
                    AdditionalDescription(ItemType.Armor_Middle);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_COTTON_ROBE:
                    description = "木綿を編み合わせたローブ。物理防御３～７。火耐性５。水耐性５";
                    PhysicalDefenseMinValue = 3;
                    PhysicalDefenseMaxValue = 7;
                    ResistFire = 5;
                    ResistIce = 5;
                    cost = 950;
                    AdditionalDescription(ItemType.Armor_Light);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_COPPER_ARMOR:
                    description = "銅の素材をふんだんに使った鎧。物理防御６～１０。";
                    PhysicalDefenseMinValue = 6;
                    PhysicalDefenseMaxValue = 10;
                    cost = 1000;
                    AdditionalDescription(ItemType.Armor_Heavy);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_HEAVY_ARMOR:
                    description = "重量感を意識して作られた鎧。物理防御８～１２。";
                    PhysicalDefenseMinValue = 8;
                    PhysicalDefenseMaxValue = 12;
                    cost = 1400;
                    AdditionalDescription(ItemType.Armor_Heavy);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                // 盾(Common)
                case FIX.COMMON_IRON_SHIELD:
                    description = "鉄製の盾。それなりにガッチリしている。物理防御５～８";
                    PhysicalDefenseMinValue = 5;
                    PhysicalDefenseMaxValue = 8;
                    cost = 1020;
                    AdditionalDescription(ItemType.Shield);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                // Rare (３色ＵＰ）
                case FIX.RARE_SINTYUU_RING_KUROHEBI:
                    description = "真鍮素材で作られた腕輪。黒蛇の刻印がしてある。知＋１６、体＋５、心＋９";
                    buffUpIntelligence = 14;
                    buffUpStamina = 5;
                    buffUpMind = 9;
                    cost = 3400;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Rare;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.RARE_SINTYUU_RING_HAKUTYOU:
                    description = "真鍮素材で作られた腕輪。白鳥の刻印がしてある。技＋６、知＋８、心＋１６";
                    buffUpAgility = 6;
                    buffUpIntelligence = 12;
                    buffUpMind = 10;
                    cost = 3400;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Rare;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.RARE_SINTYUU_RING_AKAHYOU:
                    description = "真鍮素材で作られた腕輪。赤豹の刻印がしてある。力＋１７、技＋９、心＋４";
                    buffUpStrength = 15;
                    buffUpAgility = 9;
                    buffUpMind = 4;
                    cost = 3400;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Rare;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                // 武器（Rare)
                case FIX.RARE_ICE_SWORD:
                    description = "水属性で斬る事が可能な剣。【特殊能力：有】物理攻撃１８～２５";
                    useSpecialAbility = true;
                    PhysicalAttackMinValue = 18;
                    PhysicalAttackMaxValue = 25;
                    cost = 2100;
                    AdditionalDescription(ItemType.Weapon_Heavy);
                    rareLevel = RareLevel.Rare;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.RARE_RISING_KNUCKLE:
                    description = "力の加え方が軽い感触で、振りの速さを実感できる爪。【特殊能力：有】物理攻撃２０～２５";
                    useSpecialAbility = true;
                    PhysicalAttackMinValue = 20;
                    PhysicalAttackMaxValue = 25;
                    cost = 3400;
                    AdditionalDescription(ItemType.Weapon_Light);
                    rareLevel = RareLevel.Rare;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.RARE_AUTUMN_ROD:
                    description = "秋に生い茂った樹木の枝を採用した杖。【特殊能力：有】魔法攻撃１８～２２";
                    description += "\r\n【特殊能力】　MPを回復する。";
                    UseSpecialAbility = true;
                    MagicAttackMinValue = 18;
                    MagicAttackMaxValue = 22;
                    cost = 2800;
                    AdditionalDescription(ItemType.Weapon_Rod);
                    rareLevel = RareLevel.Rare;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                // 防具（Rare)
                case FIX.RARE_SUN_BRAVE_ARMOR:
                    description = "太陽の光が注入されている鎧。物理防御１４～１８。魔法防御力１０～１２。火耐性２０、聖耐性２０";
                    PhysicalDefenseMinValue = 14;
                    PhysicalDefenseMaxValue = 18;
                    MagicDefenseMinValue = 10;
                    MagicDefenseMaxValue = 12;
                    ResistFire = 20;
                    ResistLight = 20;
                    cost = 3000;
                    AdditionalDescription(ItemType.Armor_Heavy);
                    rareLevel = RareLevel.Rare;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                // 盾(Rare)
                case FIX.RARE_ESMERALDA_SHIELD:
                    description = "赤いコーティングと重量感のある盾。物理防御８～１２、火耐性２０";
                    PhysicalDefenseMinValue = 8;
                    PhysicalDefenseMaxValue = 12;
                    ResistFire = 20;
                    cost = 2200;
                    AdditionalDescription(ItemType.Shield);
                    rareLevel = RareLevel.Rare;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                #endregion
                #region "２階：ランダムドロップ"
                // 単一UP
                case FIX.POOR_HUANTEI_RING:
                    description = "確かな感触はあるが、時々不安にさせる腕輪。力＋１０、知＋４、体＋６";
                    buffUpStrength = 10;
                    buffUpIntelligence = 4;
                    buffUpStamina = 6;
                    cost = 1600;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Poor;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.POOR_DEPRESS_FEATHER:
                    description = "芯は通っているが、不運な感覚がつきまとう羽飾り。力＋９、技＋１０、心＋１";
                    buffUpStrength = 9;
                    buffUpAgility = 10;
                    buffUpMind = 1;
                    cost = 1600;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Poor;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.POOR_DAMAGED_ORB:
                    description = "輝きのあるオーブだが、所々が欠けている。技＋７、知＋１０、体＋３";
                    buffUpAgility = 7;
                    buffUpIntelligence = 10;
                    buffUpStamina = 3;
                    cost = 1600;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Poor;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.POOR_SHIMETSUKE_BELT:
                    description = "引き締まるベルトだが、少しキツすぎる感じがする。知＋４、体＋１０、心＋６";
                    buffUpIntelligence = 4;
                    buffUpStamina = 10;
                    buffUpMind = 6;
                    cost = 1600;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Poor;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.POOR_NOGENKEI_EMBLEM:
                    description = "イメージを想起させる紋章だが、原型を留めてない。力＋１０、体＋８、心＋２";
                    buffUpStrength = 10;
                    buffUpStamina = 8;
                    buffUpMind = 2;
                    cost = 1600;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Poor;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.POOR_MAGICLIGHT_FIRE:
                    description = "火の残影を宿しているマジックライト。火耐性１００";
                    ResistFire = 100;
                    cost = 4000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Poor;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.POOR_MAGICLIGHT_ICE:
                    description = "水の残影を宿しているマジックライト。水耐性１００";
                    ResistIce = 100;
                    cost = 4000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Poor;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.POOR_MAGICLIGHT_SHADOW:
                    description = "闇の残影を宿しているマジックライト。闇耐性１００";
                    ResistShadow = 100;
                    cost = 4000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Poor;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.POOR_MAGICLIGHT_LIGHT:
                    description = "聖の残影を宿しているマジックライト。聖耐性１００";
                    ResistLight = 100;
                    cost = 4000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Poor;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_RED_CHARM:
                    description = "赤の文様が刻み込まれている【力】を示すチャーム。力＋３０";
                    BuffUpStrength = 30;
                    cost = 7800;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_BLUE_CHARM:
                    description = "青の文様が刻み込まれている【技】を示すチャーム。技＋３０";
                    BuffUpAgility = 30;
                    cost = 7800;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_PURPLE_CHARM:
                    description = "紫の文様が刻み込まれている【知】を示すチャーム。知＋３０";
                    BuffUpIntelligence = 30;
                    cost = 7800;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_GREEN_CHARM:
                    description = "緑の文様が刻み込まれている【体】を示すチャーム。体＋３０";
                    BuffUpStamina = 30;
                    cost = 7800;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_YELLOW_CHARM:
                    description = "黄の文様が刻み込まれている【心】を示すチャーム。心＋３０";
                    BuffUpMind = 30;
                    cost = 7800;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_THREE_COLOR_COMPASS:
                    description = "良識を示すものに用意された三色のコンパス。知＋１５、体＋１０、心＋１０";
                    BuffUpIntelligence = 15;
                    BuffUpStamina = 10;
                    buffUpMind = 10;
                    cost = 6700;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_SANGO_CROWN:
                    description = "珊瑚の欠片が合わさり、たまたま冠の形となったもの。力＋１５、技＋１０、知＋１０";
                    BuffUpStrength = 15;
                    BuffUpAgility = 10;
                    BuffUpIntelligence = 10;
                    cost = 8500;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_SMOOTHER_BOOTS:
                    description = "靴底をより滑らかにし、軽やかな動きを実現。技＋１５、体＋１０、心＋１０";
                    BuffUpAgility = 15;
                    BuffUpStamina = 10;
                    BuffUpMind = 10;
                    cost = 7200;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_SHIOKAZE_MANTLE:
                    description = "潮風をふんだんに滲み込ませたマント。力＋１０、知＋２０、心＋５";
                    BuffUpStrength = 10;
                    BuffUpIntelligence = 20;
                    BuffUpMind = 5;
                    cost = 8800;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                // アクセサリ（Poor2)
                case FIX.POOR_CURSE_EARRING:
                    description = "綺麗なイヤリングだが、良い感触はしない。技＋９、知＋９、心＋２";
                    buffUpAgility = 9;
                    buffUpIntelligence = 9;
                    buffUpMind = 2;
                    cost = 7000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Poor;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.POOR_CURSE_BOOTS:
                    description = "装飾が良く、履くのは可能だが、足取りは重い。技＋７、体＋１０、心＋３";
                    buffUpAgility = 7;
                    buffUpStamina = 10;
                    buffUpMind = 3;
                    cost = 7000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Poor;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.POOR_BLOODY_STATUE:
                    description = "力の増強を感じさせる彫像だが、気分は晴れない。力＋１０、技＋７、体＋３";
                    buffUpStrength = 10;
                    buffUpAgility = 7;
                    buffUpMind = 3;
                    cost = 7000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Poor;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.POOR_FALLEN_MANTLE:
                    description = "堕ちた術者が用いていたマント。力＋７、知＋１２、心＋１";
                    buffUpStrength = 7;
                    buffUpIntelligence = 12;
                    buffUpMind = 1;
                    cost = 7000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Poor;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.POOR_SIHAIRYU_SIKOTU:
                    description = "ラグンタット各地に潜む「支配竜」の指の骨。物攻率＋３％";
                    amplifyPhysicalAttack = 1.03f;
                    cost = 8000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Poor;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.POOR_OLD_TREE_KAREHA:
                    description = "ラグンタット大地に眠る「古代栄樹」の枯れ葉。魔攻率＋３％";
                    amplifyMagicAttack = 1.03f;
                    cost = 8000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Poor;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.POOR_GALEWIND_KONSEKI:
                    description = "ラグンタット山脈の神「ゲイル・ウィンド」の痕跡。戦速率＋３％";
                    amplifyBattleSpeed = 1.03f;
                    cost = 8000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Poor;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.POOR_SIN_CRYSTAL_KAKERA:
                    description = "ラグンタット古代技術「シン・クリスタル」の欠片。戦応率＋３％";
                    amplifyBattleResponse = 1.03f;
                    ResistWill = 1200;
                    cost = 8000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Poor;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.POOR_EVERMIND_ZANSHI:
                    description = "ラグンタット天空の主「エバー・マインド」の残留思念。潜力率＋３％";
                    amplifyPotential = 1.03f;
                    cost = 8000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Poor;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                // アクセサリ（Common2）
                case FIX.COMMON_BRONZE_RING_KIBA:
                    description = "青銅素材で作られた腕輪。牙の刻印がしてある。力＋２４、技＋１６";
                    buffUpStrength = 24;
                    buffUpAgility = 16;
                    cost = 14000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_BRONZE_RING_SASU:
                    description = "青銅素材で作られた腕輪。刺の刻印がしてある。力＋１６、知＋２４";
                    buffUpStrength = 16;
                    buffUpIntelligence = 24;
                    cost = 14000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_BRONZE_RING_KU:
                    description = "青銅素材で作られた腕輪。駆の刻印がしてある。力＋２４、体＋１６";
                    buffUpStrength = 24;
                    buffUpStamina = 16;
                    cost = 14000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_BRONZE_RING_NAGURI:
                    description = "青銅素材で作られた腕輪。殴の刻印がしてある。力＋１６、心＋２４";
                    buffUpStrength = 16;
                    buffUpMind = 24;
                    cost = 14000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_BRONZE_RING_TOBI:
                    description = "青銅素材で作られた腕輪。飛の刻印がしてある。技＋２４、知＋１６";
                    buffUpAgility = 24;
                    buffUpIntelligence = 16;
                    cost = 14000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_BRONZE_RING_KARAMU:
                    description = "青銅素材で作られた腕輪。絡の刻印がしてある。技＋１６、体＋２４";
                    buffUpAgility = 16;
                    buffUpStamina = 24;
                    cost = 14000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_BRONZE_RING_HANERU:
                    description = "青銅素材で作られた腕輪。跳の刻印がしてある。技＋２４、心＋１６";
                    buffUpAgility = 24;
                    buffUpMind = 16;
                    cost = 14000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_BRONZE_RING_TORU:
                    description = "青銅素材で作られた腕輪。補の刻印がしてある。知＋２４、体＋１６";
                    buffUpIntelligence = 24;
                    buffUpStamina = 16;
                    cost = 14000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_BRONZE_RING_MIRU:
                    description = "青銅素材で作られた腕輪。視の刻印がしてある。知＋１６、心＋２４";
                    buffUpIntelligence = 16;
                    buffUpMind = 24;
                    cost = 14000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_BRONZE_RING_KATAI:
                    description = "青銅素材で作られた腕輪。堅の刻印がしてある。体＋２４、心＋１６";
                    buffUpStamina = 24;
                    buffUpMind = 16;
                    cost = 14000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_RED_KOKUIN:
                    description = "赤を宿らせている刻印、それは【力】を示す。力＋５０";
                    BuffUpStrength = 50;
                    cost = 15000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_BLUE_KOKUIN:
                    description = "青を宿らせている刻印、それは【技】を示す。技＋５０";
                    BuffUpAgility = 50;
                    cost = 15000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_PURPLE_KOKUIN:
                    description = "紫を宿らせている刻印、それは【知】を示す。知＋５０";
                    BuffUpIntelligence = 50;
                    cost = 15000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_GREEN_KOKUIN:
                    description = "緑を宿らせている刻印、それは【体】を示す。体＋５０";
                    BuffUpStamina = 50;
                    cost = 15000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_YELLOW_KOKUIN:
                    description = "黄を宿らせている刻印、それは【心】を示す。心＋５０";
                    BuffUpMind = 50;
                    cost = 15000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_SISSEI_MANTLE:
                    description = "執政官が常用している厳格なマント。力＋１５、知＋３０、心＋１５";
                    buffUpStrength = 15;
                    buffUpAgility = 30;
                    buffUpMind = 15;
                    cost = 16000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_KAISEI_EMBLEM:
                    description = "覗き込むと、青空が見渡せる形状の紋章。力＋３０、体＋１５、心＋１５";
                    buffUpStrength = 30;
                    buffUpStamina = 15;
                    buffUpMind = 15;
                    cost = 16000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_SAZANAMI_EARRING:
                    description = "耳に装着すると小波の音が聞こえてくる。技＋１５、知＋１５、心＋３０";
                    buffUpAgility = 15;
                    buffUpIntelligence = 15;
                    buffUpMind = 30;
                    cost = 16000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_AMEODORI_STATUE:
                    description = "水の飛沫をリズムよく感じさせてくれる彫像。力＋１５、技＋３０、体＋１５";
                    buffUpStrength = 15;
                    buffUpAgility = 30;
                    buffUpStamina = 15;
                    cost = 16000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                #region "合成１階"
                case FIX.COMMON_KOUKAKU_ARMOR: // ワームの甲殻
                    description = "甲殻部を繋ぎ合わせた鎧に、魔法耐性を若干付与させた一品。物理防御１１～１５。火耐性２０";
                    PhysicalDefenseMinValue = 11;
                    PhysicalDefenseMaxValue = 15;
                    this.ResistFire = 20;
                    cost = 1800;
                    AdditionalDescription(ItemType.Armor_Heavy);
                    rareLevel = RareLevel.Common;
                    break;

                case FIX.COMMON_SISSO_TUKEHANE: // 鷹の白羽、太陽の葉
                    description = "毛皮に幾つかの白羽を埋め込んだアクセサリ。力＋３、技＋３、心＋３";
                    BuffUpStrength = 3;
                    BuffUpAgility = 3;
                    BuffUpMind = 3;
                    cost = 2500;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    break;

                case FIX.RARE_WAR_WOLF_BLADE: // 刺の生えた触手、狼の牙
                    description = "狼の牙を基素材とし、刺付き触手を加工した武器。物理攻撃３２～４４";
                    PhysicalAttackMinValue = 32;
                    PhysicalAttackMaxValue = 44;
                    cost = 3600;
                    AdditionalDescription(ItemType.Weapon_Heavy);
                    rareLevel = RareLevel.Rare;
                    break;

                case FIX.COMMON_BLUE_COPPER_ARMOR_KAI:
                    description = "青銅の材質強度を落とさずに仕上げられた鎧。物理防御２０～２５。";
                    PhysicalDefenseMinValue = 20;
                    PhysicalDefenseMaxValue = 25;
                    cost = 3200;
                    AdditionalDescription(ItemType.Armor_Heavy);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_RABBIT_SHOES: // ウサギの毛皮、スパイダーシルク
                    description = "ウサギの毛皮と質の良いスパイダーシルクを合成した出来たシューズ。技＋１２、体力＋１０";
                    BuffUpAgility = 12;
                    BuffUpStamina = 10;
                    cost = 3200;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    break;

                case FIX.RARE_MISTSCALE_SHIELD:
                    description = "通常のスケイルシールドに霧が塗されている。物理防御４０～４５、魔法防御４０～４５";
                    cost = 4500;
                    PhysicalDefenseMinValue = 40;
                    PhysicalDefenseMaxValue = 45;
                    MagicDefenseMinValue = 40;
                    MagicDefenseMaxValue = 45;
                    AdditionalDescription(ItemType.Shield);
                    rareLevel = RareLevel.Rare;
                    break;

                #endregion
                // アクセサリ（Rare2）
                case FIX.RARE_RING_BRONZE_RING_KONSHIN:
                    description = "燐青銅素材で作られた腕輪。渾身の刻印がされている。力＋４８、技＋１３、体＋１２、心＋１７";
                    buffUpStrength = 48;
                    buffUpAgility = 13;
                    buffUpStamina = 12;
                    buffUpMind = 17;
                    cost = 35000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Rare;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.RARE_RING_BRONZE_RING_SYUNSOKU:
                    description = "燐青銅素材で作られた腕輪。俊足の刻印がされている。技＋４７、知＋１１、体＋１３、心＋１９";
                    buffUpAgility = 47;
                    buffUpIntelligence = 11;
                    buffUpStamina = 13;
                    buffUpMind = 19;
                    cost = 35000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Rare;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.RARE_RING_BRONZE_RING_JUKURYO:
                    description = "燐青銅素材で作られた腕輪。熟慮の刻印がされている。力＋１２、技＋１７、知＋４５、体＋１６";
                    buffUpStrength = 12;
                    buffUpAgility = 17;
                    buffUpIntelligence = 45;
                    buffUpStamina = 16;
                    cost = 35000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Rare;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.RARE_RING_BRONZE_RING_SOUGEN:
                    description = "燐青銅素材で作られた腕輪。爽源の刻印がされている。力＋１３、知＋１５、体＋４６、心＋１６";
                    buffUpStrength = 13;
                    buffUpIntelligence = 15;
                    buffUpStamina = 46;
                    buffUpMind = 116;
                    cost = 35000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Rare;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.RARE_RING_BRONZE_RING_YUUDAI:
                    description = "燐青銅素材で作られた腕輪。雄大の刻印がされている。力＋１１、技＋１８、知＋１２、心＋４９";
                    buffUpStrength = 11;
                    buffUpAgility = 18;
                    buffUpIntelligence = 12;
                    buffUpMind = 49;
                    cost = 35000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Rare;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.RARE_MEIUN_BOX:
                    description = "己の命運を掛けて開かれる箱。【特殊能力：有】力＋２０、技＋２０、知＋２０、体＋２０、心＋２０";
                    buffUpStrength = 20;
                    buffUpAgility = 20;
                    buffUpIntelligence = 20;
                    buffUpStamina = 20;
                    buffUpMind = 20;
                    cost = 41000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Rare;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.RARE_WILL_HOLY_HAT:
                    description = "強い意志を放つ聖オーラを浴びたマジシャンズハット。知＋４５、心＋４５、聖耐性＋３００";
                    buffUpIntelligence = 45;
                    buffUpMind = 45;
                    ResistLight = 300;
                    cost = 43000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Rare;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.RARE_EMBLEM_BLUESTAR:
                    description = "海の王子が産み出したと言われている海星の紋章。力＋４５、知＋４５、水耐性＋３００";
                    buffUpStrength = 45;
                    buffUpIntelligence = 45;
                    ResistIce = 300;
                    cost = 43000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Rare;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.RARE_SEAL_OF_DEATH:
                    description = "死への抵抗力を研究する者が没頭し、産み出した処女作品。体＋４５、心＋４５、闇耐性＋３００";
                    buffUpStamina = 45;
                    buffUpMind = 45;
                    ResistShadow = 300;
                    cost = 43000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Rare;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                // アクセサリ（ガンツ初版）２階
                case FIX.RARE_WILD_HEART_SPADE:
                    description = "剣の象徴としてスペードの刻印を刻んだブレスレット。力＋６５、心＋３５";
                    buffUpStrength = 65;
                    buffUpMind = 35;
                    cost = 30000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Rare;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                // アクセサリ（ガンツ合成）２階
                case FIX.COMMON_WHITE_WAVE_RING: // 白の勾玉、青の勾玉
                    description = "勾玉からエッセンスを引き出し、リング形状として合成した。力＋１０、知＋１０、体＋５０";
                    buffUpStrength = 10;
                    buffUpIntelligence = 10;
                    buffUpStamina = 50;
                    cost = 20000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    break;
                case FIX.COMMON_NEEDLE_FEATHER: // 青白の鋭いトゲ、鷲の青羽
                    description = "鋭いトゲと幸運を呼ぶ青羽をうまく融合させた付け羽。力＋１０、技＋５０、心＋１０";
                    buffUpStrength = 10;
                    buffUpAgility = 50;
                    buffUpMind = 10;
                    cost = 23000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    break;
                case FIX.COMMON_KOUSHITU_ORB: // ゴツゴツした殻
                    description = "幾つもの殻を溶解し、一つの球状に仕立てあげた一品。技＋１０、知＋５０、体＋１０";
                    BuffUpAgility = 10;
                    BuffUpIntelligence = 50;
                    BuffUpStamina = 10;
                    cost = 21000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    break;
                // 宝箱２階
                case FIX.COMMON_PUZZLE_BOX:
                    description = "パズルの種が沢山収納されている箱。知＋４０、心＋１０";
                    buffUpIntelligence = 40;
                    buffUpMind = 10;
                    cost = 16000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    break;
                case FIX.COMMON_CHIENOWA_RING:
                    description = "高い知力が試されるリング。考えていると力が沸く。【特殊能力：有】知＋３０";
                    useSpecialAbility = true;
                    buffUpIntelligence = 30;
                    cost = 19500;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    break;
                case FIX.RARE_MASTER_PIECE:
                    description = "知力のあるものが産み出した名作品。力＋１０、技＋１０、知＋６０、体＋１０、心＋１０";
                    buffUpStrength = 10;
                    buffUpAgility = 10;
                    buffUpIntelligence = 60;
                    buffUpStamina = 10;
                    buffUpMind = 10;
                    cost = 33000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Rare;
                    break;
                case FIX.COMMON_TUMUJIKAZE_BOX:
                    description = "つむじ風が収納されている箱。技＋４０、心＋１０";
                    buffUpAgility = 40;
                    buffUpMind = 10;
                    cost = 16000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    break;
                case FIX.COMMON_ROCKET_DASH:
                    description = "ロケット型のブーツ。使うと物凄い速度で逆噴射する・・・。【特殊能力：有】技＋３０";
                    useSpecialAbility = true;
                    buffUpAgility = 30;
                    cost = 14000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    break;
                case FIX.COMMON_CLAW_OF_SPRING:
                    description = "春の風を漂わせる爪。振るとほんのり桜が見えるらしい。物理攻撃３２～４２、技＋２０";
                    PhysicalAttackMinValue = 32;
                    PhysicalAttackMaxValue = 42;
                    buffUpAgility = 20;
                    cost = 15000;
                    AdditionalDescription(ItemType.Weapon_Light);
                    rareLevel = RareLevel.Common;
                    break;
                case FIX.COMMON_BREEZE_CROSS:
                    description = "そよ風をほのかに感じられ、身を軽やかに動かせる舞踏衣。物理防御２０～２２、技＋２０";
                    PhysicalDefenseMinValue = 20;
                    PhysicalDefenseMaxValue = 22;
                    buffUpAgility = 20;
                    cost = 17500;
                    AdditionalDescription(ItemType.Armor_Light);
                    rareLevel = RareLevel.Common;
                    break;
                case FIX.COMMON_GUST_SWORD:
                    description = "突風の如く突き出せてしまう剣。物理攻撃３２～４２、技＋２０";
                    PhysicalAttackMinValue = 32;
                    PhysicalAttackMaxValue = 42;
                    buffUpAgility = 20;
                    cost = 17500;
                    AdditionalDescription(ItemType.Weapon_Heavy);
                    rareLevel = RareLevel.Common;
                    break;
                case FIX.COMMON_BLANK_BOX:
                    description = "何も無い箱だが奇妙な事に、心の支えを感じられる。体＋１０、心＋４０";
                    buffUpStamina = 10;
                    buffUpMind = 40;
                    cost = 16000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    break;
                case FIX.RARE_SPIRIT_OF_HEART:
                    description = "この聖杯の中には心が込められていると謳われている。力＋１０、技＋１０、知＋１０、体＋１０、心＋６０";
                    buffUpStrength = 10;
                    buffUpAgility = 10;
                    buffUpIntelligence = 10;
                    buffUpStamina = 10;
                    buffUpMind = 60;
                    cost = 33000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Rare;
                    break;
                case FIX.COMMON_FUSION_BOX:
                    description = "力の源が融合されている箱。力＋４０、心＋１０";
                    buffUpStrength = 40;
                    buffUpMind = 10;
                    cost = 16000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    break;
                case FIX.COMMON_WAR_DRUM:
                    description = "パワーアップ用の音楽を即興で出来るドラム。【特殊能力：有】力＋３０";
                    useSpecialAbility = true;
                    buffUpStrength = 30;
                    cost = 16000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    break;
                case FIX.COMMON_KOBUSHI_OBJE:
                    description = "拳の形をしたオブジェ。何となくパワーを感じる。力＋４５、体＋５、心＋５";
                    buffUpStrength = 45;
                    buffUpStamina = 5;
                    buffUpMind = 5;
                    cost = 17200;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    break;
                case FIX.COMMON_TIGER_BLADE:
                    description = "剣を振るった時、虎の吠える声に似た音がする。物理攻撃７２～７８、力＋２０";
                    PhysicalAttackMinValue = 72;
                    PhysicalAttackMaxValue = 78;
                    buffUpStrength = 20;
                    cost = 24000;
                    AdditionalDescription(ItemType.Weapon_Heavy);
                    rareLevel = RareLevel.Common;
                    break;
                case FIX.RARE_ROD_OF_STRENGTH:
                    description = "【力】そのものを宿らせている魔法の杖。【特殊能力：有】魔法攻撃９２～１０１、力＋３０";
                    MagicAttackMinValue = 92;
                    MagicAttackMaxValue = 101;
                    buffUpStrength = 30;
                    cost = 41000;
                    AdditionalDescription(ItemType.Weapon_Rod);
                    rareLevel = RareLevel.Rare;
                    break;
                case FIX.COMMON_SOUKAI_DRINK_WATER:
                    description = "スッキリ爽快になるドリンク剤の原液。そのままでは苦すぎる・・・";
                    cost = 42000;
                    AdditionalDescription(ItemType.Material_Potion);
                    rareLevel = RareLevel.Common;
                    break;
                case FIX.COMMON_TUUKAI_DRINK_WATER:
                    description = "ガッツリ痛快になるドリンク剤の原液。そのままでは苦すぎる・・・";
                    cost = 42000;
                    AdditionalDescription(ItemType.Material_Potion);
                    rareLevel = RareLevel.Common;
                    break;
                case FIX.RARE_SOUJUTENSHI_NO_GOFU:
                    description = "蒼授天使からの強力な加護を得る。体力＋２０　【沈黙】【スタン】耐性を付与。";
                    buffUpStamina = 20;
                    ResistSilence = true;
                    ResistStun = true;
                    cost = 44000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Rare;
                    break;

                // 武器(Common)
                case FIX.COMMON_SMART_SWORD:
                    description = "サッと良い斬れ味のする剣。物理攻撃４０～５０";
                    PhysicalAttackMinValue = 40;
                    PhysicalAttackMaxValue = 50;
                    cost = 6000;
                    AdditionalDescription(ItemType.Weapon_Heavy);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_SMART_CLAW:
                    description = "サクサクっと心地良く引っ掻ける爪。物理攻撃３０～４０";
                    PhysicalAttackMinValue = 30;
                    PhysicalAttackMaxValue = 40;
                    cost = 5000;
                    AdditionalDescription(ItemType.Weapon_Light);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_SMART_ROD:
                    description = "重量も軽く、ヒョイヒョイと振ることが出来る杖。魔法攻撃３５～４５";
                    MagicAttackMinValue = 35;
                    MagicAttackMaxValue = 45;
                    cost = 4500;
                    AdditionalDescription(ItemType.Weapon_Rod);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_RAUGE_SWORD:
                    description = "かなり質感があり重たいが、威力は期待できる両手剣。物理攻撃２０～８０";
                    PhysicalAttackMinValue = 20;
                    PhysicalAttackMaxValue = 80;
                    cost = 7000;
                    AdditionalDescription(ItemType.Weapon_TwoHand);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                // 武器（Rare）
                case FIX.RARE_WRATH_SERVEL_CLAW:
                    description = "憤怒のオーラを宿した切っ先のスルドイ爪。【特殊能力：有】物理攻撃５５～７０";
                    useSpecialAbility = true;
                    PhysicalAttackMinValue = 55;
                    PhysicalAttackMaxValue = 70;
                    cost = 13000;
                    AdditionalDescription(ItemType.Weapon_Light);
                    rareLevel = RareLevel.Rare;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.RARE_BLUE_LIGHTNING:
                    description = "青い閃光が宿っている剣。【特殊能力：有】物理攻撃６３～８５";
                    useSpecialAbility = true;
                    PhysicalAttackMinValue = 63;
                    PhysicalAttackMaxValue = 85;
                    cost = 15500;
                    AdditionalDescription(ItemType.Weapon_Heavy);
                    rareLevel = RareLevel.Rare;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.RARE_BURNING_CLAYMORE:
                    description = "鮮やかな赤い火の粉が舞う真鍮製クレイモア。【特殊能力：有】物理攻撃４０～１２０";
                    useSpecialAbility = true;
                    PhysicalAttackMinValue = 40;
                    PhysicalAttackMaxValue = 120;
                    cost = 14000;
                    AdditionalDescription(ItemType.Weapon_TwoHand);
                    rareLevel = RareLevel.Rare;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                // 武器（Common2）
                case FIX.COMMON_SMASH_BLADE:
                    description = "素振りレベルでも打撃感が持てる剣。物理攻撃５５～７０";
                    PhysicalAttackMinValue = 55;
                    PhysicalAttackMaxValue = 70;
                    cost = 7500;
                    AdditionalDescription(ItemType.Weapon_Heavy);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_POWERED_BUSTER:
                    description = "精一杯の力を込めて放てば威力はデカイ！物理攻撃５０～１４５";
                    PhysicalAttackMinValue = 50;
                    PhysicalAttackMaxValue = 145;
                    cost = 15000;
                    AdditionalDescription(ItemType.Weapon_TwoHand);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_STONE_CLAW:
                    description = "石製でありつつ、身軽に触れる爪。物理攻撃４２～５４";
                    PhysicalAttackMinValue = 42;
                    PhysicalAttackMaxValue = 54;
                    cost = 6700;
                    AdditionalDescription(ItemType.Weapon_Light);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_DENDOU_ROD:
                    description = "持つと少しだけ電気が走る杖。魔法攻撃４６～６２";
                    MagicAttackMinValue = 46;
                    MagicAttackMaxValue = 62;
                    cost = 6000;
                    AdditionalDescription(ItemType.Weapon_Rod);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                // 武器（Rare2）
                case FIX.RARE_DARKNESS_SWORD:
                    description = "闇を取り込み魔力を有している剣。物理攻撃６０～８０、魔法攻撃６０～８０";
                    PhysicalAttackMinValue = 60;
                    PhysicalAttackMaxValue = 80;
                    MagicAttackMinValue = 60;
                    MagicAttackMaxValue = 80;
                    cost = 15000;
                    AdditionalDescription(ItemType.Weapon_Heavy);
                    rareLevel = RareLevel.Rare;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.RARE_BLUE_RED_ROD:
                    description = "相反する赤と蒼の魔力を宿した杖。【特殊能力：有】魔法攻撃７０～８５";
                    useSpecialAbility = true;
                    MagicAttackMinValue = 70;
                    MagicAttackMaxValue = 85;
                    cost = 11500;
                    AdditionalDescription(ItemType.Weapon_Heavy);
                    rareLevel = RareLevel.Rare;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                // 武器（ガンツ２階）
                case FIX.COMMON_SMART_SWORD_2:
                    description = "サッと良い斬れ味のする剣をガンツが強化した。物理攻撃４０(+8)～５０(+8)";
                    PhysicalAttackMinValue = 48;
                    PhysicalAttackMaxValue = 58;
                    cost = 6500;
                    AdditionalDescription(ItemType.Weapon_Heavy);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_SMART_CLAW_2:
                    description = "サクサクっと心地良く引っ掻ける爪をガンツが強化した。物理攻撃３０(+7)～４０(+7)";
                    PhysicalAttackMinValue = 37;
                    PhysicalAttackMaxValue = 47;
                    cost = 5800;
                    AdditionalDescription(ItemType.Weapon_Light);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_SMART_ROD_2:
                    description = "重量も軽く、ヒョイヒョイと振ることが出来る杖をガンツが強化した。魔法攻撃３５(+6)～４５(+6)";
                    MagicAttackMinValue = 41;
                    MagicAttackMaxValue = 51;
                    cost = 5200;
                    AdditionalDescription(ItemType.Weapon_Rod);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_SMART_PLATE_2:
                    description = "ガッチリした鎧をさらにガンツが強化した鎧。物理防御３０(+5)～３５(+5)";
                    PhysicalDefenseMinValue = 35;
                    PhysicalDefenseMaxValue = 40;
                    cost = 6000;
                    AdditionalDescription(ItemType.Armor_Heavy);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_SMART_CLOTHING_2:
                    description = "着心地も良く、動きやすさも抜群の舞踏衣。物理防御２５(+4)～２８(+4)";
                    PhysicalDefenseMinValue = 29;
                    PhysicalDefenseMaxValue = 32;
                    cost = 5300;
                    AdditionalDescription(ItemType.Armor_Middle);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_SMART_ROBE_2:
                    description = "スラリとしたデザインを追求した戦闘向けローブ。物理防御１０(+4)～１２(+4)。魔法防御２０(+5)～２２(+5)";
                    PhysicalDefenseMinValue = 14;
                    PhysicalDefenseMaxValue = 16;
                    MagicDefenseMinValue = 25;
                    MagicDefenseMaxValue = 27;
                    cost = 6400;
                    AdditionalDescription(ItemType.Armor_Light);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_RAUGE_SWORD_2:
                    description = "かなり質感があり重たいが、威力は期待できる両手剣。物理攻撃２０(+10)～８０(+15)";
                    PhysicalAttackMinValue = 30;
                    PhysicalAttackMaxValue = 95;
                    cost = 8000;
                    AdditionalDescription(ItemType.Weapon_TwoHand);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_SMART_SHIELD_2:
                    description = "持ちやすく、向きもスッと変えられる盾をガンツが強化した。物理防御１２(+3)～１５(+3)";
                    PhysicalDefenseMinValue = 15;
                    PhysicalDefenseMaxValue = 18;
                    cost = 4100;
                    AdditionalDescription(ItemType.Shield);
                    rareLevel = RareLevel.Common;
                    break;

                case FIX.COMMON_STEEL_SWORD:
                    description = "ガンツが丹念に磨き上げたスチール製の剣。物理攻撃８０(+8)～９０(+9)";
                    PhysicalAttackMinValue = 88;
                    PhysicalAttackMaxValue = 99;
                    cost = 16000;
                    AdditionalDescription(ItemType.Weapon_Heavy);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_FACILITY_CLAW:
                    description = "ガンツ直伝の改良を重ねて完成された爪。物理攻撃６５(+2)～７０(+5)";
                    PhysicalAttackMinValue = 67;
                    PhysicalAttackMaxValue = 76;
                    cost = 13500;
                    AdditionalDescription(ItemType.Weapon_Light);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_MIX_HINOKI_ROD:
                    description = "檜素材に金属製素材を合成させた杖。魔法攻撃８２～９６";
                    MagicAttackMinValue = 82;
                    MagicAttackMaxValue = 96;
                    cost = 13000;
                    AdditionalDescription(ItemType.Weapon_Rod);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.RARE_RED_ARM_BLADE:
                    description = "豪腕なジョーの腕を加工し、赤褐色でコーティングを施した剣。物理攻撃１０１～１１３";
                    PhysicalAttackMinValue = 101;
                    PhysicalAttackMaxValue = 113;
                    cost = 27000;
                    AdditionalDescription(ItemType.Weapon_Heavy);
                    rareLevel = RareLevel.Rare;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.RARE_STRONG_SERPENT_CLAW:
                    description = "強固な青鮫の剣歯を更に高質化させ、高熱で磨いだ爪。物理攻撃７５～９１";
                    PhysicalAttackMinValue = 75;
                    PhysicalAttackMaxValue = 91;
                    cost = 24000;
                    AdditionalDescription(ItemType.Weapon_Light);
                    rareLevel = RareLevel.Rare;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                #endregion
                #region "３階：ランダムドロップ"
                case FIX.POOR_DIRTY_ANGEL_CONTRACT:
                    description = "利用価値が発揮される事なく、打ち捨てられた契約書。全耐性付与。戦闘中に一度でも効果発動した場合、戦闘終了後に壊れる。";
                    cost = 100000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Poor;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.POOR_JUNK_TARISMAN_FROZEN:
                    description = "今にも壊れそうな【凍結】保護タリスマン。【凍結】耐性付与。戦闘中に一度でも効果発動した場合、戦闘終了後に壊れる。";
                    cost = 80000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Poor;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.POOR_JUNK_TARISMAN_PARALYZE:
                    description = "今にも壊れそうな【麻痺】保護タリスマン。【麻痺】耐性付与。戦闘中に一度でも効果発動した場合、戦闘終了後に壊れる。";
                    cost = 80000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Poor;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.POOR_JUNK_TARISMAN_STUN:
                    description = "今にも壊れそうな【スタン】保護タリスマン。【スタン】耐性付与。戦闘中に一度でも効果発動した場合、戦闘終了後に壊れる。";
                    cost = 80000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Poor;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_RED_STONE:
                    description = "強力な赤の鼓動を感じさせる石。力＋７５";
                    buffUpStrength = 75;
                    cost = 140000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_BLUE_STONE:
                    description = "強力な青の鼓動を感じさせる石。技＋７５";
                    buffUpAgility = 75;
                    cost = 140000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_PURPLE_STONE:
                    description = "強力な紫の鼓動を感じさせる石。知＋７５";
                    buffUpIntelligence = 75;
                    cost = 140000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_GREEN_STONE:
                    description = "強力な緑の鼓動を感じさせる石。体＋７５";
                    buffUpStamina = 75;
                    cost = 140000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_YELLOW_STONE:
                    description = "強力な黄の鼓動を感じさせる石。心＋７５";
                    buffUpMind = 75;
                    cost = 140000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.POOR_MIGAWARI_DOOL:
                    description = "装着者の身代わりを果たす魔除けの人形。装備者死亡時、ライフ１で生き残る。一度効果発動すると壊れる。";
                    cost = 180000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Poor;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.POOR_ONE_DROPLET_KESSYOU:
                    description = "一滴の雫が装着者の助けとなる。現在マナ量が１０％を切った場合、マナを５０％まで回復する。一度効果発動すると壊れる。";
                    cost = 180000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Poor;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.POOR_MOMENTARY_FLASH_LIGHT:
                    description = "一瞬の光が装着者の助けとなる。現在ライフ量が１０％を切った場合、ライフを５０％まで回復する。一度効果発動すると壊れる。";
                    cost = 180000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Poor;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.POOR_SUN_YUME_KAKERA:
                    description = "一寸の夢が装着者の助けとなる。現在スキル量が１０％を切った場合、スキルを５０％まで回復する。一度効果発動すると壊れる。";
                    cost = 180000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Poor;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_STEEL_RING_1:
                    description = "鋼の素材で作られた腕輪。『パワー』の印字が刻まれている。力＋４５、技＋３０";
                    buffUpStrength = 45;
                    buffUpAgility = 30;
                    cost = 200000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_STEEL_RING_2:
                    description = "鋼の素材で作られた腕輪。『センス』の印字が刻まれている。力＋３０、知＋４５";
                    buffUpStrength = 30;
                    buffUpIntelligence = 45;
                    cost = 200000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_STEEL_RING_3:
                    description = "鋼の素材で作られた腕輪。『タフ』の印字が刻まれている。力＋４５、体＋３０";
                    buffUpStrength = 45;
                    buffUpStamina = 30;
                    cost = 200000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_STEEL_RING_4:
                    description = "鋼の素材で作られた腕輪。『ロック』の印字が刻まれている。力＋３０、心＋４５";
                    buffUpStrength = 30;
                    buffUpMind = 45;
                    cost = 200000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_STEEL_RING_5:
                    description = "鋼の素材で作られた腕輪。『ファスト』の印字が刻まれている。技＋４５、知＋３０";
                    buffUpAgility = 45;
                    buffUpIntelligence = 30;
                    cost = 200000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_STEEL_RING_6:
                    description = "鋼の素材で作られた腕輪。『シャープ』の印字が刻まれている。技＋３０、体＋４５";
                    buffUpAgility = 30;
                    buffUpStamina = 45;
                    cost = 200000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_STEEL_RING_7:
                    description = "鋼の素材で作られた腕輪。『ハイ』の印字が刻まれている。技＋４５、心＋３０";
                    buffUpAgility = 45;
                    buffUpMind = 30;
                    cost = 200000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_STEEL_RING_8:
                    description = "鋼の素材で作られた腕輪。『ディープ』の印字が刻まれている。知＋４５、体＋３０";
                    buffUpIntelligence = 45;
                    buffUpStamina = 30;
                    cost = 200000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_STEEL_RING_9:
                    description = "鋼の素材で作られた腕輪。『バウンド』の印字が刻まれている。知＋３０、心＋４５";
                    buffUpIntelligence = 30;
                    buffUpMind = 45;
                    cost = 200000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_STEEL_RING_10:
                    description = "鋼の素材で作られた腕輪。『エモート』の印字が刻まれている。体＋４５、心＋３０";
                    buffUpStamina = 45;
                    buffUpMind = 30;
                    cost = 200000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_RED_MASEKI:
                    description = "凛と光る赤い魔石からは自然に湧き出るような【力】を感じる。力＋１０５";
                    buffUpStrength = 105;
                    cost = 220000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_BLUE_MASEKI:
                    description = "凛と光る紫の魔石からは自然に湧き出るような【技】を感じる。技＋１０５";
                    buffUpAgility = 105;
                    cost = 220000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_PURPLE_MASEKI:
                    description = "凛と光る紫の魔石からは自然に湧き出るような【知】を感じる。知＋１０５";
                    buffUpIntelligence = 105;
                    cost = 220000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_GREEN_MASEKI:
                    description = "凛と光る緑の魔石からは自然に湧き出るような【体】を感じる。体＋１０５";
                    buffUpStamina = 105;
                    cost = 220000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_YELLOW_MASEKI:
                    description = "凛と光る黄の魔石からは自然に湧き出るような【心】を感じる。心＋１０５";
                    buffUpMind = 105;
                    cost = 220000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_WING_STEP_FEATHER:
                    description = "軽やかにムダなく走れる羽根つきブーツ。技＋６０、スタン耐性";
                    buffUpAgility = 60;
                    ResistStun = true;
                    cost = 210000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_SNOW_FAIRY_BREATH:
                    description = "雪の妖精からのささやかな加護を感じられる。心＋６０、沈黙耐性";
                    buffUpMind = 60;
                    ResistSilence = true;
                    cost = 215000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_SILENT_BOWL:
                    description = "微かな振動を伴いつつ、バウンドしても全く音がしないボール。知＋６０、麻痺耐性";
                    buffUpIntelligence = 60;
                    ResistParalyze = true;
                    cost = 220000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_STASIS_RING:
                    description = "使用された形式がなく、時間が止まってしまったかのようなリング。体＋６０、スタン耐性";
                    buffUpStamina = 60;
                    ResistStun = true;
                    cost = 225000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_WATERY_GROBE:
                    description = "小さな水の球体が、身体の周囲をゆっくり旋回する。沈黙耐性、麻痺耐性、スタン耐性";
                    ResistStun = true;
                    ResistParalyze = true;
                    ResistSilence = true;
                    cost = 230000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.RARE_FROZEN_LAVA:
                    description = "射出された溶岩が瞬間的に凍結された物体。【特殊能力：有】知＋５０、心＋５０、水耐性５００、火耐性５００";
                    description += "\r\n【特殊能力】　魔法「フレイム・ストライク」または魔法「フローズン・ランス」を発動する。";
                    buffUpIntelligence = 50;
                    buffUpMind = 50;
                    ResistIce = 500;
                    ResistFire = 500;
                    useSpecialAbility = true;
                    cost = 400000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Rare;
                    limitValue = RARE_EPIC_ITEM_STACK_SIZE;
                    break;

                case FIX.RARE_SEAL_OF_ICE:
                    description = "射出された溶岩が瞬間的に凍結された物体。【特殊能力：有】水耐性１０００、麻痺耐性、凍結耐性";
                    buffUpIntelligence = 70;
                    buffUpStamina = 70;
                    ResistIce = 1000;
                    ResistParalyze = true;
                    ResistFrozen = true;
                    cost = 405000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Rare;
                    limitValue = RARE_EPIC_ITEM_STACK_SIZE;
                    break;

                case FIX.RARE_TAMATEBAKO_AKIDAMA:
                    description = "開かれた玉手箱、その中には驚きの効果が眠っている。【特殊能力：有】体＋７０、心＋７０";
                    description += "\r\n【特殊能力】　戦闘中一度だけ発動可能。対象を復活させ、ライフを１０％まで回復させる。";
                    buffUpStamina = 70;
                    buffUpMind = 70;
                    useSpecialAbility = true;
                    cost = 410000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Rare;
                    limitValue = RARE_EPIC_ITEM_STACK_SIZE;
                    break;

                case FIX.RARE_WHITE_TIGER_ANGEL_GOHU:
                    description = "珀虎天使からの強力な加護を得る。体＋１００、水耐性１４００、【スタン】【麻痺】【凍結】【誘惑】耐性";
                    buffUpStamina = 100;
                    ResistIce = 1400;
                    ResistStun = true;
                    ResistParalyze = true;
                    ResistFrozen = true;
                    ResistTemptation = true;
                    cost = 600000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Rare;
                    limitValue = RARE_EPIC_ITEM_STACK_SIZE;
                    break;

                case FIX.RARE_POWER_STEEL_RING_SOLID:
                    description = "強芯鋼素材の腕輪、【ソリッド】の印字が施されている。力＋７０、技＋５０、心＋４０";
                    buffUpStrength = 70;
                    buffUpAgility = 50;
                    buffUpMind = 40;
                    cost = 380000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Rare;
                    limitValue = RARE_EPIC_ITEM_STACK_SIZE;
                    break;

                case FIX.RARE_POWER_STEEL_RING_VAPOR:
                    description = "強芯鋼素材の腕輪、【ヴェイパー】の印字が施されている。技＋７０、知＋５０、体＋４０";
                    buffUpAgility = 70;
                    buffUpIntelligence = 50;
                    buffUpStamina = 40;
                    cost = 380000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Rare;
                    limitValue = RARE_EPIC_ITEM_STACK_SIZE;
                    break;

                case FIX.RARE_POWER_STEEL_RING_ERASTIC:
                    description = "強芯鋼素材の腕輪、【エラスト】の印字が施されている。知＋４０、体＋７０、心＋５０";
                    buffUpIntelligence = 40;
                    buffUpStamina = 70;
                    buffUpMind = 50;
                    cost = 380000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Rare;
                    limitValue = RARE_EPIC_ITEM_STACK_SIZE;
                    break;

                case FIX.RARE_POWER_STEEL_RING_TORAREITION:
                    description = "強芯鋼素材の腕輪、【トラレイス】の印字が施されている。力＋５０、知＋７０、心＋４０";
                    buffUpStrength = 50;
                    buffUpIntelligence = 70;
                    buffUpMind = 40;
                    cost = 380000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Rare;
                    limitValue = RARE_EPIC_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_SIHAIRYU_KIBA:
                    description = "ラグンタット各地に潜む「支配竜」の牙。力＋５０、心＋５０、物攻率＋７％";
                    buffUpStrength = 50;
                    buffUpMind = 50;
                    amplifyPhysicalAttack = 1.07f;
                    cost = 250000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_OLD_TREE_JUSHI:
                    description = "ラグンタット大地に眠る「古代栄樹」の樹脂。知＋５０、心＋５０、魔攻率＋７％";
                    buffUpIntelligence = 50;
                    buffUpMind = 50;
                    amplifyMagicAttack = 1.07f;
                    cost = 250000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_GALEWIND_KIZUATO:
                    description = "ラグンタット山脈の神「ゲイル・ウィンド」の傷跡。技＋５０、心＋５０、戦速率＋７％";
                    buffUpAgility = 50;
                    buffUpMind = 50;
                    amplifyBattleSpeed = 1.07f;
                    cost = 250000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_SIN_CRYSTAL_QUATZ:
                    description = "ラグンタット近代技術「シン・クリスタル」のクォーツ。体＋１００、戦応率＋７％";
                    buffUpStamina = 100;
                    amplifyBattleResponse = 1.07f;
                    cost = 250000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_EVERMIND_OMEN:
                    description = "ラグンタット天空の主「エバー・マインド」のオーメン。心＋１００、潜力率＋７％";
                    buffUpMind = 100;
                    amplifyPotential = 1.07f;
                    cost = 250000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.RARE_SYUURENSYA_KUROOBI:
                    description = "修練者の極みを示す称号の黒帯。【特殊能力：有】、体＋１２０、最大スキルポイント＋１０";
                    description += "\r\n【特殊能力】　スキル「インナー・インスピレーション」を発動する。";
                    buffUpStamina = 120;
                    effectValue1 = 10;
                    useSpecialAbility = true;
                    cost = 410000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Rare;
                    limitValue = RARE_EPIC_ITEM_STACK_SIZE;
                    break;

                case FIX.RARE_SHIHANDAI_KUROOBI:
                    description = "師範代の極意が刻まれている黒帯。【特殊能力：有】、体＋１２０、最大スキルポイント＋１０";
                    description += "\r\n【特殊能力】　スキル「スタンス・オブ・アイズ」を発動する。";
                    buffUpStamina = 120;
                    effectValue1 = 10;
                    useSpecialAbility = true;
                    cost = 410000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Rare;
                    limitValue = RARE_EPIC_ITEM_STACK_SIZE;
                    break;

                case FIX.RARE_SYUUDOUSOU_KUROOBI:
                    description = "修道僧の卓越した精神を示す黒帯。【特殊能力：有】、体＋１２０、最大スキルポイント＋１０";
                    description += "\r\n【特殊能力】　スキル「ピュア・ピュリファイケーション」を発動する。";
                    buffUpStamina = 120;
                    effectValue1 = 10;
                    useSpecialAbility = true;
                    cost = 410000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Rare;
                    limitValue = RARE_EPIC_ITEM_STACK_SIZE;
                    break;

                case FIX.RARE_KUGYOUSYA_KUROOBI:
                    description = "苦行者の達観された地点を表す黒帯。【特殊能力：有】、体＋１２０、最大スキルポイント＋１０";
                    description += "\r\n【特殊能力】　スキル「ニゲイト」を発動する。";
                    buffUpStamina = 120;
                    effectValue1 = 10;
                    useSpecialAbility = true;
                    cost = 410000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Rare;
                    limitValue = RARE_EPIC_ITEM_STACK_SIZE;
                    break;

                case FIX.RARE_TEARS_END:
                    description = "枯れきるまでの涙を媒介とし、心を呼び込むアクセサリ。【特殊能力：有】、心＋１２０";
                    description += "\r\n【特殊能力】　魔法「ライズ・オブ・イメージ」を発動する。";
                    buffUpMind = 120;
                    useSpecialAbility = true;
                    cost = 420000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Rare;
                    limitValue = RARE_EPIC_ITEM_STACK_SIZE;
                    break;

                case FIX.RARE_SKY_COLD_BOOTS:
                    description = "空中に水成分を氷質化させ、技を呼び込むアクセサリ。【特殊能力：有】、技＋１２０";
                    description += "\r\n【特殊能力】　魔法「ヒート・ブースト」を発動する。";
                    buffUpAgility = 120;
                    useSpecialAbility = true;
                    cost = 420000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Rare;
                    limitValue = RARE_EPIC_ITEM_STACK_SIZE;
                    break;

                case FIX.RARE_EARTH_BREAKERS_SIGIL:
                    description = "大地へ亀裂を発生させ、力を呼び込むアクセサリ。【特殊能力：有】、力＋１２０";
                    description += "\r\n【特殊能力】　魔法「ブラッディ・ヴェンジェンス」を発動する。";
                    buffUpStrength = 120;
                    useSpecialAbility = true;
                    cost = 420000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Rare;
                    limitValue = RARE_EPIC_ITEM_STACK_SIZE;
                    break;

                case FIX.RARE_AERIAL_VORTEX:
                    description = "創生の渦を自然発生させ、知を呼び込むアクセサリ。【特殊能力：有】、知＋１２０";
                    description += "\r\n【特殊能力】　魔法「プロミスド・ナレッジ」を発動する。";
                    buffUpIntelligence = 120;
                    useSpecialAbility = true;
                    cost = 420000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Rare;
                    limitValue = RARE_EPIC_ITEM_STACK_SIZE;
                    break;

                case FIX.RARE_LIVING_GROWTH_SEED:
                    description = "永緑のある芽吹き種から、体を呼び込むアクセサリ。【特殊能力：有】、体＋１２０";
                    description += "\r\n【特殊能力】　魔法「ワード・オブ・ライフ」を発動する。";
                    buffUpStamina = 120;
                    useSpecialAbility = true;
                    cost = 420000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Rare;
                    limitValue = RARE_EPIC_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_EXCELLENT_SWORD:
                    description = "見た目も良く、切れ味も抜群の剣。物理攻撃１２５～１４０";
                    PhysicalAttackMinValue = 125;
                    PhysicalAttackMaxValue = 140;
                    cost = 25000;
                    AdditionalDescription(ItemType.Weapon_Heavy);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_EXCELLENT_KNUCKLE:
                    description = "質感、見た目的に素晴らしく、切れ味最高の爪。物理攻撃１３０～１３５";
                    PhysicalAttackMinValue = 130;
                    PhysicalAttackMaxValue = 135;
                    cost = 23000;
                    AdditionalDescription(ItemType.Weapon_Light);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_EXCELLENT_BUSTER:
                    description = "豪華な彩色であり、かつ、重さを感じさせない最高の両手剣。物理攻撃６２～２５０";
                    PhysicalAttackMinValue = 62;
                    PhysicalAttackMaxValue = 250;
                    cost = 28000;
                    AdditionalDescription(ItemType.Weapon_TwoHand);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_EXCELLENT_ROD:
                    description = "質素ながら上質、加えて、持っただけで魔力が伝わってくる杖。魔法攻撃１０５～１２２";
                    MagicAttackMinValue = 105;
                    MagicAttackMaxValue = 122;
                    cost = 30000;
                    AdditionalDescription(ItemType.Weapon_Rod);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.RARE_BLACK_ICE_SWORD:
                    description = "黒色に変色した氷が刃形状となり、若干の禍々しさを感じさせる剣。【常備能力：有】力＋７０、知＋７０、物理攻撃２１０～２４０";
                    description += "\r\n【常備能力】　攻撃を当てるたび、マナポイントが回復する。";
                    buffUpStrength = 70;
                    buffUpIntelligence = 70;
                    PhysicalAttackMinValue = 210;
                    PhysicalAttackMaxValue = 240;
                    cost = 62000;
                    useSpecialAbility = true;
                    AdditionalDescription(ItemType.Weapon_Heavy);
                    rareLevel = RareLevel.Rare;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.RARE_MENTALIZED_FORCE_CLAW:
                    description = "精神的な欲求が僅かながら力として発揮される爪。【常備能力：有】力＋６５、技＋６５、物理攻撃２００～２３０";
                    description += "\r\n【常備能力】　攻撃を当てるたび、スキルポイントが回復する。";
                    buffUpStrength = 65;
                    buffUpAgility = 65;
                    PhysicalAttackMinValue = 200;
                    PhysicalAttackMaxValue = 230;
                    cost = 58000;
                    useSpecialAbility = true;
                    AdditionalDescription(ItemType.Weapon_Light);
                    rareLevel = RareLevel.Rare;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.RARE_CLAYMORE_ZUKS:
                    description = "ガッツリダメージを当てつつ、それに付随し体力を奪い取る両手斧。【常備能力：有】力＋８０、心＋８０、物理攻撃１２５～３９０";
                    description += "\r\n【常備能力】　攻撃を当てるたび、ライフポイントが回復する。";
                    buffUpStrength = 80;
                    buffUpMind = 80;
                    PhysicalAttackMinValue = 125;
                    PhysicalAttackMaxValue = 390;
                    cost = 73000;
                    useSpecialAbility = true;
                    AdditionalDescription(ItemType.Weapon_TwoHand);
                    rareLevel = RareLevel.Rare;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.RARE_ADERKER_FALSE_ROD:
                    description = "澱んだ湿原の中で自然発生した奇妙な魔力を持つ杖。【常備能力：有】知＋６０、体＋６０、魔法攻撃１５５～１９０、";
                    description += "\r\n【常備能力】　魔法ダメージを当てるたび、インスタントポイントが回復する。";
                    buffUpIntelligence = 60;
                    buffUpStamina = 60;
                    MagicAttackMinValue = 155;
                    MagicAttackMaxValue = 190;
                    cost = 72000;
                    useSpecialAbility = true;
                    AdditionalDescription(ItemType.Weapon_Rod);
                    rareLevel = RareLevel.Rare;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_DESCENED_BLADE:
                    description = "撫で下ろすような形状をした刀。物理攻撃１５５～１８２";
                    PhysicalAttackMinValue = 155;
                    PhysicalAttackMaxValue = 182;
                    cost = 35000;
                    AdditionalDescription(ItemType.Weapon_Heavy);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_FALSET_CLAW:
                    description = "平穏な街ファルセットでは、獣狩用の爪が非常に流行しているらしい。物理攻撃１６５～１７７";
                    PhysicalAttackMinValue = 165;
                    PhysicalAttackMaxValue = 177;
                    cost = 31000;
                    AdditionalDescription(ItemType.Weapon_Light);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_SEKIGAN_ROD:
                    description = "片目を失ったとある者が魔力を失わないように作成した杖。魔法攻撃１３５～１５５";
                    MagicAttackMinValue = 135;
                    MagicAttackMaxValue = 155;
                    cost = 40000;
                    AdditionalDescription(ItemType.Weapon_Rod);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_ROCK_BUSTER:
                    description = "『岩をも砕く！』と名付けた者がそう発した両手剣。物理攻撃８５～３１０";
                    PhysicalAttackMinValue = 85;
                    PhysicalAttackMaxValue = 310;
                    cost = 40000;
                    AdditionalDescription(ItemType.Weapon_TwoHand);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.RARE_SHARPNEL_SPIN_BLADE:
                    description = "微かな高音を自律的に発している振動型の剣。【特殊能力：有】戦速率＋１０％、物理攻撃２４５～２７０";
                    description += "\r\n【特殊能力】　戦闘中使用すると、戦速率を1.1倍上昇させる。";
                    PhysicalAttackMinValue = 245;
                    PhysicalAttackMaxValue = 270;
                    amplifyBattleSpeed = 1.1f;
                    cost = 72000;
                    useSpecialAbility = true;
                    AdditionalDescription(ItemType.Weapon_Heavy);
                    rareLevel = RareLevel.Rare;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.RARE_BLUE_LIGHT_MOON_CLAW:
                    description = "戦闘の構えをした時、自然と青く光る月を連想させる爪。【特殊能力：有】物攻率＋１０％、物理攻撃２３０～２６０";
                    description += "\r\n【特殊能力】　戦闘中使用すると、物攻率を1.1倍上昇させる。";
                    PhysicalAttackMinValue = 230;
                    PhysicalAttackMaxValue = 260;
                    amplifyPhysicalAttack = 1.1f;
                    cost = 63000;
                    useSpecialAbility = true;
                    AdditionalDescription(ItemType.Weapon_Light);
                    rareLevel = RareLevel.Rare;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.RARE_SHAERING_BONE_CRUSHER:
                    description = "骨をも砕かんばかりの威力を引き出してくれる両手斧。【特殊能力：有】潜力率＋１０％、物理攻撃１５０～４７０";
                    description += "\r\n【特殊能力】　戦闘中使用すると、潜力率を1.1倍上昇させる。";
                    PhysicalAttackMinValue = 150;
                    PhysicalAttackMaxValue = 470;
                    amplifyPotential = 1.1f;
                    cost = 80000;
                    useSpecialAbility = true;
                    AdditionalDescription(ItemType.Weapon_TwoHand);
                    rareLevel = RareLevel.Rare;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.RARE_BLIZZARD_SNOW_ROD:
                    description = "骨まで結晶化させてしまうほどの威力をもつ杖。【特殊能力：有】魔攻率＋１０％、魔法攻撃１８５～２２０";
                    description += "\r\n【特殊能力】　戦闘中使用すると、魔攻率を1.1倍上昇させる。";
                    MagicAttackMinValue = 185;
                    MagicAttackMaxValue = 220;
                    amplifyMagicAttack = 1.1f;
                    cost = 78000;
                    useSpecialAbility = true;
                    AdditionalDescription(ItemType.Weapon_TwoHand);
                    rareLevel = RareLevel.Rare;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_EXCELLENT_ARMOR:
                    description = "文句なし、最高品仕立ての鎧。物理防御６０～７０";
                    PhysicalDefenseMinValue = 60;
                    PhysicalDefenseMaxValue = 70;
                    cost = 23000;
                    AdditionalDescription(ItemType.Armor_Heavy);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_EXCELLENT_CROSS:
                    description = "軽さも最高で、防御力も上質の舞踏衣。物理防御５２～５８";
                    PhysicalDefenseMinValue = 52;
                    PhysicalDefenseMaxValue = 58;
                    cost = 21000;
                    AdditionalDescription(ItemType.Armor_Middle);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_EXCELLENT_ROBE:
                    description = "最高のローブ用素材使用。あみ目の弱点補強も施されている。物理防御２９～３３、魔法防御４５～６０";
                    PhysicalDefenseMinValue = 29;
                    PhysicalDefenseMaxValue = 33;
                    MagicDefenseMinValue = 45;
                    MagicDefenseMaxValue = 60;
                    cost = 30000;
                    AdditionalDescription(ItemType.Armor_Light);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.RARE_DRAGONSCALE_ARMOR:
                    description = "貴重なドラゴン鱗素材を駆使した鎧はほのかな光を放っている。物理防御９０～１０５、麻痺耐性、闇耐性７５０";
                    PhysicalDefenseMinValue = 90;
                    PhysicalDefenseMaxValue = 105;
                    ResistParalyze = true;
                    ResistShadow = 750;
                    cost = 55000;
                    AdditionalDescription(ItemType.Armor_Heavy);
                    rareLevel = RareLevel.Rare;
                    limitValue = RARE_EPIC_ITEM_STACK_SIZE;
                    break;

                case FIX.RARE_LIGHT_BLIZZARD_ROBE:
                    description = "氷吹雪が結晶化した衣形状ローブ、淡い青光りが目に映る。物理防御５４～６７、魔法防御１０５～１２０、スタン耐性、光耐性７５０";
                    PhysicalDefenseMinValue = 54;
                    PhysicalDefenseMaxValue = 67;
                    MagicDefenseMinValue = 105;
                    MagicDefenseMaxValue = 120;
                    ResistStun = true;
                    ResistLight = 750;
                    cost = 56000;
                    AdditionalDescription(ItemType.Armor_Light);
                    rareLevel = RareLevel.Rare;
                    limitValue = RARE_EPIC_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_COLD_STEEL_PLATE:
                    description = "寒さは当然遮断しており、かつ、ダメージに対する遮断も強固な鎧。物理防御７５～８８";
                    PhysicalDefenseMinValue = 75;
                    PhysicalDefenseMaxValue = 88;
                    cost = 31000;
                    AdditionalDescription(ItemType.Armor_Heavy);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_AIR_HARE_CROSS:
                    description = "この舞踏衣を装備している者は、快晴の空を稀に見るという。物理防御６９～７９";
                    PhysicalDefenseMinValue = 69;
                    PhysicalDefenseMaxValue = 79;
                    cost = 29000;
                    AdditionalDescription(ItemType.Armor_Middle);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_FLOATING_ROBE:
                    description = "このローブを装備している者は、実際には浮かないが、浮遊感を感じるという。物理防御３４～４０、魔法防御６５～８９";
                    PhysicalDefenseMinValue = 34;
                    PhysicalDefenseMaxValue = 40;
                    MagicDefenseMinValue = 65;
                    MagicDefenseMaxValue = 89;
                    cost = 38000;
                    AdditionalDescription(ItemType.Armor_Light);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.RARE_SCALE_BLUERAGE:
                    description = "蒼炎の魂が込められた鎧。分厚いわりに装備者に重さを感じさせない。【常備能力：有】物理防御１１０～１３２";
                    description += "\r\n【常備能力】　まれに物理による被ダメージを０にする";
                    PhysicalDefenseMinValue = 110;
                    PhysicalDefenseMaxValue = 132;
                    cost = 60000;
                    AdditionalDescription(ItemType.Armor_Heavy);
                    rareLevel = RareLevel.Rare;
                    limitValue = RARE_EPIC_ITEM_STACK_SIZE;
                    break;

                case FIX.RARE_BLUE_REFLECT_ROBE:
                    description = "蒼炎の魂が込められた衣。その衣は薄く、蒼く、そして炎のゆらめきを表現する。【常備能力：有】物理防御５８～７０、魔法防御１３０～１４５";
                    description += "\r\n【常備能力】　まれに魔法による被ダメージを０にする";
                    PhysicalDefenseMinValue = 58;
                    PhysicalDefenseMaxValue = 70;
                    MagicDefenseMinValue = 130;
                    MagicDefenseMaxValue = 145;
                    cost = 64000;
                    AdditionalDescription(ItemType.Armor_Heavy);
                    rareLevel = RareLevel.Rare;
                    limitValue = RARE_EPIC_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_EXCELLENT_SHIELD:
                    description = "身体全体を守れるサイズで、かつ、耐久性にも優れている盾。物理防御３７～４２";
                    PhysicalDefenseMinValue = 37;
                    PhysicalDefenseMaxValue = 42;
                    cost = 22000;
                    AdditionalDescription(ItemType.Shield);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_SNOW_CRYSTAL_SHIELD:
                    description = "高位の結晶体が盾形状になったモノ。その硬さは一級品である。物理防御４７～５０、魔法防御５０～５５";
                    PhysicalDefenseMinValue = 47;
                    PhysicalDefenseMaxValue = 50;
                    MagicDefenseMinValue = 50;
                    MagicDefenseMaxValue = 55;
                    cost = 30000;
                    AdditionalDescription(ItemType.Shield);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.RARE_SLIDE_THROUGH_SHIELD:
                    description = "形状が非常に楕円系の形をしており、単純な攻撃ならさばくことが可能。【常備能力：有】物理防御５２～５４";
                    description += "\r\n【常備能力】　まれに物理による被ダメージを０にする";
                    PhysicalDefenseMinValue = 52;
                    PhysicalDefenseMaxValue = 54;
                    cost = 50000;
                    AdditionalDescription(ItemType.Shield);
                    rareLevel = RareLevel.Rare;
                    limitValue = RARE_EPIC_ITEM_STACK_SIZE;
                    break;

                case FIX.RARE_ELEMENTAL_STAR_SHIELD:
                    description = "各属性の紋様が星型で刻まれている盾。物理防御５０～５２、魔法防御４８～５０、光/闇/火/水/理/空耐性５００";
                    PhysicalDefenseMinValue = 53;
                    PhysicalDefenseMaxValue = 55;
                    MagicDefenseMinValue = 48;
                    MagicDefenseMaxValue = 50;
                    ResistLight = 500;
                    ResistShadow = 500;
                    ResistIce = 500;
                    ResistFire = 500;
                    ResistForce = 500;
                    ResistWill = 500;
                    cost = 54000;
                    AdditionalDescription(ItemType.Shield);
                    rareLevel = RareLevel.Rare;
                    limitValue = RARE_EPIC_ITEM_STACK_SIZE;
                    break;

                // ガンツ武器（３階）                                       
                case FIX.COMMON_EXCELLENT_SWORD_3:
                    description = "見た目も良く、切れ味も抜群の剣をガンツが強化した。物理攻撃１２５(+15)～１４０(+15)";
                    PhysicalAttackMinValue = 140;
                    PhysicalAttackMaxValue = 155;
                    cost = 3000;
                    AdditionalDescription(ItemType.Weapon_Heavy);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_EXCELLENT_KNUCKLE_3:
                    description = "質感、見た目的に素晴らしく、切れ味最高の爪をガンツが強化した。物理攻撃１３０(+12)～１３５(+12)";
                    PhysicalAttackMinValue = 142;
                    PhysicalAttackMaxValue = 147;
                    cost = 27000;
                    AdditionalDescription(ItemType.Weapon_Light);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_EXCELLENT_BUSTER_3:
                    description = "豪華な彩色であり、かつ、重さを感じさせない最高の両手剣をガンツが強化した。物理攻撃６２(+15)～２５０(+30)";
                    PhysicalAttackMinValue = 77;
                    PhysicalAttackMaxValue = 280;
                    cost = 34000;
                    AdditionalDescription(ItemType.Weapon_TwoHand);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_EXCELLENT_ROD_3:
                    description = "質素ながら上質、加えて、持っただけで魔力が伝わってくる杖をガンツが強化した。魔法攻撃１０５(+20)～１２２(+20)";
                    MagicAttackMinValue = 125;
                    MagicAttackMaxValue = 142;
                    cost = 35000;
                    AdditionalDescription(ItemType.Weapon_Rod);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_EXCELLENT_ARMOR_3:
                    description = "文句なし、最高品仕立ての鎧をガンツが強化した。物理防御６０(+8)～７０(+8)";
                    PhysicalDefenseMinValue = 68;
                    PhysicalDefenseMaxValue = 78;
                    cost = 27000;
                    AdditionalDescription(ItemType.Armor_Heavy);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_EXCELLENT_CROSS_3:
                    description = "軽さも最高で、防御力も上質の舞踏衣をガンツが強化した。物理防御５２(+6)～５８(+6)";
                    PhysicalDefenseMinValue = 58;
                    PhysicalDefenseMaxValue = 64;
                    cost = 25000;
                    AdditionalDescription(ItemType.Armor_Middle);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_EXCELLENT_ROBE_3:
                    description = "最高のローブ用素材使用。あみ目の弱点補強も施されており、さらにガンツが強化した。物理防御２９(+3)～３３(+3)、魔法防御４５(+10)～６０(+10)";
                    PhysicalDefenseMinValue = 32;
                    PhysicalDefenseMaxValue = 36;
                    MagicDefenseMinValue = 55;
                    MagicDefenseMaxValue = 70;
                    cost = 34000;
                    AdditionalDescription(ItemType.Armor_Light);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_EXCELLENT_SHIELD_3:
                    description = "身体全体を守れるサイズで、かつ、耐久性にも優れている盾をガンツが強化した。物理防御３７(+5)～４２(+5)";
                    PhysicalDefenseMinValue = 42;
                    PhysicalDefenseMaxValue = 47;
                    cost = 26000;
                    AdditionalDescription(ItemType.Shield);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_STEEL_BLADE: // ゴツゴツした棍棒
                    description = "強靭な素材のみ使用した鋼にガンツ直々の技が宿った剣！物理攻撃２２５(+25）～２５５(+25)";
                    PhysicalAttackMinValue = 250;
                    PhysicalAttackMaxValue = 280;
                    cost = 73000;
                    AdditionalDescription(ItemType.Weapon_Heavy);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.RARE_SPLASH_BARE_CLAW: // ベアクローの欠片
                    description = "ゴツゴツし砕け散ったクマの手素材をガンツが見事に武器化に成功！　物理攻撃２６２～２７７";
                    PhysicalAttackMinValue = 262;
                    PhysicalAttackMaxValue = 277;
                    cost = 68000;
                    AdditionalDescription(ItemType.Weapon_Light);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.EPIC_GATO_HAWL_OF_GREAT: // 古代ツンドラ鹿の角
                    description = "古代賢者ガトゥに仕えていた神鹿の紋章。沈黙・スタン・麻痺耐性。技＋８５、知＋３２５、魔法攻撃６６６～７７７、魔攻率＋２０％、潜力率＋２０％、闇耐性1500、火耐性1500";
                    ResistSilence = true;
                    ResistStun = true;
                    ResistParalyze = true;
                    buffUpAgility = 85;
                    buffUpIntelligence = 325;
                    MagicAttackMinValue = 666;
                    MagicAttackMaxValue = 777;
                    amplifyMagicAttack = 1.2f;
                    amplifyPotential = 1.2f;
                    ResistShadow = 1500;
                    ResistFire = 1500;
                    cost = 250000;
                    AdditionalDescription(ItemType.Weapon_Rod);
                    rareLevel = RareLevel.Epic;
                    limitValue = RARE_EPIC_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_LIZARDSCALE_ARMOR: // リザードの鱗
                    description = "リザードの鱗を細かく細分化し、鎧形状に仕立てなおしたもの。物理防御８０(+25)～１０５(+25)";
                    PhysicalDefenseMinValue = 105;
                    PhysicalDefenseMaxValue = 130;
                    cost = 62000;
                    AdditionalDescription(ItemType.Armor_Heavy);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_ARGNIAN_TUNIC: // アルゴニアンの紫鱗
                    description = "アルゴニアンの素材は紫色のコーティングがあり安定した防御性が出やすい。物理防御７７～９０";
                    PhysicalDefenseMinValue = 77;
                    PhysicalDefenseMaxValue = 90;
                    cost = 33000;
                    AdditionalDescription(ItemType.Armor_Middle);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_ANIMAL_FUR_CROSS: // ウルフの毛皮
                    description = "野生動物特有のゴワゴワした質感を落とすことなく戦闘衣に仕立ててある。体＋７０、物理防御７２～７９";
                    PhysicalDefenseMinValue = 72;
                    PhysicalDefenseMaxValue = 79;
                    buffUpStamina = 70;
                    cost = 58000;
                    AdditionalDescription(ItemType.Armor_Middle);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.RARE_CHILL_BONE_SHIELD:
                    description = "氷点下を遙かに下回る温度で凍結させた骨の盾。物理防御６５～７０、火耐性７５０、水耐性７５０";
                    PhysicalDefenseMinValue = 65;
                    PhysicalDefenseMaxValue = 70;
                    ResistIce = 750;
                    ResistFire = 750;
                    cost = 58000;
                    AdditionalDescription(ItemType.Shield);
                    rareLevel = RareLevel.Rare;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_SNOW_GUARD: // 雪猫の毛皮
                    description = "吹雪対策用に見えるが、アクセサリとしての上質さは装着した者のみが知る。体＋５０、心＋５０、水耐性１０００";
                    buffUpStamina = 50;
                    buffUpMind = 50;
                    ResistIce = 1000;
                    cost = 250000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_WINTERS_HORN:
                    description = "冬の季節に、ホーンの音が響き渡る。【特殊能力：有】知＋５０、体＋５０";
                    description += "\r\n【特殊能力】　味方全員の【知】パラメタを上昇させる。";
                    buffUpIntelligence = 50;
                    buffUpStamina = 50;
                    cost = 450000;
                    useSpecialAbility = true;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_PENGUIN_OF_PENGUIN: // エンブレム・オブ・ペンギン
                    description = "ペンギンの気持ちが心なしか伝わってくる。力＋３０、技＋３０、知＋３０、体＋３０、心＋３０";
                    buffUpStrength = 30;
                    buffUpAgility = 30;
                    buffUpIntelligence = 30;
                    buffUpStamina = 30;
                    buffUpMind = 30;
                    cost = 500000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                // 宝箱
                case FIX.COMMON_ESSENCE_OF_EARTH:
                    description = "大地のマテリアル合成素材。武具職人の力量が問われる。";
                    cost = 200000;
                    AdditionalDescription(ItemType.Material_Equip);
                    rareLevel = RareLevel.Common;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_KESSYOU_SEA_WATER_SALT:
                    description = "固形化した海水の塩がたまたま結晶に似た形をした状態を保っている。";
                    cost = 210000;
                    AdditionalDescription(ItemType.Material_Food);
                    rareLevel = RareLevel.Common;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_STAR_DUST_RING:
                    description = "星屑の形をしたリング。星屑からは理のパワーを感じる。【特殊能力：有】力＋６０";
                    description += "\r\n【特殊能力】　魔法「ワード・オブ・パワー」を発動する。";
                    buffUpStrength = 60;
                    useSpecialAbility = true;
                    cost = 235000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = RARE_EPIC_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_RED_ONION:
                    description = "真っ赤なタマネギだ・・・これは食用素材として大丈夫なのか？？";
                    cost = 215000;
                    AdditionalDescription(ItemType.Material_Food);
                    rareLevel = RareLevel.Common;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;

                case FIX.RARE_HARDEST_FIT_BOOTS:
                    description = "ガッチリと完全に足が固定化されるブーツ。動くにはある程度の慣れが必要。体＋６０、心＋４０、物防率１０％、【スタン】【麻痺】【鈍化】耐性";
                    buffUpStamina = 60;
                    buffUpMind = 40;
                    amplifyPhysicalDefense = 1.1f;
                    ResistStun = true;
                    ResistParalyze = true;
                    ResistSlow = true;
                    cost = 420000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Rare;
                    limitValue = RARE_EPIC_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_WHITE_POWDER:
                    description = "白い粉。とくに理由は無いが危険な感じがするのは気のせいか。";
                    cost = 260000;
                    AdditionalDescription(ItemType.Material_Food);
                    rareLevel = RareLevel.Common;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;

                case FIX.RARE_SWORD_OF_DIVIDE:
                    description = "一度分断された剣が再統合化された剣。異常なオーラを感じる。【常備能力：有】物理攻撃２３３～２５５";
                    description += "\r\n【常備能力】　攻撃を当てた際、まれに対象のライフを1/5減らす。";
                    PhysicalAttackMinValue = 230;
                    PhysicalAttackMaxValue = 255;
                    cost = 67000;
                    AdditionalDescription(ItemType.Weapon_Heavy);
                    rareLevel = RareLevel.Rare;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.EPIC_OLD_TREE_MIKI_DANPEN:
                    description = "古代栄樹の幹素材は絶える事のない永遠を示す。古代栄樹に仕えしガトゥの言葉がかすかに聞こえてくるようだ。";
                    cost = 0;
                    AdditionalDescription(ItemType.Material_Equip);
                    rareLevel = RareLevel.Epic;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                #endregion
                #region "４階：ランダムドロップ"
                case FIX.COMMON_RED_MEDALLION:
                    description = "煌々と光る赤のメダリオン。力＋３００";
                    buffUpStrength = 300;
                    cost = 510000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_BLUE_MEDALLION:
                    description = "煌々と光る青のメダリオン。技＋３００";
                    buffUpAgility = 300;
                    cost = 510000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_PURPLE_MEDALLION:
                    description = "煌々と光る紫のメダリオン。知＋３００";
                    buffUpIntelligence = 300;
                    cost = 510000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_GREEN_MEDALLION:
                    description = "煌々と光る緑のメダリオン。体＋３００";
                    buffUpStamina = 300;
                    cost = 510000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_YELLOW_MEDALLION:
                    description = "煌々と光る黄のメダリオン。心＋３００";
                    buffUpMind = 300;
                    cost = 510000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_SOCIETY_SYMBOL:
                    description = "従属的な社会に対し、生涯の忠誠を誓った兵士達の勲章。力＋２００、体＋２００、スタン耐性、麻痺耐性";
                    description += "\r\n【特殊能力】　味方全員の物理攻撃/物理防御を上昇させる。本アクセサリを使用した場合、戦闘終了後に破壊される。";
                    buffUpStrength = 200;
                    buffUpStamina = 200;
                    ResistStun = true;
                    ResistParalyze = true;
                    UseSpecialAbility = true;
                    cost = 490000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_SILVER_FEATHER_BRACELET:
                    description = "自由社会で生き延びるため、自律を誓った傭兵達の勲章。技＋２００、体＋２００、凍結耐性、誘惑耐性";
                    description += "\r\n【特殊能力】　味方全員の魔法攻撃/魔法防御を上昇させる。本アクセサリを使用した場合、戦闘終了後に破壊される。";
                    buffUpAgility = 200;
                    buffUpStamina = 200;
                    ResistFrozen = true;
                    ResistTemptation = true;
                    UseSpecialAbility = true;
                    cost = 495000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_BIRD_SONG_LUTE:
                    description = "吟遊詩人が奏でる旋律は、自然と士気を高めてくれる。体＋２００、心＋２００、沈黙耐性、鈍化耐性、暗闇耐性";
                    description += "\r\n【特殊能力】　味方全員の【心】パラメタを上昇させる。";
                    buffUpStamina = 200;
                    buffUpMind = 200;
                    ResistSilence = true;
                    ResistSlow = true;
                    ResistBlind = true;
                    useSpecialAbility = true;
                    cost = 500000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_MAZE_CUBE:
                    description = "強力な魔力が封じられた不思議の箱。その形状、形態は極めて不安定である。知＋２００、体＋２００、毒耐性、スリップ耐性";
                    description += "\r\n【特殊能力】　物理攻撃がヒットする度に、魔法攻撃が2%上昇する。その後魔法攻撃がヒットする度に、物理攻撃が2%上昇する。\r\nこのサイクルは最高10回まで蓄積が可能である。";
                    buffUpIntelligence = 200;
                    buffUpStamina = 200;
                    ResistPoison = true;
                    ResistSlip = true;
                    useSpecialAbility = true;
                    cost = 505000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_LIGHT_SERVANT:
                    description = "【聖】は、【聖の使い手】を魅了する。心＋２４０";
                    description += "\r\n【特殊能力】　物理および魔法攻撃がヒットする度に、聖の蓄積カウンターが１つ自分にBUFFとして蓄積する。\r\n聖の蓄積カウンターが３つ累積した状態でアクセサリを使用した場合、味方全員のライフを回復する。その後、聖の蓄積カウンターを全て除去する。";
                    buffUpMind = 240;
                    useSpecialAbility = true;
                    cost = 520000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_SHADOW_SERVANT:
                    description = "【闇】は、【闇の使い手】を支配する。心＋２４０";
                    description += "\r\n【特殊能力】　物理および魔法攻撃がヒットする度に、闇の蓄積カウンターが１つ自分にBUFFとして蓄積する。\r\n闇の蓄積カウンターが３つ累積した状態でアクセサリを使用した場合、味方全員のDEBUFF効果を解除する。その後、闇の蓄積カウンターを全て除去する。";
                    buffUpMind = 240;
                    useSpecialAbility = true;
                    cost = 520000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_ROYAL_GUARD_RING:
                    description = "堅実にガードを固めたロイヤルガードの刻印があるリング。体＋２２０";
                    description += "\r\n【常備能力】　装備者に物理攻撃/物理防御DOWN効果がかかった場合、その効果を無効化する。";
                    buffUpStamina = 220;
                    useSpecialAbility = true;
                    cost = 525000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_ELEMENTAL_GUARD_RING:
                    description = "堅実にガードを固めたエレメンタルガードの刻印があるリング。体＋２２０";
                    description += "\r\n【常備能力】　装備者に魔法攻撃/魔法防御DOWN効果がかかった場合、その効果を無効化する。";
                    buffUpStamina = 220;
                    useSpecialAbility = true;
                    cost = 525000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_HAYATE_GUARD_RING:
                    description = "堅実にガードを固められるよう、疾風ガードの刻印があるリング。体＋２２０";
                    description += "\r\n【常備能力】　装備者に戦闘速度/戦闘反応DOWN効果がかかった場合、その効果を無効化する。";
                    buffUpStamina = 220;
                    useSpecialAbility = true;
                    cost = 525000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.RARE_SPELL_COMPASS:
                    description = "そのコンパスの針は、知を示す者に対して次の魔法詠唱スタイルを教えてくれる。知＋３００、体＋１４０、心＋１４０";
                    description += "\r\n【特殊能力】　もし装備者にシャドウ・パクトがかかっていない場合、シャドウ・パクトを発動する。\r\nもし装備者にプロミスド・ナレッジがかかっていない場合、プロミスド・ナレッジを発動する。\r\nもし装備者にサイキック・トランスがかかっていない場合、サイキック・トランスを発動する。";
                    buffUpIntelligence = 300;
                    buffUpStamina = 140;
                    buffUpMind = 140;
                    useSpecialAbility = true;
                    cost = 850000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Rare;
                    limitValue = RARE_EPIC_ITEM_STACK_SIZE;
                    break;

                case FIX.RARE_SHADOW_BIBLE:
                    description = "そのバイブルからは、力を示す者に対して不死の強さを与えてくれる。力＋３００、知＋１４０、体＋１４０";
                    description += "\r\n【常備能力】　もし装備者が戦闘中に初めて死亡した場合、装備者を復活させ、ライフを全快まで回復する。その後、蘇生不可のBUFFが付与される。";
                    buffUpStrength = 300;
                    buffUpIntelligence = 140;
                    buffUpStamina = 140;
                    useSpecialAbility = true;
                    cost = 870000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Rare;
                    limitValue = RARE_EPIC_ITEM_STACK_SIZE;
                    break;

                case FIX.RARE_DETACHMENT_ORB:
                    description = "そのオーブからは、技を示す者に対してダメージ無効理論を構築してくれる。技＋３００、体＋１４０、心＋１４０";
                    description += "\r\n【特殊能力】　次ターンまで、味方全員に対するダメージを無効化する。本効果は各戦闘に付き一度だけ発動できる。";
                    buffUpAgility = 300;
                    buffUpStamina = 140;
                    buffUpMind = 140;
                    useSpecialAbility = true;
                    cost = 890000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Rare;
                    limitValue = RARE_EPIC_ITEM_STACK_SIZE;
                    break;

                case FIX.RARE_BLIND_NEEDLE:
                    description = "盲目者は見えない部分を感知し、不純物の除去を可能にする。力＋１４０、知＋１４０、心＋３００";
                    description += "\r\n【特殊能力】　全状態異常を解除する。";
                    buffUpStrength = 140;
                    buffUpIntelligence = 140;
                    buffUpMind = 300;
                    ResistStun = true;
                    ResistParalyze = true;
                    ResistFrozen = true;
                    useSpecialAbility = true;
                    cost = 1000000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Rare;
                    limitValue = RARE_EPIC_ITEM_STACK_SIZE;
                    break;

                case FIX.RARE_CORE_ESSENCE_CHANNEL:
                    description = "装着者に宿るエッセンスを最大限に引き出すチャネルリング。力＋２００、技＋２００、知＋２００、体＋２００、心＋２００";
                    description += "\r\n【特殊能力】　ライフとスキルとマナを回復する。";
                    buffUpStrength = 200;
                    buffUpAgility = 200;
                    buffUpIntelligence = 200;
                    buffUpStamina = 200;
                    buffUpMind = 200;
                    ResistPoison = true;
                    ResistSilence = true;
                    ResistTemptation = true;
                    ResistSlow = true;
                    ResistBlind = true;
                    ResistSlip = true;
                    useSpecialAbility = true;
                    cost = 1000000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Rare;
                    limitValue = RARE_EPIC_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_MASTER_SWORD:
                    description = "史上最高の質感と斬撃力が引き出されている剣。物理攻撃４６８～４９０";
                    PhysicalAttackMinValue = 468;
                    PhysicalAttackMaxValue = 490;
                    cost = 620000;
                    AdditionalDescription(ItemType.Weapon_Heavy);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_MASTER_KNUCKLE:
                    description = "史上最高の軽さと殺傷力を併せ持つ爪。物理攻撃４７５～４８５";
                    PhysicalAttackMinValue = 475;
                    PhysicalAttackMaxValue = 485;
                    cost = 620000;
                    AdditionalDescription(ItemType.Weapon_Light);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_MASTER_ROD:
                    description = "史上最高の魔力源を引き出す事に長けた杖。魔法攻撃３４３～４１８";
                    MagicAttackMinValue = 343;
                    MagicAttackMaxValue = 418;
                    cost = 620000;
                    AdditionalDescription(ItemType.Weapon_Rod);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_MASTER_AXE:
                    description = "史上最高の衝撃力を生み出す力が与えられている斧。物理攻撃２２０～６１０";
                    PhysicalAttackMinValue = 220;
                    PhysicalAttackMaxValue = 610;
                    cost = 620000;
                    AdditionalDescription(ItemType.Weapon_TwoHand);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_MASTER_ARMOR:
                    description = "史上最高の耐久性、そして、鉄壁の防御力を誇る鎧。物理防御１２０～１４５";
                    PhysicalDefenseMinValue = 120;
                    PhysicalDefenseMaxValue = 145;
                    cost = 580000;
                    AdditionalDescription(ItemType.Armor_Heavy);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_MASTER_CROSS:
                    description = "史上最高の柔軟性と耐突撃性を両立させたクロス。物理防御８８～１１２";
                    PhysicalDefenseMinValue = 88;
                    PhysicalDefenseMaxValue = 112;
                    cost = 580000;
                    AdditionalDescription(ItemType.Armor_Light);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_MASTER_ROBE:
                    description = "史上最高の光沢と魔防を兼ね備えるローブ。物理防御７６～８５、魔法防御１０８～１３２";
                    PhysicalDefenseMinValue = 76;
                    PhysicalDefenseMaxValue = 85;
                    MagicDefenseMinValue = 108;
                    MagicDefenseMaxValue = 132;
                    cost = 580000;
                    AdditionalDescription(ItemType.Armor_Light);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_MASTER_SHIELD:
                    description = "史上最高の強靭さと堅牢さを実現させた盾。物理防御６２～８５";
                    PhysicalDefenseMinValue = 62;
                    PhysicalDefenseMaxValue = 85;
                    cost = 300000;
                    AdditionalDescription(ItemType.Shield);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.RARE_ASTRAL_VOID_BLADE:
                    description = "真空の刃により、空間そのものへのダメージを与える剣。物理攻撃６５２～７２９";
                    PhysicalAttackMinValue = 652;
                    PhysicalAttackMaxValue = 729;
                    cost = 1520000;
                    AdditionalDescription(ItemType.Weapon_Heavy);
                    rareLevel = RareLevel.Rare;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.RARE_VERDANT_SONIC_CLAW:
                    description = "音速の振りで、常に共鳴波を放出しながら立ち振る舞える爪。物理攻撃６７１～７０５";
                    PhysicalAttackMinValue = 671;
                    PhysicalAttackMaxValue = 705;
                    cost = 1520000;
                    AdditionalDescription(ItemType.Weapon_Heavy);
                    rareLevel = RareLevel.Rare;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.RARE_PRISONER_BREAKING_AXE:
                    description = "監獄の檻ですら、へし折る力を引き出せるバカでかい斧。物理攻撃３４３～１０１３";
                    PhysicalAttackMinValue = 343;
                    PhysicalAttackMaxValue = 1013;
                    cost = 1520000;
                    AdditionalDescription(ItemType.Weapon_TwoHand);
                    rareLevel = RareLevel.Rare;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.RARE_INVISIBLE_STATE_ROD:
                    description = "ターゲットにされているものから、そのロッドの姿は見えない。魔法攻撃４８６～６７７";
                    MagicAttackMinValue = 486;
                    MagicAttackMaxValue = 677;
                    cost = 1520000;
                    AdditionalDescription(ItemType.Weapon_Rod);
                    rareLevel = RareLevel.Rare;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.RARE_DOMINATION_BRAVE_ARMOR:
                    description = "勇敢なる闘士を秘めたものが、防御の威力を支配する。物理防御１８６～１９８";
                    PhysicalDefenseMinValue = 186;
                    PhysicalDefenseMaxValue = 198;
                    cost = 1120000;
                    AdditionalDescription(ItemType.Armor_Heavy);
                    rareLevel = RareLevel.Rare;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_RED_FLOAT_STONE:
                    description = "淡く照らす赤の石が身体の周りに浮遊する。力＋５２０";
                    buffUpStrength = 520;
                    cost = 950000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_BLUE_FLOAT_STONE:
                    description = "淡く照らす青の石が身体の周りに浮遊する。技＋５２０";
                    buffUpAgility = 520;
                    cost = 950000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_PURPLE_FLOAT_STONE:
                    description = "淡く照らす紫の石が身体の周りに浮遊する。知＋５２０";
                    buffUpIntelligence = 520;
                    cost = 950000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_GREEN_FLOAT_STONE:
                    description = "淡く照らす緑の石が身体の周りに浮遊する。体＋５２０";
                    buffUpStamina = 520;
                    cost = 950000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_YELLOW_FLOAT_STONE:
                    description = "淡く照らす黄の石が身体の周りに浮遊する。心＋５２０";
                    buffUpMind = 520;
                    cost = 950000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_SILVER_RING_1:
                    description = "銀の素材で作られた腕輪。『業火』のオーラが漂っている。力＋３７０、技＋３７０";
                    buffUpStrength = 370;
                    buffUpAgility = 370;
                    cost = 900000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_SILVER_RING_2:
                    description = "銀の素材で作られた腕輪。『津波』のオーラが漂っている。力＋３７０、知＋３７０";
                    buffUpStrength = 370;
                    buffUpIntelligence = 370;
                    cost = 900000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_SILVER_RING_3:
                    description = "銀の素材で作られた腕輪。『秋雨』のオーラが漂っている。力＋３７０、体＋３７０";
                    buffUpStrength = 370;
                    buffUpStamina = 370;
                    cost = 900000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_SILVER_RING_4:
                    description = "銀の素材で作られた腕輪。『熱波』のオーラが漂っている。力＋３７０、心＋３７０";
                    buffUpStrength = 370;
                    buffUpMind = 370;
                    cost = 900000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_SILVER_RING_5:
                    description = "銀の素材で作られた腕輪。『雷鳴』のオーラが漂っている。技＋３７０、知＋３７０";
                    buffUpAgility = 370;
                    buffUpIntelligence = 370;
                    cost = 900000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_SILVER_RING_6:
                    description = "銀の素材で作られた腕輪。『吹雪』のオーラが漂っている。技＋３７０、体＋３７０";
                    buffUpAgility = 370;
                    buffUpStamina = 370;
                    cost = 900000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_SILVER_RING_7:
                    description = "銀の素材で作られた腕輪。『幻日』のオーラが漂っている。技＋３７０、心＋３７０";
                    buffUpAgility = 370;
                    buffUpMind = 370;
                    cost = 900000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_SILVER_RING_8:
                    description = "銀の素材で作られた腕輪。『竜巻』のオーラが漂っている。知＋３７０、体＋３７０";
                    buffUpIntelligence = 370;
                    buffUpStamina = 370;
                    cost = 900000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_SILVER_RING_9:
                    description = "銀の素材で作られた腕輪。『主虹』のオーラが漂っている。知＋３７０、心＋３７０";
                    buffUpIntelligence = 370;
                    buffUpMind = 370;
                    cost = 900000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_SILVER_RING_10:
                    description = "銀の素材で作られた腕輪。『陽炎』のオーラが漂っている。体＋３７０、心＋３７０";
                    buffUpStamina = 370;
                    buffUpMind = 370;
                    cost = 900000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_MUKEI_SAKAZUKI:
                    description = "容の見えない盃がそこに存在しており、装備者に透明な水が流れこむ。心＋４００";
                    description += "\r\n【常備能力】　ターン終了ごとに、そのターン内で減ったライフ、マナ、スキルの半分の量を各々回復する。";
                    buffUpMind = 400;
                    cost = 920000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_RAINBOW_TUBE:
                    description = "装備者の意図にかかわらず虹色の噴水が吹き出るチューブ。体＋４００";
                    description += "\r\n【特殊能力】　以下のいずれかがランダムに発動する。\r\n　敵全体に対して【火】ダメージを与える / 味方全体のライフを回復する / 敵全体に対してスタン効果を与える / 味方全体のDEBUFF効果を解除する";
                    buffUpStamina = 400;
                    useSpecialAbility = true;
                    cost = 920000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_ELDER_PERSPECTIVE_GRASS:
                    description = "見識者としての鋭い洞察が可能になる無色透明の眼鏡。知＋４００";
                    description += "\r\n【常備能力】　ターン終了ごとに、対象の戦闘速度/戦闘反応をDOWNさせる。";
                    buffUpIntelligence = 400;
                    useSpecialAbility = true;
                    cost = 920000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_DEVIL_SEALED_VASE:
                    description = "対悪魔用の切り札として開発された壺。指名された対象を陥れる力が秘められている。力＋４００";
                    description += "\r\n【特殊能力】　戦闘の前に、魔法の名称を選ぶ。戦闘中、その魔法の名称が敵から詠唱された場合、その魔法を打ち消す。";
                    buffUpStrength = 400;
                    cost = 920000;
                    useSpecialAbility = true;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_FLOATING_WHITE_BALL:
                    description = "特徴の無い白色の浮遊型のボール。戦闘中、不定期にまばゆい発光を行う。技＋４００";
                    description += "\r\n【常備能力】　もし敵が自分に対して行動してきた場合、稀に回避する。";
                    buffUpAgility = 400;
                    cost = 920000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.RARE_SEAL_OF_ASSASSINATION:
                    description = "暗殺戦闘スタイルに対し耐性を持つシール。体＋５００、心＋５００、火耐性5000、理耐性5000";
                    description += "\r\n【常備能力】　自分に対して、一撃で死亡するアクションが行われた場合、即死を回避する。";
                    buffUpStamina = 500;
                    ResistFire = 5000;
                    ResistForce = 5000;
                    cost = 1050000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Rare;
                    limitValue = RARE_EPIC_ITEM_STACK_SIZE;
                    break;

                case FIX.RARE_EMBLEM_OF_VALKYRIE:
                    description = "死を迎え入れるヴァルキリーの紋章。装備者にヴァルキリーの信念が宿る。力＋４５０、技＋３５０、体＋２００、心＋２００、聖耐性5000、火耐性5000、沈黙耐性、スタン耐性、麻痺耐性、誘惑耐性、鈍化耐性";
                    description += "\r\n【常備能力】　攻撃ヒット時、稀に対象を麻痺させる。";
                    buffUpStrength = 450;
                    buffUpAgility = 350;
                    buffUpStamina = 200;
                    buffUpMind = 200;
                    ResistLight = 5000;
                    ResistFire = 5000;
                    cost = 1050000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Rare;
                    limitValue = RARE_EPIC_ITEM_STACK_SIZE;
                    break;

                case FIX.RARE_EMBLEM_OF_HADES:
                    description = "死を呼び寄せるハデスの紋章。装備者にハデスの信念が宿る。技＋３５０、知＋４５０、体＋２００、心＋２００、闇耐性5000、水耐性5000、毒耐性、麻痺耐性、凍結耐性、暗闇耐性、スリップ耐性";
                    description += "\r\n【常備能力】　攻撃ヒット時、稀に対象を一撃で死亡させる。";
                    buffUpAgility = 350;
                    buffUpIntelligence = 450;
                    buffUpStamina = 500;
                    buffUpMind = 200;
                    ResistShadow = 5000;
                    ResistIce = 5000;
                    cost = 1050000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Rare;
                    limitValue = RARE_EPIC_ITEM_STACK_SIZE;
                    break;
                case FIX.RARE_SIHAIRYU_KATAUDE:
                    description = "支配竜の面影が感じられる片腕の造形物。力＋６００、体＋３００、心＋４００、物攻率＋１５％、潜力率＋５％";
                    buffUpStrength = 600;
                    buffUpStamina = 300;
                    buffUpMind = 400;
                    amplifyPhysicalAttack = 1.15f;
                    amplifyPotential = 1.05f;
                    cost = 1100000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Rare;
                    limitValue = RARE_EPIC_ITEM_STACK_SIZE;
                    break;
                case FIX.RARE_OLD_TREE_SINKI:
                    description = "古代栄樹の力強い脈動が感じられる芯木の造形物。知＋６００、体＋３００、心＋４００、魔攻率＋１５％、潜力率＋５％";
                    buffUpIntelligence = 600;
                    buffUpStamina = 300;
                    buffUpMind = 400;
                    amplifyMagicAttack = 1.15f;
                    amplifyPotential = 1.05f;
                    cost = 1100000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Rare;
                    limitValue = RARE_EPIC_ITEM_STACK_SIZE;
                    break;
                case FIX.RARE_GALEWIND_IBUKI:
                    description = "確かな疾風の流れを感じられる息吹を象る造形物。技＋６００、知＋４００、心＋３００、戦速率＋１５％、潜力率＋５％";
                    buffUpAgility = 600;
                    buffUpIntelligence = 400;
                    buffUpMind = 300;
                    amplifyBattleSpeed = 1.15f;
                    amplifyPotential = 1.05f;
                    cost = 1100000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Rare;
                    limitValue = RARE_EPIC_ITEM_STACK_SIZE;
                    break;
                case FIX.RARE_SIN_CRYSTAL_SOLID:
                    description = "存在を求めようとする光を感じ取られる造形物。力＋４００、知＋３００、体＋６００、戦応率＋１５％、潜力率＋５％";
                    buffUpStrength = 400;
                    buffUpIntelligence = 300;
                    buffUpStamina = 600;
                    amplifyBattleResponse = 1.15f;
                    amplifyPotential = 1.05f;
                    cost = 1100000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Rare;
                    limitValue = RARE_EPIC_ITEM_STACK_SIZE;
                    break;
                case FIX.RARE_EVERMIND_SENSE:
                    description = "永久から連なる螺旋を感じ取られる造形物。力＋２００、技＋２００、知＋２００、体＋２００、心＋６００、潜力率＋２５％";
                    buffUpStrength = 200;
                    buffUpAgility = 200;
                    buffUpIntelligence = 200;
                    buffUpStamina = 200;
                    buffUpMind = 600;
                    amplifyPotential = 1.25f;
                    cost = 1100000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Rare;
                    limitValue = RARE_EPIC_ITEM_STACK_SIZE;
                    break;
                case FIX.RARE_DEVIL_SUMMONER_TOME:
                    description = "異形の悪魔を召喚することが出来るトーム。力＋５００、知＋５００、心＋５００";
                    description += "\r\n【特殊能力】　使用したターン以降、毎ターン装備者が敵に攻撃をする度に、加えて【火/闇】属性の追加ダメージを与える。";
                    buffUpStrength = 500;
                    buffUpIntelligence = 500;
                    buffUpMind = 500;
                    useSpecialAbility = true;
                    cost = 1150000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Rare;
                    limitValue = RARE_EPIC_ITEM_STACK_SIZE;
                    break;
                case FIX.RARE_ARCHANGEL_CONTRACT:
                    description = "大天使との契約を誓いとする事で、保護の恩恵を受ける。体＋５００";
                    description += "\r\n【常備能力】　ターン終了時、物理攻撃/物理防御/魔法攻撃/魔法防御/戦闘速度/戦闘反応/潜在能力DOWNのBUFFを解除する。";
                    buffUpStamina = 500;
                    useSpecialAbility = true;
                    cost = 1150000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Rare;
                    limitValue = RARE_EPIC_ITEM_STACK_SIZE;
                    break;
                case FIX.RARE_DARKNESS_COIN:
                    description = "闇の存在と無法の契約を交わした証として配布されるコイン。";
                    description += "\r\n【常備能力】　スキル使用時、スキルポイントが不足している場合、ライフを1/5失ってスキルを発動する。この効果は装備している限り、永続する。";
                    cost = 1150000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Rare;
                    limitValue = RARE_EPIC_ITEM_STACK_SIZE;
                    break;
                case FIX.RARE_SOUSUI_HIDENSYO:
                    description = "ラグンタット悠古紀から存在するスキル伝承の総帥が記した秘伝書。体＋７００";
                    description += "\r\n【常備能力】　最大スキルポイント＋２０";
                    description += "\r\n【特殊能力】　スキル「バイオレント・スラッシュ」を発動する。";
                    effectValue1 = 20;
                    BuffUpStamina = 700;
                    cost = 1200000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Rare;
                    limitValue = RARE_EPIC_ITEM_STACK_SIZE;
                    break;
                case FIX.RARE_MEEK_HIDENSYO:
                    description = "ラグンタット悠古紀から存在するスキル伝承の若輩者が記した秘伝書。体＋７００";
                    description += "\r\n【常備能力】　最大スキルポイント＋２０";
                    description += "\r\n【特殊能力】　スキル「リカバー」を発動する。";
                    effectValue1 = 20;
                    BuffUpStamina = 700;
                    cost = 1200000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Rare;
                    limitValue = RARE_EPIC_ITEM_STACK_SIZE;
                    break;
                case FIX.RARE_JUKUTATUSYA_HIDENSYO:
                    description = "ラグンタット悠古紀から存在するスキル伝承の熟達者が記した秘伝書。体＋７００";
                    description += "\r\n【常備能力】　最大スキルポイント＋２０";
                    description += "\r\n【特殊能力】　スキル「スウィフト・ステップ」を発動する。";
                    effectValue1 = 20;
                    BuffUpStamina = 700;
                    cost = 1200000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Rare;
                    limitValue = RARE_EPIC_ITEM_STACK_SIZE;
                    break;
                case FIX.RARE_KYUUDOUSYA_HIDENSYO:
                    description = "ラグンタット悠古紀から存在するスキル伝承の求道者が記した秘伝書。体＋７００";
                    description += "\r\n【常備能力】　最大スキルポイント＋２０";
                    description += "\r\n【特殊能力】　スキル「フューチャー・ヴィジョン」を発動する。";
                    effectValue1 = 20;
                    BuffUpStamina = 700;
                    cost = 1200000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Rare;
                    limitValue = RARE_EPIC_ITEM_STACK_SIZE;
                    break;
                case FIX.RARE_DANZAI_ANGEL_GOHU:
                    description = "断罪天使が生者に対して送り届ける護符。体＋５５０、物防率＋１０％、魔防率＋１０％、光耐性7500、闇耐性7500、火耐性7500、水耐性7500、理耐性7500、空耐性7500、\r\n毒耐性、沈黙耐性、スタン耐性、麻痺耐性、凍結耐性、誘惑耐性、鈍化耐性、暗闇耐性、スリップ耐性";
                    buffUpStamina = 550;
                    ResistLight = 7500;
                    ResistShadow = 7500;
                    ResistFire = 7500;
                    ResistIce = 7500;
                    ResistForce = 7500;
                    ResistWill = 7500;
                    ResistPoison = true;
                    ResistSilence = true;
                    ResistStun = true;
                    ResistParalyze = true;
                    ResistFrozen = true;
                    ResistTemptation = true;
                    ResistSlow = true;
                    ResistBlind = true;
                    ResistSlip = true;
                    cost = 1500000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Rare;
                    limitValue = RARE_EPIC_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_INITIATE_SWORD:
                    description = "黒赤く光る部位は炎を連想させる、異形の剣。物理攻撃５８４～６５２";
                    PhysicalAttackMinValue = 584;
                    PhysicalAttackMaxValue = 652;
                    cost = 890000;
                    AdditionalDescription(ItemType.Weapon_Heavy);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_BULLET_KNUCKLE:
                    description = "刃先部が鋭くとがっており、遠目に見ると弾丸を連想させる爪。物理攻撃５９１～６２８";
                    PhysicalAttackMinValue = 591;
                    PhysicalAttackMaxValue = 628;
                    cost = 890000;
                    AdditionalDescription(ItemType.Weapon_Light);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_KENTOUSI_SWORD:
                    description = "古来より剣闘士は死の間際まで、剣を離さないと言い伝えられている。物理攻撃３１８～９２５";
                    PhysicalAttackMinValue = 318;
                    PhysicalAttackMaxValue = 925;
                    cost = 890000;
                    AdditionalDescription(ItemType.Weapon_TwoHand);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_ELECTRO_ROD:
                    description = "電磁力と魔法は似て非なるものだが、魔法と同等の物質量を生み出せる技術が蓄積されている杖。魔法攻撃４２５～５６０";
                    MagicAttackMinValue = 425;
                    MagicAttackMaxValue = 560;
                    cost = 890000;
                    AdditionalDescription(ItemType.Weapon_Rod);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_FORTIFY_SCALE:
                    description = "装備者の体格の原型がわからなくなるほどのゴツい鎧。物理防御１６２～１８８";
                    PhysicalDefenseMinValue = 162;
                    PhysicalDefenseMaxValue = 188;
                    cost = 860000;
                    AdditionalDescription(ItemType.Armor_Heavy);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_MURYOU_CROSS:
                    description = "装備している感触をまったく感じさせない舞踏衣。物理防御１４８～１５６";
                    PhysicalDefenseMinValue = 148;
                    PhysicalDefenseMaxValue = 156;
                    cost = 860000;
                    AdditionalDescription(ItemType.Armor_Light);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_COLORLESS_ROBE:
                    description = "装着者のイメージを連想させる色がローブ。物理防御１０６～１２２、魔法防御力１８９～２１２";
                    PhysicalDefenseMinValue = 106;
                    PhysicalDefenseMaxValue = 122;
                    MagicDefenseMinValue = 189;
                    MagicDefenseMaxValue = 212;
                    cost = 860000;
                    AdditionalDescription(ItemType.Armor_Light);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_LOGISTIC_SHIELD:
                    description = "魔法によるダメージをあたかも物理と見立てて防御可能とした盾。物理防御７５～９５、魔法防御力７０～７２";
                    PhysicalDefenseMinValue = 75;
                    PhysicalDefenseMaxValue = 95;
                    MagicDefenseMinValue = 70;
                    MagicDefenseMaxValue = 72;
                    cost = 340000;
                    AdditionalDescription(ItemType.Shield);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.RARE_ETHREAL_EDGE_SABRE:
                    description = "イスリアル素材による強靭な剣。剣を振った時、透明色が増し切っ先が見えなくなる。物理攻撃８２１～９６５";
                    PhysicalAttackMinValue = 821;
                    PhysicalAttackMaxValue = 965;
                    cost = 2260000;
                    AdditionalDescription(ItemType.Weapon_Heavy);
                    rareLevel = RareLevel.Rare;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.RARE_SHINGETUEN_CLAW:
                    description = "月の曲線を描くように全体が丸く曲がっている爪。物理攻撃８７７～９４３";
                    PhysicalAttackMinValue = 877;
                    PhysicalAttackMaxValue = 943;
                    cost = 2260000;
                    AdditionalDescription(ItemType.Weapon_Light);
                    rareLevel = RareLevel.Rare;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.RARE_BLOODY_DIRTY_SCYTHE:
                    description = "おびただしい数の血痕がまとわりついている大鎌。物理攻撃４６６～１４２３";
                    PhysicalAttackMinValue = 466;
                    PhysicalAttackMaxValue = 1423;
                    cost = 2260000;
                    AdditionalDescription(ItemType.Weapon_TwoHand);
                    rareLevel = RareLevel.Rare;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.RARE_ALL_ELEMENTAL_ROD:
                    description = "全属性の魔力が均等に込められている大杖。魔法攻撃７０５～８３９";
                    MagicAttackMinValue = 705;
                    MagicAttackMaxValue = 839;
                    cost = 2260000;
                    AdditionalDescription(ItemType.Weapon_Rod);
                    rareLevel = RareLevel.Rare;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.RARE_BLOOD_BLAZER_CROSS:
                    description = "赤い絹糸にイスリアル製の素材が編み込まれている舞踏衣。全体の模様が血管の様に見える。物理防御３２５～３４５";
                    PhysicalDefenseMinValue = 325;
                    PhysicalDefenseMaxValue = 345;
                    cost = 1450000;
                    AdditionalDescription(ItemType.Armor_Light);
                    rareLevel = RareLevel.Rare;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.RARE_DARK_ANGEL_ROBE:
                    description = "真っ黒なローブをまとった姿は黒衣の天使を連想させる。物理防御１９０～２３４、魔法防御力４９２～６５２";
                    description += "\r\n【常備能力】　聖魔法１０％強化、闇属性１０％強化";
                    PhysicalDefenseMinValue = 190;
                    PhysicalDefenseMaxValue = 234;
                    MagicDefenseMinValue = 492;
                    MagicDefenseMaxValue = 652;
                    amplifyLight = 1.1f;
                    amplifyShadow = 1.1f;
                    cost = 1600000;
                    AdditionalDescription(ItemType.Armor_Light);
                    rareLevel = RareLevel.Rare;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.RARE_MAJEST_HAZZARD_SHIELD:
                    description = "権威のオーラを放つかの如く、分厚い装甲の盾。物理防御１０５～１３０、魔法防御力１４０～１５０";
                    PhysicalDefenseMinValue = 105;
                    PhysicalDefenseMaxValue = 130;
                    MagicDefenseMinValue = 140;
                    MagicDefenseMaxValue = 150;
                    cost = 720000;
                    AdditionalDescription(ItemType.Shield);
                    rareLevel = RareLevel.Rare;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.RARE_WHITE_DIAMOND_SHIELD:
                    description = "白く透明な輝きを持つダイヤモンド成分を含んだ大きな盾。物理防御１２０～１４５";
                    PhysicalDefenseMinValue = 120;
                    PhysicalDefenseMaxValue = 145;
                    cost = 725000;
                    AdditionalDescription(ItemType.Shield);
                    rareLevel = RareLevel.Rare;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.RARE_VAPOR_SOLID_SHIELD:
                    description = "蒸気型の粒子を完結合させ、固体化に成功した盾。重量が軽さと反比例して重厚な作り。物理防御１６３～１７５";
                    PhysicalDefenseMinValue = 163;
                    PhysicalDefenseMaxValue = 175;
                    cost = 730000;
                    AdditionalDescription(ItemType.Shield);
                    rareLevel = RareLevel.Rare;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                // ガンツ武器屋
                case FIX.RARE_TYOU_KOU_SWORD:
                    description = "合金製の素材を何度も何度も鍛え直し、超絶に硬い剣が完成した。物理攻撃１０００～１２５０";
                    PhysicalAttackMinValue = 1000;
                    PhysicalAttackMaxValue = 1250;
                    cost = 3000000;
                    AdditionalDescription(ItemType.Weapon_Heavy);
                    rareLevel = RareLevel.Rare;
                    break;

                case FIX.RARE_TYOU_KOU_ARMOR:
                    description = "合金製の素材をフルに駆使し、超絶に硬い鎧が完成した。物理防御４４０～５５０";
                    PhysicalDefenseMinValue = 440;
                    PhysicalDefenseMaxValue = 550;
                    cost = 2200000;
                    AdditionalDescription(ItemType.Armor_Heavy);
                    rareLevel = RareLevel.Rare;
                    break;

                case FIX.RARE_TYOU_KOU_SHIELD:
                    description = "合金製の素材を盾全体に行き渡らせ、超絶に硬い盾が完成した。物理防御１９０～２００";
                    PhysicalDefenseMinValue = 190;
                    PhysicalDefenseMaxValue = 200;
                    cost = 1600000;
                    AdditionalDescription(ItemType.Shield);
                    rareLevel = RareLevel.Rare;
                    break;

                case FIX.RARE_SUPERIOR_CHOSEN_ROD:
                    description = "厳選された合金製の素材を杖の先端部に丸型にして溶接したロッド。魔法攻撃７６８～８９３";
                    MagicAttackMinValue = 768;
                    MagicAttackMaxValue = 893;
                    cost = 3000000;
                    AdditionalDescription(ItemType.Weapon_Rod);
                    rareLevel = RareLevel.Rare;
                    break;

                case FIX.RARE_WHITE_GOLD_CROSS:
                    description = "合金製の素材をマイクロ単位の薄い形状に変化させ、衣状の形に仕立て上げた。物理防御３４７～３７０、魔法防御３４０～３７０";
                    PhysicalDefenseMinValue = 340;
                    PhysicalDefenseMaxValue = 370;
                    MagicDefenseMinValue = 340;
                    MagicDefenseMaxValue = 370;
                    cost = 2150000;
                    AdditionalDescription(ItemType.Armor_Light);
                    rareLevel = RareLevel.Rare;
                    break;

                case FIX.RARE_HUNTERS_EYE: // ハンターの七つ道具
                    description = "ハンター七つ道具を組み合わせて作成された擬眼。眼の動向の開き方に応じて様々なギミックが発動する。技＋３００、体＋３００、沈黙耐性、麻痺耐性、鈍化耐性、暗闇耐性";
                    description += "\r\n【特殊能力】　以下のいずれかがランダムに発動する。\r\n　　敵全体に対して【鈍化】効果を与える / 味方全体のいずれかがトゥルス・ヴィジョンがかかっていない場合、トゥルス・ヴィジョンを発動する \r\n    / 自分自身の物理攻撃と戦闘速度をUPする / 敵単体の物理攻撃と戦闘速度をDOWNさせる";
                    buffUpAgility = 300;
                    buffUpStamina = 300;
                    useSpecialAbility = true;
                    ResistSilence = true;
                    ResistParalyze = true;
                    ResistSlow = true;
                    ResistBlind = true;
                    cost = 950000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Rare;
                    break;
                case FIX.RARE_ONEHUNDRED_BUTOUGI: // 猛獣の毛皮
                    description = "選りすぐりの獣皮を集約し、動きやすさ・重量感を重視したもの。物理防御１６４～１７８、聖耐性15000、闇耐性15000、火耐性15000、水耐性15000";
                    description += "\r\n【常備能力】　まれに物理/魔法による攻撃を回避する。";
                    PhysicalDefenseMinValue = 164;
                    PhysicalDefenseMaxValue = 178;
                    ResistLight = 15000;
                    ResistShadow = 15000;
                    ResistFire = 15000;
                    ResistIce = 15000;
                    cost = 1125000;
                    AdditionalDescription(ItemType.Armor_Light);
                    rareLevel = RareLevel.Rare;
                    break;

                case FIX.RARE_DARKANGEL_CROSS: // 執行人の汚れたローブ、天使のシルク
                    description = "執行人のローブから高級なシルク素材を摘出し、天使のシルクと融合させて新たに創生した衣。";
                    description += "\r\n防御力１９０～２３４、魔法防御４９２～６５２、聖耐性22000、闇耐性22000、毒耐性、誘惑耐性、鈍化耐性、暗闇耐性";
                    description += "\r\n【常備能力】　聖魔法１０％強化、闇魔法１０％強化";
                    PhysicalDefenseMinValue = 190;
                    PhysicalDefenseMaxValue = 234;
                    MagicDefenseMinValue = 492;
                    MagicDefenseMaxValue = 652;
                    ResistLight = 22000;
                    ResistShadow = 22000;
                    ResistPoison = true;
                    ResistTemptation = true;
                    ResistSlow = true;
                    ResistBlind = true;
                    AmplifyLight = 1.1f;
                    AmplifyShadow = 1.1f;
                    cost = 1600000;
                    AdditionalDescription(ItemType.Armor_Light);
                    rareLevel = RareLevel.Rare;
                    break;

                case FIX.RARE_DEVIL_KILLER: // 錆付いたガラクタ武具、エッセンス・オブ・ダーク
                    description = "悪しき者を断つ剣。ガラクタから生成したとは思えないガンツ渾身の力作。物理攻撃３６０～１８８５";
                    description += "\r\n【常備能力】　稀に即死させる。";
                    PhysicalAttackMinValue = 360;
                    PhysicalAttackMaxValue = 1885;
                    cost = 3000000;
                    AdditionalDescription(ItemType.Weapon_Heavy);
                    rareLevel = RareLevel.Rare;
                    break;

                case FIX.RARE_TRUERED_MASTER_BLADE: // シーカーの頭蓋骨、マスターブレイドの破片、エッセンス・オブ・フレイム
                    description = "頭蓋骨を破砕した素材を柄に付け、剣の切っ先は常に火が宿る。物理攻撃８００～８５０、魔法攻撃６５０～７００";
                    description += "\r\n【常備能力】　物理攻撃がヒットする度に、稀にワード・オブ・パワーが追加効果で発動する。";
                    description += "\r\n    魔法攻撃がヒットする度に、稀にサイキック・ウェイブが追加効果で発動する。";
                    PhysicalAttackMinValue = 800;
                    PhysicalAttackMaxValue = 850;
                    MagicAttackMinValue = 650;
                    MagicAttackMaxValue = 700;
                    cost = 2400000;
                    AdditionalDescription(ItemType.Weapon_Heavy);
                    rareLevel = RareLevel.Rare;
                    break;

                case FIX.RARE_VOID_HYMNSONIA: // 豪華なジュエルクラウン、怨霊箱
                    description = "豪華な財宝を与える事で怨霊を全て除去した箱。力＋５００、技＋５００、知＋５００、闇耐性10000毒耐性、沈黙耐性、スタン耐性、麻痺耐性、凍結耐性、誘惑耐性、鈍化耐性、暗闇耐性、スリップ耐性";
                    description += "\r\n【常備能力】　戦闘開始時、心パラメタが１になる。";
                    description += "\r\n【特殊能力】　本装備品により【心】パラメタが１になった特性を解除する。戦闘終了までこの効果は継続する。";
                    buffUpStrength = 500;
                    buffUpAgility = 500;
                    buffUpIntelligence = 500;
                    ResistShadow = 10000;
                    ResistPoison = true;
                    ResistSilence = true;
                    ResistStun = true;
                    ResistParalyze = true;
                    ResistFrozen = true;
                    ResistTemptation = true;
                    ResistSlow = true;
                    ResistBlind = true;
                    ResistSlip = true;
                    cost = 1180000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Rare;
                    break;

                case FIX.RARE_SEAL_OF_BALANCE: // 組み立て素材　天秤、組み立て素材　天分銅、組み立て素材　天秤棒
                    description = "天秤の形状を再構築し、紋章の形状に変換することに成功。体＋５００、心＋５００、水耐性5000、空耐性5000";
                    description += "\r\n【常備能力】　物理攻撃を受けた場合、マナが回復する。魔法攻撃を受けた場合、スキルポイントが回復する。DEBUFF属性が付与された場合、次のターンそのBUFFを解除する。";
                    buffUpStamina = 500;
                    buffUpMind = 500;
                    ResistIce = 5000;
                    ResistWill = 5000;
                    cost = 1040000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Rare;
                    break;

                case FIX.RARE_DOOMBRINGER: // ドゥームブリンガーの柄、ドゥームブリンガーの欠片
                    description = "破滅した者へ永遠の安らぎをもたらすために作られた剣。物理攻撃４７３～１４６９";
                    description += "\r\n【常備能力】　理魔法＋１０％強化。";
                    description += "\r\n              戦闘開始時、ゲイル・ウィンドが自分自身にかかる。";
                    PhysicalAttackMinValue = 473;
                    PhysicalAttackMaxValue = 1469;
                    amplifyForce = 1.1f;
                    cost = 2400000;
                    AdditionalDescription(ItemType.Weapon_TwoHand);
                    rareLevel = RareLevel.Rare;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.EPIC_MEIKOU_DOOMBRINGER: // ドゥームブリンガー、浄火の鍛造
                    description = "穢れを取り払われた闇の剣。持ち主の意図に関わらず、剣が宿主を選ぶ。物理攻撃１２００～２４００、魔法攻撃１２００～２４００、物攻率＋２５％、魔攻率＋２０％、戦速率＋１５％";
                    description += "\r\n【常備能力】　理魔法＋１６％強化、聖魔法１６％強化。";
                    description += "\r\n              戦闘開始時、ゲイル・ウィンドが自分自身にかかる。";
                    description += "\r\n              戦闘開始時、ジェネシスの行動記憶に【ゲイル・ウィンド】がセットされる。";
                    PhysicalAttackMinValue = 1200;
                    PhysicalAttackMaxValue = 2400;
                    MagicAttackMinValue = 1200;
                    MagicAttackMaxValue = 2400;
                    buffUpStrength = 777;
                    buffUpAgility = 555;
                    buffUpIntelligence = 666;
                    amplifyPhysicalAttack = 1.25;
                    amplifyMagicAttack = 1.20;
                    amplifyBattleSpeed = 1.15;
                    amplifyForce = 1.16;
                    amplifyLight = 1.16;
                    cost = 10000000;
                    AdditionalDescription(ItemType.Weapon_TwoHand);
                    rareLevel = RareLevel.Rare;
                    break;

                // 宝箱

                // EPIC

                case FIX.EPIC_EZEKRIEL_ARMOR_SIGIL:
                    description = "古代賢者エゼクリエルが壮年時代に付けていた鎧。防御力１１２６～１３９７、魔法防御６７２～８３０、力＋８５０、技＋６２０、知＋５３０、体＋７４０";
                    description += "\r\n物防率＋２５％、魔法防御率＋２５％、聖耐性35000、闇耐性35000、火耐性35000、水耐性35000";
                    description += "\r\n毒耐性、沈黙耐性、スタン耐性、麻痺耐性、凍結耐性、誘惑耐性、鈍化耐性、暗闇耐性、スリップ耐性";
                    description += "\r\n【常備能力】毎ターン、ライフとマナとスキルポイントが回復する。";
                    description += "\r\n魔法消費１０％軽減。  スキルポイント消費１０％軽減。";
                    PhysicalDefenseMinValue = 1126;
                    PhysicalDefenseMaxValue = 1397;
                    MagicDefenseMinValue = 672;
                    MagicDefenseMaxValue = 830;
                    buffUpStrength = 850;
                    buffUpAgility = 620;
                    buffUpIntelligence = 530;
                    buffUpStamina = 740;
                    ResistFire = 35000;
                    ResistIce = 35000;
                    ResistLight = 35000;
                    ResistShadow = 35000;
                    amplifyPhysicalDefense = 1.25;
                    amplifyMagicDefense = 1.25;
                    ResistPoison = true;
                    ResistSilence = true;
                    ResistStun = true;
                    ResistParalyze = true;
                    ResistFrozen = true;
                    ResistTemptation = true;
                    ResistSlow = true;
                    ResistBlind = true;
                    ResistSlip = true;
                    manaCostReduction = 0.1f;
                    skillCostReduction = 0.1f;
                    cost = 0;
                    AdditionalDescription(ItemType.Armor_Heavy);
                    rareLevel = RareLevel.Epic;
                    break;

                case FIX.EPIC_SHEZL_THE_MIRAGE_LANCER:
                    description = "古代賢者シェズルが壮年時代に振るっていた剣。物理攻撃１６８０～１８５５、魔法攻撃１５２２～１７２８、技＋７５０、知＋９５０、心＋５５０";
                    description += "\r\n魔攻率＋２５％、戦応率＋２０％、潜力率＋１５％";
                    description += "\r\n【常備能力】この剣から物理攻撃がヒットした際、ダブルヒットとして扱われる。";
                    PhysicalAttackMinValue = 1680;
                    PhysicalAttackMaxValue = 1855;
                    MagicAttackMinValue = 1522;
                    MagicAttackMaxValue = 1728;
                    buffUpAgility = 750;
                    buffUpIntelligence = 950;
                    buffUpMind = 550;
                    amplifyMagicAttack = 1.25;
                    amplifyBattleResponse = 1.20;
                    amplifyPotential = 1.15;
                    cost = 0;
                    AdditionalDescription(ItemType.Weapon_Heavy);
                    rareLevel = RareLevel.Epic;
                    break;

                case FIX.EPIC_JUZA_THE_PHANTASMAL_CLAW:
                    description = "古代賢者ジュザが壮年時代に振るっていた爪。物理攻撃１９８４～２０２１、力＋９５０、技＋７５０、体＋５５０";
                    description += "\r\n物攻率＋２５％、戦速率＋２０％、戦応率＋１５％";
                    description += "\r\n【常備能力】物理攻撃がヒットするたびに、颯の蓄積カウンターが１つ自分にBUFFとして蓄積する。蓄積されたカウンターの分だけ、戦闘速度が２％ずつ上昇する。最大10個まで蓄積が行える。";
                    PhysicalAttackMinValue = 1984;
                    PhysicalAttackMaxValue = 2021;
                    buffUpStrength = 950;
                    buffUpAgility = 750;
                    buffUpStamina = 550;
                    amplifyPhysicalAttack = 1.25;
                    amplifyBattleSpeed = 1.20;
                    amplifyBattleResponse = 1.15;
                    cost = 0;
                    AdditionalDescription(ItemType.Weapon_Light);
                    rareLevel = RareLevel.Epic;
                    break;

                case FIX.EPIC_ADILRING_OF_BLUE_BURN:
                    description = "古代賢者エーディルが壮年時代に装着していた蒼く光るリング。物理攻撃１０５０～１１５０、魔法攻撃１２５０～１３５０。力＋５５０、知＋１０５０、心＋５５０、沈黙耐性、凍結耐性、鈍化耐性";
                    description += "\r\n物攻率＋１０％、魔攻率＋３０％、潜力率＋１０％、聖耐性10000、闇耐性10000、火耐性10000、水耐性75000、理耐性10000、空耐性10000";
                    description += "\r\n【常備能力】任意の行動を行うたびに、蒼の蓄積カウンターが１つ自分にBUFFとして蓄積する。最大30個まで蓄積が行える。";
                    description += "\r\n【特殊能力】単一の敵に対して、無属性のダメージを与える。ダメージ量は蒼の蓄積カウンターに依存する。";
                    PhysicalAttackMinValue = 1050;
                    PhysicalAttackMaxValue = 1150;
                    MagicAttackMinValue = 1250;
                    MagicAttackMaxValue = 1350;
                    buffUpStrength = 550;
                    buffUpIntelligence = 1050;
                    buffUpMind = 550;
                    amplifyPhysicalAttack = 1.10;
                    amplifyMagicAttack = 1.30;
                    amplifyPotential = 1.10;
                    ResistLight = 10000;
                    ResistShadow = 10000;
                    ResistFire = 10000;
                    ResistIce = 75000;
                    ResistForce = 10000;
                    ResistWill = 10000;
                    ResistSilence = true;
                    ResistFrozen = true;
                    ResistSlow = true;
                    cost = 0;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Epic;
                    break;

                case FIX.EPIC_ETERNAL_HOMURA_RING:
                    description = "その焔火が潰える事は未だかつて起きた事がない。魔法攻撃１８５０～２０５０、知＋１２５０、スタン耐性、麻痺耐性、凍結耐性";
                    description += "\r\n魔攻率＋３５％、魔防率３０％、聖耐性10000、闇耐性10000、火耐性75000、水耐性75000、理耐性10000、空耐性10000";
                    description += "\r\n【常備能力】毎ターン、MPを回復する。";
                    description += "\r\n【特殊能力】全MPを消費して、消費したMPの分だけ、無属性魔法ダメージを与える。";
                    useSpecialAbility = true;
                    MagicAttackMinValue = 1850;
                    MagicAttackMaxValue = 2050;
                    buffUpIntelligence = 1250;
                    amplifyMagicAttack = 1.35;
                    amplifyMagicDefense = 1.30;
                    ResistLight = 10000;
                    ResistShadow = 10000;
                    ResistFire = 75000;
                    ResistIce = 10000;
                    ResistForce = 10000;
                    ResistWill = 10000;
                    ResistStun = true;
                    ResistParalyze = true;
                    ResistFrozen = true;
                    cost = 0;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Epic;
                    limitValue = RARE_EPIC_ITEM_STACK_SIZE;
                    break;

                // 素材
                case FIX.COMMON_BLACK_SALT:
                    description = "得たいの知れない黒く変色した物体・・・微妙に何かツンとした匂いがする。";
                    cost = 1200000;
                    AdditionalDescription(ItemType.Material_Food);
                    rareLevel = RareLevel.Common;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_FEBL_ANIS:
                    description = "フェブルの大地に稀に映える植物。果物のような香りがほんのりする。";
                    cost = 1200000;
                    AdditionalDescription(ItemType.Material_Food);
                    rareLevel = RareLevel.Common;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_SMORKY_HUNNY:
                    description = "煙状のように拡がり、甘い香りを発する植物から、その名が付けられた。";
                    cost = 1200000;
                    AdditionalDescription(ItemType.Material_Food);
                    rareLevel = RareLevel.Common;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_ANGEL_DUST:
                    description = "天使の衣の一部から食用の繊維が入手出来ると言われている。";
                    cost = 1200000;
                    AdditionalDescription(ItemType.Material_Food);
                    rareLevel = RareLevel.Common;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_SUN_TARAGON:
                    description = "濃い光沢のある先の尖った植物。サクサクっとした食感が期待できる。";
                    cost = 1200000;
                    AdditionalDescription(ItemType.Material_Food);
                    rareLevel = RareLevel.Common;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_ECHO_BEAST_MEAT:
                    description = "共鳴音を奏でるのが得意な生物エコービーストのもも肉。";
                    cost = 1200000;
                    AdditionalDescription(ItemType.Material_Food);
                    rareLevel = RareLevel.Common;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_CHAOS_TONGUE:
                    description = "カオス・ワーデンが最後の断末魔をあげた直後に舌を切り取ると、非常に美味とされている。";
                    cost = 1200000;
                    AdditionalDescription(ItemType.Material_Food);
                    rareLevel = RareLevel.Common;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                #endregion
                #region "５階：ランダムドロップ"
                case FIX.COMMON_RED_CRYSTAL:
                    description = "永久の時代よりその輝きは失われていない、真紅のクリスタル。力＋１４００";
                    buffUpStrength = 1400;
                    cost = 2000000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_BLUE_CRYSTAL:
                    description = "永久の時代よりその輝きは失われていない、瑠璃のクリスタル。技＋１４００";
                    buffUpAgility = 1400;
                    cost = 2000000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_PURPLE_CRYSTAL:
                    description = "永久の時代よりその輝きは失われていない、紫苑のクリスタル。知＋１４００";
                    buffUpIntelligence = 1400;
                    cost = 2000000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_GREEN_CRYSTAL:
                    description = "永久の時代よりその輝きは失われていない、翡翠のクリスタル。体＋１４００";
                    buffUpStamina = 1400;
                    cost = 2000000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_YELLOW_CRYSTAL:
                    description = "永久の時代よりその輝きは失われていない、琥珀のクリスタル。心＋１４００";
                    buffUpMind = 1400;
                    cost = 2000000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_PLATINUM_RING_1:
                    description = "白金の素材で形成された腕輪。『白虎』の刻印が刻まれている。力＋６５０、技＋６５０";
                    buffUpStrength = 650;
                    buffUpAgility = 650;
                    cost = 1600000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_PLATINUM_RING_2:
                    description = "白金の素材で形成された腕輪。『ヴァルキリー』の刻印が刻まれている。力＋６５０、知＋６５０";
                    buffUpStrength = 650;
                    buffUpIntelligence = 650;
                    cost = 1600000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_PLATINUM_RING_3:
                    description = "白金の素材で形成された腕輪。『ナイトメア』の刻印が刻まれている。力＋６５０、体＋６５０";
                    buffUpStrength = 650;
                    buffUpStamina = 650;
                    cost = 1600000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_PLATINUM_RING_4:
                    description = "白金の素材で形成された腕輪。『ナラシンハ』の刻印が刻まれている。力＋６５０、心＋６５０";
                    buffUpStrength = 650;
                    buffUpMind = 650;
                    cost = 1600000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_PLATINUM_RING_5:
                    description = "白金の素材で形成された腕輪。『朱雀』の刻印が刻まれている。技＋６５０、知＋６５０";
                    buffUpAgility = 650;
                    buffUpIntelligence = 650;
                    cost = 1600000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_PLATINUM_RING_6:
                    description = "白金の素材で形成された腕輪。『ウロボロス』の刻印が刻まれている。技＋６５０、体＋６５０";
                    buffUpAgility = 650;
                    buffUpStamina = 650;
                    cost = 1600000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_PLATINUM_RING_7:
                    description = "白金の素材で形成された腕輪。『ナインテイル』の刻印が刻まれている。技＋６５０、心＋６５０";
                    buffUpAgility = 650;
                    buffUpMind = 650;
                    cost = 1600000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_PLATINUM_RING_8:
                    description = "白金の素材で形成された腕輪。『ベヒモス』の刻印が刻まれている。知＋６５０、体＋６５０";
                    buffUpIntelligence = 650;
                    buffUpStamina = 650;
                    cost = 1600000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_PLATINUM_RING_9:
                    description = "白金の素材で形成された腕輪。『青龍』の刻印が刻まれている。知＋６５０、心＋６５０";
                    buffUpIntelligence = 650;
                    buffUpMind = 650;
                    cost = 1600000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_PLATINUM_RING_10:
                    description = "白金の素材で形成された腕輪。『玄武』の刻印が刻まれている。体＋６５０、心＋６５０";
                    buffUpStamina = 650;
                    buffUpMind = 650;
                    cost = 1600000;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                #endregion
                #region "ラナの薬品店"
                #region "ダンジョン１階"
                // 初版
                case FIX.POOR_SMALL_GREEN_POTION:
                    description = "小さめに作られたスキル回復用の薬。回復量５～１０";
                    PhysicalAttackMinValue = 5;
                    PhysicalAttackMaxValue = 10;
                    cost = 150;
                    AdditionalDescription(ItemType.Use_Potion);
                    rareLevel = RareLevel.Common;
                    break;
                case FIX.POOR_POTION_CURE_POISON:
                    description = "少量の毒を瞬時に浄化する薬。効果【猛毒】を解除。";
                    PhysicalAttackMinValue = 100;
                    PhysicalAttackMaxValue = 100;
                    cost = 200;
                    AdditionalDescription(ItemType.Use_Potion);
                    rareLevel = RareLevel.Poor;
                    break;

                case FIX.COMMON_REVIVE_POTION_MINI:
                    description = "死亡したパーティメンバーを復活させる薬。ライフ１で復活する。一度使うと無くなる。";
                    cost = 2000;
                    AdditionalDescription(ItemType.Use_Potion);
                    rareLevel = RareLevel.Common;
                    limitValue = RARE_EPIC_ITEM_STACK_SIZE;
                    break;

                // 合成
                case FIX.COMMON_POTION_NATURALIZE:
                    description = "自然素材の緑色素を調合した浄化薬。効果【猛毒】【鈍化】を解除。【戦闘中専用】";
                    PhysicalAttackMinValue = 100;
                    PhysicalAttackMaxValue = 100;
                    cost = 700;
                    AdditionalDescription(ItemType.Use_Potion);
                    rareLevel = RareLevel.Common;
                    break;
                case FIX.COMMON_POTION_RESIST_FIRE:
                    description = "枯れた茎から抽出した耐熱成分を体液と融合させた薬。火耐性５０。【戦闘中専用】";
                    cost = 850;
                    AdditionalDescription(ItemType.Use_Potion);
                    rareLevel = RareLevel.Common;
                    break;
                case FIX.COMMON_POTION_MAGIC_SEAL:
                    description = "赤い胞子内から魔法成分を摘出し、統合に成功。魔法攻撃５％ＵＰ。【戦闘中専用】";
                    cost = 1500;
                    AdditionalDescription(ItemType.Use_Potion);
                    rareLevel = RareLevel.Common;
                    break;
                case FIX.COMMON_POTION_ATTACK_SEAL:
                    description = "アルラウネの花粉から筋力を一時増強させる薬。物理攻撃５％ＵＰ。【戦闘中専用】";
                    cost = 1500;
                    AdditionalDescription(ItemType.Use_Potion);
                    rareLevel = RareLevel.Common;
                    break;
                case FIX.COMMON_POTION_CURE_BLIND:
                    description = "闇属性のマンドラゴラに輝く燐粉を織り交ぜた薬。効果【暗闇】を解除。【戦闘中専用】";
                    cost = 2000;
                    AdditionalDescription(ItemType.Use_Potion);
                    rareLevel = RareLevel.Common;
                    break;
                case FIX.RARE_POTION_MOSSGREEN_DREAM:
                    description = "モスの有効なエキスを摘出し、ドリームパウダーで清浄化した薬。効果【猛毒】【鈍化】【暗闇】を解除。【戦闘中専用】";
                    cost = 3500;
                    AdditionalDescription(ItemType.Use_Potion);
                    rareLevel = RareLevel.Rare;
                    break;
                case FIX.RARE_DRYAD_SAGE_POTION:
                    description = "鱗粉とエキスを融合させた薬。強烈な匂いにより敏感な能力を活性化させる。戦闘速度／戦闘反応５％ＵＰ。【戦闘中専用】";
                    cost = 4000;
                    AdditionalDescription(ItemType.Material_Potion);
                    rareLevel = RareLevel.Rare;
                    break;
                #endregion
                #region "ダンジョン２階"
                // 初版
                // 後編調整ポーション。前編の設定とバランスが合わないので新規作成する。
                case FIX.COMMON_NORMAL_RED_POTION:
                    description = "標準的な大きさで作られたライフ回復用の薬。回復量２１２０～３６８０";
                    PhysicalAttackMinValue = 2120;
                    PhysicalAttackMaxValue = 3680;
                    cost = 2000;
                    AdditionalDescription(ItemType.Use_Potion);
                    rareLevel = RareLevel.Common;
                    limitValue = USING_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_NORMAL_BLUE_POTION:
                    description = "標準的な大きさで作られたマナ回復用の薬。回復量４３０～７７０";
                    PhysicalAttackMinValue = 430;
                    PhysicalAttackMaxValue = 770;
                    cost = 2000;
                    AdditionalDescription(ItemType.Use_Potion);
                    rareLevel = RareLevel.Common;
                    limitValue = USING_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_NORMAL_GREEN_POTION:
                    description = "標準的な大きさで作られたスキル回復用の薬。回復量１０～２０";
                    PhysicalAttackMinValue = 10;
                    PhysicalAttackMaxValue = 20;
                    cost = 2000;
                    AdditionalDescription(ItemType.Use_Potion);
                    rareLevel = RareLevel.Common;
                    limitValue = USING_ITEM_STACK_SIZE;
                    break;
                // 合成
                case FIX.COMMON_RESIST_POISON:
                    description = "猛毒成分を抽出し、化学式の再配列に成功。【猛毒】解除し【猛毒】耐性を付与。【戦闘中専用】";
                    cost = 12000;
                    AdditionalDescription(ItemType.Use_Potion);
                    rareLevel = RareLevel.Common;
                    limitValue = USING_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_POTION_OVER_GROWTH:
                    description = "異常成長した卵から、成長促進エキスを摘出し、調合した薬。最大ライフ1000ＵＰ【戦闘中専用】";
                    cost = 14000;
                    AdditionalDescription(ItemType.Use_Potion);
                    rareLevel = RareLevel.Common;
                    limitValue = USING_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_POTION_RAINBOW_IMPACT:
                    description = "戦闘能力低下に対し精神活性を行う七色薬品。【物理攻撃】【魔法攻撃】低下を解除【戦闘中専用】";
                    cost = 15000;
                    AdditionalDescription(ItemType.Use_Potion);
                    rareLevel = RareLevel.Common;
                    limitValue = USING_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_POTION_BLACK_GAST:
                    description = "強力な身体活性と魔力活性エキスを調合した薬品。魔法攻撃/物理攻撃７％ＵＰ【戦闘中専用】";
                    cost = 25000;
                    AdditionalDescription(ItemType.Use_Potion);
                    rareLevel = RareLevel.Common;
                    limitValue = USING_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_SOUKAI_DRINK_SS:
                    description = "スッキリ爽快（Speedy & Splash!）頭と身体が冴えわたる！魔法攻撃／戦闘速度７％ＵＰ【戦闘中専用】";
                    cost = 27000;
                    AdditionalDescription(ItemType.Use_Potion);
                    rareLevel = RareLevel.Common;
                    limitValue = USING_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_TUUKAI_DRINK_DD:
                    description = "ガッツリ痛快（Dont & DoIt!) 身体中に力がみなぎる！物理攻撃／戦闘速度７％ＵＰ【戦闘中専用】";
                    cost = 27000;
                    AdditionalDescription(ItemType.Use_Potion);
                    rareLevel = RareLevel.Common;
                    limitValue = USING_ITEM_STACK_SIZE;
                    break;
                #endregion
                #region "ダンジョン３階"
                case FIX.COMMON_LARGE_RED_POTION:
                    description = "かなり大きめに作られたライフ回復用の薬。回復量９０００～１２０００";
                    PhysicalAttackMinValue = 9000;
                    PhysicalAttackMaxValue = 12000;
                    cost = 15000;
                    AdditionalDescription(ItemType.Use_Potion);
                    rareLevel = RareLevel.Common;
                    limitValue = USING_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_LARGE_BLUE_POTION:
                    description = "かなり大きめに作られたマナ回復用の薬。回復量１４９０～２０４０";
                    PhysicalAttackMinValue = 1490;
                    PhysicalAttackMaxValue = 2040;
                    cost = 15000;
                    AdditionalDescription(ItemType.Use_Potion);
                    rareLevel = RareLevel.Common;
                    limitValue = USING_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_LARGE_GREEN_POTION:
                    description = "かなり大きめに作られたスキル回復用の薬。回復量２０～３０";
                    PhysicalAttackMinValue = 20;
                    PhysicalAttackMaxValue = 30;
                    cost = 15000;
                    AdditionalDescription(ItemType.Use_Potion);
                    rareLevel = RareLevel.Common;
                    limitValue = USING_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_FAIRY_BREATH:
                    description = "フェアリーの息吹には、精神を収める成分が含まれている。【沈黙】を解除し【沈黙】耐性を付与。【戦闘中専用】";
                    cost = 40000;
                    AdditionalDescription(ItemType.Use_Potion);
                    rareLevel = RareLevel.Common;
                    limitValue = USING_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_HEART_ACCELERATION:
                    description = "心臓の状態を最高のコンディションにし、身体の躍動を生み出す。【麻痺】を解除し【麻痺】耐性を付与。【戦闘中専用】";
                    cost = 40000;
                    AdditionalDescription(ItemType.Use_Potion);
                    rareLevel = RareLevel.Common;
                    limitValue = USING_ITEM_STACK_SIZE;
                    break;
                case FIX.RARE_SAGE_POTION_MINI:
                    description = "賢者達の研究結果の一部を拝借した秘薬。全特殊効果を解除し、全耐性を付与。対象者は死亡時、復活できなくなる。【戦闘中専用】";
                    cost = 150000;
                    AdditionalDescription(ItemType.Use_Potion);
                    rareLevel = RareLevel.Common;
                    limitValue = USING_ITEM_STACK_SIZE;
                    break;
                #endregion
                #region "ダンジョン４階"
                case FIX.COMMON_HUGE_RED_POTION:
                    description = "超ビッグサイズで、派手な光沢が施されているライフ回復用の薬。回復量３００００～４５０００";
                    PhysicalAttackMinValue = 30000;
                    PhysicalAttackMaxValue = 45000;
                    cost = 200000;
                    AdditionalDescription(ItemType.Use_Potion);
                    rareLevel = RareLevel.Common;
                    limitValue = USING_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_HUGE_BLUE_POTION:
                    description = "超ビッグサイズで、派手な光沢が施されているマナ回復用の薬。回復量１５０００～１８０００";
                    PhysicalAttackMinValue = 15000;
                    PhysicalAttackMaxValue = 18000;
                    cost = 200000;
                    AdditionalDescription(ItemType.Use_Potion);
                    rareLevel = RareLevel.Common;
                    limitValue = USING_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_HUGE_GREEN_POTION:
                    description = "超ビッグサイズで、派手な光沢が施されているスキル回復用の薬。回復量３０～４０";
                    PhysicalAttackMinValue = 30;
                    PhysicalAttackMaxValue = 40;
                    cost = 200000;
                    AdditionalDescription(ItemType.Use_Potion);
                    rareLevel = RareLevel.Common;
                    limitValue = USING_ITEM_STACK_SIZE;
                    break;
                case FIX.RARE_POWER_SURGE:
                    description = "生命の源からパワーの根源を引き出す薬。力＋６００、体＋４００、物攻率＋２０％を付与する。【戦闘中専用】";
                    cost = 500000;
                    AdditionalDescription(ItemType.Use_Potion);
                    rareLevel = RareLevel.Rare;
                    limitValue = USING_ITEM_STACK_SIZE;
                    break;
                case FIX.RARE_GENSEI_MAGIC_BOTTLE:
                    description = "精神の源から知恵の源流を引き出す薬。知＋６００、心＋４００、魔攻率＋２０％を付与する。【戦闘中専用】";
                    cost = 500000;
                    AdditionalDescription(ItemType.Use_Potion);
                    rareLevel = RareLevel.Rare;
                    limitValue = USING_ITEM_STACK_SIZE;
                    break;
                case FIX.RARE_MIND_ILLUSION:
                    description = "第六感の源からイメージの増幅を引き出す薬。力＋１００、技＋１００、知＋１００、体＋１００、心＋６００、潜力率＋２０％を付与する。【戦闘中専用】";
                    cost = 500000;
                    AdditionalDescription(ItemType.Use_Potion);
                    rareLevel = RareLevel.Rare;
                    limitValue = USING_ITEM_STACK_SIZE;
                    break;
                case FIX.RARE_ZETTAI_STAMINAUP:
                    description = "魂の源からオーラの存在を引き出す薬。力＋２００、知＋２００、体＋６００、物防率＋１０％、魔防率＋１０％を付与する。【戦闘中専用】";
                    cost = 500000;
                    AdditionalDescription(ItemType.Use_Potion);
                    rareLevel = RareLevel.Rare;
                    limitValue = USING_ITEM_STACK_SIZE;
                    break;
                case FIX.RARE_ZEPHER_BREATH:
                    description = "天性の源から躍動の心を引き出す薬。技＋６００、知＋４００、戦速率＋２０％を付与する。【戦闘中専用】";
                    cost = 500000;
                    AdditionalDescription(ItemType.Use_Potion);
                    rareLevel = RareLevel.Rare;
                    limitValue = USING_ITEM_STACK_SIZE;
                    break;
                case FIX.RARE_ELEMENTAL_SEAL:
                    description = "様々なマテリアルを分析し、耐性創生色素を抽出し、一つのシールに仕立てた薬品。";
                    description += "\r\n対象者の毒、沈黙、スタン、麻痺、凍結、誘惑、鈍化、暗闇、スリップを解除する。【戦闘中専用】";
                    description += "\r\n毒耐性、沈黙耐性、スタン耐性、麻痺耐性、凍結耐性、誘惑耐性、鈍化耐性、暗闇耐性、スリップ耐性【戦闘中専用】";
                    cost = 350000;
                    AdditionalDescription(ItemType.Use_Potion);
                    rareLevel = RareLevel.Rare;
                    limitValue = USING_ITEM_STACK_SIZE;
                    break;
                case FIX.RARE_GENSEI_TAIMA_KUSURI:
                    description = "『源正酒造』と連携し、酒と薬をうまく調合した退魔の秘薬。";
                    description += "\r\n即死を伴うアクションが行われた場合、即死を回避する。この効果は一度だけ適用される。【戦闘中専用】";
                    description += "\r\nライフが０になった場合、ライフを半分にまで回復する。この効果は一度だけ適用される。【戦闘中専用】";
                    cost = 700000;
                    AdditionalDescription(ItemType.Use_Potion);
                    rareLevel = RareLevel.Rare;
                    limitValue = USING_ITEM_STACK_SIZE;
                    break;
                case FIX.RARE_SHINING_AETHER:
                    description = "神々しく光輝くエーテル剤。見ているだけでも、勇気が湧いてくる。";
                    description += "\r\n次のターンまで、【元核】スキルを一度だけ発動可能となる。【戦闘中専用】";
                    description += "\r\n次のターンまで、全ダメージが一切無効となる。【戦闘中専用】";
                    cost = 750000;
                    AdditionalDescription(ItemType.Use_Potion);
                    rareLevel = RareLevel.Rare;
                    limitValue = USING_ITEM_STACK_SIZE;
                    break;
                case FIX.RARE_BLACK_ELIXIR:
                    description = "体内に宿る悪しき力を純粋な力へと変換する薬。";
                    description += "\r\n最大ライフを５０％増加させる。その増加した分だけ、ライフ回復する。【戦闘中専用】";
                    description += "\r\nライフを減少させる効果（ライフ％減少、ライフ半分、ライフ１変換）が来た場合、それを回避する。【戦闘中専用】";
                    cost = 750000;
                    AdditionalDescription(ItemType.Use_Potion);
                    rareLevel = RareLevel.Rare;
                    limitValue = USING_ITEM_STACK_SIZE;
                    break;
                case FIX.RARE_COLORLESS_ANTIDOTE:
                    description = "物理的、または精神的な悪循環を払拭させるために開発された特効薬。";
                    description += "\r\n物理攻撃、物理防御、魔法攻撃、魔法防御、戦闘速度、戦闘反応、潜在能力DOWNを解除する。【戦闘中専用】";
                    description += "\r\n物理攻撃、物理防御、魔法攻撃、魔法防御、戦闘速度、戦闘反応、潜在能力DOWNに対する耐性を得る。【戦闘中専用】";
                    cost = 1000000;
                    AdditionalDescription(ItemType.Use_Potion);
                    rareLevel = RareLevel.Rare;
                    limitValue = USING_ITEM_STACK_SIZE;
                    break;
                #endregion
                #region "ダンジョン５階"
                case FIX.COMMON_GORGEOUS_RED_POTION:
                    description = "超ビッグサイズで、派手な光沢が施されているライフ回復用の薬。回復量５００００～７００００";
                    PhysicalAttackMinValue = 50000;
                    PhysicalAttackMaxValue = 70000;
                    cost = 450000;
                    AdditionalDescription(ItemType.Use_Potion);
                    rareLevel = RareLevel.Common;
                    limitValue = USING_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_GORGEOUS_BLUE_POTION:
                    description = "超ビッグサイズで、派手な光沢が施されているマナ回復用の薬。回復量２２０００～２６０００";
                    PhysicalAttackMinValue = 22000;
                    PhysicalAttackMaxValue = 26000;
                    cost = 450000;
                    AdditionalDescription(ItemType.Use_Potion);
                    rareLevel = RareLevel.Common;
                    limitValue = USING_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_GORGEOUS_GREEN_POTION:
                    description = "超ビッグサイズで、派手な光沢が施されているスキル回復用の薬。回復量４５～６０";
                    PhysicalAttackMinValue = 45;
                    PhysicalAttackMaxValue = 60;
                    cost = 450000;
                    AdditionalDescription(ItemType.Use_Potion);
                    rareLevel = RareLevel.Common;
                    limitValue = USING_ITEM_STACK_SIZE;
                    break;
                #endregion

                #endregion

                #region "後編ダンジョン１階"

                case FIX.POOR_HARD_SHOES:
                    description = "硬皮材質で作られた靴。硬いので歩き辛い・・・。体力＋２、心＋１";
                    BuffUpStamina = 2;
                    BuffUpMind = 1;
                    cost = 280;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Poor;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_SIMPLE_BRACELET:
                    description = "単純に作られたブレスレットだが、気力は沸いて来る。力＋２、心＋３";
                    BuffUpStrength = 2;
                    BuffUpMind = 3;
                    cost = 500;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_SEAL_OF_POSION:
                    description = "毒の研究データが埋め込んであるシール。体力＋２、【猛毒】耐性";
                    BuffUpStamina = 2;
                    ResistPoison = true;
                    cost = 530;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_GREEN_EGG_KAIGARA:
                    description = "緑色の卵からは、豊富な養分が採取される。";
                    cost = 420;
                    AdditionalDescription(ItemType.Material_Food);
                    rareLevel = RareLevel.Common;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_HAYATE_ORB:
                    description = "疾風の息吹が込められている宝珠。戦闘中使用で、一瞬速度が上がる。";
                    cost = 880;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_VIKING_SWORD:
                    description = "標準的な大剣。少し重たいがバランスは良い方。物理攻撃４～２２";
                    PhysicalAttackMinValue = 4;
                    PhysicalAttackMaxValue = 22;
                    cost = 850;
                    AdditionalDescription(ItemType.Weapon_TwoHand);
                    rareLevel = RareLevel.Common;
                    limitValue = USING_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_NEBARIITO_KUMO:
                    description = "土蜘蛛が構築していた蜘蛛の糸のかけら。かなり粘っこい。";
                    cost = 640;
                    AdditionalDescription(ItemType.Material_Potion);
                    rareLevel = RareLevel.Common;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_SUN_PRISM:
                    description = "太陽のエッセンスが注入されてるプリズム。力＋６、体＋６";
                    BuffUpStrength = 6;
                    BuffUpStamina = 6;
                    cost = 1200;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_POISON_EKISU:
                    description = "解毒開発はあらゆ毒の要素を研究することから行われる。";
                    cost = 860;
                    AdditionalDescription(ItemType.Material_Potion);
                    rareLevel = RareLevel.Common;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_SOLID_CLAW:
                    description = "鋭さより当たりやすさを重視した鈍器のような爪。物理攻撃１１～１２";
                    PhysicalAttackMinValue = 11;
                    PhysicalAttackMaxValue = 12;
                    cost = 1100;
                    AdditionalDescription(ItemType.Weapon_Light);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_GREEN_LEEF_CHARM:
                    description = "緑葉の繊維を材質として作られた魔除け。知＋８、心＋４、魔法攻撃２～４";
                    BuffUpIntelligence = 8;
                    BuffUpMind = 4;
                    MagicAttackMinValue = 2;
                    MagicAttackMaxValue = 4;
                    cost = 1400;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_WARRIOR_MEDAL:
                    description = "戦士の像が彫られているメダル。力＋１０、心＋１０";
                    BuffUpStrength = 10;
                    BuffUpMind = 10;
                    cost = 1800;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_PALADIN_MEDAL:
                    description = "パラディンの像が彫られているメダル。力＋１０、知＋１０";
                    BuffUpStrength = 10;
                    BuffUpIntelligence = 10;
                    cost = 1800;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_KASHI_ROD:
                    description = "樫のパワーが宿っている杖。魔法攻撃７～９";
                    MagicAttackMinValue = 7;
                    MagicAttackMaxValue = 9;
                    cost = 550;
                    AdditionalDescription(ItemType.Weapon_Rod);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.RARE_TOTAL_HIYAKU_KASSEI:
                    description = "力・技・知のうち、一番能力の高い部分を活性化させる。一度使うと無くなる。戦闘中専用。";
                    cost = 6000;
                    AdditionalDescription(ItemType.Use_Potion);
                    rareLevel = RareLevel.Rare;
                    limitValue = RARE_EPIC_ITEM_STACK_SIZE;
                    break;
                case FIX.RARE_PURE_WATER:
                    description = "約束された回復薬。毎日１度だけライフを100%回復する。このアイテムは使用しても無くならない。\r\nホームタウン帰還後、再使用可能となる。";
                    PhysicalAttackMinValue = 0;
                    PhysicalAttackMaxValue = 0;
                    cost = 25000;
                    AdditionalDescription(ItemType.Use_Potion);
                    rareLevel = RareLevel.Rare;
                    limitValue = RARE_EPIC_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_DREAM_POWDER:
                    description = "様々な可能性を秘めているパウダー。ただし、調合者の腕次第。";
                    PhysicalAttackMinValue = 0;
                    PhysicalAttackMaxValue = 0;
                    cost = 1500;
                    AdditionalDescription(ItemType.Material_Potion);
                    rareLevel = RareLevel.Common;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_BLUE_COPPER:
                    description = "純度の高い青銅の石。";
                    PhysicalAttackMinValue = 0;
                    PhysicalAttackMaxValue = 0;
                    cost = 1800;
                    AdditionalDescription(ItemType.Material_Equip);
                    rareLevel = RareLevel.Common;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_ORANGE_MATERIAL:
                    description = "オレンジ色のマテリアル。それほど珍しくは無い。";
                    PhysicalAttackMinValue = 0;
                    PhysicalAttackMaxValue = 0;
                    cost = 1560;
                    AdditionalDescription(ItemType.Material_Equip);
                    rareLevel = RareLevel.Common;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                case FIX.RARE_ZEPHER_FETHER:
                    description = "ゼフィールの羽。洗練された速さと正確さを感じ取れる。技＋３０";
                    buffUpAgility = 30;
                    cost = 3800;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Rare;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.RARE_LIFE_SWORD:
                    description = "生命の大樹を一部切り取り、組み込まれた剣。【特殊能力：有】物理攻撃１６～２２";
                    useSpecialAbility = true;
                    PhysicalAttackMinValue = 16;
                    PhysicalAttackMaxValue = 22;
                    cost = 1850;
                    AdditionalDescription(ItemType.Weapon_Heavy);
                    rareLevel = RareLevel.Rare;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.RARE_PURE_GREEN_SILK_ROBE:
                    description = "純度の高いシルク素材に緑色素を注入してある。物理防御７～１０。魔法防御力２０～３０";
                    PhysicalDefenseMinValue = 7;
                    PhysicalDefenseMaxValue = 10;
                    MagicDefenseMinValue = 20;
                    MagicDefenseMaxValue = 30;
                    cost = 2500;
                    AdditionalDescription(ItemType.Armor_Light);
                    rareLevel = RareLevel.Rare;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                // ガンツ初版武具：１階
                case FIX.COMMON_BRONZE_SWORD:
                    description = "銅製の剣。特に威力に期待は出来ないが、ひとまず使える武器である。物理攻撃４～６";
                    PhysicalAttackMinValue = 4;
                    PhysicalAttackMaxValue = 6;
                    cost = 300;
                    AdditionalDescription(ItemType.Weapon_Heavy);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_LIGHT_SHIELD:
                    description = "誰でも持てるほどの軽い盾。盾として最低限の能力しか持ちあわせてない。物理防御２～３";
                    PhysicalDefenseMinValue = 2;
                    PhysicalDefenseMaxValue = 3;
                    cost = 350;
                    AdditionalDescription(ItemType.Shield);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_FINE_SWORD_1:
                    description = "そつなく使える剣をガンツが強化した。物理攻撃５(+3)～８(+3)";
                    PhysicalAttackMinValue = 8;
                    PhysicalAttackMaxValue = 11;
                    cost = 900;
                    AdditionalDescription(ItemType.Weapon_Heavy);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_FINE_ARMOR_1:
                    description = "そつなく使える鎧をガンツが強化した。物理防御３(+2)～６(+2)";
                    PhysicalDefenseMinValue = 5;
                    PhysicalDefenseMaxValue = 8;
                    cost = 900;
                    AdditionalDescription(ItemType.Armor_Heavy);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_FINE_SHIELD_1:
                    description = "そつなく使える盾をガンツが強化した。物理防御３(+1)～４(+2)";
                    PhysicalDefenseMinValue = 4;
                    PhysicalDefenseMaxValue = 5;
                    cost = 750;
                    AdditionalDescription(ItemType.Shield);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_LIGHT_CLAW_1:
                    description = "普通の研ぎ方で作成された爪をガンツが強化した。物理攻撃５(+3)～７(+3)";
                    PhysicalAttackMinValue = 8;
                    PhysicalAttackMaxValue = 10;
                    cost = 950;
                    AdditionalDescription(ItemType.Weapon_Light);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_KASHI_ROD_1:
                    description = "樫のパワーが宿っている杖。魔法攻撃７(+3)～９(+3)";
                    MagicAttackMinValue = 10;
                    MagicAttackMaxValue = 12;
                    cost = 1000;
                    AdditionalDescription(ItemType.Weapon_Rod);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_LETHER_CLOTHING_1:
                    description = "標準的なサイズで作成されたレザー製の衣をガンツが強化した。物理防御４(+2)～７(+2)";
                    PhysicalDefenseMinValue = 6;
                    PhysicalDefenseMaxValue = 9;
                    cost = 980;
                    AdditionalDescription(ItemType.Armor_Middle);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_BASTARD_SWORD_1:
                    description = "両手剣専用。ある程度の力が必要だが、ガンツがさらにその威力を強化した。物理攻撃７(+3)～４０(+5)";
                    PhysicalAttackMinValue = 10;
                    PhysicalAttackMaxValue = 45;
                    cost = 1350;
                    AdditionalDescription(ItemType.Weapon_TwoHand);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_IRON_SWORD:
                    description = "鉄製の剣。ガンツ渾身の技で強化改良済み。物理攻撃２０(+6）～３０(+6)";
                    PhysicalAttackMinValue = 26;
                    PhysicalAttackMaxValue = 36;
                    cost = 2300;
                    AdditionalDescription(ItemType.Weapon_Heavy);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_FIT_ARMOR:
                    description = "初級者の体質に合うように作られた鎧。動きやすいが、それほど防御力に期待はできない。物理防御２～５";
                    PhysicalDefenseMinValue = 2;
                    PhysicalDefenseMaxValue = 5;
                    cost = 450;
                    AdditionalDescription(ItemType.Armor_Heavy);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_KUSARI_KATABIRA:
                    description = "鎖を編み合わせて作成された鎧。ガンツ直伝の技で強化改良済み。物理防御１４(+3)～１８(+3)";
                    PhysicalDefenseMinValue = 17;
                    PhysicalDefenseMaxValue = 21;
                    cost = 2600;
                    AdditionalDescription(ItemType.Armor_Heavy);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.RARE_FLOWER_WAND:
                    description = "花型の取っ手が付いているワンド。ガンツがラナのイメージに合わせたとの事。魔法攻撃２０～２４";
                    description += "\r\n【特殊能力】　MPを回復する。";
                    UseSpecialAbility = true;
                    MagicAttackMinValue = 20;
                    MagicAttackMaxValue = 24;
                    cost = 3000;
                    AdditionalDescription(ItemType.Weapon_Rod);
                    rareLevel = RareLevel.Rare;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_SURVIVAL_CLAW:
                    description = "気性の荒い人（？）でも長く使えるように改良が施されている爪。物理攻撃１６～１９";
                    PhysicalAttackMinValue = 16;
                    PhysicalAttackMaxValue = 19;
                    cost = 1600;
                    AdditionalDescription(ItemType.Weapon_Light);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_SUPERIOR_CROSS:
                    description = "レザー製の衣の中でも上質な素材を選定して、作られた舞踏衣。物理防御８～１０";
                    PhysicalDefenseMinValue = 8;
                    PhysicalDefenseMaxValue = 10;
                    cost = 1200;
                    AdditionalDescription(ItemType.Armor_Middle);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_SILK_ROBE:
                    description = "普通のシルク素材をもちいた魔法のローブ。物理防御４～８。魔法防御力１０～１５";
                    PhysicalDefenseMinValue = 4;
                    PhysicalDefenseMaxValue = 8;
                    MagicDefenseMinValue = 10;
                    MagicDefenseMaxValue = 15;
                    cost = 1300;
                    AdditionalDescription(ItemType.Armor_Light);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_BLACER_OF_SYOJIN:
                    description = "アインへの精進の念を込めて作成されたブレスレット。力＋１０、体＋２０、心＋１０";
                    buffUpStrength = 10;
                    buffUpAgility = 20;
                    buffUpMind = 10;
                    cost = 4000;
                    AdditionalDescription(ItemType.Accessory);
                    equipablePerson = Equipable.Ein;
                    rareLevel = RareLevel.Rare;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_ZIAI_PENDANT:
                    description = "ラナへの慈愛の念を込めて作成されたペンダント。知＋１０、体＋１０、心＋２０";
                    buffUpIntelligence = 10;
                    buffUpStamina = 10;
                    buffUpMind = 20;
                    cost = 4000;
                    AdditionalDescription(ItemType.Accessory);
                    equipablePerson = Equipable.Lana;
                    rareLevel = RareLevel.Rare;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                // 防具(Common1)
                case FIX.COMMON_SMART_CLOTHING:
                    description = "着心地も良く、動きやすさも抜群の舞踏衣。物理防御２５～２８。";
                    PhysicalDefenseMinValue = 25;
                    PhysicalDefenseMaxValue = 28;
                    cost = 4600;
                    AdditionalDescription(ItemType.Armor_Middle);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_SMART_ROBE:
                    description = "スラリとしたデザインを追求した戦闘向けローブ。物理防御１０～１２。魔法防御２０～２２";
                    PhysicalDefenseMinValue = 10;
                    PhysicalDefenseMaxValue = 12;
                    MagicDefenseMinValue = 20;
                    MagicDefenseMaxValue = 22;
                    cost = 5500;
                    AdditionalDescription(ItemType.Armor_Light);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_SMART_PLATE:
                    description = "ガッチリした鎧にも関わらず、煩わしさが無い。物理防御３０～３５";
                    PhysicalDefenseMinValue = 30;
                    PhysicalDefenseMaxValue = 35;
                    cost = 5200;
                    AdditionalDescription(ItemType.Armor_Heavy);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                // 防具（Rare1）
                case FIX.RARE_DIRGE_ROBE:
                    description = "重々しさを背負うが、確かな魔法耐性を感じられる。物理防御２０～２０、魔法防御４０～４０、聖耐性１００、闇耐性１００";
                    PhysicalDefenseMinValue = 20;
                    PhysicalDefenseMaxValue = 20;
                    MagicDefenseMinValue = 40;
                    MagicDefenseMaxValue = 40;
                    ResistLight = 100;
                    ResistShadow = 100;
                    cost = 12000;
                    AdditionalDescription(ItemType.Armor_Light);
                    rareLevel = RareLevel.Rare;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.RARE_DUNSID_PLATE:
                    description = "巷で大人気だったアゼル・ダンシッドが装着していた鎧。物理防御５１～５８、火耐性１００、水耐性１００";
                    PhysicalDefenseMinValue = 51;
                    PhysicalDefenseMaxValue = 58;
                    ResistFire = 100;
                    ResistIce = 100;
                    cost = 12000;
                    AdditionalDescription(ItemType.Armor_Heavy);
                    rareLevel = RareLevel.Rare;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                // 防具（Common2）
                case FIX.COMMON_SERPENT_ARMOR:
                    description = "サーペント族がよく愛用している鎧。物理防御４２～４９";
                    PhysicalDefenseMinValue = 42;
                    PhysicalDefenseMaxValue = 49;
                    cost = 7000;
                    AdditionalDescription(ItemType.Armor_Heavy);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_SWIFT_CROSS:
                    description = "非常に瞬発力を出しやすい舞踏衣。物理防御３８～４２";
                    PhysicalDefenseMinValue = 38;
                    PhysicalDefenseMaxValue = 32;
                    cost = 6500;
                    AdditionalDescription(ItemType.Armor_Middle);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_CHIFFON_ROBE:
                    description = "フワフワとした感触で魔法耐性を持たせてある衣。物理防御１５～１８、魔法防御２５～３０";
                    PhysicalDefenseMinValue = 15;
                    PhysicalDefenseMaxValue = 18;
                    MagicDefenseMinValue = 25;
                    MagicDefenseMaxValue = 30;
                    cost = 7000;
                    AdditionalDescription(ItemType.Armor_Light);
                    rareLevel = RareLevel.Common;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                // 防具（Rare2）
                case FIX.RARE_SHARKSKIN_ARMOR:
                    description = "鮫の鱗が新しく形状化し、鎧形状となった。物理防御６６～７５、聖耐性２５０、火耐性２５０";
                    PhysicalDefenseMinValue = 66;
                    PhysicalDefenseMaxValue = 75;
                    ResistLight = 250;
                    ResistFire = 250;
                    cost = 13000;
                    AdditionalDescription(ItemType.Armor_Heavy);
                    rareLevel = RareLevel.Rare;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.RARE_BLACK_MAGICIAN_CROSS:
                    description = "魔法の使い手前衛で戦う事を前提として生み出された武闘衣。物理防御５２～５８、魔法防御５２～５８、闇耐性２５０、火耐性２５０";
                    PhysicalDefenseMinValue = 52;
                    PhysicalDefenseMaxValue = 58;
                    MagicDefenseMinValue = 52;
                    MagicDefenseMaxValue = 58;
                    ResistShadow = 250;
                    ResistFire = 250;
                    cost = 12000;
                    AdditionalDescription(ItemType.Armor_Middle);
                    rareLevel = RareLevel.Rare;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.RARE_RED_THUNDER_ROBE:
                    description = "赤い雷の文様が描かれているローブ。物理防御２５～３０、魔法防御６０～７５、聖耐性２５０、火耐性２５０";
                    PhysicalDefenseMinValue = 46;
                    PhysicalDefenseMaxValue = 51;
                    ResistShadow = 250;
                    ResistFire = 250;
                    cost = 13500;
                    AdditionalDescription(ItemType.Armor_Light);
                    rareLevel = RareLevel.Rare;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                // 防具（ガンツ合成）2階
                case FIX.COMMON_BERSERKER_PLATE:
                    description = "狂戦士バーサーカーの気質が伝わってくる鎧。物理防御７１～８２、魔法防御６０～７５、聖耐性２５０、火耐性２５０";
                    PhysicalDefenseMinValue = 71;
                    PhysicalDefenseMaxValue = 82;
                    cost = 14500;
                    AdditionalDescription(ItemType.Armor_Heavy);
                    rareLevel = RareLevel.Rare;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_BRIGHTNESS_ROBE:
                    description = "光の輝きを宿らせた洗練されたローブ。物理防御３６～４２、魔法防御８０～９０";
                    PhysicalDefenseMinValue = 36;
                    PhysicalDefenseMaxValue = 42;
                    MagicDefenseMinValue = 80;
                    MagicDefenseMaxValue = 90;
                    cost = 15000;
                    AdditionalDescription(ItemType.Armor_Light);
                    rareLevel = RareLevel.Rare;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                // 盾（Common1)
                case FIX.COMMON_SMART_SHIELD:
                    description = "持ちやすく、向きもスッと変えられる盾。物理防御１２～１５";
                    PhysicalDefenseMinValue = 12;
                    PhysicalDefenseMaxValue = 15;
                    cost = 3500;
                    AdditionalDescription(ItemType.Shield);
                    rareLevel = RareLevel.Common;
                    break;
                // 盾（Common2)
                case FIX.COMMON_PURE_BRONZE_SHIELD:
                    description = "純度のある青銅で生み出された盾。物理防御１８～２４";
                    PhysicalDefenseMinValue = 18;
                    PhysicalDefenseMaxValue = 24;
                    cost = 4800;
                    AdditionalDescription(ItemType.Shield);
                    rareLevel = RareLevel.Common;
                    break;
                // 盾（Rare1)
                case FIX.RARE_BLUE_SKY_SHIELD:
                    description = "青く広大な海が描かれている盾。物理防御２５～３３、聖耐性３００、水耐性３００";
                    PhysicalDefenseMinValue = 25;
                    PhysicalDefenseMaxValue = 33;
                    ResistLight = 300;
                    ResistIce = 300;
                    cost = 9500;
                    AdditionalDescription(ItemType.Shield);
                    rareLevel = RareLevel.Rare;
                    break;
                // 盾（ガンツ合成）２階
                case FIX.RARE_STRONG_SERPENT_SHIELD: // 半透明の石灰、青鮫の鱗
                    description = "強固な青鮫の鱗を更に高質化させ、低温度化で固めた盾。物理防御３８～４０";
                    PhysicalDefenseMinValue = 38;
                    PhysicalDefenseMaxValue = 40;
                    cost = 11000;
                    AdditionalDescription(ItemType.Shield);
                    rareLevel = RareLevel.Rare;
                    break;
                #endregion
                #region "その他、未使用、なにもなし、etc..."
                case "": // 装備無し
                    description = "";
                    PhysicalAttackMinValue = 0;
                    PhysicalAttackMaxValue = 0;
                    buffUpStrength = 0;
                    buffUpAgility = 0;
                    buffUpIntelligence = 0;
                    buffUpStamina = 0;
                    buffUpMind = 0;
                    amplifyPhysicalAttack = 0.0f;
                    amplifyPhysicalDefense = 0.0f;
                    amplifyMagicAttack = 0.0f;
                    amplifyMagicDefense = 0.0f;
                    amplifyBattleSpeed = 0.0f;
                    amplifyBattleResponse = 0.0f;
                    amplifyPotential = 0.0f;
                    ResistFire = 0;
                    ResistIce = 0;
                    ResistLight = 0;
                    ResistShadow = 0;
                    ResistForce = 0;
                    ResistWill = 0;
                    cost = 0;
                    //AdditionalDescription(ItemType.Useless);
                    rareLevel = RareLevel.Poor;
                    limitValue = OTHER_ITEM_STACK_SIZE;
                    break;

                case "アカシジアの実":
                    description = "恐ろしく不味いが、食べれば気付け効果がある。戦闘中専用。「解毒」「スタン」を解除";
                    PhysicalAttackMinValue = 100;
                    PhysicalAttackMaxValue = 100;
                    cost = 150;
                    AdditionalDescription(ItemType.Use_Potion);
                    rareLevel = RareLevel.Common;
                    limitValue = USING_ITEM_STACK_SIZE;
                    break;

                #endregion
                #region "固定ドロップアイテム"
                #region "１階"
                case FIX.POOR_BLACK_MATERIAL: // ドロップアイテム（１階任意）
                    description = "純黒色の立方体。使用済みマテリアルのため、使い道はない。";
                    cost = 20;
                    AdditionalDescription(ItemType.Useless);
                    rareLevel = RareLevel.Poor;
                    limitValue = OTHER_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_BEATLE_TOGATTA_TUNO: // ドロップアイテム（ひ弱なビートル）
                    description = "死骸となったビートルの角。";
                    cost = 62;
                    AdditionalDescription(ItemType.Material_Equip);
                    rareLevel = RareLevel.Common;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_HENSYOKU_KUKI: // ドロップアイテム（変色したプラント）
                    description = "変色した茎にはほんのりと熱がこもっている。";
                    cost = 70;
                    AdditionalDescription(ItemType.Material_Potion);
                    rareLevel = RareLevel.Common;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_GREEN_SIKISO: // ドロップアイテム（グリーン・チャイルド）
                    description = "樹木の表面にほんのり残っていた緑色素。";
                    cost = 78;
                    AdditionalDescription(ItemType.Material_Potion);
                    rareLevel = RareLevel.Common;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_MANTIS_TAIEKI: // ドロップアイテム（タイニー・マンティス）
                    description = "マンティスの体液は皮膚に塗ると薬用として効果があると言われている。";
                    cost = 87;
                    AdditionalDescription(ItemType.Material_Potion);
                    rareLevel = RareLevel.Common;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_WARM_NO_KOUKAKU: // ドロップアイテム（甲殻ワーム）
                    description = "死骸となったワームの甲殻の欠片。";
                    cost = 94;
                    AdditionalDescription(ItemType.Material_Equip);
                    rareLevel = RareLevel.Common;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_MANDORAGORA_ROOT: // ドロップアイテム（マンドラゴラ）
                    description = "マンドラゴラ死に際の根には、魔力が宿る言われている。";
                    cost = 250;
                    AdditionalDescription(ItemType.Material_Potion);
                    rareLevel = RareLevel.Common;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_SUN_LEAF: // ドロップアイテム（サン・フラワー）
                    description = "【武具素材】太陽の恩恵を受けずに人工的な光で育った葉。";
                    cost = 100;
                    AdditionalDescription(ItemType.Material_Equip);
                    rareLevel = RareLevel.Common;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_INAGO: // ドロップアイテム（レッドホッパー）
                    description = "奇妙な形をした死骸。佃煮にすると上手いが少し度胸が必要。";
                    cost = 110;
                    AdditionalDescription(ItemType.Material_Food);
                    rareLevel = RareLevel.Common;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_SPIDER_SILK: // ドロップアイテム（アースパイダー）
                    description = "蜘蛛が攻撃の際に撒き散らした良質な形状の糸。";
                    cost = 120;
                    AdditionalDescription(ItemType.Material_Equip);
                    rareLevel = RareLevel.Common;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_ANT_ESSENCE: // ドロップアイテム（ワイルドアント）
                    description = "アリの死骸から採取されたエッセンス。";
                    cost = 140;
                    AdditionalDescription(ItemType.Material_Potion);
                    rareLevel = RareLevel.Common;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_YELLOW_MATERIAL: // ドロップアイテム（ワイルドアント）
                    description = "純黄色の立方体。";
                    cost = 160;
                    AdditionalDescription(ItemType.Material_Equip);
                    rareLevel = RareLevel.Common;
                    limitValue = OTHER_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_ALRAUNE_KAHUN: // ドロップアイテム（アルラウネ）
                    description = "アルラウネから採取される花粉は媚薬の元となる。";
                    cost = 300;
                    AdditionalDescription(ItemType.Material_Potion);
                    rareLevel = RareLevel.Common;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                case FIX.RARE_MARY_KISS: // ドロップアイテム（ポイズン・マリー）
                    description = "最後に投げられた胞子。キスマークの形をしてる。";
                    cost = 1060;
                    AdditionalDescription(ItemType.Material_Potion);
                    rareLevel = RareLevel.Rare;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_RABBIT_KEGAWA: // ドロップアイテム（雑食ウサギ）
                    description = "柔軟性のあるウサギの毛皮。";
                    cost = 150;
                    AdditionalDescription(ItemType.Material_Equip);
                    rareLevel = RareLevel.Common;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_RABBIT_MEAT: // ドロップアイテム（雑食ウサギ）
                    description = "雑食で育ったウサギの肉。煮てから焼いて食べると美味しい。";
                    cost = 160;
                    AdditionalDescription(ItemType.Material_Food);
                    rareLevel = RareLevel.Common;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_TAKA_FETHER: // ドロップアイテム（俊敏な鷹）
                    description = "鷹の羽には、鷹の素早さの精神が宿るといわれている。";
                    cost = 172;
                    AdditionalDescription(ItemType.Material_Equip);
                    rareLevel = RareLevel.Common;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_ASH_EGG: // ドロップアイテム（アッシュ・クリーパー）
                    description = "灰色ではあるが、れっきとした卵。不気味だが美味と言われている。";
                    cost = 186;
                    AdditionalDescription(ItemType.Material_Food);
                    rareLevel = RareLevel.Common;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_SNEAK_UROKO: // ドロップアイテム（ジャイアント・スネーク）
                    description = "蛇の鱗。ツヤはあるが何となく触るのに勇気がいる・・・。";
                    cost = 300;
                    AdditionalDescription(ItemType.Material_Equip);
                    rareLevel = RareLevel.Common;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_PLANTNOID_SEED: // ドロップアイテム（ワンダーシード）
                    description = "体当たり時に紛れ落ちていたプラントノイド種。";
                    cost = 350;
                    AdditionalDescription(ItemType.Material_Food);
                    rareLevel = RareLevel.Common;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_TOGE_HAETA_SYOKUSYU: // ドロップアイテム（フランシスナイト）
                    description = "攻撃用の触手として異常発達した触手。";
                    cost = 370;
                    AdditionalDescription(ItemType.Material_Equip);
                    rareLevel = RareLevel.Common;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_BRILLIANT_RINPUN: // ドロップアイテム（ブリリアント・バタフライ）
                    description = "バタフライ死の直後、一際輝いた部分の燐粉を採取。";
                    cost = 222;
                    AdditionalDescription(ItemType.Material_Potion);
                    rareLevel = RareLevel.Common;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_MIST_CRYSTAL: // ドロップアイテム（ミスト・エレメンタル）
                    description = "霧の形状が結晶化したもの。デリケートに扱わないとすぐ砕けてしまう。";
                    cost = 420;
                    AdditionalDescription(ItemType.Material_Equip);
                    rareLevel = RareLevel.Common;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_DRYAD_RINPUN: // ドロップアイテム（ウィスパー・ドライアド）
                    description = "ドライアドが死に際に散布した鱗粉。ほのかに良い香りがする。";
                    cost = 450;
                    AdditionalDescription(ItemType.Material_Potion);
                    rareLevel = RareLevel.Common;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_RED_HOUSI: // ドロップアイテム（ブラッドモス）
                    description = "胞子攻撃の際に噴出された胞子。";
                    cost = 480;
                    AdditionalDescription(ItemType.Material_Potion);
                    rareLevel = RareLevel.Common;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                case FIX.RARE_MOSSGREEN_EKISU: // ドロップアイテム（モスグリーン・ダディ）
                    description = "この特有エキスは特殊な耐性を与えると言われている。";
                    cost = 1310;
                    AdditionalDescription(ItemType.Material_Potion);
                    rareLevel = RareLevel.Rare;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;

                case FIX.EPIC_ORB_GROW_GREEN: // ドロップアイテム（一階の守護者：絡みつくフランシス）
                    description = "新緑の息吹が封じられた宝珠。最大スキル＋２０、移動時スキル回復、戦闘時スキル回復＋３。";
                    effectValue1 = 20;
                    cost = 0;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Epic;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;

                #endregion
                #region "２階"
                case FIX.POOR_BLACK_MATERIAL2: // ドロップアイテム（２階任意）
                    description = "純黒色の立方体。若干の改良が試みた後があるが、使い道はない。";
                    cost = 900;
                    AdditionalDescription(ItemType.Useless);
                    rareLevel = RareLevel.Poor;
                    limitValue = OTHER_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_DAGGERFISH_UROKO: // ドロップアイテム（ダガーフィッシュ）
                    description = "牙魚の鱗は、薄いが歯ごたえのある硬さがウリの一つ。";
                    cost = 242;
                    AdditionalDescription(ItemType.Material_Food);
                    rareLevel = RareLevel.Common;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_SIPPUU_HIRE: // ドロップアイテム（疾風・フライングフィッシュ）
                    description = "疾魚のヒレは、柔らかさと香ばしさがウリの一つ。";
                    cost = 254;
                    AdditionalDescription(ItemType.Material_Food);
                    rareLevel = RareLevel.Common;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_WHITE_MAGATAMA: // ドロップアイテム（オーブ・シェルフィッシュ）
                    description = "その白さは、質素ではあるが、品格のある形をしている。";
                    cost = 264;
                    AdditionalDescription(ItemType.Material_Equip);
                    rareLevel = RareLevel.Common;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_BLUE_MAGATAMA: // ドロップアイテム（オーブ・シェルフィッシュ）
                    description = "その青さは、目立たないが、高貴な雰囲気を出している。";
                    cost = 264;
                    AdditionalDescription(ItemType.Material_Equip);
                    rareLevel = RareLevel.Common;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_KURIONE_ZOUMOTU: // ドロップアイテム（スプラッシュ・クリオネ）
                    description = "臓物の中でも特に鮮度の高い部分を切り出してある。";
                    cost = 512;
                    AdditionalDescription(ItemType.Material_Food);
                    rareLevel = RareLevel.Common;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_BLUEWHITE_SHARP_TOGE: // ドロップアイテム（スプラッシュ・クリオネ）
                    description = "戦闘中にクリオネが飛ばしてきた、鋭い青白の針。";
                    cost = 520;
                    AdditionalDescription(ItemType.Material_Equip);
                    rareLevel = RareLevel.Common;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                case FIX.RARE_TRANSPARENT_POWDER: // ドロップアイテム（透明なウミウシ）
                    description = "透明のため目視は難しいが、よく目を凝らすと見えなくもない粉末。";
                    cost = 1450;
                    AdditionalDescription(ItemType.Material_Potion);
                    rareLevel = RareLevel.Rare;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_RENEW_AKAMI: // ドロップアイテム（ローリング・マグロ）
                    description = "活きの良いマグロの赤身。アンシェットの町では売れ筋No.1　";
                    cost = 334;
                    AdditionalDescription(ItemType.Material_Food);
                    rareLevel = RareLevel.Common;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_SEA_WASI_KUTIBASI: // ドロップアイテム（青海鷲）
                    description = "異常成長した海鷲のくちばし、高温で焼くと香ばしい味がする。";
                    cost = 366;
                    AdditionalDescription(ItemType.Material_Food);
                    rareLevel = RareLevel.Common;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_WASI_BLUE_FEATHER: // ドロップアイテム（青海鷲）
                    description = "異常成長した海鷲の青い羽。幸運を呼ぶと言われている。";
                    cost = 370;
                    AdditionalDescription(ItemType.Material_Equip);
                    rareLevel = RareLevel.Common;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_BRIGHT_GESO: // ドロップアイテム（ブライト・スクイッド）
                    description = "単なるゲソだが、異常に眩しく光っている・・・。";
                    cost = 430;
                    AdditionalDescription(ItemType.Material_Food);
                    rareLevel = RareLevel.Common;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_GANGAME_EGG: // ドロップアイテム（頑亀）
                    description = "異常な大きさの卵。生のままでは食べられない。";
                    cost = 724;
                    AdditionalDescription(ItemType.Material_Potion);
                    rareLevel = RareLevel.Common;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                case FIX.RARE_JOE_TONGUE: // ドロップアイテム（ビッグマウス・ジョー）
                    description = "長い。硬い。ゴツい。料理の腕が問われる。";
                    cost = 2628;
                    AdditionalDescription(ItemType.Material_Food);
                    rareLevel = RareLevel.Rare;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                case FIX.RARE_JOE_ARM: // ドロップアイテム（ビッグマウス・ジョー）
                    description = "蛙とは思えないぐらいの大きい腕。骨格部は武具素材として使えそう。";
                    cost = 2722;
                    AdditionalDescription(ItemType.Material_Equip);
                    rareLevel = RareLevel.Rare;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                case FIX.RARE_JOE_LEG: // ドロップアイテム（ビッグマウス・ジョー）
                    description = "初めて見る者は、これが蛙の足だとは思わず、美味しそうに食べる。";
                    cost = 2812;
                    AdditionalDescription(ItemType.Material_Food);
                    rareLevel = RareLevel.Rare;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_SOFT_BIG_HIRE: // ドロップアイテム（モーグル・マンタ）
                    description = "極薄のヒレ。コリコリした感触で、歯ごたえ十分。";
                    cost = 522;
                    AdditionalDescription(ItemType.Material_Food);
                    rareLevel = RareLevel.Common;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_PURE_WHITE_BIGEYE: // ドロップアイテム（浮遊するゴールドフィッシュ）
                    description = "純白の目玉のため、逆に食事の際は恐ろしい印象を受ける。";
                    cost = 588;
                    AdditionalDescription(ItemType.Material_Food);
                    rareLevel = RareLevel.Common;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_SAME_NANKOTSU: // ドロップアイテム（暴れ大ザメ）
                    description = "サメの軟骨には意外と知られていない効用のある成分が含まれている。";
                    cost = 600;
                    AdditionalDescription(ItemType.Material_Potion);
                    rareLevel = RareLevel.Common;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_HALF_TRANSPARENT_ROCK_ASH: // ドロップアイテム（バニッシング・コーラル）
                    description = "石灰は本来特定の色が付いてるが、これは不透明であり純度が低い。";
                    cost = 622;
                    AdditionalDescription(ItemType.Material_Equip);
                    rareLevel = RareLevel.Common;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_GOTUGOTU_KARA: // ドロップアイテム（護衛隊・ハーミットクラブ）
                    description = "ちょっとやそっとのパンチ・キックでは壊れない殻。";
                    cost = 1250;
                    AdditionalDescription(ItemType.Material_Equip);
                    rareLevel = RareLevel.Common;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                case FIX.RARE_SEKIKASSYOKU_HASAMI: // ドロップアイテム（キャシー・ザ・キャンサー）
                    description = "キャシーのハサミは、通常のハサミと比べて形状が異常発達している。";
                    cost = 4200;
                    AdditionalDescription(ItemType.Material_Equip);
                    rareLevel = RareLevel.Rare;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_KOUSITUKA_MATERIAL: // ドロップアイテム（ブラック・スターフィッシュ）
                    description = "ブラック・スターフィッシュは死亡後、硬質化し物質成分が変化する。";
                    cost = 820;
                    AdditionalDescription(ItemType.Material_Equip);
                    rareLevel = RareLevel.Common;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_NANAIRO_SYOKUSYU: // ドロップアイテム（レインボー・アネモネ）
                    description = "カラフルな触手のため、数多くの魚がこの罠に引っかかると言われている。";
                    cost = 890;
                    AdditionalDescription(ItemType.Material_Potion);
                    rareLevel = RareLevel.Common;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_PUREWHITE_KIMO: // ドロップアイテム（待ち伏せアンコウ）
                    description = "白色の肝には、身体の健康を促進させる効果があると言われている。";
                    cost = 970;
                    AdditionalDescription(ItemType.Material_Potion);
                    rareLevel = RareLevel.Common;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_AOSAME_KENSHI: // ドロップアイテム（エッジド・ハイ・シャーク）
                    description = "強度が高く、形状も綺麗な剣歯。";
                    cost = 1700;
                    AdditionalDescription(ItemType.Material_Equip);
                    rareLevel = RareLevel.Common;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_AOSAME_UROKO: // ドロップアイテム（エッジド・ハイ・シャーク）
                    description = "普通に触ると柔らかいが、対衝撃性に優れている。";
                    cost = 1800;
                    AdditionalDescription(ItemType.Material_Equip);
                    rareLevel = RareLevel.Common;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_EIGHTEIGHT_KUROSUMI: // ドロップアイテム（エイト・エイト）
                    description = "純黒色の墨。少し粘りっけがある。";
                    cost = 5100;
                    AdditionalDescription(ItemType.Material_Potion);
                    rareLevel = RareLevel.Rare;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_EIGHTEIGHT_KYUUBAN: // ドロップアイテム（エイト・エイト）
                    description = "様々な形状をした吸盤。細かく刻んで焼くと大変美味しい。";
                    cost = 5200;
                    AdditionalDescription(ItemType.Material_Food);
                    rareLevel = RareLevel.Rare;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;

                case FIX.EPIC_ORB_GROUNDSEA_STAR: // ドロップアイテム（二階の守護者：大海蛇リヴィアサン）
                    description = "リヴィアサン撃破の際、落とされた宝珠。稀にスペル詠唱が２回発生する。魔防率＋１０％、光耐性2500、水耐性2500、沈黙耐性、凍結耐性";
                    cost = 0;
                    amplifyMagicDefense = 1.1f;
                    ResistLight = 2500;
                    ResistIce = 2500;
                    ResistSilence = true;
                    ResistFrozen = true;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Epic;
                    limitValue = EQUIP_ITEM_STACK_SIZE;
                    break;
                #endregion
                #region "３階"
                case FIX.POOR_BLACK_MATERIAL3: // ドロップアイテム（３階任意）
                    description = "純黒色の立方体。マテリアル圧縮を試みたが、残骸のままである。";
                    cost = 9500;
                    AdditionalDescription(ItemType.Useless);
                    rareLevel = RareLevel.Poor;
                    limitValue = OTHER_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_ORC_MOMONIKU: // ドロップアイテム（突進オーク）
                    description = "こんがり焼き上げたもも肉、定評のある味わい。";
                    cost = 10500;
                    AdditionalDescription(ItemType.Material_Food);
                    rareLevel = RareLevel.Common;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_SNOW_CAT_KEGAWA: // ドロップアイテム（スノーキャット）
                    description = "上質な雪猫の毛皮。高く売れるが実用性は武具職人に腕次第。";
                    cost = 11200;
                    AdditionalDescription(ItemType.Material_Equip);
                    rareLevel = RareLevel.Common;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_BIG_HIZUME: // ドロップアイテム（ウォー・マンモス）
                    description = "マンモスの足跡を見て、その蹄を食料と考える人は数少ない。";
                    cost = 12600;
                    AdditionalDescription(ItemType.Material_Food);
                    rareLevel = RareLevel.Common;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_FAIRY_POWDER: // ドロップアイテム（ウィングド・コールドフェアリー）
                    description = "妖精から採取されるパウダーは、知力活性の源となる。";
                    cost = 28000;
                    AdditionalDescription(ItemType.Material_Potion);
                    rareLevel = RareLevel.Common;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                case FIX.RARE_GRIFFIN_WHITE_FEATHER: // ドロップアイテム（フリージング・グリフィン）
                    description = "グリフィンの羽は寒い環境下にも耐えるため、強度の高い素材として用いられる。";
                    cost = 50000;
                    AdditionalDescription(ItemType.Material_Equip);
                    rareLevel = RareLevel.Rare;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_GOTUGOTU_KONBOU: // ドロップアイテム（ブルータル・オーガ）
                    description = "でかすぎてこのままでは使い物にならない、素材自体は丈夫な物。";
                    cost = 14100;
                    AdditionalDescription(ItemType.Material_Equip);
                    rareLevel = RareLevel.Common;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_LIZARD_UROKO: // ドロップアイテム（ハイドロー・リザード）
                    description = "青黒の自然色で形成される鱗は、迷彩にも使われる場合がある。";
                    cost = 15400;
                    AdditionalDescription(ItemType.Material_Equip);
                    rareLevel = RareLevel.Common;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_EMBLEM_OF_PENGUIN: // ドロップアイテム（ペンギンスター）
                    description = "ペンギン最強説を謡う者が各地のペンギンに配布してるらしい。";
                    cost = 16600;
                    AdditionalDescription(ItemType.Material_Equip);
                    rareLevel = RareLevel.Common;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_KINKIN_ICE: // ドロップアイテム（アイスバーグ・スピリット）
                    description = "あまりにも冷たすぎるため、素手では触れない氷。そう簡単には溶けないようだ。";
                    cost = 18000;
                    AdditionalDescription(ItemType.Material_Equip);
                    rareLevel = RareLevel.Common;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_SHARPNESS_TIGER_TOOTH: // ドロップアイテム（剣歯虎）
                    description = "剣歯虎の牙からは強靭性エキスが摘出可能である。";
                    cost = 36000;
                    AdditionalDescription(ItemType.Material_Potion);
                    rareLevel = RareLevel.Common;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                case FIX.RARE_BEAR_CLAW_KAKERA: // ドロップアイテム（フェロシアス・レイジベア）
                    description = "憤怒しきったベアが研ぎ澄ました爪。切っ先は赤い血で染まっている。";
                    cost = 110000;
                    AdditionalDescription(ItemType.Material_Equip);
                    rareLevel = RareLevel.Rare;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_TOUMEI_SNOW_CRYSTAL: // ドロップアイテム（ウィンター・オーブ）
                    description = "雪結晶として形成されたウィンター・オーブの欠片。";
                    cost = 21000;
                    AdditionalDescription(ItemType.Material_Food);
                    rareLevel = RareLevel.Common;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_WHITE_AZARASHI_MEAT: // ドロップアイテム（追従する雪アザラシ）
                    description = "極寒の地で取れた肉は身がしまっており、大変歯ごたえがある。";
                    cost = 23600;
                    AdditionalDescription(ItemType.Material_Food);
                    rareLevel = RareLevel.Common;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_CENTAURUS_LEATHER: // ドロップアイテム（マジェスティック・ケンタウルス）
                    description = "ケンタウルスから剥ぎ取った皮は非常に柔らかく、かつ、剛性力が強い。";
                    cost = 42000;
                    AdditionalDescription(ItemType.Material_Equip);
                    rareLevel = RareLevel.Common;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_ARGONIAN_PURPLE_UROKO: // ドロップアイテム（知的なアルゴニアン）
                    description = "アルゴニアンから剥ぎ取った鱗は光沢のある紫色をしている。";
                    cost = 45500;
                    AdditionalDescription(ItemType.Material_Equip);
                    rareLevel = RareLevel.Common;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_BLUE_DANGAN_KAKERA: // ドロップアイテム（蒼い弾丸の欠片）
                    description = "魔法生物が更に結晶化させてきた弾丸の欠片。";
                    cost = 68000;
                    AdditionalDescription(ItemType.Material_Food);
                    rareLevel = RareLevel.Common;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                case FIX.RARE_PURE_CRYSTAL: // ドロップアイテム（ピュア・ブリザード・クリスタル）
                    description = "純正のクリスタル、希少価値が高く、トレード材料に使われる。";
                    cost = 175000;
                    AdditionalDescription(ItemType.Material_Potion);
                    rareLevel = RareLevel.Rare;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_WOLF_KEGAWA: // ドロップアイテム（紫目・ウェアウルフ）
                    description = "ごわごわとしたウルフの毛皮。少しとげとげしてて触ると痛い。";
                    cost = 26000;
                    AdditionalDescription(ItemType.Material_Equip);
                    rareLevel = RareLevel.Common;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_FROZEN_HEART: // ドロップアイテム（フロスト・ハート）
                    description = "魔法生物が結晶化した物の心臓部。鼓動が聞こえてきそうだ。";
                    cost = 28200;
                    AdditionalDescription(ItemType.Material_Potion);
                    rareLevel = RareLevel.Common;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_CLAW_HEART: // ドロップアイテム（百夜のグリズリー）
                    description = "死んだ直後に採取されたグリズリーの心臓。非常に大きく、ゴツゴツしている。";
                    cost = 31000;
                    AdditionalDescription(ItemType.Material_Potion);
                    rareLevel = RareLevel.Common;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_ESSENCE_OF_WIND: // ドロップアイテム（ウィンドブレイカー）
                    description = "風のマテリアル合成素材。武具職人の力量が問われる。";
                    cost = 59000;
                    AdditionalDescription(ItemType.Material_Potion);
                    rareLevel = RareLevel.Common;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                case FIX.RARE_TUNDRA_DEER_HORN: // ドロップアイテム（ツンドラ・ロングホーン・ディア）
                    description = "神の使いと称される鹿の偉大なる角、膨大な魔力が込められている。";
                    cost = 210000;
                    AdditionalDescription(ItemType.Material_Equip);
                    rareLevel = RareLevel.Rare;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                case FIX.EPIC_ORB_SILENT_COLD_ICE: // ドロップアイテム（三階の守護者：恐鳴主ハウリングシーザー）
                    // 攻撃ヒット時、稀に対象を凍結させ、＋効果のBUFFを全て消す。物理攻撃１０％UP、魔法攻撃１０％UP【常時】
                    description = "ハウリングシーザー撃破の際、落とされた宝珠。水魔法コスト３０％軽減、水魔法３０％強化";
                    description += "\r\n【特殊能力】　攻撃ヒット時、稀に対象を凍結させ、＋効果のBUFFを全て消す。";
                    manaCostReductionIce = 0.3f;
                    amplifyIce = 1.30f;
                    cost = 0;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Epic;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                #endregion
                #region "４階"
                case FIX.POOR_BLACK_MATERIAL4: // ドロップアイテム（４階任意）
                    description = "純黒色の立方体。素質変化を試みたが、不変のままである。";
                    cost = 78000;
                    AdditionalDescription(ItemType.Useless);
                    rareLevel = RareLevel.Poor;
                    limitValue = OTHER_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_HUNTER_SEVEN_TOOL: // ドロップアイテム（幻暗ハンター）
                    description = "ハンター達が長年利用してきたアイテム類は、戦況を有利な状況へと導いてくれる。";
                    cost = 127000;
                    AdditionalDescription(ItemType.Material_Equip);
                    rareLevel = RareLevel.Common;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_BEAST_KEGAWA: // ドロップアイテム（ビーストマスター）
                    description = "ビーストマスターが所有していた毛皮。弾力と剛質性を兼ね備えている。";
                    cost = 131000;
                    AdditionalDescription(ItemType.Material_Equip);
                    rareLevel = RareLevel.Common;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                case FIX.RARE_BLOOD_DAGGER_KAKERA: // ドロップアイテム（エルダーアサシン）
                    description = "ダガーに付着している血液は、どの獣の血か既にわからない。血液成分をキッチリ鑑定すれば、何かに使えそうだ。";
                    cost = 138000;
                    AdditionalDescription(ItemType.Material_Potion);
                    rareLevel = RareLevel.Rare;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_SABI_BUGU: // ドロップアイテム（フォールンシーカー）
                    description = "堕ちたる求道者は、武具のメンテナンスを全く行ってない。鍛冶屋がメンテナンスすれば元の状態に戻せそうだ。";
                    cost = 188000;
                    AdditionalDescription(ItemType.Material_Equip);
                    rareLevel = RareLevel.Common;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                case FIX.RARE_MEPHISTO_BLACKLIGHT: // ドロップアイテム（メフィスト・ザ・ライトアーム）
                    description = "メフィストの右腕についていた黒い瘴気が怪しく光っている。";
                    cost = 300000;
                    AdditionalDescription(ItemType.Material_Potion);
                    rareLevel = RareLevel.Rare;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_SEEKER_HEAD: // ドロップアイテム（闇の眷属）
                    description = "求道者の末期姿。闇の眷属は求道者の潜在能力を吸い取り、それを糧として力を得ていた。";
                    cost = 179000;
                    AdditionalDescription(ItemType.Material_Equip);
                    rareLevel = RareLevel.Common;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                case FIX.RARE_ESSENCE_OF_DARK: // ドロップアイテム（マスターロード）
                    description = "闇のマテリアル合成素材。武具職人の力量が問われる。";
                    cost = 191000;
                    AdditionalDescription(ItemType.Material_Equip);
                    rareLevel = RareLevel.Common;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_EXECUTIONER_ROBE: // ドロップアイテム（エグゼキュージョナー）
                    description = "執行人のローブには呪いの念がこめられており、通常の人間には扱えない。";
                    cost = 216000;
                    AdditionalDescription(ItemType.Material_Equip);
                    rareLevel = RareLevel.Common;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_NEMESIS_ESSENCE: // ドロップアイテム（マリオネット・ネメシス）
                    description = "倒れていたネメシスからエッセンスが抽出されたもの。溶かす事で何かの成分が摘出できそうだ。";
                    cost = 250000;
                    AdditionalDescription(ItemType.Material_Potion);
                    rareLevel = RareLevel.Common;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                case FIX.RARE_MASTERBLADE_KAKERA: // ドロップアイテム（黒炎マスターブレイド）
                    description = "マスターブレイドの威力は宿る色により変化すると言われている。";
                    cost = 263000;
                    AdditionalDescription(ItemType.Material_Equip);
                    rareLevel = RareLevel.Rare;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                case FIX.RARE_MASTERBLADE_FIRE: // ドロップアイテム（黒炎マスターブレイド）
                    description = "マスターブレイドに宿らせる火。禍々しさは消えうせている。";
                    cost = 273000;
                    AdditionalDescription(ItemType.Material_Food);
                    rareLevel = RareLevel.Rare;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_GREAT_JEWELCROWN: // ドロップアイテム（シン・ザ・ダークエルフ）
                    description = "派手な装飾により煌びやかに光っている。宝石素材のみ使い道あり。";
                    cost = 450000;
                    AdditionalDescription(ItemType.Material_Equip);
                    rareLevel = RareLevel.Rare;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                case FIX.RARE_ESSENCE_OF_SHINE: // ドロップアイテム（サン・ストライダー）
                    description = "聖のマテリアル合成素材。ポーション合成スキルの力量が問われる。";
                    cost = 360000;
                    AdditionalDescription(ItemType.Material_Potion);
                    rareLevel = RareLevel.Rare;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                case FIX.RARE_DEMON_HORN: // ドロップアイテム（アークデーモン）
                    description = "悪魔の角には咎を収める能力が込められている。その能力は角の繊維の奥深くに隠されている。";
                    cost = 370000;
                    AdditionalDescription(ItemType.Material_Potion);
                    rareLevel = RareLevel.Rare;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_KUMITATE_TENBIN: // ドロップアイテム（天秤を司る者）
                    description = "魔法生命の天秤より得られた素材。このままでは使えないが・・・";
                    cost = 380000;
                    AdditionalDescription(ItemType.Material_Equip);
                    rareLevel = RareLevel.Common;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_KUMITATE_TENBIN_DOU: // ドロップアイテム（天秤を司る者）
                    description = "魔法生命の天秤より得られた素材。このままでは使えないが・・・";
                    cost = 380000;
                    AdditionalDescription(ItemType.Material_Equip);
                    rareLevel = RareLevel.Common;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_KUMITATE_TENBIN_BOU: // ドロップアイテム（天秤を司る者）
                    description = "魔法生命の天秤より得られた素材。このままでは使えないが・・・";
                    cost = 380000;
                    AdditionalDescription(ItemType.Material_Equip);
                    rareLevel = RareLevel.Common;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                case FIX.COMMON_WYVERN_BONE: // ドロップアイテム（アンデッド・ワイバーン）
                    description = "ワイバーンの骨からは体力維持に欠かせないエキスが大量に抽出できる。";
                    cost = 383000;
                    AdditionalDescription(ItemType.Material_Potion);
                    rareLevel = RareLevel.Common;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                case FIX.RARE_ESSENCE_OF_FLAME: // ドロップアイテム（業・フレイムスラッシャー）
                    description = "火のマテリアル合成素材。武具職人の力量が問われる。";
                    cost = 385000;
                    AdditionalDescription(ItemType.Material_Equip);
                    rareLevel = RareLevel.Common;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                case FIX.RARE_BLACK_SEAL_IMPRESSION: // ドロップアイテム（デビル・チルドレン）
                    description = "黒色とは分からないほど、禍々しいまでにドス黒い印鑑。黒い液体はエキスとして使えそうだ。";
                    cost = 520000;
                    AdditionalDescription(ItemType.Material_Potion);
                    rareLevel = RareLevel.Rare;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;

                case FIX.COMMON_ONRYOU_HAKO: // ドロップアイテム（ハウリングホラー）
                    description = "何が飛び出てくるか分からない・・・箱からは強烈な恐怖が伝わってくるため、肝のすわった鍛冶職人にしか開くことは出来ない。";
                    cost = 475000;
                    AdditionalDescription(ItemType.Material_Equip);
                    rareLevel = RareLevel.Common;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                case FIX.RARE_ANGEL_SILK: // ドロップアイテム（ペインエンジェル）
                    description = "純白かつ透明なシルク素材。触っている感触が分からないほど軽い。";
                    cost = 490000;
                    AdditionalDescription(ItemType.Material_Equip);
                    rareLevel = RareLevel.Common;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                case FIX.RARE_CHAOS_SIZUKU: // ドロップアイテム（カオスワーデン)
                    description = "どれほどの人格者であったとしても、これに触れた途端、カオス属性に落とし込むエキスが内部に凝固化して入っている。";
                    cost = 520000;
                    AdditionalDescription(ItemType.Material_Potion);
                    rareLevel = RareLevel.Rare;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                case FIX.RARE_DREAD_EXTRACT: // ドロップアイテム（ドレッド・ナイト）
                    description = "恐怖のエッセンスが凝縮されているエキス。耐性力を高める効果が期待できる。";
                    cost = 560000;
                    AdditionalDescription(ItemType.Material_Potion);
                    rareLevel = RareLevel.Rare;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                case FIX.RARE_DOOMBRINGER_TUKA: // ドロップアイテム（ドゥームブリンガー）
                    description = "闇を滅するドゥームブリンガーの柄。不思議と握られた跡がない。";
                    cost = 666666;
                    AdditionalDescription(ItemType.Material_Equip);
                    rareLevel = RareLevel.Rare;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                case FIX.RARE_DOOMBRINGER_KAKERA: // ドロップアイテム（ドゥームブリンガー）
                    description = "闇を滅するドゥームブリンガーの欠片。不思議と血液は付着してない。";
                    cost = 666666;
                    AdditionalDescription(ItemType.Material_Equip);
                    rareLevel = RareLevel.Rare;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                case FIX.RARE_JOUKA_TANZOU: // 宝箱
                    description = "鍛造の中は、薄白色に光を放つ炎が永に存在している。手を入れても不思議と全く熱くはない。";
                    cost = 650000;
                    AdditionalDescription(ItemType.Material_Equip);
                    rareLevel = RareLevel.Rare;
                    limitValue = RARE_EPIC_ITEM_STACK_SIZE;
                    break;
                case FIX.RARE_ESSENCE_OF_ADAMANTINE: // 宝箱
                    description = "綺麗な球状の硬素材。カスリ傷一つ付いておらず、光の反射を見ていると魅入られてしまいそうだ。";
                    cost = 750000;
                    AdditionalDescription(ItemType.Material_Equip);
                    rareLevel = RareLevel.Rare;
                    limitValue = RARE_EPIC_ITEM_STACK_SIZE;
                    break;
                case FIX.EPIC_ORB_DESTRUCT_FIRE: // ドロップアイテム（闇焔レギィンアーゼ）
                    description = "レギィンアーゼ撃破の際、落とされた宝珠。クリティカルダメージ量を更に強化する。";
                    cost = 0;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Epic;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                #endregion
                #region "５階"
                case FIX.POOR_BLACK_MATERIAL5: // ドロップアイテム
                    description = "純黒色の立方体。元素への還元を試みたが、還元はされないまま。";
                    cost = 8400;
                    AdditionalDescription(ItemType.Useless);
                    rareLevel = RareLevel.Poor;
                    limitValue = OTHER_ITEM_STACK_SIZE;
                    break;

                case "ハート・オブ・フェニックス": // ドロップアイテム（Phoenix）
                    description = "伝説の生物Phoenixの心得。";
                    cost = 110000;
                    AdditionalDescription(ItemType.Material_Equip);
                    rareLevel = RareLevel.Rare;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                case "ハート・オブ・ドラゴン": // ドロップアイテム（Emerald Dragon）
                    description = "伝説の生物Emerald Dragonの心得。";
                    cost = 120000;
                    AdditionalDescription(ItemType.Material_Equip);
                    rareLevel = RareLevel.Rare;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                case "ハート・オブ・モンスター": // ドロップアイテム（Nine Tail）
                    description = "伝説の生物Nine Tailの心得。";
                    cost = 130000;
                    AdditionalDescription(ItemType.Material_Equip);
                    rareLevel = RareLevel.Rare;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                case "ハート・オブ・ジャッジ": // ドロップアイテム（Judgement）
                    description = "伝説の生物Judgementの心得。";
                    cost = 140000;
                    AdditionalDescription(ItemType.Material_Equip);
                    rareLevel = RareLevel.Rare;
                    limitValue = MATERIAL_ITEM_STACK_SIZE;
                    break;
                #endregion
                #endregion
                #region "階層別非依存ドロップ、　成長リキッドシリーズ"
                case FIX.GROWTH_LIQUID_STRENGTH:
                    description = "能力の一部を成長促進させる薬。力パラメタが１～３ＵＰする。";
                    PhysicalAttackMinValue = 1;
                    PhysicalAttackMaxValue = 3;
                    cost = 0;
                    AdditionalDescription(ItemType.Use_Potion);
                    rareLevel = RareLevel.Rare;
                    limitValue = RARE_EPIC_ITEM_STACK_SIZE;
                    break;
                case FIX.GROWTH_LIQUID_AGILITY:
                    description = "能力の一部を成長促進させる薬。技パラメタが１～３ＵＰする。";
                    PhysicalAttackMinValue = 1;
                    PhysicalAttackMaxValue = 3;
                    cost = 0;
                    AdditionalDescription(ItemType.Use_Potion);
                    rareLevel = RareLevel.Rare;
                    limitValue = RARE_EPIC_ITEM_STACK_SIZE;
                    break;
                case FIX.GROWTH_LIQUID_INTELLIGENCE:
                    description = "能力の一部を成長促進させる薬。知パラメタが１～３ＵＰする。";
                    PhysicalAttackMinValue = 1;
                    PhysicalAttackMaxValue = 3;
                    cost = 0;
                    AdditionalDescription(ItemType.Use_Potion);
                    rareLevel = RareLevel.Rare;
                    limitValue = RARE_EPIC_ITEM_STACK_SIZE;
                    break;
                case FIX.GROWTH_LIQUID_STAMINA:
                    description = "能力の一部を成長促進させる薬。体パラメタが１～３ＵＰする。";
                    PhysicalAttackMinValue = 1;
                    PhysicalAttackMaxValue = 3;
                    cost = 0;
                    AdditionalDescription(ItemType.Use_Potion);
                    rareLevel = RareLevel.Rare;
                    limitValue = RARE_EPIC_ITEM_STACK_SIZE;
                    break;
                case FIX.GROWTH_LIQUID_MIND:
                    description = "能力の一部を成長促進させる薬。心パラメタが１～３ＵＰする。";
                    PhysicalAttackMinValue = 1;
                    PhysicalAttackMaxValue = 3;
                    cost = 0;
                    AdditionalDescription(ItemType.Use_Potion);
                    rareLevel = RareLevel.Rare;
                    limitValue = RARE_EPIC_ITEM_STACK_SIZE;
                    break;

                case FIX.GROWTH_LIQUID2_STRENGTH:
                    description = "能力の一部を成長促進させる薬。力パラメタが５～１０ＵＰする。";
                    PhysicalAttackMinValue = 5;
                    PhysicalAttackMaxValue = 10;
                    cost = 0;
                    AdditionalDescription(ItemType.Use_Potion);
                    rareLevel = RareLevel.Rare;
                    limitValue = RARE_EPIC_ITEM_STACK_SIZE;
                    break;
                case FIX.GROWTH_LIQUID2_AGILITY:
                    description = "能力の一部を成長促進させる薬。技パラメタが５～１０ＵＰする。";
                    PhysicalAttackMinValue = 5;
                    PhysicalAttackMaxValue = 10;
                    cost = 0;
                    AdditionalDescription(ItemType.Use_Potion);
                    rareLevel = RareLevel.Rare;
                    limitValue = RARE_EPIC_ITEM_STACK_SIZE;
                    break;
                case FIX.GROWTH_LIQUID2_INTELLIGENCE:
                    description = "能力の一部を成長促進させる薬。知パラメタが５～１０ＵＰする。";
                    PhysicalAttackMinValue = 5;
                    PhysicalAttackMaxValue = 10;
                    cost = 0;
                    AdditionalDescription(ItemType.Use_Potion);
                    rareLevel = RareLevel.Rare;
                    limitValue = RARE_EPIC_ITEM_STACK_SIZE;
                    break;
                case FIX.GROWTH_LIQUID2_STAMINA:
                    description = "能力の一部を成長促進させる薬。体パラメタが５～１０ＵＰする。";
                    PhysicalAttackMinValue = 5;
                    PhysicalAttackMaxValue = 10;
                    cost = 0;
                    AdditionalDescription(ItemType.Use_Potion);
                    rareLevel = RareLevel.Rare;
                    limitValue = RARE_EPIC_ITEM_STACK_SIZE;
                    break;
                case FIX.GROWTH_LIQUID2_MIND:
                    description = "能力の一部を成長促進させる薬。心パラメタが５～１０ＵＰする。";
                    PhysicalAttackMinValue = 5;
                    PhysicalAttackMaxValue = 10;
                    cost = 0;
                    AdditionalDescription(ItemType.Use_Potion);
                    rareLevel = RareLevel.Rare;
                    limitValue = RARE_EPIC_ITEM_STACK_SIZE;
                    break;

                case FIX.GROWTH_LIQUID3_STRENGTH:
                    description = "能力の一部を成長促進させる薬。力パラメタが２０～３０ＵＰする。";
                    PhysicalAttackMinValue = 20;
                    PhysicalAttackMaxValue = 30;
                    cost = 0;
                    AdditionalDescription(ItemType.Use_Potion);
                    rareLevel = RareLevel.Rare;
                    limitValue = RARE_EPIC_ITEM_STACK_SIZE;
                    break;
                case FIX.GROWTH_LIQUID3_AGILITY:
                    description = "能力の一部を成長促進させる薬。技パラメタが２０～３０ＵＰする。";
                    PhysicalAttackMinValue = 20;
                    PhysicalAttackMaxValue = 30;
                    cost = 0;
                    AdditionalDescription(ItemType.Use_Potion);
                    rareLevel = RareLevel.Rare;
                    limitValue = RARE_EPIC_ITEM_STACK_SIZE;
                    break;
                case FIX.GROWTH_LIQUID3_INTELLIGENCE:
                    description = "能力の一部を成長促進させる薬。知パラメタが２０～３０ＵＰする。";
                    PhysicalAttackMinValue = 20;
                    PhysicalAttackMaxValue = 30;
                    cost = 0;
                    AdditionalDescription(ItemType.Use_Potion);
                    rareLevel = RareLevel.Rare;
                    limitValue = RARE_EPIC_ITEM_STACK_SIZE;
                    break;
                case FIX.GROWTH_LIQUID3_STAMINA:
                    description = "能力の一部を成長促進させる薬。体パラメタが２０～３０ＵＰする。";
                    PhysicalAttackMinValue = 20;
                    PhysicalAttackMaxValue = 30;
                    cost = 0;
                    AdditionalDescription(ItemType.Use_Potion);
                    rareLevel = RareLevel.Rare;
                    limitValue = RARE_EPIC_ITEM_STACK_SIZE;
                    break;
                case FIX.GROWTH_LIQUID3_MIND:
                    description = "能力の一部を成長促進させる薬。心パラメタが２０～３０ＵＰする。";
                    PhysicalAttackMinValue = 20;
                    PhysicalAttackMaxValue = 30;
                    cost = 0;
                    AdditionalDescription(ItemType.Use_Potion);
                    rareLevel = RareLevel.Rare;
                    limitValue = RARE_EPIC_ITEM_STACK_SIZE;
                    break;

                case FIX.GROWTH_LIQUID4_STRENGTH:
                    description = "能力の一部を成長促進させる薬。力パラメタが４５～６０ＵＰする。";
                    PhysicalAttackMinValue = 45;
                    PhysicalAttackMaxValue = 60;
                    cost = 0;
                    AdditionalDescription(ItemType.Use_Potion);
                    rareLevel = RareLevel.Rare;
                    limitValue = RARE_EPIC_ITEM_STACK_SIZE;
                    break;
                case FIX.GROWTH_LIQUID4_AGILITY:
                    description = "能力の一部を成長促進させる薬。技パラメタが４５～６０ＵＰする。";
                    PhysicalAttackMinValue = 45;
                    PhysicalAttackMaxValue = 60;
                    cost = 0;
                    AdditionalDescription(ItemType.Use_Potion);
                    rareLevel = RareLevel.Rare;
                    limitValue = RARE_EPIC_ITEM_STACK_SIZE;
                    break;
                case FIX.GROWTH_LIQUID4_INTELLIGENCE:
                    description = "能力の一部を成長促進させる薬。知パラメタが４５～６０ＵＰする。";
                    PhysicalAttackMinValue = 45;
                    PhysicalAttackMaxValue = 60;
                    cost = 0;
                    AdditionalDescription(ItemType.Use_Potion);
                    rareLevel = RareLevel.Rare;
                    limitValue = RARE_EPIC_ITEM_STACK_SIZE;
                    break;
                case FIX.GROWTH_LIQUID4_STAMINA:
                    description = "能力の一部を成長促進させる薬。体パラメタが４５～６０ＵＰする。";
                    PhysicalAttackMinValue = 45;
                    PhysicalAttackMaxValue = 60;
                    cost = 0;
                    AdditionalDescription(ItemType.Use_Potion);
                    rareLevel = RareLevel.Rare;
                    limitValue = RARE_EPIC_ITEM_STACK_SIZE;
                    break;
                case FIX.GROWTH_LIQUID4_MIND:
                    description = "能力の一部を成長促進させる薬。心パラメタが４５～６０ＵＰする。";
                    PhysicalAttackMinValue = 45;
                    PhysicalAttackMaxValue = 60;
                    cost = 0;
                    AdditionalDescription(ItemType.Use_Potion);
                    rareLevel = RareLevel.Rare;
                    limitValue = RARE_EPIC_ITEM_STACK_SIZE;
                    break;

                case FIX.GROWTH_LIQUID5_STRENGTH:
                    description = "能力の一部を成長促進させる薬。力パラメタが８０～１００ＵＰする。";
                    PhysicalAttackMinValue = 80;
                    PhysicalAttackMaxValue = 100;
                    cost = 0;
                    AdditionalDescription(ItemType.Use_Potion);
                    rareLevel = RareLevel.Rare;
                    limitValue = RARE_EPIC_ITEM_STACK_SIZE;
                    break;
                case FIX.GROWTH_LIQUID5_AGILITY:
                    description = "能力の一部を成長促進させる薬。技パラメタが８０～１００ＵＰする。";
                    PhysicalAttackMinValue = 80;
                    PhysicalAttackMaxValue = 100;
                    cost = 0;
                    AdditionalDescription(ItemType.Use_Potion);
                    rareLevel = RareLevel.Rare;
                    limitValue = RARE_EPIC_ITEM_STACK_SIZE;
                    break;
                case FIX.GROWTH_LIQUID5_INTELLIGENCE:
                    description = "能力の一部を成長促進させる薬。知パラメタが８０～１００ＵＰする。";
                    PhysicalAttackMinValue = 80;
                    PhysicalAttackMaxValue = 100;
                    cost = 0;
                    AdditionalDescription(ItemType.Use_Potion);
                    rareLevel = RareLevel.Rare;
                    limitValue = RARE_EPIC_ITEM_STACK_SIZE;
                    break;
                case FIX.GROWTH_LIQUID5_STAMINA:
                    description = "能力の一部を成長促進させる薬。体パラメタが８０～１００ＵＰする。";
                    PhysicalAttackMinValue = 80;
                    PhysicalAttackMaxValue = 100;
                    cost = 0;
                    AdditionalDescription(ItemType.Use_Potion);
                    rareLevel = RareLevel.Rare;
                    limitValue = RARE_EPIC_ITEM_STACK_SIZE;
                    break;
                case FIX.GROWTH_LIQUID5_MIND:
                    description = "能力の一部を成長促進させる薬。心パラメタが８０～１００ＵＰする。";
                    PhysicalAttackMinValue = 80;
                    PhysicalAttackMaxValue = 100;
                    cost = 0;
                    AdditionalDescription(ItemType.Use_Potion);
                    rareLevel = RareLevel.Rare;
                    limitValue = RARE_EPIC_ITEM_STACK_SIZE;
                    break;
                #endregion
                #region "レベル範囲に応じたドロップアイテム(Epic Only)"
                case FIX.EPIC_RING_OF_OSCURETE:
                    description = "古代賢者オスキュレーテが幼少時代に付けていたリング。力＋１５、技＋７、知＋３０、体力＋４、心＋８、魔法攻撃４５～６２";
                    MagicAttackMinValue = 45;
                    MagicAttackMaxValue = 62;
                    BuffUpStrength = 15;
                    BuffUpAgility = 7;
                    BuffUpIntelligence = 30;
                    BuffUpStamina = 4;
                    BuffUpMind = 8;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Epic;
                    limitValue = RARE_EPIC_ITEM_STACK_SIZE;
                    break;

                case FIX.EPIC_MERGIZD_SOL_BLADE:
                    description = "古代賢者メルギズドが幼少時代に付けていたブレード。力＋３０、知＋１６、物理攻撃４５～７８、魔法攻撃３６～４２";
                    PhysicalAttackMinValue = 45;
                    PhysicalAttackMaxValue = 78;
                    MagicAttackMinValue = 36;
                    MagicAttackMaxValue = 42;
                    BuffUpStrength = 30;
                    BuffUpIntelligence = 16;
                    AdditionalDescription(ItemType.Weapon_Heavy);
                    rareLevel = RareLevel.Epic;
                    limitValue = RARE_EPIC_ITEM_STACK_SIZE;
                    break;

                case FIX.EPIC_GARVANDI_ADILORB:
                    description = "古代賢者エーディルが幼少時代に付けていた水晶。技＋６５、知＋１１０、体＋６３、魔法攻撃２０１～３４４";
                    MagicAttackMinValue = 201;
                    MagicAttackMaxValue = 344;
                    buffUpAgility = 65;
                    buffUpIntelligence = 110;
                    buffUpStamina = 63;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Epic;
                    limitValue = RARE_EPIC_ITEM_STACK_SIZE;
                    break;

                case FIX.EPIC_MAXCARN_X_BUSTER:
                    description = "古代賢者マクスカーンが幼少時代に付けていた両手剣。力＋７５、技＋６３、心＋１００、物理攻撃２２０～６００";
                    PhysicalAttackMinValue = 220;
                    PhysicalAttackMaxValue = 600;
                    BuffUpStrength = 75;
                    BuffUpAgility = 63;
                    BuffUpMind = 100;
                    AdditionalDescription(ItemType.Weapon_TwoHand);
                    rareLevel = RareLevel.Epic;
                    limitValue = RARE_EPIC_ITEM_STACK_SIZE;
                    break;

                case FIX.EPIC_JUZA_ARESTINE_SLICER:
                    description = "古代賢者ジュザが幼少時代に付けていたスライサー爪。力＋１０６、技＋１３２、物理攻撃３２２～３８７";
                    PhysicalAttackMinValue = 322;
                    PhysicalAttackMaxValue = 387;
                    BuffUpStrength = 106;
                    BuffUpAgility = 132;
                    AdditionalDescription(ItemType.Weapon_Light);
                    rareLevel = RareLevel.Epic;
                    limitValue = RARE_EPIC_ITEM_STACK_SIZE;
                    break;

                case FIX.EPIC_SHEZL_MYSTIC_FORTUNE:
                    description = "古代賢者シェズルが幼少時代に付けていた衣。【常備能力：有】魔法防御４６０～５９８、沈黙耐性、スタン耐性、麻痺耐性、知＋５６０、魔攻率＋１０％、魔防率＋１０％、光耐性2000、理耐性2000";
                    description += "\r\n【常備能力】　毎ターン、マナが回復する。";
                    MagicDefenseMinValue = 460;
                    MagicDefenseMaxValue = 598;
                    ResistSilence = true;
                    ResistStun = true;
                    ResistParalyze = true;
                    amplifyMagicAttack = 1.1f;
                    amplifyMagicDefense = 1.1f;
                    buffUpIntelligence = 560;
                    ResistLight = 2000;
                    ResistForce = 2000;
                    AdditionalDescription(ItemType.Armor_Light);
                    rareLevel = RareLevel.Epic;
                    limitValue = RARE_EPIC_ITEM_STACK_SIZE;
                    break;

                case FIX.EPIC_FLOW_FUNNEL_OF_THE_ZVELDOZE:
                    description = "古代賢者ツヴェルドーゼが幼少時代に付けていた装飾品。【常備能力：有】物理防御０～１０５０、魔法防御０～１０５０、心＋５００、光耐性3500、闇耐性3500";
                    description += "\r\n【常備能力】　戦闘開始時、ワード・オブ・ライフとライズ・オブ・イメージが自分自身にかかる。";
                    PhysicalDefenseMinValue = 0;
                    PhysicalDefenseMaxValue = 1050;
                    MagicDefenseMinValue = 0;
                    MagicDefenseMaxValue = 1050;
                    amplifyPotential = 1.2f;
                    buffUpMind = 500;
                    ResistShadow = 3500;
                    ResistLight = 3500;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Epic;
                    limitValue = RARE_EPIC_ITEM_STACK_SIZE;
                    break;

                case FIX.EPIC_MERGIZD_DAV_AGITATED_BLADE:
                    description = "古代賢者メルギズドが青年時代に愛用していたブレード。物理攻撃５４５～６１２、魔法攻撃４２３～４６５、力＋２８５、知＋１６８、戦攻率＋１５％、魔攻率＋１５％";
                    PhysicalAttackMinValue = 545;
                    PhysicalAttackMaxValue = 612;
                    MagicAttackMinValue = 423;
                    MagicAttackMaxValue = 465;
                    buffUpStrength = 285;
                    buffUpIntelligence = 168;
                    amplifyPhysicalAttack = 1.15f;
                    amplifyMagicAttack = 1.15f;
                    AdditionalDescription(ItemType.Weapon_Heavy);
                    rareLevel = RareLevel.Epic;
                    limitValue = RARE_EPIC_ITEM_STACK_SIZE;
                    break;
                #endregion
                #region "合成アイテム"

                #region "５階"
                case "四神究極摂理": // ハート・オブ・フェニックス,ハート・オブ・ドラゴン,ハート・オブ・モンスター,ハート・オブ・ジャッジ
                    description = "伝説生物の心得を結集させたアクセサリ。魔法とスキルを同時併用可能になる。";
                    cost = 0;
                    AdditionalDescription(ItemType.Accessory);
                    rareLevel = RareLevel.Epic;
                    break;
                #endregion
                #endregion
            }
        }

        protected string itemName = string.Empty;
        protected string description = string.Empty;
        public int PhysicalAttackMinValue = 0;
        public int PhysicalAttackMaxValue = 0;
        protected int cost = 0;
        protected ItemType type = ItemType.None;
        protected Equipable equipablePerson = Equipable.All;
        protected RareLevel rareLevel = RareLevel.Poor;
        protected int buffUpStrength = 0;
        protected int buffUpAgility = 0;
        protected int buffUpIntelligence = 0;
        protected int buffUpStamina = 0;
        protected int buffUpMind = 0;
        protected double amplifyPhysicalAttack = 0.0f; // 後編追加
        protected double amplifyPhysicalDefense = 0.0f; // 後編追加
        protected double amplifyMagicAttack = 0.0f; // 後編追加
        protected double amplifyMagicDefense = 0.0f; // 後編追加
        protected double amplifyBattleSpeed = 0.0f; // 後編追加
        protected double amplifyBattleResponse = 0.0f; // 後編追加
        protected double amplifyPotential = 0.0f; // 後編追加
        protected double amplifyLight = 0.0f; // 後編追加
        protected double amplifyShadow = 0.0f; // 後編追加
        protected double amplifyFire = 0.0f; // 後編追加
        protected double amplifyIce = 0.0f; // 後編追加
        protected double amplifyForce = 0.0f; // 後編追加
        protected double amplifyWill = 0.0f; // 後編追加

        protected double effectValue1 = 0; // 後編追加(最大スキルポイント増加)
        protected double manaCostReduction = 0; // 後編追加(魔法消費軽減)
        protected double manaCostReductionLight = 0; // 後編追加
        protected double manaCostReductionShadow = 0; // 後編追加
        protected double manaCostReductionFire = 0; // 後編追加
        protected double manaCostReductionIce = 0; // 後編追加
        protected double manaCostReductionForce = 0; // 後編追加
        protected double manaCostReductionWill = 0; // 後編追加
        protected double skillCostReduction = 0; // 後編追加（スキル消費軽減）
        protected double skillCostReductionActive = 0; // 後編追加
        protected double skillCostReductionPassive = 0; // 後編追加
        protected double skillCostReductionSoft = 0; // 後編追加
        protected double skillCostReductionHard = 0; // 後編追加
        protected double skillCostReductionTruth = 0; // 後編追加
        protected double skillCostReductionVoid = 0; // 後編追加

        protected bool switchStatus1 = false; // 後編追加（メイズ・キューブの物理/魔法の対象切り替えにつくった値)

        protected string information = string.Empty;
        protected bool useSpecialAbility = false;
        protected bool afterBroken = false; // ジャンク・タリスマン発動時、戦闘終了後にアイテム破棄するために用意したフラグ
        protected bool onlyOnce = false; // デタッチメント・オーブにより、戦闘中に一度しか発動できないために用意したフラグ
        protected string imprintCommand = string.Empty; // 悪魔封じの壺により、キャンセル対象魔法の名前を覚えるために用意した
        protected bool effectStatus = false; // 玉手箱『秋玉』により、死亡時一度だけ蘇生するために用意したフラグ

        public string ItemName
        {
            get { return itemName; }
            set { itemName = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public int MinValue
        {
            get { return PhysicalAttackMinValue; }
            set { PhysicalAttackMinValue = value; }
        }
        public int MaxValue
        {
            get { return PhysicalAttackMaxValue; }
            set { PhysicalAttackMaxValue = value; }
        }

        public int Cost
        {
            get { return cost; }
            set { cost = value; }
        }

        public ItemType Type
        {
            get { return type; }
            set { type = value; }
        }
        public Equipable EquipablePerson
        {
            get { return equipablePerson; }
            set { equipablePerson = value; }
        }
        public RareLevel Rare
        {
            get { return rareLevel; }
            set { rareLevel = value; }
        }
        // s 後編追加
        public int StackValue
        {
            get { return stackValue; }
            set { stackValue = value; }
        }
        public int LimitValue
        {
            get { return limitValue; }
            set { limitValue = value; }
        }
        // e 後編追加
        public int BuffUpStrength
        {
            get { return buffUpStrength; }
            set { buffUpStrength = value; }
        }
        public int BuffUpAgility
        {
            get { return buffUpAgility; }
            set { buffUpAgility = value; }
        }
        public int BuffUpIntelligence
        {
            get { return buffUpIntelligence; }
            set { buffUpIntelligence = value; }
        }
        public int BuffUpStamina
        {
            get { return buffUpStamina; }
            set { buffUpStamina = value; }
        }
        public int BuffUpMind
        {
            get { return buffUpMind; }
            set { buffUpMind = value; }
        }
        // s 後編追加
        public double AmplifyPhysicalAttack
        {
            get { return amplifyPhysicalAttack; }
            set { amplifyPhysicalAttack = value; }
        }
        public double AmplifyPhysicalDefense
        {
            get { return amplifyPhysicalDefense; }
            set { amplifyPhysicalDefense = value; }
        }
        public double AmplifyMagicAttack
        {
            get { return amplifyMagicAttack; }
            set { amplifyMagicAttack = value; }
        }
        public double AmplifyMagicDefense
        {
            get { return amplifyMagicDefense; }
            set { amplifyMagicDefense = value; }
        }
        public double AmplifyBattleSpeed
        {
            get { return amplifyBattleSpeed; }
            set { amplifyBattleSpeed = value; }
        }
        public double AmplifyBattleResponse
        {
            get { return amplifyBattleResponse; }
            set { amplifyBattleResponse = value; }
        }
        public double AmplifyPotential
        {
            get { return amplifyPotential; }
            set { amplifyPotential = value; }
        }
        public double AmplifyLight
        {
            get { return amplifyLight; }
            set { amplifyLight = value; }
        }
        public double AmplifyShadow
        {
            get { return amplifyShadow; }
            set { amplifyShadow = value; }
        }
        public double AmplifyFire
        {
            get { return amplifyFire; }
            set { amplifyFire = value; }
        }
        public double AmplifyIce
        {
            get { return amplifyIce; }
            set { amplifyIce = value; }
        }
        public double AmplifyForce
        {
            get { return amplifyForce; }
            set { amplifyForce = value; }
        }
        public double AmplifyWill
        {
            get { return amplifyWill; }
            set { amplifyWill = value; }
        }
        public double EffectValue1
        {
            get { return effectValue1; }
            set { effectValue1 = value; }
        }
        public double ManaCostReduction
        {
            get { return manaCostReduction; }
            set { manaCostReduction = value; }
        }

        public double ManaCostReductionLight
        {
            get { return manaCostReductionLight; }
            set { manaCostReductionLight = value; }
        }
        public double ManaCostReductionShadow
        {
            get { return manaCostReductionShadow; }
            set { manaCostReductionShadow = value; }
        }
        public double ManaCostReductionFire
        {
            get { return manaCostReductionFire; }
            set { manaCostReductionFire = value; }
        }
        public double ManaCostReductionIce
        {
            get { return manaCostReductionIce; }
            set { manaCostReductionIce = value; }
        }
        public double ManaCostReductionForce
        {
            get { return manaCostReductionForce; }
            set { manaCostReductionForce = value; }
        }
        public double ManaCostReductionWill
        {
            get { return manaCostReductionWill; }
            set { manaCostReductionWill = value; }
        }

        public double SkillCostReduction
        {
            get { return skillCostReduction; }
            set { skillCostReduction = value; }
        }
        public double SkillCostReductionActive
        {
            get { return skillCostReductionActive; }
            set { skillCostReductionActive = value; }
        }
        public double SkillCostReductionPassive
        {
            get { return skillCostReductionPassive; }
            set { skillCostReductionPassive = value; }
        }
        public double SkillCostReductionSoft
        {
            get { return skillCostReductionSoft; }
            set { skillCostReductionSoft = value; }
        }
        public double SkillCostReductionHard
        {
            get { return skillCostReductionHard; }
            set { skillCostReductionHard = value; }
        }
        public double SkillCostReductionTruth
        {
            get { return skillCostReductionTruth; }
            set { skillCostReductionTruth = value; }
        }
        public double SkillCostReductionVoid
        {
            get { return skillCostReductionVoid; }
            set { skillCostReductionVoid = value; }
        }

        public bool SwitchStatus1
        {
            get { return switchStatus1; }
            set { switchStatus1 = value; }
        }
        // e 後編追加

        public string Information
        {
            get { return information; }
            set { information = value; }
        }
        // s 後編追加
        public int ResistFire { get; set; }
        public int ResistIce { get; set; }
        public int ResistLight { get; set; }
        public int ResistShadow { get; set; }
        public int ResistForce { get; set; }
        public int ResistWill { get; set; }
        // e 後編追加
        public bool UseSpecialAbility
        {
            get { return useSpecialAbility; }
            set { useSpecialAbility = value; }
        }
        // s 後編追加
        public bool AfterBroken
        {
            get { return afterBroken; }
            set { afterBroken = value; }
        }
        public bool EffectStatus
        {
            get { return effectStatus; }
            set { effectStatus = value; }
        }
        public bool OnlyOnce
        {
            get { return onlyOnce; }
            set { onlyOnce = value; }
        }
        public string ImprintCommand
        {
            get { return imprintCommand; }
            set { imprintCommand = value; }
        }
        // e 後編追加

        // s 後編追加
        public bool ResistStun { get; set; }
        public bool ResistSilence { get; set; }
        public bool ResistPoison { get; set; }
        public bool ResistTemptation { get; set; }
        public bool ResistFrozen { get; set; }
        public bool ResistParalyze { get; set; }
        public bool ResistSlow { get; set; }
        public bool ResistBlind { get; set; }
        public bool ResistSlip { get; set; }
        public bool ResistNoResurrection { get; set; }
        // e 後編追加

        public int UseIt()
        {
            System.Random rd = new System.Random(DateTime.Now.Millisecond);
            return rd.Next(PhysicalAttackMinValue, PhysicalAttackMaxValue + 1);
        }

        protected void AdditionalDescription(ItemType s_type)
        {
            this.type = s_type;
            //if (s_type == ItemType.Material_Equip)
            //{
            //    this.description = this.description.Insert(0, FIX.DESCRIPTION_EQUIP_MATERIAL);
            //}
            //else if (s_type == ItemType.Material_Food)
            //{
            //    this.description = this.description.Insert(0, FIX.DESCRIPTION_FOOD_MATERIAL);
            //}
            //else if (s_type == ItemType.Material_Potion)
            //{
            //    this.description = this.description.Insert(0, FIX.DESCRIPTION_POTION_MATERIAL);
            //}
            //else if (s_type == ItemType.Useless || type == ItemType.None)
            //{
            //    this.description = this.description.Insert(0, FIX.DESCRIPTION_SELL_ONLY);
            //}
        }
        public int PhysicalDefenseMinValue { get; set; }
        public int PhysicalDefenseMaxValue { get; set; }
        public int MagicAttackMinValue { get; set; }
        public int MagicAttackMaxValue { get; set; }
        public int MagicDefenseMinValue { get; set; }
        public int MagicDefenseMaxValue { get; set; }

        // s 後編追加
        protected int stackValue = 1; // 生成した時点で１つのオブジェクトがあるため、明示的に１を宣言
        protected int limitValue = 1; // オブジェクトがスタックできる最大数

        // [comment] アイテム消耗品より、RARE_EPICだった場合はスタック１とすること。
        //           装備品はRARE_EPICと同等で気にしなくて良い。
        public const int USING_ITEM_STACK_SIZE = 5;
        public const int RARE_EPIC_ITEM_STACK_SIZE = 1;
        public const int EQUIP_ITEM_STACK_SIZE = 1;
        public const int MATERIAL_ITEM_STACK_SIZE = 10;
        public const int OTHER_ITEM_STACK_SIZE = 10;
        // e 後編追加

        public void CleanUpStatus()
        {
            EffectStatus = false;
        }
    }
}
