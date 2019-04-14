using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ObsidianPortal
{
    public class UnitStatus : MotherForm
    {
        public GameObject groupParentStatus;
        public GameObject groupParentBackpack;
        public GameObject groupParentCommand;
        public GameObject groupParentResist;

        public Text txtUnitName;
        public Text txtLevel;
        public Text txtExp;
        public Text txtLife;
        public Text txtStrength;
        public Text txtAgility;
        public Text txtIntelligence;
        public Text txtStamina;
        public Text txtMind;
        public Text txtMainWeapon;
        public Image imgMainWeapon;
        public GameObject back_MainWeapon;
        public Text txtSubWeapon;
        public Image imgSubWeapon;
        public GameObject back_SubWeapon;
        public Text txtArmor;
        public Image imgArmor;
        public GameObject back_Armor;
        public Text txtAccessory1;
        public Image imgAccessory1;
        public GameObject back_Accessory1;
        public Text txtAccessory2;
        public Image imgAccessory2;
        public GameObject back_Accessory2;
        public Text txtAccessory3;
        public Image imgAccessory3;
        public GameObject back_Accessory3;

        // Backpack
        public GameObject groupChangeEquip;
        public GameObject groupBackpackNormal;
        public GameObject groupBackpackValuables;
        public GameObject ItemNormalContent;
        public GameObject ItemValuablesContent;
        public GameObject ItemNode;
        public GameObject ItemDetailGroup;
        public Image ItemDetailImage;
        public Text ItemDetailTitle;
        public Text ItemDetailDesc;
        public Text ItemDetailSpecial;
        public Text ItemDetailStr;
        public Text ItemDetailAgl;
        public Text ItemDetailInt;
        public Text ItemDetailStm;
        public Text ItemDetailMnd;

        // Command
        public List<GameObject> CommandList;
        public GameObject groupCommandContent;
        public GameObject CommandNode;

        bool firstAction = false;
        int ExchangeEquipNumber = 0;

        // Use this for initialization
        new void Start()
        {
            base.Start();

            if (ONE.UnitList.Count > 0)
            {
                SetupUnitStatus();
            }
        }

        // Update is called once per frame
        new void Update()
        {
            base.Update();

            if (firstAction == false)
            {
                firstAction = true;

                int detect = 0;
                for (int ii = 0; ii < ONE.UnitList[0].AvailableCommandLv.Count; ii++)
                {
                    GameObject obj = GameObject.Instantiate(CommandNode);
                    RectTransform rect = obj.GetComponent<RectTransform>();
                    rect.anchorMin = new Vector2(0.5f, 0.0f);
                    rect.anchorMax = new Vector2(0.5f, 0.0f);
                    rect.pivot = new Vector2(0.5f, 0.0f);
                    obj.transform.SetParent(groupCommandContent.transform, false);
                    obj.transform.localPosition = new Vector3(obj.transform.localPosition.x, obj.transform.localPosition.y + FIX.COMMAND_HEIGHT * detect, obj.transform.localPosition.z);
                    obj.SetActive(true);

                    Text[] txtList = obj.GetComponentsInChildren<Text>();
                    for (int jj = 0; jj < txtList.Length; jj++)
                    {
                        if (txtList[jj].name == "txtLevel")
                        {
                            txtList[jj].text = "Level " + ONE.UnitList[0].AvailableCommandLv[ii].ToString();
                        }
                        else if (txtList[jj].name == "txtCommand")
                        {
                            txtList[jj].text = ONE.UnitList[0].AvailableCommandName[ii];
                        }
                        else if (txtList[jj].name == "txtValue")
                        {
                            txtList[jj].text = ONE.UnitList[0].AvailableCommandValue[ii];
                        }
                    }
                    Image[] imgList = obj.GetComponentsInChildren<Image>();
                    for (int jj = 0; jj < imgList.Length; jj++)
                    {
                        if (imgList[jj].name == "imgCommand")
                        {
                            imgList[jj].sprite = Resources.Load<Sprite>(ONE.UnitList[0].AvailableCommandName[ii]);
                        }
                    }
                    CommandList.Add(obj);
                    detect++;
                }
            }
        }

        #region "TapEvent"
        public void TapItem(int num)
        {
            groupChangeEquip.SetActive(true);

            List<Item.ItemType> list = new List<Item.ItemType>();
            switch (num)
            {
                case 1:
                    list.Add(Item.ItemType.Weapon_Heavy);
                    list.Add(Item.ItemType.Weapon_Middle);
                    list.Add(Item.ItemType.Weapon_Light);
                    list.Add(Item.ItemType.Weapon_Bow);
                    list.Add(Item.ItemType.Weapon_Rod);
                    list.Add(Item.ItemType.Weapon_TwoHand);
                    break;
                case 2:
                    list.Add(Item.ItemType.Weapon_Heavy);
                    list.Add(Item.ItemType.Weapon_Middle);
                    list.Add(Item.ItemType.Weapon_Light);
                    list.Add(Item.ItemType.Shield);
                    break;
                case 3:
                    list.Add(Item.ItemType.Armor_Heavy);
                    list.Add(Item.ItemType.Armor_Middle);
                    list.Add(Item.ItemType.Armor_Light);
                    break;
                case 4:
                    list.Add(Item.ItemType.Accessory);
                    break;
                case 5:
                    list.Add(Item.ItemType.Accessory);
                    break;
                case 6:
                    list.Add(Item.ItemType.Accessory);
                    break;
                default:
                    break;
            }
            this.ExchangeEquipNumber = num;
            AbstractSetupItemList(ItemNormalContent, ONE.UnitList[0].GetBackPackInfo(), list);
        }
        public void ExchangeEquipItem(Text txt)
        {
            Item current = null;

            switch (this.ExchangeEquipNumber)
            {
                case 1:
                    current = ONE.UnitList[0].MainWeapon;
                    ONE.UnitList[0].MainWeapon = new Item(txt.text);
                    break;
                case 2:
                    current = ONE.UnitList[0].SubWeapon;
                    ONE.UnitList[0].SubWeapon = new Item(txt.text);
                    break;
                case 3:
                    current = ONE.UnitList[0].MainArmor;
                    ONE.UnitList[0].MainArmor = new Item(txt.text);
                    break;
                case 4:
                    current = ONE.UnitList[0].Accessory;
                    ONE.UnitList[0].Accessory = new Item(txt.text);
                    break;
                case 5:
                    current = ONE.UnitList[0].Accessory2;
                    ONE.UnitList[0].Accessory2 = new Item(txt.text);
                    break;
                case 6:
                    current = ONE.UnitList[0].Accessory3;
                    ONE.UnitList[0].Accessory3 = new Item(txt.text);
                    break;
                default:
                    break;
            }
            // アイテム交換の対象元が存在しない場合、何もせず終了する。
            if (current == null)
            {
                this.ExchangeEquipNumber = 0;
                groupChangeEquip.SetActive(false);
                return;
            }

            ONE.UnitList[0].DeleteBackPack(new Item(txt.text), 1);
            ONE.UnitList[0].AddBackPack(current, 1);
            SetupUnitStatus();

            this.ExchangeEquipNumber = 0;
            groupChangeEquip.SetActive(false);
        }
        public void TapSubMenu(int num)
        {
            switch (num)
            {
                case 1:
                    UpdateGroupView(true, false, false, false);
                    break;
                case 2:
                    UpdateGroupView(false, true, false, false);
                    break;
                case 3:
                    UpdateGroupView(false, false, true, false);
                    break;
                case 4:
                    UpdateGroupView(false, false, false, true);
                    break;
                default:
                    UpdateGroupView(true, false, false, false);
                    break;
            }
        }
        private void UpdateGroupView(bool b1, bool b2, bool b3, bool b4)
        {
            groupParentStatus.SetActive(b1);
            groupParentBackpack.SetActive(b2);
            groupParentCommand.SetActive(b3);
            groupParentResist.SetActive(b4);
        }
        #endregion

        private void SetupUnitStatus()
        {
            txtUnitName.text = ONE.UnitList[0].FullName;
            txtLevel.text = "LV  " + ONE.UnitList[0].Level.ToString();
            txtExp.text = "Exp  " + ONE.UnitList[0].Exp.ToString();
            txtLife.text = "Life  " + ONE.UnitList[0].CurrentLife.ToString() + " / " + ONE.UnitList[0].MaxLife.ToString();
            txtStrength.text = "" + ONE.UnitList[0].TotalStrength.ToString();
            txtAgility.text = "" + ONE.UnitList[0].TotalAgility.ToString();
            txtIntelligence.text = "" + ONE.UnitList[0].TotalIntelligence.ToString();
            txtStamina.text = "" + ONE.UnitList[0].TotalStamina.ToString();
            txtMind.text = "" + ONE.UnitList[0].TotalMind.ToString();

            SetupItem(ONE.UnitList[0].MainWeapon, imgMainWeapon, txtMainWeapon, back_MainWeapon);
            SetupItem(ONE.UnitList[0].SubWeapon, imgSubWeapon, txtSubWeapon, back_SubWeapon);
            SetupItem(ONE.UnitList[0].MainArmor, imgArmor, txtArmor, back_Armor);
            SetupItem(ONE.UnitList[0].Accessory, imgAccessory1, txtAccessory1, back_Accessory1);
            SetupItem(ONE.UnitList[0].Accessory2, imgAccessory2, txtAccessory2, back_Accessory2);
            SetupItem(ONE.UnitList[0].Accessory3, imgAccessory3, txtAccessory3, back_Accessory3);
        }

        private void SetupItem(Item item, Image img, Text txt, GameObject obj_back)
        {
            if (item != null)
            {
                txt.text = item.ItemName;
                Method.UpdateItemImage(item, img);
                Method.UpdateRareColor(item, txt, obj_back, null);
            }
            else
            {
                txt.text = "";
                img.sprite = null;
                obj_back.gameObject.GetComponent<Image>().color = Color.white;
            }
        }

        private List<GameObject> itemsList = new List<GameObject>();
        private void AbstractSetupItemList(GameObject groupContent, List<Item> list, List<Item.ItemType> availableList)
        {
            RectTransform rect = groupContent.GetComponent<RectTransform>();
            rect.sizeDelta = new Vector2(rect.sizeDelta.x, 1);
            Debug.Log("list length: " + list.Count.ToString());

            // 前回表示していたアイテムリストをクリアする。
            for (int ii = 0; ii < itemsList.Count; ii++)
            {
                itemsList[ii].transform.parent = null;
            }

            int detect = 0;
            for (int ii = 0; ii < list.Count; ii++)
            {
                if (list[ii] == null) { continue; }
                if (list[ii].ItemName == "" || list[ii].ItemName == String.Empty) { continue; }
                bool hasFlag = false;
                for (int jj = 0; jj < availableList.Count; jj++)
                {
                    if (availableList[jj] == list[ii].Type)
                    {
                        hasFlag = true;
                        break;
                    }
                }
                if (hasFlag == false) { continue; }
                detect++;

                Debug.Log("list " + ii.ToString() + " " + list[ii].ItemName);

                // 個数に応じて、コンテンツ長さを延長する。
                rect.sizeDelta = new Vector2(rect.sizeDelta.x, rect.sizeDelta.y + FIX.BACKPACK_HEIGHT);

                GameObject item = GameObject.Instantiate(ItemNode);
                item.transform.SetParent(groupContent.transform, false);
                item.transform.localPosition = new Vector3(item.transform.localPosition.x, item.transform.localPosition.y - FIX.BACKPACK_HEIGHT * detect, item.transform.localPosition.z);
                item.SetActive(true);
                itemsList.Add(item);

                Text[] txtField = item.GetComponentsInChildren<Text>();
                Text txtColorField = null;
                Text txtColorFieldNum = null;
                for (int kk = 0; kk < txtField.Length; kk++)
                {
                    if (txtField[kk].name == "txtItem") { txtField[kk].text = list[ii].ItemName; txtColorField = txtField[kk]; }
                    if (txtField[kk].name == "txtItemNumber") { txtField[kk].text = "x " + list[ii].StackValue.ToString(); txtColorFieldNum = txtField[kk]; }
                }

                Image[] imgField = item.GetComponentsInChildren<Image>();
                Image img_item = null;
                Image[] objField = item.GetComponentsInChildren<Image>();
                Image obj_back = null;
                for (int jj = 0; jj < imgField.Length; jj++)
                {
                    if (objField[jj].name == "back_item")
                    {
                        obj_back = objField[jj];
                        break;
                    }
                }

                for (int jj = 0; jj < imgField.Length; jj++)
                {
                    if (imgField[jj].name == "imgItem")
                    {
                        img_item = imgField[jj];
                        Method.UpdateItemImage(list[ii], imgField[jj]);
                        Method.UpdateRareColor(list[ii], txtColorField, obj_back.gameObject, txtColorFieldNum);
                    }
                }
            }
            // 最後に余白を追加しておく。
            rect.sizeDelta = new Vector2(rect.sizeDelta.x, rect.sizeDelta.y + FIX.BACKPACK_MARGIN);
        }

    }
}