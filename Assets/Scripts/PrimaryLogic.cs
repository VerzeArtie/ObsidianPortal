using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace ObsidianPortal
{
    public static class PrimaryLogic
    {
        public enum NeedType
        {
            Random,
            Min,
            Max
        }

        public enum DmgAttr
        {
            Physical,
            Magic,
        }

        public enum SpellSkillType
        {
            Standard,
            PsychicWave,
            WordOfPower,
        }

        private static double CoreDamage(Unit player, NeedType type, double min, double max)
        {
            double result = 0.0;
            switch (type)
            {
                case NeedType.Random:
                    double sigma = 0.0f;
                    double mu = 0.0f;
                    // sigma
                    if (player.TotalMind <= ((max + min) / 2.0F)) { sigma = (player.TotalMind / 3.5F); }
                    else { sigma = (((max + min) / 2.0F) / 3.5F); }
                    // mu
                    if (player.TotalMind <= min) mu = min;
                    else if (player.TotalMind >= max) mu = max;
                    else { mu = player.TotalMind; }
                    // 『標準正規累積分布に対する逆関数』により算出される
                    result = (Statistics.Distributions.NormInv(AP.Math.RandomReal(), mu, sigma));
                    if (result <= min) result = min;
                    if (result >= max) result = max;
                    break;
                case NeedType.Min:
                    result = min;
                    break;
                case NeedType.Max:
                    result = max;
                    break;
            }
            return result;
        }

        /// <summary>
        /// 物理攻撃力
        /// </summary>
        public static double PhysicalAttack(Unit player)
        {
            return AttackValue(player, NeedType.Min, DmgAttr.Physical, 1.0F, 0.0F, 0.0F, 0.0F, SpellSkillType.Standard, false);
        }
        public static double PhysicalAttack(Unit player, NeedType type, double pStr, double pAgl, double pInt, double pMind)
        {
            return AttackValue(player, type, DmgAttr.Physical, pStr, pAgl, pInt, pMind, SpellSkillType.Standard, false);
        }

        /// <summary>
        /// 魔法攻撃力
        /// </summary>
        public static double MagicAttack(Unit player)
        {
            return AttackValue(player, NeedType.Min, DmgAttr.Magic, 0.0F, 0.0F, 1.0F, 0.0F, SpellSkillType.Standard, false);
        }
        public static double MagicAttack(Unit player, NeedType type, double pStr, double pAgl, double pInt, double pMind)
        {
            return AttackValue(player, type, DmgAttr.Magic, pStr, pAgl, pInt, pMind, SpellSkillType.Standard, false);
        }

        /// <summary>
        /// 攻撃力
        /// </summary>
        public static double AttackValue(Unit player, NeedType type, DmgAttr attr, double pStr, double pAgl, double pInt, double pMind, SpellSkillType spellSkill, bool ignoreChargeCount)
        {
            double min = 0;
            double max = 0;
            double factor = 0.0f;

            // パラメタによるベース値は「力」「技」「知」の組み合わせとする。
            factor = player.TotalStrength * pStr + player.TotalAgility * pAgl + player.TotalIntelligence * pInt;

            // 心係数で値を増幅する。
            min = factor * Math.Log(Convert.ToInt32(player.TotalMind), Math.Exp(1)) / 2.00;
            max = factor * Math.Log(Convert.ToInt32(player.TotalMind), Math.Exp(1)) / 2.00;

            // 物理系は物理UP効果を対象
            if (attr == DmgAttr.Physical)
            {
                // 武器による加算値（メイン）
                if (player.MainWeapon != null)
                {
                    min += player.MainWeapon.PhysicalAttackMinValue;
                    max += player.MainWeapon.PhysicalAttackMaxValue;
                }
                // 武器による加算値（サブ）
                if (player.SubWeapon != null)
                {
                    min += player.SubWeapon.PhysicalAttackMinValue;
                    max += player.SubWeapon.PhysicalAttackMaxValue;
                }
                // 防具による加算値
                if (player.MainArmor != null)
                {
                    min += player.MainArmor.PhysicalAttackMinValue;
                    max += player.MainArmor.PhysicalAttackMaxValue;
                }
                // アクセサリによる加算値
                if (player.Accessory != null)
                {
                    min += player.Accessory.PhysicalAttackMinValue;
                    max += player.Accessory.PhysicalAttackMaxValue;
                }
                if (player.Accessory2 != null)
                {
                    min += player.Accessory2.PhysicalAttackMinValue;
                    max += player.Accessory2.PhysicalAttackMaxValue;
                }
                if (player.Accessory3 != null)
                {
                    min += player.Accessory3.PhysicalAttackMinValue;
                    max += player.Accessory3.PhysicalAttackMaxValue;
                }
            }
            // 魔法系は魔法UP効果を対象
            else // if (attr == DmgAttr.Magic)
            {
                // 武器による加算値（メイン）
                if (player.MainWeapon != null)
                {
                    min += player.MainWeapon.MagicAttackMinValue;
                    max += player.MainWeapon.MagicAttackMaxValue;
                }
                // 武器による加算値（サブ）
                if (player.SubWeapon != null)
                {
                    min += player.SubWeapon.MagicAttackMinValue;
                    max += player.SubWeapon.MagicAttackMaxValue;
                }
                // 防具による加算値
                if (player.MainArmor != null)
                {
                    min += player.MainArmor.MagicAttackMinValue;
                    max += player.MainArmor.MagicAttackMaxValue;
                }
                // アクセサリによる加算値
                if (player.Accessory != null)
                {
                    min += player.Accessory.MagicAttackMinValue;
                    max += player.Accessory.MagicAttackMaxValue;
                }
                if (player.Accessory2 != null)
                {
                    min += player.Accessory2.MagicAttackMinValue;
                    max += player.Accessory2.MagicAttackMaxValue;
                }
                if (player.Accessory3 != null)
                {
                    min += player.Accessory3.MagicAttackMinValue;
                    max += player.Accessory3.MagicAttackMaxValue;
                }
            }

            double result = CoreDamage(player, type, min, max);

            // 武器、防具、アクセサリからの増強
            if (attr == DmgAttr.Physical)
            {
                if ((player.MainWeapon != null) && (player.MainWeapon.AmplifyPhysicalAttack != 0.0f)) result = result * player.MainWeapon.AmplifyPhysicalAttack;
                if ((player.SubWeapon != null) && (player.SubWeapon.AmplifyPhysicalAttack != 0.0f)) result = result * player.SubWeapon.AmplifyPhysicalAttack;
                if ((player.MainArmor != null) && (player.MainArmor.AmplifyPhysicalAttack != 0.0f)) result = result * player.MainArmor.AmplifyPhysicalAttack;
                if ((player.Accessory != null) && (player.Accessory.AmplifyPhysicalAttack != 0.0f)) result = result * player.Accessory.AmplifyPhysicalAttack;
                if ((player.Accessory2 != null) && (player.Accessory2.AmplifyPhysicalAttack != 0.0f)) result = result * player.Accessory2.AmplifyPhysicalAttack;
                if ((player.Accessory3 != null) && (player.Accessory3.AmplifyPhysicalAttack != 0.0f)) result = result * player.Accessory3.AmplifyPhysicalAttack;
            }
            else // if (attr == DmgAttr.Magic)
            {
                if ((player.MainWeapon != null) && (player.MainWeapon.AmplifyMagicAttack != 0.0f)) result = result * player.MainWeapon.AmplifyMagicAttack;
                if ((player.SubWeapon != null) && (player.SubWeapon.AmplifyMagicAttack != 0.0f)) result = result * player.SubWeapon.AmplifyMagicAttack;
                if ((player.MainArmor != null) && (player.MainArmor.AmplifyMagicAttack != 0.0f)) result = result * player.MainArmor.AmplifyMagicAttack;
                if ((player.Accessory != null) && (player.Accessory.AmplifyMagicAttack != 0.0f)) result = result * player.Accessory.AmplifyMagicAttack;
                if ((player.Accessory2 != null) && (player.Accessory2.AmplifyMagicAttack != 0.0f)) result = result * player.Accessory2.AmplifyMagicAttack;
                if ((player.Accessory3 != null) && (player.Accessory3.AmplifyMagicAttack != 0.0f)) result = result * player.Accessory3.AmplifyMagicAttack;
            }

            if (attr == DmgAttr.Physical)
            {
                if (player.CurrentPhysicalChargeCount > 0)
                {
                    result = result * (double)(1.0F + player.CurrentPhysicalChargeCount);
                }

                if (player.AmplifyPhysicalAttack > 0.0f)
                {
                    result = result * player.AmplifyPhysicalAttack;
                }
            }
            else // if (attr == DmgAttr.Magic)
            {
                if (!ignoreChargeCount && (player.CurrentChargeCount > 0))
                {
                    //result = result * (double)(1.0F + player.CurrentChargeCount + player.CurrentSoulAttributes[(int)TruthActionCommand.SoulStyle.Oracle_Commander] * TruthActionCommand.OracleCommanderValue);
                    result = result * (double)(1.0F + player.CurrentChargeCount);
                }
                if (player.AmplifyMagicAttack > 0.0f) // 「警告」魔法攻撃増強で回復も増強するのか？
                {
                    result = result * player.AmplifyMagicAttack;
                }
            }

            if (player.CurrentSyutyu_Danzetsu > 0)
            {
                result = result * PrimaryLogic.SyutyuDanzetsuValue(player);
            }
            if (player.CurrentOnslaughtHit > 0)
            {
                result = result * (1.00f - 0.15f * player.CurrentOnslaughtHitValue);
            }

            // ＋ーバッファは潜在係数や増幅係数を考慮せず、単純増加とする。
            if (attr == DmgAttr.Physical)
            {
                result += player.CurrentPhysicalAttackUpValue;
                result -= player.CurrentPhysicalAttackDownValue;
            }
            else // if (attr == DmgAttr.Magic)
            {
                result += player.CurrentMagicAttackUpValue;
                result -= player.CurrentMagicAttackDownValue;
            }

            if (result <= 0) result = 0;
            return result;
        }

        /// <summary>
        /// 物理防御力
        /// </summary>
        public static double PhysicalDefense(Unit player)
        {
            return DefenseValue(player, NeedType.Min, DmgAttr.Physical, 0.5F, 0.0F, 0.0F, 0.0F, SpellSkillType.Standard, false);
        }
        public static double PhysicalDefense(Unit player, NeedType type, double pStr, double pAgl, double pInt, double pMind)
        {
            return DefenseValue(player, type, DmgAttr.Physical, pStr, pAgl, pInt, pMind, SpellSkillType.Standard, false);
        }

        /// <summary>
        /// 魔法防御力
        /// </summary>
        public static double MagicDefense(Unit player)
        {
            return DefenseValue(player, NeedType.Min, DmgAttr.Magic, 0.0F, 0.0F, 0.5F, 0.0F, SpellSkillType.Standard, false);
        }
        public static double MagicDefense(Unit player, NeedType type, double pStr, double pAgl, double pInt, double pMind)
        {
            return DefenseValue(player, type, DmgAttr.Magic, pStr, pAgl, pInt, pMind, SpellSkillType.Standard, false);
        }
        public static double DefenseValue(Unit player, NeedType type, DmgAttr attr, double pStr, double pAgl, double pInt, double pMind, SpellSkillType spellSkill, bool ignoreChargeCount)
        {
            double min = 0;
            double max = 0;
            double factor = 0.0f;

            // パラメタによるベース値は「力」「技」「知」の組み合わせとする。
            factor = player.TotalStrength * pStr + player.TotalAgility * pAgl + player.TotalIntelligence * pInt;

            // 心係数で値を増幅する。
            min = factor * Math.Log(Convert.ToInt32(player.TotalMind), Math.Exp(1)) / 2.00;
            max = factor * Math.Log(Convert.ToInt32(player.TotalMind), Math.Exp(1)) / 2.00;

            if (attr == DmgAttr.Physical)
            {
                // 武器による加算値（メイン）
                if (player.MainWeapon != null)
                {
                    min += player.MainWeapon.PhysicalDefenseMinValue;
                    max += player.MainWeapon.PhysicalDefenseMaxValue;
                }
                // 武器による加算値（サブ）
                if (player.SubWeapon != null)
                {
                    min += player.SubWeapon.PhysicalDefenseMinValue;
                    max += player.SubWeapon.PhysicalDefenseMaxValue;
                }
                // 防具による加算値
                if (player.MainArmor != null)
                {
                    min += player.MainArmor.PhysicalDefenseMinValue;
                    max += player.MainArmor.PhysicalDefenseMaxValue;
                }
                // アクセサリによる加算値
                if (player.Accessory != null)
                {
                    min += player.Accessory.PhysicalDefenseMinValue;
                    max += player.Accessory.PhysicalDefenseMaxValue;
                }
                if (player.Accessory2 != null)
                {
                    min += player.Accessory2.PhysicalDefenseMinValue;
                    max += player.Accessory2.PhysicalDefenseMaxValue;
                }
                if (player.Accessory3 != null)
                {
                    min += player.Accessory3.PhysicalDefenseMinValue;
                    max += player.Accessory3.PhysicalDefenseMaxValue;
                }
            }
            else // if (attr == DmgAttr.Magic)
            {
                // 武器による加算値（メイン）
                if (player.MainWeapon != null)
                {
                    min += player.MainWeapon.MagicDefenseMinValue;
                    max += player.MainWeapon.MagicDefenseMaxValue;
                }
                // 武器による加算値（サブ）
                if (player.SubWeapon != null)
                {
                    min += player.SubWeapon.MagicDefenseMinValue;
                    max += player.SubWeapon.MagicDefenseMaxValue;
                }
                // 防具による加算値
                if (player.MainArmor != null)
                {
                    min += player.MainArmor.MagicDefenseMinValue;
                    max += player.MainArmor.MagicDefenseMaxValue;
                }
                // アクセサリによる加算値
                if (player.Accessory != null)
                {
                    min += player.Accessory.MagicDefenseMinValue;
                    max += player.Accessory.MagicDefenseMaxValue;
                }
                if (player.Accessory2 != null)
                {
                    min += player.Accessory2.MagicDefenseMinValue;
                    max += player.Accessory2.MagicDefenseMaxValue;
                }
                if (player.Accessory3 != null)
                {
                    min += player.Accessory3.MagicDefenseMinValue;
                    max += player.Accessory3.MagicDefenseMaxValue;
                }
            }

            double result = CoreDamage(player, type, min, max);

            if (attr == DmgAttr.Physical)
            {
                // 武器、防具、アクセサリからの増強
                if ((player.MainWeapon != null) && (player.MainWeapon.AmplifyPhysicalDefense != 0.0f)) result = result * player.MainWeapon.AmplifyPhysicalDefense;
                if ((player.SubWeapon != null) && (player.SubWeapon.AmplifyPhysicalDefense != 0.0f)) result = result * player.SubWeapon.AmplifyPhysicalDefense;
                if ((player.MainArmor != null) && (player.MainArmor.AmplifyPhysicalDefense != 0.0f)) result = result * player.MainArmor.AmplifyPhysicalDefense;
                if ((player.Accessory != null) && (player.Accessory.AmplifyPhysicalDefense != 0.0f)) result = result * player.Accessory.AmplifyPhysicalDefense;
                if ((player.Accessory2 != null) && (player.Accessory2.AmplifyPhysicalDefense != 0.0f)) result = result * player.Accessory2.AmplifyPhysicalDefense;
                if ((player.Accessory3 != null) && (player.Accessory3.AmplifyPhysicalDefense != 0.0f)) result = result * player.Accessory3.AmplifyPhysicalDefense;

                // Mystic_EnhancerはBUFFによる上昇のみを対象とする。（自分自身の防御減少の対象にはならない）
                if (player.CurrentBlindJustice > 0)
                {
                    result = result * 0.70f;
                }
                if (player.CurrentImmolate > 0)
                {
                    result = result * 0.80f;
                }
                if (player.CurrentDarkenField > 0)
                {
                    result = result * 0.80f;
                }
                if (player.CurrentConcussiveHit > 0)
                {
                    result = result * (1.00f - 0.15f * player.CurrentConcussiveHitValue);
                }

                if (player.AmplifyPhysicalDefense > 0.0f)
                {
                    result = result * player.AmplifyPhysicalDefense;
                }

                // ＋ーバッファは潜在係数や増幅係数を考慮せず、単純増加とする。
                result += player.CurrentPhysicalDefenseUpValue;
                result -= player.CurrentPhysicalDefenseDownValue;
            }
            else // if (attr == DmgAttr.Magic)
            {
                // 武器、防具、アクセサリからの増強
                if ((player.MainWeapon != null) && (player.MainWeapon.AmplifyMagicDefense != 0.0f)) result = result * player.MainWeapon.AmplifyMagicDefense;
                if ((player.SubWeapon != null) && (player.SubWeapon.AmplifyMagicDefense != 0.0f)) result = result * player.SubWeapon.AmplifyMagicDefense;
                if ((player.MainArmor != null) && (player.MainArmor.AmplifyMagicDefense != 0.0f)) result = result * player.MainArmor.AmplifyMagicDefense;
                if ((player.Accessory != null) && (player.Accessory.AmplifyMagicDefense != 0.0f)) result = result * player.Accessory.AmplifyMagicDefense;
                if ((player.Accessory2 != null) && (player.Accessory2.AmplifyMagicDefense != 0.0f)) result = result * player.Accessory2.AmplifyMagicDefense;
                if ((player.Accessory3 != null) && (player.Accessory3.AmplifyMagicDefense != 0.0f)) result = result * player.Accessory3.AmplifyMagicDefense;

                // Mystic_EnhancerはBUFFによる上昇のみを対象とする。（自分自身の防御減少の対象にはならない）
                if (player.CurrentDarkenField > 0)
                {
                    result = result * 0.80f;
                }
                if (player.CurrentBlackFire > 0)
                {
                    result = result * 0.80f;
                }
                if (player.CurrentPsychicTrance > 0)
                {
                    result = result * 0.70f;
                }
                if (player.CurrentConcussiveHit > 0)
                {
                    result = result * (1.00f - 0.15f * player.CurrentConcussiveHitValue);
                }

                if (player.AmplifyMagicDefense > 0.0f)
                {
                    result = result * player.AmplifyMagicDefense;
                }

                if (player.CurrentSkyShield > 0)
                {
                    result = result + player.CurrentSkyShieldValue;
                }

                // ＋ーバッファは潜在係数や増幅係数を考慮せず、単純増加とする。
                result += player.CurrentMagicDefenseUpValue;
                result -= player.CurrentMagicDefenseDownValue;
            }

            if (result <= 0) result = 0;

            return result;
        }

        /// <summary>
        /// 総合的な速度を取得します。
        /// </summary>
        public static double BattleSpeedValue(Unit player)
        {
            // 最大速度が速すぎるため以下のように調整。
            // 最小3.000 ~ 最大5.828となるようにする。
            // result = 3.00 + LN(agl) * LN(mind) / 30.0
            double result = 1 + player.TotalAgility * Math.Log(Convert.ToInt32(player.TotalMind), Math.Exp(1)) / 2.00;

            //double result = 3.00 + Math.Log(Convert.ToInt32(player.TotalAgility), Math.Exp(1)) * Math.Log(Convert.ToInt32(player.TotalMind), Math.Exp(1));

            // 武器、防具、アクセサリからの増強
            if ((player.MainWeapon != null) && (player.MainWeapon.AmplifyBattleSpeed != 0.0f)) result = result * player.MainWeapon.AmplifyBattleSpeed;
            if ((player.SubWeapon != null) && (player.SubWeapon.AmplifyBattleSpeed != 0.0f)) result = result * player.SubWeapon.AmplifyBattleSpeed;
            if ((player.MainArmor != null) && (player.MainArmor.AmplifyBattleSpeed != 0.0f)) result = result * player.MainArmor.AmplifyBattleSpeed;
            if ((player.Accessory != null) && (player.Accessory.AmplifyBattleSpeed != 0.0f)) result = result * player.Accessory.AmplifyBattleSpeed;
            if ((player.Accessory2 != null) && (player.Accessory2.AmplifyBattleSpeed != 0.0f)) result = result * player.Accessory2.AmplifyBattleSpeed;

            if (player.CurrentImpulseHit > 0)
            {
                result = result * (1.00f - 0.15f * player.CurrentImpulseHitValue);
            }

            if (player.AmplifyBattleSpeed > 0.0f)
            {
                result = result * player.AmplifyBattleSpeed;
            }

            // ＋ーバッファは潜在係数や増幅係数を考慮せず、単純増加とする。
            result += player.CurrentSpeedUpValue;
            result -= player.CurrentSpeedDownValue;

            if (result <= 0) result = 0;

            //result += 1.0f; // 万が一０の場合進まなくなるため、1.0を追加
            if (result < 1.0f) { result = 1.0f; } // 万が一、1よりも小さい場合、進みが遅すぎるため、1.0を追加

            if (player.CurrentSwiftStep > 0)
            {
                result = result * 1.2f;
            }
            if (player.CurrentColorlessMove > 0)
            {
                result = 0;
            }
            return result;
        }

        /// <summary>
        /// 戦闘反応値の算出
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public static double BattleResponseValue(Unit player)
        {
            // 最大速度が速すぎるため以下のように調整。
            // 最小1.000 ~ 最大22.207となるようにする。
            // result = 1.00 + LN(agl) * LN(mind) / 4.0
            double result = 1.00f + Math.Log(Convert.ToInt32(player.TotalAgility), Math.Exp(1)) * Math.Log(Convert.ToInt32(player.TotalMind), Math.Exp(1)) / 4.0f;

            // 武器、防具、アクセサリからの増強
            if ((player.MainWeapon != null) && (player.MainWeapon.AmplifyBattleResponse != 0.0f)) result = result * player.MainWeapon.AmplifyBattleResponse;
            if ((player.SubWeapon != null) && (player.SubWeapon.AmplifyBattleResponse != 0.0f)) result = result * player.SubWeapon.AmplifyBattleResponse;
            if ((player.MainArmor != null) && (player.MainArmor.AmplifyBattleResponse != 0.0f)) result = result * player.MainArmor.AmplifyBattleResponse;
            if ((player.Accessory != null) && (player.Accessory.AmplifyBattleResponse != 0.0f)) result = result * player.Accessory.AmplifyBattleResponse;
            if ((player.Accessory2 != null) && (player.Accessory2.AmplifyBattleResponse != 0.0f)) result = result * player.Accessory2.AmplifyBattleResponse;

            if (player.CurrentPhantasmalWind > 0)
            {
                result = result * 1.2f;
            }
            if (player.CurrentVigorSense > 0)
            {
                result = result * 1.4f;
            }
            if (player.CurrentColorlessMove > 0)
            {
                result = result * 2.0f;
            }
            if (player.CurrentWordOfMalice > 0)
            {
                result = result * 0.7f;
            }

            if (player.CurrentImpulseHit > 0)
            {
                result = result * (1.00f - 0.15f * player.CurrentImpulseHitValue);
            }

            if (player.AmplifyBattleResponse > 0.0f)
            {
                result = result * player.AmplifyBattleResponse;
            }
            
            // ＋ーバッファは潜在係数や増幅係数を考慮せず、単純増加とする。
            result += player.CurrentReactionUpValue;
            result -= player.CurrentReactionDownValue;

            if (result <= 0) result = 0;
            return result;
        }

        /// <summary>
        /// 潜在能力値の算出
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public static double PotentialValue(Unit player)
        {
            // 最大値が大きすぎるため以下の様に調整
            // 最小が1.00、最大が4.00となるようにする。
            double result = (double)(player.TotalMind);

            // 心      [ 1 - 100 ] -->   1.0 + 心 /  100 * 0.5
            //      [ 101 - 1000 ] -->   1.5 + 心 / 1000 * 1.0
            //    [ 1001 - 10000 ] -->   2.5 + 心 / 9999 * 1.5
            if (0 <= player.TotalMind && player.TotalMind <= 100)
            {
                result = 1.0F + result / 100.0F * 0.5F;
            }
            else if (101 <= player.TotalMind && player.TotalMind <= 1000)
            {
                result = 1.5F + (result - 100) / 900.0F * 1.0F;
            }
            else if (1001 <= player.TotalMind && player.TotalMind <= 9999)
            {
                result = 2.5F + (result - 1000) / 9000.0F * 1.5F;
            }

            // 武器、防具、アクセサリからの増強
            if ((player.MainWeapon != null) && (player.MainWeapon.AmplifyPotential != 0.0f)) result = result * player.MainWeapon.AmplifyPotential;
            if ((player.SubWeapon != null) && (player.SubWeapon.AmplifyPotential != 0.0f)) result = result * player.SubWeapon.AmplifyPotential;
            if ((player.MainArmor != null) && (player.MainArmor.AmplifyPotential != 0.0f)) result = result * player.MainArmor.AmplifyPotential;
            if ((player.Accessory != null) && (player.Accessory.AmplifyPotential != 0.0f)) result = result * player.Accessory.AmplifyPotential;
            if ((player.Accessory2 != null) && (player.Accessory2.AmplifyPotential != 0.0f)) result = result * player.Accessory2.AmplifyPotential;

            if (player.CurrentParadoxImage > 0)
            {
                result = result * 1.2f;
            }

            if (player.AmplifyPotential > 0.0f)
            {
                result = result * player.AmplifyPotential;
            }
            
            // ＋ーバッファは潜在係数や増幅係数を考慮せず、単純増加とする。
            result += player.CurrentPotentialUpValue;
            result -= player.CurrentPotentialDownValue;

            if (result <= 0) result = 0;
            return result;
        }

        /// <summary>
        /// クリティカル発動率の算出（前編ではパラメタＭＡＸが１００前後、後編では９９９９ＭＡＸを意識した値に調整）
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public static bool CriticalDetect(Unit player)
        {
            double max = 0;

            // 技      [ 1 - 100 ] -->   0 + 技 / 10
            //      [ 101 - 1000 ] -->  10 + 技 / 45
            //    [ 1001 - 10000 ] -->  30 + 技 / 450
            if (0 <= player.TotalAgility && player.TotalAgility <= 100)
            {
                max = 0.0F + (double)player.TotalAgility / 10.0F;
            }
            else if (101 <= player.TotalAgility && player.TotalAgility <= 1000)
            {
                max = 10.0F + (double)(player.TotalAgility - 100.0F) / 45.0F;
            }
            else if (1001 <= player.TotalAgility && player.TotalAgility <= 9999)
            {
                max = 40.0F + (double)(player.TotalAgility - 1000.0F) / 450.0F;
            }

            System.Random rd = new System.Random(DateTime.Now.Millisecond);
            int result = AP.Math.RandomInteger(100);
            if (player.CurrentFortuneSpirit > 0)
            {
                result = 0;
            }
            if (result < max)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static double CriticalDamageValue(Unit player)
        {
            return 2.0F;
        }
        public static double NormalAttackValue(Unit player)
        {
            // 力x100
            return PhysicalAttack(player, NeedType.Random, 1.0F, 0.0F, 0.0F, 0.0F);
        }
        public static double MagicAttackValue(Unit player)
        {
            // 知x100
            return MagicAttack(player, NeedType.Random, 0.0F, 0.0F, 1.0F, 0.0F);
        }

        public static double StraightSmashValue(Unit player)
        {
            // 力x250
            return PhysicalAttack(player, NeedType.Random, 2.5F, 0.0F, 0.0F, 0.0F);
        }

        public static double ShieldBashValue(Unit player)
        {
            // 力x100
            return PhysicalAttack(player, NeedType.Random, 1.0F, 0.0F, 0.0F, 0.0F);
        }

        public static double HunterShotValue(Unit player)
        {
            // 技x150
            return PhysicalAttack(player, NeedType.Random, 0.0F, 1.5F, 0.0F, 0.0F);
        }
        public static double VenomSlashValue(Unit player)
        {
            // 技x100
            return PhysicalAttack(player, NeedType.Random, 0.0F, 1.0F, 0.0F, 0.0F);
        }
        public static double HeartOfLifeValue(Unit player)
        {
            // 心x120
            return player.TotalMind * 1.20F;
        }
        public static double OracleCommandValue(Unit player)
        {
            // --
            return 1.0F;
        }
        public static double FreshHealValue(Unit player)
        {
            // 知x300
            return MagicAttack(player, NeedType.Random, 0.0F, 0.0F, 3.0F, 0.0F);
        }
        public static double ShadowBlastValue(Unit player)
        {
            // 知x150
            return MagicAttack(player, NeedType.Random, 0.0F, 0.0F, 1.5F, 0.0F);
        }
        public static double FireBoltValue(Unit player)
        {
            // 知x300
            return 9;// MagicAttack(player, NeedType.Random, 0.0F, 0.0F, 3.0F, 0.0F);
        }
        public static double IceNeedleValue(Unit player)
        {
            // 知x250
            return MagicAttack(player, NeedType.Random, 0.0F, 0.0F, 2.5F, 0.0F);
        }
        public static double AuraOfPowerValue(Unit player)
        {
            // BUFF ＋３
            return 3.0F;
        }
        public static double SkyShieldValue(Unit player)
        {
            // BUFF ＋３
            return 3.0F;
        }
        public static double StanceOfBladeValue(Unit player)
        {
            // BUFF ＋３
            return 3.0F;
        }
        public static double StanceOfGuardValue(Unit player)
        {
            // BUFF ＋３
            return 3.0F;
        }

        public static double MultipleShotValue(Unit player)
        {
            // 技x120
            return PhysicalAttack(player, NeedType.Random, 0.0F, 1.20F, 0.0F, 0.0F);
        }

        public static double InvisibleBindValue(Unit player)
        {
            // なし
            return 0;
        }

        public static double FortuneSpiritValue(Unit player)
        {
            // 幸運100%
            return 100.0F;
        }

        public static double ZeroImmunityValue(Unit player)
        {
            // なし
            return 0;
        }

        public static double DivineCircleValue(Unit player)
        {
            // 知x120
            return player.TotalIntelligence * 1.20F;
        }
        public static double BloodSignValue(Unit player)
        {
            // 知x50
            return player.TotalIntelligence * 0.50F;
        }
        public static double FlameBladeValue(Unit player)
        {
            // 知x150
            return MagicAttack(player, NeedType.Random, 0.0F, 0.0F, 1.5F, 0.0F);
        }
        public static double StormArmorValue(Unit player)
        {
            // BUFF +３
            return 3.0F;
        }
        public static double DoubleSlashValue(Unit player)
        {
            // 力x120
            return PhysicalAttack(player, NeedType.Random, 1.2F, 0.0F, 0.0F, 0.0F);
        }

        public static double SyutyuDanzetsuValue(Unit player)
        {
            return 0;
        }

    }
}
