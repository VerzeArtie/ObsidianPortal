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
        public GameObject groupCharacterDetail;
        public GameObject groupEquipChange;
        private Unit CurrentUnit;
        private FIX.EquipItemType currentEquipType;
        public GameObject nodeEquipChange;
        public GameObject contentEquipChange;
        private List<GameObject> EquipChangeList = new List<GameObject>();

        private bool firstAction = false;

        private const string CONST_STR_GOLD = "gold";

        // Use this for initialization
        public override void Start()
        {
            base.Start();
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
                    List<string> textTopList = new List<string>();
                    textTopList.Add("エスミリア草原区域１");
                    textTopList.Add("エスミリア草原区域２");
                    textTopList.Add("エスミリア草原区域３");
                    textTopList.Add("エスミリア草原区域４");
                    textTopList.Add("エスミリア草原区域５");
                    textTopList.Add("エスミリア草原区域６");
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
                    textTopList.Add(FIX.DUEL_EONE_FULNEA);
                    textTopList.Add(FIX.DUEL_MAGI_ZELKIS);
                    textTopList.Add(FIX.DUEL_SELMOI_RO);
                    textTopList.Add(FIX.DUEL_KARTIN_MAI);
                    textTopList.Add(FIX.DUEL_JEDA_ARUS);
                    textTopList.Add(FIX.DUEL_SINIKIA_VEILHANZ);
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

                #region "トップメニューの内容設定"
                // キャラクターのリスト設定
                ConstructCharacterPanel(contentCharacter, nodeCharacter);
                #endregion
            }
        }

        #region "GUI Event"
        public void TapActionMenuButton(int number)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S)");
            switch (number)
            {
                case 0:
                    CallCharacter();
                    break;
                case 1:
                    CallDungeon();
                    break;
                case 2:
                    CallShop();
                    break;
                case 3:
                    CallInn();
                    break;
                case 4:
                    CallDuel();
                    break;
                case 5:
                    CallTransferGate();
                    break;
                default:
                    Debug.Log("default button has tapped, then no action.");
                    break;
            }
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(E)");
        }

        public void TapDungeonChallenge(string number)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S)");
            ONE.CurrentArea = FIX.PortalArea.Area_Esmilia;
            ONE.CurrentStage = FIX.Stage.Stage1_1;
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
            ONE.UnitList[0].AddBackPack(CurrentSelectItem, 1);
            CurrentSelectItem = null;
            filterConfrim.SetActive(false);
        }
        public void TapCancel()
        {
            CurrentSelectItem = null;
            filterConfrim.SetActive(false);
        }
        #endregion

        private void CallCharacter()
        {
            UpdateGroupView(true, false, false, false, false, false);
        }
        private void CallDungeon()
        {
            UpdateGroupView(false, true, false, false, false, false);
        }
        private void CallShop()
        {
            UpdateGroupView(false, false, true, false, false, false);
        }
        private void CallInn()
        {
            UpdateGroupView(false, false, false, true, false, false);
        }
        private void CallDuel()
        {
            UpdateGroupView(false, false, false, false, true, false);
        }
        private void CallTransferGate()
        {
            UpdateGroupView(false, false, false, false, false, true);
        }
        private void UpdateGroupView(bool g1, bool g2, bool g3, bool g4, bool g5, bool g6)
        {
            groupCharacter.SetActive(g1);
            groupDungeonPlayer.SetActive(g2);
            groupShop.SetActive(g3);
            groupInn.SetActive(g4);
            groupDuelColosseum.SetActive(g5);
            groupTransferGate.SetActive(g6);
        }

        private void UpdateHomeTownView()
        {
            txtDate.text = ONE.Day.ToString() + "日目";
            txtGold.text = ONE.Gold.ToString();
            txtArea.text = ONE.HomeTownArea;
            txtSoulFragment.text = ONE.SoulFragment.ToString();
            txtObsidianStone.text = ONE.ObsidianStone.ToString();
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

        /// <summary>
        /// キャラクターリストを並べる。
        /// </summary>
        private void ConstructCharacterPanel(GameObject content, GameObject node)
        {
            RectTransform rect = node.GetComponent<RectTransform>();
            AbstractContentPanel(content, node, 0, -rect.sizeDelta.y, 0, FIX.LAYOUT_MARGIN);
        }

        private void AbstractContentPanel(GameObject content, GameObject node, float contentWidth, float contentHeight, int marginX, int marginY)
        {
            int detect = 0;
            RectTransform contentRect = content.GetComponent<RectTransform>();
            contentRect.sizeDelta = new Vector2(1, contentRect.sizeDelta.y);
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

                    groupCharacterDetail.SetActive(true); break;
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
            List<Item> list = CurrentUnit.GetBackPackInfo();
            for (int ii = 0; ii < list.Count; ii++)
            {
                if (number == 0 && ((list[ii].Type == Item.ItemType.Weapon_Axe) ||
                                   (list[ii].Type == Item.ItemType.Weapon_Book) ||
                                   (list[ii].Type == Item.ItemType.Weapon_Bow) ||
                                   (list[ii].Type == Item.ItemType.Weapon_Heavy) ||
                                   (list[ii].Type == Item.ItemType.Weapon_Lance) ||
                                   (list[ii].Type == Item.ItemType.Weapon_Light) ||
                                   (list[ii].Type == Item.ItemType.Weapon_Middle) ||
                                   (list[ii].Type == Item.ItemType.Weapon_Orb) ||
                                   (list[ii].Type == Item.ItemType.Weapon_Rod) ||
                                   (list[ii].Type == Item.ItemType.Weapon_Staff) ||
                                   (list[ii].Type == Item.ItemType.Weapon_TwoHand)) == false)
                {
                    continue;
                }
                if (number == 1 && ((list[ii].Type == Item.ItemType.Shield) ||
                                    (list[ii].Type == Item.ItemType.Weapon_Shield)) == false)
                {
                    continue;
                }
                if (number == 2 && ((list[ii].Type == Item.ItemType.Armor_Heavy) ||
                                    (list[ii].Type == Item.ItemType.Armor_Middle) ||
                                    (list[ii].Type == Item.ItemType.Armor_Light)) == false)
                {
                    continue;
                }
                if ((number == 3 || number == 4) && ((list[ii].Type == Item.ItemType.Accessory)) == false)
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
                            txtList2[jj].text = list[ii].ItemName;
                        }
                    }

                    Image[] imgList2 = obj.GetComponentsInChildren<Image>();
                    for (int jj = 0; jj < imgList2.Length; jj++)
                    {
                        if (imgList2[jj].name == "imgEquipItem")
                        {
                            Method.UpdateItemImage(list[ii], imgList2[jj]);
                            Method.UpdateRareColor(list[ii], Method.SearchTextGameObject(obj, "txtEquipItem"), Method.SearchBackGameObject(obj, "backEquipItem").gameObject, null);
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
                    CurrentUnit.AddBackPack(CurrentUnit.MainWeapon, 1);
                    CurrentUnit.MainWeapon = swap;
                    break;
                case FIX.EquipItemType.SubWeapon:
                    CurrentUnit.AddBackPack(CurrentUnit.SubWeapon, 1);
                    CurrentUnit.SubWeapon = swap;
                    break;
                case FIX.EquipItemType.Armor:
                    CurrentUnit.AddBackPack(CurrentUnit.MainArmor, 1);
                    CurrentUnit.MainArmor = swap;
                    break;
                case FIX.EquipItemType.Accessory1:
                    CurrentUnit.AddBackPack(CurrentUnit.Accessory, 1);
                    CurrentUnit.Accessory = swap;
                    break;
                case FIX.EquipItemType.Accessory2:
                    CurrentUnit.AddBackPack(CurrentUnit.Accessory2, 1);
                    CurrentUnit.Accessory2 = swap;
                    break;
                default:
                    CurrentUnit.AddBackPack(CurrentUnit.MainWeapon, 1);
                    CurrentUnit.MainWeapon = swap;
                    break;
            }
            CurrentUnit.DeleteBackPack(swap, 1);
            SelectCharacterDetail(CurrentUnit.FullName);
            groupEquipChange.SetActive(false);
        }
    }
}

