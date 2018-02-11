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
        public AreaInformation prefab_NoneTile;
        public AreaInformation prefab_Tile;
        public AreaInformation prefab_Forest;
        public AreaInformation prefab_Sea;
        public AreaInformation prefab_Mountain;
        public GameObject prefab_Quad;
        public GameObject prefab_AttackTile;
        public GameObject prefab_AllyEffectTile;
        public GameObject prefab_HealTile;
        public Unit prefab_Fighter;
        public Unit prefab_Archer;
        public Unit prefab_Magician;
        public Unit prefab_Sorcerer;
        public Unit prefab_Priest;
        public Unit prefab_Enchanter;
        public Unit prefab_Wall;
        public Unit prefab_Monster;
        public GameObject prefab_Treasure;
        public Unit prefab_TreasureOpen;
        public GameObject prefab_Damage;
        public GameObject prefab_LifeGauge;
        // オブジェクト
        public Camera CameraView;
        private List<Unit> AllList = new List<Unit>();
        private List<Unit> AllyList = new List<Unit>();
        private List<Unit> EnemyList = new List<Unit>();
        private List<GameObject> TreasureList = new List<GameObject>();
        private List<GameObject> LifeGaugeList = new List<GameObject>();
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
        const float HEX_MOVE_X = 1.0f;
        const float HEX_MOVE_Z = 1.0f;
        // 移動状態
        public enum FieldMode
        {
            Move,
            Battle,
        }
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

        private FieldMode MoveMode = FieldMode.Move;
        private ActionPhase Phase = ActionPhase.WaitActive;

        public enum JudgeResult
        {
            Win,
            Lose,
            Draw
        }

        private bool GameEnd = false;

        // 一時記憶
        public Unit OwnerUnit;
        public Unit CurrentUnit;
        public Unit CurrentTarget;
        private Vector3 shadowPosition = new Vector3();
        private string currentCommand = string.Empty;
        private FIX.Direction currentDirection = FIX.Direction.None;
        private int currentDistance = 0;
        #endregion

        #region "キー操作"
        bool arrowDown = false; // add unity
        bool arrowUp = false; // add unity
        bool arrowLeft = false; // add unity
        bool arrowRight = false; // add unity
        bool keyDown = false;
        bool keyUp = false;
        bool keyLeft = false;
        bool keyRight = false;
        int MOVE_INTERVAL = 20;
        int interval = 0;
        private int MovementInterval = 0; // ダンジョンマップ全体を見ている時のインターバル
        #endregion

        new void Start()
        {
            base.Start();
            RenderSettings.skybox = (Material)Resources.Load("Skybox4");
            ONE.P1.labelFullName = this.txtPlayerName;
            ONE.P1.labelRace = this.txtRace;
            ONE.P1.ImageRace = this.iconRace;
            ONE.P1.MeterExp = this.meterExp;

            this.interval = MOVE_INTERVAL;
            this.MovementInterval = MOVE_INTERVAL;

            // プレイヤー設定
            txtPlayerName.text = ONE.P1.FullName;
            for (int ii = 0; ii < ONE.P1.ObsidianStone; ii++)
            {
                orbList[ii].SetActive(true);
            }
            txtLevel.text = ONE.P1.Level.ToString();
            if (ONE.P1.Race == FIX.Race.Human) { txtRace.text = "人間族"; iconRace.GetComponent<Image>().sprite = Resources.Load<Sprite>("Icon_Human"); }
            else if (ONE.P1.Race == FIX.Race.Mech) { txtRace.text = "機巧族"; iconRace.GetComponent<Image>().sprite = Resources.Load<Sprite>("Icon_Mech"); }
            else if (ONE.P1.Race == FIX.Race.Angel) { txtRace.text = "天使族"; iconRace.GetComponent<Image>().sprite = Resources.Load<Sprite>("Icon_Angel"); }
            else if (ONE.P1.Race == FIX.Race.Demon) { txtRace.text = "魔貴族"; iconRace.GetComponent<Image>().sprite = Resources.Load<Sprite>("Icon_Demon"); }
            else if (ONE.P1.Race == FIX.Race.Fire) { txtRace.text = "炎霊族"; iconRace.GetComponent<Image>().sprite = Resources.Load<Sprite>("Icon_Fire"); }
            else if (ONE.P1.Race == FIX.Race.Ice) { txtRace.text = "氷霊族"; iconRace.GetComponent<Image>().sprite = Resources.Load<Sprite>("Icon_Ice"); }
            ONE.P1.UpdateExp();
            txtExp.text = "( " + ONE.P1.Exp.ToString() + " / " + ONE.P1.NextLevelBorder.ToString() + " )";


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
                current.field = AreaInformation.Field.Plain;
                if (tileData[ii] == Convert.ToInt32(AreaInformation.Field.None))
                {
                    current = this.prefab_NoneTile;
                    current.field = AreaInformation.Field.None;
                }
                else if (tileData[ii] == Convert.ToInt32(AreaInformation.Field.Forest))
                {
                    current = this.prefab_Forest;
                    current.field = AreaInformation.Field.Forest;
                }
                else if (tileData[ii] == Convert.ToInt32(AreaInformation.Field.Sea))
                {
                    current = this.prefab_Sea;
                    current.field = AreaInformation.Field.Sea;
                }
                else if (tileData[ii] == Convert.ToInt32(AreaInformation.Field.Mountain))
                {
                    current = this.prefab_Mountain;
                    current.field = AreaInformation.Field.Mountain;
                }

                AreaInformation tile;
                tile = Instantiate(current, new Vector3(HEX_MOVE_X * (ii % column), HEX_MOVE_Z * (ii / column), 0), Quaternion.identity) as AreaInformation;
                tile.transform.Rotate(new Vector3(0, 0, 0));
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
                int counter = 0;
                // ユニット配置(味方)
                SetupUnit(ref AllList, counter, false, Unit.RaceType.Human, Unit.UnitType.Fighter, 2, 2); counter++;
                // ユニット配置(敵)
                SetupUnit(ref EnemyList, counter, true, Unit.RaceType.Monster, Unit.UnitType.Fighter, 11, 7); counter++;
                SetupUnit(ref EnemyList, counter, true, Unit.RaceType.Monster, Unit.UnitType.Fighter, 21, 7); counter++;
                SetupUnit(ref EnemyList, counter, true, Unit.RaceType.Monster, Unit.UnitType.Fighter, 25, 15); counter++;
                // 宝箱配置
                SetupItem(ref TreasureList, counter, 11, 10); counter++;
            }
            else if (ONE.CurrentStage == FIX.Stage.Stage1_2)
            {
                //Debug.Log("stage Stage1_2");
                //int counter = 0;
                //// ユニット配置(味方)
                //SetupUnit(ref AllList, counter, false, Unit.RaceType.Human, Unit.UnitType.Fighter, 0, 0); counter++;
                //SetupUnit(ref AllList, counter, false, Unit.RaceType.Human, Unit.UnitType.Archer, 0, 1); counter++;
                //// ユニット配置(敵)
                //SetupUnit(ref EnemyList, counter, true, Unit.RaceType.Human, Unit.UnitType.Archer, 7, 0); counter++;
                //SetupUnit(ref EnemyList, counter, true, Unit.RaceType.Human, Unit.UnitType.Fighter, 7, 7); counter++;
            }
            //else if (ONE.CurrentStage == FIX.Stage.Stage1_3)
            //{
            //    Debug.Log("stage Stage1_3");

            //    // ユニット配置(味方)
            //    SetupUnit(ref AllList, 1, false, Unit.RaceType.Human, Unit.UnitType.Sorcerer, 2, 0, true);
            //    SetupUnit(ref AllList, 2, false, Unit.RaceType.Human, Unit.UnitType.Archer, 0, 1, true);
            //    SetupUnit(ref AllList, 3, false, Unit.RaceType.Human, Unit.UnitType.Priest, 0, 0, true);
            //    // ユニット配置(敵)
            //    SetupUnit(ref AllList, 4, true, Unit.RaceType.Human, Unit.UnitType.Archer, 5, 4, true);
            //    SetupUnit(ref AllList, 5, true, Unit.RaceType.Human, Unit.UnitType.Sorcerer, 4, 4, true);
            //    SetupUnit(ref AllList, 6, true, Unit.RaceType.Human, Unit.UnitType.Priest, 6, 6, true);
            //}
            //else if (ONE.CurrentStage == FIX.Stage.Stage1_4)
            //{
            //    Debug.Log("stage Stage1_4");

            //    // ユニット配置(味方)
            //    SetupUnit(ref AllList, 1, false, Unit.RaceType.Human, Unit.UnitType.Fighter, 2, 0, true);
            //    SetupUnit(ref AllList, 2, false, Unit.RaceType.Human, Unit.UnitType.Archer, 0, 1, true);
            //    SetupUnit(ref AllList, 3, false, Unit.RaceType.Human, Unit.UnitType.Priest, 0, 0, true);
            //    // ユニット配置(敵)
            //    SetupUnit(ref AllList, 4, true, Unit.RaceType.Human, Unit.UnitType.Archer, 4, 3, true);
            //    SetupUnit(ref AllList, 5, true, Unit.RaceType.Human, Unit.UnitType.Fighter, 5, 4, true);
            //    SetupUnit(ref AllList, 6, true, Unit.RaceType.Human, Unit.UnitType.Priest, 4, 5, true);
            //}
            //else if (ONE.CurrentStage == FIX.Stage.Stage1_5)
            //{
            //    Debug.Log("stage Stage1_5");

            //    // ユニット配置(味方)
            //    SetupUnit(ref AllList, 1, false, Unit.RaceType.Human, Unit.UnitType.Archer, 0, 7, true);
            //    SetupUnit(ref AllList, 2, false, Unit.RaceType.Human, Unit.UnitType.Archer, 1, 7, true);
            //    SetupUnit(ref AllList, 3, false, Unit.RaceType.Human, Unit.UnitType.Priest, 2, 7, true);
            //    // ユニット配置(敵)
            //    SetupUnit(ref AllList, 4, true, Unit.RaceType.Human, Unit.UnitType.Fighter, 7, 0, true);
            //    SetupUnit(ref AllList, 5, true, Unit.RaceType.Human, Unit.UnitType.Fighter, 7, 1, true);
            //    SetupUnit(ref AllList, 6, true, Unit.RaceType.Human, Unit.UnitType.Priest, 7, 2, true);
            //}
            //else if (ONE.CurrentStage == FIX.Stage.Stage2_1)
            //{
            //    Debug.Log("stage Stage2_1");

            //    // ユニット配置(味方)
            //    SetupUnit(ref AllList, 1, false, Unit.RaceType.Angel, Unit.UnitType.Archer, 0, 3, true);
            //    SetupUnit(ref AllList, 2, false, Unit.RaceType.Angel, Unit.UnitType.Enchanter, 0, 4, true);
            //    SetupUnit(ref AllList, 3, false, Unit.RaceType.Human, Unit.UnitType.Priest, 1, 3, true);
            //    SetupUnit(ref AllList, 4, false, Unit.RaceType.Human, Unit.UnitType.Enchanter, 1, 2, true);
            //    // ユニット配置(敵)
            //    SetupUnit(ref AllList, 5, true, Unit.RaceType.Human, Unit.UnitType.Fighter, 6, 0, true);
            //}
            //else if (ONE.CurrentStage == FIX.Stage.Stage2_2)
            //{
            //    Debug.Log("stage Stage2_2");

            //    // ユニット配置(味方)
            //    SetupUnit(ref AllList, 1, false, Unit.RaceType.Fire, Unit.UnitType.Enchanter, 0, 4, true);
            //    SetupUnit(ref AllList, 2, false, Unit.RaceType.Fire, Unit.UnitType.Fighter, 0, 3, true);
            //    // ユニット配置(敵)
            //    SetupUnit(ref AllList, 3, true, Unit.RaceType.Human, Unit.UnitType.Priest, 5, 2, true);
            //    SetupUnit(ref AllList, 4, true, Unit.RaceType.Human, Unit.UnitType.Sorcerer, 5, 3, true);
            //    SetupUnit(ref AllList, 5, true, Unit.RaceType.Human, Unit.UnitType.Enchanter, 5, 4, true);
            //}
            //else if (ONE.CurrentStage == FIX.Stage.Stage2_3)
            //{
            //    Debug.Log("stage Stage2_3");

            //    // ユニット配置(味方)
            //    SetupUnit(ref AllList, 1, false, Unit.RaceType.Fire, Unit.UnitType.Archer, 0, 4, true);
            //    // ユニット配置(敵)
            //    SetupUnit(ref AllList, 2, true, Unit.RaceType.Human, Unit.UnitType.Priest, 4, 1, true);
            //    SetupUnit(ref AllList, 3, true, Unit.RaceType.Human, Unit.UnitType.Priest, 4, 2, true);
            //    SetupUnit(ref AllList, 4, true, Unit.RaceType.Human, Unit.UnitType.Priest, 4, 3, true);
            //}
            //else if (ONE.CurrentStage == FIX.Stage.Stage2_4)
            //{
            //    Debug.Log("stage Stage2_4");

            //    // ユニット配置(味方)
            //    SetupUnit(ref AllList, 1, false, Unit.RaceType.Angel, Unit.UnitType.Sorcerer, 0, 4, true);
            //    // ユニット配置(敵)
            //    SetupUnit(ref AllList, 2, true, Unit.RaceType.Human, Unit.UnitType.Priest, 4, 1, true);
            //    SetupUnit(ref AllList, 3, true, Unit.RaceType.Human, Unit.UnitType.Priest, 4, 2, true);
            //    SetupUnit(ref AllList, 4, true, Unit.RaceType.Human, Unit.UnitType.Priest, 4, 3, true);
            //}
            //else if (ONE.CurrentStage == FIX.Stage.Stage2_5)
            //{
            //    Debug.Log("stage Stage2_5");

            //    // ユニット配置(味方)
            //    SetupUnit(ref AllList, 1, false, Unit.RaceType.Fire, Unit.UnitType.Priest, 0, 4, true);
            //    // ユニット配置(敵)
            //    SetupUnit(ref AllList, 2, true, Unit.RaceType.Human, Unit.UnitType.Fighter, 5, 0, true);
            //}
            #endregion
            // 通常移動モードでは、常にプレイヤ－１を選択する。
            for (int ii = 0; ii < AllyList.Count; ii++)
            {
                this.AllyList[ii].CleanUp();
            }
            this.CurrentUnit = AllyList[0];
            this.OwnerUnit = AllyList[0];
            this.shadowPosition = this.CurrentUnit.transform.localPosition;
        }

        private int AutoClose = 300;
        new void Update()
        {
            base.Update();

            #region "ゲーム終了"
            if (this.GameEnd)
            {
                this.AutoClose--;
                if (this.AutoClose <= 0 || Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
                {
                    //this.MoveMode = FieldMode.Move;
                    //this.GameEnd = false;
                    //this.panelMessage.SetActive(false);
                    //for (int ii = 0; ii < AllyList.Count; ii++)
                    //{
                    //    this.AllyList[ii].CleanUp();
                    //}

                    //SceneManager.LoadSceneAsync(FIX.SCENE_GAMERESULT);
                }
                return;
            }
            #endregion

            #region "カーソルとキー操作"
            if (MoveMode == FieldMode.Move)
            {
                // カーソル移動
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, 100))
                {
                    GameObject obj = hit.collider.gameObject;
                    // フィールド操作
                    Cursor.transform.localPosition = new Vector3(obj.transform.localPosition.x,
                                                                 obj.transform.localPosition.y,
                                                                 Cursor.transform.localPosition.z);
                    Unit loc = ExistUnitFromLocation(Cursor.transform.localPosition);
                    if (loc != null)
                    {
                        UpdateUnitStatus(loc);
                    }
                }


                if (Input.GetKey(KeyCode.Keypad8) || Input.GetKey(KeyCode.UpArrow) || this.arrowUp)
                {
                    this.keyUp = true;
                    this.keyDown = false;
                    movementTimer_Tick(this.OwnerUnit);
                }
                else if (Input.GetKey(KeyCode.Keypad2) || Input.GetKey(KeyCode.DownArrow) || this.arrowDown)
                {
                    this.keyDown = true;
                    this.keyUp = false;
                    movementTimer_Tick(this.OwnerUnit);
                }
                if (Input.GetKey(KeyCode.Keypad4) || Input.GetKey(KeyCode.LeftArrow) || this.arrowLeft)
                {
                    this.keyLeft = true;
                    this.keyRight = false;
                    movementTimer_Tick(this.OwnerUnit);
                }
                if (Input.GetKey(KeyCode.Keypad6) || Input.GetKey(KeyCode.RightArrow) || this.arrowRight)
                {
                    this.keyRight = true;
                    this.keyLeft = false;
                    movementTimer_Tick(this.OwnerUnit);
                }

                if (Input.GetKeyUp(KeyCode.Keypad8) || Input.GetKeyUp(KeyCode.UpArrow))
                {
                    this.keyUp = false;
                    this.interval = MOVE_INTERVAL;
                }
                if (Input.GetKeyUp(KeyCode.Keypad4) || Input.GetKeyUp(KeyCode.LeftArrow))
                {
                    this.keyLeft = false;
                    this.interval = MOVE_INTERVAL;
                }
                if (Input.GetKeyUp(KeyCode.Keypad6) || Input.GetKeyUp(KeyCode.RightArrow))
                {
                    this.keyRight = false;
                    this.interval = MOVE_INTERVAL;
                }
                if (Input.GetKeyUp(KeyCode.Keypad2) || Input.GetKeyUp(KeyCode.DownArrow))
                {
                    this.keyDown = false;
                    this.interval = MOVE_INTERVAL;
                }
            }
            #endregion

            #region "タイム進行とアクティブユニット探索"
            if (this.Phase == ActionPhase.WaitActive)
            {
                Unit activePlayer = null;

                // タイマー０ですでに順番が来ていないかどうかチェックする。(Ally -> Enemyの順序)
                if (activePlayer == null)
                {
                    for (int ii = 0; ii < AllyList.Count; ii++)
                    {
                        if (AllyList[ii].Dead == false && AllyList[ii].CurrentTime <= 0)
                        {
                            activePlayer = AllyList[ii];
                            break;
                        }
                    }
                }

                if (activePlayer == null)
                {
                    for (int ii = 0; ii < EnemyList.Count; ii++)
                    {
                        if (EnemyList[ii].Dead == false && EnemyList[ii].CurrentTime <= 0)
                        {
                            activePlayer = EnemyList[ii];
                            break;
                        }
                    }
                }

                // タイマー更新（結果０以下になったらそれをDetect扱いとする） (Enemy -> Allyの順序)
                if (activePlayer == null)
                {
                    for (int ii = 0; ii < EnemyList.Count; ii++)
                    {
                        if (EnemyList[ii].Dead == false)
                        {
                            EnemyList[ii].CurrentTime--;
                            if (EnemyList[ii].CurrentTime <= 0)
                            {
                                activePlayer = EnemyList[ii];
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
                                activePlayer = AllyList[ii];
                            }
                        }
                    }
                }

                if (activePlayer != null)
                {
                    Unit target = SearchAttackableUnitInArea(activePlayer, activePlayer.AttackRange);

                    if (target != null && target.Dead == false && ((activePlayer.IsAlly && target.IsEnemy) || (activePlayer.IsEnemy && target.IsAlly)))
                    {
                        this.currentCommand = FIX.NORMAL_ATTACK;
                        int damage = 0;
                        if (activePlayer.Type == Unit.UnitType.Magician)
                        {
                            damage = activePlayer.MagicAttackValue + target.CurrentReachabletargetValue - target.MagicDefenseValue;
                        }
                        else
                        {
                            damage = activePlayer.AttackValue + target.CurrentReachabletargetValue - target.DefenseValue;
                        }
                        this.CurrentUnit = activePlayer; // アクティブユニット記憶
                        this.CurrentTarget = target; // ターゲットユニット記憶
                        StartAnimation(target, damage.ToString(), new Color(1.0f, 0.3f, 0.3f));
                        BeginEffect(ActionCommand.GetSkillNumbering(this.currentCommand));
                        this.Phase = ActionPhase.ExecAnimation;
                    }
                    else
                    {
                        this.currentCommand = String.Empty;
                        this.currentDirection = FIX.Direction.None;
                        this.currentDistance = 0;
                        activePlayer.currentTime = 100 - activePlayer.SpeedValue;
                        Debug.Log("detect isn't null and Unit doesn't exist");
                    }
                }
            }
            #endregion

            #region "コマンド実行"
            //#region "敵フェーズ"
            //if (this.CurrentUnit.IsAlly == false)
            //{
            //    if (Phase == ActionPhase.SelectFirst)
            //    {
            //        Debug.Log("ActionPhase.SelectFirst");
            //        System.Threading.Thread.Sleep(500);
            //        UpdateUnitStatus(this.CurrentUnit);
            //        OpenMoveable(this.CurrentUnit);
            //        this.Phase = ActionPhase.SelectMove;
            //    }
            //    else if (this.Phase == ActionPhase.SelectMove)
            //    {
            //        Debug.Log("ActionPhase.SelectMove");
            //        System.Threading.Thread.Sleep(500);

            //        if (this.CurrentUnit.CurrentEarthBind > 0)
            //        {
            //            this.Phase = ActionPhase.SelectCommand;
            //            return;
            //        }

            //        // 攻撃可能なユニットがいるかどうか確認。
            //        List<Unit> attackable = SearchAttackableUnit(this.CurrentUnit, this.CurrentUnit.AttackRange);
            //        if (attackable.Count > 0)
            //        {
            //            Debug.Log("ActionPhase.SelectMove: detect attackable: " + attackable.Count.ToString());
            //            ClearQuadTile();

            //            lblCommand1.GetComponent<TextMesh>().text = FIX.NORMAL_ATTACK;
            //            lblCommand2.GetComponent<TextMesh>().text = CurrentUnit.SkillName;
            //            lblCommand3.GetComponent<TextMesh>().text = FIX.NORMAL_END;
            //            groupCommand.transform.localPosition = new Vector3(CurrentUnit.transform.localPosition.x + 2,
            //                                                               CurrentUnit.transform.localPosition.y,
            //                                                               CurrentUnit.transform.localPosition.z);
            //            groupCommand.SetActive(true);
            //            this.Phase = ActionPhase.SelectCommand;
            //            return;
            //        }

            //        Debug.Log("ActionPhase.SelectMove: now moving...");

            //        // 攻撃可能なユニットがいなければ、移動する。
            //        // A.I. 攻撃ターゲットの探索対象は常にユニット順序とは限らない。
            //        Unit targetUnit = AllyList[0];
            //        FIX.Direction direction = FIX.Direction.Top;
            //        for (int ii = 0; ii < AllyList.Count; ii++)
            //        {
            //            if (AllyList[ii].Dead == false)
            //            {
            //                targetUnit = AllyList[ii];
            //                break;
            //            }
            //        }
            //        if (targetUnit.transform.localPosition.x < CurrentUnit.transform.localPosition.x)
            //        {
            //            if (targetUnit.transform.localPosition.y == CurrentUnit.transform.localPosition.y)
            //            {
            //                direction = FIX.Direction.Left;
            //            }
            //            else if (targetUnit.transform.localPosition.y < CurrentUnit.transform.localPosition.y)
            //            {
            //                direction = FIX.Direction.Bottom;
            //            }
            //            else
            //            {
            //                direction = FIX.Direction.Top;
            //            }
            //        }
            //        else if (targetUnit.transform.localPosition.x > CurrentUnit.transform.localPosition.x)
            //        {
            //            if (targetUnit.transform.localPosition.y == CurrentUnit.transform.localPosition.y)
            //            {
            //                direction = FIX.Direction.Right;
            //            }
            //            else if (targetUnit.transform.localPosition.y < CurrentUnit.transform.localPosition.y)
            //            {
            //                direction = FIX.Direction.Bottom;
            //            }
            //            else
            //            {
            //                direction = FIX.Direction.Top;
            //            }
            //        }

            //        // 移動先がエリアが無い、もしくは、別のユニットが存在する場合、方向を調整します。
            //        bool canMove = true;
            //        if (direction == FIX.Direction.Top)
            //        {
            //            JudgeMove(FIX.Direction.Top, FIX.Direction.Left, FIX.Direction.Right, out direction);
            //        }
            //        else if (direction == FIX.Direction.Left)
            //        {
            //            JudgeMove(FIX.Direction.Left, FIX.Direction.Top, FIX.Direction.Bottom, out direction);
            //        }
            //        else if (direction == FIX.Direction.Right)
            //        {
            //            JudgeMove(FIX.Direction.Right, FIX.Direction.Top, FIX.Direction.Bottom, out direction);
            //        }
            //        else if (direction == FIX.Direction.Bottom)
            //        {
            //            JudgeMove(FIX.Direction.Bottom, FIX.Direction.Left, FIX.Direction.Right, out direction);
            //        }
            //        // 行き先がない場合、移動完了します。
            //        if (direction == FIX.Direction.None)
            //        {
            //            this.CurrentUnit.CurrentMovePoint = 0;
            //            canMove = false;
            //        }

            //        // 移動コストが大きい場合、移動完了します。
            //        AreaInformation nextArea = ExistAreaFromLocation(this.CurrentUnit.GetNeighborhood(direction));
            //        if (this.CurrentUnit.CurrentMovePoint < nextArea.MoveCost)
            //        {
            //            this.CurrentUnit.CurrentMovePoint = 0;
            //            canMove = false;
            //        }
            //        if (this.CurrentUnit.CurrentEarthBind > 0)
            //        {
            //            canMove = false;
            //        }

            //        if (canMove)
            //        {
            //            // 移動開始
            //            CurrentUnit.CurrentMovePoint -= nextArea.MoveCost;
            //            CurrentUnit.Move(direction);
            //            Cursor.transform.localPosition = new Vector3(CurrentUnit.transform.localPosition.x,
            //                                                         CurrentUnit.transform.localPosition.y,
            //                                                         Cursor.transform.localPosition.z);
            //        }

            //        if (CurrentUnit.CurrentMovePoint > 0)
            //        {
            //            return;
            //        }

            //        ClearQuadTile();

            //        lblCommand1.GetComponent<TextMesh>().text = FIX.NORMAL_ATTACK;
            //        lblCommand2.GetComponent<TextMesh>().text = CurrentUnit.SkillName;
            //        lblCommand3.GetComponent<TextMesh>().text = FIX.NORMAL_END;
            //        groupCommand.transform.localPosition = new Vector3(CurrentUnit.transform.localPosition.x + 2,
            //                                                           CurrentUnit.transform.localPosition.y,
            //                                                           CurrentUnit.transform.localPosition.z);
            //        groupCommand.SetActive(true);
            //        this.Phase = ActionPhase.SelectCommand;
            //    }
            //    else if (this.Phase == ActionPhase.SelectCommand)
            //    {
            //        Debug.Log("ActionPhase.SelectCommand");
            //        System.Threading.Thread.Sleep(500);

            //        //if (this.CurrentUnit.Race == Unit.RaceType.Human && this.CurrentUnit.Type == Unit.UnitType.Fighter && this.CurrentUnit.CurrentSilverArrow <= 0)
            //        //{
            //        //    Debug.Log("ActionPhase.SelectCommand: Human Fighter SilverArrow");

            //        //    List<Unit> attackable = SearchAttackableUnitLinearGroup(this.CurrentUnit, this.CurrentUnit.EffectRange);
            //        //    Debug.Log("attackable: " + attackable.Count.ToString());
            //        //    if (attackable.Count > 0)
            //        //    {
            //        //        Debug.Log("attackable: " + attackable.Count.ToString());
            //        //        OpenAttackable(this.CurrentUnit, this.CurrentUnit.EffectRange, true);
            //        //        int random = AP.Math.RandomInteger(attackable.Count);
            //        //        this.CurrentTarget = attackable[random];
            //        //        groupCommand.SetActive(false);
            //        //        this.Phase = ActionPhase.SelectTarget;
            //        //        return;
            //        //    }
            //        //    Debug.Log("attackable: " + attackable.Count.ToString());
            //        //}
            //        //else
            //        //{
            //            List<Unit> attackable = SearchAttackableUnit(this.CurrentUnit, this.CurrentUnit.AttackRange);
            //            if (attackable.Count > 0)
            //            {
            //                OpenAttackable(this.CurrentUnit, this.CurrentUnit.AttackRange, false);
            //                int random = AP.Math.RandomInteger(attackable.Count);
            //                this.CurrentTarget = attackable[random];
            //                groupCommand.SetActive(false);
            //                this.Phase = ActionPhase.SelectTarget;
            //                return;
            //            }
            //        //}

            //        // A.I [ATTACK][SKILL]
            //        Debug.Log("ActionPhase.SelectCommand (END)");
            //        groupCommand.SetActive(false);
            //        this.Phase = ActionPhase.End;
            //    }
            //    else if (this.Phase == ActionPhase.SelectTarget)
            //    {
            //        Debug.Log("ActionPhase.SelectTarget");
            //        System.Threading.Thread.Sleep(500);

            //        if (this.CurrentUnit.Race == Unit.RaceType.Human && this.CurrentUnit.Type == Unit.UnitType.Fighter && this.CurrentUnit.CurrentSilverArrow <= 0)
            //        {
            //            Debug.Log("ActionPhase.SelectTarget:Human Fighter SilverArrow");

            //            int move = 0;
            //            FIX.Direction direction = FIX.Direction.Top;
            //            if (ExistAttackableUnitLinear(ref move, this.CurrentUnit, this.CurrentTarget, this.CurrentUnit.EffectRange, FIX.Direction.Top))
            //            {
            //                direction = FIX.Direction.Top;
            //            }
            //            else if (ExistAttackableUnitLinear(ref move, this.CurrentUnit, this.CurrentTarget, this.CurrentUnit.EffectRange, FIX.Direction.Left))
            //            {
            //                direction = FIX.Direction.Left;
            //            }
            //            else if (ExistAttackableUnitLinear(ref move, this.CurrentUnit, this.CurrentTarget, this.CurrentUnit.EffectRange, FIX.Direction.Right))
            //            {
            //                direction = FIX.Direction.Right;
            //            }
            //            else if (ExistAttackableUnitLinear(ref move, this.CurrentUnit, this.CurrentTarget, this.CurrentUnit.EffectRange, FIX.Direction.Bottom))
            //            {
            //                direction = FIX.Direction.Bottom;
            //            }
            //            else
            //            {
            //                Debug.Log("DASH detect other...");
            //            }
            //            for (int ii = 0; ii < move; ii++)
            //            {
            //                //if (this.CurrentUnit.CurrentEarthBind > 0) // アースバインドでダッシュの移動を防ぐことはできない。
            //                this.CurrentUnit.Move(direction);
            //            }
            //            Debug.Log("ActionPhase.SelectTarget:ExecDamage: " + ActionCommand.EffectValue(this.currentCommand).ToString());
            //            ExecDamage(this.CurrentUnit, this.CurrentTarget, ActionCommand.EffectValue(this.currentCommand) + this.CurrentTarget.CurrentReachabletargetValue - this.CurrentTarget.DefenseValue);

            //            Debug.Log("ActionPhase.SelectTarget:now ClearAttackTile");
            //            ClearAttackTile();
            //            JudgeGameEnd();
            //            Debug.Log("ActionPhase.SelectTarget:(END)");
            //            this.Phase = ActionPhase.End;
            //        }
            //        else
            //        {
            //            List<Unit> attackable = SearchAttackableUnit(this.CurrentUnit, this.CurrentUnit.AttackRange);
            //            if (attackable.Count > 0)
            //            {
            //                Debug.Log("ActionPhase.SelectTarget: target " + this.CurrentTarget.name + " " + this.CurrentTarget.CurrentLife.ToString());
            //                this.CurrentTarget.CurrentLife -= this.CurrentUnit.AttackValue + this.CurrentTarget.CurrentReachabletargetValue - this.CurrentTarget.DefenseValue;
            //                UpdateLife(this.CurrentTarget);
            //                Debug.Log("ActionPhase.SelectTarget: after " + this.CurrentTarget.name + " " + this.CurrentTarget.CurrentLife.ToString());
            //                if (this.CurrentTarget.CurrentLife <= 0)
            //                {
            //                    this.CurrentTarget.Dead = true;
            //                    this.CurrentTarget.gameObject.SetActive(false);
            //                    AllyList.Remove(this.CurrentTarget);
            //                }
            //                ClearAttackTile();
            //                JudgeGameEnd();
            //                this.Phase = ActionPhase.End;
            //            }
            //        }
            //    }
            //    else if (this.Phase == ActionPhase.End)
            //    {
            //        Debug.Log("ActionPhase.End");
            //        System.Threading.Thread.Sleep(500);
            //        CurrentUnit.Completed();
            //        AdjustTime(this.CurrentUnit);
            //        JudgeGameEnd();
            //        this.currentCommand = String.Empty;
            //        this.currentDirection = FIX.Direction.None;
            //        this.currentDistance = 0;
            //        this.CurrentUnit = null;
            //        this.CurrentTarget = null;
            //        this.Phase = ActionPhase.WaitActive;
            //    }
            //    return;
            //}
            //#endregion

            //#region "味方フェーズ"
            // 最初のフェーズ
            //if (this.Phase == ActionPhase.SelectFirst)
            //{
            //    UpdateUnitStatus(this.CurrentUnit);
            //    OpenMoveable(this.CurrentUnit);
            //    this.Phase = ActionPhase.Upkeep;
            //}
            //// アップキープ
            //else if (this.Phase == ActionPhase.Upkeep)
            //{
            //    if (this.CurrentUnit.CurrentHealingWord > 0)
            //    {
            //        StartAnimation(this.CurrentUnit, "LIFE +3", Color.yellow);
            //        this.Phase = ActionPhase.UpkeepAnimation;
            //        return;
            //    }
            //    this.Phase = ActionPhase.SelectMove;
            //}
            //else if (this.Phase == ActionPhase.UpkeepAnimation)
            //{
            //    ExecAnimationDamage();
            //    if (this.currentPrefabObject != null)
            //    {
            //        return;
            //    }
            //    if (this.nowAnimationCounter <= MAX_ANIMATION)
            //    {
            //        return;
            //    }
            //    this.Phase = ActionPhase.UpkeepExec;
            //}
            //else if (this.Phase == ActionPhase.UpkeepExec)
            //{
            //    if (this.CurrentUnit.CurrentHealingWord > 0)
            //    {
            //        ExecHeal(this.CurrentUnit, this.CurrentUnit, 3);
            //    }
            //    this.Phase = ActionPhase.SelectMove;
            //}
            //// 移動先を選択
            //else if (this.Phase == ActionPhase.SelectMove)
            //{
            //    if (this.CurrentUnit.CurrentEarthBind > 0)
            //    {
            //        this.Phase = ActionPhase.SelectCommand;
            //        return;
            //    }

            //    if (CheckMoveableArea(Cursor.transform.localPosition) && Input.GetMouseButtonDown(0))
            //    {
            //        Debug.Log("mousedown, nowselectmoveale");
            //        Unit target = ExistUnitFromLocation(Cursor.transform.localPosition);
            //        if (target != null && target.Equals(this.CurrentUnit) == false)
            //        {
            //            Debug.Log("already exist unit, then no action.");
            //            return;
            //        }
            //        CurrentUnit.transform.localPosition = new Vector3(Cursor.transform.localPosition.x,
            //                                                            Cursor.transform.localPosition.y,
            //                                                            CurrentUnit.transform.localPosition.z);
            //        ClearQuadTile();

            //        lblCommand1.GetComponent<TextMesh>().text = FIX.NORMAL_ATTACK;
            //        lblCommand2.GetComponent<TextMesh>().text = CurrentUnit.SkillName;
            //        lblCommand3.GetComponent<TextMesh>().text = FIX.NORMAL_END;
            //        groupCommand.transform.localPosition = new Vector3(CurrentUnit.transform.localPosition.x + 2,
            //                                                            CurrentUnit.transform.localPosition.y,
            //                                                            CurrentUnit.transform.localPosition.z);
            //        groupCommand.SetActive(true);
            //        this.Phase = ActionPhase.SelectCommand;
            //    }
            //}
            //// コマンド選択時
            //else if (this.Phase == ActionPhase.SelectCommand)
            //{
            //    int LayerNo = LayerMask.NameToLayer(FIX.LAYER_UNITCOMMAND);
            //    int layerMask = 1 << LayerNo;
            //    if (Physics.Raycast(ray, out hit, 100, layerMask) && Input.GetMouseButtonDown(0))
            //    {
            //        GameObject obj = hit.collider.gameObject;
            //        CommandCursor.transform.localPosition = new Vector3(obj.transform.localPosition.x,
            //                                                                obj.transform.localPosition.y - 0.01f,
            //                                                                obj.transform.localPosition.z);

            //        groupCommand.SetActive(false);
            //        // コマンドメニュー操作
            //        if (obj.name == "back_Command1")
            //        {
            //            this.currentCommand = FIX.NORMAL_ATTACK;
            //            OpenAttackable(this.CurrentUnit, this.CurrentUnit.AttackRange, false);
            //            this.Phase = ActionPhase.SelectTarget;
            //        }
            //        if (obj.name == "back_Command2")
            //        {
            //            this.currentCommand = this.CurrentUnit.SkillName;
            //            // 単一の敵対象
            //            if (ActionCommand.GetTargetType(this.currentCommand) == ActionCommand.TargetType.Enemy)
            //            {
            //                if (this.currentCommand == FIX.DASH)
            //                {
            //                    OpenAttackable(this.CurrentUnit, this.CurrentUnit.EffectRange, true);
            //                }
            //                else if (this.currentCommand == FIX.EXPLOSION)
            //                {
            //                    OpenAttackable(this.CurrentUnit, this.CurrentUnit.EffectRange, true);
            //                }
            //                else
            //                {
            //                    OpenAttackable(this.CurrentUnit, this.CurrentUnit.AttackRange, false);
            //                }
            //            }
            //            // 単一の味方対象(効果/回復)
            //            else if (ActionCommand.GetTargetType(this.currentCommand) == ActionCommand.TargetType.Ally)
            //            {
            //                // 回復
            //                if (ActionCommand.IsHeal(this.currentCommand))
            //                {
            //                    OpenHealable(this.CurrentUnit);
            //                }
            //                // 効果
            //                else
            //                {
            //                    OpenAllyEffectable(this.CurrentUnit);
            //                }
            //            }
            //            // 自分自身
            //            else if (ActionCommand.GetTargetType(this.currentCommand) == ActionCommand.TargetType.Own)
            //            {
            //                // 何も表示せず、次のフェーズへ
            //            }
            //            // 対象なし（自分中央でエリア範囲）
            //            else if (ActionCommand.GetTargetType(this.currentCommand) == ActionCommand.TargetType.AllyGroup)
            //            {
            //                // 何も表示せず、次のフェーズへ
            //            }
            //            else if (this.currentCommand == FIX.BLAZE)
            //            {
            //                OpenAttackable(this.CurrentUnit, this.CurrentUnit.EffectRange, true);
            //            }
            //            else if (this.currentCommand == FIX.LAVAWALL)
            //            {
            //                OpenAttackable(this.CurrentUnit, this.CurrentUnit.EffectRange, false);
            //            }
            //            this.Phase = ActionPhase.SelectTarget;
            //        }
            //        if (obj.name == "back_Command3")
            //        {
            //            CurrentUnit.Completed();
            //            AdjustTime(this.CurrentUnit);
            //            this.Phase = ActionPhase.End;
            //        }
            //    }
            //}
            //// コマンド実行対象の選択
            //else if (this.Phase == ActionPhase.SelectTarget)
            //{
            //    bool detectAction = false;
            //    if (ActionCommand.GetTargetType(this.currentCommand) == ActionCommand.TargetType.Own)
            //    {
            //        // 自分自身が対象なので即座に次へ
            //        detectAction = true;
            //        if (this.currentCommand == FIX.FIREBLADE)
            //        {
            //            this.CurrentTarget = this.CurrentUnit;
            //            StartAnimation(this.CurrentUnit, "STR + " + ActionCommand.EffectValue(this.currentCommand).ToString(), Color.yellow);
            //        }
            //        else if (this.currentCommand == FIX.HOLYBULLET)
            //        {
            //            this.CurrentTarget = null;
            //            StartAnimation(this.CurrentUnit, "HOLY", new Color(1.0f, 0.3f, 0.3f));
            //        }
            //    }
            //    else if (Input.GetMouseButtonDown(0))
            //    {
            //        // 単一の敵対象
            //        if (ActionCommand.GetTargetType(this.currentCommand) == ActionCommand.TargetType.Enemy &&
            //            CheckAttackableArea(Cursor.transform.localPosition))
            //        {
            //            detectAction = true;
            //            Unit target = ExistUnitFromLocation(Cursor.transform.localPosition);
            //            if (target == null)
            //            {
            //                Debug.Log("unit is not exist, then no action.");
            //                return;
            //            }
            //            if (target.IsAlly)
            //            {
            //                Debug.Log("unit is ally, then no action");
            //                return;
            //            }
            //            this.CurrentTarget = target;

            //            if (this.currentCommand == FIX.DASH)
            //            {
            //                int move = 0;
            //                FIX.Direction direction = ExistAttackableUnitLinerGroup(ref move, this.CurrentUnit, this.CurrentTarget, this.CurrentUnit.EffectRange);
            //                for (int ii = 0; ii < move; ii++)
            //                {
            //                    //if (this.CurrentUnit.CurrentEarthBind > 0) // アースバインドでダッシュの移動を防ぐことはできない。
            //                    this.CurrentUnit.Move(direction);
            //                }
            //                int damage = 0;
            //                damage = ActionCommand.EffectValue(this.currentCommand) + this.CurrentTarget.CurrentReachabletargetValue - this.CurrentTarget.MagicDefenseValue;
                                
            //                StartAnimation(this.CurrentTarget, damage.ToString(), new Color(1.0f, 0.3f, 0.3f));
            //            }
            //            else if (this.currentCommand == FIX.NEEDLESPEAR || this.currentCommand == FIX.SILVERARROW)
            //            {
            //                int damage = ActionCommand.EffectValue(this.currentCommand) + this.CurrentTarget.CurrentReachabletargetValue - this.CurrentTarget.DefenseValue;
            //                StartAnimation(this.CurrentTarget, damage.ToString(), new Color(1.0f, 0.3f, 0.3f));
            //            }
            //            else if (this.currentCommand == FIX.EARTHBIND)
            //            {
            //                StartAnimation(this.CurrentTarget, "BIND", new Color(1.0f, 0.3f, 0.3f));
            //            }
            //            else if (this.currentCommand == FIX.EXPLOSION)
            //            {
            //                int damage = ActionCommand.EffectValue(this.currentCommand) + this.CurrentTarget.CurrentReachabletargetValue - this.CurrentTarget.DefenseValue;
            //                StartAnimation(this.CurrentTarget, damage.ToString(), new Color(1.0f, 0.3f, 0.3f));
            //            }
            //            else if (this.currentCommand == FIX.REACHABLETARGET)
            //            {
            //                StartAnimation(this.CurrentTarget, "TARGET", new Color(1.0f, 0.3f, 0.3f));
            //            }
            //            else
            //            {
            //                int damage = 0;
            //                if (this.CurrentUnit.Type == Unit.UnitType.Magician)
            //                {
            //                    damage = this.CurrentUnit.MagicAttackValue + this.CurrentTarget.CurrentReachabletargetValue - this.CurrentTarget.MagicDefenseValue;
            //                }
            //                else
            //                {
            //                    damage = this.CurrentUnit.AttackValue + this.CurrentTarget.CurrentReachabletargetValue - this.CurrentTarget.DefenseValue;
            //                }
            //                StartAnimation(this.CurrentTarget, damage.ToString(), new Color(1.0f, 0.3f, 0.3f));
            //            }
            //        }
            //        // 単一の味方対象(効果/回復)
            //        else if (ActionCommand.GetTargetType(this.currentCommand) == ActionCommand.TargetType.Ally)
            //        {
            //            // 回復
            //            if (ActionCommand.IsHeal(this.currentCommand) && CheckHealableArea(Cursor.transform.localPosition))
            //            {
            //                detectAction = true;
            //                Unit target = ExistUnitFromLocation(Cursor.transform.localPosition);
            //                if (target == null)
            //                {
            //                    Debug.Log("unit is not exist, then no action.");
            //                    return;
            //                }
            //                if (target.IsAlly == false)
            //                {
            //                    Debug.Log("unit is enemy, then no action");
            //                    return;
            //                }

            //                this.CurrentTarget = target;
            //                StartAnimation(this.CurrentTarget, ActionCommand.EffectValue(this.currentCommand).ToString(), Color.yellow);
            //            }
            //            // 効果
            //            else if (CheckAllyEffectArea(Cursor.transform.localPosition))
            //            {
            //                detectAction = true;
            //                Unit target = ExistUnitFromLocation(Cursor.transform.localPosition);
            //                if (target == null)
            //                {
            //                    Debug.Log("unit is not exist, then no action.");
            //                    return;
            //                }
            //                if (target.IsAlly == false)
            //                {
            //                    Debug.Log("unit is enemy, then no action");
            //                    return;
            //                }
            //                this.CurrentTarget = target;
            //                if (this.currentCommand == FIX.POWERWORD)
            //                {
            //                    StartAnimation(this.CurrentTarget, "STR +" + ActionCommand.EffectValue(this.currentCommand).ToString(), Color.yellow);
            //                }
            //                else if (this.currentCommand == FIX.PROTECTION)
            //                {
            //                    StartAnimation(this.CurrentTarget, "DEF +" + ActionCommand.EffectValue(this.currentCommand).ToString(), Color.yellow);
            //                }
            //                else if (this.currentCommand == FIX.HEATBOOST)
            //                {
            //                    StartAnimation(this.CurrentUnit, "SPD +" + ActionCommand.EffectValue(this.currentCommand).ToString(), Color.yellow);
            //                }
            //            }
            //        }
            //        else if (this.currentCommand == FIX.BLAZE && CheckAttackableArea(Cursor.transform.localPosition))
            //        {
            //            FIX.Direction direction = FIX.Direction.None;
            //            int move = 0;
            //            if (IsLinear(ref direction, ref move, this.CurrentUnit.transform.position, Cursor.transform.position))
            //            {
            //                detectAction = true;
            //                this.currentDirection = direction;
            //                this.currentDistance = move;
            //                StartAnimation(this.CurrentUnit, "Blaze", Color.yellow);
            //            }
            //        }
            //        else if (this.currentCommand == FIX.LAVAWALL && CheckAttackableArea(Cursor.transform.localPosition))
            //        {
            //            FIX.Direction direction = FIX.Direction.None;
            //            int move = 0;
            //            if (IsLinear(ref direction, ref move, this.CurrentUnit.transform.position, Cursor.transform.position))
            //            {
            //                detectAction = true;
            //                this.currentDirection = direction;
            //                this.currentDistance = move;
            //                StartAnimation(this.CurrentUnit, "LAVAWALL", Color.yellow);
            //            }
            //        }
            //    }
            //    if (detectAction)
            //    {
            //        ClearAttackTile();
            //        ClearHealTile();
            //        ClearAllyEffectTile();
            //        JudgeGameEnd();
            //        int number = ActionCommand.GetSkillNumbering(this.currentCommand);
            //        if (number <= -1)
            //        {
            //            this.Phase = ActionPhase.End;
            //            return;
            //        }

            //        BeginEffect(ActionCommand.GetSkillNumbering(this.currentCommand));
            //        this.Phase = ActionPhase.ExecAnimation;
            //    }
            //}
            // アニメーション実行
            if (this.Phase == ActionPhase.ExecAnimation)
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
                    if (this.CurrentUnit.Type == Unit.UnitType.Magician)
                    {
                        ExecDamage(this.CurrentUnit, this.CurrentTarget, this.CurrentUnit.MagicAttackValue + this.CurrentTarget.CurrentReachabletargetValue - this.CurrentTarget.MagicDefenseValue);
                    }
                    else
                    {
                        ExecDamage(this.CurrentUnit, this.CurrentTarget, this.CurrentUnit.AttackValue + this.CurrentTarget.CurrentReachabletargetValue - this.CurrentTarget.DefenseValue);
                    }
                }
                else if (this.currentCommand == FIX.DASH)
                {
                    ExecDash(this.CurrentUnit, this.CurrentTarget);
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
                    ExecHealingWord(this.CurrentUnit, this.CurrentTarget);
                }
                else if (this.currentCommand == FIX.NEEDLESPEAR)
                {
                    ExecNeedleSpear(this.CurrentUnit, this.CurrentTarget);
                }
                else if (this.currentCommand == FIX.SILVERARROW)
                {
                    ExecSilverArrow(this.CurrentUnit, this.CurrentTarget);
                }
                else if (this.currentCommand == FIX.HOLYBULLET)
                {
                    ExecHolyBullet(this.CurrentUnit);
                }
                else if (this.currentCommand == FIX.PROTECTION)
                {
                    ExecProtection(this.CurrentUnit, this.CurrentTarget);
                }
                else if (this.currentCommand == FIX.FRESHHEAL)
                {
                    ExecFreshHeal(this.CurrentUnit, this.CurrentTarget);
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
                    ExecBlaze(this.CurrentUnit, this.currentDirection);
                }
                else if (this.currentCommand == FIX.HEATBOOST)
                {
                    ExecHeatBoost(this.CurrentUnit, this.CurrentTarget);
                }
                else if (this.currentCommand == FIX.EXPLOSION)
                {
                    ExecExplosion(this.CurrentUnit, this.CurrentTarget);
                }
                JudgeUnitDead();
                this.Phase = ActionPhase.End;
            }
            // 終了
            else if (this.Phase == ActionPhase.End)
            {
                CurrentUnit.Completed();
                AdjustTime(this.CurrentUnit);
                JudgeGameEnd();
                this.currentCommand = String.Empty;
                this.currentDirection = FIX.Direction.None;
                this.currentDistance = 0;
                this.CurrentUnit = null;
                this.CurrentTarget = null;
                this.shadowPosition = this.OwnerUnit.transform.localPosition;
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
        public void tapCommand(int number)
        {
            Debug.Log("tapCommand: " + number.ToString());
        }

        public void tapMoveTop()
        {
        }
        public void tapMoveLeftUp()
        {
        }
        public void tapMoveLeftDown()
        {
        }
        public void tapMoveRightUp()
        {
        }
        public void tapMoveRightDown()
        {
        }
        public void tapMoveBottom()
        {
        }
        public void tapSelect()
        {
        }
        public void tapCancel()
        {
        }
        public void tapActionCommand()
        {
        }
        public void tapAttack()
        {
        }
        public void tapBattleStart()
        {
        }
        #endregion

        private GameObject currentPrefabObject = null;
        private FireBaseScript currentPrefabScript;


        private void BeginEffect(int number)
        {
            //Vector3 pos;
            //float yRot = this.CurrentUnit.transform.rotation.eulerAngles.y;
            //Vector3 forwardY = Quaternion.Euler(0.0f, yRot, 0.0f) * Vector3.forward;
            //Vector3 forward = this.CurrentUnit.transform.forward;
            //Vector3 right = this.CurrentUnit.transform.right;
            //Vector3 up = this.CurrentUnit.transform.up;
            //Quaternion rotation = Quaternion.identity;
            //currentPrefabObject = GameObject.Instantiate(prefab_Effect[number]);
            //currentPrefabScript = currentPrefabObject.GetComponent<FireConstantBaseScript>();

            //if (currentPrefabScript == null)
            //{
            //    // temporary effect, like a fireball
            //    currentPrefabScript = currentPrefabObject.GetComponent<FireBaseScript>();
            //    if (currentPrefabScript.IsProjectile)
            //    {
            //        // set the start point near the player
            //        rotation = this.CurrentUnit.transform.rotation;
            //        pos = this.CurrentUnit.transform.position;// +forward + right + up;
            //    }
            //    else
            //    {
            //        // set the start point in front of the player a ways
            //        pos = this.CurrentUnit.transform.position;// +(forwardY * 10.0f);
            //    }
            //}
            //else
            //{
            //    // set the start point in front of the player a ways, rotated the same way as the player
            //    pos = this.CurrentUnit.transform.position;// +(forwardY * 5.0f);
            //    rotation = this.CurrentUnit.transform.rotation;
            //    pos.y = 0.0f;
            //}

            //FireProjectileScript projectileScript = currentPrefabObject.GetComponentInChildren<FireProjectileScript>();
            //if (projectileScript != null)
            //{
            //    // make sure we don't collide with other friendly layers
            //    projectileScript.ProjectileCollisionLayers &= (~UnityEngine.LayerMask.NameToLayer("FriendlyLayer"));
            //}

            //currentPrefabObject.transform.position = pos;
            //currentPrefabObject.transform.rotation = rotation;
        }

        private void UpdateLife(Unit unit)
        {
            UnitLifeText.text = unit.CurrentLife.ToString() + "  /  " + unit.MaxLife.ToString();

            float dx = (float)unit.CurrentLife / (float)unit.MaxLife;
            if (this.UniteLifeMeter != null)
            {
                this.UniteLifeMeter.rectTransform.localScale = new Vector2(dx, 1.0f);
            }
            if (unit.LifeGauge != null)
            {
                unit.LifeGauge.transform.localScale = new Vector3(dx, unit.LifeGauge.transform.localScale.y, unit.LifeGauge.transform.localScale.z);
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
            this.currentDamageObject.transform.localPosition = new Vector3(unit.transform.localPosition.x, unit.transform.localPosition.y, unit.transform.localPosition.z - 1);
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

        private void movementTimer_Tick(Unit player)
        {
            if (this.interval < this.MovementInterval) { this.interval++; return; }
            else { this.interval = 0; }

            if (this.keyUp)
            {
                UpdatePlayersKeyEvents(player, FIX.Direction.Top);
            }
            else if (this.keyRight)
            {
                UpdatePlayersKeyEvents(player, FIX.Direction.Right);
            }
            else if (this.keyDown)
            {
                UpdatePlayersKeyEvents(player, FIX.Direction.Bottom);
            }
            else if (this.keyLeft)
            {
                UpdatePlayersKeyEvents(player, FIX.Direction.Left);
            }
        }
        public void CancelKeyDownMovement()
        {
            this.arrowUp = false;
            this.arrowDown = false;
            this.arrowLeft = false;
            this.arrowRight = false;
            this.keyUp = false;
            this.keyDown = false;
            this.keyLeft = false;
            this.keyRight = false;
            this.interval = MOVE_INTERVAL;
        }

        private void UpdatePlayersKeyEvents(Unit player, FIX.Direction direction)
        {
            // 通常動作モード
            int moveX = 0;
            int moveY = 0;

            AreaInformation area = ExistAreaFromLocation(player.GetNeighborhood(direction));
            if (area == null|| area.MoveCost >= 999)
            {
                keyDown = false;
                keyUp = false;
                keyLeft = false;
                keyRight = false;
                return;
            }

            //if (CheckBlueWall(direction))
            //{
            //    System.Threading.Thread.Sleep(100);
            //    return;
            //}

            Unit target = ExistUnitFromLocation(player.GetNeighborhood(direction));
            if (target != null && target.Dead == false && player.IsAlly && target.IsEnemy) { return; }
            if (target != null && target.Dead == false && player.IsEnemy && target.IsAlly) { return; }

            if (direction == FIX.Direction.Top) moveY = 1; // change unity
            else if (direction == FIX.Direction.Left) moveX = -1;
            else if (direction == FIX.Direction.Right) moveX = 1;
            else if (direction == FIX.Direction.Bottom) moveY = -1; // change unity

            JumpToLocation(player, (int)player.transform.position.x + moveX, (int)player.transform.position.y + moveY);
            //this.CameraView.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, this.CameraView.transform.position.z);

            // 移動時のタイル更新
            //bool lowSpeed = UpdateUnknownTile();

            // イベント発生
            //SearchSomeEvents();

            // ターゲットの位置を記憶
            this.shadowPosition = this.OwnerUnit.transform.position;

            this.MovementInterval = MOVE_INTERVAL;
        }

        private void JumpToLocation(Unit player, int x, int y)
        {
            if (player != null)
            {
                player.transform.localPosition = new Vector3(x, y, 0.0f);
                player.LifeGauge.transform.localPosition = new Vector3(x, y - 0.2f, player.LifeGauge.transform.localPosition.z);
            }
        }
    }
}