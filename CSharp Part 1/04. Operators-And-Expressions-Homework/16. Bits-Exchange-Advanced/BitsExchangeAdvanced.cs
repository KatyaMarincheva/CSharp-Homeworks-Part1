﻿// Problem 16.** Bit Exchange (Advanced)

/*Write a program that exchanges bits {p, p+1, …, p+k-1} with bits {q, q+1, …, q+k-1} of a given 32-bit unsigned integer.
    The first and the second sequence of bits may not overlap.

Examples:
n 	            p 	q 	k 	binary representation of n 	                    binary result 	                        result
1140867093 	    3 	24 	3 	         01000100 00000000 01000000 00010101 	01000010 00000000 01000000 00100101 	1107312677
4294901775 	    24 	3 	3 	         11111111 11111111 00000000 00001111 	11111001 11111111 00000000 00111111 	4194238527
2369124121 	    2 	22 	10 	         10001101 00110101 11110111 00011001 	01110001 10110101 11111000 11010001 	1907751121
987654321 	    2 	8 	11 	         00111010 11011110 01101000 10110001 	            - 	                        overlapping
123456789 	    26 	0 	7 	         00000111 01011011 11001101 00010101 	            - 	                        out of range
33333333333 	-1 	0 	33 	00000111 11000010 11010010 01001101 01010101 	            - 	                        out of range  */

using System;

class BitsExchangeAdvanced
{
    static void Main()
    {
        Console.SetWindowSize(80, 20);
        Console.SetBufferSize(80, 146);

        string inputN;
        uint n;

        string inputQ;
        int q;

        string inputK;
        int k;

        string inputP;
        int p;

        // the homework instruction asks for manipulations on "unsigned integer" (uint)
        // direct calculations with uint n and (1 << position) (1 is per default an int)
        // cause castting errors
        uint one = 1;

        string intro =
    @"This program exchanges bits {p, p+1, …, p+k-1} 
with bits {q, q+1, …, q+k-1} 
of a given 32-bit unsigned integer.";

        Console.WriteLine(intro);

        do  // validates input for n
        {
            Console.Write("\nPlease enter an uint value for n: ");
            inputN = Console.ReadLine();

        } while (!uint.TryParse(inputN, out n));

        do  // validates input for p
        {
            Console.Write("\nPlease enter a value for p (p < 0 || p > 32): ");
            inputP = Console.ReadLine(); ;

        } while (!int.TryParse(inputP, out p) || p < 0 || p > 32);

        do  // validates input for q
        {
            Console.Write("\nPlease enter a value for q (q > 0 || q < 32 || q != p): ");
            inputQ = Console.ReadLine();

        } while (!int.TryParse(inputQ, out q) || q < 0 || q > 32 || q == p);

        // validates input for k
        // (k < |p-q|) -> no overlapping between first and second position
        // (k < 1) || (k > (32 - q)) || (k > (32 - p)) -> no out of range
        do  
        {
            Console.Write("\nPlease enter a value for  k (k < |p-q|); (k < (32 - q); (k < (32 - p)): ");
            inputK = Console.ReadLine();

        } while (!int.TryParse(inputK, out k) || (k < 1) || (k > (32 - q)) || (k > Math.Abs(p - q)) || (k > (32 - p)));



        // prints initial n as binary, table view
        Console.WriteLine("\n{0,-16} {1,32}", "Initial n:", Convert.ToString(n, 2).PadLeft(32, '0'));

        // loops over i-positions and j-positions, limit: j <= (q + k - 1) 
        for (int i = p, j = q; j <= (q + k - 1); i++, j++)
        {
            // checks if bit values at i- and j-positions are different
            if (((n >> i) & 1) != ((n >> j) & 1))
            {
                // if bit values at i- and j-positions are different, 
                n = n ^ (one << i); // swaps bit value at position i
                n = n ^ (one << j); // swaps bit value at position j
            }
        }
        // prints final n and n as binary, table view
        Console.WriteLine("\n{0, -16} {1, 32}", "Final n:", Convert.ToString(n, 2).PadLeft(32, '0'));
        Console.WriteLine("\n{0, -16} {1}\n", "Final n dec.:", n);
    }
}

