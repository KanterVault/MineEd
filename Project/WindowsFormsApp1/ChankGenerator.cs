using System;
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

namespace WindowsFormsApp1
{
    public static class ChankGenerator
    {
        const int CHANK_MAX_UP_BLOCKS = 256;

        public enum GeneratorKey
        {
            Flat = 0
        };

        public static ArrayList chanks = new ArrayList();
        public static int chankCount = 0;

        public class Chank
        {
            public int chankID = 0;
            public string chankName = "chank_0";
            public Vector2 chankWorldPosition = new Vector2();
            public byte[][][] chankArray = null;
        }

        public static void CreateChank(Vector2 chankWorldPosition, GeneratorKey generatorKey)
        {
            Chank chank = new Chank();
            chank.chankID = chankCount; chankCount++;
            chank.chankName = "chank_" + chank.chankID;
            chank.chankWorldPosition = chankWorldPosition;

            InitializeArray();
            PasteBlocksToArray();

            chanks.Add(chank);
            MessageBox.Show("Чанк создан!");

            

            void PasteBlocksToArray()
            {
                if (generatorKey == GeneratorKey.Flat)
                {
                    for (int y = 0; y < CHANK_MAX_UP_BLOCKS / 8; y++)
                        for (int z = 0; z < 16; z++)
                            for (int x = 0; x < 16; x++) chank.chankArray[y][z][x] = (byte)1;
                }
            }

            void InitializeArray()
            {
                chank.chankArray = new byte[CHANK_MAX_UP_BLOCKS][][];
                for (int y = 0; y < CHANK_MAX_UP_BLOCKS; y++)
                {
                    chank.chankArray[y] = new byte[16][];
                    for (int z = 0; z < 16; z++)
                    {
                        chank.chankArray[y][z] = new byte[16];
                        for (int x = 0; x < 16; x++) chank.chankArray[y][z][x] = (byte)0;
                    }
                }
            }

        }
    }
}
