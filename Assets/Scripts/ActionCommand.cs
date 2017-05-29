using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObsidianPortal
{
    public class ActionCommand
    {
        /// <summary>
        /// コマンドのターゲットタイプ
        /// </summary>
        public enum TargetType
        {
            NoTarget, // 対象を取らない。
            Ally, // 味方１体
            Enemy, // 敵１体
            Area, // エリア指定
            AllyOrEnemy, // 味方１対か敵１体
            Own, // 自分自身
            AllyGroup, // 味方全員
            EnemyGroup, // 敵全員
            AllMember, // 敵味方全員
            InstantTarget, // インスタント行動を対象
        }

        /// <summary>
        /// コマンドのターゲットタイプを判別します。
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public static TargetType GetTargetType(string command)
        {
            // 単一敵
            if (command == FIX.NORMAL_ATTACK) { return TargetType.Enemy; }

            if (command == FIX.DASH) { return TargetType.Enemy; }
            if (command == FIX.REACHABLETARGET) { return TargetType.Enemy; }
            if (command == FIX.EARTHBIND) { return TargetType.Enemy; }
            if (command == FIX.NEEDLESPEAR) { return TargetType.Enemy; }
            if (command == FIX.SILVERARROW) { return TargetType.Enemy; }
            if (command == FIX.BLAZE) { return TargetType.Area; }
            if (command == FIX.LAVAWALL) { return TargetType.Area; }
            if (command == FIX.EXPLOSION) { return TargetType.Enemy; }
            // 単一味方（効果）
            if (command == FIX.POWERWORD) { return TargetType.Ally; }
            if (command == FIX.PROTECTION) { return TargetType.Ally; }
            if (command == FIX.HEATBOOST) { return TargetType.Ally; }
            // 単一味方（回復）
            if (command == FIX.HEALINGWORD) { return TargetType.Ally; }
            if (command == FIX.FRESHHEAL) { return TargetType.Ally; }
            // 自分自身
            if (command == FIX.FIREBLADE) { return TargetType.Own; }
            if (command == FIX.HOLYBULLET) { return TargetType.Own; }

            return TargetType.NoTarget;
        }

        /// <summary>
        /// コマンドが回復系かどうかを判別します。(trueが回復系)
        /// </summary>
        /// <param name="commandName"></param>
        /// <returns></returns>
        public static bool IsHeal(string command)
        {
            if (command == FIX.HEALINGWORD ||
                command == FIX.FRESHHEAL)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// アニメーション対象番号を取得します。(-1の場合、アニメーションなしを実行してください）
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public static int GetSkillNumbering(string command)
        {
            if (command == FIX.NORMAL_ATTACK) { return 0; }
            if (command == FIX.DASH) { return 1; }
            if (command == FIX.REACHABLETARGET) { return 2; }
            if (command == FIX.EARTHBIND) { return 3; }
            if (command == FIX.POWERWORD) { return 4; }
            if (command == FIX.HEALINGWORD) { return 5; }
            if (command == FIX.NEEDLESPEAR) { return 6; }
            if (command == FIX.SILVERARROW) { return 7; }
            if (command == FIX.HOLYBULLET) { return 8; }
            if (command == FIX.PROTECTION) { return 9; }
            if (command == FIX.FRESHHEAL) { return 10; }
            if (command == FIX.FIREBLADE) { return 11; }
            if (command == FIX.LAVAWALL) { return 12; }
            if (command == FIX.BLAZE) { return 13; }
            if (command == FIX.HEATBOOST) { return 14; }
            if (command == FIX.EXPLOSION) { return 15; }
            return -1;
        }

        /// <summary>
        /// コマンドの説明文を取得します。
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public static string GetDescription(string command)
        {
            if (command == FIX.NORMAL_ATTACK) { return "通常攻撃を行う。"; }

            // 人間族
            if (command == FIX.DASH) { return "直線上にある２つ先のタイルに存在する対象の敵へ近づき、【３】ダメージを与える。"; }
            if (command == FIX.REACHABLETARGET) { return "対象の敵をターゲットとして記憶する。ターゲット対象はダメージ発生時、追加で【２】ダメージ食らう。"; }
            if (command == FIX.EARTHBIND) { return "対象の敵を拘束し、移動不可にする。"; }
            if (command == FIX.HEALINGWORD) { return "対象の味方のライフを【３】回復する。その後、対象の順序が来た場合、ライフを【３】回復する。"; }
            if (command == FIX.POWERWORD) { return "対象の味方のSTRを【＋２】する。"; }
            // 天使族
            if (command == FIX.NEEDLESPEAR) { return "対象の敵へ【３】ダメージを与える。加えて、対象の位置を１タイルだけ後方へ移動させる。"; }
            if (command == FIX.SILVERARROW) { return "対象の敵に【３】ダメージを与える。加えて、次の順序が来た場合、特殊能力が発動できなくなる。"; }
            if (command == FIX.HOLYBULLET) { return "自分の位置を中心として、周囲のタイルに存在する敵ユニットへ【４】ダメージを与える。"; }
            if (command == FIX.PROTECTION) { return "対象の味方のDEFを【＋２】する。"; }
            if (command == FIX.FRESHHEAL) { return "対象の味方の状態異常を解除する。加えて、ライフを【６】回復する。"; }
            // 炎霊族
            if (command == FIX.FIREBLADE) { return "自分自身のSTRを【＋３】する。"; }
            if (command == FIX.LAVAWALL) { return "自分の前方周囲のタイル３つに炎の壁を出現させる。このタイルに隣接しているユニットは順序開始時【１】ダメージ受ける。"; }
            if (command == FIX.BLAZE) { return "直線上にある３つ先のタイルまで存在するユニットに対して、【５】ダメージを与える。"; }
            if (command == FIX.HEATBOOST) { return "対象の味方の待機時間を【－８】する。"; }
            if (command == FIX.EXPLOSION) { return "自分自身を爆発させる事で、対象の敵に【２５】ダメージを与える。この後、本ユニットは死亡する。"; }

            return string.Empty;
        }

        public static int IsBuffTurn(string command)
        {
            if (command == FIX.POWERWORD) { return 5; }
            if (command == FIX.SILVERARROW) { return 2; }
            if (command == FIX.EARTHBIND) { return 2; }
            if (command == FIX.PROTECTION) { return 5; }
            if (command == FIX.FIREBLADE) { return 5; }
            if (command == FIX.HEALINGWORD) { return 2; }
            if (command == FIX.REACHABLETARGET) { return 5; }

            return FIX.INFINITY;
        }

        public static int EffectValue(string command)
        {
            if (command == FIX.HOLYBULLET) { return 5; }
            if (command == FIX.REACHABLETARGET) { return 2; }

            return 0;
        }            
    }
}
