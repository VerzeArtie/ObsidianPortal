using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

namespace ObsidianPortal
{
    public partial class BattleField : MotherForm
    {
        private void ExecHeal(Unit player, Unit target, int value)
        {
            target.CurrentLife += value;
            if (player.IsAlly)
            {
                ONE.BattleHealingDone += value;
            }
            UpdateLife(target, UnitLifeText, UnitLifeMeter);
        }
        private void ExecDamage(Unit player, Unit target, int value)
        {
            if (value < 0) { value = 0; }
            target.CurrentLife -= value;
            if (player.IsAlly)
            {
                ONE.BattleDamageDone += value;
            }
            UpdateLife(target, UnitLifeText, UnitLifeMeter);
        }

        private void GetTacticsPoint(Unit player)
        {
            if (player.IsAlly)
            {
                ONE.BattleTacticsPoint++;
            }
        }

        private void ExecDash(Unit player, Unit target)
        {
            // todo dashの能力をこちらに書く。
            //ExecDamage(player, target, ActionCommand.EffectValue(FIX.DASH) + target.CurrentReachabletargetValue - target.DefenseValue);
        }

        private void ExecFireBlade(Unit player)
        {
            player.CurrentFireBlade = ActionCommand.IsBuffTurn(FIX.FIREBLADE);
            player.CurrentFireBladeValue = ActionCommand.EffectValue(FIX.FIREBLADE);
        }

        private void ExecHolyBullet(Unit player)
        {
            FIX.Direction[] direction = { FIX.Direction.Top, FIX.Direction.Left, FIX.Direction.Right, FIX.Direction.Bottom };
            for (int ii = 0; ii < direction.Length; ii++)
            {
                Unit target = ExistUnitFromLocation(player.GetNeighborhood(direction[ii]));
                if (target != null)
                {
                    Debug.Log("detect holy target");
                    //ExecDamage(player, target, ActionCommand.EffectValue(FIX.HOLYBULLET) + target.CurrentReachabletargetValue - target.DefenseValue);
                }
                else
                {
                    Debug.Log("holy target null...");
                }
            }
        }

        private void ExecProtection(Unit player, Unit target)
        {
            target.CurrentProtection = ActionCommand.IsBuffTurn(FIX.PROTECTION);
            target.CurrentProtectionValue = ActionCommand.EffectValue(FIX.PROTECTION);
        }

        private void ExecNeedleSpear(Unit player, Unit target)
        {
            //ExecDamage(player, target, ActionCommand.EffectValue(FIX.NEEDLESPEAR) + target.CurrentReachabletargetValue - target.DefenseValue);

            int dummy = 0;
            FIX.Direction direction = ExistAttackableUnitLinerGroup(ref dummy, player, target, player.EffectRange);
            target.Move(direction); // 敵を一歩後退させる。
        }

        private void ExecSilverArrow(Unit player, Unit target)
        {
            //ExecDamage(player, target, ActionCommand.EffectValue(FIX.SILVERARROW) + target.CurrentReachabletargetValue - target.DefenseValue);
            target.CurrentSilverArrow = ActionCommand.IsBuffTurn(FIX.SILVERARROW);
            target.CurrentSilverArrowValue = ActionCommand.EffectValue(FIX.SILVERARROW);
        }

        private void ExecEarthBind(Unit player, Unit target)
        {
            target.CurrentEarthBind = ActionCommand.IsBuffTurn(FIX.EARTHBIND);
            target.CurrentEarthBindValue = ActionCommand.EffectValue(FIX.EARTHBIND);
        }

        private void ExecPowerWord(Unit player, Unit target)
        {
            target.CurrentPowerWord = ActionCommand.IsBuffTurn(FIX.POWERWORD);
            target.CurrentPowerWordValue = ActionCommand.EffectValue(FIX.POWERWORD);
        }

        private void ExecHeatBoost(Unit player, Unit target)
        {
            target.CurrentTime -= ActionCommand.EffectValue(FIX.HEATBOOST);
            AdjustTime(target);
        }

        private void ExecHealingWord(Unit player, Unit target)
        {
            ExecHeal(player, target, ActionCommand.EffectValue(FIX.HEALINGWORD));
            target.CurrentHealingWord = ActionCommand.IsBuffTurn(FIX.HEALINGWORD);
            target.CurrentHealingWordValue = ActionCommand.EffectValue(FIX.HEALINGWORD);
        }

        private void ExecLavaWall(Unit player, FIX.Direction direction)
        {
        //    List<Vector3> list = new List<Vector3>();
        //    list.Add(player.GetNeighborhood(direction));
        //    if (direction == FIX.Direction.Top)
        //    {
        //        list.Add(player.GetNeighborhood(FIX.Direction.Left));
        //        list.Add(player.GetNeighborhood(FIX.Direction.Right));
        //    }
        //    else if (direction == FIX.Direction.Left)
        //    {
        //        list.Add(player.GetNeighborhood(FIX.Direction.Top));
        //        list.Add(player.GetNeighborhood(FIX.Direction.Bottom));
        //    }
        //    else if (direction == FIX.Direction.Right)
        //    {
        //        list.Add(player.GetNeighborhood(FIX.Direction.Top));
        //        list.Add(player.GetNeighborhood(FIX.Direction.Bottom));
        //    }
        //    else if (direction == FIX.Direction.Bottom)
        //    {
        //        list.Add(player.GetNeighborhood(FIX.Direction.Left));
        //        list.Add(player.GetNeighborhood(FIX.Direction.Right));
        //    }

        //    for (int ii = 0; ii < list.Count; ii++)
        //    {
        //        if (ExistUnitFromLocation(list[ii]) == null &&
        //            ExistAreaFromLocation(list[ii]) != null)
        //        {
        //            SetupUnit(ref this.AllList, 999, false, Unit.RaceType.Fire, Unit.UnitType.Wall, list[ii].x, list[ii].z, false);
        //        }
        //    }
        }

        private void ExecBlaze(Unit player, FIX.Direction direction)
        {
            for (int ii = 0; ii < player.EffectRange; ii++)
            {
                float x = 0;
                float y = 0;
                if (direction == FIX.Direction.Top) { x = -FIX.HEX_MOVE_X * (ii + 1); y = 0; }
                else if (direction == FIX.Direction.Right) { x = -FIX.HEX_MOVE_X * (ii + 1); y = FIX.HEX_MOVE_Z * (ii + 1); }
                else if (direction == FIX.Direction.Left) { x = -FIX.HEX_MOVE_X * (ii + 1); y = -FIX.HEX_MOVE_Z * (ii + 1); }
                else if (direction == FIX.Direction.Bottom) { x = FIX.HEX_MOVE_X * (ii + 1); y = 0; }
                Unit target = ExistUnitFromLocation(new Vector3(player.transform.position.x + x,
                                                                 player.transform.position.y + y,
                                                                 player.transform.position.z));
                if (target != null)
                {
                    Debug.Log("Blaze detect: " + target.transform.localPosition.ToString());
                    //int value = ActionCommand.EffectValue(FIX.BLAZE) + target.CurrentReachabletargetValue - target.DefenseValue;
                    //ExecDamage(player, target, value);
                }
            }
        }

        private void ExecExplosion(Unit player, Unit target)
        {
            //int value = ActionCommand.EffectValue(FIX.EXPLOSION) + target.CurrentReachabletargetValue - target.DefenseValue;
            //ExecDamage(player, target, value);
        }

        private void PlayerNormalAttack(Unit player, Unit target, double damage, string soundName)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S)");
            double result = 0;
            string message = string.Empty;

            // 増加要因
            if (damage == 0.0F)
            {
                result = PrimaryLogic.PhysicalAttack(player, PrimaryLogic.NeedType.Random, 1.0f, 0.0f, 0.0f, 0.0f);
            }
            else
            {
                result = damage;
            }
            if (player.CurrentStanceOfBlade > 0)
            {
                result = result * player.CurrentStanceOfBladeValue;
            }
            if (player.CurrentAuraOfPower > 0)
            {
                result = result * player.CurrentAuraOfPowerValue;
            }

            // クリティカル判定
            if (PrimaryLogic.CriticalDetect(player))
            {
                result = result * PrimaryLogic.CriticalDamageValue(player);
                message += FIX.LABEL_CRITICAL;
                player.CurrentFortuneSpirit = 0;
                player.CurrentFortuneSpiritValue = 0;
            }

            if (target.CurrentReachableTarget > 0)
            {
                result += target.CurrentReachabletargetValue;
            }

            // 減少要因
            double defense = PrimaryLogic.PhysicalDefense(target, PrimaryLogic.NeedType.Random, 0.2F, 0.0F, 0.0F, 0.0F);
            if (target.CurrentDivineCircle > 0)
            {
                defense = defense * target.CurrentDivineCircleValue;
            }
            if (target.CurrentStanceOfGuard > 0)
            {
                defense = defense * target.CurrentStanceOfGuardValue;
            }
            result -= defense;

            // ０制限（負の値なし）
            if (result <= 0.0f) { result = 0.0f; }

            ExecDamage(player, target, (int)result);

            Instantiate(fx_prefabs[19], new Vector3(target.transform.localPosition.x, target.transform.localPosition.y, target.transform.localPosition.z - 1), Quaternion.identity);
            message += "\r\n" + ((int)result).ToString();
            StartAnimation(target, message, FIX.COLOR_DAMAGE);

            if (player.CurrentFlameBlade > 0)
            {
                int flameDamage = (int)(PrimaryLogic.FlameBladeValue(player));
                ExecDamage(player, target, flameDamage);
                StartAnimation(target, flameDamage.ToString(), FIX.COLOR_DAMAGE);
            }
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(E)");
        }

        private void PlayerMagicAttack(Unit player, Unit target, double damage, string soundName)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S)");
            double result = 0;
            string message = string.Empty;

            // 増加要因
            if (damage == 0.0F)
            {
                result = PrimaryLogic.MagicAttack(player, PrimaryLogic.NeedType.Random, 0.0f, 0.0f, 1.0f, 0.0f);
            }
            else
            {
                result = damage;
            }

            // クリティカル判定
            if (PrimaryLogic.CriticalDetect(player))
            {
                result = result * PrimaryLogic.CriticalDamageValue(player);
                message += FIX.LABEL_CRITICAL;
                player.CurrentFortuneSpirit = 0;
                player.CurrentFortuneSpiritValue = 0;
            }

            if (target.CurrentReachableTarget > 0)
            {
                result += target.CurrentReachabletargetValue;
            }

            // 減少要因
            double defense = PrimaryLogic.MagicDefense(target, PrimaryLogic.NeedType.Random, 0.0F, 0.0F, 0.2F, 0.0F);
            if (target.CurrentStormArmor > 0)
            {
                defense = defense + target.CurrentStormArmorValue;
            }
            result -= defense;

            // ０制限（負の値なし）
            if (result <= 0.0f) { result = 0.0f; }

            ExecDamage(player, target, (int)result);
            Instantiate(fx_prefabs[19], new Vector3(target.transform.localPosition.x, target.transform.localPosition.y, target.transform.localPosition.z - 1), Quaternion.identity);
            Debug.Log(MethodBase.GetCurrentMethod().Name + ": " + ((int)result).ToString());
            message += "\r\n" + ((int)result).ToString();
            StartAnimation(target, message, new Color(1.0f, 0.3f, 0.3f));
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(E)");
        }

        // Basic Command
        private void ExecNormalAttack(Unit player, Unit target)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S)");
            double damage = PrimaryLogic.NormalAttackValue(player);
            PlayerNormalAttack(player, target, damage, FIX.SOUND_NORMAL_ATTACK);
            Debug.Log("ExecNormalAttack(E)");
        }
        private void ExecMagicAttack(Unit player, Unit target)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S)");
            double damage = PrimaryLogic.MagicAttackValue(player);
            PlayerMagicAttack(player, target, damage, FIX.SOUND_MAGIC_ATTACK);
            Debug.Log("ExecMagicAttack(E)");
        }
        private void ExecDefense(Unit player)
        {
        }

        // Delve I
        private void ExecStraightSmash(Unit player, Unit target)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S)");
            double damage = PrimaryLogic.StraightSmashValue(player);
            PlayerNormalAttack(player, target, damage, FIX.SOUND_STRAIGHT_SMASH);
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(E)");
        }

        private void ExecShieldBash(Unit player, Unit target)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S)");
            double damage = PrimaryLogic.ShieldBashValue(player);
            PlayerNormalAttack(player, target, damage, FIX.SOUND_SHIELD_BASH);
            PushUnit(player, target);
            NowSilence(player, target);
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(E)");
        }

        private void ExecHunterShot(Unit player, Unit target)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S)");
            double damage = PrimaryLogic.HunterShotValue(player);
            PlayerNormalAttack(player, target, damage, FIX.SOUND_HUNTER_SHOT);
            NowBind(player, target);
            Instantiate(fx_prefabs[19], new Vector3(target.transform.localPosition.x, target.transform.localPosition.y, target.transform.localPosition.z - 1), Quaternion.identity);
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(E)");
        }

        private void ExecVenomSlash(Unit player, Unit target)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S)");
            double damage = PrimaryLogic.VenomSlashValue(player);
            PlayerNormalAttack(player, target, damage, FIX.SOUND_VENOM_SLASH);
            NowPoison(player, target);
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(E)");
        }

        private void ExecHeartOfTheLife(Unit player, Unit target)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S)");
            PlayerBuffAbstract(player, target, FIX.HEART_OF_THE_LIFE);
            StartAnimation(target, FIX.HEART_OF_THE_LIFE, Color.green);
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(E)");
        }

        private void ExecOracleCommand(Unit player, Unit target)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S)");
            target.CurrentAP += (int)(PrimaryLogic.OracleCommandValue(player));
            StartAnimation(target, "AP+1", FIX.COLOR_MINDFULNESS);
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(E)");
        }

        private void ExecFreshHeal(Unit player, Unit target)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S)");
            double damage = PrimaryLogic.FreshHealValue(player);
            ExecHeal(player, target, (int)damage);
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(E)");
        }

        private void ExecShadowBlast(Unit player, Unit target)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S)");
            double damage = PrimaryLogic.ShadowBlastValue(player);
            PlayerMagicAttack(player, target, damage, FIX.SOUND_SHADOW_BLAST);
            NowBlind(player, target);
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(E)");
        }

        private void ExecFireBolt(Unit player, Unit target)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S)");
            double damage = PrimaryLogic.FireBoltValue(player);
            PlayerMagicAttack(player, target, damage, FIX.SOUND_FIRE_BOLT);
            GameObject instance = Instantiate(fx_FireRing, new Vector3(target.transform.localPosition.x, target.transform.localPosition.y, target.transform.localPosition.z - 1), Quaternion.identity);
            instance.AddComponent<SelfDestruct>();
            instance.GetComponent<SelfDestruct>().selfdestruct_in = 1;
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(E)");
        }

        private void ExecIceNeedle(Unit player, Unit target)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S)");
            double damage = PrimaryLogic.IceNeedleValue(player);
            PlayerMagicAttack(player, target, damage, FIX.SOUND_ICE_NEEDLE);
            NowSlow(player, target);
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(E)");
        }

        private void ExecAuraOfPower(Unit player, Unit target)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S)");
            PlayerBuffAbstract(player, target, FIX.AURA_OF_POWER);
            StartAnimation(target, "ATK UP", Color.yellow);
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(E)");
        }

        private void ExecSkyShield(Unit player, Unit target)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S)");
            // --
            PlayerBuffAbstract(player, target, FIX.SKY_SHIELD);
            StartAnimation(target, "MDF UP", Color.green);
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(E)");
        }
        // Delve II
        private void ExecStanceOfBlade(Unit player, Unit target)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S)");
            PlayerBuffAbstract(player, target, FIX.STANCE_OF_THE_BLADE);
            StartAnimation(target, FIX.STANCE_OF_THE_BLADE, Color.blue);
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(E)");
        }
        private void ExecStanceOfGuard(Unit player, Unit target)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S)");
            PlayerBuffAbstract(player, target, FIX.STANCE_OF_THE_GUARD);
            StartAnimation(target, FIX.STANCE_OF_THE_GUARD, Color.blue);
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(E)");
        }
        private void ExecMultipleShot(Unit player, List<Unit> target)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S)");
            for (int ii = 0; ii < target.Count; ii++)
            {
                double damage = PrimaryLogic.MultipleShotValue(player);
                PlayerNormalAttack(player, target[ii], damage, FIX.SOUND_HUNTER_SHOT);
            }
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(E)");
        }
        private void ExecInvisibleBind(Unit player, Unit target)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S)");
            PlayerBuffAbstract(player, target, FIX.INVISIBLE_BIND);
            StartAnimation(target, FIX.INVISIBLE_BIND, FIX.COLOR_COMBATTRICK);
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(E)");
        }
        private void ExecFortuneSpirit(Unit player, Unit target)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S)");
            PlayerBuffAbstract(player, target, FIX.FORTUNE_SPIRIT);
            StartAnimation(target, FIX.EFFECT_FORTUNE, Color.yellow);
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(E)");
        }
        private void ExecZeroImmunity(Unit player, Unit target)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S)");
            PlayerBuffAbstract(player, target, FIX.ZERO_IMMUNITY);
            StartAnimation(target, FIX.ZERO_IMMUNITY, FIX.COLOR_MINDFULNESS);
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(E)");
        }
        private void ExecDivineCircle(Unit player, List<Unit> target)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S)");
            for (int ii = 0; ii < target.Count; ii++)
            {
                PlayerBuffAbstract(player, target[ii], FIX.DIVINE_CIRCLE);
                StartAnimation(target[ii], FIX.DIVINE_CIRCLE, Color.yellow);
            }
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(E)");
        }
        private void ExecBloodSign(Unit player, Unit target)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S)");
            PlayerBuffAbstract(player, target, FIX.BLOOD_SIGN);
            StartAnimation(target, FIX.BLOOD_SIGN, Color.red);
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(E)");
        }
        private void ExecFlameBlade(Unit player, Unit target)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S)");
            PlayerBuffAbstract(player, target, FIX.FLAME_BLADE);
            StartAnimation(target, FIX.FLAME_BLADE, FIX.COLOR_FIRE);
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(E)");
        }
        private void ExecPurePurification(Unit player, Unit target)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S)");
            target.CurrentPoison = 0;
            target.CurrentPoisonValue = 0;
            target.imgPoison = null;
            target.CurrentBlind = 0;
            target.CurrentBlindValue = 0;
            target.imgBlind = null;
            target.CurrentBind = 0;
            target.CurrentBindValue = 0;
            target.imgBind = null;
            target.CurrentSilence = 0;
            target.CurrentSilenceValue = 0;
            target.imgSilence = null;
            target.CurrentSeal = 0;
            target.CurrentSealValue = 0;
            target.imgSeal = null;
            target.CurrentSlow = 0;
            target.CurrentSlowValue = 0;
            target.imgSlow = null;
            StartAnimation(target, FIX.PURE_PURIFICATION, FIX.COLOR_ICE);

            Debug.Log(MethodBase.GetCurrentMethod().Name + "(E)");
        }
        private void ExecStormArmor(Unit player, Unit target)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S)");
            PlayerBuffAbstract(player, target, FIX.STORM_ARMOR);
            StartAnimation(target, FIX.STORM_ARMOR, FIX.COLOR_ENHANCE);
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(E)");
        }
        private void ExecDispelMagic(Unit player, Unit target)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S)");
            target.CurrentAuraOfPower = 0;
            target.CurrentAuraOfPowerValue = 0;
            target.imgAuraOfPower = null;
            target.CurrentHeartOfLife = 0;
            target.CurrentHeartOfLifeValue = 0;
            target.imgHeartOfLife = null;
            target.CurrentSkyShield = 0;
            target.CurrentSkyShieldValue = 0;
            target.imgSkyShield = null;
            target.CurrentStanceOfBlade = 0;
            target.CurrentStanceOfBladeValue = 0;
            target.imgStanceOfBlade = null;
            target.CurrentStanceOfGuard = 0;
            target.CurrentStanceOfGuardValue = 0;
            target.imgStanceOfGuard = null;
            target.CurrentFortuneSpirit = 0;
            target.CurrentFortuneSpiritValue = 0;
            target.imgFortuneSpirit = null;
            target.CurrentZeroImmunity = 0;
            target.CurrentZeroImmunityValue = 0;
            target.imgZeroImmunity = null;
            target.CurrentDivineCircle = 0;
            target.CurrentDivineCircleValue = 0;
            target.imgDivineCircle = null;
            target.CurrentFlameBlade = 0;
            target.CurrentFlameBladeValue = 0;
            target.imgFlameBlade = null;
            target.CurrentStormArmor = 0;
            target.CurrentStormArmorValue = 0;
            target.imgStormArmor = null;
            StartAnimation(target, FIX.DISPEL_MAGIC, FIX.COLOR_MIST);
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(E)");
        }
        // Delve III
        private void ExecDoubleSlash(Unit player, Unit target)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S)");
            double damage = PrimaryLogic.DoubleSlashValue(player);
            PlayerNormalAttack(player, target, damage, FIX.SOUND_NORMAL_ATTACK);
            PlayerNormalAttack(player, target, damage, FIX.SOUND_NORMAL_ATTACK);
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(E)");
        }
        private void ExecConcussiveHit(Unit player, Unit target)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S)");
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(E)");
        }
        private void ExecReachableTarget(Unit player, Unit target)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S)");
            target.CurrentReachableTarget = ActionCommand.IsBuffTurn(FIX.REACHABLETARGET);
            target.CurrentReachabletargetValue = ActionCommand.EffectValue(FIX.REACHABLETARGET);
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(E)");
        }
        private void ExecIrregularStep(Unit player, Unit target)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S)");
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(E)");
        }
        private void ExecVoiceOfVigor(Unit player, List<Unit> target)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S)");
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(E)");
        }
        private void ExecSpiritualRest(Unit player, Unit target)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S)");
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(E)");
        }
        private void ExecHolyBreath(Unit player, List<Unit> target)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S)");
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(E)");
        }
        private void ExecDeathScythe(Unit player, Unit target)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S)");
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(E)");
        }
        private void ExecMeteorBullet(Unit player, Unit target)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S)");
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(E)");
        }
        private void ExecBlueBullet(Unit player, Unit target)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S)");
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(E)");
        }
        private void ExecAetherDrive(Unit player, Unit target)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S)");
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(E)");
        }
        private void ExecMuteImpulse(Unit player, Unit target)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S)");
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(E)");
        }
        // Delve IV
        private void ExecWarSwing(Unit player, List<Unit> target)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S)");
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(E)");
        }
        private void ExecDominationField(Unit player, List<Unit> target)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S)");
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(E)");
        }
        private void ExecHawkEye(Unit player, List<Unit> target)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S)");
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(E)");
        }
        private void ExecDissensionRhythm(Unit player, List<Unit> target)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S)");
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(E)");
        }
        private void ExecSigilOfFaith(Unit player, List<Unit> target)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S)");
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(E)");
        }
        private void ExecEssenceOverflow(Unit player, List<Unit> target)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S)");
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(E)");
        }
        private void ExecSanctionField(Unit player, List<Unit> target)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S)");
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(E)");
        }
        private void ExecBlackVoice(Unit player, List<Unit> target)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S)");
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(E)");
        }
        private void ExecFlameStrike(Unit player, List<Unit> target)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S)");
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(E)");
        }
        private void ExecFreezingCube(Unit player, List<Unit> target)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S)");
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(E)");
        }
        private void ExecCircleOfPower(Unit player, List<Unit> target)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S)");
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(E)");
        }
        private void ExecDetachmentFault(Unit player, List<Unit> target)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S)");
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(E)");
        }
        // Delve V
        private void ExecKineticSmash(Unit player, Unit target)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S)");
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(E)");
        }
        private void ExecSafetyField(Unit player, List<Unit> target)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S)");
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(E)");
        }
        private void ExecPiercingArrow(Unit player, List<Unit> target)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S)");
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(E)");
        }
        private void ExecAssassinationHit(Unit player, Unit target)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S)");
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(E)");
        }
        private void ExecCallOfStorm(Unit player, List<Unit> target)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S)");
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(E)");
        }
        private void ExecInnerInspiration(Unit player, Unit target)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S)");
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(E)");
        }
        private void ExecValkyrieBreak(Unit player, Unit target)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S)");
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(E)");
        }
        private void ExecAbyssEye(Unit player, Unit target)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S)");
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(E)");
        }
        private void ExecSigilOfHomura(Unit player, Unit target)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S)");
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(E)");
        }
        private void ExecFrostLance(Unit player, Unit target)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S)");
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(E)");
        }
        private void ExecRuneStrike(Unit player, Unit target)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S)");
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(E)");
        }
        private void ExecPhantomOboro(Unit player, Unit target)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S)");
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(E)");
        }
        // Delve VI
        private void ExecStanceOfIai(Unit player, Unit target)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S)");
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(E)");
        }
        private void ExecOathOfAegis(Unit player, List<Unit> target)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S)");
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(E)");
        }
        private void ExecWindRunner(Unit player, Unit target)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S)");
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(E)");
        }
        private void ExecKillerGaze(Unit player, List<Unit> target)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S)");
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(E)");
        }
        private void ExecSoulShout(Unit player, List<Unit> target)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S)");
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(E)");
        }
        private void ExecEverflowMind(Unit player, List<Unit> target)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S)");
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(E)");
        }
        private void ExecShiningHeal(Unit player, Unit target)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S)");
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(E)");
        }
        private void ExecDarkIntensity(Unit player, Unit target)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S)");
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(E)");
        }
        private void ExecPiercingFlame(Unit player, Unit target)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S)");
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(E)");
        }
        private void ExecWaterSplash(Unit player, List<Unit> target)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S)");
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(E)");
        }
        private void ExecWordOfRevolution(Unit player, Unit target)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S)");
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(E)");
        }
        private void ExecTranquility(Unit player, List<Unit> target)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S)");
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(E)");
        }
        // Delve VII
        private void ExecDestroyerSmash(Unit player, Unit target)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S)");
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(E)");
        }
        private void ExecOneImmunity(Unit player, Unit target)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S)");
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(E)");
        }
        private void ExecDeadlyArrow(Unit player, Unit target)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S)");
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(E)");
        }
        private void ExecCarnageRush(Unit player, Unit target)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S)");
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(E)");
        }
        private void ExecOverwhelmingDestiny(Unit player, Unit target)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S)");
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(E)");
        }
        private void ExecTranscendenceReached(Unit player, Unit target)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S)");
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(E)");
        }
        private void ExecResurrection(Unit player, Unit target)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S)");
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(E)");
        }
        private void ExecDemonContract(Unit player, Unit target)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S)");
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(E)");
        }
        private void ExecLavaAnnihilation(Unit player, List<Unit> target)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S)");
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(E)");
        }
        private void ExecAbsoluteZero(Unit player, List<Unit> target)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S)");
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(E)");
        }
        private void ExecBrilliantFrom(Unit player, Unit target)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S)");
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(E)");
        }
        private void ExecTimeSkip(Unit player, Unit target)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S)");
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(E)");
        }


        // Effect
        private void EffectPoisonDamage(Unit player, Unit target)
        {
            ExecDamage(player, target, ActionCommand.EffectValue(FIX.EFFECT_POISON));
        }
        private void EffectHeartOfLife(Unit player, Unit target)
        {
            ExecHeal(player, target, target.CurrentHeartOfLifeValue);
        }


        // Buff

        private void PlayerBuffAbstract(Unit player, Unit target, string commandName)
        {
            switch (commandName)
            {
                case FIX.HEART_OF_THE_LIFE:
                    target.CurrentHeartOfLife = ActionCommand.IsBuffTurn(FIX.HEART_OF_THE_LIFE);
                    target.CurrentHeartOfLifeValue = (int)(PrimaryLogic.HeartOfLifeValue(player));
                    break;

                case FIX.AURA_OF_POWER:
                    target.CurrentAuraOfPower = ActionCommand.IsBuffTurn(FIX.AURA_OF_POWER);
                    target.CurrentAuraOfPowerValue = (int)(PrimaryLogic.AuraOfPowerValue(player));
                    break;

                case FIX.SKY_SHIELD:
                    target.CurrentSkyShield = ActionCommand.IsBuffTurn(FIX.SKY_SHIELD);
                    target.CurrentSkyShieldValue = (int)(PrimaryLogic.SkyShieldValue(player));
                    break;

                case FIX.STANCE_OF_THE_BLADE:
                    target.CurrentStanceOfBlade = ActionCommand.IsBuffTurn(FIX.STANCE_OF_THE_BLADE);
                    target.CurrentStanceOfBladeValue = (int)(PrimaryLogic.StanceOfBladeValue(player));
                    break;

                case FIX.STANCE_OF_THE_GUARD:
                    target.CurrentStanceOfGuard = ActionCommand.IsBuffTurn(FIX.STANCE_OF_THE_GUARD);
                    target.CurrentStanceOfGuardValue = (int)(PrimaryLogic.StanceOfGuardValue(player));
                    break;

                case FIX.INVISIBLE_BIND:
                    target.CurrentBind = ActionCommand.IsBuffTurn(FIX.INVISIBLE_BIND);
                    target.CurrentBindValue = (int)(PrimaryLogic.InvisibleBindValue(player));
                    break;

                case FIX.FORTUNE_SPIRIT:
                    target.CurrentFortuneSpirit = ActionCommand.IsBuffTurn(FIX.FORTUNE_SPIRIT);
                    target.CurrentFortuneSpiritValue = (int)(PrimaryLogic.FortuneSpiritValue(player));
                    break;

                case FIX.ZERO_IMMUNITY:
                    target.CurrentZeroImmunity = ActionCommand.IsBuffTurn(FIX.ZERO_IMMUNITY);
                    target.CurrentZeroImmunityValue = (int)(PrimaryLogic.ZeroImmunityValue(player));
                    break;

                case FIX.DIVINE_CIRCLE:
                    target.CurrentDivineCircle = ActionCommand.IsBuffTurn(FIX.DIVINE_CIRCLE);
                    target.CurrentDivineCircleValue = (int)(PrimaryLogic.DivineCircleValue(player));
                    break;

                case FIX.BLOOD_SIGN:
                    target.CurrentSlip = ActionCommand.IsBuffTurn(FIX.BLOOD_SIGN);
                    target.CurrentSlipValue = (int)(PrimaryLogic.BloodSignValue(player));
                    break;

                case FIX.FLAME_BLADE:
                    target.CurrentFlameBlade = ActionCommand.IsBuffTurn(FIX.FLAME_BLADE);
                    target.CurrentFlameBladeValue = (int)(PrimaryLogic.FlameBladeValue(player));
                    break;

                case FIX.STORM_ARMOR:
                    target.CurrentStormArmor = ActionCommand.IsBuffTurn(FIX.STORM_ARMOR);
                    target.CurrentStormArmorValue = (int)(PrimaryLogic.StormArmorValue(player));
                    break;
            }
        }
    }
}