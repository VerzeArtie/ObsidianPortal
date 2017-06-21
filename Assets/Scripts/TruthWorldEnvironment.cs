using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace ObsidianPortal
{
    public class TruthWorldEnvironment : MonoBehaviour
    {
        public int TotalPlayed { get; set; }
        public int TotalWin { get; set; }
        public int TotalLose { get; set; }

        public int MostDamageDone { get; set; }
        public int MostHealingDone { get; set; }
        public int MostTacticsPoint { get; set; }
        public int MostEliminations { get; set; }

        public int PlayHuman { get; set; }
        public int PlayMech { get; set; }
        public int PlayAngel { get; set; }
        public int PlayDemon { get; set; }
        public int PlayFire { get; set; }
        public int PlayIce { get; set; }

        public int UseDash { get; set; }
        public int UseTarget { get; set; }
        public int UseEarthBind { get; set; }
        public int UseHealingWord { get; set; }
        public int UsePowerWord { get; set; }

        public int UseNeedSpear { get; set; }
        public int UseSilverArrow { get; set; }
        public int UseHolyField { get; set; }
        public int UseFreshHeal { get; set; }
        public int UseProtection { get; set; }

        public int UseFireBlade { get; set; }
        public int UseBlaze { get; set; }
        public int UseLavaWall { get; set; }
        public int UseHeatBoost { get; set; }
        public int UseExplosion { get; set; }

        public bool CompleteStage11 { get; set; }
        public bool CompleteStage12 { get; set; }
        public bool CompleteStage13 { get; set; }
        public bool CompleteStage14 { get; set; }
        public bool CompleteStage15 { get; set; }
        public bool CompleteStage21 { get; set; }
        public bool CompleteStage22 { get; set; }
        public bool CompleteStage23 { get; set; }
        public bool CompleteStage24 { get; set; }
        public bool CompleteStage25 { get; set; }
        public bool CompleteStage31 { get; set; }
        public bool CompleteStage32 { get; set; }
        public bool CompleteStage33 { get; set; }
        public bool CompleteStage34 { get; set; }
        public bool CompleteStage35 { get; set; }
        public bool CompleteStage41 { get; set; }
        public bool CompleteStage42 { get; set; }
        public bool CompleteStage43 { get; set; }
        public bool CompleteStage44 { get; set; }
        public bool CompleteStage45 { get; set; }
        public bool CompleteStage51 { get; set; }
        public bool CompleteStage52 { get; set; }
        public bool CompleteStage53 { get; set; }
        public bool CompleteStage54 { get; set; }
        public bool CompleteStage55 { get; set; }

        // SQLログ採取用アカウント
        public string Account { get; set; }
    }
}
