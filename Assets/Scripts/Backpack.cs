using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObsidianPortal
{
    public class Backpack : MonoBehaviour
    {
        protected List<Item> backpack = new List<Item>(FIX.MAX_BACKPACK_SIZE);
        protected List<Item> valuables = new List<Item>(FIX.MAX_BACKPACK_SIZE);

        public List<Item> BackpackList
        {
            get { return backpack; }
        }
        public List<Item> ValuableList
        {
            get { return valuables; }
        }

        /// <summary>
        /// バックパックにアイテムを追加します。
        /// </summary>
        /// <param name = "item" ></ param >
        /// < returns > TRUE:追加完了、FALSE:満杯のため追加できない</returns>
        public bool AddBackPack(Item item, int addValue)
        {
            return AbstractAddItem(backpack, item, addValue);
        }
        public bool AddValuables(Item item, int addValue)
        {
            return AbstractAddItem(valuables, item, addValue);
        }
        protected bool AbstractAddItem(List<Item> list, Item item, int addValue)
        {
            // バックパックを検索し、新しいアイテムとして追加するかどうか確認する。
            for (int ii = 0; ii < list.Count; ii++)
            {
                if (list[ii].ItemName == item.ItemName)
                {
                    // スタック上限に指定した数のぶんだけ追加で間に合う場合は、スタック数を追加して終わり。
                    if (list[ii].StackValue + addValue <= item.LimitValue)
                    {
                        list[ii].StackValue += addValue;
                        return true;
                    }
                }
            }

            // バックパックの上限を超えている場合は、満杯とみなして追加しない。
            if (list.Count >= FIX.MAX_BACKPACK_SIZE)
            {
                return false;
            }

            // 新しいアイテムを追加する。
            list.Add(item);
            list[list.Count - 1].StackValue = addValue;
            return true;
        }


        /// <summary>
        /// バックパックのアイテムを指定した数だけ削除します。
        /// </summary>
        /// <param name = "item" ></ param >
        /// < param name="deleteValue">指定数だけ削除</param>
        /// <returns></returns>
        public void DeleteBackPack(Item item, int deleteValue)
        {
            AbstractDeleteItem(backpack, item, deleteValue);
        }
        public void DeleteValuables(Item item, int deteteValue)
        {
            AbstractDeleteItem(valuables, item, deteteValue);
        }
        protected void AbstractDeleteItem(List<Item> list, Item item, int deleteValue)
        {
            for (int ii = 0; ii < list.Count; ii++)
            {
                if (list[ii] != null)
                {
                    if (list[ii].ItemName == item.ItemName)
                    {
                        // スタック量が正値の場合、指定されたスタック量を減らす。
                        list[ii].StackValue -= deleteValue;
                        if (list[ii].StackValue <= 0) // 結果的にスタック量が０になった場合はオブジェクトを消す。
                        {
                            list.RemoveAt(ii);
                        }
                        break;
                    }
                }
            }
        }

        public void DeleteBackPackAll()
        {
            AbstractDeleteItemAll(backpack);
        }
        public void DeleteValuablesAll()
        {
            AbstractDeleteItemAll(valuables);
        }
        protected void AbstractDeleteItemAll(List<Item> list)
        {
            list.Clear();
        }

        /// <summary>
        /// バックパックに対象のアイテムが含まれている数を示します。
        /// </summary>
        /// <param name = "item" ></ param >
        /// < returns ></ returns >
        public int CheckBackPackExist(Item item, int ii)
        {
            return AbstractItemExist(backpack, item, ii);
        }
        public int CheckValuablesExist(Item item, int ii)
        {
            return AbstractItemExist(valuables, item, ii);
        }
        protected int AbstractItemExist(List<Item> list, Item item, int ii)
        {
            if (list[ii] != null)
            {
                if (list[ii].ItemName == item.ItemName)
                {
                    return list[ii].StackValue;
                }
            }
            return 0;
        }

        /// <summary>
        /// バックパックに対象のアイテムが含まれているかどうかをチェックします。
        /// </summary>
        /// <param name = "itemName" > 検索対象となるアイテム名 </ param >
        /// < returns > true: 存在する,  false: 存在しない</returns>
        public bool FindBackPackItem(string itemName)
        {
            return AbstractFindItem(backpack, itemName);
        }
        public bool FindValuablesItem(string itemName)
        {
            return AbstractFindItem(valuables, itemName);
        }
        protected bool AbstractFindItem(List<Item> list, string itemName)
        {
            for (int ii = 0; ii < list.Count; ii++)
            {
                if (list[ii] != null && list[ii].ItemName == itemName)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// バックパックの内容を一括で全て取得します。
        /// </summary>
        /// <returns></returns>
        public List<Item> GetBackPackInfo()
        {
            return backpack;
        }
        public List<Item> GetValuablesInfo()
        {
            return valuables;
        }
    }
}