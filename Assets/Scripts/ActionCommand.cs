using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObsidianPortal
{
    public class ActionCommand
    {
        /// <summary>
        /// コマンドのターゲットタイプ
        /// </summary>
        public enum TargetType
        {
            NoTarget, // 対象を取らない。
            Ally, // 味方１体
            Enemy, // 敵１体
            Area, // エリア指定
            AllyOrEnemy, // 味方１対か敵１体
            Own, // 自分自身
            AllyGroup, // 味方全員
            EnemyGroup, // 敵全員
            AllMember, // 敵味方全員
            InstantTarget, // インスタント行動を対象
        }

        public enum Attribute
        {
            None,
            NormalAttack,
            Spell,
            Skill,
        }

        public static List<int> GetRequiredLV(string playerName)
        {
            List<int> ssList = new List<int>();

            // とりあえず全員同じルールとする。
            ssList.Add(3);
            ssList.Add(6);
            ssList.Add(10);
            ssList.Add(15);
            ssList.Add(20);
            ssList.Add(25);
            ssList.Add(30);
            ssList.Add(35);
            ssList.Add(40);
            ssList.Add(50);
            ssList.Add(60);
            ssList.Add(70);

            return ssList;
        }

        public static List<string> GetActionCommandPrimary(string playerName)
        {
            List<string> ssName = new List<string>();

            // ビリー・ラキ
            if (playerName == FIX.DUEL_BILLY_RAKI)
            {
                ssName.Add(FIX.STRAIGHT_SMASH);
                ssName.Add(FIX.STANCE_OF_THE_BLADE);
                ssName.Add(FIX.DOUBLE_SLASH);
                ssName.Add(FIX.WAR_SWING);
                ssName.Add(FIX.KINETIC_SMASH);
                ssName.Add(FIX.STANCE_OF_THE_IAI);
                ssName.Add(FIX.DESTROYER_SMASH);
            }
            // アンナ・ハミルトン
            else if (playerName == FIX.DUEL_ANNA_HAMILTON)
            {
                ssName.Add(FIX.FIRE_BOLT);
                ssName.Add(FIX.FLAME_BLADE);
                ssName.Add(FIX.METEOR_BULLET);
                ssName.Add(FIX.FLAME_STRIKE);
                ssName.Add(FIX.SIGIL_OF_THE_HOMURA);
                ssName.Add(FIX.PIERCING_FLAME);
                ssName.Add(FIX.LAVA_ANNIHILATION);
            }
            // エオネ・フルネア
            else if (playerName == FIX.DUEL_EONE_FULNEA)
            {
                ssName.Add(FIX.FRESH_HEAL);
                ssName.Add(FIX.DIVINE_CIRCLE);
                ssName.Add(FIX.HOLY_BREATH);
                ssName.Add(FIX.SANCTION_FIELD);
                ssName.Add(FIX.VALKYRIE_BREAK);
                ssName.Add(FIX.SHINING_HEAL);
                ssName.Add(FIX.RESURRECTION);
            }
            return ssName;
        }

        public static List<string> GetActionCommandSecondary(string playerName)
        {
            List<string> ssName = new List<string>();

            // ビリー・ラキ
            if (playerName == FIX.DUEL_BILLY_RAKI)
            {
                ssName.Add(FIX.AURA_OF_POWER);
                ssName.Add(FIX.STORM_ARMOR);
                ssName.Add(FIX.AETHER_DRIVE);
                ssName.Add(FIX.CIRCLE_OF_THE_POWER);
                ssName.Add(FIX.RUNE_STRIKE);
                ssName.Add(FIX.WORD_OF_THE_REVOLUTION);
                ssName.Add(FIX.BRILLIANT_FORM);
            }
            // アンナ・ハミルトン
            else if (playerName == FIX.DUEL_ANNA_HAMILTON)
            {
                ssName.Add(FIX.HUNTER_SHOT);
                ssName.Add(FIX.MULTIPLE_SHOT);
                ssName.Add(FIX.REACHABLE_TARGET);
                ssName.Add(FIX.HAWK_EYE);
                ssName.Add(FIX.PIERCING_ARROW);
                ssName.Add(FIX.WIND_RUNNER);
                ssName.Add(FIX.DEADLY_ARROW);
            }
            // エオネ・フルネア
            else if (playerName == FIX.DUEL_EONE_FULNEA)
            {
                ssName.Add(FIX.ICE_NEEDLE);
                ssName.Add(FIX.PURE_PURIFICATION);
                ssName.Add(FIX.BLUE_BULLET);
                ssName.Add(FIX.FREEZING_CUBE);
                ssName.Add(FIX.FROST_LANCE);
                ssName.Add(FIX.WATER_SPLASH);
                ssName.Add(FIX.ABSOLUTE_ZERO);
            }
            return ssName;
        }

        public static Attribute GetAttribute(string command)
        {
            if (command == FIX.NORMAL_ATTACK) { return Attribute.NormalAttack; }

            if (command == FIX.STRAIGHT_SMASH) { return Attribute.Skill; }
            if (command == FIX.SHIELD_BASH) { return Attribute.Skill; }
            if (command == FIX.VENOM_SLASH) { return Attribute.Skill; }
            if (command == FIX.HUNTER_SHOT) { return Attribute.Skill; }
            if (command == FIX.HEART_OF_THE_LIFE) { return Attribute.Skill; }
            if (command == FIX.ORACLE_COMMAND) { return Attribute.Skill; }

            if (command == FIX.FRESH_HEAL) { return Attribute.Spell; }
            if (command == FIX.SHADOW_BLAST) { return Attribute.Spell; }
            if (command == FIX.ICE_NEEDLE) { return Attribute.Spell; }
            if (command == FIX.FIRE_BOLT) { return Attribute.Spell; }
            if (command == FIX.AURA_OF_POWER) { return Attribute.Spell; }
            if (command == FIX.SKY_SHIELD) { return Attribute.Spell; }

            return Attribute.None;
        }

        /// <summary>
        /// コマンドのターゲットタイプを判別します。
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public static TargetType GetTargetType(string command)
        {
            // Basic
            if (command == FIX.NORMAL_ATTACK) { return TargetType.Enemy; }

            // Delve I
            if (command == FIX.STRAIGHT_SMASH) { return TargetType.Enemy; }
            if (command == FIX.SHIELD_BASH) { return TargetType.Enemy; }
            if (command == FIX.HUNTER_SHOT) { return TargetType.Enemy; }
            if (command == FIX.VENOM_SLASH) { return TargetType.Enemy; }
            if (command == FIX.HEART_OF_THE_LIFE) { return TargetType.Ally; }
            if (command == FIX.ORACLE_COMMAND) { return TargetType.Ally; }
            if (command == FIX.FRESH_HEAL) { return TargetType.Ally; }
            if (command == FIX.SHADOW_BLAST) { return TargetType.Enemy; }
            if (command == FIX.FIRE_BOLT) { return TargetType.Enemy; }
            if (command == FIX.ICE_NEEDLE) { return TargetType.Enemy; }
            if (command == FIX.AURA_OF_POWER) { return TargetType.Ally; }
            if (command == FIX.SKY_SHIELD) { return TargetType.Ally; }

            // Delve II
            if (command == FIX.STANCE_OF_THE_BLADE) { return TargetType.Own; }
            if (command == FIX.STANCE_OF_THE_GUARD) { return TargetType.Own; }
            if (command == FIX.MULTIPLE_SHOT) { return TargetType.EnemyGroup; }
            if (command == FIX.INVISIBLE_BIND) { return TargetType.Enemy; }
            if (command == FIX.FORTUNE_SPIRIT) { return TargetType.Ally; }
            if (command == FIX.ZERO_IMMUNITY) { return TargetType.Ally; }
            if (command == FIX.DIVINE_CIRCLE) { return TargetType.AllyGroup; }
            if (command == FIX.BLOOD_SIGN) { return TargetType.Enemy; }
            if (command == FIX.FLAME_BLADE) { return TargetType.Ally; }
            if (command == FIX.PURE_PURIFICATION) { return TargetType.Ally; }
            if (command == FIX.STORM_ARMOR) { return TargetType.Ally; }
            if (command == FIX.DISPEL_MAGIC) { return TargetType.Enemy; }

            // Other Special
            if (command == FIX.DASH) { return TargetType.Enemy; }
            if (command == FIX.REACHABLETARGET) { return TargetType.Enemy; }
            if (command == FIX.EARTHBIND) { return TargetType.Enemy; }
            if (command == FIX.NEEDLESPEAR) { return TargetType.Enemy; }
            if (command == FIX.SILVERARROW) { return TargetType.Enemy; }
            if (command == FIX.BLAZE) { return TargetType.Area; }
            if (command == FIX.LAVAWALL) { return TargetType.Area; }
            if (command == FIX.EXPLOSION) { return TargetType.Enemy; }
            if (command == FIX.POWERWORD) { return TargetType.Ally; }
            if (command == FIX.PROTECTION) { return TargetType.Ally; }
            if (command == FIX.HEATBOOST) { return TargetType.Ally; }
            if (command == FIX.HEALINGWORD) { return TargetType.Ally; }
            if (command == FIX.FIREBLADE) { return TargetType.Own; }
            if (command == FIX.HOLYBULLET) { return TargetType.Own; }

            return TargetType.NoTarget;
        }

        /// <summary>
        /// コマンドが回復系かどうかを判別します。(trueが回復系)
        /// </summary>
        /// <param name="commandName"></param>
        /// <returns></returns>
        public static bool IsHeal(string command)
        {
            if (command == FIX.HEALINGWORD ||
                command == FIX.FRESH_HEAL)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// アニメーション対象番号を取得します。(-1の場合、アニメーションなしを実行してください）
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public static int GetSkillNumbering(string command)
        {
            if (command == FIX.NORMAL_ATTACK) { return 0; }
            if (command == FIX.DASH) { return 1; }
            if (command == FIX.REACHABLETARGET) { return 2; }
            if (command == FIX.EARTHBIND) { return 3; }
            if (command == FIX.POWERWORD) { return 4; }
            if (command == FIX.HEALINGWORD) { return 5; }
            if (command == FIX.NEEDLESPEAR) { return 6; }
            if (command == FIX.SILVERARROW) { return 7; }
            if (command == FIX.HOLYBULLET) { return 8; }
            if (command == FIX.PROTECTION) { return 9; }
            if (command == FIX.FRESH_HEAL) { return 10; }
            if (command == FIX.FIREBLADE) { return 11; }
            if (command == FIX.LAVAWALL) { return 12; }
            if (command == FIX.BLAZE) { return 13; }
            if (command == FIX.HEATBOOST) { return 14; }
            if (command == FIX.EXPLOSION) { return 15; }
            return -1;
        }

        /// <summary>
        /// コマンドの説明文を取得します。
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public static string GetDescription(string command)
        {
            if (command == FIX.NORMAL_ATTACK) { return "通常攻撃を行う。"; }

            // 人間族
            if (command == FIX.DASH) { return "直線上にある２つ先のタイルに存在する対象の敵へ近づき、【３】ダメージを与える。"; }
            if (command == FIX.REACHABLETARGET) { return "対象の敵をターゲットとして記憶する。ターゲット対象はダメージ発生時、追加で【２】ダメージ食らう。"; }
            if (command == FIX.EARTHBIND) { return "対象の敵を拘束し、移動不可にする。"; }
            if (command == FIX.HEALINGWORD) { return "対象の味方のライフを【３】回復する。その後、対象の順序が来た場合、ライフを【３】回復する。"; }
            if (command == FIX.POWERWORD) { return "対象の味方のSTRを【＋２】する。"; }
            // 天使族
            if (command == FIX.NEEDLESPEAR) { return "対象の敵へ【３】ダメージを与える。加えて、対象の位置を１タイルだけ後方へ移動させる。"; }
            if (command == FIX.SILVERARROW) { return "対象の敵に【３】ダメージを与える。加えて、次の順序が来た場合、特殊能力が発動できなくなる。"; }
            if (command == FIX.HOLYBULLET) { return "自分の位置を中心として、周囲のタイルに存在する敵ユニットへ【４】ダメージを与える。"; }
            if (command == FIX.PROTECTION) { return "対象の味方のDEFを【＋２】する。"; }
            if (command == FIX.FRESH_HEAL) { return "対象の味方の状態異常を解除する。加えて、ライフを【６】回復する。"; }
            // 炎霊族
            if (command == FIX.FIREBLADE) { return "自分自身のSTRを【＋３】する。"; }
            if (command == FIX.LAVAWALL) { return "自分の前方周囲のタイル３つに炎の壁を出現させる。このタイルに隣接しているユニットは順序開始時【１】ダメージ受ける。"; }
            if (command == FIX.BLAZE) { return "直線上にある３つ先のタイルまで存在するユニットに対して、【５】ダメージを与える。"; }
            if (command == FIX.HEATBOOST) { return "対象の味方の待機時間を【－８】する。"; }
            if (command == FIX.EXPLOSION) { return "自分自身を爆発させる事で、対象の敵に【２５】ダメージを与える。この後、本ユニットは死亡する。"; }

            return string.Empty;
        }

        public static int UsedAP(string command)
        {
            if (command == FIX.NORMAL_ATTACK) { return 0; }

            // Delve I
            if (command == FIX.STRAIGHT_SMASH) { return 2; }
            if (command == FIX.SHIELD_BASH) { return 2; }
            if (command == FIX.HUNTER_SHOT) { return 2; }
            if (command == FIX.VENOM_SLASH) { return 2; }
            if (command == FIX.HEART_OF_THE_LIFE) { return 2; }
            if (command == FIX.ORACLE_COMMAND) { return 2; }
            if (command == FIX.FRESH_HEAL) { return 2; }
            if (command == FIX.SHADOW_BLAST) { return 2; }
            if (command == FIX.FIRE_BOLT) { return 2; }
            if (command == FIX.ICE_NEEDLE) { return 2; }
            if (command == FIX.AURA_OF_POWER) { return 2; }
            if (command == FIX.SKY_SHIELD) { return 2; }

            // Delve II
            if (command == FIX.STANCE_OF_THE_BLADE) { return 3; }
            if (command == FIX.STANCE_OF_THE_GUARD) { return 3; }
            if (command == FIX.MULTIPLE_SHOT) { return 3; }
            if (command == FIX.INVISIBLE_BIND) { return 3; }
            if (command == FIX.FORTUNE_SPIRIT) { return 3; }
            if (command == FIX.ZERO_IMMUNITY) { return 3; }
            if (command == FIX.DIVINE_CIRCLE) { return 3; }
            if (command == FIX.BLOOD_SIGN) { return 3; }
            if (command == FIX.FLAME_BLADE) { return 3; }
            if (command == FIX.PURE_PURIFICATION) { return 3; }
            if (command == FIX.STORM_ARMOR) { return 3; }
            if (command == FIX.DISPEL_MAGIC) { return 3; }

            // Delve III
            if (command == FIX.DOUBLE_SLASH) { return 4; }
            if (command == FIX.CONCUSSIVE_HIT) { return 4; }
            if (command == FIX.REACHABLE_TARGET) { return 4; }
            if (command == FIX.IRREGULAR_STEP) { return 4; }
            if (command == FIX.VOICE_OF_THE_VIGOR) { return 4; }
            if (command == FIX.SPIRITUAL_REST) { return 4; }
            if (command == FIX.HOLY_BREATH) { return 4; }
            if (command == FIX.DEATH_SCYTHE) { return 4; }
            if (command == FIX.METEOR_BULLET) { return 4; }
            if (command == FIX.BLUE_BULLET) { return 4; }
            if (command == FIX.AETHER_DRIVE) { return 4; }
            if (command == FIX.MUTE_IMPULSE) { return 4; }

            // Delve IV
            if (command == FIX.WAR_SWING) { return 5; }
            if (command == FIX.DOMINATION_FIELD) { return 5; }
            if (command == FIX.HAWK_EYE) { return 5; }
            if (command == FIX.DISSENSION_RHYTHM) { return 5; }
            if (command == FIX.SIGIL_OF_THE_FAITH) { return 5; }
            if (command == FIX.ESSENCE_OVERFLOW) { return 5; }
            if (command == FIX.SANCTION_FIELD) { return 5; }
            if (command == FIX.BLACK_VOICE) { return 5; }
            if (command == FIX.FLAME_STRIKE) { return 5; }
            if (command == FIX.FREEZING_CUBE) { return 5; }
            if (command == FIX.CIRCLE_OF_THE_POWER) { return 5; }
            if (command == FIX.DETACHMENT_FAULT) { return 5; }

            // Delve V
            if (command == FIX.KINETIC_SMASH) { return 6; }
            if (command == FIX.SAFETY_FIELD) { return 6; }
            if (command == FIX.PIERCING_ARROW) { return 6; }
            if (command == FIX.ASSASINATION_HIT) { return 6; }
            if (command == FIX.CALL_OF_THE_STORM) { return 6; }
            if (command == FIX.INNER_INSPIRATION) { return 6; }
            if (command == FIX.VALKYRIE_BREAK) { return 6; }
            if (command == FIX.ABYSS_EYE) { return 6; }
            if (command == FIX.SIGIL_OF_THE_HOMURA) { return 6; }
            if (command == FIX.FROST_LANCE) { return 6; }
            if (command == FIX.RUNE_STRIKE) { return 6; }
            if (command == FIX.PHANTOM_OBORO) { return 6; }

            // Delve VI
            if (command == FIX.STANCE_OF_THE_IAI) { return 7; }
            if (command == FIX.OATH_OF_THE_AEGIS) { return 7; }
            if (command == FIX.WIND_RUNNER) { return 7; }
            if (command == FIX.KILLER_GAZE) { return 7; }
            if (command == FIX.SOUL_SHOUT) { return 7; }
            if (command == FIX.EVERFLOW_MIND) { return 7; }
            if (command == FIX.SHINING_HEAL) { return 7; }
            if (command == FIX.THE_DARK_INTENSITY) { return 7; }
            if (command == FIX.PIERCING_FLAME) { return 7; }
            if (command == FIX.WATER_SPLASH) { return 7; }
            if (command == FIX.WORD_OF_THE_REVOLUTION) { return 7; }
            if (command == FIX.TRANQUILITY) { return 7; }

            // Delve VI
            if (command == FIX.DESTROYER_SMASH) { return 8; }
            if (command == FIX.ONE_IMMUNITY) { return 8; }
            if (command == FIX.DEADLY_ARROW) { return 8; }
            if (command == FIX.CARNAGE_RUSH) { return 8; }
            if (command == FIX.OVERWHELMING_DESTINY) { return 8; }
            if (command == FIX.TRANSCENDENCE_REACHED) { return 8; }
            if (command == FIX.RESURRECTION) { return 8; }
            if (command == FIX.DEMON_CONTRACT) { return 8; }
            if (command == FIX.LAVA_ANNIHILATION) { return 8; }
            if (command == FIX.ABSOLUTE_ZERO) { return 8; }
            if (command == FIX.BRILLIANT_FORM) { return 8; }
            if (command == FIX.TIME_SKIP) { return 8; }

            // Other Special
            if (command == FIX.DASH) { return 2; }
            if (command == FIX.REACHABLETARGET) { return 2; }
            if (command == FIX.EARTHBIND) { return 2; }
            if (command == FIX.NEEDLESPEAR) { return 2; }
            if (command == FIX.SILVERARROW) { return 2; }
            if (command == FIX.BLAZE) { return 2; }
            if (command == FIX.LAVAWALL) { return 2; }
            if (command == FIX.EXPLOSION) { return 2; }
            if (command == FIX.POWERWORD) { return 2; }
            if (command == FIX.PROTECTION) { return 2; }
            if (command == FIX.HEATBOOST) { return 2; }
            if (command == FIX.HEALINGWORD) { return 2; }
            if (command == FIX.FIREBLADE) { return 2; }
            if (command == FIX.HOLYBULLET) { return 2; }

            return 0;
        }

        public static int AreaRange(Unit player, string command)
        {
            // Basic
            if (command == FIX.NORMAL_ATTACK)
            {
                switch (player.Job)
                {
                    case FIX.JobClass.Fighter:
                    case FIX.JobClass.Seeker:
                    case FIX.JobClass.Enchanter:
                        return 1;

                    case FIX.JobClass.Ranger:
                    case FIX.JobClass.Priest:
                    case FIX.JobClass.Magician:
                        return 2;

                    default:
                        return 1;
                }
            }

            // Delve I
            if (command == FIX.STRAIGHT_SMASH) { return 1; }
            if (command == FIX.SHIELD_BASH) { return 1; }
            if (command == FIX.HUNTER_SHOT) { return 2; }
            if (command == FIX.VENOM_SLASH) { return 1; }
            if (command == FIX.HEART_OF_THE_LIFE) { return 3; }
            if (command == FIX.ORACLE_COMMAND) { return 3; }
            if (command == FIX.FRESH_HEAL) { return 3; }
            if (command == FIX.SHADOW_BLAST) { return 2; }
            if (command == FIX.FIRE_BOLT) { return 2; }
            if (command == FIX.ICE_NEEDLE) { return 2; }
            if (command == FIX.AURA_OF_POWER) { return 3; }
            if (command == FIX.SKY_SHIELD) { return 3; }

            // Delve II
            if (command == FIX.STANCE_OF_THE_BLADE) { return 0; }
            if (command == FIX.STANCE_OF_THE_GUARD) { return 0; }
            if (command == FIX.MULTIPLE_SHOT) { return 2; }
            if (command == FIX.INVISIBLE_BIND) { return 1; }
            if (command == FIX.FORTUNE_SPIRIT) { return 3; }
            if (command == FIX.ZERO_IMMUNITY) { return 3; }
            if (command == FIX.DIVINE_CIRCLE) { return 2; }
            if (command == FIX.BLOOD_SIGN) { return 2; }
            if (command == FIX.FLAME_BLADE) { return 3; }
            if (command == FIX.PURE_PURIFICATION) { return 3; }
            if (command == FIX.STORM_ARMOR) { return 3; }
            if (command == FIX.DISPEL_MAGIC) { return 2; }

            // Other Special
            if (command == FIX.DASH) { return 2; }
            if (command == FIX.REACHABLETARGET) { return 2; }
            if (command == FIX.EARTHBIND) { return 2; }
            if (command == FIX.NEEDLESPEAR) { return 2; }
            if (command == FIX.SILVERARROW) { return 2; }
            if (command == FIX.BLAZE) { return 4; }
            if (command == FIX.LAVAWALL) { return 2; }
            if (command == FIX.EXPLOSION) { return 2; }
            if (command == FIX.POWERWORD) { return 3; }
            if (command == FIX.PROTECTION) { return 3; }
            if (command == FIX.HEATBOOST) { return 3; }
            if (command == FIX.HEALINGWORD) { return 3; }
            if (command == FIX.FIREBLADE) { return 0; }
            if (command == FIX.HOLYBULLET) { return 0; }

            return 3;
        }

        /// <summary>
        /// ターン経過に対するBUFFの維持
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public static int IsBuffTurn(string command)
        {
            if (command == FIX.POWERWORD) { return 5; }
            if (command == FIX.SILVERARROW) { return 2; }
            if (command == FIX.EARTHBIND) { return 2; }
            if (command == FIX.PROTECTION) { return 5; }
            if (command == FIX.FIREBLADE) { return 5; }
            if (command == FIX.HEALINGWORD) { return 2; }
            if (command == FIX.REACHABLETARGET) { return 5; }

            if (command == FIX.HEART_OF_THE_LIFE) { return 10; }
            if (command == FIX.AURA_OF_POWER) { return 5; }
            if (command == FIX.SKY_SHIELD) { return 5; }
            if (command == FIX.STANCE_OF_THE_BLADE) { return 3; }
            if (command == FIX.STANCE_OF_THE_GUARD) { return 3; }
            if (command == FIX.INVISIBLE_BIND) { return 2; }
            if (command == FIX.FORTUNE_SPIRIT) { return 10; }
            if (command == FIX.ZERO_IMMUNITY) { return 2; }
            if (command == FIX.DIVINE_CIRCLE) { return 3; }
            if (command == FIX.BLOOD_SIGN) { return 5; }
            if (command == FIX.FLAME_BLADE) { return 5; }
            if (command == FIX.STORM_ARMOR) { return 5; }

            return FIX.INFINITY;
        }

        public static int EffectValue(string command)
        {
            if (command == FIX.DASH) { return 3; }
            if (command == FIX.REACHABLETARGET) { return 2; }
            if (command == FIX.EARTHBIND) { return 1; }
            if (command == FIX.HEALINGWORD) { return 3; }
            if (command == FIX.POWERWORD) { return 2; }

            if (command == FIX.FIREBLADE) { return 3; }
            if (command == FIX.LAVAWALL) { return 0; } // no meaning
            if (command == FIX.BLAZE) { return 5; }
            if (command == FIX.HEATBOOST) { return 8; }
            if (command == FIX.EXPLOSION) { return 25; }

            if (command == FIX.NEEDLESPEAR) { return 3; }
            if (command == FIX.SILVERARROW) { return 3; }
            if (command == FIX.HOLYBULLET) { return 5; }
            if (command == FIX.FRESH_HEAL) { return 6; }
            if (command == FIX.PROTECTION) { return 2; }

            if (command == FIX.AURA_OF_POWER) { return 2; }

            if (command == FIX.EFFECT_POISON) { return 2; }
            Debug.Log("EffectValue is else???");
            return 0;
        }            
    }
}
