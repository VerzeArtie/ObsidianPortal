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
            Lottery,
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


        public static void UpdateItemImage(Item item, Image src)
        {
            Texture2D current = Resources.Load<Texture2D>("ItemIcon");
            int BASE_SIZE = 49;
            int locX = 0;
            int locY = 0;
            if ((item.Type == Item.ItemType.Weapon_Heavy) ||
                (item.Type == Item.ItemType.Weapon_Middle))
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
            else if (item.Type == Item.ItemType.Shield)
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
                case FIX.JobClass.Archer:
                    target.GetComponent<Image>().sprite = Resources.Load<Sprite>("Unit_Archer");
                    break;
                case FIX.JobClass.Magician:
                    target.GetComponent<Image>().sprite = Resources.Load<Sprite>("Unit_Magician");
                    break;
                case FIX.JobClass.Armorer:
                    target.GetComponent<Image>().sprite = Resources.Load<Sprite>("Unit_Shield");
                    break;
                case FIX.JobClass.Apprentice:
                    target.GetComponent<Image>().sprite = Resources.Load<Sprite>("Unit_Enchanter");
                    break;
                default:
                    target.GetComponent<Image>().sprite = null;
                    break;
            }
        }
    }
}
