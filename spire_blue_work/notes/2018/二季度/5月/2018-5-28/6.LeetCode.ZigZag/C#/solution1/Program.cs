using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zigzag
{
    class Program
    {


        public static String convert(String s, int nRows) {
        if (nRows == 1)
            return s;
 
        // each unit
        int amountInUnit = nRows + nRows - 2;
        int totalUnits = s.Length/ amountInUnit;
        if (s.Length % amountInUnit != 0)
            totalUnits++;
 
        // each unit is a rectangle
        int rows = nRows;
        int cols = totalUnits * (nRows - 1);
        char[,] map = new char[rows,cols];
 
        int i = 0;
        while (i < s.Length) {
            char ch = s[i];
 
            // which unit, starts from 0
            int unitNumber = i / amountInUnit;
 
            // which postion in the unit, starts from 0
            int posInUnit = i % (amountInUnit);
 
            // if it's in the first column of the unit
            int x, y;
            if (posInUnit < nRows) {
                x = posInUnit;
                y = unitNumber * (nRows - 1);
            } else {
                x = nRows - 1 - (posInUnit + 1 - nRows);
                y = nRows - x - 1 + unitNumber * (nRows - 1);
            }
            map[x,y] = ch;
 
            i++;
 
        } // while
 
        // iterate and output
        StringBuilder sb = new StringBuilder();
        for (i = 0; i < rows; i++) {
            for (int j = 0; j < cols; j++) {
                if (map[i,j] != 0)
                    sb.Append(map[i,j]);
            }
        }
        return sb.ToString();
    }

        static void Main(string[] args)
        {
            Console.WriteLine(convert("PAYPALISHIRING", 4));//"PINALSIGYAHRPI"
            Console.WriteLine(convert("PAYPALISHIRING", 3));//"PAHNAPLSIIGYIR"
            Console.ReadKey();



        }
    }
}
