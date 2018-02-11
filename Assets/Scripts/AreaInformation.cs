using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace ObsidianPortal
{
    public class AreaInformation : MonoBehaviour
    {
        public enum Field
        {
            None = 0,
            Plain,
            Forest,
            Sea,
            Mountain,
            Wall,
        }
        public Field field = Field.Plain;

        public int MoveCost
        {
            get
            {
                if (field == Field.Plain) { return 1; }
                if (field == Field.Forest) { return 2; }
                if (field == Field.Mountain) { return 999; }
                if (field == Field.None) { return 999; }
                if (field == Field.Wall) { return 999; }
                return 999;
            }
        }
        //public static int GYOU = 17;  // 横のタイル量
        //public static int RETU = 10;  // 縦のタイル量
        //public static int IPPEN = 40; // タイル一辺の長さ
        //public static int TOTAL = GYOU * RETU; //総合タイル量

        //public Point[] TILEPT;//タイルの位置
        //public Rectangle[] rects; // タイルを示す四角形
        //public string[] attr;//地形属性文字列
        //public int[] moveable;//移動消費歩数
        //public Bitmap[] currentPlane; // 使用するビットマップ

        //public Bitmap normalPlane;
        //public Bitmap deepPlane;
        //public Bitmap wallPlane;
        //public Bitmap mountainPlane;
        //public Bitmap riverPlane;
        //public Bitmap bridgePlane;
        //public Bitmap castlePlane;

        //public AreaInformation()
        //{
        //    attr = new string[GYOU * RETU];
        //    moveable = new int[GYOU * RETU];

        //    normalPlane = new Bitmap("normal2.jpg");
        //    deepPlane = new Bitmap("deep.jpg");
        //    wallPlane = new Bitmap("wall.jpg");
        //    riverPlane = new Bitmap("river.jpg");
        //    bridgePlane = new Bitmap("bridge.jpg");
        //    castlePlane = new Bitmap("castle.jpg");
        //    mountainPlane = new Bitmap("mountain.jpg");

        //    TILEPT = new Point[TOTAL];
        //    rects = new Rectangle[GYOU * RETU];
        //    for (int i = 0; i < GYOU * RETU; i++)
        //    {
        //        int amari = i % GYOU;
        //        TILEPT[i] = new Point(IPPEN * amari, i / GYOU * IPPEN);
        //        rects[i] = new Rectangle(TILEPT[i].X, TILEPT[i].Y, IPPEN, IPPEN);
        //    }

        //    // マップ情報をここから具体的に記載する。
        //    // XML情報などで制御できるようにするべきである。
        //    currentPlane = new Bitmap[TOTAL];
        //    SetNormalInformation(0);
        //    SetNormalInformation(1);
        //    SetNormalInformation(2);
        //    SetNormalInformation(3);
        //    SetNormalInformation(4);
        //    SetNormalInformation(5);
        //    SetNormalInformation(6);
        //    SetRiverInformation(7);
        //    SetRiverInformation(8);
        //    SetRiverInformation(9);
        //    SetNormalInformation(10);
        //    SetNormalInformation(11);
        //    SetNormalInformation(12);
        //    SetNormalInformation(13);
        //    SetNormalInformation(14);
        //    SetNormalInformation(15);
        //    SetNormalInformation(16);

        //    SetCastleInformation(0 + GYOU);
        //    SetNormalInformation(1 + GYOU);
        //    SetNormalInformation(2 + GYOU);
        //    SetNormalInformation(3 + GYOU);
        //    SetMountainInformation(4 + GYOU);
        //    SetNormalInformation(5 + GYOU);
        //    SetNormalInformation(6 + GYOU);
        //    SetWallInformation(7 + GYOU);
        //    SetRiverInformation(8 + GYOU);
        //    SetRiverInformation(9 + GYOU);
        //    SetNormalInformation(10 + GYOU);
        //    SetNormalInformation(11 + GYOU);
        //    SetNormalInformation(12 + GYOU);
        //    SetNormalInformation(13 + GYOU);
        //    SetNormalInformation(14 + GYOU);
        //    SetNormalInformation(15 + GYOU);
        //    SetNormalInformation(16 + GYOU);

        //    SetNormalInformation(0 + GYOU * 2);
        //    SetNormalInformation(1 + GYOU * 2);
        //    SetNormalInformation(2 + GYOU * 2);
        //    SetMountainInformation(3 + GYOU * 2);
        //    SetNormalInformation(4 + GYOU * 2);
        //    SetNormalInformation(5 + GYOU * 2);
        //    SetNormalInformation(6 + GYOU * 2);
        //    SetWallInformation(7 + GYOU * 2);
        //    SetRiverInformation(8 + GYOU * 2);
        //    SetRiverInformation(9 + GYOU * 2);
        //    SetNormalInformation(10 + GYOU * 2);
        //    SetNormalInformation(11 + GYOU * 2);
        //    SetNormalInformation(12 + GYOU * 2);
        //    SetNormalInformation(13 + GYOU * 2);
        //    SetNormalInformation(14 + GYOU * 2);
        //    SetNormalInformation(15 + GYOU * 2);
        //    SetNormalInformation(16 + GYOU * 2);

        //    SetNormalInformation(0 + GYOU * 3);
        //    SetNormalInformation(1 + GYOU * 3);
        //    SetNormalInformation(2 + GYOU * 3);
        //    SetMountainInformation(3 + GYOU * 3);
        //    SetNormalInformation(4 + GYOU * 3);
        //    SetNormalInformation(5 + GYOU * 3);
        //    SetNormalInformation(6 + GYOU * 3);
        //    SetWallInformation(7 + GYOU * 3);
        //    SetRiverInformation(8 + GYOU * 3);
        //    SetRiverInformation(9 + GYOU * 3);
        //    SetNormalInformation(10 + GYOU * 3);
        //    SetNormalInformation(11 + GYOU * 3);
        //    SetNormalInformation(12 + GYOU * 3);
        //    SetNormalInformation(13 + GYOU * 3);
        //    SetNormalInformation(14 + GYOU * 3);
        //    SetNormalInformation(15 + GYOU * 3);
        //    SetNormalInformation(16 + GYOU * 3);

        //    SetNormalInformation(0 + GYOU * 4);
        //    SetNormalInformation(1 + GYOU * 4);
        //    SetNormalInformation(2 + GYOU * 4);
        //    SetNormalInformation(3 + GYOU * 4);
        //    SetNormalInformation(4 + GYOU * 4);
        //    SetNormalInformation(5 + GYOU * 4);
        //    SetNormalInformation(6 + GYOU * 4);
        //    SetBridgeInformation(7 + GYOU * 4);
        //    SetBridgeInformation(8 + GYOU * 4);
        //    SetBridgeInformation(9 + GYOU * 4);
        //    SetNormalInformation(10 + GYOU * 4);
        //    SetNormalInformation(11 + GYOU * 4);
        //    SetNormalInformation(12 + GYOU * 4);
        //    SetNormalInformation(13 + GYOU * 4);
        //    SetNormalInformation(14 + GYOU * 4);
        //    SetNormalInformation(15 + GYOU * 4);
        //    SetNormalInformation(16 + GYOU * 4);

        //    SetNormalInformation(0 + GYOU * 5);
        //    SetNormalInformation(1 + GYOU * 5);
        //    SetNormalInformation(2 + GYOU * 5);
        //    SetNormalInformation(3 + GYOU * 5);
        //    SetNormalInformation(4 + GYOU * 5);
        //    SetNormalInformation(5 + GYOU * 5);
        //    SetNormalInformation(6 + GYOU * 5);
        //    SetBridgeInformation(7 + GYOU * 5);
        //    SetBridgeInformation(8 + GYOU * 5);
        //    SetBridgeInformation(9 + GYOU * 5);
        //    SetNormalInformation(10 + GYOU * 5);
        //    SetNormalInformation(11 + GYOU * 5);
        //    SetNormalInformation(12 + GYOU * 5);
        //    SetNormalInformation(13 + GYOU * 5);
        //    SetNormalInformation(14 + GYOU * 5);
        //    SetNormalInformation(15 + GYOU * 5);
        //    SetNormalInformation(16 + GYOU * 5);

        //    SetNormalInformation(0 + GYOU * 6);
        //    SetNormalInformation(1 + GYOU * 6);
        //    SetNormalInformation(2 + GYOU * 6);
        //    SetNormalInformation(3 + GYOU * 6);
        //    SetNormalInformation(4 + GYOU * 6);
        //    SetNormalInformation(5 + GYOU * 6);
        //    SetNormalInformation(6 + GYOU * 6);
        //    SetRiverInformation(7 + GYOU * 6);
        //    SetRiverInformation(8 + GYOU * 6);
        //    SetWallInformation(9 + GYOU * 6);
        //    SetNormalInformation(10 + GYOU * 6);
        //    SetNormalInformation(11 + GYOU * 6);
        //    SetNormalInformation(12 + GYOU * 6);
        //    SetMountainInformation(13 + GYOU * 6);
        //    SetNormalInformation(14 + GYOU * 6);
        //    SetNormalInformation(15 + GYOU * 6);
        //    SetNormalInformation(16 + GYOU * 6);

        //    SetNormalInformation(0 + GYOU * 7);
        //    SetNormalInformation(1 + GYOU * 7);
        //    SetNormalInformation(2 + GYOU * 7);
        //    SetNormalInformation(3 + GYOU * 7);
        //    SetNormalInformation(4 + GYOU * 7);
        //    SetNormalInformation(5 + GYOU * 7);
        //    SetNormalInformation(6 + GYOU * 7);
        //    SetRiverInformation(7 + GYOU * 7);
        //    SetRiverInformation(8 + GYOU * 7);
        //    SetWallInformation(9 + GYOU * 7);
        //    SetNormalInformation(10 + GYOU * 7);
        //    SetNormalInformation(11 + GYOU * 7);
        //    SetNormalInformation(12 + GYOU * 7);
        //    SetMountainInformation(13 + GYOU * 7);
        //    SetNormalInformation(14 + GYOU * 7);
        //    SetNormalInformation(15 + GYOU * 7);
        //    SetNormalInformation(16 + GYOU * 7);

        //    SetNormalInformation(0 + GYOU * 8);
        //    SetNormalInformation(1 + GYOU * 8);
        //    SetNormalInformation(2 + GYOU * 8);
        //    SetNormalInformation(3 + GYOU * 8);
        //    SetNormalInformation(4 + GYOU * 8);
        //    SetNormalInformation(5 + GYOU * 8);
        //    SetNormalInformation(6 + GYOU * 8);
        //    SetRiverInformation(7 + GYOU * 8);
        //    SetRiverInformation(8 + GYOU * 8);
        //    SetWallInformation(9 + GYOU * 8);
        //    SetNormalInformation(10 + GYOU * 8);
        //    SetNormalInformation(11 + GYOU * 8);
        //    SetMountainInformation(12 + GYOU * 8);
        //    SetNormalInformation(13 + GYOU * 8);
        //    SetNormalInformation(14 + GYOU * 8);
        //    SetNormalInformation(15 + GYOU * 8);
        //    SetCastleInformation(16 + GYOU * 8);

        //    SetNormalInformation(0 + GYOU * 9);
        //    SetNormalInformation(1 + GYOU * 9);
        //    SetNormalInformation(2 + GYOU * 9);
        //    SetNormalInformation(3 + GYOU * 9);
        //    SetNormalInformation(4 + GYOU * 9);
        //    SetNormalInformation(5 + GYOU * 9);
        //    SetNormalInformation(6 + GYOU * 9);
        //    SetRiverInformation(7 + GYOU * 9);
        //    SetRiverInformation(8 + GYOU * 9);
        //    SetRiverInformation(9 + GYOU * 9);
        //    SetNormalInformation(10 + GYOU * 9);
        //    SetNormalInformation(11 + GYOU * 9);
        //    SetNormalInformation(12 + GYOU * 9);
        //    SetNormalInformation(13 + GYOU * 9);
        //    SetNormalInformation(14 + GYOU * 9);
        //    SetNormalInformation(15 + GYOU * 9);
        //    SetNormalInformation(16 + GYOU * 9);
        //}

        //private void SetNormalInformation(int num)
        //{
        //    attr[num] = "normal";
        //    moveable[num] = 1;
        //    currentPlane[num] = new Bitmap(normalPlane);
        //}

        //private void SetDeepInformation(int num)
        //{
        //    attr[num] = "deep";
        //    moveable[num] = 2;
        //    currentPlane[num] = new Bitmap(deepPlane);
        //}

        //private void SetWallInformation(int num)
        //{
        //    attr[num] = "wall";
        //    moveable[num] = 999;
        //    currentPlane[num] = new Bitmap(wallPlane);
        //}

        //private void SetRiverInformation(int num)
        //{
        //    attr[num] = "river";
        //    moveable[num] = 3;
        //    currentPlane[num] = new Bitmap(riverPlane);
        //}

        //private void SetBridgeInformation(int num)
        //{
        //    attr[num] = "bridge";
        //    moveable[num] = 1;
        //    currentPlane[num] = new Bitmap(bridgePlane);
        //}

        //private void SetCastleInformation(int num)
        //{
        //    attr[num] = "castle";
        //    moveable[num] = 1;
        //    currentPlane[num] = new Bitmap(castlePlane);
        //}

        //private void SetMountainInformation(int num)
        //{
        //    attr[num] = "mountain";
        //    moveable[num] = 4;
        //    currentPlane[num] = new Bitmap(mountainPlane);
        //}
    }
}