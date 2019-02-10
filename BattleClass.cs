using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObsidianPortal
{
    public static class BattleClass
    {
        public static List<string> CommandList(FIX.JobClass src)
        {
            List<string> list = new List<string>();
            switch (src)
            {
                case FIX.JobClass.Fighter:
                    list.Add(FIX.STRAIGHT_SMASH);
                    break;
                case FIX.JobClass.Archer:
                    list.Add(FIX.HUNTER_SHOT);
                    break;
                case FIX.JobClass.Magician:
                    list.Add(FIX.ENERGY_BOLT);
                    break;
                case FIX.JobClass.Priest:
                    list.Add(FIX.FRESH_HEAL);
                    break;
                case FIX.JobClass.Apprentice:
                    list.Add(FIX.WORD_OF_LIGHT);
                    break;
                case FIX.JobClass.Armorer:
                    list.Add(FIX.SHIELD_BASH);
                    break;
                case FIX.JobClass.Enchanter:
                    list.Add(FIX.FORCE_OF_STRENGTH);
                    break;
                default:
                    // nothing !!
                    break;
            }
            return list;
        }
    }
}
