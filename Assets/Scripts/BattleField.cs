using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DigitalRuby.PyroParticles;
using System;
using UnityEngine.EventSystems;
using System.Reflection;

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
        public AreaInformation prefab_Bridge1;
        public AreaInformation prefab_Bridge2;
        public AreaInformation prefab_Road_V;
        public AreaInformation prefab_Road_H;
        public AreaInformation prefab_Wall_1;
        public AreaInformation prefab_Road_RB;
        public AreaInformation prefab_Road_LB;
        public AreaInformation prefab_Road_TR;
        public AreaInformation prefab_Road_TL;
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
        public Unit prefab_MonsterA;
        public Unit prefab_MonsterB;
        public Unit prefab_TimeKeeper;
        public GameObject prefab_Treasure;
        public Unit prefab_TreasureOpen;
        public GameObject prefab_Damage;
        // オブジェクト
        public Camera CameraView;
        private List<Unit> AllList = new List<Unit>();
        private List<Unit> AllyList = new List<Unit>();
        private List<Unit> EnemyList = new List<Unit>();
        private List<Unit> OtherList = new List<Unit>();
        private List<GameObject> TreasureList = new List<GameObject>();
        private List<AreaInformation> fieldTile = new List<AreaInformation>();
        private List<GameObject> MoveTile = new List<GameObject>();
        private List<GameObject> AttackTile = new List<GameObject>();
        private List<GameObject> AllyEffectTile = new List<GameObject>();
        private List<GameObject> HealTile = new List<GameObject>();
        public GameObject Cursor;
        public GameObject groupAction;
        public GameObject groupUnitStatus;
        public GameObject[] LifeBox;
        public GameObject txtUnitName;
        public Image UnitLifeMeter;
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
        public Text txtStrength;
        public Text txtAgility;
        public Text txtIntelligence;
        public Text txtMind;
        public Text txtMove;
        public Text txtOrder;
        public Text txtTime;
        public GameObject txtUnitName_mini;
        public Image UnitLifeMeter_mini;
        public Text UnitLifeText_mini;
        public Image UnitImage_mini;
        public Text txtStrength_mini;
        public Text txtAgility_mini;
        public Text txtIntelligence_mini;
        public Text txtMind_mini;
        public Text txtMove_mini;
        public Text txtOrder_mini;
        public Text txtTime_mini;
        public GameObject groupAP_mini;
        public List<Image> ActionPoint_mini = new List<Image>();

        public List<GameObject> orbList = new List<GameObject>();
        public GameObject FocusCursor;
        public GameObject groupAP;
        public List<Image> ActionPoint = new List<Image>();
        public List<GameObject> OrderList = new List<GameObject>();
        // GUIオブジェクト
        public List<GameObject> objActionButton = new List<GameObject>();

        // エフェクト用
        public GameObject[] fx_prefabs;
        public int index_fx = 0;
        public GameObject fx_FireRing;

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
            UntapStep,
            SelectFirst,
            //Upkeep,
            UpkeepAnimation,
            UpkeepExec,
            SelectMove,
            SelectCommand,
            SelectTarget,
            ExecCommand,
            ExecAnimation,
            ExecEnd,
            End
        }
        public enum CommandResult
        {
            None,
            Complete,
            Fail,
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
        public Unit CurrentEffect;
        private string currentCommand = string.Empty;
        private FIX.Direction currentDirection = FIX.Direction.None;
        private int currentDistance = 0;
        #endregion


        private int AutoClose = 300;
        private Vector3 dstView = new Vector3();
        private int CameraMove = 0;
        private int MAX_CAMERAMOVE = 10;

        private bool isDoubleTapStart; //タップ認識中のフラグ
        private bool isDoubleTapChatter; // ダブルタップ認識フェーズ中間フラグ
        private float doubleTapTime; //タップ開始からの累積時間
        private float dragTime; // タップ開始からドラッグしているまでの判定タイム

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
            ONE.UnitList[0].labelFullName = this.txtPlayerName;
            ONE.UnitList[0].labelRace = this.txtRace;
            ONE.UnitList[0].ImageRace = this.iconRace;
            ONE.UnitList[0].MeterExp = this.meterExp;

            this.interval = MOVE_INTERVAL;
            this.MovementInterval = MOVE_INTERVAL;

            // プレイヤー設定
            txtPlayerName.text = ONE.UnitList[0].FullName;
            for (int ii = 0; ii < ONE.UnitList[0].ObsidianStone; ii++)
            {
                orbList[ii].SetActive(true);
            }
            txtLevel.text = ONE.UnitList[0].Level.ToString();
            if (ONE.UnitList[0].Race == FIX.RaceType.Human) { txtRace.text = "人間族"; iconRace.GetComponent<Image>().sprite = Resources.Load<Sprite>("Icon_Human"); }
            //else if (ONE.Chara[0].Race == FIX.RaceType.Mech) { txtRace.text = "機巧族"; iconRace.GetComponent<Image>().sprite = Resources.Load<Sprite>("Icon_Mech"); }
            //else if (ONE.Chara[0].Race == FIX.RaceType.Angel) { txtRace.text = "天使族"; iconRace.GetComponent<Image>().sprite = Resources.Load<Sprite>("Icon_Angel"); }
            //else if (ONE.Chara[0].Race == FIX.RaceType.Demon) { txtRace.text = "魔貴族"; iconRace.GetComponent<Image>().sprite = Resources.Load<Sprite>("Icon_Demon"); }
            //else if (ONE.Chara[0].Race == FIX.RaceType.Fire) { txtRace.text = "炎霊族"; iconRace.GetComponent<Image>().sprite = Resources.Load<Sprite>("Icon_Fire"); }
            //else if (ONE.Chara[0].Race == FIX.RaceType.Ice) { txtRace.text = "氷霊族"; iconRace.GetComponent<Image>().sprite = Resources.Load<Sprite>("Icon_Ice"); }
            ONE.UnitList[0].UpdateExp();
            txtExp.text = "( " + ONE.UnitList[0].Exp.ToString() + " / " + ONE.UnitList[0].NextLevelBorder.ToString() + " )";


            #region "ステージのセットアップ"
            int column = DAT.COLUMN_1_1;
            int[] tileData = DAT.Tile1_1;
            int[] tileH = DAT.TileH1_1;
            if (ONE.CurrentStage == FIX.Stage.Stage1_1) { column = DAT.COLUMN_1_1; tileData = DAT.Tile1_1; tileH = DAT.TileH1_1; }
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
                else if (tileData[ii] == Convert.ToInt32(AreaInformation.Field.Bridge1))
                {
                    current = this.prefab_Bridge1;
                    current.field = AreaInformation.Field.Bridge1;
                }
                else if (tileData[ii] == Convert.ToInt32(AreaInformation.Field.Bridge2))
                {
                    current = this.prefab_Bridge2;
                    current.field = AreaInformation.Field.Bridge2;
                }
                else if (tileData[ii] == Convert.ToInt32(AreaInformation.Field.Road_V))
                {
                    current = this.prefab_Road_V;
                    current.field = AreaInformation.Field.Road_V;
                }
                else if (tileData[ii] == Convert.ToInt32(AreaInformation.Field.Road_H))
                {
                    current = this.prefab_Road_H;
                    current.field = AreaInformation.Field.Road_H;
                }
                else if (tileData[ii] == Convert.ToInt32(AreaInformation.Field.Wall_1))
                {
                    current = this.prefab_Wall_1;
                    current.field = AreaInformation.Field.Wall_1;
                }
                else if (tileData[ii] == Convert.ToInt32(AreaInformation.Field.Road_RB))
                {
                    current = this.prefab_Road_RB;
                    current.field = AreaInformation.Field.Road_RB;
                }
                else if (tileData[ii] == Convert.ToInt32(AreaInformation.Field.Road_LB))
                {
                    current = this.prefab_Road_LB;
                    current.field = AreaInformation.Field.Road_LB;
                }
                else if (tileData[ii] == Convert.ToInt32(AreaInformation.Field.Road_TR))
                {
                    current = this.prefab_Road_TR;
                    current.field = AreaInformation.Field.Road_TR;
                }
                else if (tileData[ii] == Convert.ToInt32(AreaInformation.Field.Road_TL))
                {
                    current = this.prefab_Road_TL;
                    current.field = AreaInformation.Field.Road_TL;
                }
                else
                {
                    Debug.Log("TapArea else routine..." + tileData[ii].ToString());
                }
                AreaInformation tile;
                tile = Instantiate(current, new Vector3(HEX_MOVE_X * (ii % column), HEX_MOVE_Z * (ii / column), -0.5f * tileH[ii]), Quaternion.identity) as AreaInformation;
                tile.transform.Rotate(new Vector3(0, 0, 0));
                tile.gameObject.SetActive(true);
                if (tileData[ii] == 0)
                {
                    tile.gameObject.SetActive(false);
                }
                tile.cost = -1;
                fieldTile.Add(tile);
            }

            // ノード情報を設定する。
            for (int ii = 0; ii < fieldTile.Count; ii++)
            {
                if (fieldTile[ii].field == AreaInformation.Field.None) { continue; }

                //Debug.Log("start fieldTile " + ii.ToString());
                Vector3 src = new Vector3(fieldTile[ii].transform.localPosition.x + 1,
                                          fieldTile[ii].transform.localPosition.y,
                                          fieldTile[ii].transform.localPosition.z);
                AreaInformation area = ExistAreaFromLocation(src);
                if (area != null)
                {
                    if (area.field != AreaInformation.Field.None)
                    {
                        fieldTile[ii].connectNode.Add(area);
                        //Debug.Log("add  " + ii.ToString() + " 1+");
                    }
                    else
                    {
                        //Debug.Log("none " + ii.ToString() + " 1 ");
                    }
                }
                else
                {
                    //Debug.Log("null " + ii.ToString() + " 1 ");
                }

                src = new Vector3(fieldTile[ii].transform.localPosition.x - 1,
                                  fieldTile[ii].transform.localPosition.y,
                                  fieldTile[ii].transform.localPosition.z);
                area = ExistAreaFromLocation(src);
                if (area != null)
                {
                    if (area.field != AreaInformation.Field.None)
                    {
                        fieldTile[ii].connectNode.Add(area);
                        //Debug.Log("add  " + ii.ToString() + " 2+");
                    }
                    else
                    {
                        //Debug.Log("none " + ii.ToString() + " 2 ");
                    }
                }
                else
                {
                    //Debug.Log("null " + ii.ToString() + " 2 ");
                }

                src = new Vector3(fieldTile[ii].transform.localPosition.x,
                                  fieldTile[ii].transform.localPosition.y + 1,
                                  fieldTile[ii].transform.localPosition.z);
                area = ExistAreaFromLocation(src);
                if (area != null)
                {
                    if (area.field != AreaInformation.Field.None)
                    {
                        fieldTile[ii].connectNode.Add(area);
                        //Debug.Log("add  " + ii.ToString() + " 3+");
                    }
                    else
                    {
                        //Debug.Log("none " + ii.ToString() + " 3 ");
                    }
                }
                else
                {
                    //Debug.Log("null " + ii.ToString() + " 3 ");
                }

                src = new Vector3(fieldTile[ii].transform.localPosition.x,
                                  fieldTile[ii].transform.localPosition.y - 1,
                                  fieldTile[ii].transform.localPosition.z);
                area = ExistAreaFromLocation(src);
                if (area != null)
                {
                    if (area.field != AreaInformation.Field.None)
                    {
                        fieldTile[ii].connectNode.Add(area);
                        //Debug.Log("add  " + ii.ToString() + " 4+");
                    }
                    else
                    {
                        //Debug.Log("none " + ii.ToString() + " 4 ");
                    }
                }
                else
                {
                    //Debug.Log("null " + ii.ToString() + " 4 ");
                }
            }

            if (ONE.CurrentStage == FIX.Stage.Stage1_1)
            {
                Debug.Log("stage Stage1_1");
                int counter = 0;
                Unit current = null;

                current = SetupUnit(0, Unit.Ally.TimerKeeper, FIX.RaceType.TimeKeeper, FIX.JobClass.TimeKeeper, 0, 0);
                OtherList.Add(current);
                AllList.Add(current);
                counter++;

                // ユニット配置
                int[] objList = DAT.OBJECT_1_1;
                int COLUMN = DAT.COLUMN_1_1;
                int unitNumber = 0;
                for (int ii = 0; ii < objList.Length; ii++)
                {
                    if (objList[ii] > 0)
                    {
                        Unit prefab = null;
                        switch (ONE.UnitList[unitNumber].Job)
                        {
                            case FIX.JobClass.Fighter:
                                Debug.Log("Fighter choice");
                                prefab = prefab_Fighter;
                                break;
                            case FIX.JobClass.Ranger:
                                Debug.Log("Ranger choice");
                                prefab = prefab_Archer;
                                break;
                            case FIX.JobClass.Magician:
                                Debug.Log("Magician choice");
                                prefab = prefab_Magician;
                                break;
                            default:
                                Debug.Log("default choice");
                                prefab = prefab_Fighter;
                                break;
                        }
                        float x = ii % COLUMN;
                        float y = ii / COLUMN;
                        x = x * FIX.HEX_MOVE_X;
                        y = y * FIX.HEX_MOVE_Z;

                        current = Instantiate(prefab, new Vector3(x, y, ExistAreaFromLocation(new Vector3(x, y, 0)).transform.localPosition.z - 0.5f), Quaternion.identity) as Unit;
                        current.FullName = ONE.UnitList[unitNumber].FullName;
                        current.Level = ONE.UnitList[unitNumber].Level;
                        current.Job = ONE.UnitList[unitNumber].Job;
                        current.Race = ONE.UnitList[unitNumber].Race;
                        current.BaseStrength = ONE.UnitList[unitNumber].BaseStrength;
                        current.BaseAgility = ONE.UnitList[unitNumber].BaseAgility;
                        current.BaseIntelligence = ONE.UnitList[unitNumber].BaseIntelligence;
                        current.BaseStamina = ONE.UnitList[unitNumber].BaseStamina;
                        current.BaseMind = ONE.UnitList[unitNumber].BaseMind;
                        current.MainWeapon = ONE.UnitList[unitNumber].MainWeapon;
                        current.SubWeapon = ONE.UnitList[unitNumber].SubWeapon;
                        current.MainArmor = ONE.UnitList[unitNumber].MainArmor;
                        current.Accessory = ONE.UnitList[unitNumber].Accessory;
                        current.Accessory2 = ONE.UnitList[unitNumber].Accessory2;
                        current.Accessory3 = ONE.UnitList[unitNumber].Accessory3;
                        current.Stone = ONE.UnitList[unitNumber].Stone;
                        current.ObsidianStone = ONE.UnitList[unitNumber].ObsidianStone;
                        for (int jj = 0; jj < ONE.UnitList[unitNumber].ActionButtonCommand.Count; jj++)
                        {
                            current.ActionButtonCommand.Add(ONE.UnitList[unitNumber].ActionButtonCommand[jj]);
                        }
                        current.Initialize(current.Race, current.Job, Unit.Ally.Ally);
                        current.name = current.FullName;
                        current.gameObject.SetActive(true);
                        AddUnitWithAdjustTime(current);
                        AllyList.Add(current);
                        AllList.Add(current);
                        counter++;
                        unitNumber++;
                    }
                }
                int[] enemyList = DAT.ENENMY_1_1;
                for (int ii = 0; ii < enemyList.Length; ii++)
                {
                    if (enemyList[ii] > 0)
                    {
                        current = SetupUnit(counter, Unit.Ally.Enemy, FIX.RaceType.Monster, (FIX.JobClass)(Enum.ToObject(typeof(FIX.JobClass), enemyList[ii])), ii % COLUMN, ii / COLUMN);
                        EnemyList.Add(current);
                        AllList.Add(current);
                        counter++;
                    }
                }
            }
            #endregion

            CameraView.transform.localPosition = new Vector3(5, 5, CameraView.transform.localPosition.z);

            // 通常移動モードでは、常にプレイヤ－１を選択する。
            for (int ii = 0; ii < AllyList.Count; ii++)
            {
                this.AllyList[ii].CleanUp();
            }
            this.CurrentUnit = AllyList[0];
            this.OwnerUnit = AllyList[0];
        }

        int counter1 = 0;
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

                    SceneManager.LoadSceneAsync(FIX.SCENE_GAMERESULT);
                }
                return;
            }
            #endregion

            // this.Phase == ActionPhase.SelectFirst
            if (CurrentUnit == null)
            {
                for (int ii = 0; ii < objActionButton.Count; ii++)
                {
                    objActionButton[ii].GetComponent<Button>().interactable = false;
                }
            }
            else if (CurrentUnit.IsEnemy)
            {
                for (int ii = 0; ii < objActionButton.Count; ii++)
                {
                    objActionButton[ii].GetComponent<Button>().interactable = false;
                }
            }
            else if (CurrentUnit.Job == FIX.JobClass.TimeKeeper)
            {
                for (int ii = 0; ii < objActionButton.Count; ii++)
                {
                    objActionButton[ii].GetComponent<Button>().interactable = false;
                }
            }
            else
            {
                for (int ii = 0; ii < objActionButton.Count; ii++)
                {
                    if (this.CurrentUnit.CurrentAP >= ActionCommand.UsedAP(this.CurrentUnit.ActionButtonCommand[ii]))
                    {
                        objActionButton[ii].GetComponent<Button>().interactable = true;
                    }
                    else
                    {
                        objActionButton[ii].GetComponent<Button>().interactable = false;
                    }
                }
            }

            if (CameraMove > 0)
            {
                float speed = 0.0f;
                if (CameraMove >= MAX_CAMERAMOVE - 2)
                {
                    speed = 2.0f / 10.0f;
                }
                else if (CameraMove >= MAX_CAMERAMOVE - 5)
                {
                    speed = 1.0f / 10.0f;
                }
                else
                {
                    speed = 0.25f / 10.0f;
                }
                CameraView.transform.localPosition = new Vector3(CameraView.transform.localPosition.x + dstView.x * speed,
                                                                CameraView.transform.localPosition.y + dstView.y * speed,
                                                                CameraView.transform.localPosition.z);
                CameraMove--;
            }
            // カーソル移動
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100))
            {
                GameObject obj = hit.collider.gameObject;
                // フィールド操作
                if (obj.layer == 11)
                {
                    Cursor.transform.localPosition = new Vector3(obj.transform.localPosition.x,
                                                                 obj.transform.localPosition.y,
                                                                 Cursor.transform.localPosition.z);
                }
                else
                {
                    Cursor.transform.localPosition = new Vector3(obj.transform.localPosition.x,
                                                                 obj.transform.localPosition.y,
                                                                 obj.transform.localPosition.z - 0.6f);
                }

                Unit target = ExistUnitFromLocation(Cursor.transform.localPosition);
                if (target != null)
                {
                    UpdateUnitStatusMini(target);
                    UpdateUnitAP(ActionPoint_mini, target);
                }
            }

            #region "カーソルとキー操作"
            if (MoveMode == FieldMode.Move)
            {
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

                // タイマー０ですでに順番が来ている場合、アクティブプレイヤーにする。(TimeKeeper -> Ally -> Enemyの順序)
                if (activePlayer == null)
                {
                    for (int ii = 0; ii < OtherList.Count; ii++)
                    {
                        if (OtherList[ii].Dead == false && OtherList[ii].CurrentTime <= 0)
                        {
                            activePlayer = OtherList[ii];
                            break;
                        }
                    }
                }
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

                // タイマー進行の結果０になった場合、アクティブプレイヤーにする。(TimeKeeper -> Ally -> Enemyの順序)
                if (activePlayer == null)
                {
                    for (int ii = 0; ii < EnemyList.Count; ii++)
                    {
                        if (EnemyList[ii].Dead == false)
                        {
                            EnemyList[ii].TimerProgress();
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
                            AllyList[ii].TimerProgress();
                            if (AllyList[ii].CurrentTime <= 0)
                            {
                                activePlayer = AllyList[ii];
                            }
                        }
                    }
                    for (int ii = 0; ii < OtherList.Count; ii++)
                    {
                        if (OtherList[ii].Dead == false)
                        {
                            OtherList[ii].TimerProgress();
                            if (OtherList[ii].CurrentTime <= 0)
                            {
                                activePlayer = OtherList[ii];
                            }
                        }
                    }
                }

                if (activePlayer != null)
                {
                    Debug.Log("ActivePlayer is " + activePlayer.UnitName);
                    TimeComparer comp = new TimeComparer();
                    AllList.Sort(comp);
                    Debug.Log("AllList count: " + AllList.Count.ToString());

                    UnitTimeSort();
                    //for (int ii = 0; ii < 12; ii++)
                    //{
                    //    if (ii >= AllList.Count) { break; }
                    //    int num = ii % AllList.Count;
                    //    Debug.Log("num: " + num.ToString());
                    //    Sprite sprite = null;
                    //    switch (AllList[ii].Job)
                    //    {
                    //        case FIX.JobClass.Fighter:
                    //            sprite = Resources.Load<Sprite>(FIX.UNIT_FIGHTER);
                    //            break;
                    //        case FIX.JobClass.Ranger:
                    //            sprite = Resources.Load<Sprite>(FIX.UNIT_RANGER);
                    //            break;
                    //        case FIX.JobClass.Magician:
                    //            sprite = Resources.Load<Sprite>(FIX.UNIT_MAGICIAN);
                    //            break;
                    //        case FIX.JobClass.MonsterA:
                    //            sprite = Resources.Load<Sprite>(FIX.UNIT_MONSTER_A);
                    //            break;
                    //        case FIX.JobClass.MonsterB:
                    //            sprite = Resources.Load<Sprite>(FIX.UNIT_MONSTER_B);
                    //            break;
                    //        case FIX.JobClass.TimeKeeper:
                    //            sprite = Resources.Load<Sprite>(FIX.UNIT_TIME_KEEPER);
                    //            break;
                    //        default:
                    //            sprite = Resources.Load<Sprite>(FIX.UNIT_FIGHTER);
                    //            break;
                    //    }
                    //    OrderList[ii].GetComponent<Image>().sprite = sprite;
                    //}

                    FocusCursor.transform.localPosition = new Vector3(activePlayer.transform.localPosition.x,
                                                                 activePlayer.transform.localPosition.y,
                                                                 -0.51f);

                    if (activePlayer.Race == FIX.RaceType.TimeKeeper)
                    {
                        for (int ii = 0; ii < AllList.Count; ii++)
                        {
                            AllList[ii].UpkeepCheck = false;
                        }
                    }
                    activePlayer.CurrentAP += 1;
                    UpdateUnitStatus(activePlayer);
                    UpdateUnitStatusMini(activePlayer);
                    UpdateUnitAP(ActionPoint, activePlayer);
                    this.groupAP.SetActive(true);
                    this.CurrentUnit = activePlayer;
                    this.Phase = ActionPhase.UntapStep;
                    MoveMode = FieldMode.Battle;
                }
            }
            #endregion

            #region "コマンド実行"
            #region "TimeKeeperフェーズ"
            if (this.CurrentUnit != null && this.CurrentUnit.Race == FIX.RaceType.TimeKeeper)
            {
                if (this.Phase == ActionPhase.End)
                {
                    Debug.Log("TimeKeeper End");
                    UnitEnd();
                }
                else if (this.Phase == ActionPhase.UntapStep)
                {
                    bool detect = false;
                    #region "各ユニットにかかっているエフェクトの経過ターンを更新させる"
                    for (int ii = 0; ii < AllList.Count; ii++)
                    {
                        AllList[ii].CleanUp();
                    }
                    #endregion

                    // 各ユニットにターンに応じた効果がかかっている場合、それを解決する。
                    for (int ii = 0; ii < AllList.Count; ii++)
                    {
                        if (AllList[ii].UpkeepCheck == false)
                        {
                            if (AllList[ii].CurrentPoison > 0)
                            {
                                Debug.Log("poison unit has detected, then poison damage.");
                                detect = true;
                                AllList[ii].UpkeepCheck = true;
                                CurrentEffect = AllList[ii];
                                AllList[ii].CurrentLife -= AllList[ii].CurrentPoisonValue;
                                currentCommand = FIX.EFFECT_POISON;
                                StartAnimation(AllList[ii], FIX.EFFECT_POISON, new Color(1.0f, 0.3f, 0.3f));
                                this.Phase = ActionPhase.ExecAnimation;
                                return;
                            }
                            if (AllList[ii].CurrentHeartOfLife > 0)
                            {
                                Debug.Log("HeartOfLife unit has detected, then gain life.");
                                detect = true;
                                AllList[ii].UpkeepCheck = true;
                                AllList[ii].CurrentHeartOfLife--;
                                CurrentEffect = AllList[ii];
                                currentCommand = FIX.EFFECT_HEART_OF_LIFE;
                                StartAnimation(AllList[ii], "LIFE +" + (AllList[ii].CurrentHeartOfLifeValue).ToString(), Color.yellow);
                                this.Phase = ActionPhase.ExecAnimation;
                                return;
                            }
                            if (AllList[ii].CurrentSlip > 0)
                            {
                                Debug.Log("Slip unit has detected, then poison damage.");
                                detect = true;
                                AllList[ii].UpkeepCheck = true;
                                CurrentEffect = AllList[ii];
                                AllList[ii].CurrentLife -= AllList[ii].CurrentSlipValue;
                                currentCommand = FIX.EFFECT_SLIP;
                                StartAnimation(AllList[ii], "SLIP -" + (AllList[ii].CurrentSlipValue).ToString(), Color.red);
                                this.Phase = ActionPhase.ExecAnimation;
                                return;
                            }
                        }
                    }

                    if (detect == false)
                    {
                        this.Phase = ActionPhase.End;
                    }
                }
                else if (this.Phase == ActionPhase.ExecAnimation)
                {
                    ExecAnimationDamage();
                    if (WaitAnimation()) { return; }
                    this.Phase = ActionPhase.ExecEnd;
                }
                else if (this.Phase == ActionPhase.ExecEnd)
                {
                    if (this.currentCommand == FIX.EFFECT_POISON)
                    {
                        EffectPoisonDamage(CurrentEffect, CurrentEffect);
                    }
                    if (this.currentCommand == FIX.EFFECT_HEART_OF_LIFE)
                    {
                        EffectHeartOfLife(CurrentEffect, CurrentEffect);
                    }

                    JudgeUnitDead();
                    JudgeGameEnd();
                    if (this.GameEnd == false)
                    {
                        this.Phase = ActionPhase.End;
                    }
                }
                return;
            }
            #endregion
            #region "敵フェーズ"
            if (this.CurrentUnit != null && this.CurrentUnit.IsAlly == false)
            {
                if (this.Phase == ActionPhase.End)
                {
                    Debug.Log("EnemyUnit End");
                    UnitEnd();
                }
                if (this.Phase == ActionPhase.UntapStep)
                {
                    Debug.Log("ActionPhase.UntapStep");
                    System.Threading.Thread.Sleep(300);

                    this.Phase = ActionPhase.SelectFirst;
                }
                if (Phase == ActionPhase.SelectFirst)
                {
                    Debug.Log("ActionPhase.SelectFirst");
                    System.Threading.Thread.Sleep(500);
                    UpdateUnitStatus(this.CurrentUnit);
                    UpdateUnitStatusMini(this.CurrentUnit);
                    OpenMoveable(this.CurrentUnit);
                    counter1++;
                    Talos.TraceOpponent(AllList, fieldTile, AllyList[0]);
                    this.Phase = ActionPhase.SelectMove;
                }
                else if (this.Phase == ActionPhase.SelectMove)
                {
                    Debug.Log("ActionPhase.SelectMove");
                    System.Threading.Thread.Sleep(100);

                    // 移動不可の場合、即座に終了する。
                    if (CurrentUnit.CurrentBind > 0)
                    {
                        this.Phase = ActionPhase.End;
                        ClearTile(MoveTile);
                        return;
                    }

                    // 目標地点に向かって移動する。
                    AreaInformation currentArea = ExistAreaFromLocation(CurrentUnit.transform.localPosition);
                    if (currentArea == null)
                    {
                        this.Phase = ActionPhase.End;
                        ClearTile(MoveTile);
                        return;
                    }
                    if (currentArea.toGoal != null)
                    {
                        Debug.Log("currentArea.togoal: " + currentArea.toGoal.cost.ToString());
                    }
                    // 次の地点が目標ポイントの場合、そこで止まる。
                    if (currentArea.toGoal != null && currentArea.toGoal.cost <= CurrentUnit.AttackRange - 1)
                    {
                        this.Phase = ActionPhase.SelectCommand;
                        ClearTile(MoveTile);
                        OpenAttackable(CurrentUnit, CurrentUnit.AttackRange, false);
                        return;
                    }
                    // 次の地点へ移動する。
                    if (currentArea.toGoal != null && CurrentUnit.CurrentMovePoint >= currentArea.toGoal.MoveCost)
                    {
                        CurrentUnit.CurrentMovePoint -= currentArea.toGoal.MoveCost;
                        JumpToLocation(CurrentUnit, (int)(currentArea.toGoal.transform.localPosition.x), (int)(currentArea.toGoal.transform.localPosition.y));
                    }
                    // 移動コストがなければ、終了する。
                    else
                    {
                        this.Phase = ActionPhase.End;
                        ClearTile(MoveTile);
                    }
                }
                else if (this.Phase == ActionPhase.SelectCommand)
                {
                    System.Threading.Thread.Sleep(100);
                    AreaInformation currentArea = ExistAreaFromLocation(CurrentUnit.transform.localPosition);
                    if (currentArea == null)
                    {
                        this.Phase = ActionPhase.End;
                        ClearTile(MoveTile);
                        return;
                    }
                    if (currentArea.toGoal != null)
                    {
                        Unit target = null;
                        #region "芋プログラミングだが良しとする。"
                        if (CurrentUnit.AttackRange == 0)
                        {
                            target = ExistUnitFromLocation(currentArea.transform.localPosition);
                        }
                        else if (CurrentUnit.AttackRange == 1)
                        {
                            target = ExistUnitFromLocation(currentArea.toGoal.transform.localPosition);
                        }
                        else if (CurrentUnit.AttackRange == 2)
                        {
                            target = ExistUnitFromLocation(currentArea.toGoal.toGoal.transform.localPosition);
                        }
                        else if (CurrentUnit.AttackRange == 3)
                        {
                            target = ExistUnitFromLocation(currentArea.toGoal.toGoal.toGoal.transform.localPosition);
                        }
                        #endregion

                        if (target == null)
                        {
                            this.Phase = ActionPhase.End;
                            ClearTile(MoveTile);
                            return;
                        }

                        if (CurrentUnit.Job == FIX.JobClass.MonsterA)
                        {
                            this.currentCommand = FIX.VENOM_SLASH;
                        }
                        else if (CurrentUnit.Job == FIX.JobClass.MonsterB)
                        {
                            this.currentCommand = FIX.NORMAL_ATTACK;
                        }
                        else
                        {
                            this.currentCommand = FIX.NORMAL_ATTACK;
                        }

                        this.CurrentTarget = target;

                        CurrentUnit.CurrentAP -= ActionCommand.UsedAP(currentCommand);
                        UpdateUnitAP(ActionPoint, CurrentUnit);

                        // タイルクリアする。
                        ClearTile(MoveTile);
                        ClearTile(AttackTile);
                        ClearTile(HealTile);
                        ClearTile(AllyEffectTile);
                        this.Phase = ActionPhase.ExecCommand;
                    }
                }
                else if (this.Phase == ActionPhase.ExecCommand)
                {
                    CommandResult result = ExecCommand(this.currentCommand, this.CurrentUnit, this.CurrentTarget);
                    if (result == CommandResult.Complete)
                    {
                        Debug.Log("detectAction true.");
                        GetTacticsPoint(this.CurrentUnit);
                        CurrentUnit.CurrentAP -= 2;
                        this.Phase = ActionPhase.ExecAnimation;
                    }
                    else if (result == CommandResult.Fail)
                    {
                        Debug.Log("Command fail, then End.");
                        this.Phase = ActionPhase.ExecAnimation;
                    }
                    else
                    {
                        Debug.Log("Unknown command, then End.");
                        this.Phase = ActionPhase.ExecAnimation;
                    }
                    //if (this.currentCommand == FIX.NORMAL_ATTACK)
                    //{
                    //    if (this.CurrentUnit.Type == Unit.UnitType.Magician)
                    //    {
                    //        ExecMagicAttack(CurrentUnit, CurrentTarget);
                    //    }
                    //    else
                    //    {
                    //        ExecNormalAttack(CurrentUnit, CurrentTarget);
                    //    }
                    //}
                    //else if (this.currentCommand == FIX.AURA_OF_POWER)
                    //{
                    //    ExecAuraOfPower(CurrentUnit, CurrentTarget);
                    //}
                    //else if (this.currentCommand == FIX.HUNTER_SHOT)
                    //{
                    //    ExecHunterShot(CurrentUnit, CurrentTarget);
                    //}
                    //else if (this.currentCommand == FIX.VENOM_SLASH)
                    //{
                    //    ExecVenomSlash(CurrentUnit, CurrentTarget);
                    //}
                    //else if (this.currentCommand == FIX.FIRE_BOLT)
                    //{
                    //    ExecFireBolt(CurrentUnit, CurrentTarget);
                    //}
                    //else if (this.currentCommand == FIX.ZERO_IMMUNITY)
                    //{
                    //    ExecZeroImmunity(CurrentUnit, CurrentTarget);
                    //}
                    //else if (this.currentCommand == FIX.INVISIBLE_BIND)
                    //{
                    //    ExecInvisibleBind(CurrentUnit, CurrentTarget);
                    //}
                    this.Phase = ActionPhase.ExecAnimation;
                }
                // アニメーション実行
                else if (this.Phase == ActionPhase.ExecAnimation)
                {
                    ExecAnimationDamage();
                    if (WaitAnimation()) { return; }
                    this.Phase = ActionPhase.ExecEnd;
                }
                // 実処理実行
                else if (this.Phase == ActionPhase.ExecEnd)
                {
                    Debug.Log("ExecEnd: " + this.currentCommand);

                    if (this.currentCommand == FIX.DASH)
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
                    JudgeGameEnd();
                    if (this.GameEnd == false)
                    {
                        this.Phase = ActionPhase.End;
                        ClearTile(MoveTile);
                    }
                }
                return;
            }
            #endregion
            #region "味方フェーズ"
            if (this.Phase == ActionPhase.UntapStep)
            {
                for (int ii = 0; ii < CurrentUnit.ActionButtonCommand.Count; ii++)
                {
                    SetupActionButton(objActionButton[ii], CurrentUnit.ActionButtonCommand[ii]);
                }

                this.Phase = ActionPhase.SelectFirst;
            }
            // 移動先を選択
            if (this.Phase == ActionPhase.SelectMove)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Debug.Log("mousedown, now CheckMoveableArea: " + Cursor.transform.localPosition.ToString());
                    if (CheckMoveableArea(Cursor.transform.localPosition))
                    {
                        Debug.Log("CheckMoveArea ok.");
                        Unit target = ExistUnitFromLocation(Cursor.transform.localPosition);
                        if (target != null && target.Equals(this.CurrentUnit) == false)
                        {
                            Debug.Log("already exist unit, then no action.");
                            return;
                        }

                        JumpToLocation(CurrentUnit, (int)Cursor.transform.localPosition.x, (int)Cursor.transform.localPosition.y);
                        ClearTile(MoveTile);

                        CurrentUnit.CurrentAP--;
                        UpdateUnitAP(ActionPoint, CurrentUnit);
                        this.Phase = ActionPhase.SelectFirst;
                    }
                    else
                    {
                        Debug.Log("CheckMoveArea: No exist.");
                    }
                }
            }
            // コマンド実行対象の選択
            else if (this.Phase == ActionPhase.SelectTarget)
            {
#if UNITY_EDITOR
                if (EventSystem.current.IsPointerOverGameObject())
                {
                    return;
                }
#else 
                if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId)) {
                    return;
                }
#endif
                else if (Input.GetMouseButtonDown(0))
                {
                    Debug.Log("GetMouseButton(0)");
                    ActionCommand.TargetType targetType = ActionCommand.GetTargetType(this.currentCommand);
                    Unit target = ExistUnitFromLocation(Cursor.transform.localPosition);

                    // 単一の敵対象
                    if (targetType == ActionCommand.TargetType.Enemy)
                    {
                        if (CheckAttackableArea(Cursor.transform.localPosition) == false)
                        {
                            Debug.Log("CheckAttackableArea out of area, then no action.");
                            return;
                        }
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
                        if (CurrentUnit.CurrentAP < 2)
                        {
                            Debug.Log("Not enough AP, then no action");
                            return;
                        }
                        if (target.CurrentZeroImmunity > 0)
                        {
                            Debug.Log("Target has ZeroImmunity, then no action");
                            return;
                        }
                    }
                    // 単一の味方対象(効果/回復)
                    else if (targetType == ActionCommand.TargetType.Ally)
                    {
                        Debug.Log("GetTargetType Ally routine.");

                        if (ActionCommand.IsHeal(currentCommand) && CheckAllyEffectArea(Cursor.transform.localPosition, HealTile) == false)
                        {
                            Debug.Log("CheckAllyEffectArea(Heal) out of area, then no action.");
                            return;
                        }
                        if (ActionCommand.IsHeal(currentCommand) == false && CheckAllyEffectArea(Cursor.transform.localPosition, AllyEffectTile) == false)
                        {
                            Debug.Log("CheckAllyEffectArea(Effect) out of area, then no action.");
                            return;
                        }
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
                    }
                    this.CurrentTarget = target;
                    ClearTile(MoveTile);
                    ClearTile(AttackTile);
                    ClearTile(HealTile);
                    ClearTile(AllyEffectTile);
                    JudgeGameEnd();
                    this.Phase = ActionPhase.ExecCommand;
                }
            }
            else if (this.Phase == ActionPhase.ExecCommand)
            {
                CommandResult result = ExecCommand(this.currentCommand, this.CurrentUnit, this.CurrentTarget);
                if (result == CommandResult.Complete)
                {
                    Debug.Log("ExecCommand detect Complete.");
                    GetTacticsPoint(this.CurrentUnit);
                    CurrentUnit.CurrentAP -= 2;
                }
                else if (result == CommandResult.Fail)
                {
                    Debug.Log("ExecCommand fail.");
                }
                else
                {
                    Debug.Log("Unknown command.");
                }
                UpdateUnitAP(ActionPoint, CurrentUnit);
                this.Phase = ActionPhase.ExecAnimation;
            }
            // アニメーション実行
            else if (this.Phase == ActionPhase.ExecAnimation)
            {
                ExecAnimationDamage();
                if (WaitAnimation()) { return; }

                this.Phase = ActionPhase.ExecEnd;
            }
            // 実処理実行
            else if (this.Phase == ActionPhase.ExecEnd)
            {
                Debug.Log("ExecEnd: " + this.currentCommand);

                JudgeUnitDead();
                JudgeGameEnd();
                if (this.GameEnd == false)
                {
                    this.Phase = ActionPhase.End;
                }
            }
            // 終了
            else if (this.Phase == ActionPhase.End)
            {
                UnitEnd();
            }
            #endregion
            #endregion
        }

        private CommandResult ExecCommand(string command, Unit player, Unit target)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S)");

            ActionCommand.TargetType targetType = ActionCommand.GetTargetType(command);

            // スペル属性で、沈黙状態のときは詠唱できない。
            if (ActionCommand.GetAttribute(command) == ActionCommand.Attribute.Spell && player.CurrentSilence > 0)
            {
                StartAnimation(player, FIX.STRING_MISS, new Color(1.0f, 1.0f, 1.0f));
                return CommandResult.Fail;
            }
            // スキル属性で、封技状態のときは技を使えない。
            if (ActionCommand.GetAttribute(command) == ActionCommand.Attribute.Skill && player.CurrentSeal > 0)
            {
                StartAnimation(player, FIX.STRING_MISS, new Color(1.0f, 1.0f, 1.0f));
                return CommandResult.Fail;
            }
            // 単一の敵対象時のミス判定
            if (targetType == ActionCommand.TargetType.Enemy)
            {
                Debug.Log("GetTargetType Enemy routine.");

                if (target == null)
                {
                    Debug.Log("unit is not exist, then no action.");
                    return CommandResult.Fail;
                }
                if ((player.IsAlly && target.IsAlly) || (player.IsEnemy && target.IsEnemy))
                {
                    Debug.Log("unit is ally -> ally or enemy -> enemy, then no action");
                    return CommandResult.Fail;
                }
                // ターゲット選定後、ターゲット不可の場合
                if (target.CurrentZeroImmunity > 0)
                {
                    Debug.Log("Target has ZeroImmunity, then no action");
                    StartAnimation(this.CurrentTarget, FIX.STRING_MISS, new Color(1.0f, 1.0f, 1.0f));
                    return CommandResult.Fail;
                }
                // 暗闇状態でミスした場合
                if (CurrentUnit.CurrentBlind > 0)
                {
                    int random = AP.Math.RandomInteger(100);
                    if (random < CurrentUnit.CurrentBlindValue)
                    {
                        Debug.Log("Attack has missed. then no damage.");
                        StartAnimation(this.CurrentTarget, FIX.STRING_MISS, new Color(1.0f, 1.0f, 1.0f));
                        return CommandResult.Fail;
                    }
                }
            }
            // 単一の味方対象(効果/回復)
            if (targetType == ActionCommand.TargetType.Ally)
            {
                Debug.Log("GetTargetType Ally routine.");

                if (target == null)
                {
                    Debug.Log("unit is not exist, then no action.");
                    return CommandResult.Fail;
                }
                if ((player.IsAlly && target.IsEnemy) || (player.IsEnemy && target.IsAlly))
                {
                    Debug.Log("unit is ally -> enemy or enemy -> ally, then no action");
                    return CommandResult.Fail;
                }
            }

            // コマンド実行
            if (command == FIX.NORMAL_ATTACK)
            {
                if (player.Job == FIX.JobClass.Magician)
                {
                    ExecMagicAttack(player, target);
                }
                else
                {
                    ExecNormalAttack(player, target);
                }
            }
            else if (command == FIX.VENOM_SLASH)
            {
                ExecVenomSlash(player, target);
            }
            else if (command == FIX.DOUBLE_SLASH)
            {
                ExecDoubleSlash(player, target);
            }
            else if (command == FIX.STANCE_OF_THE_BLADE)
            {
                ExecStanceOfBlade(player, target);
            }
            else if (command == FIX.STANCE_OF_THE_GUARD)
            {
                ExecStanceOfGuard(player, target);
            }
            else if (command == FIX.STRAIGHT_SMASH)
            {
                ExecStraightSmash(player, target);
            }
            else if (command == FIX.FIRE_BOLT)
            {
                ExecFireBolt(player, target);
            }
            else if (command == FIX.VENOM_SLASH)
            {
                ExecVenomSlash(player, target);
            }
            else if (command == FIX.SHADOW_BLAST)
            {
                ExecShadowBlast(player, target);
            }
            else if (command == FIX.HUNTER_SHOT)
            {
                ExecHunterShot(player, target);
            }
            else if (command == FIX.ICE_NEEDLE)
            {
                ExecIceNeedle(player, target);
            }
            else if (command == FIX.SHIELD_BASH)
            {
                ExecShieldBash(player, target);
            }
            else if (command == FIX.DASH)
            {
                int move = 0;
                FIX.Direction direction = ExistAttackableUnitLinerGroup(ref move, player, target, player.EffectRange);
                for (int ii = 0; ii < move; ii++)
                {
                    //if (player.CurrentEarthBind > 0) // アースバインドでダッシュの移動を防ぐことはできない。
                    player.Move(direction);
                }
                int damage = 0;
                damage = (int)(PrimaryLogic.PhysicalAttack(player, PrimaryLogic.NeedType.Random, 1.0F, 0.0F, 0.0F, 0.0F));
                ExecDash(player, target);

                StartAnimation(target, damage.ToString(), new Color(1.0f, 0.3f, 0.3f));
            }
            else if (command == FIX.NEEDLESPEAR)
            {
                int damage = (int)(PrimaryLogic.PhysicalAttack(player, PrimaryLogic.NeedType.Random, 1.0F, 0.0F, 0.0F, 0.0F));
                ExecNeedleSpear(player, target);
                StartAnimation(target, damage.ToString(), new Color(1.0f, 0.3f, 0.3f));
            }
            else if (command == FIX.SILVERARROW)
            {
                int damage = (int)(PrimaryLogic.MagicAttack(player, PrimaryLogic.NeedType.Random, 1.0F, 0.0F, 0.0F, 0.0F));
                ExecSilverArrow(player, target);
                StartAnimation(target, damage.ToString(), new Color(1.0f, 0.3f, 0.3f));
            }
            else if (command == FIX.EARTHBIND)
            {
                ExecEarthBind(player, target);
                StartAnimation(target, "BIND", new Color(1.0f, 0.3f, 0.3f));
            }
            else if (command == FIX.EXPLOSION)
            {
                int damage = (int)(PrimaryLogic.MagicAttack(player, PrimaryLogic.NeedType.Random, 1.0F, 0.0F, 0.0F, 0.0F));
                ExecExplosion(player, target);
                StartAnimation(target, damage.ToString(), new Color(1.0f, 0.3f, 0.3f));
            }
            else if (command == FIX.REACHABLETARGET)
            {
                ExecReachableTarget(player, target);
                StartAnimation(target, "TARGET", new Color(1.0f, 0.3f, 0.3f));
            }
            else if (command == FIX.BLOOD_SIGN)
            {
                ExecBloodSign(player, target);
                StartAnimation(target, FIX.BLOOD_SIGN, Color.black);
            }
            else if (command == FIX.DISPEL_MAGIC)
            {
                ExecDispelMagic(player, target);
            }
            else if (command == FIX.MULTIPLE_SHOT)
            {
                List<Unit> targetList = new List<Unit>();
                for (int ii = 0; ii < AttackTile.Count; ii++)
                {
                    Unit current = ExistUnitFromLocation(AttackTile[ii].transform.localPosition);
                    if (current != null && current.IsEnemy)
                    {
                        targetList.Add(current);
                    }
                }
                ExecMultipleShot(player, targetList);
            }
            else if (command == FIX.FRESH_HEAL)
            {
                ExecFreshHeal(player, target);
                StartAnimation(target, ActionCommand.EffectValue(command).ToString(), Color.yellow);
            }
            else if (command == FIX.HEALINGWORD)
            {
                ExecHealingWord(player, target);
                StartAnimation(target, ActionCommand.EffectValue(command).ToString(), Color.yellow);
            }
            else if (command == FIX.POWERWORD)
            {
                ExecPowerWord(player, target);
                StartAnimation(target, "STR +" + ActionCommand.EffectValue(command).ToString(), Color.yellow);
            }
            else if (command == FIX.PROTECTION)
            {
                ExecProtection(player, target);
                StartAnimation(target, "DEF +" + ActionCommand.EffectValue(command).ToString(), Color.yellow);
            }
            else if (command == FIX.HEATBOOST)
            {
                ExecHeatBoost(player, target);
                StartAnimation(target, "SPD +" + ActionCommand.EffectValue(command).ToString(), Color.yellow);
            }
            else if (command == FIX.AURA_OF_POWER)
            {
                ExecAuraOfPower(player, target);
            }
            else if (command == FIX.HEART_OF_THE_LIFE)
            {
                ExecHeartOfTheLife(player, target);
            }
            else if (command == FIX.ORACLE_COMMAND)
            {
                ExecOracleCommand(player, target);
            }
            else if (command == FIX.SKY_SHIELD)
            {
                ExecSkyShield(player, target);
            }
            else if (command == FIX.FORTUNE_SPIRIT)
            {
                ExecFortuneSpirit(player, target);
            }
            else if (command == FIX.FLAME_BLADE)
            {
                ExecFlameBlade(player, target);
            }
            else if (command == FIX.STORM_ARMOR)
            {
                ExecStormArmor(player, target);
            }
            else if (command == FIX.ZERO_IMMUNITY)
            {
                ExecZeroImmunity(player, target);
            }
            else if (command == FIX.PURE_PURIFICATION)
            {
                ExecPurePurification(player, target);
            }
            else if (command == FIX.DIVINE_CIRCLE)
            {
                List<Unit> targetList = new List<Unit>();
                targetList.Add(target);
                //for (int ii = 0; ii < AllyEffectTile.Count; ii++)
                //{
                //    Unit current = ExistUnitFromLocation(AllyEffectTile[ii].transform.localPosition);
                //    if (current != null && current.IsAlly)
                //    {
                //        targetList.Add(current);
                //    }
                //}
                ExecDivineCircle(player, targetList);
            }
            else
            {
                Debug.Log("Unknown command, then End.");
                Debug.Log("debug routine 1003");
                Debug.Log("Unknown command: " + command);
                return CommandResult.Fail;
            }
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(E)");
            return CommandResult.Complete;
        }

        private void UnitEnd()
        {
            if (CurrentUnit != null)
            {
                CurrentUnit.Completed();
                AdjustTime(this.CurrentUnit);
            }
            JudgeGameEnd();
            this.groupAP.SetActive(false);
            this.currentCommand = String.Empty;
            this.currentDirection = FIX.Direction.None;
            this.currentDistance = 0;
            this.CurrentUnit = null;
            this.CurrentTarget = null;
            this.CurrentEffect = null;
            this.Phase = ActionPhase.WaitActive;
        }
        
        #region "Canvasイベント"
        public void TapAction()
        {
            groupAction.SetActive(true);
        }
        public void TapMove()
        {
            OpenMoveable(this.CurrentUnit);
            this.Phase = ActionPhase.SelectMove;
        }
        public void TapCancel()
        {
            Debug.Log("TapCancel(S)");
            ExecCancel(CurrentUnit);
        }
        public void TapEnd()
        {
            this.Phase = ActionPhase.End;
        }

        public void tapCommand(int number)
        {
            if (number >= 1 && (CurrentUnit.CurrentAP < ActionCommand.UsedAP(CurrentUnit.ActionButtonCommand[number])))
            {
                Debug.Log("Not enough AP, then no action");
                return;
            }
            Debug.Log("tapCommand: " + number.ToString());
            if (number == 0)
            {
                if (this.CurrentUnit.CurrentBind > 0)
                {
                    Debug.Log("Cannot Move cause CurrentBind is " + this.CurrentUnit.CurrentBind.ToString());
                    return;
                }
                OpenMoveable(this.CurrentUnit);
                this.Phase = ActionPhase.SelectMove;
            }
            else
            {
                currentCommand = objActionButton[number].name;
                switch (ActionCommand.GetTargetType(currentCommand))
                {
                    case ActionCommand.TargetType.Ally:
                        if (ActionCommand.IsHeal(currentCommand))
                        {
                            OpenEffectArea(this.CurrentUnit, ActionCommand.AreaRange(CurrentUnit, currentCommand), HealTile, prefab_HealTile);
                        }
                        else
                        {
                            OpenEffectArea(this.CurrentUnit, ActionCommand.AreaRange(CurrentUnit, currentCommand), AllyEffectTile, prefab_AllyEffectTile);
                        }
                        this.Phase = ActionPhase.SelectTarget;
                        break;
                    case ActionCommand.TargetType.Enemy:
                        OpenAttackable(this.CurrentUnit, ActionCommand.AreaRange(CurrentUnit, currentCommand), false);
                        this.Phase = ActionPhase.SelectTarget;
                        break;
                    case ActionCommand.TargetType.AllyOrEnemy:
                        // todo AllyOrEnemy用のタイル指定
                        break;
                    case ActionCommand.TargetType.AllyGroup:
                        break;
                    case ActionCommand.TargetType.EnemyGroup:
                        break;
                    case ActionCommand.TargetType.Area:
                        break;
                    case ActionCommand.TargetType.AllMember:
                        break;
                    case ActionCommand.TargetType.Own:
                        ExecCommand(currentCommand, CurrentUnit, CurrentUnit);
                        break;
                    case ActionCommand.TargetType.InstantTarget:
                        break;
                    case ActionCommand.TargetType.NoTarget:
                        break;
                    default:
                        break;
                }
            }
        }
        #endregion

        /// <summary>
        /// アクションボタンを設定する
        /// </summary>
        /// <param name="actionButton"></param>
        /// <param name="sorceryMark"></param>
        /// <param name="actionCommand"></param>
        private void SetupActionButton(GameObject actionButton, string actionCommand)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S) " + actionCommand);
            if (actionCommand != null && actionCommand != "" && actionCommand != string.Empty)
            {
                actionButton.GetComponent<Image>().sprite = Resources.Load<Sprite>(actionCommand);
                actionButton.name = actionCommand;
            }
            else
            {
                actionButton.GetComponent<Image>().sprite = Resources.Load<Sprite>(FIX.NORMAL_ATTACK);
                actionButton.name = FIX.NORMAL_ATTACK;
            }
        }
        private void UpdateLife(Unit unit, Text txt, Image meter)
        {
            txt.text = unit.CurrentLife.ToString() + "  /  " + unit.MaxLife.ToString();

            float dx = (float)unit.CurrentLife / (float)unit.MaxLife;
            if (meter != null)
            {
                meter.rectTransform.localScale = new Vector2(dx, 1.0f);
            }
        }

        private void UpdateUnitImage(Unit unit, Image image)
        {
            image.sprite = Resources.Load<Sprite>("Unit_" + unit.Job.ToString());
        }

        private int ANIMATION_LENGTH = 100;
        private const int MAX_ANIMATION_COUNT = 100;
        private List<GameObject> currentDamageObject = new List<GameObject>(MAX_ANIMATION_COUNT);
        private List<string> nowAnimationString = new List<string>(MAX_ANIMATION_COUNT);
        private List<int> nowAnimationCounter = new List<int>(MAX_ANIMATION_COUNT);
        private List<Vector3> ExecAnimation_basePoint = new List<Vector3>(MAX_ANIMATION_COUNT);

        private void StartAnimation(Unit unit, string message, Color color)
        {
            this.currentDamageObject.Add(GameObject.Instantiate(prefab_Damage));
            this.nowAnimationString.Add(message);
            this.nowAnimationCounter.Add(0);
            this.ExecAnimation_basePoint.Add(currentDamageObject[currentDamageObject.Count - 1].transform.position);
            this.currentDamageObject[currentDamageObject.Count - 1].GetComponent<TextMesh>().color = color;
            this.currentDamageObject[currentDamageObject.Count - 1].transform.localPosition = new Vector3(unit.transform.localPosition.x, unit.transform.localPosition.y, unit.transform.localPosition.z - 1);
            //this.currentDamageObject[currentDamageObject.Count - 1].SetActive(true);
        }
        private void ExecAnimationDamage()
        {
            for (int ii = 0; ii < this.currentDamageObject.Count; ii++)
            {
                if (this.currentDamageObject[ii] == null) { continue; }

                currentDamageObject[ii].SetActive(true);
                currentDamageObject[ii].GetComponent<TextMesh>().text = nowAnimationString[ii];
                if (this.nowAnimationCounter[ii] <= 0)
                {
                    ExecAnimation_basePoint[ii] = currentDamageObject[ii].transform.position;
                }

                float movement = 0.05f;
                if (this.nowAnimationCounter[ii] > 10) { movement = 0; }
                currentDamageObject[ii].transform.position = new Vector3(currentDamageObject[ii].transform.position.x + movement, currentDamageObject[ii].transform.position.y, currentDamageObject[ii].transform.position.z);

                this.nowAnimationCounter[ii]++;
                if (this.nowAnimationCounter[ii] > ANIMATION_LENGTH)
                {
                    this.currentDamageObject[ii].transform.position = ExecAnimation_basePoint[ii];
                    this.currentDamageObject[ii].SetActive(false);
                    this.currentDamageObject[ii] = null;
                    this.currentDamageObject.RemoveAt(ii);
                    this.nowAnimationString.RemoveAt(ii);
                    this.nowAnimationCounter.RemoveAt(ii);
                    this.ExecAnimation_basePoint.RemoveAt(ii);
                }
                return;
            }
        }
        private bool WaitAnimation()
        {
            if (currentDamageObject.Count > 0) { return true; }
            Debug.Log("WaitAnimation end");
            return false;
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
            if (area == null || area.MoveCost >= 999)
            {
                keyDown = false;
                keyUp = false;
                keyLeft = false;
                keyRight = false;
                return;
            }

            Unit target = ExistUnitFromLocation(player.GetNeighborhood(direction));
            if (target != null && target.Dead == false && player.IsAlly && target.IsEnemy) { return; }
            if (target != null && target.Dead == false && player.IsEnemy && target.IsAlly) { return; }

            if (direction == FIX.Direction.Top) moveY = 1; // change unity
            else if (direction == FIX.Direction.Left) moveX = -1;
            else if (direction == FIX.Direction.Right) moveX = 1;
            else if (direction == FIX.Direction.Bottom) moveY = -1; // change unity

            JumpToLocation(player, (int)player.transform.position.x + moveX, (int)player.transform.position.y + moveY);

            this.MovementInterval = MOVE_INTERVAL;
        }

        private void JumpToLocation(Unit player, int x, int y)
        {
            if (player != null)
            {
                player.transform.localPosition = new Vector3(x, y, ExistAreaFromLocation(new Vector3(x, y, 0)).transform.localPosition.z - 0.5f);
            }
        }

        #region "Battle Method"
        private void NowPoison(Unit player, Unit target)
        {
            target.CurrentPoison = 3;
            target.CurrentPoisonValue = 2;
        }
        private void NowBlind(Unit player, Unit target)
        {
            target.CurrentBlind = 3;
            target.CurrentBlindValue = 30;
        }
        private void NowBind(Unit player, Unit target)
        {
            target.CurrentBind = 2;
            target.CurrentBindValue = 0; // no used
        }
        private void NowSilence(Unit player, Unit target)
        {
            target.CurrentSilence = 2;
            target.CurrentSilenceValue = 100;
        }
        private void NowSeal(Unit player, Unit target)
        {
            target.CurrentSeal = 2;
            target.CurrentSealValue = 100;
        }
        private void NowSlow(Unit player, Unit target)
        {
            target.CurrentSlow = 2;
            target.CurrentSlowValue = 2;
        }
        #endregion

        #region "処理系"
        private void UnitTimeSort()
        {
            int detectCounter = 0;

            // 現在値をシャドウに設定
            for (int ii = 0; ii < AllList.Count; ii++)
            {
                AllList[ii].ShadowCurrentTime = AllList[ii].CurrentTime;
            }

            // 無限ループ（ユニット順序格納リストの個数分まで到達したら抜ける)
            for (int ii = 0; ii < FIX.INFINITY; ii++)
            {
                if (detectCounter >= OrderList.Count) { break; }

                Unit activePlayer = null;
                // タイマー０ですでに順番が来ている場合、アクティブプレイヤーにする。(TimeKeeper -> Ally -> Enemyの順序)
                if (activePlayer == null)
                {
                    for (int jj = 0; jj < OtherList.Count; jj++)
                    {
                        if (OtherList[jj].Dead == false && OtherList[jj].ShadowCurrentTime <= 0)
                        {
                            activePlayer = OtherList[jj];
                            break;
                        }
                    }
                }
                if (activePlayer == null)
                {
                    for (int jj = 0; jj < AllyList.Count; jj++)
                    {
                        if (AllyList[jj].Dead == false && AllyList[jj].ShadowCurrentTime <= 0)
                        {
                            activePlayer = AllyList[jj];
                            break;
                        }
                    }
                }
                if (activePlayer == null)
                {
                    for (int jj = 0; jj < EnemyList.Count; jj++)
                    {
                        if (EnemyList[jj].Dead == false && EnemyList[jj].ShadowCurrentTime <= 0)
                        {
                            activePlayer = EnemyList[jj];
                            break;
                        }
                    }
                }

                // タイマー進行の結果０になった場合、アクティブプレイヤーにする。(TimeKeeper -> Ally -> Enemyの順序)
                if (activePlayer == null)
                {
                    for (int jj = 0; jj < EnemyList.Count; jj++)
                    {
                        if (EnemyList[jj].Dead == false)
                        {
                            EnemyList[jj].ShadowTimerProgress();
                            if (EnemyList[jj].ShadowCurrentTime <= 0)
                            {
                                activePlayer = EnemyList[jj];
                            }
                        }
                    }

                    for (int jj = 0; jj < AllyList.Count; jj++)
                    {
                        if (AllyList[jj].Dead == false)
                        {
                            AllyList[jj].ShadowTimerProgress();
                            if (AllyList[jj].ShadowCurrentTime <= 0)
                            {
                                activePlayer = AllyList[jj];
                            }
                        }
                    }
                    for (int jj = 0; jj < OtherList.Count; jj++)
                    {
                        if (OtherList[jj].Dead == false)
                        {
                            OtherList[jj].ShadowTimerProgress();
                            if (OtherList[jj].ShadowCurrentTime <= 0)
                            {
                                activePlayer = OtherList[jj];
                            }
                        }
                    }
                }

                if (activePlayer != null)
                {
                    Sprite sprite = null;
                    switch (activePlayer.Job)
                    {
                        case FIX.JobClass.Fighter:
                            sprite = Resources.Load<Sprite>(FIX.UNIT_FIGHTER);
                            break;
                        case FIX.JobClass.Ranger:
                            sprite = Resources.Load<Sprite>(FIX.UNIT_RANGER);
                            break;
                        case FIX.JobClass.Magician:
                            sprite = Resources.Load<Sprite>(FIX.UNIT_MAGICIAN);
                            break;
                        case FIX.JobClass.MonsterA:
                            sprite = Resources.Load<Sprite>(FIX.UNIT_MONSTER_A);
                            break;
                        case FIX.JobClass.MonsterB:
                            sprite = Resources.Load<Sprite>(FIX.UNIT_MONSTER_B);
                            break;
                        case FIX.JobClass.TimeKeeper:
                            sprite = Resources.Load<Sprite>(FIX.UNIT_TIME_KEEPER);
                            break;
                        default:
                            sprite = Resources.Load<Sprite>(FIX.UNIT_FIGHTER);
                            break;
                    }
                    OrderList[detectCounter].GetComponent<Image>().sprite = sprite;
                    detectCounter++;

                    activePlayer.ShadowCurrentTime = FIX.MAX_TIME;
                }
            }
        }
        #endregion
    }

    //並び替える方法を定義するクラス
    //IComparerインターフェイスを実装する
    public class TimeComparer : System.Collections.Generic.IComparer<Unit>
    {
        //xがyより小さいときはマイナスの数、大きいときはプラスの数、同じときは0を返す
        public int Compare(Unit x, Unit y)
        {
            //nullが最も小さいとする
            if (x == null && y == null)
            {
                return 0;
            }
            if (x == null)
            {
                return -1;
            }
            if (y == null)
            {
                return 1;
            }

            return ((Unit)x).CurrentTime.CompareTo(((Unit)y).CurrentTime);
        }
    }
}