import java.util.*;
import java.lang.*;

class Program
{


	public static String convert(String s, int nRows) {
	if (nRows == 1)
		return s;

	// each unit
	int amountInUnit = nRows + nRows - 2;
	int totalUnits = s.length()/ amountInUnit;
	if (s.length() % amountInUnit != 0)
		totalUnits++;

	// each unit is a rectangle
	int rows = nRows;
	int cols = totalUnits * (nRows - 1);
	char[][] map = new char[rows][cols];

	int i = 0;
	while (i < s.length()) {
		char ch = s.charAt(i);

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
		map[x][y] = ch;

		i++;

	} // while

	// iterate and output
	StringBuilder sb = new StringBuilder();
	for (i = 0; i < rows; i++) {
		for (int j = 0; j < cols; j++) {
			if (map[i][j] != 0)
				sb.append(map[i][j]);
		}
	}
	return sb.toString();
}

	public static void main(String[] args)
	{
		System.out.println(convert("PAYPALISHIRING", 4));//"PINALSIGYAHRPI"
		System.out.println(convert("PAYPALISHIRING", 3));//"PAHNAPLSIIGYIR"
		System.out.println();



	}
}
