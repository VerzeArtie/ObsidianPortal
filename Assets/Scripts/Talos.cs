using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;

namespace ObsidianPortal
{
    public static class Talos
    {
        public static void TraceOpponent(List<Unit> allUnitList, List<AreaInformation> fieldTile, Unit dst)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name +  "(S)");
            for (int ii = 0; ii < fieldTile.Count; ii++)
            {
                fieldTile[ii].cost = -1;
                fieldTile[ii].toGoal = null;
                for (int jj = 0; jj < fieldTile[ii].connectNode.Count; jj++)
                {
                    fieldTile[ii].connectNode[jj].cost = -1;
                }
            }
            List<AreaInformation> work1 = new List<AreaInformation>();
            List<AreaInformation> work2 = new List<AreaInformation>();

            AreaInformation m_goal = ExistAreaFromLocation(fieldTile, dst.transform.localPosition);

            m_goal.cost = 0; //ゴールにコスト0をセットして計算済みとする

            work1.Add(m_goal);

            //for (int ii = 0; ii < fieldTile.Count; ii++)
            //{
            //    if (work1[0].Equals(fieldTile[ii]))
            //    {
            //        Debug.Log("work1 same detect: " + ii.ToString());
            //        break;
            //    }
            //}

            while (work1.Count > 0)
            {
                for (int ii = 0; ii < work1.Count; ii++)
                {
                    //次のノード階層へ進めるなら、nextレベルに格納
                    for (int jj = 0; jj < work1[ii].connectNode.Count; jj++)
                    {
                        int nodeCost = work1[ii].cost + work1[ii].connectNode[jj].MoveCost;

                        for (int kk = 0; kk < allUnitList.Count; kk++)
                        {
                            // 敵軍ユニットから見て敵軍（つまりプレイヤー軍隊）がいた場合、コストを最大にする。
                            Unit unit = ExistUnitFromLocation(allUnitList, work1[ii].connectNode[jj].transform.localPosition);
                            if (unit != null && unit.IsAlly)
                            {
                                nodeCost = 999;
                                break;
                            }

                            // ターゲット近隣判定で、敵軍からみて自軍（つまり敵軍）がいた場合、
                            if (ii == 0 && unit != null && unit.IsEnemy)
                            {
                                nodeCost = 999;
                                break;
                            }
                        }
                        if (work1[ii].connectNode[jj].cost <= -1 || nodeCost < work1[ii].connectNode[jj].cost)
                        {
                            //未探索ノードあるいは最短ルートを更新できる場合
                            //経路コストとゴールへ向かうためのノードをセットして
                            //次に検索する階層のリストに登録
                            work1[ii].connectNode[jj].cost = nodeCost;
                            work1[ii].connectNode[jj].toGoal = work1[ii];
                            work2.Add(work1[ii].connectNode[jj]);
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                //リストを入れ替えて次の階層を検索する
                work1.Clear();
                for (int ii = 0; ii < work2.Count; ii++)
                {
                    work1.Add(work2[ii]);
                }
                work2.Clear();
            }

            //for (int ii = 0; ii < fieldTile.Count / 11; ii++)
            //{
            //    Debug.Log("FieldTile cost: " + fieldTile[ii * 11].cost.ToString("D4") + " "
            //                                 + fieldTile[ii * 11 + 1].cost.ToString("D4") + " "
            //                                 + fieldTile[ii * 11 + 2].cost.ToString("D4") + " "
            //                                 + fieldTile[ii * 11 + 3].cost.ToString("D4") + " "
            //                                 + fieldTile[ii * 11 + 4].cost.ToString("D4") + " "
            //                                 + fieldTile[ii * 11 + 5].cost.ToString("D4") + " "
            //                                 + fieldTile[ii * 11 + 6].cost.ToString("D4") + " "
            //                                 + fieldTile[ii * 11 + 7].cost.ToString("D4") + " "
            //                                 + fieldTile[ii * 11 + 8].cost.ToString("D4") + " "
            //                                 + fieldTile[ii * 11 + 9].cost.ToString("D4") + " "
            //                                 + fieldTile[ii * 11 + 10].cost.ToString("D4") + " "
            //                                 );
            //}
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(E)");
        }

        public static Unit ExistUnitFromLocation(List<Unit> AllList, Vector3 src)
        {
            for (int ii = 0; ii < AllList.Count; ii++)
            {
                if (ContainPositionX(AllList[ii].transform.localPosition.x, src.x) &&
                    AllList[ii].transform.localPosition.y == src.y)
                {
                    return AllList[ii];
                }
            }
            return null;
        }

        /// <summary>
        /// X座標のタイル位置とオブジェクト位置が合致するかどうかの判定を行います。
        /// </summary>
        /// <param name="x"></param>
        /// <param name="x2"></param>
        /// <returns></returns>
        public static bool ContainPositionX(float x, float x2)
        {
            // wonder just equal value is not detect target object...
            // adjust -0.01 < x < +0.01
            if (x - 0.01 <= x2 && x2 <= x + 0.01)
            {
                return true;
            }
            return false;
        }
        
        /// <summary>
        /// 指定の位置にタイルエリアが存在するかどうか確認します。
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static AreaInformation ExistAreaFromLocation(List<AreaInformation> FieldTile, Vector3 src)
        {
            for (int ii = 0; ii < FieldTile.Count; ii++)
            {
                if (ContainPositionX(FieldTile[ii].transform.localPosition.x, src.x) &&
                    FieldTile[ii].transform.localPosition.y == src.y)
                {
                    return FieldTile[ii];
                }
            }
            return null;
        }
    }
}
