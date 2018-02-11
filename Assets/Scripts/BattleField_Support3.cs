using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            UpdateLife(target);
        }
        private void ExecDamage(Unit player, Unit target, int value)
        {
            if (value < 0) { value = 0; }
            target.CurrentLife -= value;
            if (player.IsAlly)
            {
                ONE.BattleDamageDone += value;
            }
            UpdateLife(target);
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
            ExecDamage(player, target, ActionCommand.EffectValue(FIX.DASH) + target.CurrentReachabletargetValue - target.DefenseValue);
            GetTacticsPoint(player);
        }

        private void ExecFireBlade(Unit player)
        {
            player.CurrentFireBlade = ActionCommand.IsBuffTurn(FIX.FIREBLADE);
            player.CurrentFireBladeValue = ActionCommand.EffectValue(FIX.FIREBLADE);
            GetTacticsPoint(player);
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
                    ExecDamage(player, target, ActionCommand.EffectValue(FIX.HOLYBULLET) + target.CurrentReachabletargetValue - target.DefenseValue);
                }
                else
                {
                    Debug.Log("holy target null...");
                }
            }
            GetTacticsPoint(player);
        }

        private void ExecProtection(Unit player, Unit target)
        {
            target.CurrentProtection = ActionCommand.IsBuffTurn(FIX.PROTECTION);
            target.CurrentProtectionValue = ActionCommand.EffectValue(FIX.PROTECTION);
            GetTacticsPoint(player);
        }

        private void ExecNeedleSpear(Unit player, Unit target)
        {
            ExecDamage(player, target, ActionCommand.EffectValue(FIX.NEEDLESPEAR) + target.CurrentReachabletargetValue - target.DefenseValue);

            int dummy = 0;
            FIX.Direction direction = ExistAttackableUnitLinerGroup(ref dummy, player, target, player.EffectRange);
            target.Move(direction); // 敵を一歩後退させる。
            GetTacticsPoint(player);
        }

        private void ExecSilverArrow(Unit player, Unit target)
        {
            ExecDamage(player, target, ActionCommand.EffectValue(FIX.SILVERARROW) + target.CurrentReachabletargetValue - target.DefenseValue);
            target.CurrentSilverArrow = ActionCommand.IsBuffTurn(FIX.SILVERARROW);
            target.CurrentSilverArrowValue = ActionCommand.EffectValue(FIX.SILVERARROW);
            GetTacticsPoint(player);
        }

        private void ExecEarthBind(Unit player, Unit target)
        {
            target.CurrentEarthBind = ActionCommand.IsBuffTurn(FIX.EARTHBIND);
            target.CurrentEarthBindValue = ActionCommand.EffectValue(FIX.EARTHBIND);
            GetTacticsPoint(player);
        }

        private void ExecPowerWord(Unit player, Unit target)
        {
            target.CurrentPowerWord = ActionCommand.IsBuffTurn(FIX.POWERWORD);
            target.CurrentPowerWordValue = ActionCommand.EffectValue(FIX.POWERWORD);
            GetTacticsPoint(player);
        }

        private void ExecHeatBoost(Unit player, Unit target)
        {
            target.CurrentTime -= ActionCommand.EffectValue(FIX.HEATBOOST);
            AdjustTime(target);
            GetTacticsPoint(player);
        }

        private void ExecFreshHeal(Unit player, Unit target)
        {
            ExecHeal(player, target, ActionCommand.EffectValue(FIX.FRESHHEAL));
            GetTacticsPoint(player);
        }

        private void ExecHealingWord(Unit player, Unit target)
        {
            ExecHeal(player, target, ActionCommand.EffectValue(FIX.HEALINGWORD));
            target.CurrentHealingWord = ActionCommand.IsBuffTurn(FIX.HEALINGWORD);
            target.CurrentHealingWordValue = ActionCommand.EffectValue(FIX.HEALINGWORD);
            GetTacticsPoint(player);
        }

        private void ExecReachableTarget(Unit player, Unit target)
        {
            target.CurrentReachableTarget = ActionCommand.IsBuffTurn(FIX.REACHABLETARGET);
            target.CurrentReachabletargetValue = ActionCommand.EffectValue(FIX.REACHABLETARGET);
            GetTacticsPoint(player);
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
        //    GetTacticsPoint(player);
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
                    int value = ActionCommand.EffectValue(FIX.BLAZE) + target.CurrentReachabletargetValue - target.DefenseValue;
                    ExecDamage(player, target, value);
                }
            }
            GetTacticsPoint(player);
        }

        private void ExecExplosion(Unit player, Unit target)
        {
            int value = ActionCommand.EffectValue(FIX.EXPLOSION) + target.CurrentReachabletargetValue - target.DefenseValue;
            ExecDamage(player, target, value);
            GetTacticsPoint(player);
        }
    }
}