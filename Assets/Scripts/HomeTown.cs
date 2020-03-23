using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace ObsidianPortal
{
    public class HomeTown : MotherForm
    {
        public GameObject groupTopMenu;
        public GameObject groupActionMenu;

        public GameObject groupBackpack;
        public GameObject groupCharacter;
        public GameObject groupDungeonPlayer;
        public GameObject groupShop;
        public GameObject groupInn;
        public GameObject groupDuelColosseum;
        public GameObject groupTransferGate;

        public Button btnDungeon;
        public Button btnMonsterQuest;
        public Button btnMemberTalk;
        public Button btnShop;
        public Button btnInn;
        public Button btnDuelColosseum;
        public Button btnTransferGate;

        public Button btnCharacter;
        public Button btnBattleSetting;
        public Button btnSave;
        public Button btnExit;

        // Message
        public GameObject groupMessage;
        public Text txtMessage;
        public Image panelHide;
        public Button btnOK;
        private List<string> m_list = new List<string>();
        private List<MessagePack.ActionEvent> e_list = new List<MessagePack.ActionEvent>();
        private int nowReading = 0;
        private bool nowHideing;
        public Text systemMessage;
        public GameObject systemMessagePanel;

        // DungeonPlayer
        public GameObject nodeDungeon;
        public GameObject contentDungeon;
        private List<GameObject> DungeonList = new List<GameObject>();

        // MonsterQuest
        public GameObject nodeMonsterQuest;
        public GameObject contentMonsterQuest;
        private List<GameObject> MonsterQuestList = new List<GameObject>();

        // Shop
        public GameObject nodeItem;
        public GameObject contentItem;
        private List<GameObject> ItemList = new List<GameObject>();
        private List<string> ShopItemList = new List<string>();
        // Shop-Confirm
        private Item CurrentSelectItem = null;
        public GameObject filterConfrim;
        public Image confirmImgItem;
        public Text confirmTxtItem;
        public Text confirmTxtGold;
        private List<GameObject> CharacterList = new List<GameObject>();

        // Inn
        public GameObject nodeInnFood;
        public GameObject contentInnFood;
        private List<GameObject> InnFoodList = new List<GameObject>();

        // Duel
        public GameObject nodeDuelist;
        public GameObject contentDuelist;
        private List<GameObject> DuelistList = new List<GameObject>();

        // HomeTown
        public Text txtDate;
        public Text txtArea;
        public Text txtGold;
        public Text txtSoulFragment;
        public Text txtObsidianStone;

        // Character
        public GameObject nodeCharacter;
        public GameObject contentCharacter;
        private Vector2 contentCharacterBase = new Vector2();
        public GameObject groupCharacterDetail;
        public GameObject groupEquipChange;
        private Unit CurrentUnit;
        private FIX.EquipItemType currentEquipType;
        public GameObject nodeEquipChange;
        public GameObject contentEquipChange;
        private List<GameObject> EquipChangeList = new List<GameObject>();
        public GameObject groupActionCommandSetting;
        public GameObject nodeActionCommand;
        public GameObject contentActionCommand;
        private List<GameObject> ACPrimaryList = new List<GameObject>();
        private Vector2 contentActionCommandBase = new Vector2();
        public GameObject contentACSecondary;
        private List<GameObject> ACSecondaryList = new List<GameObject>();
        private Vector2 contentACSecondaryBase = new Vector2();

        // Backpack
        public GameObject nodeBackpack;
        public GameObject contentBackpack;
        public List<GameObject> BackpackList = new List<GameObject>();
        public GameObject groupBackpackDetail;

        private bool firstAction = false;

        private const string CONST_STR_GOLD = "gold";

        // Use this for initialization
        public override void Start()
        {
            base.Start();

            txtMessage.text = "アイン：さて、何すっかな。";
        }

        // Update is called once per frame
        public override void Update()
        {
            base.Update();

            if (firstAction == false)
            {
                UpdateHomeTownView();
                firstAction = true;

                #region "アクションメニューの内容設定"
                // ダンジョンのリスト設定
                {
                    List<Sprite> imgMainList = new List<Sprite>();
                    imgMainList.Add(Resources.Load<Sprite>("Field_Forest"));
                    imgMainList.Add(Resources.Load<Sprite>("Field_Forest"));
                    imgMainList.Add(Resources.Load<Sprite>("Field_Forest"));
                    imgMainList.Add(Resources.Load<Sprite>("Field_Forest"));
                    imgMainList.Add(Resources.Load<Sprite>("Field_Forest"));
                    imgMainList.Add(Resources.Load<Sprite>("Field_Forest"));
                    imgMainList.Add(Resources.Load<Sprite>("Field_Forest"));
                    imgMainList.Add(Resources.Load<Sprite>("Field_Forest"));
                    imgMainList.Add(Resources.Load<Sprite>("Field_Forest"));
                    imgMainList.Add(Resources.Load<Sprite>("Field_Forest"));
                    imgMainList.Add(Resources.Load<Sprite>("Field_Forest"));
                    imgMainList.Add(Resources.Load<Sprite>("Field_Forest"));
                    imgMainList.Add(Resources.Load<Sprite>("Field_Forest"));
                    imgMainList.Add(Resources.Load<Sprite>("Field_Forest"));
                    imgMainList.Add(Resources.Load<Sprite>("Field_Forest"));
                    imgMainList.Add(Resources.Load<Sprite>("Field_Forest"));
                    imgMainList.Add(Resources.Load<Sprite>("Field_Forest"));
                    imgMainList.Add(Resources.Load<Sprite>("Field_Forest"));
                    imgMainList.Add(Resources.Load<Sprite>("Field_Forest"));
                    imgMainList.Add(Resources.Load<Sprite>("Field_Forest"));
                    List<string> textTopList = new List<string>();
                    textTopList.Add(FIX.FIELD_ESMILIA_GRASS_AREA);
                    textTopList.Add(FIX.FIELD_ARTHARIUM_FACTORY);
                    textTopList.Add(FIX.FIELD_GORATRUM_DUNGEON);
                    textTopList.Add(FIX.FIELD_ZHALMAN_VILLAGE);
                    textTopList.Add(FIX.FIELD_KIZIK_MOUNTAIN_ROAD);
                    textTopList.Add(FIX.FIELD_ORAN_TOWER);
                    textTopList.Add(FIX.FIELD_ESMILIA_GRASS_TOWNROD);
                    textTopList.Add(FIX.FIELD_VELGUS_SEA_TEMPLE);
                    textTopList.Add(FIX.FIELD_MOONFORDER_SNOW_AREA);
                    textTopList.Add(FIX.FIELD_RUINS_OF_SARITAN);
                    textTopList.Add(FIX.FIELD_WOSM_ISOLATED_ISLAND);
                    textTopList.Add(FIX.FIELD_VINSGARDE_OLDROAD);
                    textTopList.Add(FIX.FIELD_DISKEL_BATTLE_FIELD);
                    textTopList.Add(FIX.FIELD_GANRO_FORTRESS);
                    textTopList.Add(FIX.FIELD_LOSLON_DUNGEON);
                    textTopList.Add(FIX.FIELD_EDELGARZEN_CASTLE);
                    textTopList.Add(FIX.FIELD_MYSTIC_ZELMAN);
                    textTopList.Add(FIX.FIELD_SNOWTREE_LATA);
                    textTopList.Add(FIX.FIELD_KILCOOD_MOUNTAIN_AREA);
                    textTopList.Add(FIX.FIELD_HEAVENS_GENESIS_GATE);
                    List<string> textCenterList = new List<string>();
                    textCenterList.Add("サンプル１");
                    textCenterList.Add("サンプル２");
                    textCenterList.Add("サンプル３");
                    textCenterList.Add("サンプル４");
                    textCenterList.Add("サンプル５");
                    textCenterList.Add("サンプル６");
                    textCenterList.Add("サンプル７");
                    textCenterList.Add("サンプル８");
                    textCenterList.Add("サンプル９");
                    textCenterList.Add("サンプル１０");
                    textCenterList.Add("サンプル１１");
                    textCenterList.Add("サンプル１２");
                    textCenterList.Add("サンプル１３");
                    textCenterList.Add("サンプル１４");
                    textCenterList.Add("サンプル１５");
                    textCenterList.Add("サンプル１６");
                    textCenterList.Add("サンプル１７");
                    textCenterList.Add("サンプル１８");
                    textCenterList.Add("サンプル１９");
                    textCenterList.Add("サンプル２０");
                    List<string> textBottomList = new List<string>();
                    for (int ii = 0; ii < textTopList.Count; ii++)
                    {
                        textBottomList.Add("決定");
                    }
                    AbstractConstructPanel(contentDungeon, nodeDungeon, ref DungeonList, false, imgMainList, textTopList, textCenterList, textBottomList);
                }

                // モンスタークエストのリスト設定
                {
                    List<Sprite> imgMainList = new List<Sprite>();
                    imgMainList.Add(Resources.Load<Sprite>("Icon_demon"));
                    imgMainList.Add(Resources.Load<Sprite>("Icon_demon"));
                    imgMainList.Add(Resources.Load<Sprite>("Icon_demon"));
                    imgMainList.Add(Resources.Load<Sprite>("Icon_demon"));
                    imgMainList.Add(Resources.Load<Sprite>("Icon_demon"));
                    imgMainList.Add(Resources.Load<Sprite>("Icon_demon"));
                    List<string> textTopList = new List<string>();
                    textTopList.Add("モンスター１");
                    textTopList.Add("モンスター２");
                    textTopList.Add("モンスター３");
                    textTopList.Add("モンスター４");
                    textTopList.Add("モンスター５");
                    textTopList.Add("モンスター６");
                    List<string> textCenterList = new List<string>();
                    textCenterList.Add("サンプル１");
                    textCenterList.Add("サンプル２");
                    textCenterList.Add("サンプル３");
                    textCenterList.Add("サンプル４");
                    textCenterList.Add("サンプル５");
                    textCenterList.Add("サンプル６");
                    List<string> textBottomList = new List<string>();
                    for (int ii = 0; ii < textTopList.Count; ii++)
                    {
                        textBottomList.Add("討伐");
                    }
                    AbstractConstructPanel(contentMonsterQuest, nodeMonsterQuest, ref MonsterQuestList, false, imgMainList, textTopList, textCenterList, textBottomList);
                }

                // ショップアイテムのリスト設定
                {
                    // アイテムリストの初期設定
                    List<Item> vendorItemList = new List<Item>();
                    vendorItemList.Add(new Item(FIX.COMMON_FINE_SWORD));
                    vendorItemList.Add(new Item(FIX.COMMON_FINE_BOW));
                    vendorItemList.Add(new Item(FIX.COMMON_FINE_SHIELD));
                    vendorItemList.Add(new Item(FIX.COMMON_NORMAL_RED_POTION));

                    // 抽象化ロジックの部分
                    List<Sprite> imgMainList = new List<Sprite>();
                    imgMainList.Add(Resources.Load<Sprite>(null));
                    imgMainList.Add(Resources.Load<Sprite>(null));
                    imgMainList.Add(Resources.Load<Sprite>(null));
                    imgMainList.Add(Resources.Load<Sprite>(null));
                    List<string> textTopList = new List<string>();
                    for (int ii = 0; ii < vendorItemList.Count; ii++)
                    {
                        textTopList.Add(vendorItemList[ii].ItemName);
                    }
                    List<string> textCenterList = new List<string>();
                    for (int ii = 0; ii < vendorItemList.Count; ii++)
                    {
                        textCenterList.Add(vendorItemList[ii].Description);
                    }
                    List<string> textBottomList = new List<string>();
                    for (int ii = 0; ii < textTopList.Count; ii++)
                    {
                        textBottomList.Add(vendorItemList[ii].Cost.ToString() + " " + CONST_STR_GOLD);
                    }
                    AbstractConstructPanel(contentItem, nodeItem, ref ItemList, false, imgMainList, textTopList, textCenterList, textBottomList);
                }

                // 宿屋メニューのリスト設定
                {
                    List<Sprite> imgMainList = new List<Sprite>();
                    imgMainList.Add(Resources.Load<Sprite>("Mark_Inn"));
                    imgMainList.Add(Resources.Load<Sprite>("Mark_Inn"));
                    imgMainList.Add(Resources.Load<Sprite>("Mark_Inn"));
                    imgMainList.Add(Resources.Load<Sprite>("Mark_Inn"));
                    imgMainList.Add(Resources.Load<Sprite>("Mark_Inn"));
                    imgMainList.Add(Resources.Load<Sprite>("Mark_Inn"));
                    List<string> textTopList = new List<string>();
                    textTopList.Add(FIX.FOOD_KATUCARRY);
                    textTopList.Add(FIX.FOOD_OLIVE_AND_ONION);
                    textTopList.Add(FIX.FOOD_INAGO_AND_TAMAGO);
                    textTopList.Add(FIX.FOOD_USAGI);
                    textTopList.Add(FIX.FOOD_SANMA);
                    List<string> textCenterList = new List<string>();
                    textCenterList.Add(FIX.DESC_11_MINI);
                    textCenterList.Add(FIX.DESC_12_MINI);
                    textCenterList.Add(FIX.DESC_13_MINI);
                    textCenterList.Add(FIX.DESC_14_MINI);
                    textCenterList.Add(FIX.DESC_15_MINI);
                    List<string> textBottomList = new List<string>();
                    for (int ii = 0; ii < textTopList.Count; ii++)
                    {
                        textBottomList.Add("決定");
                    }
                    AbstractConstructPanel(contentInnFood, nodeInnFood, ref InnFoodList, false, imgMainList, textTopList, textCenterList, textBottomList);
                }

                // Duelistのリスト設定
                {
                    List<Sprite> imgMainList = new List<Sprite>();
                    imgMainList.Add(Resources.Load<Sprite>("Mark_Dungeon"));
                    imgMainList.Add(Resources.Load<Sprite>("Mark_Dungeon"));
                    imgMainList.Add(Resources.Load<Sprite>("Mark_Dungeon"));
                    imgMainList.Add(Resources.Load<Sprite>("Mark_Dungeon"));
                    imgMainList.Add(Resources.Load<Sprite>("Mark_Dungeon"));
                    imgMainList.Add(Resources.Load<Sprite>("Mark_Dungeon"));
                    List<string> textTopList = new List<string>();
                    textTopList.Add(FIX.NAME_EONE_FULNEA);
                    textTopList.Add(FIX.NAME_MAGI_ZELKIS);
                    textTopList.Add(FIX.NAME_SELMOI_RO);
                    textTopList.Add(FIX.NAME_KARTIN_MAI);
                    textTopList.Add(FIX.NAME_JEDA_ARUS);
                    textTopList.Add(FIX.NAME_SINIKIA_VEILHANZ);
                    List<string> textCenterList = new List<string>();
                    textCenterList.Add(FIX.DUEL_DESC_001);
                    textCenterList.Add(FIX.DUEL_DESC_002);
                    textCenterList.Add(FIX.DUEL_DESC_003);
                    textCenterList.Add(FIX.DUEL_DESC_004);
                    textCenterList.Add(FIX.DUEL_DESC_005);
                    textCenterList.Add(FIX.DUEL_DESC_006);
                    List<string> textBottomList = new List<string>();
                    for (int ii = 0; ii < textTopList.Count; ii++)
                    {
                        textBottomList.Add("決闘");
                    }
                    AbstractConstructPanel(contentDuelist, nodeDuelist, ref DuelistList, false, imgMainList, textTopList, textCenterList, textBottomList);
                }
                #endregion

                // キャラクターのリスト設定
                RectTransform rect = nodeCharacter.GetComponent<RectTransform>();
                AbstractContentPanel(contentCharacter, nodeCharacter, 0, -rect.sizeDelta.y, 0, FIX.LAYOUT_MARGIN);

                // バックパックのリスト設定
                int detect = 0;
                GameObject content = contentBackpack;
                GameObject node = nodeBackpack;
                RectTransform contentRect = content.GetComponent<RectTransform>();
                contentRect.sizeDelta = new Vector2(1, contentRect.sizeDelta.y);
                float contentHeight = 60.0f;
                Debug.Log("backpack count: " + ONE.BP.BackpackList.Count.ToString());
                for (int ii = 0; ii < ONE.BP.BackpackList.Count; ii++)
                {
                    GameObject obj = GameObject.Instantiate(node);
                    obj.transform.SetParent(content.transform, false);
                    obj.transform.localPosition = new Vector3(obj.transform.localPosition.x, obj.transform.localPosition.y - contentHeight * detect, obj.transform.localPosition.z);
                    obj.SetActive(true);
                    obj.name = "" + (ii + 1).ToString("D3");
                    // 個数に応じて、コンテンツ長さを延長する。
                    contentRect.sizeDelta = new Vector2(contentRect.sizeDelta.x, contentRect.sizeDelta.y + contentHeight);

                    Text[] txtList2 = obj.GetComponentsInChildren<Text>();
                    for (int jj = 0; jj < txtList2.Length; jj++)
                    {
                        if (txtList2[jj].name == "txtBackpack")
                        {
                            txtList2[jj].text = ONE.BP.BackpackList[ii].ItemName;
                        }
                    }

                    Image[] imgList2 = obj.GetComponentsInChildren<Image>();
                    for (int jj = 0; jj < imgList2.Length; jj++)
                    {
                        if (imgList2[jj].name == "imgBackpack")
                        {
                            Method.UpdateItemImage(ONE.BP.BackpackList[ii], imgList2[jj]);
                            Method.UpdateRareColor(ONE.BP.BackpackList[ii], Method.SearchTextGameObject(obj, "txtBackpack"), Method.SearchBackGameObject(obj, "backBackpack").gameObject, null);
                        }
                    }

                    BackpackList.Add(obj);
                    detect++;
                }
                // 最後に余白を追加しておく。
                contentRect.sizeDelta = new Vector2(contentRect.sizeDelta.x, contentRect.sizeDelta.y + FIX.LAYOUT_MARGIN);
            }
        }

        public void TapActionMenuButton(int number)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S)");
            switch (number)
            {
                case 0:
                    CallQuest();
                    break;
                case 1:
                    CallBackpack();
                    break;
                case 2:
                    CallCharacter();
                    break;
                case 3:
                    CallDungeon();
                    break;
                case 4:
                    CallShop();
                    break;
                case 5:
                    CallInn();
                    break;
                case 6:
                    CallDuel();
                    break;
                case 7:
                    CallTransferGate();
                    break;
                default:
                    Debug.Log("default button has tapped, then no action.");
                    break;
            }
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(E)");
        }
        
        public void TapBackpack(Text item)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S)");
            Debug.Log("backitem: " + item.text);
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(E)");
        }

        public void TapDungeonChallenge(Text txtObj)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S)");
            ONE.CurrentArea = txtObj.text;
            SceneManager.LoadScene(FIX.SCENE_BATTLEFIELD);
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(E)");
        }

        public void TapBuyItem(Text item)
        {
            CurrentSelectItem = new Item(item.text);
            Method.UpdateItemImage(CurrentSelectItem, confirmImgItem);
            confirmTxtItem.text = CurrentSelectItem.ItemName;
            confirmTxtGold.text = CurrentSelectItem.Cost.ToString() + " " + CONST_STR_GOLD;
            filterConfrim.SetActive(true);
        }

        public void TapConfirm()
        {
            ONE.BP.AddBackPack(CurrentSelectItem, 1);
            CurrentSelectItem = null;
            filterConfrim.SetActive(false);
        }
        public void TapCancel()
        {
            CurrentSelectItem = null;
            filterConfrim.SetActive(false);
        }

        private void CallQuest()
        {
            UpdateGroupView(true, false, false, false, false, false, false, false);
            ExecQuest();
        }
        private void CallBackpack()
        {
            UpdateGroupView(false, true, false, false, false, false, false, false);
        }
        private void CallCharacter()
        {
            UpdateGroupView(false, false, true, false, false, false, false, false);
        }
        private void CallDungeon()
        {
            UpdateGroupView(false, false, false, true, false, false, false, false);
        }
        private void CallShop()
        {
            UpdateGroupView(false, false, false, false, true, false, false, false);
        }
        private void CallInn()
        {
            UpdateGroupView(false, false, false, false, false, true, false, false);
        }
        private void CallDuel()
        {
            UpdateGroupView(false, false, false, false, false, false, true, false);
        }
        private void CallTransferGate()
        {
            UpdateGroupView(false, false, false, false, false, false, false, true);
        }
        private void UpdateGroupView(bool g1, bool g2, bool g3, bool g4, bool g5, bool g6, bool g7, bool g8)
        {
            groupMessage.SetActive(g1);
            groupBackpack.SetActive(g2);
            groupCharacter.SetActive(g3);
            groupDungeonPlayer.SetActive(g4);
            groupShop.SetActive(g5);
            groupInn.SetActive(g6);
            groupDuelColosseum.SetActive(g7);
            groupTransferGate.SetActive(g8);
        }

        private void UpdateHomeTownView()
        {
            txtDate.text = ONE.Day.ToString() + "日目";
            txtGold.text = ONE.Gold.ToString();
            txtArea.text = ONE.HomeTownArea;
            txtSoulFragment.text = ONE.SoulFragment.ToString();
            txtObsidianStone.text = ONE.ObsidianStone.ToString();
        }

        public void TapOK()
        {
            bool ForceSkipTapOK = false;

            if (this.nowReading < this.m_list.Count)
            {
                // 非表示のメッセージ枠を表示する。
                if (this.panelHide.isActiveAndEnabled == false && this.nowHideing)
                {
                    this.panelHide.gameObject.SetActive(true);
                }
                this.groupMessage.SetActive(true);
                this.btnOK.enabled = true;
                this.btnOK.gameObject.SetActive(true);

                // メッセージ処理
                MessagePack.ActionEvent current = this.e_list[this.nowReading];
                if (current == MessagePack.ActionEvent.HomeTownMessageDisplay)
                {
                    systemMessage.text = this.m_list[this.nowReading];
                    systemMessagePanel.SetActive(true);
                }
                else
                {
                    systemMessagePanel.SetActive(false);
                    systemMessage.text = "";
                    txtMessage.text = this.m_list[this.nowReading];
                    //GroundOne.playbackMessage.Add(this.m_list[this.nowReading]);
                }

                // イベント毎の処理
                if (current == MessagePack.ActionEvent.AutoSaveWorldEnvironment)
                {
                    Method.AutoSaveTruthWorldEnvironment();
                    ForceSkipTapOK = true;
                }

                this.nowReading++;
                if (this.m_list[this.nowReading - 1] == "" || ForceSkipTapOK)
                {
                    TapOK();
                }
            }

            if (this.nowReading >= this.m_list.Count)
            {
                this.nowReading = 0;
                this.m_list.Clear();
                this.e_list.Clear();

                this.systemMessage.text = "";
                this.systemMessagePanel.SetActive(false);
                this.txtMessage.text = "";
                this.groupMessage.SetActive(false);
                this.nowHideing = false;
                this.panelHide.gameObject.SetActive(false);
                this.btnOK.enabled = false;
                this.btnOK.gameObject.SetActive(false);
                this.groupMessage.SetActive(false);
            }
        }

        /// <summary>
        /// アクションメニューから呼び出されるコンテンツリストを設定する。
        /// </summary>
        private void AbstractConstructPanel(GameObject content, GameObject node, ref List<GameObject> memorizedList, bool vertical, List<Sprite> imgMainList, List<string> textTopList, List<string> textCenterList, List<string> textBottomList)
        {
            int detect = 0;
            float contentWidth = 0.0f;
            float contentHeight = 0.0f;
            int marginX = 0;
            int marginY = 0;
            RectTransform contentRect = content.GetComponent<RectTransform>();
            if (vertical)
            {
                contentRect.sizeDelta = new Vector2(contentRect.sizeDelta.x, 1);
                contentWidth = 0.0f;
                contentHeight = node.GetComponent<RectTransform>().sizeDelta.y;
                marginX = 0;
                marginY = FIX.LAYOUT_MARGIN;
            }
            else
            {
                contentRect.sizeDelta = new Vector2(1, contentRect.sizeDelta.y);
                contentWidth = node.GetComponent<RectTransform>().sizeDelta.x;
                contentHeight = 0.0f;
                marginX = FIX.LAYOUT_MARGIN;
                marginY = 0;
            }
            for (int ii = 0; ii < textTopList.Count; ii++)
            {
                GameObject obj = GameObject.Instantiate(node);
                obj.transform.SetParent(content.transform, false);
                obj.transform.localPosition = new Vector3(obj.transform.localPosition.x + contentWidth * detect, obj.transform.localPosition.y + contentHeight * detect, obj.transform.localPosition.z);
                obj.SetActive(true);
                obj.name = "" + (ii + 1).ToString("D3");
                // 個数に応じて、コンテンツ長さを延長する。
                contentRect.sizeDelta = new Vector2(contentRect.sizeDelta.x + contentWidth, contentRect.sizeDelta.y + contentHeight);

                Text[] txtList = obj.GetComponentsInChildren<Text>();
                for (int jj = 0; jj < txtList.Length; jj++)
                {
                    if (txtList[jj].name == "txtTop")
                    {
                        txtList[jj].text = textTopList[ii];
                    }
                    else if (txtList[jj].name == "txtCenter")
                    {
                        txtList[jj].text = textCenterList[ii];
                    }
                    else if (txtList[jj].name == "txtBottom")
                    {
                        txtList[jj].text = textBottomList[ii];
                    }
                }
                Image[] imgList = obj.GetComponentsInChildren<Image>();
                for (int jj = 0; jj < imgList.Length; jj++)
                {
                    if (imgList[jj].name == "imgMain")
                    {
                        // イメージ指定がある場合は、直接設定
                        if (imgMainList[ii])
                        {
                            imgList[jj].sprite = imgMainList[ii];
                        }
                        // nullで指定がない場合は、Methodで検索して適用する。
                        else
                        {
                            Method.UpdateItemImage(new Item(textTopList[ii]), imgList[jj]);
                        }
                    }
                }
                memorizedList.Add(obj);
                detect++;
            }
            // 最後に余白を追加しておく。
            contentRect.sizeDelta = new Vector2(contentRect.sizeDelta.x + marginX, contentRect.sizeDelta.y + marginY);
        }

        private void AbstractContentPanel(GameObject content, GameObject node, float contentWidth, float contentHeight, int marginX, int marginY)
        {
            int detect = 0;
            RectTransform contentRect = content.GetComponent<RectTransform>();
            Debug.Log("AbstractContentPanel: " + contentRect.sizeDelta.y.ToString());
            if (this.contentCharacterBase.x <= 0.0f && this.contentCharacterBase.y <= 0)
            {
                this.contentCharacterBase = new Vector2(1, contentRect.sizeDelta.y);
            }
            contentRect.sizeDelta = new Vector2(this.contentCharacterBase.x, this.contentCharacterBase.y);

            for (int ii = 0; ii < ONE.UnitList.Count; ii++)
            {
                GameObject obj = GameObject.Instantiate(node);
                obj.transform.SetParent(content.transform, false);
                obj.transform.localPosition = new Vector3(obj.transform.localPosition.x + contentWidth * detect, obj.transform.localPosition.y + contentHeight * detect, obj.transform.localPosition.z);
                obj.SetActive(true);
                obj.name = "" + (ii + 1).ToString("D3");
                // 個数に応じて、コンテンツ長さを延長する。
                contentRect.sizeDelta = new Vector2(contentRect.sizeDelta.x, contentRect.sizeDelta.y + contentHeight);

                Text[] txtList = obj.GetComponentsInChildren<Text>();
                for (int jj = 0; jj < txtList.Length; jj++)
                {
                    if (txtList[jj].name == "txtCharacterName")
                    {
                        txtList[jj].text = ONE.UnitList[ii].FullName;
                    }
                    else if (txtList[jj].name == "txtLevel")
                    {
                        txtList[jj].text = ONE.UnitList[ii].Level.ToString();
                    }
                    else if (txtList[jj].name == "txtLife")
                    {
                        txtList[jj].text = ONE.UnitList[ii].MaxLife.ToString();
                    }
                    else if (txtList[jj].name == "txtStrength")
                    {
                        txtList[jj].text = ONE.UnitList[ii].TotalStrength.ToString();
                    }
                    else if (txtList[jj].name == "txtAgility")
                    {
                        txtList[jj].text = ONE.UnitList[ii].TotalAgility.ToString();
                    }
                    else if (txtList[jj].name == "txtIntelligence")
                    {
                        txtList[jj].text = ONE.UnitList[ii].TotalIntelligence.ToString();
                    }
                    else if (txtList[jj].name == "txtStamina")
                    {
                        txtList[jj].text = ONE.UnitList[ii].TotalStamina.ToString();
                    }
                    else if (txtList[jj].name == "txtMind")
                    {
                        txtList[jj].text = ONE.UnitList[ii].TotalMind.ToString();
                    }
                    else if (txtList[jj].name == "txtMainWeapon")
                    {
                        if (ONE.UnitList[ii].MainWeapon != null)
                        {
                            txtList[jj].text = ONE.UnitList[ii].MainWeapon.ItemName;
                        }
                        else
                        {
                            txtList[jj].text = string.Empty;
                        }
                    }
                    else if (txtList[jj].name == "txtActionCommand")
                    {
                        txtList[jj].text = ONE.UnitList[ii].ActionButtonCommand[0];
                    }
                }

                Text txtRareColor = Method.SearchTextGameObject(obj, "txtMainWeapon");
                Image imgBack = Method.SearchBackGameObject(obj, "backMainWeapon");

                Image[] imgList = obj.GetComponentsInChildren<Image>();
                for (int jj = 0; jj < imgList.Length; jj++)
                {
                    if ((ONE.UnitList[ii].MainWeapon != null) &&
                        (imgList[jj].name == "imgMainWeapon"))
                    {
                        Method.UpdateItemImage(ONE.UnitList[ii].MainWeapon, imgList[jj]);
                        Method.UpdateRareColor(ONE.UnitList[ii].MainWeapon, txtRareColor, imgBack.gameObject, null);
                    }
                    else if (imgList[jj].name == "imgJobClass")
                    {
                        Debug.Log("imgJobClass detect");
                        Method.UpdateJobClassImage(ONE.UnitList[ii].Job, imgList[jj]);
                    }
                    else if (imgList[jj].name == "imgActionCommand")
                    {
                        Debug.Log("imgActionCommand detect");
                        imgList[jj].sprite = Resources.Load<Sprite>(ONE.UnitList[ii].ActionButtonCommand[0]);
                    }
                }
                CharacterList.Add(obj);
                detect++;
            }
            // 最後に余白を追加しておく。
            contentRect.sizeDelta = new Vector2(contentRect.sizeDelta.x + marginX, contentRect.sizeDelta.y + marginY);

        }

        private void BuyItem(int gold)
        {
            ONE.UnitList[0].Gold -= gold;
        }

        public void TapActionCommandSetting(Text txtCharacter)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S)");

            RectTransform contentRect = contentActionCommand.GetComponent<RectTransform>();
            RectTransform nodeRect = nodeActionCommand.GetComponent<RectTransform>();
            float topMargin = 0;
            float leftMargin = 20;
            float margin = 40;
            float width = nodeRect.sizeDelta.x;
            contentRect.anchoredPosition = new Vector2(0, 0);

            List<string> ActionCommandList = ActionCommand.GetActionCommandPrimary(txtCharacter.text);
            List<int> RequiredLvList = ActionCommand.GetRequiredLV(txtCharacter.text);
            for (int ii = 0; ii < ActionCommandList.Count; ii++)
            {
                GameObject obj = GameObject.Instantiate(this.nodeActionCommand);
                obj.transform.SetParent(this.contentActionCommand.transform);
                obj.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                RectTransform rect = obj.GetComponent<RectTransform>();
                rect.anchorMin = new Vector2(0, 0.5f);
                rect.anchorMax = new Vector2(0, 0.5f);
                rect.pivot = new Vector2(0, 0.5f);
                rect.anchoredPosition = new Vector3(leftMargin + (width + margin) * ii, topMargin);
                obj.SetActive(true);

                // 個数に応じて、コンテンツ長さを延長する。
                contentRect.sizeDelta = new Vector2(contentRect.sizeDelta.x + width + margin, contentRect.sizeDelta.y);

                Text[] txtList = obj.GetComponentsInChildren<Text>();
                for (int jj = 0; jj < txtList.Length; jj++)
                {
                    if (txtList[jj].name == "txtActionCommand")
                    {
                        txtList[jj].text = ActionCommandList[ii];
                        Method.SetupActionCommand(obj, ActionCommandList[ii]);
                    }
                    if (txtList[jj].name == "txtActionRequired")
                    {
                        txtList[jj].text = "Required LV " + RequiredLvList[ii].ToString();
                    }
                }
                ACPrimaryList.Add(obj);
            }

            RectTransform contentRectAC = contentACSecondary.GetComponent<RectTransform>();
            List<string> ActionCommandSecondaryList = ActionCommand.GetActionCommandSecondary(txtCharacter.text);
            contentRectAC.anchoredPosition = new Vector2(0, 0);

            for (int ii = 0; ii < ActionCommandSecondaryList.Count; ii++)
            {
                GameObject obj = GameObject.Instantiate(this.nodeActionCommand);
                obj.transform.SetParent(this.contentACSecondary.transform);
                obj.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                RectTransform rect = obj.GetComponent<RectTransform>();
                rect.anchoredPosition = new Vector3(leftMargin + (width + margin) * ii, topMargin);
                obj.SetActive(true);

                // 個数に応じて、コンテンツ長さを延長する。
                contentRectAC.sizeDelta = new Vector2(contentRectAC.sizeDelta.x + width + margin, contentRectAC.sizeDelta.y);

                Text[] txtList = obj.GetComponentsInChildren<Text>();
                for (int jj = 0; jj < txtList.Length; jj++)
                {
                    if (txtList[jj].name == "txtActionCommand")
                    {
                        txtList[jj].text = ActionCommandSecondaryList[ii];
                        Method.SetupActionCommand(obj, ActionCommandSecondaryList[ii]);
                    }
                    if (txtList[jj].name == "txtActionRequired")
                    {
                        txtList[jj].text = "Required LV " + RequiredLvList[ii].ToString();
                    }
                }
                ACSecondaryList.Add(obj);
            }
            groupActionCommandSetting.SetActive(true);
        }

        public void TapActionCommandSettingCancel()
        {
            groupActionCommandSetting.SetActive(false);
            RectTransform contentRect = contentActionCommand.GetComponent<RectTransform>();
            if (this.contentActionCommandBase.x <= 0.0f && this.contentActionCommandBase.y <= 0)
            {
                this.contentActionCommandBase = new Vector2(1, contentRect.sizeDelta.y);
            }
            contentRect.sizeDelta = new Vector2(this.contentActionCommandBase.x, this.contentActionCommandBase.y);

            for (int ii = 0; ii < ACPrimaryList.Count; ii++)
            {
                ACPrimaryList[ii].transform.parent = null;
            }
            ACPrimaryList.Clear();


            RectTransform contentRect2 = contentACSecondary.GetComponent<RectTransform>();
            if (this.contentACSecondaryBase.x <= 0.0f && this.contentACSecondaryBase.y <= 0.0f)
            {
                this.contentACSecondaryBase = new Vector2(1, contentRect2.sizeDelta.y);
            }
            contentRect2.sizeDelta = new Vector2(this.contentACSecondaryBase.x, this.contentACSecondaryBase.y);

            for (int ii = 0; ii < ACSecondaryList.Count; ii++)
            {
                ACSecondaryList[ii].transform.parent = null;
            }
            ACSecondaryList.Clear();
        }

        public void TapCharacterDetail(Text txtCharacter)
        {
            SelectCharacterDetail(txtCharacter.text);
        }

        private void SelectCharacterDetail(string charaName)
        {
            for (int ii = 0; ii < ONE.UnitList.Count; ii++)
            {
                if (charaName == ONE.UnitList[ii].FullName)
                {
                    this.CurrentUnit = ONE.UnitList[ii];

                    Text[] txtList = groupCharacterDetail.GetComponentsInChildren<Text>();
                    for (int jj = 0; jj < txtList.Length; jj++)
                    {
                        if (txtList[jj].name == "txtCharacterName")
                        {
                            txtList[jj].text = ONE.UnitList[ii].FullName;
                        }
                        else if (txtList[jj].name == "txtLevel")
                        {
                            txtList[jj].text = ONE.UnitList[ii].Level.ToString();
                        }
                        else if (txtList[jj].name == "txtLife")
                        {
                            txtList[jj].text = ONE.UnitList[ii].MaxLife.ToString();
                        }
                        else if (txtList[jj].name == "txtStrength")
                        {
                            txtList[jj].text = ONE.UnitList[ii].TotalStrength.ToString();
                        }
                        else if (txtList[jj].name == "txtAgility")
                        {
                            txtList[jj].text = ONE.UnitList[ii].TotalAgility.ToString();
                        }
                        else if (txtList[jj].name == "txtIntelligence")
                        {
                            txtList[jj].text = ONE.UnitList[ii].TotalIntelligence.ToString();
                        }
                        else if (txtList[jj].name == "txtStamina")
                        {
                            txtList[jj].text = ONE.UnitList[ii].TotalStamina.ToString();
                        }
                        else if (txtList[jj].name == "txtMind")
                        {
                            txtList[jj].text = ONE.UnitList[ii].TotalMind.ToString();
                        }
                        else if (txtList[jj].name == "txtMainWeapon")
                        {
                            if (ONE.UnitList[ii].MainWeapon != null)
                            {
                                txtList[jj].text = ONE.UnitList[ii].MainWeapon.ItemName;
                            }
                            else
                            {
                                txtList[jj].text = string.Empty;
                            }
                        }
                        else if (txtList[jj].name == "txtSubWeapon")
                        {
                            if (ONE.UnitList[ii].SubWeapon != null)
                            {
                                txtList[jj].text = ONE.UnitList[ii].SubWeapon.ItemName;
                            }
                            else
                            {
                                txtList[jj].text = string.Empty;
                            }
                        }
                        else if (txtList[jj].name == "txtArmor")
                        {
                            if (ONE.UnitList[ii].MainArmor != null)
                            {
                                txtList[jj].text = ONE.UnitList[ii].MainArmor.ItemName;
                            }
                            else
                            {
                                txtList[jj].text = string.Empty;
                            }
                        }
                        else if (txtList[jj].name == "txtArmor")
                        {
                            if (ONE.UnitList[ii].MainArmor != null)
                            {
                                txtList[jj].text = ONE.UnitList[ii].MainArmor.ItemName;
                            }
                            else
                            {
                                txtList[jj].text = string.Empty;
                            }
                        }
                        else if (txtList[jj].name == "txtAccessory1")
                        {
                            if (ONE.UnitList[ii].Accessory != null)
                            {
                                txtList[jj].text = ONE.UnitList[ii].Accessory.ItemName;
                            }
                            else
                            {
                                txtList[jj].text = string.Empty;
                            }
                        }
                        else if (txtList[jj].name == "txtAccessory2")
                        {
                            if (ONE.UnitList[ii].Accessory2 != null)
                            {
                                txtList[jj].text = ONE.UnitList[ii].Accessory2.ItemName;
                            }
                            else
                            {
                                txtList[jj].text = string.Empty;
                            }
                        }
                    }

                    Image[] imgList = groupCharacterDetail.GetComponentsInChildren<Image>();
                    for (int jj = 0; jj < imgList.Length; jj++)
                    {
                        if ((ONE.UnitList[ii].MainWeapon != null) &&
                            (imgList[jj].name == "imgMainWeapon"))
                        {
                            Method.UpdateItemImage(ONE.UnitList[ii].MainWeapon, imgList[jj]);
                            Method.UpdateRareColor(ONE.UnitList[ii].MainWeapon, Method.SearchTextGameObject(groupCharacterDetail, "txtMainWeapon"), Method.SearchBackGameObject(groupCharacterDetail, "backMainWeapon").gameObject, null);
                        }
                        else if ((ONE.UnitList[ii].SubWeapon != null) &&
                            (imgList[jj].name == "imgSubWeapon"))
                        {
                            Method.UpdateItemImage(ONE.UnitList[ii].SubWeapon, imgList[jj]);
                            Method.UpdateRareColor(ONE.UnitList[ii].SubWeapon, Method.SearchTextGameObject(groupCharacterDetail, "txtSubWeapon"), Method.SearchBackGameObject(groupCharacterDetail, "backSubWeapon").gameObject, null);
                        }
                        else if ((ONE.UnitList[ii].MainArmor != null) &&
                            (imgList[jj].name == "imgArmor"))
                        {
                            Method.UpdateItemImage(ONE.UnitList[ii].MainArmor, imgList[jj]);
                            Method.UpdateRareColor(ONE.UnitList[ii].MainArmor, Method.SearchTextGameObject(groupCharacterDetail, "txtArmor"), Method.SearchBackGameObject(groupCharacterDetail, "backArmor").gameObject, null);
                        }
                        else if ((ONE.UnitList[ii].Accessory != null) &&
                            (imgList[jj].name == "imgAccessory1"))
                        {
                            Method.UpdateItemImage(ONE.UnitList[ii].Accessory, imgList[jj]);
                            Method.UpdateRareColor(ONE.UnitList[ii].Accessory, Method.SearchTextGameObject(groupCharacterDetail, "txtAccessory1"), Method.SearchBackGameObject(groupCharacterDetail, "backAccessory1").gameObject, null);
                        }
                        else if ((ONE.UnitList[ii].Accessory2 != null) &&
                            (imgList[jj].name == "imgAccessory2"))
                        {
                            Method.UpdateItemImage(ONE.UnitList[ii].Accessory2, imgList[jj]);
                            Method.UpdateRareColor(ONE.UnitList[ii].Accessory2, Method.SearchTextGameObject(groupCharacterDetail, "txtAccessory2"), Method.SearchBackGameObject(groupCharacterDetail, "backAccessory2").gameObject, null);
                        }
                    }

                    groupCharacterDetail.SetActive(true);
                    break;
                }
            }
        }

        public void TapCharacterDetailCancel()
        {
            this.CurrentUnit = null;
            groupCharacterDetail.SetActive(false);
        }

        public void TapChangeEquip(int number)
        {
            for (int ii = 0; ii < EquipChangeList.Count; ii++)
            {
                EquipChangeList[ii].transform.parent = null;
            }
            EquipChangeList.Clear();

            Item targetItem = null;
            string targetType = string.Empty;
            switch (number)
            {
                case 0:
                    targetType = "Main-Weapon";
                    currentEquipType = FIX.EquipItemType.MainWeapon;
                    if (this.CurrentUnit.MainWeapon != null)
                    {
                        targetItem = this.CurrentUnit.MainWeapon;
                    }
                    break;
                case 1:
                    targetType = "Sub-Weapon";
                    currentEquipType = FIX.EquipItemType.SubWeapon;
                    if (this.CurrentUnit.SubWeapon != null)
                    {
                        targetItem = this.CurrentUnit.SubWeapon;
                    }
                    break;
                case 2:
                    targetType = "Armor";
                    currentEquipType = FIX.EquipItemType.Armor;
                    if (this.CurrentUnit.MainArmor != null)
                    {
                        targetItem = this.CurrentUnit.MainArmor;
                    }
                    break;
                case 3:
                    targetType = "Accessory-1";
                    currentEquipType = FIX.EquipItemType.Accessory1;
                    if (this.CurrentUnit.Accessory != null)
                    {
                        targetItem = this.CurrentUnit.Accessory;
                    }
                    break;
                case 4:
                    targetType = "Accessory-2";
                    currentEquipType = FIX.EquipItemType.Accessory2;
                    if (this.CurrentUnit.Accessory2 != null)
                    {
                        targetItem = this.CurrentUnit.Accessory2;
                    }
                    break;
                default:
                    break;
            }

            Text[] txtList = groupEquipChange.GetComponentsInChildren<Text>();
            for (int jj = 0; jj < txtList.Length; jj++)
            {
                if (txtList[jj].name == "txtCurrentItem")
                {
                    txtList[jj].text = targetItem.ItemName;
                }
                else if (txtList[jj].name == "txtCurrentEquipPosition")
                {
                    txtList[jj].text = targetType;
                }
            }

            Image[] imgList = groupEquipChange.GetComponentsInChildren<Image>();
            for (int jj = 0; jj < imgList.Length; jj++)
            {
                if ((targetItem != null) &&
                    (imgList[jj].name == "imgCurrentItem"))
                {
                    Method.UpdateItemImage(targetItem, imgList[jj]);
                    Method.UpdateRareColor(targetItem, Method.SearchTextGameObject(groupEquipChange, "txtCurrentItem"), Method.SearchBackGameObject(groupEquipChange, "backCurrentItem").gameObject, null);
                }
            }

            int detect = 0;
            GameObject content = contentEquipChange;
            GameObject node = nodeEquipChange;
            RectTransform contentRect = content.GetComponent<RectTransform>();
            contentRect.sizeDelta = new Vector2(1, contentRect.sizeDelta.y);
            float contentHeight = 60.0f;
            for (int ii = 0; ii < ONE.BP.BackpackList.Count; ii++)
            {
                if (number == 0 && ((ONE.BP.BackpackList[ii].Type == Item.ItemType.Weapon_Axe) ||
                                   (ONE.BP.BackpackList[ii].Type == Item.ItemType.Weapon_Book) ||
                                   (ONE.BP.BackpackList[ii].Type == Item.ItemType.Weapon_Bow) ||
                                   (ONE.BP.BackpackList[ii].Type == Item.ItemType.Weapon_Heavy) ||
                                   (ONE.BP.BackpackList[ii].Type == Item.ItemType.Weapon_Lance) ||
                                   (ONE.BP.BackpackList[ii].Type == Item.ItemType.Weapon_Light) ||
                                   (ONE.BP.BackpackList[ii].Type == Item.ItemType.Weapon_Middle) ||
                                   (ONE.BP.BackpackList[ii].Type == Item.ItemType.Weapon_Orb) ||
                                   (ONE.BP.BackpackList[ii].Type == Item.ItemType.Weapon_Rod) ||
                                   (ONE.BP.BackpackList[ii].Type == Item.ItemType.Weapon_Staff) ||
                                   (ONE.BP.BackpackList[ii].Type == Item.ItemType.Weapon_TwoHand)) == false)
                {
                    continue;
                }
                if (number == 1 && ((ONE.BP.BackpackList[ii].Type == Item.ItemType.Shield) ||
                                    (ONE.BP.BackpackList[ii].Type == Item.ItemType.Weapon_Shield)) == false)
                {
                    continue;
                }
                if (number == 2 && ((ONE.BP.BackpackList[ii].Type == Item.ItemType.Armor_Heavy) ||
                                    (ONE.BP.BackpackList[ii].Type == Item.ItemType.Armor_Middle) ||
                                    (ONE.BP.BackpackList[ii].Type == Item.ItemType.Armor_Light)) == false)
                {
                    continue;
                }
                if ((number == 3 || number == 4) && ((ONE.BP.BackpackList[ii].Type == Item.ItemType.Accessory)) == false)
                {
                    continue;
                }

                GameObject obj = GameObject.Instantiate(node);
                obj.transform.SetParent(content.transform, false);
                obj.transform.localPosition = new Vector3(obj.transform.localPosition.x, obj.transform.localPosition.y - contentHeight * detect, obj.transform.localPosition.z);
                obj.SetActive(true);
                obj.name = "" + (ii + 1).ToString("D3");
                // 個数に応じて、コンテンツ長さを延長する。
                contentRect.sizeDelta = new Vector2(contentRect.sizeDelta.x, contentRect.sizeDelta.y + contentHeight);

                {
                    Text[] txtList2 = obj.GetComponentsInChildren<Text>();
                    for (int jj = 0; jj < txtList2.Length; jj++)
                    {
                        if (txtList2[jj].name == "txtEquipItem")
                        {
                            txtList2[jj].text = ONE.BP.BackpackList[ii].ItemName;
                        }
                    }

                    Image[] imgList2 = obj.GetComponentsInChildren<Image>();
                    for (int jj = 0; jj < imgList2.Length; jj++)
                    {
                        if (imgList2[jj].name == "imgEquipItem")
                        {
                            Method.UpdateItemImage(ONE.BP.BackpackList[ii], imgList2[jj]);
                            Method.UpdateRareColor(ONE.BP.BackpackList[ii], Method.SearchTextGameObject(obj, "txtEquipItem"), Method.SearchBackGameObject(obj, "backEquipItem").gameObject, null);
                        }
                    }
                }
                EquipChangeList.Add(obj);
                detect++;
            }
            // 最後に余白を追加しておく。
            contentRect.sizeDelta = new Vector2(contentRect.sizeDelta.x, contentRect.sizeDelta.y + FIX.LAYOUT_MARGIN);

            groupEquipChange.SetActive(true);
        }

        public void TapChangeEquipCancel()
        {
            groupEquipChange.SetActive(false);
        }
        public void TapSwapItem(Text swapItem)
        {
            Item swap = new Item(swapItem.text);
            switch (currentEquipType)
            {
                case FIX.EquipItemType.MainWeapon:
                    ONE.BP.AddBackPack(CurrentUnit.MainWeapon, 1);
                    CurrentUnit.MainWeapon = swap;
                    break;
                case FIX.EquipItemType.SubWeapon:
                    ONE.BP.AddBackPack(CurrentUnit.SubWeapon, 1);
                    CurrentUnit.SubWeapon = swap;
                    break;
                case FIX.EquipItemType.Armor:
                    ONE.BP.AddBackPack(CurrentUnit.MainArmor, 1);
                    CurrentUnit.MainArmor = swap;
                    break;
                case FIX.EquipItemType.Accessory1:
                    ONE.BP.AddBackPack(CurrentUnit.Accessory, 1);
                    CurrentUnit.Accessory = swap;
                    break;
                case FIX.EquipItemType.Accessory2:
                    ONE.BP.AddBackPack(CurrentUnit.Accessory2, 1);
                    CurrentUnit.Accessory2 = swap;
                    break;
                default:
                    ONE.BP.AddBackPack(CurrentUnit.MainWeapon, 1);
                    CurrentUnit.MainWeapon = swap;
                    break;
            }
            ONE.BP.DeleteBackPack(swap, 1);
            SelectCharacterDetail(CurrentUnit.FullName);
            RefreshCharacterStatus();
            groupEquipChange.SetActive(false);
        }

        private void RefreshCharacterStatus()
        {
            SelectCharacterDetail(this.CurrentUnit.FullName);
            foreach (Transform obj in contentCharacter.transform)
            {
                GameObject.Destroy(obj.gameObject);
            }
            CharacterList.Clear();
            RectTransform rect = nodeCharacter.GetComponent<RectTransform>();
            AbstractContentPanel(contentCharacter, nodeCharacter, 0, -rect.sizeDelta.y, 0, FIX.LAYOUT_MARGIN);
        }

        public void TapItemDetail(Text item)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + " " + item.text);

            Item current = new Item(item.text);
            Text obj = null;
            Text[] txtList = groupBackpackDetail.GetComponentsInChildren<Text>();
            for (int ii = 0; ii < txtList.Length; ii++)
            {
                if (txtList[ii].name == "txtItem")
                {
                    txtList[ii].text = current.ItemName;
                    obj = txtList[ii];
                }
                if (txtList[ii].name == "txtDescription")
                {
                    txtList[ii].text = current.Description;
                }
            }
            Image[] imglist = groupBackpackDetail.GetComponentsInChildren<Image>();
            for (int ii = 0; ii < imglist.Length; ii++)
            {
                if (imglist[ii].name == "imgItem")
                {
                    Method.UpdateItemImage(current, imglist[ii]);
                    Method.UpdateRareColor(current, Method.SearchTextGameObject(groupBackpackDetail, "txtItem"), Method.SearchBackGameObject(groupBackpackDetail, "backItem").gameObject, null);
                }
            }
            groupBackpackDetail.SetActive(true);
        }
        public void TapBackpackDetailCancel()
        {
            groupBackpackDetail.SetActive(false);
        }

        public void ExecQuest()
        {
            m_list.Clear();
            e_list.Clear();

            if (ONE.WE2 == null) { Debug.Log("WE2 is null... error."); }

            if (ONE.WE2.Event_Message100010 == false)
            {
                MessagePack.Message100010(ref m_list, ref e_list);
                TapOK();
            }
            else if (ONE.WE2.Event_Message100020 == false)
            {
                MessagePack.Message100020(ref m_list, ref e_list);
                TapOK();
            }
            else if (ONE.WE2.Event_Message100030 == false)
            {
                MessagePack.Message100030(ref m_list, ref e_list);
                TapOK();
            }
            else if (ONE.WE2.Event_Message100040 == false)
            {
                MessagePack.Message100040(ref m_list, ref e_list);
                TapOK();
            }
            else if (ONE.WE2.Event_Message200010 == false)
            {
                MessagePack.Message200010(ref m_list, ref e_list);
                TapOK();
            }
            else if (ONE.WE2.Event_Message200020 == false)
            {
                MessagePack.Message200020(ref m_list, ref e_list);
                TapOK();
            }
            else if (ONE.WE2.Event_Message200030 == false)
            {
                if (MessagePack.GetZetaniumCount() < 5)
                {
                    MessagePack.Message200030(ref m_list, ref e_list);
                    TapOK();
                }
                else
                {
                    txtMessage.text = "今は、何も無いみたいだな。";
                }
            }
            else if (ONE.WE2.Event_Message300010 == false)
            {
                MessagePack.Message300010(ref m_list, ref e_list);
                TapOK();
            }
            else if (ONE.WE2.Event_Message300020 == false)
            {
                MessagePack.Message300020(ref m_list, ref e_list);
                TapOK();
            }
            else if (ONE.WE2.Event_Message300021 == false)
            {
                MessagePack.Message300021(ref m_list, ref e_list);
                TapOK();
            }
            else if (ONE.WE2.Event_Message300022 == false)
            {
                MessagePack.Message300022(ref m_list, ref e_list);
                TapOK();
            }
            else if (ONE.WE2.Event_Message300023 == false)
            {
                MessagePack.Message300023(ref m_list, ref e_list);
                TapOK();
            }
            else if (ONE.WE2.Event_Message300024 == false)
            {
                MessagePack.Message300024(ref m_list, ref e_list);
                TapOK();
            }
            else if (ONE.WE2.Event_Message400010 == false)
            {
                MessagePack.Message400010(ref m_list, ref e_list);
                TapOK();
            }
            else if (ONE.WE2.Event_Message400020 == false)
            {
                MessagePack.Message400020(ref m_list, ref e_list);
                TapOK();
            }
            else
            {
                txtMessage.text = "今は、何も無いみたいだな。";
            }
        }
    }
}

