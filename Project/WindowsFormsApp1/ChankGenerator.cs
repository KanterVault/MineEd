using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsFormsApp1
{
    public static class ChankGenerator
    {
        public static byte[][][][][] chank = null; //[yc10][xc10][y256][z16][x16]

        public static void InitializeArray()
        {
            chank = new byte[10][][][][];
            for (int yc = 0; yc < 10; yc++)
            {
                chank[yc] = new byte[10][][][];
                for (int xc = 0; xc < 10; xc++)
                {
                    chank[yc][xc] = new byte[256][][];
                    for (int y = 0; y < 256; y++)
                    {
                        chank[yc][xc][y] = new byte[16][];
                        for (int z = 0; z < 16; z++)
                        {
                            chank[yc][xc][y][z] = new byte[16];
                            for (int x = 0; x < 16; x++)
                            {
                                chank[yc][xc][y][z][x] = (byte)0;
                            }
                        }
                    }
                }
            }
        }


    }
}
