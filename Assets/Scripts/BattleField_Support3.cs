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
            UpdateLife(target);
        }
        private void ExecDamage(Unit target, int value)
        {
            if (value < 0) { value = 0; }
            target.CurrentLife -= value;
            UpdateLife(target);
            if (target.CurrentLife <= 0)
            {
                target.Dead = true;
                target.gameObject.SetActive(false);
                EnemyList.Remove(target);
                ONE.Player.Exp += target.GetExp;
                ONE.Player.UpdateExp();
                txtExp.text = "( " + ONE.Player.Exp.ToString() + " / " + ONE.Player.NextLevelBorder.ToString() + " )";
            }
        }

        private void ExecFireBlade(Unit player)
        {
            player.CurrentFireBlade = ActionCommand.IsBuffTurn(FIX.FIREBLADE);
            player.CurrentFireBladeValue = ActionCommand.EffectValue(FIX.FIREBLADE);
        }

        private void ExecProtection(Unit player, Unit target)
        {
            target.CurrentProtection = ActionCommand.IsBuffTurn(FIX.PROTECTION);
            target.CurrentProtectionValue = ActionCommand.EffectValue(FIX.PROTECTION);
        }

        private void ExecSilverArrow(Unit player, Unit target)
        {
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
            //animation; // todo change new spell ( dont use heatboost)
            //AddUnitWithAdjustTime(target);
        }

        private void ExecHealingWord(Unit player, Unit target)
        {
            target.CurrentHealingWord = ActionCommand.IsBuffTurn(FIX.HEALINGWORD);
            target.CurrentHealingWordValue = ActionCommand.EffectValue(FIX.HEALINGWORD);
        }

        private void ExecReachableTarget(Unit player, Unit target)
        {
            target.CurrentReachableTarget = ActionCommand.IsBuffTurn(FIX.REACHABLETARGET);
            target.CurrentReachabletargetValue = ActionCommand.EffectValue(FIX.REACHABLETARGET);
        }

        private void ExecLavaWall(Unit player, FIX.Direction direction)
        {
            Vector3 result = player.GetNeighborhood(direction);
            SetupUnit(ref this.AllList, 999, false, Unit.RaceType.Fire, Unit.UnitType.Wall, result.x, result.z, false);
        }
    }
}