using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace ObsidianPortal
{
    public class Unit : MonoBehaviour
    {
        public enum Ally
        {
            Ally,
            Enemy,
        }

        public enum UnitType
        {
            None,
            Fighter,
            Archer,
            Magician,
            //Sorcerer,
            //Enchanter,
            //Priest,
            //Wall,
        }

        public enum RaceType
        {
            None,
            Human,
            Monster,
            //Angel,
            //Fire,
            //Demon,
            //Mech,
            //Ice,
        }

        // ユニット属性値
        public string UnitName = ""; // 名前
        public int MaxLife = 1; // 最大ライフ
        private int MovePoint = 1; // 移動力
        private int Attack = 1; // 攻撃力
        public int AttackRange = 1; // 攻撃範囲
        public int HealRange = 1; // 回復範囲
        public int EffectRange = 1; // 味方効果範囲
        public string SkillName = "";
        private int Defense = 1; // 防御力
        private int Speed = 1; // 速度
        private int MagicAttack = 1; // 魔法攻撃力
        private int MagicDefense = 1; // 魔法防御力
        public int Cost = 999; // コスト
        public bool ActionComplete = false; // 行動完了フラグ
        public bool Dead = false; // 生死フラグ
        public RaceType Race = RaceType.Human; // ユニット属性
        public UnitType Type = UnitType.None; // ユニットタイプ
        public Ally ally = Ally.Ally; // 陣営タイプ
        private int currentLife;
        public int CurrentLife // 現在ライフ
        {
            get { return currentLife; }
            set
            {
                if (value > this.MaxLife) { value = this.MaxLife; }
                if (value < 0) { value = 0; }
                this.currentLife = value;
            }
        }
        public int currentTime = 100; // 現在待機時間
        public int CurrentTime
        {
            get { return this.currentTime; }
            set
            {
                if (value <= 0) { value = 0; }
                this.currentTime = value;
            }
        }
        public int CurrentMovePoint = 1; // 現在移動可能ポイント（敵専用）

        // BUFF効果
        public int CurrentPowerWord = 0; // STR UP
        public int CurrentPowerWordValue = 0;
        public int CurrentSilverArrow = 0; // SILENCE
        public int CurrentSilverArrowValue = 0;
        public int CurrentProtection = 0; // DEF UP
        public int CurrentProtectionValue = 0;
        public int CurrentFireBlade = 0; // STR UP
        public int CurrentFireBladeValue = 0;
        public int CurrentEarthBind = 0; // Cannot Move
        public int CurrentEarthBindValue = 0;
        public int CurrentHealingWord = 0; // After life gain
        public int CurrentHealingWordValue = 0;
        public int CurrentReachableTarget = 0; // DEF DOWN
        public int CurrentReachabletargetValue = 0;

        // Gauge
        public GameObject LifeGauge;

        /// <summary>
        /// 倒された時の経験値取得
        /// </summary>
        public int GetExp
        {
            get { return 100; }
        }

        public void Initialize(RaceType race, UnitType type, bool enemy)
        {
            this.Type = type;
            if (enemy)
            {
                this.ally = Ally.Enemy;
            }
            else
            {
                this.ally = Ally.Ally;
            }

            // 人間族                                                                                                     L,  A, D,  S,  M, MD,MV,AR, HR, ER, C, SKILL 
            if (race == RaceType.Human && type == UnitType.Fighter)     { SetupProperty(race, type, FIX.HUMAN_FIGHTER,   20, 12, 3,  7,  1,  1, 4, 1,  0,  2, 10, FIX.DASH); }
            if (race == RaceType.Human && type == UnitType.Archer)      { SetupProperty(race, type, FIX.HUMAN_ARCHER,    16,  8, 2, 11,  1,  2, 4, 2,  0,  3, 10, FIX.REACHABLETARGET); }
            if (race == RaceType.Human && type == UnitType.Magician)    { SetupProperty(race, type, FIX.HUMAN_MAGICIAN,  13,  3, 1,  9,  8,  3, 4, 2,  0,  2, 10, FIX.EARTHBIND); }
            //if (race == RaceType.Human && type == UnitType.Sorcerer)  { SetupProperty(race, type, FIX.HUMAN_SORCERER,  13,  3, 1,  9, 10,  3, 4, 2,  0,  2, 10, FIX.EARTHBIND); }
            //if (race == RaceType.Human && type == UnitType.Enchanter) { SetupProperty(race, type, FIX.HUMAN_ENCHANTER, 11,  5, 2,  6,  8,  2, 4, 1,  0,  1, 10, FIX.POWERWORD); }
            //if (race == RaceType.Human && type == UnitType.Priest)    { SetupProperty(race, type, FIX.HUMAN_PRIEST,    10,  1, 1,  5,  6,  2, 3, 1,  2,  2, 10, FIX.HEALINGWORD); }
            //// 天使族
            //if (race == RaceType.Angel && type == UnitType.Fighter)   { SetupProperty(race, type, FIX.ANGEL_DOMINION,  19, 11, 3,  7,  3,  2, 4, 1,  0,  1, 10, FIX.NEEDLESPEAR); }
            //if (race == RaceType.Angel && type == UnitType.Archer)    { SetupProperty(race, type, FIX.ANGEL_VALKYRIE,  16,  7, 2, 12,  7,  3, 4, 2,  0,  2, 10, FIX.SILVERARROW); }
            //if (race == RaceType.Angel && type == UnitType.Sorcerer)  { SetupProperty(race, type, FIX.ANGEL_HOLYEYE,   14,  4, 1, 10,  9,  4, 4, 2,  0,  2, 10, FIX.HOLYBULLET); }
            //if (race == RaceType.Angel && type == UnitType.Enchanter) { SetupProperty(race, type, FIX.ANGEL_QUPID,     10,  3, 1,  9,  6,  2, 3, 1,  0,  2, 10, FIX.PROTECTION); }
            //if (race == RaceType.Angel && type == UnitType.Priest)    { SetupProperty(race, type, FIX.ANGEL_ANGEL,     12,  2, 1,  6,  8,  3, 3, 1,  2,  0, 10, FIX.FRESHHEAL); }
            //// 炎霊族
            //if (race == RaceType.Fire && type == UnitType.Fighter)    { SetupProperty(race, type, FIX.FIRE_SALAMANDER, 22, 13, 2,  7,  1,  1, 4, 1,  0,  0, 10, FIX.FIREBLADE); } 
            //if (race == RaceType.Fire && type == UnitType.Archer)     { SetupProperty(race, type, FIX.FIRE_FLAMEBIRD,  18,  9, 1, 10,  1,  2, 3, 1,  0,  1, 10, FIX.LAVAWALL); }
            //if (race == RaceType.Fire && type == UnitType.Sorcerer)   { SetupProperty(race, type, FIX.FIRE_EFREET,     14,  5, 1, 12, 12,  2, 4, 2,  0,  3, 10, FIX.BLAZE); }
            //if (race == RaceType.Fire && type == UnitType.Enchanter)  { SetupProperty(race, type, FIX.FIRE_ELEMENTAL,  12,  8, 1,  8,  8,  1, 4, 2,  0,  1, 10, FIX.HEATBOOST); }
            //if (race == RaceType.Fire && type == UnitType.Priest)     { SetupProperty(race, type, FIX.FIRE_REDBOMB,     8,  4, 1,  5,  4,  5, 3, 1,  0,  1, 10, FIX.EXPLOSION); }

            //if (race == RaceType.Fire && type == UnitType.Wall)       { SetupProperty(race, type, FIX.OBJ_LAVAWALL,    99,  0, 0,  0,  0,  0, 0, 0,  0,  0,  0, FIX.NONE); }

            // モンスター
            if (race == RaceType.Monster && type == UnitType.Fighter)   { SetupProperty(race, type, FIX.HUMAN_FIGHTER,   36,  8, 2,  5,  1,  1, 4, 1,  0,  0, 10, FIX.NONE); }
        }

        private void SetupProperty(RaceType race, UnitType type, string unitName, int maxLife, int attack, int def, int spd, int mag, int mdf, int move, int range, int healRange, int effectRange, int cost, string skill)
        {
            this.Race = race;
            this.Type = type;
            this.UnitName = unitName;
            this.MaxLife = maxLife;
            this.Attack = attack;
            this.Defense = def;
            this.Speed = spd;
            this.MagicAttack = mag;
            this.MagicDefense = mdf;
            this.AttackRange = range;
            this.EffectRange = effectRange;
            this.HealRange = healRange;
            this.MovePoint = move;
            this.Cost = cost;
            this.SkillName = skill;

            this.CurrentLife = this.MaxLife;
            this.CurrentTime = 100 - this.Speed;
            this.CurrentMovePoint = this.MovePoint;
            this.Dead = false;
        }

        public void Completed()
        {
            this.CurrentTime = 100 - this.Speed;
            Debug.Log("Completed: " + this.CurrentTime.ToString());
        }

        public void CleanUp()
        {
            this.CurrentMovePoint = this.MovePoint;
            CountDown(ref this.CurrentPowerWord);
            CountDown(ref this.CurrentSilverArrow);
            CountDown(ref this.CurrentProtection);
            CountDown(ref this.CurrentFireBlade);
            CountDown(ref this.CurrentEarthBind);
            CountDown(ref this.CurrentHealingWord);

            this.GetComponent<MeshRenderer>().material = Resources.Load(Type.ToString()) as Material;

            if (this.CurrentHealingWord > 0)
            {
                this.currentLife += ActionCommand.EffectValue(FIX.HEALINGWORD);
                if (this.IsAlly)
                {
                    ONE.BattleHealingDone += ActionCommand.EffectValue(FIX.HEALINGWORD);
                }
            }
            // todo healingWord
        }

        private void CountDown(ref int value)
        {
            if (value > 0) { value--; }
        }

        public void DeadUnit()
        {
            Debug.Log("DeadUnit: " + this.UnitName);
            this.CurrentLife = 0;
            this.Dead = true;
            this.Completed();
            this.GetComponent<MeshRenderer>().material = Resources.Load("Dead") as Material;
            if (this.LifeGauge != null)
            {
                this.LifeGauge.SetActive(false);
            }
        }

        public bool IsAlly
        {
            get
            {
                if (this.ally == Ally.Ally)
                {
                    return true;
                }
                return false;
            }
        }
        public bool IsEnemy
        {
            get
            {
                if (this.ally == Ally.Enemy)
                {
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        /// 総合的な攻撃力を取得します。
        /// </summary>
        public int AttackValue
        {
            get { return this.Attack + this.CurrentPowerWord + this.CurrentFireBlade; }
        }

        /// <summary>
        /// 総合的な防御力を取得します。
        /// </summary>
        public int DefenseValue
        {
            get { return this.Defense + this.CurrentProtection; }
        }

        /// <summary>
        /// 総合的な魔法攻撃力を取得します。
        /// </summary>
        public int MagicAttackValue
        {
            get { return this.MagicAttack; }
        }

        /// <summary>
        /// 総合的な魔法防御力を取得します。
        /// </summary>
        public int MagicDefenseValue
        {
            get { return this.MagicDefense; }
        }

        /// <summary>
        /// 総合的な速度を取得します。
        /// </summary>
        public int SpeedValue
        {
            get { return this.Speed; }
        }

        /// <summary>
        ///  総合的な移動量を取得します。
        /// </summary>
        public int MoveValue
        {
            get { return this.MovePoint; }
        }

        /// <summary>
        /// 飛行可能なユニットかどうか判別します。(trueなら飛行可能)
        /// </summary>
        /// <returns></returns>
        public bool IsFlying()
        {
            // 初版はすべて地上ユニットとする。
            return false;
        }

        /// <summary>
        /// 方向を指定して、隣接する位置情報を取得します。
        /// </summary>
        /// <param name="direction"></param>
        /// <returns></returns>
        public Vector3 GetNeighborhood(FIX.Direction direction)
        {
            if (direction == FIX.Direction.Top)
            {
                return new Vector3(this.transform.localPosition.x, this.transform.localPosition.y + FIX.HEX_MOVE_X, this.transform.localPosition.z);
            }
            else if (direction == FIX.Direction.Right)
            {
                return new Vector3(this.transform.localPosition.x + FIX.HEX_MOVE_X, this.transform.localPosition.y, this.transform.localPosition.z);
            }
            else if (direction == FIX.Direction.Left)
            {
                return new Vector3(this.transform.localPosition.x - FIX.HEX_MOVE_X, this.transform.localPosition.y, this.transform.localPosition.z);
            }
            else if (direction == FIX.Direction.Bottom)
            {
                return new Vector3(this.transform.localPosition.x, this.transform.localPosition.y - FIX.HEX_MOVE_X, this.transform.localPosition.z);
            }

            // same as Top
            return new Vector3(this.transform.localPosition.x + FIX.HEX_MOVE_X, this.transform.localPosition.y, this.transform.localPosition.z);
        }

        /// <summary>
        /// 方向を指定して、ユニットを移動します。
        /// </summary>
        /// <param name="direction"></param>
        public void Move(FIX.Direction direction)
        {
            if (direction == (int)(FIX.Direction.Top))
            {
                this.transform.localPosition = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y + FIX.HEX_MOVE_X, this.transform.localPosition.z);
            }
            else if (direction == FIX.Direction.Right)
            {
                this.transform.localPosition = new Vector3(this.transform.localPosition.x + FIX.HEX_MOVE_X, this.transform.localPosition.y, this.transform.localPosition.z);
            }
            else if (direction == FIX.Direction.Left)
            {
                this.transform.localPosition = new Vector3(this.transform.localPosition.x - FIX.HEX_MOVE_X, this.transform.localPosition.y, this.transform.localPosition.z);
            }
            else if (direction == FIX.Direction.Bottom)
            {
                this.transform.localPosition = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y - FIX.HEX_MOVE_X, this.transform.localPosition.z);
            }
        }

        public static int Compare(Unit a, Unit b)
        {
            if (a.CurrentTime > b.CurrentTime) { return 1; }
            else if (a.CurrentTime == b.CurrentTime) { return 0; }
            else { return -1; }
        }

        public Vector3 Top
        {
            get { return new Vector3(this.transform.localPosition.x, this.transform.localPosition.y + 1, this.transform.localPosition.z); }
        }
        public Vector3 Left
        {
            get { return new Vector3(this.transform.localPosition.x - 1, this.transform.localPosition.y, this.transform.localPosition.z); }
        }
        public Vector3 Right
        {
            get { return new Vector3(this.transform.localPosition.x + 1, this.transform.localPosition.y, this.transform.localPosition.z); }
        }
        public Vector3 Botoom
        {
            get { return new Vector3(this.transform.localPosition.x, this.transform.localPosition.y - 1, this.transform.localPosition.z); }
        }
    }
}