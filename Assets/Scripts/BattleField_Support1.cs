using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ObsidianPortal
{
    public partial class BattleField : MotherForm
    {
        /// <summary>
        /// 対象ユニットのステータスを表示します。
        /// </summary>
        /// <param name="unit"></param>
        private void UpdateUnitStatus(Unit unit)
        {
            if (unit != null)
            {
                txtUnitName.GetComponent<Text>().text = unit.UnitName;
                txtAttack.text = unit.AttackValue.ToString();
                txtDefense.text = unit.DefenseValue.ToString();
                txtSpeed.text = unit.SpeedValue.ToString();
                txtMagicAttack.text = unit.MagicAttackValue.ToString();
                txtMagicDefense.text = unit.MagicDefenseValue.ToString();
                txtMove.text = unit.MoveValue.ToString();
                txtTime.text = unit.CurrentTime.ToString();
                txtOrder.text = GetSequenceNumber(unit).ToString();
                UpdateLife(unit);
                UpdateUnitImage(unit);
            }
            else
            {
                txtUnitName.GetComponent<Text>().text = "";
                UnitLifeText.text = "";
                UpdateUnitImage(unit);
            }
        }

        /// <summary>
        /// 対象ユニットのAPを表示します。
        /// </summary>
        /// <param name="unit"></param>
        private void UpdateUnitAP(Unit unit)
        {
            if (unit == null)
            {
                for (int ii = 0; ii < ActionPoint.Count; ii++)
                {
                    ActionPoint[ii].sprite = Resources.Load<Sprite>("ActionPoint_use");
                }
                return;
            }

            for (int ii = 0; ii < ActionPoint.Count; ii++)
            {
                if (ii < unit.CurrentAP)
                {
                    ActionPoint[ii].sprite = Resources.Load<Sprite>("ActionPoint");
                }
                else
                {
                    ActionPoint[ii].sprite = Resources.Load<Sprite>("ActionPoint_use");
                }
            }
        }

        // 各キャラクターが死亡をチェックし、ユニットリスト操作を行います。
        private void JudgeUnitDead()
        {
            for (int ii = 0; ii < AllyList.Count; ii++)
            {
                if (AllyList[ii].CurrentLife <= 0)
                {
                    AllyList[ii].DeadUnit();
                }
            }
            for (int ii = 0; ii < EnemyList.Count; ii++)
            {
                if (EnemyList[ii].CurrentLife <= 0)
                {
                    EnemyList[ii].DeadUnit();
                }
            }
            //if (player.IsAlly)
            //{
            //    ONE.BattleElimination++;
            //    ONE.BattleGettingExp += target.GetExp;
            //    ONE.Player.UpdateExp();
            //    txtExp.text = "( " + ONE.Player.Exp.ToString() + " / " + ONE.Player.NextLevelBorder.ToString() + " )";
            //}
        }

        // ゲームが終了したかどうかを判定し、画面に表示します。
        private void JudgeGameEnd()
        {
            if (DetectWin())
            {
                ONE.BattleWin = true;
                this.lblMessage.text = "VICTORY";
                this.panelMessage.SetActive(true);
                this.GameEnd = true;
            }
            else if (DetectLose())
            {
                ONE.BattleWin = false;
                this.lblMessage.text = "DEFEAT";
                this.panelMessage.SetActive(true);
                this.GameEnd = true;
            }
        }

        /// <summary>
        /// 選択／行動／指定などのコマンドをすべてをキャンセルします。
        /// </summary>
        private void ExecCancel(Unit unit)
        {
            this.Phase = ActionPhase.SelectFirst;
            ClearQuadTile();
            ClearAttackTile();
            ClearHealTile();
            ClearAllyEffectTile();
        }

        /// <summary>
        /// 全自軍ユニットか全相手ユニットが全滅したかどうか確認します。
        /// </summary>
        /// <returns></returns>
        private bool DetectWin()
        {
            for (int ii = 0; ii < EnemyList.Count; ii++)
            {
                if (EnemyList[ii].Dead == false)
                {
                    return false;
                }
            }
            Debug.Log("DetectWin true");
            return true;
        }

        /// <summary>
        /// 自軍ユニットが全滅したかどうか確認します。
        /// </summary>
        /// <returns></returns>
        private bool DetectLose()
        {
            for (int ii = 0; ii < AllyList.Count; ii++)
            {
                if (AllyList[ii].Dead == false)
                {
                    return false;
                }
            }
            Debug.Log("DetectLose true");
            return true;
        }

        /// <summary>
        /// X座標のタイル位置とオブジェクト位置が合致するかどうかの判定を行います。
        /// </summary>
        /// <param name="x"></param>
        /// <param name="x2"></param>
        /// <returns></returns>
        private bool ContainPositionX(float x, float x2)
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
        /// 移動可能な範囲かどうかを確認します。(Abstract -> Move)
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        private bool CheckMoveableArea(Vector3 src)
        {
            return AbstractCheckArea(src, MoveTile);
        }

        /// <summary>
        /// 攻撃可能な範囲かどうかを確認します。 (Abstract -> Attack)
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        private bool CheckAttackableArea(Vector3 src)
        {
            return AbstractCheckArea(src, AttackTile);
        }

        /// <summary>
        /// 回復可能な範囲かどうかを確認します。 (Abstract -> Heal)
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        private bool CheckHealableArea(Vector3 src)
        {
            return AbstractCheckArea(src, HealTile);
        }
        private bool CheckAllyEffectArea(Vector3 src)
        {
            return AbstractCheckArea(src, AllyEffectTile);
        }

        /// <summary>
        /// ターゲット可能な範囲かどうかを確認します。
        /// </summary>
        /// <param name="src"></param>
        /// <param name="areaList"></param>
        /// <returns></returns>
        private bool AbstractCheckArea(Vector3 src, List<GameObject> areaList)
        {
            for (int ii = 0; ii < areaList.Count; ii++)
            {
                if (ContainPositionX(areaList[ii].transform.localPosition.x, src.x) &&
                    src.y == areaList[ii].transform.localPosition.y)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 指定された位置がライン上に存在するかどうかを取得します。
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        private bool IsLinear(ref FIX.Direction direction, ref int move, Vector3 src, Vector3 target)
        {
            float x = 0;
            float z = 0;
            for (int ii = 0; ii < 999; ii++)
            {
                x = -FIX.HEX_MOVE_X * (ii + 1);
                z = 0;
                if (ContainPositionX(src.x + x, target.x) && (src.y + z == target.y))
                {
                    direction = FIX.Direction.Top;
                    move = ii;
                    return true;
                }

                x = -FIX.HEX_MOVE_X * (ii + 1);
                z = FIX.HEX_MOVE_Z * (ii + 1);
                if (ContainPositionX(src.x + x, target.x) && (src.y + z == target.y))
                {
                    direction = FIX.Direction.Right;
                    move = ii;
                    return true;
                }

                x = -FIX.HEX_MOVE_X * (ii + 1);
                z = -FIX.HEX_MOVE_Z * (ii + 1);
                if (ContainPositionX(src.x + x, target.x) && (src.y + z == target.y))
                {
                    direction = FIX.Direction.Left;
                    move = ii;
                    return true;
                }

                x = FIX.HEX_MOVE_X * (ii + 1);
                z = 0;
                if (ContainPositionX(src.x + x, target.x) && (src.y + z == target.y))
                {
                    direction = FIX.Direction.Bottom;
                    move = ii;
                    return true;
                }
            }

            direction = FIX.Direction.None;
            move = -1;
            return false;
        }

        /// <summary>
        /// ヒール可能な範囲を取得・表示します。
        /// </summary>
        /// <param name="src"></param>
        private void OpenHealable(Unit src)
        {
            ClearHealTile();
            List<Vector3> result = new List<Vector3>();
            result.Add(src.transform.localPosition);
            SearchMoveablePoint(ref result, src.transform.localPosition, src.HealRange, -1, src.ally, false);
            for (int ii = 0; ii < result.Count; ii++)
            {
                GameObject current = Instantiate(prefab_HealTile, new Vector3(result[ii].x, result[ii].y, ExistAreaFromLocation(result[ii]).transform.localPosition.z - 0.51f), Quaternion.identity) as GameObject;
                current.transform.Rotate(new Vector3(0, 0, 0));
                current.gameObject.SetActive(true);
                HealTile.Add(current);
            }
        }

        /// <summary>
        /// 攻撃可能な範囲を取得・表示します。
        /// </summary>
        /// <param name="src"></param>
        private void OpenAttackable(Unit src, int range, bool linear)
        {
            ClearAttackTile();
            List<Vector3> result = new List<Vector3>();
            result.Add(src.transform.localPosition);
            if (linear)
            {
                SearchMoveableLinear(ref result, src.transform.localPosition, range, 0, src.ally, false);
                SearchMoveableLinear(ref result, src.transform.localPosition, range, 1, src.ally, false);
                SearchMoveableLinear(ref result, src.transform.localPosition, range, 2, src.ally, false);
                SearchMoveableLinear(ref result, src.transform.localPosition, range, 3, src.ally, false);
            }
            else
            {
                SearchMoveablePoint(ref result, src.transform.localPosition, range, -1, src.ally, false);
            }

            for (int ii = 0; ii < result.Count; ii++)
            {
                GameObject current = Instantiate(prefab_AttackTile, new Vector3(result[ii].x, result[ii].y, ExistAreaFromLocation(result[ii]).transform.localPosition.z - 0.51f), Quaternion.identity) as GameObject;
                current.transform.Rotate(new Vector3(0, 0, 0));
                current.gameObject.SetActive(true);
                AttackTile.Add(current);
            }
        }

        /// <summary>
        /// 味方を対象とするエリア範囲を取得・表示します。
        /// </summary>
        /// <param name="src"></param>
        private void OpenAllyEffectable(Unit src)
        {
            ClearAllyEffectTile();
            List<Vector3> result = new List<Vector3>();
            result.Add(src.transform.localPosition);
            SearchMoveablePoint(ref result, src.transform.localPosition, src.EffectRange, -1, src.ally, false);
            for (int ii = 0; ii < result.Count; ii++)
            {
                GameObject current = Instantiate(prefab_AllyEffectTile, new Vector3(result[ii].x, result[ii].y, ExistAreaFromLocation(result[ii]).transform.localPosition.z - 0.51f), Quaternion.identity) as GameObject;
                current.transform.Rotate(new Vector3(0, 0, 0));
                current.gameObject.SetActive(true);
                AllyEffectTile.Add(current);
            }
        }

        /// <summary>
        /// 移動可能な範囲を取得・表示します。
        /// </summary>
        /// <param name="src"></param>
        private void OpenMoveable(Unit src)
        {
            ClearQuadTile();
            List<Vector3> result = new List<Vector3>();
            result.Add(src.transform.localPosition);
            SearchMoveablePoint(ref result, src.transform.localPosition, src.MoveValue, -1, src.ally, true);
            for (int ii = 0; ii < result.Count; ii++)
            {
                GameObject current = Instantiate(prefab_Quad, new Vector3(result[ii].x, result[ii].y, ExistAreaFromLocation(result[ii]).transform.localPosition.z - 0.51f), Quaternion.identity) as GameObject;
                current.transform.Rotate(new Vector3(0, 0, 0));
                current.gameObject.SetActive(true);
                MoveTile.Add(current);
            }
            for (int ii = 0; ii < MoveTile.Count; ii++)
            {
                Debug.Log(MoveTile[ii].transform.localPosition.ToString());
            }
        }

        /// <summary>
        /// 指定の位置にユニットが存在するかどうか確認します。
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private Unit ExistUnitFromLocation(Vector3 src)
        {
            for (int ii = 0; ii < AllyList.Count; ii++)
            {
                if (ContainPositionX(AllyList[ii].transform.localPosition.x, src.x) &&
                    AllyList[ii].transform.localPosition.y == src.y)
                {
                    return AllyList[ii];
                }
            }
            for (int ii = 0; ii < EnemyList.Count; ii++)
            {
                if (ContainPositionX(EnemyList[ii].transform.localPosition.x, src.x) &&
                    EnemyList[ii].transform.localPosition.y == src.y)
                {
                    return EnemyList[ii];
                }
            }
            return null;
        }

        /// <summary>
        /// 指定の位置にタイルエリアが存在するかどうか確認します。
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        private AreaInformation ExistAreaFromLocation(Vector3 src)
        {
            for (int ii = 0; ii < fieldTile.Count; ii++)
            {
                if (ContainPositionX(fieldTile[ii].transform.localPosition.x, src.x) &&
                    fieldTile[ii].transform.localPosition.y == src.y)
                {
                    return fieldTile[ii];
                }
            }
            return null;
        }

        private Unit SearchAttackableUnitInArea(Unit src, int range)
        {
            Unit target = null;
            int[,] array = null;

            if (src.AttackRange == 1)
            {
                array = new int[,] { { 0, 1 },
                                     { -1, 0 }, /*{ 0, 0 },*/ { 1, 0 }, 
                                     { 0, -1 } };
            }
            else if (src.AttackRange == 2)
            {
                array = new int[,] { { 0, 2 },
                                     { -1, 1 }, { 0, 1 }, { 1, 1 },
                                     { -2, 0 }, { -1, 0 }, /*{0, 0},*/ { 1, 0 }, { 2, 0 },
                                     { -1, -1}, {0, -1}, {1, -1},
                                     { 0, -2 } };
            }
            else if (src.AttackRange == 3)
            {
                array = new int[,] { { 0, 3 },
                                     { -1, 2 }, { 0, 2 }, { 1, 2 },
                                     { -2, 1 }, { -1, 1}, { 0, 1 }, { 1, 1 }, { 2, 1 },
                                     { -3, 0}, { -2, 0 }, { -1, 0 }, /*{0, 0},*/ { 1, 0 }, { 2, 0 }, { 3, 0 },
                                     { -2, -1 }, { -1, -1}, { 0, -1 }, { 1, -1 }, { 2, -1 },                                
                                     { -1, -2}, {0, -2}, {1, -2},
                                     { 0, -3 } };
            }

            Debug.Log("SearchAttackableUnitInArea: " + src.AttackRange.ToString() + " " + array.Length.ToString());
            for (int ii = 0; ii < array.Length/2; ii++)
            {
                Vector3 search = new Vector3(src.transform.localPosition.x + array[ii, 0], src.transform.localPosition.y + array[ii, 1], src.transform.localPosition.z);
                target = ExistUnitFromLocation(search);
                if (target != null && target.Dead == false && ((src.IsAlly && target.IsEnemy) || (src.IsEnemy && target.IsAlly)))
                {
                    return target;
                }
            }
            return null;
        }

        /// <summary>
        /// 攻撃が行えるユニットが存在するかどうか確認します。(敵専用)
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        private List<Unit> SearchAttackableUnit(Unit src, int range)
        {
            List<Unit> result = new List<Unit>();
            // ユニットの位置情報はすでにAllyListで把握している。

            List<Vector3> target = new List<Vector3>();
            SearchMoveablePoint(ref target, src.transform.localPosition, range, -1, src.ally, false);
            for (int ii = 0; ii < AllyList.Count; ii++)
            {
                Debug.Log("ally type: " + AllList[ii].Type.ToString());
                if (AllyList[ii].Dead) { continue; }
                //if (AllyList[ii].Type == Unit.UnitType.Wall) { continue; }

                for (int jj = 0; jj < target.Count; jj++)
                {
                    if (ContainPositionX(AllyList[ii].transform.localPosition.x, target[jj].x) &&
                        AllyList[ii].transform.localPosition.y == target[jj].y)
                    {
                        result.Add(AllyList[ii]);
                    }
                }
            }

            for (int ii = 0; ii < result.Count; ii++)
            {
                Debug.Log("SearchAttackableUnit: " + result[ii].UnitName);
            }
            return result;
        }

        private List<Unit> SearchAttackableUnitLinearGroup(Unit src, int max)
        {
            List<Unit> result = new List<Unit>();
            List<Unit> temp = SearchAttackableUnitLinear(src, max, FIX.Direction.Top);
            if (temp.Count > 0)
            {
                for (int ii = 0; ii < temp.Count; ii++)
                {
                    result.Add(temp[ii]);
                }
            }
            temp.Clear();
            temp = SearchAttackableUnitLinear(src, max, FIX.Direction.Left);
            if (temp.Count > 0)
            {
                for (int ii = 0; ii < temp.Count; ii++)
                {
                    result.Add(temp[ii]);
                }
            }
            temp.Clear();
            temp = SearchAttackableUnitLinear(src, max, FIX.Direction.Right);
            if (temp.Count > 0)
            {
                for (int ii = 0; ii < temp.Count; ii++)
                {
                    result.Add(temp[ii]);
                }
            }
            temp.Clear();
            temp = SearchAttackableUnitLinear(src, max, FIX.Direction.Bottom);
            if (temp.Count > 0)
            {
                for (int ii = 0; ii < temp.Count; ii++)
                {
                    result.Add(temp[ii]);
                }
            }
            temp.Clear();
            return result;
        }

        /// <summary>
        /// 指定した方向に対して、攻撃可能なユニットがいるかどうか確認し、復帰値に登録します。
        /// </summary>
        /// <param name="src"></param>
        /// <param name="max"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        private List<Unit> SearchAttackableUnitLinear(Unit src, int max, FIX.Direction direction)
        {
            List<Unit> result = new List<Unit>();
            for (int ii = 0; ii < max; ii++)
            {
                float x = 0;
                float z = 0;
                if (direction == FIX.Direction.Top)
                {
                    x = -FIX.HEX_MOVE_X * (ii + 1);
                    z = 0;
                }
                else if (direction == FIX.Direction.Right)
                {
                    x = -FIX.HEX_MOVE_X * (ii + 1);
                    z = FIX.HEX_MOVE_Z * (ii + 1);
                }
                else if (direction == FIX.Direction.Left)
                {
                    x = FIX.HEX_MOVE_X * (ii + 1);
                    z = FIX.HEX_MOVE_Z * (ii + 1);
                }
                else if (direction == FIX.Direction.Bottom)
                {
                    x = FIX.HEX_MOVE_X * (ii + 1);
                    z = 0;
                }
                for (int jj = 0; jj < AllyList.Count; jj++)
                {
                    if (ContainPositionX(src.transform.position.x + x, AllyList[jj].transform.position.x) &&
                        (src.transform.position.y + z == AllyList[jj].transform.position.y))// &&
                        //(AllyList[jj].Type != Unit.UnitType.Wall))
                    {
                        Debug.Log("SearchAttackableUnitLinear(E) " + jj.ToString());
                        result.Add(AllyList[jj]);
                    }
                }
            }
            return result;
        }

        private FIX.Direction ExistAttackableUnitLinerGroup(ref int move, Unit src, Unit target, int range)
        {
            if (ExistAttackableUnitLinear(ref move, src, target, range, FIX.Direction.Top))
            {
                return FIX.Direction.Top;
            }
            else if (ExistAttackableUnitLinear(ref move, src, this.CurrentTarget, src.EffectRange, FIX.Direction.Top))
            {
                return FIX.Direction.Top;
            }
            else if (ExistAttackableUnitLinear(ref move, src, this.CurrentTarget, src.EffectRange, FIX.Direction.Left))
            {
                return FIX.Direction.Left;
            }
            else if (ExistAttackableUnitLinear(ref move, src, this.CurrentTarget, src.EffectRange, FIX.Direction.Right))
            {
                return FIX.Direction.Right;
            }
            else if (ExistAttackableUnitLinear(ref move, src, this.CurrentTarget, src.EffectRange, FIX.Direction.Bottom))
            {
                return FIX.Direction.Bottom;
            }
            else
            {
                Debug.Log("DASH detect other...");
                return FIX.Direction.None;
            }
        }
        private bool ExistAttackableUnitLinear(ref int move, Unit src, Unit target, int max, FIX.Direction direction)
        {
            Debug.Log("ExistAttackableUnitLinear(S)");
            for (int ii = 0; ii < max; ii++)
            {
                float x = 0;
                float y = 0;
                if (direction == FIX.Direction.Top)
                {
                    x = 0;
                    y = FIX.HEX_MOVE_Z * (ii + 1);
                }
                else if (direction == FIX.Direction.Right)
                {
                    x = FIX.HEX_MOVE_X * (ii + 1);
                    y = 0;
                }
                else if (direction == FIX.Direction.Left)
                {
                    x = -FIX.HEX_MOVE_X * (ii + 1);
                    y = 0;
                }
                else if (direction == FIX.Direction.Bottom)
                {
                    x = 0;
                    y = -FIX.HEX_MOVE_Z * (ii + 1);
                }
                if (ContainPositionX(src.transform.position.x + x, target.transform.position.x) &&
                    (src.transform.position.y + y == target.transform.position.y))// &&
                    //(target.Type != Unit.UnitType.Wall))
                {
                    Debug.Log("ExistAttackableUnitLinear(E) " + ii.ToString());
                    move = ii;
                    return true;
                }
            }
            Debug.Log("ExistAttackableUnitLinear(E)");
            return false;
        }

        private void SetupItem(ref List<GameObject> list, int number, float x, float y)
        {
            GameObject unit = null;
            
            x = x * FIX.HEX_MOVE_X;
            y = y * FIX.HEX_MOVE_Z;
            unit = Instantiate(prefab_Treasure, new Vector3(x, y, -0.2f), Quaternion.identity) as GameObject;

            unit.SetActive(true);
            TreasureList.Add(unit);
            unit.name = "Treasure_" + number.ToString();
        }
        /// <summary>
        /// ユニットを生成します。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="type"></param>
        /// <param name="x"></param>
        /// <param name="z"></param>
        private Unit SetupUnit(int number, bool enemy, Unit.RaceType race, Unit.UnitType type, float x, float y)
        {
            Unit prefab = null;
            Unit unit = null;
            if (type == Unit.UnitType.Fighter) { prefab = prefab_Fighter; }
            else if (type == Unit.UnitType.Archer) { prefab = prefab_Archer; }
            else if (type == Unit.UnitType.Magician) { prefab = prefab_Magician; }
            //else if (type == Unit.UnitType.Sorcerer) { prefab = prefab_Sorcerer; }
            //else if (type == Unit.UnitType.Priest) { prefab = prefab_Priest; }
            //else if (type == Unit.UnitType.Enchanter) { prefab = prefab_Enchanter; }
            //else if (type == Unit.UnitType.Wall) { prefab = prefab_Wall; }
            if (race == Unit.RaceType.Monster) { prefab = prefab_Monster; }

            x = x * FIX.HEX_MOVE_X;
            y = y * FIX.HEX_MOVE_Z;

            unit = Instantiate(prefab, new Vector3(x, y, ExistAreaFromLocation(new Vector3(x, y, 0)).transform.localPosition.z - 0.5f), Quaternion.identity) as Unit;

            unit.Initialize(race, type, enemy);
            unit.name = type.ToString() + "_" + number.ToString();
            unit.gameObject.SetActive(true);

            AddUnitWithAdjustTime(unit);
            return unit;
        }

        /// <summary>
        /// タイマーコストが同値で競合しないように調整します。
        /// </summary>
        /// <param name="unit"></param>
        private void AdjustTime(Unit unit)
        {
            for (int ii = 0; ii < AllList.Count; ii++)
            {
                if (AllList[ii].Equals(unit)) { continue;}

                if (AllList[ii].CurrentTime == unit.CurrentTime)
                {
                    for (int jj = ii; jj < AllList.Count; jj++)
                    {
                        if (AllList[jj].Equals(unit)) { continue; }
                        if (AllList[jj].CurrentTime >= unit.CurrentTime)
                        {
                            AllList[jj].CurrentTime++;
                        }
                    }
                    break;
                }
            }
        }

        /// <summary>
        /// タイマーコストが同値で競合しないように新しいユニットを追加します。
        /// </summary>
        /// <param name="unit"></param>
        private void AddUnitWithAdjustTime(Unit unit)
        {
            AllList.Sort(Unit.Compare);
            for (int ii = 0; ii < AllList.Count; ii++)
            {
                if (AllList[ii].CurrentTime == unit.CurrentTime)
                {
                    Debug.Log("equal detect: " + AllList[ii].CurrentTime.ToString());
                    unit.CurrentTime++;
                    for (int jj = ii+1; jj < AllList.Count; jj++)
                    {
                        AllList[jj].CurrentTime++;
                    }
                    break;
                }
            }
        }

        /// <summary>
        /// ヒール可能タイルをクリアします。
        /// </summary>
        private void ClearHealTile()
        {
            for (int ii = 0; ii < HealTile.Count; ii++)
            {
                HealTile[ii].SetActive(false);
                Destroy(HealTile[ii]);
            }
            HealTile.Clear();
        }

        /// <summary>
        /// 攻撃可能タイルをクリアします。
        /// </summary>
        private void ClearAttackTile()
        {
            for (int ii = 0; ii < AttackTile.Count; ii++)
            {
                AttackTile[ii].SetActive(false);
                Destroy(AttackTile[ii]);
            }
            AttackTile.Clear();
        }

        /// <summary>
        /// 味方効果タイルをクリアします。
        /// </summary>
        private void ClearAllyEffectTile()
        {
            for (int ii = 0; ii < AllyEffectTile.Count; ii++)
            {
                AllyEffectTile[ii].SetActive(false);
                Destroy(AllyEffectTile[ii]);
            }
            AllyEffectTile.Clear();
        }

        /// <summary>
        /// 移動可能タイルをクリアします。
        /// </summary>
        private void ClearQuadTile()
        {
            for (int ii = 0; ii < MoveTile.Count; ii++)
            {
                MoveTile[ii].SetActive(false);
                Destroy(MoveTile[ii]);
            }
            MoveTile.Clear();
        }

        private void SearchMoveableLinear(ref List<Vector3> result, Vector3 p, int max, int direction, Unit.Ally ally, bool ristriction)
        {
            if (max <= 0) return;

            if (direction == 0)
            {
                AddCheckPointLinear(ref result, p, max, -HEX_MOVE_X, 0, direction, ally, ristriction);
                return;
            }
            if (direction == 1)
            {
                AddCheckPointLinear(ref result, p, max, 0, -HEX_MOVE_Z, direction, ally, ristriction);
                return;
            }
            if (direction == 2)
            {
                AddCheckPointLinear(ref result, p, max, 0, HEX_MOVE_Z, direction, ally, ristriction);
                return;

            }
            if (direction == 3)
            {
                AddCheckPointLinear(ref result, p, max, HEX_MOVE_X, 0, direction, ally, ristriction);
                return;

            }
        }

        private void AddCheckPointLinear(ref List<Vector3> result, Vector3 p, int max, float x, float y, int next, Unit.Ally ally, bool ristriction)
        {
            Vector3 checkPoint = new Vector3(p.x + x, p.y + y, p.z);
            int moveWeight = CheckMoveWeight(checkPoint, ally, ristriction);

            // 999は移動不可領域。移動可能量が移動コストより小さい場合チェックする。
            if (moveWeight >= 999) { return; }
            if (max - moveWeight < 0) { return; }

            AddCheckPoint(ref result, checkPoint, max - moveWeight);
            SearchMoveableLinear(ref result, checkPoint, max - moveWeight, next, ally, ristriction);
        }

        // p 検索対象元の地点
        // max 移動出来る量
        // direction 検索不要の方向（0:なし（全検索）、1:右不要、２：左不要、３：上不要、４：下不要)
        private void SearchMoveablePoint(ref List<Vector3> result, Vector3 p, int max, int direction, Unit.Ally ally, bool ristriction)
        {
            if (max <= 0) return;

            //Point情報から、上下左右１つずつ移動先のPointを計算
            // 上を検索
            if (direction != 5)
            {
                AddCheckPointRoutine(ref result, p, max, 0, HEX_MOVE_X, 0, ally, ristriction);
            }
            // 下を検索
            if (direction != 0)
            {
                AddCheckPointRoutine(ref result, p, max, 0, -HEX_MOVE_X, 5, ally, ristriction);
            }
            // 右を検索
            if (direction != 4)
            {
                AddCheckPointRoutine(ref result, p, max, HEX_MOVE_X, 0, 1, ally, ristriction);
            }
            // 左を検索
            if (direction != 1)
            {
                AddCheckPointRoutine(ref result, p, max, -HEX_MOVE_X, 0, 4, ally, ristriction);
            }
        }

        private void AddCheckPointRoutine(ref List<Vector3> result, Vector3 p, int max, float x, float y, int next, Unit.Ally ally, bool ristriction)
        {
            Vector3 checkPoint = new Vector3(p.x + x, p.y + y, p.z);
            int moveWeight = CheckMoveWeight(checkPoint, ally, ristriction);

            // 999は移動不可領域。移動可能量が移動コストより小さい場合チェックする。
            if (moveWeight >= 999) { return; }
            if (max - moveWeight < 0) { return; }

            AddCheckPoint(ref result, checkPoint, max - moveWeight);
            SearchMoveablePoint(ref result, checkPoint, max - moveWeight, next, ally, ristriction);
        }

        /// <summary>
        /// 移動コストを確認します。
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private int CheckMoveWeight(Vector3 p, Unit.Ally attr, bool ristriction)
        {
            for (int ii = 0; ii < fieldTile.Count; ii++)
            {
                if (ContainPositionX(fieldTile[ii].transform.localPosition.x, p.x) &&
                    p.y == fieldTile[ii].transform.localPosition.y &&
                    fieldTile[ii].gameObject.activeInHierarchy)
                {
                    if (ristriction)
                    {
                        Unit target = ExistUnitFromLocation(fieldTile[ii].transform.localPosition);
                        if (target != null)
                        {
                            if (attr == Unit.Ally.Ally && target.ally == Unit.Ally.Enemy)
                            {
                                return 999;
                            }
                            if (attr == Unit.Ally.Enemy && target.ally == Unit.Ally.Ally)
                            {
                                return 999;
                            }
                        }
                        return fieldTile[ii].MoveCost;
                    }
                    else
                    {
                        return 1;
                    }
                }
            }
            return 999;
        }

        /// <summary>
        /// 移動／攻撃可能範囲にタイル情報を含めます。
        /// </summary>
        /// <param name="result"></param>
        /// <param name="dst"></param>
        /// <param name="sub"></param>
        private void AddCheckPoint(ref List<Vector3> result, Vector3 dst, int sub)
        {
            for (int ii = 0; ii < result.Count; ii++)
            {
                if (ContainPositionX(result[ii].x, dst.x) &&
                    result[ii].y == dst.y)
                {
                    // 含めない
                    return;
                }
            }

            result.Add(dst);
        }

    }
}