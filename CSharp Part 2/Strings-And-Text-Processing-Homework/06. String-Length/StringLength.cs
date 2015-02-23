﻿// Problem 6. String length

/* Write a program that reads from the console a string of maximum 20 characters. 
 * If the length of the string is less than 20, the rest of the characters should be filled with *.
    Print the result string into the console.
 */

using System;

class StringLength
{
    static void Main()
    {
        string input = "";

        while (input.Length > 20 || input.Length == 0)
        {
            // input
            Console.WriteLine("Please, enter a string which is no more than 20 chars long: ");
            input = Console.ReadLine();

            // supplementing and printing
            Console.WriteLine(input.PadRight(20, '*'));
        }
    }
}

