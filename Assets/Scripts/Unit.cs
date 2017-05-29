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
            Sorcerer,
            Enchanter,
            Priest,
            Wall,
        }

        public enum RaceType
        {
            Human,
            Angel,
            Fire,
            Demon,
            Mech,
            Ice,
        }

        // ���j�b�g�����l
        public string UnitName = ""; // ���O
        public int MaxLife = 1; // �ő僉�C�t
        private int MovePoint = 1; // �ړ���
        private int Attack = 1; // �U����
        public int AttackRange = 1; // �U���͈�
        public int HealValue = 1; // �񕜗�
        public int HealRange = 1; // �񕜔͈�
        public int EffectValue = 1; // �����֌��ʂ�^����l
        public int EffectRange = 1; // �������ʔ͈�
        public string SkillName = "";
        private int Defense = 1; // �h���
        private int Speed = 1; // ���x
        private int MagicAttack = 1; // ���@�U����
        private int MagicDefense = 1; // ���@�h���
        public int Cost = 999; // �R�X�g
        public bool ActionComplete = false; // �s�������t���O
        public bool Dead = false; // �����t���O
        public RaceType Race = RaceType.Human; // ���j�b�g����
        public UnitType Type = UnitType.None; // ���j�b�g�^�C�v
        public Ally ally = Ally.Ally; // �w�c�^�C�v
        private int currentLife;
        public int CurrentLife // ���݃��C�t
        {
            get { return currentLife; }
            set
            {
                if (value > this.MaxLife) { value = this.MaxLife; }
                if (value < 0) { value = 0; }
                this.currentLife = value;
            }
        }
        public int CurrentTime = 100; // ���ݑҋ@����
        public int CurrentMovePoint = 1; // ���݈ړ��\�|�C���g�i�G��p�j

        // BUFF����
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

        /// <summary>
        /// �|���ꂽ���̌o���l�擾
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

            // �l�ԑ�                                                                                                   L,  A, D,  S,  M, MD,MV,AR, H,HR, E,ER, C, SKILL 
            if (race == RaceType.Human && type == UnitType.Fighter)   { SetupProperty(race, type, FIX.HUMAN_FIGHTER,   20, 12, 3,  7,  1,  1, 4, 1, 0, 0, 3, 2, 10, FIX.DASH); }
            if (race == RaceType.Human && type == UnitType.Archer)    { SetupProperty(race, type, FIX.HUMAN_ARCHER,    16,  8, 2, 11,  1,  2, 4, 2, 0, 0, 2, 3, 10, FIX.REACHABLETARGET); }
            if (race == RaceType.Human && type == UnitType.Sorcerer)  { SetupProperty(race, type, FIX.HUMAN_SORCERER,  13,  3, 1,  9, 10,  3, 4, 2, 0, 0, 1, 2, 10, FIX.EARTHBIND); }
            if (race == RaceType.Human && type == UnitType.Enchanter) { SetupProperty(race, type, FIX.HUMAN_ENCHANTER, 11,  5, 2,  6,  8,  2, 4, 1, 0, 0, 2, 1, 10, FIX.POWERWORD); }
            if (race == RaceType.Human && type == UnitType.Priest)    { SetupProperty(race, type, FIX.HUMAN_PRIEST,    10,  1, 1,  5,  6,  2, 3, 1, 3, 2, 3, 2, 10, FIX.HEALINGWORD); }
            // �V�g��
            if (race == RaceType.Angel && type == UnitType.Fighter)   { SetupProperty(race, type, FIX.ANGEL_DOMINION,  19, 11, 3,  7,  3,  2, 4, 1, 0, 0, 3, 1, 10, FIX.NEEDLESPEAR); }
            if (race == RaceType.Angel && type == UnitType.Archer)    { SetupProperty(race, type, FIX.ANGEL_VALKYRIE,  16,  7, 2, 12,  7,  3, 4, 2, 0, 0, 3, 2, 10, FIX.SILVERARROW); }
            if (race == RaceType.Angel && type == UnitType.Sorcerer)  { SetupProperty(race, type, FIX.ANGEL_HOLYEYE,   14,  4, 1, 10,  9,  4, 4, 2, 0, 0, 1, 2, 10, FIX.HOLYBULLET); }
            if (race == RaceType.Angel && type == UnitType.Enchanter) { SetupProperty(race, type, FIX.ANGEL_QUPID,     10,  3, 1,  9,  6,  2, 3, 1, 0, 0, 2, 2, 10, FIX.PROTECTION); }
            if (race == RaceType.Angel && type == UnitType.Priest)    { SetupProperty(race, type, FIX.ANGEL_ANGEL,     12,  2, 1,  6,  8,  3, 3, 1, 6, 2, 0, 0, 10, FIX.FRESHHEAL); }
            // ���쑰
            if (race == RaceType.Fire && type == UnitType.Fighter)    { SetupProperty(race, type, FIX.FIRE_SALAMANDER, 22, 13, 2,  7,  1,  1, 4, 1, 0, 0, 3, 0, 10, FIX.FIREBLADE); } 
            if (race == RaceType.Fire && type == UnitType.Archer)     { SetupProperty(race, type, FIX.FIRE_FLAMEBIRD,  18,  9, 1, 10,  1,  2, 3, 1, 0, 0, 3, 1, 10, FIX.LAVAWALL); }
            if (race == RaceType.Fire && type == UnitType.Sorcerer)   { SetupProperty(race, type, FIX.FIRE_EFREET,     14,  5, 1, 12, 12,  2, 4, 2, 0, 0, 5, 3, 10, FIX.BLAZE); }
            if (race == RaceType.Fire && type == UnitType.Enchanter)  { SetupProperty(race, type, FIX.FIRE_ELEMENTAL,  12,  8, 1,  8,  8,  1, 4, 2, 0, 0, 5, 1, 10, FIX.HEATBOOST); }
            if (race == RaceType.Fire && type == UnitType.Priest)     { SetupProperty(race, type, FIX.FIRE_REDBOMB,     8,  4, 1,  5,  4,  5, 3, 1, 0, 0,25, 1, 10, FIX.EXPLOSION); }

            if (race == RaceType.Fire && type == UnitType.Wall)       { SetupProperty(race, type, FIX.OBJ_LAVAWALL,    99,  0, 0,  0,  0,  0, 0, 0, 0, 0, 0, 0,  0, FIX.NONE); }

        }

        private void SetupProperty(RaceType race, UnitType type, string unitName, int maxLife, int attack, int def, int spd, int mag, int mdf, int move, int range, int heal, int healRange, int effect, int effectRange, int cost, string skill)
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
            this.HealValue = heal;
            this.EffectValue = effect;
            this.EffectRange = effectRange;
            this.HealRange = healRange;
            this.MovePoint = move;
            this.Cost = cost;
            this.SkillName = skill;

            this.CurrentLife = this.MaxLife;
            this.CurrentTime = 100 - this.Speed;
            this.CurrentMovePoint = this.MovePoint;
            this.ActionComplete = false;
            this.Dead = false;
        }

        public void Completed()
        {
            this.ActionComplete = true;
            this.CurrentTime = 100 - this.Speed;
            Debug.Log("Completed: " + this.CurrentTime.ToString());
            this.GetComponent<MeshRenderer>().material = Resources.Load("Complete") as Material;
        }

        public void CleanUp()
        {
            this.ActionComplete = false;
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
                this.currentLife += 3;
            }
            // todo healingWord
        }

        private void CountDown(ref int value)
        {
            if (value > 0) { value--; }
        }

        public bool IsCompleted
        {
            get { return this.ActionComplete; }
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

        /// <summary>
        /// �����I�ȍU���͂��擾���܂��B
        /// </summary>
        public int AttackValue
        {
            get { return this.Attack + this.CurrentPowerWord + this.CurrentFireBlade; }
        }

        /// <summary>
        /// �����I�Ȗh��͂��擾���܂��B
        /// </summary>
        public int DefenseValue
        {
            get { return this.Defense + this.CurrentProtection; }
        }

        /// <summary>
        /// �����I�Ȗ��@�U���͂��擾���܂��B
        /// </summary>
        public int MagicAttackValue
        {
            get { return this.MagicAttack; }
        }

        /// <summary>
        /// �����I�Ȗ��@�h��͂��擾���܂��B
        /// </summary>
        public int MagicDefenseValue
        {
            get { return this.MagicDefense; }
        }

        /// <summary>
        /// �����I�ȑ��x���擾���܂��B
        /// </summary>
        public int SpeedValue
        {
            get { return this.Speed; }
        }

        /// <summary>
        ///  �����I�Ȉړ��ʂ��擾���܂��B
        /// </summary>
        public int MoveValue
        {
            get { return this.MovePoint; }
        }

        /// <summary>
        /// ��s�\�ȃ��j�b�g���ǂ������ʂ��܂��B(true�Ȃ��s�\)
        /// </summary>
        /// <returns></returns>
        public bool IsFlying()
        {
            // ���ł͂��ׂĒn�テ�j�b�g�Ƃ���B
            return false;
        }

        /// <summary>
        /// �������w�肵�āA�אڂ���ʒu�����擾���܂��B
        /// </summary>
        /// <param name="direction"></param>
        /// <returns></returns>
        public Vector3 GetNeighborhood(FIX.Direction direction)
        {
            if (direction == FIX.Direction.Top)
            {
                return new Vector3(this.transform.localPosition.x - FIX.HEX_MOVE_X, this.transform.localPosition.y, this.transform.localPosition.z);
            }
            else if (direction == FIX.Direction.TopRight)
            {
                return new Vector3(this.transform.localPosition.x - FIX.HEX_MOVE_X2, this.transform.localPosition.y, this.transform.localPosition.z + FIX.HEX_MOVE_Z);
            }
            else if (direction == FIX.Direction.BottomRight)
            {
                return new Vector3(this.transform.localPosition.x + FIX.HEX_MOVE_X2, this.transform.localPosition.y, this.transform.localPosition.z + FIX.HEX_MOVE_Z);
            }
            else if (direction == FIX.Direction.TopLeft)
            {
                return new Vector3(this.transform.localPosition.x - FIX.HEX_MOVE_X2, this.transform.localPosition.y, this.transform.localPosition.z - FIX.HEX_MOVE_Z);
            }
            else if (direction == FIX.Direction.BottomLeft)
            {
                return new Vector3(this.transform.localPosition.x + FIX.HEX_MOVE_X2, this.transform.localPosition.y, this.transform.localPosition.z - FIX.HEX_MOVE_Z);
            }
            else if (direction == FIX.Direction.Bottom)
            {
                return new Vector3(this.transform.localPosition.x + FIX.HEX_MOVE_X, this.transform.localPosition.y, this.transform.localPosition.z);
            }

            // same as Top
            return new Vector3(this.transform.localPosition.x - FIX.HEX_MOVE_X, this.transform.localPosition.y, this.transform.localPosition.z);
        }

        /// <summary>
        /// �������w�肵�āA���j�b�g���ړ����܂��B
        /// </summary>
        /// <param name="direction"></param>
        public void Move(FIX.Direction direction)
        {
            if (direction == (int)(FIX.Direction.Top))
            {
                this.transform.localPosition = new Vector3(this.transform.localPosition.x - FIX.HEX_MOVE_X, this.transform.localPosition.y, this.transform.localPosition.z);
            }
            else if (direction == FIX.Direction.TopRight)
            {
                this.transform.localPosition = new Vector3(this.transform.localPosition.x - FIX.HEX_MOVE_X2, this.transform.localPosition.y, this.transform.localPosition.z + FIX.HEX_MOVE_Z);
            }
            else if (direction == FIX.Direction.BottomRight)
            {
                this.transform.localPosition = new Vector3(this.transform.localPosition.x + FIX.HEX_MOVE_X2, this.transform.localPosition.y, this.transform.localPosition.z + FIX.HEX_MOVE_Z);
            }
            else if (direction == FIX.Direction.TopLeft)
            {
                this.transform.localPosition = new Vector3(this.transform.localPosition.x - FIX.HEX_MOVE_X2, this.transform.localPosition.y, this.transform.localPosition.z - FIX.HEX_MOVE_Z);
            }
            else if (direction == FIX.Direction.BottomLeft)
            {
                this.transform.localPosition = new Vector3(this.transform.localPosition.x + FIX.HEX_MOVE_X2, this.transform.localPosition.y, this.transform.localPosition.z - FIX.HEX_MOVE_Z);
            }
            else if (direction == FIX.Direction.Bottom)
            {
                this.transform.localPosition = new Vector3(this.transform.localPosition.x + FIX.HEX_MOVE_X, this.transform.localPosition.y, this.transform.localPosition.z);
            }
        }

        public static int Compare(Unit a, Unit b)
        {
            if (a.CurrentTime > b.CurrentTime) { return 1; }
            else if (a.CurrentTime == b.CurrentTime) { return 0; }
            else { return -1; }
        }
    }
}