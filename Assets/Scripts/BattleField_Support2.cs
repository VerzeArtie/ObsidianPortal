using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObsidianPortal
{
    public partial class BattleField : MotherForm
    {


        private bool CanMove(FIX.Direction direction)
        {
            AreaInformation nextArea = ExistAreaFromLocation(this.CurrentUnit.GetNeighborhood(direction));
            if (nextArea == null)
            {
                return false;
            }

            Unit nextUnit = ExistUnitFromLocation(nextArea.transform.localPosition);
            if (nextUnit != null)
            {
                return false;
            }

            return true;
        }

        private void JudgeMove(FIX.Direction first, FIX.Direction second, FIX.Direction third, out FIX.Direction result)
        {
            if (CanMove(first))
            {
                result = first;
            }
            else if (CanMove(FIX.Direction.TopLeft))
            {
                result = second;
            }
            else if (CanMove(FIX.Direction.TopRight))
            {
                result = third;
            }
            else
            {
                result = FIX.Direction.None;
            }
        }

        private int GetSequenceNumber(Unit unit)
        {
            int TotalCount = AllyList.Count + EnemyList.Count;
            Unit[] list = new Unit[TotalCount];
            int jj = 0;
            for (int ii = 0; ii < AllyList.Count; ii++)
            {
                list[ii] = AllyList[ii];
                jj++;
            }
            for (int ii = 0; ii < EnemyList.Count; ii++)
            {
                list[ii+jj] = EnemyList[ii];
            }
            System.Array.Sort((System.Array)list, 0, TotalCount, SortCurrentTime());

            for (int ii = 0; ii < TotalCount; ii++)
            {
                if (list[ii].name == unit.name)
                {
                    return ii + 1;
                }
            }
            return -1;
        }
        public static IComparer SortCurrentTime()
        {
            return (IComparer)new TimeSort();
        }
        public class TimeSort : IComparer
        {
            int IComparer.Compare(object a, object b)
            {
                Unit c1 = (Unit)a;
                Unit c2 = (Unit)b;

                //if (c1.CurrentTime.CompareTo(c2.CurrentTime) == 0)
                //{
                //    if (c1.IsAlly) { return -1; } else { return 1; }
                //}
               // else
                //{
                    return c1.CurrentTime.CompareTo(c2.CurrentTime);// c2.Rare.CompareTo(c1.Rare);
               // }
            }
        }
    }
}