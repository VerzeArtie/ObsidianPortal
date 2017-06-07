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

    }
}
