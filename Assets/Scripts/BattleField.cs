using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DigitalRuby.PyroParticles;
using System;

namespace ObsidianPortal
{
    public partial class BattleField : MotherForm
    {
        #region "変数・定数"
        // プレハブ
        public GameObject[] prefab_Effect;
        public AreaInformation prefab_Tile;
        public AreaInformation prefab_Forest;
        public AreaInformation prefab_NoneTile;
        public GameObject prefab_Quad;
        public GameObject prefab_AttackTile;
        public GameObject prefab_AllyEffectTile;
        public GameObject prefab_HealTile;
        public Unit prefab_Fighter;
        public Unit prefab_Archer;
        public Unit prefab_Sorcerer;
        public Unit prefab_Priest;
        public Unit prefab_Enchanter;
        public Unit prefab_Wall;
        public GameObject prefab_Damage;
        // オブジェクト
        private List<Unit> AllList = new List<Unit>();
        private List<Unit> AllyList = new List<Unit>();
        private List<Unit> EnemyList = new List<Unit>();
        private List<AreaInformation> fieldTile = new List<AreaInformation>();
        private List<GameObject> MoveTile = new List<GameObject>();
        private List<GameObject> AttackTile = new List<GameObject>();
        private List<GameObject> AllyEffectTile = new List<GameObject>();
        private List<GameObject> HealTile = new List<GameObject>();
        public GameObject Cursor;
        public GameObject groupCommand;
        public GameObject lblCommand1;
        public GameObject lblCommand2;
        public GameObject lblCommand3;
        public GameObject CommandCursor;
        public GameObject groupUnitStatus;
        public GameObject[] LifeBox;
        public GameObject txtUnitName;
        public Image UniteLifeMeter;
        public Text UnitLifeText;
        public Image UnitImage;
        public GameObject panelMessage;
        public Text lblMessage;
        public Text txtPlayerName;
        public Text lblLevel;
        public Text txtLevel;
        public Image meterExp;
        public Text txtExp;
        public Image iconRace;
        public Text txtRace;
        public Text txtAttack;
        public Text txtDefense;
        public Text txtSpeed;
        public Text txtMagicAttack;
        public Text txtMagicDefense;
        public Text txtMove;
        public Text txtOrder;
        public Text txtTime;
        public List<GameObject> orbList = new List<GameObject>();
        // 定数
        const float HEX_MOVE_X = 1.732f;
        const float HEX_MOVE_Z = 1.500f;
        const float HEX_MOVE_X2 = 0.866f;
        // 実行中状態
        public enum ActionPhase
        {
            WaitActive = 0,
            SelectFirst,
            Upkeep,
            UpkeepAnimation,
            UpkeepExec,
            SelectMove,
            SelectCommand,
            SelectTarget,
            ExecAnimation,
            ExecCommand,
            End
        }
        private ActionPhase Phase = ActionPhase.WaitActive;

        public enum JudgeResult
        {
            Win,
            Lose,
            Draw
        }

        private bool GameEnd = false;

        // 一時記憶
        public Unit CurrentUnit;
        public Unit CurrentTarget;
        private Vector3 shadowPosition = new Vector3();
        private string currentCommand = string.Empty;
        private FIX.Direction currentDirection = FIX.Direction.None;
        private int currentDistance = 0;
        #endregion

        new void Start()
        {
            base.Start();
            RenderSettings.skybox = (Material)Resources.Load("Skybox4");
            ONE.Player.labelFullName = this.txtPlayerName;
            ONE.Player.labelRace = this.txtRace;
            ONE.Player.ImageRace = this.iconRace;
            ONE.Player.MeterExp = this.meterExp;

            // プレイヤー設定
            txtPlayerName.text = ONE.Player.FullName;
            for (int ii = 0; ii < ONE.Player.ObsidianStone; ii++)
            {
                orbList[ii].SetActive(true);
            }
            txtLevel.text = ONE.Player.Level.ToString();
            if (ONE.Player.Race == FIX.Race.Human) { txtRace.text = "人間族"; iconRace.GetComponent<Image>().sprite = Resources.Load<Sprite>("Icon_Human"); }
            else if (ONE.Player.Race == FIX.Race.Mech) { txtRace.text = "機巧族"; iconRace.GetComponent<Image>().sprite = Resources.Load<Sprite>("Icon_Mech"); }
            else if (ONE.Player.Race == FIX.Race.Angel) { txtRace.text = "天使族"; iconRace.GetComponent<Image>().sprite = Resources.Load<Sprite>("Icon_Angel"); }
            else if (ONE.Player.Race == FIX.Race.Demon) { txtRace.text = "魔貴族"; iconRace.GetComponent<Image>().sprite = Resources.Load<Sprite>("Icon_Demon"); }
            else if (ONE.Player.Race == FIX.Race.Fire) { txtRace.text = "炎霊族"; iconRace.GetComponent<Image>().sprite = Resources.Load<Sprite>("Icon_Fire"); }
            else if (ONE.Player.Race == FIX.Race.Ice) { txtRace.text = "氷霊族"; iconRace.GetComponent<Image>().sprite = Resources.Load<Sprite>("Icon_Ice"); }
            ONE.Player.UpdateExp();
            txtExp.text = "( " + ONE.Player.Exp.ToString() + " / " + ONE.Player.NextLevelBorder.ToString() + " )";


            #region "ステージのセットアップ"
            int column = DAT.COLUMN_1_1;
            int[] tileData = DAT.Tile1_1;
            if (ONE.CurrentStage == FIX.Stage.Stage1_1) { column = DAT.COLUMN_1_1; tileData = DAT.Tile1_1; }
            if (ONE.CurrentStage == FIX.Stage.Stage1_2) { column = DAT.COLUMN_1_2; tileData = DAT.Tile1_2; }
            if (ONE.CurrentStage == FIX.Stage.Stage1_3) { column = DAT.COLUMN_1_3; tileData = DAT.Tile1_3; }
            if (ONE.CurrentStage == FIX.Stage.Stage1_4) { column = DAT.COLUMN_1_4; tileData = DAT.Tile1_4; }
            if (ONE.CurrentStage == FIX.Stage.Stage1_5) { column = DAT.COLUMN_1_5; tileData = DAT.Tile1_5; }
            if (ONE.CurrentStage == FIX.Stage.Stage2_1) { column = DAT.COLUMN_2_1; tileData = DAT.Tile2_1; }
            if (ONE.CurrentStage == FIX.Stage.Stage2_2) { column = DAT.COLUMN_2_2; tileData = DAT.Tile2_2; }
            if (ONE.CurrentStage == FIX.Stage.Stage2_3) { column = DAT.COLUMN_2_3; tileData = DAT.Tile2_3; }
            if (ONE.CurrentStage == FIX.Stage.Stage2_4) { column = DAT.COLUMN_2_4; tileData = DAT.Tile2_4; }
            if (ONE.CurrentStage == FIX.Stage.Stage2_5) { column = DAT.COLUMN_2_5; tileData = DAT.Tile2_5; }

            for (int ii = 0; ii < tileData.Length; ii++)
            {
                AreaInformation current = this.prefab_Tile;
                current.field = AreaInformation.Field.Normal;
                if (tileData[ii] == 0)
                {
                    current = this.prefab_NoneTile;
                    current.field = AreaInformation.Field.None;
                }
                else if (tileData[ii] == 2)
                {
                    current = this.prefab_Forest;
                    current.field = AreaInformation.Field.Forest;
                }

                AreaInformation tile;
                if ((ii / column) % 2 == 0)
                {
                    tile = Instantiate(current, new Vector3(HEX_MOVE_X * (ii % column), 0, HEX_MOVE_Z * (ii / column)), Quaternion.identity) as AreaInformation;
                }
                else
                {
                    tile = Instantiate(current, new Vector3(HEX_MOVE_X * (ii % column) - FIX.HEX_MOVE_X2, 0, HEX_MOVE_Z * (ii / column)), Quaternion.identity) as AreaInformation;
                }
                tile.transform.Rotate(new Vector3(0, 90, 0));
                tile.gameObject.SetActive(true);
                if (tileData[ii] == 0)
                {
                    tile.gameObject.SetActive(false);
                }
                fieldTile.Add(tile);
            }

            if (ONE.CurrentStage == FIX.Stage.Stage1_1)
            {
                Debug.Log("stage Stage1_1");
                // ユニット配置(味方)
                SetupUnit(ref AllList, 1, false, Unit.RaceType.Human, Unit.UnitType.Fighter, 0, 0, true);
                // ユニット配置(敵)
                SetupUnit(ref AllList, 2, true, Unit.RaceType.Human, Unit.UnitType.Archer, 6, 0, true);
            }
            else if (ONE.CurrentStage == FIX.Stage.Stage1_2)
            {
                Debug.Log("stage Stage1_2");
                // ユニット配置(味方)
                SetupUnit(ref AllList, 1, false, Unit.RaceType.Human, Unit.UnitType.Fighter, 0, 0, true);
                SetupUnit(ref AllList, 2, false, Unit.RaceType.Human, Unit.UnitType.Archer, 0, 1, true);
                // ユニット配置(敵)
                SetupUnit(ref AllList, 3, true, Unit.RaceType.Human, Unit.UnitType.Archer, 7, 0, true);
                SetupUnit(ref AllList, 4, true, Unit.RaceType.Human, Unit.UnitType.Fighter, 7, 7, true);
            }
            else if (ONE.CurrentStage == FIX.Stage.Stage1_3)
            {
                Debug.Log("stage Stage1_3");

                // ユニット配置(味方)
                SetupUnit(ref AllList, 1, false, Unit.RaceType.Human, Unit.UnitType.Sorcerer, 2, 0, true);
                SetupUnit(ref AllList, 2, false, Unit.RaceType.Human, Unit.UnitType.Archer, 0, 1, true);
                SetupUnit(ref AllList, 3, false, Unit.RaceType.Human, Unit.UnitType.Priest, 0, 0, true);
                // ユニット配置(敵)
                SetupUnit(ref AllList, 4, true, Unit.RaceType.Human, Unit.UnitType.Archer, 5, 4, true);
                SetupUnit(ref AllList, 5, true, Unit.RaceType.Human, Unit.UnitType.Sorcerer, 4, 4, true);
                SetupUnit(ref AllList, 6, true, Unit.RaceType.Human, Unit.UnitType.Priest, 6, 6, true);
            }
            else if (ONE.CurrentStage == FIX.Stage.Stage1_4)
            {
                Debug.Log("stage Stage1_4");

                // ユニット配置(味方)
                SetupUnit(ref AllList, 1, false, Unit.RaceType.Human, Unit.UnitType.Fighter, 2, 0, true);
                SetupUnit(ref AllList, 2, false, Unit.RaceType.Human, Unit.UnitType.Archer, 0, 1, true);
                SetupUnit(ref AllList, 3, false, Unit.RaceType.Human, Unit.UnitType.Priest, 0, 0, true);
                // ユニット配置(敵)
                SetupUnit(ref AllList, 4, true, Unit.RaceType.Human, Unit.UnitType.Archer, 4, 3, true);
                SetupUnit(ref AllList, 5, true, Unit.RaceType.Human, Unit.UnitType.Fighter, 5, 4, true);
                SetupUnit(ref AllList, 6, true, Unit.RaceType.Human, Unit.UnitType.Priest, 4, 5, true);
            }
            else if (ONE.CurrentStage == FIX.Stage.Stage1_5)
            {
                Debug.Log("stage Stage1_5");

                // ユニット配置(味方)
                SetupUnit(ref AllList, 1, false, Unit.RaceType.Human, Unit.UnitType.Archer, 0, 7, true);
                SetupUnit(ref AllList, 2, false, Unit.RaceType.Human, Unit.UnitType.Archer, 1, 7, true);
                SetupUnit(ref AllList, 3, false, Unit.RaceType.Human, Unit.UnitType.Priest, 2, 7, true);
                // ユニット配置(敵)
                SetupUnit(ref AllList, 4, true, Unit.RaceType.Human, Unit.UnitType.Fighter, 7, 0, true);
                SetupUnit(ref AllList, 5, true, Unit.RaceType.Human, Unit.UnitType.Fighter, 7, 1, true);
                SetupUnit(ref AllList, 6, true, Unit.RaceType.Human, Unit.UnitType.Priest, 7, 2, true);
            }
            else if (ONE.CurrentStage == FIX.Stage.Stage2_1)
            {
                Debug.Log("stage Stage2_1");

                // ユニット配置(味方)
                SetupUnit(ref AllList, 1, false, Unit.RaceType.Angel, Unit.UnitType.Archer, 0, 3, true);
                SetupUnit(ref AllList, 2, false, Unit.RaceType.Angel, Unit.UnitType.Enchanter, 0, 4, true);
                SetupUnit(ref AllList, 3, false, Unit.RaceType.Human, Unit.UnitType.Priest, 1, 3, true);
                SetupUnit(ref AllList, 4, false, Unit.RaceType.Human, Unit.UnitType.Enchanter, 1, 2, true);
                // ユニット配置(敵)
                SetupUnit(ref AllList, 5, true, Unit.RaceType.Human, Unit.UnitType.Fighter, 6, 0, true);
            }
            else if (ONE.CurrentStage == FIX.Stage.Stage2_2)
            {
                Debug.Log("stage Stage2_2");

                // ユニット配置(味方)
                SetupUnit(ref AllList, 1, false, Unit.RaceType.Fire, Unit.UnitType.Enchanter, 0, 4, true);
                SetupUnit(ref AllList, 2, false, Unit.RaceType.Fire, Unit.UnitType.Fighter, 0, 3, true);
                // ユニット配置(敵)
                SetupUnit(ref AllList, 3, true, Unit.RaceType.Human, Unit.UnitType.Priest, 5, 2, true);
                SetupUnit(ref AllList, 4, true, Unit.RaceType.Human, Unit.UnitType.Sorcerer, 5, 3, true);
                SetupUnit(ref AllList, 5, true, Unit.RaceType.Human, Unit.UnitType.Enchanter, 5, 4, true);
            }
            else if (ONE.CurrentStage == FIX.Stage.Stage2_3)
            {
                Debug.Log("stage Stage2_3");

                // ユニット配置(味方)
                SetupUnit(ref AllList, 1, false, Unit.RaceType.Fire, Unit.UnitType.Archer, 0, 4, true);
                // ユニット配置(敵)
                SetupUnit(ref AllList, 2, true, Unit.RaceType.Human, Unit.UnitType.Priest, 4, 1, true);
                SetupUnit(ref AllList, 3, true, Unit.RaceType.Human, Unit.UnitType.Priest, 4, 2, true);
                SetupUnit(ref AllList, 4, true, Unit.RaceType.Human, Unit.UnitType.Priest, 4, 3, true);
            }
            else if (ONE.CurrentStage == FIX.Stage.Stage2_4)
            {
                Debug.Log("stage Stage2_4");

                // ユニット配置(味方)
                SetupUnit(ref AllList, 1, false, Unit.RaceType.Angel, Unit.UnitType.Sorcerer, 0, 4, true);
                // ユニット配置(敵)
                SetupUnit(ref AllList, 2, true, Unit.RaceType.Human, Unit.UnitType.Priest, 4, 1, true);
                SetupUnit(ref AllList, 3, true, Unit.RaceType.Human, Unit.UnitType.Priest, 4, 2, true);
                SetupUnit(ref AllList, 4, true, Unit.RaceType.Human, Unit.UnitType.Priest, 4, 3, true);
            }
            else if (ONE.CurrentStage == FIX.Stage.Stage2_5)
            {
                Debug.Log("stage Stage2_5");

                // ユニット配置(味方)
                SetupUnit(ref AllList, 1, false, Unit.RaceType.Fire, Unit.UnitType.Priest, 0, 4, true);
                // ユニット配置(敵)
                SetupUnit(ref AllList, 2, true, Unit.RaceType.Human, Unit.UnitType.Fighter, 5, 0, true);
            }
            #endregion
        }

        void Update()
        {
            #region "ゲーム終了"
            if (this.GameEnd)
            {
                if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
                {
                    SceneManager.LoadSceneAsync(0);
                }
                return;
            }
            #endregion

            #region "タイム進行とアクティブユニット探索"
            if (this.Phase == ActionPhase.WaitActive)
            {
                Unit detect = null;

                // タイマー０ですでに順番が来ていないかどうかチェックする。(Ally -> Enemyの順序)
                if (detect == null)
                {
                    for (int ii = 0; ii < AllyList.Count; ii++)
                    {
                        if (AllyList[ii].Dead == false && AllyList[ii].CurrentTime <= 0)
                        {
                            detect = AllyList[ii];
                            break;
                        }
                    }
                }

                if (detect == null)
                {
                    for (int ii = 0; ii < EnemyList.Count; ii++)
                    {
                        if (EnemyList[ii].Dead == false && EnemyList[ii].CurrentTime <= 0)
                        {
                            detect = EnemyList[ii];
                            break;
                        }
                    }
                }

                // タイマー更新（結果０以下になったらそれをDetect扱いとする） (Enemy -> Allyの順序)
                if (detect == null)
                {
                    for (int ii = 0; ii < EnemyList.Count; ii++)
                    {
                        if (EnemyList[ii].Dead == false)
                        {
                            EnemyList[ii].CurrentTime--;
                            if (EnemyList[ii].CurrentTime <= 0)
                            {
                                detect = EnemyList[ii];
                            }
                        }
                    }

                    for (int ii = 0; ii < AllyList.Count; ii++)
                    {
                        if (AllyList[ii].Dead == false)
                        {
                            AllyList[ii].CurrentTime--;
                            if (AllyList[ii].CurrentTime <= 0)
                            {
                                detect = AllyList[ii];
                            }
                        }
                    }
                }

                if (detect != null)
                {
                    this.CurrentUnit = detect; // ターゲットオブジェクトを記憶
                    this.shadowPosition = detect.transform.localPosition; // ターゲットの位置を記憶
                    this.CurrentUnit.CleanUp(); // クリーンナップ
                    this.Cursor.transform.localPosition = new Vector3(detect.transform.localPosition.x,
                                                                      Cursor.transform.localPosition.y,
                                                                      detect.transform.localPosition.z);
                    if (this.CurrentUnit.Type == Unit.UnitType.Wall)
                    {
                        this.Phase = ActionPhase.End;
                    }
                    else
                    {
                        this.Phase = ActionPhase.SelectFirst;
                    }
                    return;
                }
                return;
            }
            #endregion

            #region "敵フェーズ"
            if (this.CurrentUnit.IsAlly == false)
            {
                if (Phase == ActionPhase.SelectFirst)
                {
                    Debug.Log("ActionPhase.SelectFirst");
                    System.Threading.Thread.Sleep(500);
                    UpdateUnitStatus(this.CurrentUnit);
                    OpenMoveable(this.CurrentUnit);
                    this.Phase = ActionPhase.SelectMove;
                }
                else if (this.Phase == ActionPhase.SelectMove)
                {
                    Debug.Log("ActionPhase.SelectMove");
                    System.Threading.Thread.Sleep(500);

                    if (this.CurrentUnit.CurrentEarthBind > 0)
                    {
                        this.Phase = ActionPhase.SelectCommand;
                        return;
                    }

                    // 攻撃可能なユニットがいるかどうか確認。
                    List<Unit> attackable = SearchAttackableUnit(this.CurrentUnit, this.CurrentUnit.AttackRange);
                    if (attackable.Count > 0)
                    {
                        Debug.Log("ActionPhase.SelectMove: detect attackable: " + attackable.Count.ToString());
                        ClearQuadTile();

                        lblCommand1.GetComponent<TextMesh>().text = FIX.NORMAL_ATTACK;
                        lblCommand2.GetComponent<TextMesh>().text = CurrentUnit.SkillName;
                        lblCommand3.GetComponent<TextMesh>().text = FIX.NORMAL_END;
                        groupCommand.transform.localPosition = new Vector3(CurrentUnit.transform.localPosition.x + 2,
                                                                           CurrentUnit.transform.localPosition.y,
                                                                           CurrentUnit.transform.localPosition.z);
                        groupCommand.SetActive(true);
                        this.Phase = ActionPhase.SelectCommand;
                        return;
                    }

                    Debug.Log("ActionPhase.SelectMove: now moving...");

                    // 攻撃可能なユニットがいなければ、移動する。
                    // A.I. 攻撃ターゲットの探索対象は常にユニット順序とは限らない。
                    Unit targetUnit = AllyList[0];
                    FIX.Direction direction = FIX.Direction.Top;
                    for (int ii = 0; ii < AllyList.Count; ii++)
                    {
                        if (AllyList[ii].Dead == false)
                        {
                            targetUnit = AllyList[ii];
                            break;
                        }
                    }
                    if (targetUnit.transform.localPosition.x < CurrentUnit.transform.localPosition.x)
                    {
                        if (targetUnit.transform.localPosition.z == CurrentUnit.transform.localPosition.z)
                        {
                            direction = FIX.Direction.Top;
                        }
                        else if (targetUnit.transform.localPosition.z < CurrentUnit.transform.localPosition.z)
                        {
                            direction = FIX.Direction.TopLeft;
                        }
                        else
                        {
                            direction = FIX.Direction.TopRight;
                        }
                    }
                    else if (targetUnit.transform.localPosition.x > CurrentUnit.transform.localPosition.x)
                    {
                        if (targetUnit.transform.localPosition.z == CurrentUnit.transform.localPosition.z)
                        {
                            direction = FIX.Direction.Bottom;
                        }
                        else if (targetUnit.transform.localPosition.z < CurrentUnit.transform.localPosition.z)
                        {
                            direction = FIX.Direction.BottomLeft;
                        }
                        else
                        {
                            direction = FIX.Direction.BottomRight;
                        }
                    }

                    // 移動先がエリアが無い、もしくは、別のユニットが存在する場合、方向を調整します。
                    bool canMove = true;
                    if (direction == FIX.Direction.Top)
                    {
                        JudgeMove(FIX.Direction.Top, FIX.Direction.TopLeft, FIX.Direction.TopRight, out direction);
                    }
                    else if (direction == FIX.Direction.TopLeft)
                    {
                        JudgeMove(FIX.Direction.TopLeft, FIX.Direction.Top, FIX.Direction.BottomLeft, out direction);
                    }
                    else if (direction == FIX.Direction.TopRight)
                    {
                        JudgeMove(FIX.Direction.TopRight, FIX.Direction.Top, FIX.Direction.BottomRight, out direction);
                    }
                    else if (direction == FIX.Direction.Bottom)
                    {
                        JudgeMove(FIX.Direction.Bottom, FIX.Direction.BottomLeft, FIX.Direction.BottomRight, out direction);
                    }
                    else if (direction == FIX.Direction.BottomLeft)
                    {
                        JudgeMove(FIX.Direction.BottomLeft, FIX.Direction.TopLeft, FIX.Direction.Bottom, out direction);
                    }
                    else if (direction == FIX.Direction.BottomRight)
                    {
                        JudgeMove(FIX.Direction.BottomRight, FIX.Direction.TopRight, FIX.Direction.Bottom, out direction);
                    }
                    // 行き先がない場合、移動完了します。
                    if (direction == FIX.Direction.None)
                    {
                        this.CurrentUnit.CurrentMovePoint = 0;
                        canMove = false;
                    }

                    // 移動コストが大きい場合、移動完了します。
                    AreaInformation nextArea = ExistAreaFromLocation(this.CurrentUnit.GetNeighborhood(direction));
                    if (this.CurrentUnit.CurrentMovePoint < nextArea.MoveCost)
                    {
                        this.CurrentUnit.CurrentMovePoint = 0;
                        canMove = false;
                    }
                    if (this.CurrentUnit.CurrentEarthBind > 0)
                    {
                        canMove = false;
                    }

                    if (canMove)
                    {
                        // 移動開始
                        CurrentUnit.CurrentMovePoint -= nextArea.MoveCost;
                        CurrentUnit.Move(direction);
                        Cursor.transform.localPosition = new Vector3(CurrentUnit.transform.localPosition.x,
                                                                     Cursor.transform.localPosition.y,
                                                                     CurrentUnit.transform.localPosition.z);
                    }

                    if (CurrentUnit.CurrentMovePoint > 0)
                    {
                        return;
                    }

                    ClearQuadTile();

                    lblCommand1.GetComponent<TextMesh>().text = FIX.NORMAL_ATTACK;
                    lblCommand2.GetComponent<TextMesh>().text = CurrentUnit.SkillName;
                    lblCommand3.GetComponent<TextMesh>().text = FIX.NORMAL_END;
                    groupCommand.transform.localPosition = new Vector3(CurrentUnit.transform.localPosition.x + 2,
                                                                       CurrentUnit.transform.localPosition.y,
                                                                       CurrentUnit.transform.localPosition.z);
                    groupCommand.SetActive(true);
                    this.Phase = ActionPhase.SelectCommand;
                }
                else if (this.Phase == ActionPhase.SelectCommand)
                {
                    Debug.Log("ActionPhase.SelectCommand");
                    System.Threading.Thread.Sleep(500);

                    if (this.CurrentUnit.Race == Unit.RaceType.Human && this.CurrentUnit.Type == Unit.UnitType.Fighter && this.CurrentUnit.CurrentSilverArrow <= 0)
                    {
                        Debug.Log("ActionPhase.SelectCommand: Human Fighter SilverArrow");

                        List<Unit> attackable = SearchAttackableUnitLinearGroup(this.CurrentUnit, this.CurrentUnit.EffectRange);
                        Debug.Log("attackable: " + attackable.Count.ToString());
                        if (attackable.Count > 0)
                        {
                            Debug.Log("attackable: " + attackable.Count.ToString());
                            OpenAttackable(this.CurrentUnit, this.CurrentUnit.EffectRange, true);
                            int random = AP.Math.RandomInteger(attackable.Count);
                            this.CurrentTarget = attackable[random];
                            groupCommand.SetActive(false);
                            this.Phase = ActionPhase.SelectTarget;
                            return;
                        }
                        Debug.Log("attackable: " + attackable.Count.ToString());
                    }
                    else
                    {
                        List<Unit> attackable = SearchAttackableUnit(this.CurrentUnit, this.CurrentUnit.AttackRange);
                        if (attackable.Count > 0)
                        {
                            OpenAttackable(this.CurrentUnit, this.CurrentUnit.AttackRange, false);
                            int random = AP.Math.RandomInteger(attackable.Count);
                            this.CurrentTarget = attackable[random];
                            groupCommand.SetActive(false);
                            this.Phase = ActionPhase.SelectTarget;
                            return;
                        }
                    }

                    // A.I [ATTACK][SKILL]
                    Debug.Log("ActionPhase.SelectCommand (END)");
                    groupCommand.SetActive(false);
                    this.Phase = ActionPhase.End;
                }
                else if (this.Phase == ActionPhase.SelectTarget)
                {
                    Debug.Log("ActionPhase.SelectTarget");
                    System.Threading.Thread.Sleep(500);

                    if (this.CurrentUnit.Race == Unit.RaceType.Human && this.CurrentUnit.Type == Unit.UnitType.Fighter && this.CurrentUnit.CurrentSilverArrow <= 0)
                    {
                        Debug.Log("ActionPhase.SelectTarget:Human Fighter SilverArrow");

                        int move = 0;
                        FIX.Direction direction = FIX.Direction.Top;
                        if (ExistAttackableUnitLinear(ref move, this.CurrentUnit, this.CurrentTarget, this.CurrentUnit.EffectRange, FIX.Direction.Top))
                        {
                            direction = FIX.Direction.Top;
                        }
                        else if (ExistAttackableUnitLinear(ref move, this.CurrentUnit, this.CurrentTarget, this.CurrentUnit.EffectRange, FIX.Direction.TopRight))
                        {
                            direction = FIX.Direction.TopRight;
                        }
                        else if (ExistAttackableUnitLinear(ref move, this.CurrentUnit, this.CurrentTarget, this.CurrentUnit.EffectRange, FIX.Direction.BottomRight))
                        {
                            direction = FIX.Direction.BottomRight;
                        }
                        else if (ExistAttackableUnitLinear(ref move, this.CurrentUnit, this.CurrentTarget, this.CurrentUnit.EffectRange, FIX.Direction.TopLeft))
                        {
                            direction = FIX.Direction.TopLeft;
                        }
                        else if (ExistAttackableUnitLinear(ref move, this.CurrentUnit, this.CurrentTarget, this.CurrentUnit.EffectRange, FIX.Direction.BottomLeft))
                        {
                            direction = FIX.Direction.BottomLeft;
                        }
                        else if (ExistAttackableUnitLinear(ref move, this.CurrentUnit, this.CurrentTarget, this.CurrentUnit.EffectRange, FIX.Direction.Bottom))
                        {
                            direction = FIX.Direction.Bottom;
                        }
                        else
                        {
                            Debug.Log("DASH detect other...");
                        }
                        for (int ii = 0; ii < move; ii++)
                        {
                            //if (this.CurrentUnit.CurrentEarthBind > 0) // アースバインドでダッシュの移動を防ぐことはできない。
                            this.CurrentUnit.Move(direction);
                        }
                        Debug.Log("ActionPhase.SelectTarget:ExecDamage: " + ActionCommand.EffectValue(this.currentCommand).ToString());
                        ExecDamage(this.CurrentTarget, ActionCommand.EffectValue(this.currentCommand) + this.CurrentTarget.CurrentReachabletargetValue - this.CurrentTarget.DefenseValue);

                        Debug.Log("ActionPhase.SelectTarget:now ClearAttackTile");
                        ClearAttackTile();
                        JudgeGameEnd();
                        Debug.Log("ActionPhase.SelectTarget:(END)");
                        this.Phase = ActionPhase.End;
                    }
                    else
                    {
                        List<Unit> attackable = SearchAttackableUnit(this.CurrentUnit, this.CurrentUnit.AttackRange);
                        if (attackable.Count > 0)
                        {
                            Debug.Log("ActionPhase.SelectTarget: target " + this.CurrentTarget.name + " " + this.CurrentTarget.CurrentLife.ToString());
                            this.CurrentTarget.CurrentLife -= this.CurrentUnit.AttackValue + this.CurrentTarget.CurrentReachabletargetValue - this.CurrentTarget.DefenseValue;
                            UpdateLife(this.CurrentTarget);
                            Debug.Log("ActionPhase.SelectTarget: after " + this.CurrentTarget.name + " " + this.CurrentTarget.CurrentLife.ToString());
                            if (this.CurrentTarget.CurrentLife <= 0)
                            {
                                this.CurrentTarget.Dead = true;
                                this.CurrentTarget.gameObject.SetActive(false);
                                AllyList.Remove(this.CurrentTarget);
                            }
                            ClearAttackTile();
                            JudgeGameEnd();
                            this.Phase = ActionPhase.End;
                        }
                    }
                }
                else if (this.Phase == ActionPhase.End)
                {
                    Debug.Log("ActionPhase.End");
                    System.Threading.Thread.Sleep(500);
                    CurrentUnit.Completed();
                    JudgeGameEnd();
                    this.currentCommand = String.Empty;
                    this.currentDirection = FIX.Direction.None;
                    this.currentDistance = 0;
                    this.CurrentUnit = null;
                    this.CurrentTarget = null;
                    this.shadowPosition = new Vector3();
                    this.Phase = ActionPhase.WaitActive;
                }
                return;
            }
            #endregion

            #region "味方フェーズ"
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // カーソル移動
            if (Physics.Raycast(ray, out hit, 100))
            {
                GameObject obj = hit.collider.gameObject;
                // フィールド操作
                Cursor.transform.localPosition = new Vector3(obj.transform.localPosition.x, Cursor.transform.localPosition.y, obj.transform.localPosition.z);
                Unit loc = ExistUnitFromLocation(Cursor.transform.localPosition);
                if (loc != null)
                {
                    UpdateUnitStatus(loc);
                }
            }

            // 最初のフェーズ
            if (this.Phase == ActionPhase.SelectFirst)
            {
                UpdateUnitStatus(this.CurrentUnit);
                OpenMoveable(this.CurrentUnit);
                this.Phase = ActionPhase.Upkeep;
            }
            // アップキープ
            else if (this.Phase == ActionPhase.Upkeep)
            {
                if (this.CurrentUnit.CurrentHealingWord > 0)
                {
                    StartAnimation(this.CurrentUnit, "LIFE +3", Color.yellow);
                    this.Phase = ActionPhase.UpkeepAnimation;
                    return;
                }
                this.Phase = ActionPhase.SelectMove;
            }
            else if (this.Phase == ActionPhase.UpkeepAnimation)
            {
                ExecAnimationDamage();
                if (this.currentPrefabObject != null)
                {
                    return;
                }
                if (this.nowAnimationCounter <= MAX_ANIMATION)
                {
                    return;
                }
                this.Phase = ActionPhase.UpkeepExec;
            }
            else if (this.Phase == ActionPhase.UpkeepExec)
            {
                if (this.CurrentUnit.CurrentHealingWord > 0)
                {
                    ExecHeal(this.CurrentUnit, this.CurrentUnit, 3);
                }
                this.Phase = ActionPhase.SelectMove;
            }
            // 移動先を選択
            else if (this.Phase == ActionPhase.SelectMove)
            {
                if (this.CurrentUnit.CurrentEarthBind > 0)
                {
                    this.Phase = ActionPhase.SelectCommand;
                    return;
                }

                if (CheckMoveableArea(Cursor.transform.localPosition) && Input.GetMouseButtonDown(0))
                {
                    Debug.Log("mousedown, nowselectmoveale");
                    Unit target = ExistUnitFromLocation(Cursor.transform.localPosition);
                    if (target != null && target.Equals(this.CurrentUnit) == false)
                    {
                        Debug.Log("already exist unit, then no action.");
                        return;
                    }
                    CurrentUnit.transform.localPosition = new Vector3(Cursor.transform.localPosition.x,
                                                                        CurrentUnit.transform.localPosition.y,
                                                                        Cursor.transform.localPosition.z);
                    ClearQuadTile();

                    lblCommand1.GetComponent<TextMesh>().text = FIX.NORMAL_ATTACK;
                    lblCommand2.GetComponent<TextMesh>().text = CurrentUnit.SkillName;
                    lblCommand3.GetComponent<TextMesh>().text = FIX.NORMAL_END;
                    groupCommand.transform.localPosition = new Vector3(CurrentUnit.transform.localPosition.x + 2,
                                                                        CurrentUnit.transform.localPosition.y,
                                                                        CurrentUnit.transform.localPosition.z);
                    groupCommand.SetActive(true);
                    this.Phase = ActionPhase.SelectCommand;
                }
            }
            // コマンド選択時
            else if (this.Phase == ActionPhase.SelectCommand)
            {
                int LayerNo = LayerMask.NameToLayer(FIX.LAYER_UNITCOMMAND);
                int layerMask = 1 << LayerNo;
                if (Physics.Raycast(ray, out hit, 100, layerMask) && Input.GetMouseButtonDown(0))
                {
                    GameObject obj = hit.collider.gameObject;
                    CommandCursor.transform.localPosition = new Vector3(obj.transform.localPosition.x,
                                                                            obj.transform.localPosition.y - 0.01f,
                                                                            obj.transform.localPosition.z);

                    groupCommand.SetActive(false);
                    // コマンドメニュー操作
                    if (obj.name == "back_Command1")
                    {
                        this.currentCommand = FIX.NORMAL_ATTACK;
                        OpenAttackable(this.CurrentUnit, this.CurrentUnit.AttackRange, false);
                        this.Phase = ActionPhase.SelectTarget;
                    }
                    if (obj.name == "back_Command2")
                    {
                        this.currentCommand = this.CurrentUnit.SkillName;
                        // 単一の敵対象
                        if (ActionCommand.GetTargetType(this.currentCommand) == ActionCommand.TargetType.Enemy)
                        {
                            if (this.currentCommand == FIX.DASH)
                            {
                                OpenAttackable(this.CurrentUnit, this.CurrentUnit.EffectRange, true);
                            }
                            else if (this.currentCommand == FIX.EXPLOSION)
                            {
                                OpenAttackable(this.CurrentUnit, this.CurrentUnit.EffectRange, true);
                            }
                            else
                            {
                                OpenAttackable(this.CurrentUnit, this.CurrentUnit.AttackRange, false);
                            }
                        }
                        // 単一の味方対象(効果/回復)
                        else if (ActionCommand.GetTargetType(this.currentCommand) == ActionCommand.TargetType.Ally)
                        {
                            // 回復
                            if (ActionCommand.IsHeal(this.currentCommand))
                            {
                                OpenHealable(this.CurrentUnit);
                            }
                            // 効果
                            else
                            {
                                OpenAllyEffectable(this.CurrentUnit);
                            }
                        }
                        // 自分自身
                        else if (ActionCommand.GetTargetType(this.currentCommand) == ActionCommand.TargetType.Own)
                        {
                            // 何も表示せず、次のフェーズへ
                        }
                        // 対象なし（自分中央でエリア範囲）
                        else if (ActionCommand.GetTargetType(this.currentCommand) == ActionCommand.TargetType.AllyGroup)
                        {
                            // 何も表示せず、次のフェーズへ
                        }
                        else if (this.currentCommand == FIX.BLAZE)
                        {
                            OpenAttackable(this.CurrentUnit, this.CurrentUnit.EffectRange, true);
                        }
                        else if (this.currentCommand == FIX.LAVAWALL)
                        {
                            OpenAttackable(this.CurrentUnit, this.CurrentUnit.EffectRange, false);
                        }
                        this.Phase = ActionPhase.SelectTarget;
                    }
                    if (obj.name == "back_Command3")
                    {
                        CurrentUnit.Completed();
                        this.Phase = ActionPhase.End;
                    }
                }
            }
            // コマンド実行対象の選択
            else if (this.Phase == ActionPhase.SelectTarget)
            {
                bool detectAction = false;
                if (ActionCommand.GetTargetType(this.currentCommand) == ActionCommand.TargetType.Own)
                {
                    // 自分自身が対象なので即座に次へ
                    detectAction = true;
                    if (this.currentCommand == FIX.FIREBLADE)
                    {
                        this.CurrentTarget = this.CurrentUnit;
                        StartAnimation(this.CurrentUnit, "STR + " + ActionCommand.EffectValue(this.currentCommand).ToString(), Color.yellow);
                    }
                    else if (this.currentCommand == FIX.HOLYBULLET)
                    {
                        this.CurrentTarget = null;
                        StartAnimation(this.CurrentUnit, "HOLY", new Color(1.0f, 0.3f, 0.3f));
                    }
                }
                else if (Input.GetMouseButtonDown(0))
                {
                    // 単一の敵対象
                    if (ActionCommand.GetTargetType(this.currentCommand) == ActionCommand.TargetType.Enemy &&
                        CheckAttackableArea(Cursor.transform.localPosition))
                    {
                        detectAction = true;
                        Unit target = ExistUnitFromLocation(Cursor.transform.localPosition);
                        if (target == null)
                        {
                            Debug.Log("unit is not exist, then no action.");
                            return;
                        }
                        if (target.IsAlly)
                        {
                            Debug.Log("unit is ally, then no action");
                            return;
                        }
                        this.CurrentTarget = target;

                        if (this.currentCommand == FIX.DASH)
                        {
                            int move = 0;
                            FIX.Direction direction = ExistAttackableUnitLinerGroup(ref move, this.CurrentUnit, this.CurrentTarget, this.CurrentUnit.EffectRange);
                            for (int ii = 0; ii < move; ii++)
                            {
                                //if (this.CurrentUnit.CurrentEarthBind > 0) // アースバインドでダッシュの移動を防ぐことはできない。
                                this.CurrentUnit.Move(direction);
                            }
                            int damage = ActionCommand.EffectValue(this.currentCommand) + this.CurrentTarget.CurrentReachabletargetValue - this.CurrentTarget.DefenseValue;
                            StartAnimation(this.CurrentTarget, damage.ToString(), new Color(1.0f, 0.3f, 0.3f));
                        }
                        else if (this.currentCommand == FIX.NEEDLESPEAR || this.currentCommand == FIX.SILVERARROW)
                        {
                            int damage = ActionCommand.EffectValue(this.currentCommand) + this.CurrentTarget.CurrentReachabletargetValue - this.CurrentTarget.DefenseValue;
                            StartAnimation(this.CurrentTarget, damage.ToString(), new Color(1.0f, 0.3f, 0.3f));
                        }
                        else if (this.currentCommand == FIX.EARTHBIND)
                        {
                            StartAnimation(this.CurrentTarget, "BIND", new Color(1.0f, 0.3f, 0.3f));
                        }
                        else if (this.currentCommand == FIX.EXPLOSION)
                        {
                            int damage = ActionCommand.EffectValue(this.currentCommand) + this.CurrentTarget.CurrentReachabletargetValue - this.CurrentTarget.DefenseValue;
                            StartAnimation(this.CurrentTarget, damage.ToString(), new Color(1.0f, 0.3f, 0.3f));
                        }
                        else if (this.currentCommand == FIX.REACHABLETARGET)
                        {
                            StartAnimation(this.CurrentTarget, "TARGET", new Color(1.0f, 0.3f, 0.3f));
                        }
                        else
                        {
                            int damage = this.CurrentUnit.AttackValue + this.CurrentTarget.CurrentReachabletargetValue - this.CurrentTarget.DefenseValue;
                            StartAnimation(this.CurrentTarget, damage.ToString(), new Color(1.0f, 0.3f, 0.3f));
                        }
                    }
                    // 単一の味方対象(効果/回復)
                    else if (ActionCommand.GetTargetType(this.currentCommand) == ActionCommand.TargetType.Ally)
                    {
                        // 回復
                        if (ActionCommand.IsHeal(this.currentCommand) && CheckHealableArea(Cursor.transform.localPosition))
                        {
                            detectAction = true;
                            Unit target = ExistUnitFromLocation(Cursor.transform.localPosition);
                            if (target == null)
                            {
                                Debug.Log("unit is not exist, then no action.");
                                return;
                            }
                            if (target.IsAlly == false)
                            {
                                Debug.Log("unit is enemy, then no action");
                                return;
                            }

                            this.CurrentTarget = target;
                            StartAnimation(this.CurrentTarget, ActionCommand.EffectValue(this.currentCommand).ToString(), Color.yellow);
                        }
                        // 効果
                        else if (CheckAllyEffectArea(Cursor.transform.localPosition))
                        {
                            detectAction = true;
                            Unit target = ExistUnitFromLocation(Cursor.transform.localPosition);
                            if (target == null)
                            {
                                Debug.Log("unit is not exist, then no action.");
                                return;
                            }
                            if (target.IsAlly == false)
                            {
                                Debug.Log("unit is enemy, then no action");
                                return;
                            }
                            this.CurrentTarget = target;
                            if (this.currentCommand == FIX.POWERWORD)
                            {
                                StartAnimation(this.CurrentTarget, "STR +" + ActionCommand.EffectValue(this.currentCommand).ToString(), Color.yellow);
                            }
                            else if (this.currentCommand == FIX.PROTECTION)
                            {
                                StartAnimation(this.CurrentTarget, "DEF +" + ActionCommand.EffectValue(this.currentCommand).ToString(), Color.yellow);
                            }
                            else if (this.currentCommand == FIX.HEATBOOST)
                            {
                                StartAnimation(this.CurrentUnit, "SPD +" + ActionCommand.EffectValue(this.currentCommand).ToString(), Color.yellow);
                            }
                        }
                    }
                    else if (this.currentCommand == FIX.BLAZE && CheckAttackableArea(Cursor.transform.localPosition))
                    {
                        FIX.Direction direction = FIX.Direction.None;
                        int move = 0;
                        if (IsLinear(ref direction, ref move, this.CurrentUnit.transform.position, Cursor.transform.position))
                        {
                            detectAction = true;
                            this.currentDirection = direction;
                            this.currentDistance = move;
                            StartAnimation(this.CurrentUnit, "Blaze", Color.yellow);
                        }
                    }
                    else if (this.currentCommand == FIX.LAVAWALL && CheckAttackableArea(Cursor.transform.localPosition))
                    {
                        FIX.Direction direction = FIX.Direction.None;
                        int move = 0;
                        if (IsLinear(ref direction, ref move, this.CurrentUnit.transform.position, Cursor.transform.position))
                        {
                            detectAction = true;
                            this.currentDirection = direction;
                            this.currentDistance = move;
                            StartAnimation(this.CurrentUnit, "LAVAWALL", Color.yellow);
                        }
                    }
                }
                if (detectAction)
                {
                    ClearAttackTile();
                    ClearHealTile();
                    ClearAllyEffectTile();
                    JudgeGameEnd();
                    int number = ActionCommand.GetSkillNumbering(this.currentCommand);
                    if (number <= -1)
                    {
                        this.Phase = ActionPhase.End;
                        return;
                    }

                    BeginEffect(ActionCommand.GetSkillNumbering(this.currentCommand));
                    this.Phase = ActionPhase.ExecAnimation;
                }
            }
            // アニメーション実行
            else if (this.Phase == ActionPhase.ExecAnimation)
            {
                ExecAnimationDamage();
                if (this.currentPrefabObject != null)
                {
                    return;
                }
                if (this.nowAnimationCounter <= MAX_ANIMATION)
                {
                    return;
                }
                this.Phase = ActionPhase.ExecCommand;
            }
            // 実処理実行
            else if (this.Phase == ActionPhase.ExecCommand)
            {
                Debug.Log("ExecCommand: " + this.currentCommand);
                if (this.currentCommand == FIX.NORMAL_ATTACK)
                {
                    ExecDamage(this.CurrentTarget, this.CurrentUnit.AttackValue + this.CurrentTarget.CurrentReachabletargetValue - this.CurrentTarget.DefenseValue);
                }
                else if (this.currentCommand == FIX.DASH)
                {
                    ExecDamage(this.CurrentTarget, ActionCommand.EffectValue(this.currentCommand) + this.CurrentTarget.CurrentReachabletargetValue - this.CurrentTarget.DefenseValue);
                }
                else if (this.currentCommand == FIX.REACHABLETARGET)
                {
                    ExecReachableTarget(this.CurrentUnit, this.CurrentTarget);
                }
                else if (this.currentCommand == FIX.EARTHBIND)
                {
                    ExecEarthBind(this.CurrentUnit, this.CurrentTarget);
                }
                else if (this.currentCommand == FIX.POWERWORD)
                {
                    ExecPowerWord(this.CurrentUnit, this.CurrentTarget);
                }
                else if (this.currentCommand == FIX.HEALINGWORD)
                {
                    ExecHeal(this.CurrentUnit, this.CurrentTarget, ActionCommand.EffectValue(this.currentCommand));
                    ExecHealingWord(this.CurrentUnit, this.CurrentTarget);
                }
                else if (this.currentCommand == FIX.NEEDLESPEAR)
                {
                    ExecDamage(this.CurrentTarget, ActionCommand.EffectValue(this.currentCommand) + this.CurrentTarget.CurrentReachabletargetValue - this.CurrentTarget.DefenseValue);

                    int dummy = 0;
                    FIX.Direction direction = ExistAttackableUnitLinerGroup(ref dummy, this.CurrentUnit, this.CurrentTarget, this.CurrentUnit.EffectRange);
                    this.CurrentTarget.Move(direction); // 敵を一歩後退させる。
                }
                else if (this.currentCommand == FIX.SILVERARROW)
                {
                    ExecDamage(this.CurrentTarget, ActionCommand.EffectValue(this.currentCommand) + this.CurrentTarget.CurrentReachabletargetValue - this.CurrentTarget.DefenseValue);
                    ExecSilence(this.CurrentTarget);
                }
                else if (this.currentCommand == FIX.HOLYBULLET)
                {
                    FIX.Direction[] direction = { FIX.Direction.Top, FIX.Direction.TopRight, FIX.Direction.BottomRight, FIX.Direction.TopLeft, FIX.Direction.BottomLeft, FIX.Direction.Bottom };
                    for (int ii = 0; ii < direction.Length; ii++)
                    {
                        Unit unit = ExistUnitFromLocation(this.CurrentUnit.GetNeighborhood(direction[ii]));
                        if (unit != null)
                        {
                            Debug.Log("detect holy target");
                            ExecDamage(unit, ActionCommand.EffectValue(FIX.HOLYBULLET) + unit.CurrentReachabletargetValue - unit.DefenseValue);
                        }
                        else
                        {
                            Debug.Log("holy target null...");
                        }
                    }
                }
                else if (this.currentCommand == FIX.PROTECTION)
                {
                    ExecProtection(this.CurrentUnit, this.CurrentTarget);
                }
                else if (this.currentCommand == FIX.FRESHHEAL)
                {
                    ExecHeal(this.CurrentUnit, this.CurrentTarget, ActionCommand.EffectValue(this.currentCommand));
                }
                else if (this.currentCommand == FIX.FIREBLADE)
                {
                    ExecFireBlade(this.CurrentUnit);
                }
                else if (this.currentCommand == FIX.LAVAWALL)
                {
                    ExecLavaWall(this.CurrentUnit, currentDirection);
                }
                else if (this.currentCommand == FIX.BLAZE)
                {
                    for (int ii = 0; ii < this.CurrentUnit.EffectRange; ii++)
                    {
                        float x = 0;
                        float z = 0;
                        if (currentDirection == FIX.Direction.Top) { x = -FIX.HEX_MOVE_X * (ii + 1); z = 0; }
                        else if (currentDirection == FIX.Direction.TopRight) { x = -FIX.HEX_MOVE_X2 * (ii + 1); z = FIX.HEX_MOVE_Z * (ii + 1); }
                        else if (currentDirection == FIX.Direction.BottomRight) { x = FIX.HEX_MOVE_X2 * (ii + 1); z = FIX.HEX_MOVE_Z * (ii + 1); }
                        else if (currentDirection == FIX.Direction.TopLeft) { x = -FIX.HEX_MOVE_X2 * (ii + 1); z = -FIX.HEX_MOVE_Z * (ii + 1); }
                        else if (currentDirection == FIX.Direction.BottomLeft) { x = FIX.HEX_MOVE_X2 * (ii + 1); z = -FIX.HEX_MOVE_Z * (ii + 1); }
                        else if (currentDirection == FIX.Direction.Bottom) { x = FIX.HEX_MOVE_X * (ii + 1); z = 0; }
                        Unit target = ExistUnitFromLocation(new Vector3(this.CurrentUnit.transform.position.x + x,
                                                                         this.CurrentUnit.transform.position.y,
                                                                         this.CurrentUnit.transform.position.z + z));
                        if (target != null && target.Type != Unit.UnitType.Wall)
                        {
                            Debug.Log("Blaze detect: " + target.transform.localPosition.ToString());
                            int value = ActionCommand.EffectValue(this.currentCommand) + target.CurrentReachabletargetValue - target.DefenseValue;
                            ExecDamage(target, value);
                        }
                    }
                }
                else if (this.currentCommand == FIX.HEATBOOST)
                {
                    ExecHeatBoost(this.CurrentUnit, this.CurrentTarget);
                }
                else if (this.currentCommand == FIX.EXPLOSION)
                {
                    int value = ActionCommand.EffectValue(this.currentCommand) + this.CurrentTarget.CurrentReachabletargetValue - this.CurrentTarget.DefenseValue;
                    ExecDamage(this.CurrentTarget, value);
                    this.CurrentUnit.CurrentLife = 0;
                    this.CurrentUnit.Dead = true;
                    this.CurrentUnit.gameObject.SetActive(false);
                    EnemyList.Remove(this.CurrentUnit);
                }
                this.Phase = ActionPhase.End;
            }
            // 終了
            else if (this.Phase == ActionPhase.End)
            {
                CurrentUnit.Completed();
                JudgeGameEnd();
                this.currentCommand = String.Empty;
                this.currentDirection = FIX.Direction.None;
                this.currentDistance = 0;
                this.CurrentUnit = null;
                this.CurrentTarget = null;
                this.shadowPosition = new Vector3();
                this.Phase = ActionPhase.WaitActive;
            }
            #endregion
        }

        #region "Canvasイベント"
        public void tapCommand1()
        {
            groupCommand.SetActive(false);
        }
        public void tapCommand2()
        {
            groupCommand.SetActive(false);
        }
        public void tapCommand3()
        {
            groupCommand.SetActive(false);
        }

        public void tapMoveTop()
        {
            CurrentUnit.transform.localPosition = new Vector3(CurrentUnit.transform.localPosition.x - HEX_MOVE_X,
                                                               CurrentUnit.transform.localPosition.y,
                                                               CurrentUnit.transform.localPosition.z);
        }
        public void tapMoveLeftUp()
        {
            CurrentUnit.transform.localPosition = new Vector3(CurrentUnit.transform.localPosition.x - HEX_MOVE_X / 2,
                                                               CurrentUnit.transform.localPosition.y,
                                                               CurrentUnit.transform.localPosition.z - HEX_MOVE_Z);
        }
        public void tapMoveLeftDown()
        {
            CurrentUnit.transform.localPosition = new Vector3(CurrentUnit.transform.localPosition.x + HEX_MOVE_X2,
                                                               CurrentUnit.transform.localPosition.y,
                                                               CurrentUnit.transform.localPosition.z - HEX_MOVE_Z);
        }
        public void tapMoveRightUp()
        {
            CurrentUnit.transform.localPosition = new Vector3(CurrentUnit.transform.localPosition.x - HEX_MOVE_X2,
                                                               CurrentUnit.transform.localPosition.y,
                                                               CurrentUnit.transform.localPosition.z + HEX_MOVE_Z);
        }
        public void tapMoveRightDown()
        {
            CurrentUnit.transform.localPosition = new Vector3(CurrentUnit.transform.localPosition.x + HEX_MOVE_X2,
                                                               CurrentUnit.transform.localPosition.y,
                                                               CurrentUnit.transform.localPosition.z + HEX_MOVE_Z);
        }
        public void tapMoveBottom()
        {
            CurrentUnit.transform.localPosition = new Vector3(CurrentUnit.transform.localPosition.x + HEX_MOVE_X,
                                                               CurrentUnit.transform.localPosition.y,
                                                               CurrentUnit.transform.localPosition.z);
        }
        public void tapSelect()
        {
            OpenMoveable(CurrentUnit);
        }
        public void tapCancel()
        {
            ExecCancel();
        }
        #endregion

        private void ExecSilence(Unit target, int value = 1)
        {
            target.CurrentSilverArrow = value;
        }
        private GameObject currentPrefabObject = null;
        private FireBaseScript currentPrefabScript;


        private void BeginEffect(int number)
        {
            Vector3 pos;
            float yRot = this.CurrentUnit.transform.rotation.eulerAngles.y;
            Vector3 forwardY = Quaternion.Euler(0.0f, yRot, 0.0f) * Vector3.forward;
            Vector3 forward = this.CurrentUnit.transform.forward;
            Vector3 right = this.CurrentUnit.transform.right;
            Vector3 up = this.CurrentUnit.transform.up;
            Quaternion rotation = Quaternion.identity;
            currentPrefabObject = GameObject.Instantiate(prefab_Effect[number]);
            currentPrefabScript = currentPrefabObject.GetComponent<FireConstantBaseScript>();

            if (currentPrefabScript == null)
            {
                // temporary effect, like a fireball
                currentPrefabScript = currentPrefabObject.GetComponent<FireBaseScript>();
                if (currentPrefabScript.IsProjectile)
                {
                    // set the start point near the player
                    rotation = this.CurrentUnit.transform.rotation;
                    pos = this.CurrentUnit.transform.position;// +forward + right + up;
                }
                else
                {
                    // set the start point in front of the player a ways
                    pos = this.CurrentUnit.transform.position;// +(forwardY * 10.0f);
                }
            }
            else
            {
                // set the start point in front of the player a ways, rotated the same way as the player
                pos = this.CurrentUnit.transform.position;// +(forwardY * 5.0f);
                rotation = this.CurrentUnit.transform.rotation;
                pos.y = 0.0f;
            }

            FireProjectileScript projectileScript = currentPrefabObject.GetComponentInChildren<FireProjectileScript>();
            if (projectileScript != null)
            {
                // make sure we don't collide with other friendly layers
                projectileScript.ProjectileCollisionLayers &= (~UnityEngine.LayerMask.NameToLayer("FriendlyLayer"));
            }

            currentPrefabObject.transform.position = pos;
            currentPrefabObject.transform.rotation = rotation;
        }

        private void UpdateLife(Unit unit)
        {
            UnitLifeText.text = unit.CurrentLife.ToString() + "  /  " + unit.MaxLife.ToString();

            float dx = (float)unit.CurrentLife / (float)unit.MaxLife;
            if (this.UniteLifeMeter != null)
            {
                this.UniteLifeMeter.rectTransform.localScale = new Vector2(dx, 1.0f);
            }
        }

        private void UpdateUnitImage(Unit unit)
        {
            UnitImage.sprite = Resources.Load<Sprite>("Unit_" + unit.Type.ToString());
        }


        private string nowAnimationString = String.Empty;
        private GameObject currentDamageObject = null;
        private int nowAnimationCounter = 0;
        private int MAX_ANIMATION = 100;
        Vector3 ExecAnimation_basePoint;

        private void StartAnimation(Unit unit, string message, Color color)
        {
            Debug.Log("StartAnimationDamage");
            if (this.currentDamageObject == null)
            {
                Debug.Log("StartAnimationDamage(2)");
                this.currentDamageObject = GameObject.Instantiate(prefab_Damage);
            }

            this.nowAnimationCounter = 0;
            this.currentDamageObject.GetComponent<TextMesh>().color = color;
            this.currentDamageObject.transform.position = unit.transform.position;
            this.currentDamageObject.SetActive(true);
            this.nowAnimationString = message;
        }
        private void ExecAnimationDamage()
        {
            if (this.currentDamageObject == null) { return; }

            currentDamageObject.GetComponent<TextMesh>().text = nowAnimationString;
            if (this.nowAnimationCounter <= 0)
            {
                ExecAnimation_basePoint = currentDamageObject.transform.position;
            }

            float movement = 0.05f;
            if (this.nowAnimationCounter > 10) { movement = 0; }
            currentDamageObject.transform.position = new Vector3(currentDamageObject.transform.position.x + movement, currentDamageObject.transform.position.y, currentDamageObject.transform.position.z);

            this.nowAnimationCounter++;
            if (this.nowAnimationCounter > MAX_ANIMATION)
            {
                this.currentDamageObject.transform.position = ExecAnimation_basePoint;
                this.currentDamageObject.SetActive(false);
                this.currentDamageObject = null;
            }
        }
    }
}