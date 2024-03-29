﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using Microsoft.DirectX.DirectDraw;
using Microsoft.DirectX.DirectInput;

namespace MinecraftEd
{
    public static class ChankGenerator
    {
        public const int CHANK_MAX_UP_BLOCKS = 256;

        public enum GeneratorKey
        {
            Flat = 0
        };

        public static ArrayList chanks = new ArrayList();
        public static Vector2[][] chanksRootToPlayer = null;
        public static int chankCount = 0;

        public class Chank
        {
            public int chankID = 0;
            public string chankName = "chank_0";
            public Vector2 chankWorldPosition = new Vector2();
            public byte[][][] chankArray = null;
        }

        public static float Distance(float a, float b) { return Math.Abs(b - a); }
        public static float VectorDistance(Vector3 a, Vector3 b) {
            return (float)Math.Sqrt((b.X - a.X) * (b.X - a.X) + (b.Y - a.Y) * (b.Y - a.Y) + (b.Z - a.Z) * (b.Z - a.Z)); }
        public static void CreateChanksAroundArray()
        {
            for (int i = 0; i < chanks.Count; i++)
            {
                //if (((Chank)chanks[i]).chankWorldPosition)
            }
            //PlayerMoving.playerWorldPosition;
        }

        private static Chank chank = new Chank();
        private static GeneratorKey keyg = GeneratorKey.Flat;
        public static void CreateChank(Vector2 chankWorldPosition, GeneratorKey generatorKey)
        {
            keyg = generatorKey;
            chank.chankID = chankCount; chankCount++;
            chank.chankName = "chank_" + chank.chankID;
            chank.chankWorldPosition = chankWorldPosition;

            InitializeArray();
            PasteBlocksToArray();
            chanks.Add(chank);

            MeshBuilder.CreateChankMesh(chank);
            EditBlocksCollisions.InitializeCollisions();
        }

        private static void PasteBlocksToArray()
        {
            if (keyg == GeneratorKey.Flat)
            {
                for (int Y = 0; Y < CHANK_MAX_UP_BLOCKS / 4; Y++) //to 64 plane
                {
                    if (Y < 64)
                        for (int Z = 0; Z < 16; Z++)
                            for (int X = 0; X < 16; X++) chank.chankArray[Y][Z][X] = (byte)4;
                    if (Y > 59 && Y < 63)
                        for (int Z = 0; Z < 16; Z++)
                            for (int X = 0; X < 16; X++) chank.chankArray[Y][Z][X] = (byte)3;
                    if (Y == 63)
                        for (int Z = 0; Z < 16; Z++)
                            for (int X = 0; X < 16; X++) chank.chankArray[Y][Z][X] = (byte)2;
                }
            }
        }

        private static void InitializeArray()
        {
            chank.chankArray = new byte[CHANK_MAX_UP_BLOCKS][][];
            for (int Y = 0; Y < CHANK_MAX_UP_BLOCKS; Y++)
            {
                chank.chankArray[Y] = new byte[16][];
                for (int Z = 0; Z < 16; Z++)
                {
                    chank.chankArray[Y][Z] = new byte[16];
                    for (int X = 0; X < 16; X++) chank.chankArray[Y][Z][X] = (byte)0;
                }
            }
        }

    }
}
