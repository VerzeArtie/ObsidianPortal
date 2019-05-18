using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;
using UnityEngine;
using UnityEngine.UI;

namespace ObsidianPortal
{
    public class Method
    {
        public enum NewItemCategory
        {
            Battle,
            Lottery_L1,
        }

        public static void MakeDirectory()
        {
            if (System.IO.File.Exists(Method.PathForRootFile(FIX.WE2_FILE)) == false)
            {
                Method.AutoSaveTruthWorldEnvironment();
            }
            if (Application.platform == RuntimePlatform.IPhonePlayer)
            {
                // なし
                string directory = Method.PathForSaveFile();
                if (System.IO.Directory.Exists(directory) == false)
                {
                    System.IO.Directory.CreateDirectory(directory);
                }
            }
            else if (Application.platform == RuntimePlatform.Android)
            {
                string directory = Method.PathForSaveFile();
                if (System.IO.Directory.Exists(directory) == false)
                {
                    System.IO.Directory.CreateDirectory(directory);
                }
            }
            else
            {
                if (System.IO.Directory.Exists(FIX.BaseSaveFolder) == false)
                {
                    System.IO.Directory.CreateDirectory(FIX.BaseSaveFolder);
                }
            }
        }

        // ONE.WE2をリロード
        public static string PathForSaveFile()
        {
            if (Application.platform == RuntimePlatform.IPhonePlayer)
            {
                //return Application.persistentDataPath.Substring(0, Application.persistentDataPath.LastIndexOf('/')); // after (ios)
                return Path.Combine(Application.persistentDataPath, "save");
            }
            else if (Application.platform == RuntimePlatform.Android)
            {
                return Path.Combine(Application.persistentDataPath, "save");
            }
            else
            {
                return FIX.BaseSaveFolder;
            }

        }

        public static string pathForDocumentsFile(string filename)
        {
            if (Application.platform == RuntimePlatform.IPhonePlayer)
            {
                //string path = Application.dataPath.Substring(0, Application.dataPath.Length - 5);
                //path = path.Substring(0, path.LastIndexOf('/'));
                //return Path.Combine(Path.Combine(path, "Documents"), filename);
                return Path.Combine(PathForSaveFile(), filename);
            }
            else if (Application.platform == RuntimePlatform.Android)
            {
                return Path.Combine(PathForSaveFile(), filename);
            }
            else
            {
                return FIX.BaseSaveFolder + filename;
            }
        }

        public static string PathForRootFile(string filename)
        {
            if (Application.platform == RuntimePlatform.IPhonePlayer)
            {
                //return filename;
                return Path.Combine(Application.persistentDataPath, filename);
            }
            else if (Application.platform == RuntimePlatform.Android)
            {
                return Path.Combine(Application.persistentDataPath, filename);
            }
            else
            {
                return filename;
            }
        }

        public static void ReloadTruthWorldEnvironment()
        {
            XmlDocument xml2 = new XmlDocument();
            xml2.Load(PathForRootFile(FIX.WE2_FILE));
            Type typeWE2 = ONE.WE2.GetType();
            foreach (PropertyInfo pi in typeWE2.GetProperties())
            {
                // [警告]：catch構文はSetプロパティがない場合だが、それ以外のケースも見えなくなってしまうので要分析方法検討。
                if (pi.PropertyType == typeof(System.Int32))
                {
                    try
                    {
                        pi.SetValue(ONE.WE2, Convert.ToInt32(xml2.GetElementsByTagName(pi.Name)[0].InnerText), null);
                    }
                    catch { }
                }
                else if (pi.PropertyType == typeof(System.String))
                {
                    try
                    {
                        pi.SetValue(ONE.WE2, (xml2.GetElementsByTagName(pi.Name)[0].InnerText), null);
                    }
                    catch { }
                }
                else if (pi.PropertyType == typeof(System.Boolean))
                {
                    try
                    {
                        pi.SetValue(ONE.WE2, Convert.ToBoolean(xml2.GetElementsByTagName(pi.Name)[0].InnerText), null);
                    }
                    catch { }
                }
            }
        }


        // 通常セーブ、現実世界の自動セーブ、タイトルSeekerモードの自動セーブを結合
        public static void AutoSaveTruthWorldEnvironment()
        {
            XmlTextWriter xmlWriter2 = new XmlTextWriter(Method.PathForRootFile(FIX.WE2_FILE), Encoding.UTF8);
            try
            {
                xmlWriter2.WriteStartDocument();
                xmlWriter2.WriteWhitespace("\r\n");

                xmlWriter2.WriteStartElement("Body");
                xmlWriter2.WriteElementString("DateTime", DateTime.Now.ToString());
                xmlWriter2.WriteWhitespace("\r\n");

                // ワールド環境
                xmlWriter2.WriteStartElement("TruthWorldEnvironment");
                xmlWriter2.WriteWhitespace("\r\n");
                if (ONE.WE2 != null)
                {
                    Type typeWE2 = ONE.WE2.GetType();
                    foreach (PropertyInfo pi in typeWE2.GetProperties())
                    {
                        if (pi.PropertyType == typeof(System.Int32))
                        {
                            xmlWriter2.WriteElementString(pi.Name, ((System.Int32)(pi.GetValue(ONE.WE2, null))).ToString());
                            xmlWriter2.WriteWhitespace("\r\n");
                        }
                        else if (pi.PropertyType == typeof(System.String))
                        {
                            xmlWriter2.WriteElementString(pi.Name, (string)(pi.GetValue(ONE.WE2, null)));
                            xmlWriter2.WriteWhitespace("\r\n");
                        }
                        else if (pi.PropertyType == typeof(System.Boolean))
                        {
                            xmlWriter2.WriteElementString(pi.Name, ((System.Boolean)pi.GetValue(ONE.WE2, null)).ToString());
                            xmlWriter2.WriteWhitespace("\r\n");
                        }
                    }
                }
                xmlWriter2.WriteEndElement();
                xmlWriter2.WriteWhitespace("\r\n");

                xmlWriter2.WriteEndElement();
                xmlWriter2.WriteWhitespace("\r\n");
                xmlWriter2.WriteEndDocument();
            }
            finally
            {
                xmlWriter2.Close();
            }
        }

        public static void UpdateJobClassImage(FIX.JobClass jobClass, Image src)
        {
            Sprite current = null;
            switch (jobClass)
            {
                case FIX.JobClass.Fighter:
                    current = Resources.Load<Sprite>("Unit_Fighter");
                    break;
                case FIX.JobClass.Ranger:
                    current = Resources.Load<Sprite>("Unit_Ranger");
                    break;
                case FIX.JobClass.Seeker:
                    current = Resources.Load<Sprite>("Unit_Seeker");
                    break;
                case FIX.JobClass.Priest:
                    current = Resources.Load<Sprite>("Unit_Priest");
                    break;
                case FIX.JobClass.Magician:
                    current = Resources.Load<Sprite>("Unit_Magician");
                    break;
                case FIX.JobClass.Enchanter:
                    current = Resources.Load<Sprite>("Unit_Enchanter");
                    break;
            }
            src.sprite = current;
        }

        public static void UpdateItemImage(Item item, Image src)
        {
            Texture2D current = Resources.Load<Texture2D>("ItemIcon");
            int BASE_SIZE = 49;
            int locX = 0;
            int locY = 0;
            if ((item.Type == Item.ItemType.Weapon_Heavy) ||
                (item.Type == Item.ItemType.Weapon_Middle) ||
                (item.Type == Item.ItemType.Weapon_Bow))
            {
                locX = 0; locY = 2;
            }
            else if (item.Type == Item.ItemType.Weapon_TwoHand)
            {
                locX = 1; locY = 2;
            }
            else if (item.Type == Item.ItemType.Weapon_Light)
            {
                locX = 2; locY = 2;
            }
            else if (item.Type == Item.ItemType.Weapon_Rod)
            {
                locX = 3; locY = 2;
            }
            else if ((item.Type == Item.ItemType.Shield) ||
                     (item.Type == Item.ItemType.Weapon_Shield))
            {
                locX = 0; locY = 1;
            }
            else if ((item.Type == Item.ItemType.Armor_Heavy) ||
                        (item.Type == Item.ItemType.Armor_Middle))
            {
                locX = 1; locY = 1;
            }
            else if ((item.Type == Item.ItemType.Armor_Light))
            {
                locX = 2; locY = 1;
            }
            //else if ((backpackData[currentNumber].Type == Item.ItemType.Robe))
            //{
            //    locX = 3; locY = 1;
            //}
            else if ((item.Type == Item.ItemType.Material_Equip) ||
                        (item.Type == Item.ItemType.Material_Food) ||
                        (item.Type == Item.ItemType.Material_Potion))
            {
                locX = 0; locY = 0;
            }
            else if (item.Type == Item.ItemType.Use_Potion)
            {
                locX = 1; locY = 0;
            }
            else if (item.Type == Item.ItemType.Useless)
            {
                locX = 2; locY = 0;
            }
            else if (item.Type == Item.ItemType.Accessory)
            {
                locX = 0; locY = 3;
            }
            else if (item.Type == Item.ItemType.Use_BlueOrb)
            {
                locX = 1; locY = 3;
            }
            else if (item.Type == Item.ItemType.Use_Item)
            {
                locX = 2; locY = 3;
            }
            else
            {
                locX = 2; locY = 0; // same Useless
            }
            Debug.Log("Item Type: " + item.Type.ToString() + " " + locX.ToString() + " " + locY.ToString());
            src.sprite = Sprite.Create(current, new Rect(BASE_SIZE * locX, BASE_SIZE * locY, BASE_SIZE, BASE_SIZE), new Vector2(0, 0));
        }

        public static Text SearchTextGameObject(GameObject obj, string txtName)
        {
            Text[] list = obj.GetComponentsInChildren<Text>();
            for (int ii = 0; ii < list.Length; ii++)
            {
                if (list[ii].name == txtName)
                {
                    return list[ii];
                }
            }
            return null;
        }

        public static Image SearchBackGameObject(GameObject obj, string objName)
        {
            Image[] list = obj.GetComponentsInChildren<Image>();
            for (int ii = 0; ii < list.Length; ii++)
            {
                if (list[ii].name == objName)
                {
                    return list[ii];
                }
            }
            return null;
        }

        public static void SetupActionCommand(GameObject obj, string commandName)
        {
            Image[] imgList = obj.GetComponentsInChildren<Image>();
            for (int ii = 0; ii < imgList.Length; ii++)
            {
                if (imgList[ii].name == "imgActionCommand")
                {
                    imgList[ii].sprite = Resources.Load<Sprite>(commandName);
                }
            }
        }

        // panel(gameobject)の色をレアに応じて変更
        public static void UpdateRareColor(Item item, Text target1, GameObject target2, Text target3)
        {
            if (item == null)
            {
                if (target1 != null) { target1.color = Color.white; }
                if (target2 != null) { target2.gameObject.GetComponent<Image>().color = Color.white; }
                return;
            }

            switch (item.Rare)
            {
                case Item.RareLevel.Poor:
                    target1.color = Color.white;
                    target2.gameObject.GetComponent<Image>().color = Color.gray;
                    if (target3 != null) { target3.color = Color.white; }
                    break;
                case Item.RareLevel.Common:
                    target1.color = Color.black;
                    target2.gameObject.GetComponent<Image>().color = UnityColor.CommonGreen;
                    if (target3 != null) { target3.color = Color.black; }
                    break;
                case Item.RareLevel.Rare:
                    target1.color = Color.white;
                    target2.gameObject.GetComponent<Image>().color = UnityColor.DarkBlue;
                    if (target3 != null) { target3.color = Color.white; }
                    break;
                case Item.RareLevel.Epic:
                    target1.color = Color.white;
                    target2.gameObject.GetComponent<Image>().color = UnityColor.EpicPurple;
                    if (target3 != null) { target3.color = Color.white; }
                    break;
                case Item.RareLevel.Legendary: // 後編追加
                    target1.color = Color.white;
                    target2.gameObject.GetComponent<Image>().color = UnityColor.OrangeRed;
                    if (target3 != null) { target3.color = Color.white; }
                    break;
            }
        }

        public static void UpdateJobClassImage(FIX.JobClass job, GameObject target)
        {
            switch (job)
            {
                case FIX.JobClass.Fighter:
                    target.GetComponent<Image>().sprite = Resources.Load<Sprite>("Unit_Fighter");
                    break;
                case FIX.JobClass.Ranger:
                    target.GetComponent<Image>().sprite = Resources.Load<Sprite>("Unit_Archer");
                    break;
                case FIX.JobClass.Magician:
                    target.GetComponent<Image>().sprite = Resources.Load<Sprite>("Unit_Magician");
                    break;
                case FIX.JobClass.Seeker:
                    target.GetComponent<Image>().sprite = Resources.Load<Sprite>("Unit_Enchanter");
                    break;
                default:
                    target.GetComponent<Image>().sprite = null;
                    break;
            }
        }

        // 戦闘終了後のアイテムゲット、ファージル宮殿お楽しみ抽選券のアイテムゲットを統合
        public static string GetNewItem(NewItemCategory category)
        {
            string targetItemName = String.Empty;
            int debugCounter1 = 0;
            int debugCounter2 = 0;
            int debugCounter3 = 0;
            int debugCounter4 = 0;
            int debugCounter5 = 0;
            int debugCounter6 = 0;
            int debugCounter7 = 0;

            int debugCounter8 = 0;

            for (int zzz = 0; zzz < 1; zzz++)
            {
                System.Threading.Thread.Sleep(1);

                // ドロップアイテムを出現させる
                System.Random rd = new System.Random(Environment.TickCount * DateTime.Now.Millisecond);
                int param1 = 1000; // 素材
                int param2 = 600; // 武具POOR
                int param3 = 350; // 武具COMMON
                int param4 = 50; // 武具RARE
                int param5 = 20; // パラメタUP
                int param6 = 10; // EPIC
                int param7 = 200; // ハズレ

                if (category == NewItemCategory.Lottery_L1)
                {
                    param1 = 0; // 抽選券または宝箱、モンスター素材ではない。
                    param2 = 0; // 抽選券または宝箱、POORは無しとする
                    param3 = 600;
                    param4 = 240;
                    param5 = 100;
                    param6 = 7;
                    param7 = 0; // 抽選券または宝箱、ハズレは無しとする
                    debugCounter8++;
                }

                int randomValue = rd.Next(1, param1 + param2 + param3 + param4 + param5 + param6 + param7 + 1);
                int randomValue2 = rd.Next(1, 1 + param1 + param2 + param3 + param4);
                int randomValue21 = rd.Next(1, 19);
                int randomValue22 = rd.Next(1, 11);
                int randomValue3 = rd.Next(1, 17);
                int randomValue32 = rd.Next(1, 26);
                int randomValue4 = rd.Next(1, 6);
                int randomValue42 = rd.Next(1, 9);
                int randomValue5 = rd.Next(1, 6);
                int randomValue6 = rd.Next(1, 3);
                int randomValue7 = rd.Next(1, 101);

                #region "エリア毎のアイテム総数に応じた値を設定"
                // 1階は上述宣言時の値そのもの
                if (category == NewItemCategory.Lottery_L1)
                {
                    randomValue21 = rd.Next(1, 19);
                    randomValue22 = rd.Next(1, 11);
                    randomValue3 = rd.Next(1, 17);
                    randomValue32 = rd.Next(1, 26);
                    randomValue4 = rd.Next(1, 6);
                    randomValue42 = rd.Next(1, 9);
                    randomValue5 = rd.Next(1, 6);
                    randomValue6 = rd.Next(1, 3);
                    randomValue7 = rd.Next(1, 101);
                }
                #endregion

                #region "Poor"
                if (1 <= randomValue && randomValue <= param1) // 44.84 %
                {
                    targetItemName = FIX.POOR_BLACK_MATERIAL;
                    //int DropItemNumber = 0;
                    //for (int ii = 0; ii < ec1.DropItem.Length; ii++)
                    //{
                    //    if (ec1.DropItem[ii] != String.Empty)
                    //    {
                    //        DropItemNumber++;
                    //    }
                    //}
                    //if (DropItemNumber <= 0) // 素材登録が無い場合、ハズレ
                    //{
                    //    targetItemName = String.Empty;
                    //}
                    //else
                    //{
                    //    int randomValue1 = AP.Math.RandomInteger(DropItemNumber);
                    //    targetItemName = ec1.DropItem[randomValue1];
                    //}
                    debugCounter1++;
                }
                #endregion
                #region "ダンジョンエリア毎の汎用装備品"
                else if (param1 < randomValue && randomValue <= (param1 + param2 + param3 + param4)) // 44.84%
                {
                    if (1 <= randomValue2 && randomValue2 <= param2) // Poor 60.00%
                    {
                        #region "１階エリア１－２　３－４"
                        if (category == NewItemCategory.Lottery_L1)
                        {
                            switch (randomValue21)
                            {
                                case 1:
                                    targetItemName = FIX.POOR_HINJAKU_ARMRING;
                                    break;
                                case 2:
                                    targetItemName = FIX.POOR_USUYOGORETA_FEATHER;
                                    break;
                                case 3:
                                    targetItemName = FIX.POOR_NON_BRIGHT_ORB;
                                    break;
                                case 4:
                                    targetItemName = FIX.POOR_KUKEI_BANGLE;
                                    break;
                                case 5:
                                    targetItemName = FIX.POOR_SUTERARESHI_EMBLEM;
                                    break;
                                case 6:
                                    targetItemName = FIX.POOR_ARIFURETA_STATUE;
                                    break;
                                case 7:
                                    targetItemName = FIX.POOR_NON_ADJUST_BELT;
                                    break;
                                case 8:
                                    targetItemName = FIX.POOR_SIMPLE_EARRING;
                                    break;
                                case 9:
                                    targetItemName = FIX.POOR_KATAKUZURESHITA_FINGERRING;
                                    break;
                                case 10:
                                    targetItemName = FIX.POOR_IROASETA_CHOKER;
                                    break;
                                case 11:
                                    targetItemName = FIX.POOR_YOREYORE_MANTLE;
                                    break;
                                case 12:
                                    targetItemName = FIX.POOR_NON_HINSEI_CROWN;
                                    break;
                                case 13:
                                    targetItemName = FIX.POOR_TUKAIFURUSARETA_SWORD;
                                    break;
                                case 14:
                                    targetItemName = FIX.POOR_TUKAINIKUI_LONGSWORD;
                                    break;
                                case 15:
                                    targetItemName = FIX.POOR_GATAGAKITERU_ARMOR;
                                    break;
                                case 16:
                                    targetItemName = FIX.POOR_FESTERING_ARMOR;
                                    break;
                                case 17:
                                    targetItemName = FIX.POOR_HINSO_SHIELD;
                                    break;
                                case 18:
                                    targetItemName = FIX.POOR_MUDANIOOKII_SHIELD;
                                    break;
                            }
                        }
                        #endregion
                        debugCounter2++;
                    }
                    // ダンジョンエリア毎のコモン汎用装備品
                    else if (param2 < randomValue2 && randomValue2 <= (param2 + param3)) // Common 35.00%
                    {
                        #region "１階エリア１－２　３－４"
                        if (category == NewItemCategory.Lottery_L1)
                        {
                            switch (randomValue3)
                            {
                                case 1:
                                    targetItemName = FIX.COMMON_RED_PENDANT;
                                    break;
                                case 2:
                                    targetItemName = FIX.COMMON_BLUE_PENDANT;
                                    break;
                                case 3:
                                    targetItemName = FIX.COMMON_PURPLE_PENDANT;
                                    break;
                                case 4:
                                    targetItemName = FIX.COMMON_GREEN_PENDANT;
                                    break;
                                case 5:
                                    targetItemName = FIX.COMMON_YELLOW_PENDANT;
                                    break;
                                case 6:
                                    targetItemName = FIX.COMMON_SISSO_ARMRING;
                                    break;
                                case 7:
                                    targetItemName = FIX.COMMON_FINE_FEATHER;
                                    break;
                                case 8:
                                    targetItemName = FIX.COMMON_KIREINA_ORB;
                                    break;
                                case 9:
                                    targetItemName = FIX.COMMON_FIT_BANGLE;
                                    break;
                                case 10:
                                    targetItemName = FIX.COMMON_PRISM_EMBLEM;
                                    break;
                                case 11:
                                    targetItemName = FIX.COMMON_FINE_SWORD;
                                    break;
                                case 12:
                                    targetItemName = FIX.COMMON_TWEI_SWORD;
                                    break;
                                case 13:
                                    targetItemName = FIX.COMMON_FINE_ARMOR;
                                    break;
                                case 14:
                                    targetItemName = FIX.COMMON_GOTHIC_PLATE;
                                    break;
                                case 15:
                                    targetItemName = FIX.COMMON_FINE_SHIELD;
                                    break;
                                case 16:
                                    targetItemName = FIX.COMMON_GRIPPING_SHIELD;
                                    break;
                            }
                        }
                        else if (category == NewItemCategory.Lottery_L1)
                        {
                            switch (randomValue32)
                            {
                                case 1:
                                    targetItemName = FIX.COMMON_COPPER_RING_TORA;
                                    break;
                                case 2:
                                    targetItemName = FIX.COMMON_COPPER_RING_IRUKA;
                                    break;
                                case 3:
                                    targetItemName = FIX.COMMON_COPPER_RING_UMA;
                                    break;
                                case 4:
                                    targetItemName = FIX.COMMON_COPPER_RING_KUMA;
                                    break;
                                case 5:
                                    targetItemName = FIX.COMMON_COPPER_RING_HAYABUSA;
                                    break;
                                case 6:
                                    targetItemName = FIX.COMMON_COPPER_RING_TAKO;
                                    break;
                                case 7:
                                    targetItemName = FIX.COMMON_COPPER_RING_USAGI;
                                    break;
                                case 8:
                                    targetItemName = FIX.COMMON_COPPER_RING_KUMO;
                                    break;
                                case 9:
                                    targetItemName = FIX.COMMON_COPPER_RING_SHIKA;
                                    break;
                                case 10:
                                    targetItemName = FIX.COMMON_COPPER_RING_ZOU;
                                    break;
                                case 11:
                                    targetItemName = FIX.COMMON_RED_AMULET;
                                    break;
                                case 12:
                                    targetItemName = FIX.COMMON_BLUE_AMULET;
                                    break;
                                case 13:
                                    targetItemName = FIX.COMMON_PURPLE_AMULET;
                                    break;
                                case 14:
                                    targetItemName = FIX.COMMON_GREEN_AMULET;
                                    break;
                                case 15:
                                    targetItemName = FIX.COMMON_YELLOW_AMULET;
                                    break;
                                case 16:
                                    targetItemName = FIX.COMMON_SHARP_CLAW;
                                    break;
                                case 17:
                                    targetItemName = FIX.COMMON_LIGHT_CLAW;
                                    break;
                                case 18:
                                    targetItemName = FIX.COMMON_WOOD_ROD;
                                    break;
                                case 19:
                                    targetItemName = FIX.COMMON_SHORT_SWORD;
                                    break;
                                case 20:
                                    targetItemName = FIX.COMMON_BASTARD_SWORD;
                                    break;
                                case 21:
                                    targetItemName = FIX.COMMON_LETHER_CLOTHING;
                                    break;
                                case 22:
                                    targetItemName = FIX.COMMON_COTTON_ROBE;
                                    break;
                                case 23:
                                    targetItemName = FIX.COMMON_COPPER_ARMOR;
                                    break;
                                case 24:
                                    targetItemName = FIX.COMMON_HEAVY_ARMOR;
                                    break;
                                case 25:
                                    targetItemName = FIX.COMMON_IRON_SHIELD;
                                    break;
                            }
                        }
                        #endregion
                        debugCounter3++;
                    }
                    // ダンジョンエリア毎のレア汎用装備品
                    else if ((param2 + param3) < randomValue2 && randomValue2 <= (param2 + param3 + param4)) // Rare 5.00%
                    {
                        #region "１階エリア１－２　３－４"
                        if (category == NewItemCategory.Lottery_L1)
                        {
                            switch (randomValue4)
                            {
                                case 1:
                                    targetItemName = FIX.RARE_JOUSITU_BLUE_POWERRING;
                                    break;
                                case 2:
                                    targetItemName = FIX.RARE_KOUJOUSINYADORU_RED_ORB;
                                    break;
                                case 3:
                                    targetItemName = FIX.RARE_MAGICIANS_MANTLE;
                                    break;
                                case 4:
                                    targetItemName = FIX.RARE_BEATRUSH_BANGLE;
                                    break;
                                case 5:
                                    targetItemName = FIX.RARE_AERO_BLADE;
                                    break;
                            }
                        }
                        #endregion
                        debugCounter4++;
                    }
                }
                #endregion
                #region "ダンジョン階層依存のパワーアップアイテム"
                else if ((param1 + param2 + param3 + param4) < randomValue && randomValue <= (param1 + param2 + param3 + param4 + param5)) // Rare Use Item 0.90%
                {
                    #region "１階全エリア"
                    if (category == NewItemCategory.Lottery_L1)
                    {
                        switch (randomValue5)
                        {
                            case 1:
                                targetItemName = FIX.GROWTH_LIQUID_STRENGTH;
                                break;
                            case 2:
                                targetItemName = FIX.GROWTH_LIQUID_AGILITY;
                                break;
                            case 3:
                                targetItemName = FIX.GROWTH_LIQUID_INTELLIGENCE;
                                break;
                            case 4:
                                targetItemName = FIX.GROWTH_LIQUID_STAMINA;
                                break;
                            case 5:
                                targetItemName = FIX.GROWTH_LIQUID_MIND;
                                break;
                        }
                    }
                    #endregion
                     debugCounter5++;
                }
                #endregion
                #region "ダンジョン階層依存の高級装備品"
                else if ((param1 + param2 + param3 + param4 + param5) < randomValue && randomValue <= (param1 + param2 + param3 + param4 + param5 + param6)) // EPIC 0.45%
                {
                    #region "１階全エリア"
                    if (category == NewItemCategory.Lottery_L1)
                    {
                        switch (randomValue6)
                        {
                            case 1:
                                targetItemName = FIX.EPIC_RING_OF_OSCURETE;
                                break;
                            case 2:
                                targetItemName = FIX.EPIC_MERGIZD_SOL_BLADE;
                                break;
                        }
                        //GroundOne.WE2.KillingEnemy = 0; // EPIC出現後、ボーナス値をリセットしておく。
                    }
                    #endregion
                    debugCounter6++;
                }
                #endregion
                #region "ハズレ"
                else if ((param1 + param2 + param3 + param4 + param5 + param6) < randomValue && randomValue <= (param1 + param2 + param3 + param4 + param5 + param6 + param7)) // ハズレ 8.97 %
                {
                    targetItemName = String.Empty;
                    debugCounter7++;
                }
                else // 万が一規定外の値はハズレ
                {
                    targetItemName = String.Empty;
                }
                #endregion

                #region "ハズレは、不用品をランダムドロップ"
                if (targetItemName == string.Empty)
                {
                    if (category == NewItemCategory.Lottery_L1)
                    {
                        if (1 <= randomValue7 && randomValue7 <= 50)
                        {
                            targetItemName = FIX.POOR_BLACK_MATERIAL;
                        }
                    }
                }
                #endregion
            }

            //MessageBox.Show(debugCounter1.ToString() + "(" + Convert.ToString((double)(((double)debugCounter1 / 10000.0f) * 100.0f)) + "\r\n" +
            //                debugCounter2.ToString() + "(" + Convert.ToString((double)(((double)debugCounter2 / 10000.0f) * 100.0f)) + "\r\n" +
            //                debugCounter3.ToString() + "(" + Convert.ToString((double)(((double)debugCounter3 / 10000.0f) * 100.0f)) + "\r\n" +
            //                debugCounter4.ToString() + "(" + Convert.ToString((double)(((double)debugCounter4 / 10000.0f) * 100.0f)) + "\r\n" +
            //                debugCounter5.ToString() + "(" + Convert.ToString((double)(((double)debugCounter5 / 10000.0f) * 100.0f)) + "\r\n" +
            //                debugCounter6.ToString() + "(" + Convert.ToString((double)(((double)debugCounter6 / 10000.0f) * 100.0f)) + "\r\n" +
            //                debugCounter7.ToString() + "(" + Convert.ToString((double)(((double)debugCounter7 / 10000.0f) * 100.0f)) + "\r\n" +
            //                debugCounter8.ToString() + "\r\n");

            return targetItemName;
        }
    }
}
