﻿// Problem 7. Encode/decode

/*  Write a program that encodes and decodes a string using given encryption key (cipher).
    The key consists of a sequence of characters.
    The encoding/decoding is done by performing XOR (exclusive or) operation over the first 
 * letter of the string with the first of the key, the second – with the second, etc. When the 
 * last key character is reached, the next is the first.
 */

using System;
using System.Text;

class EncodeDecode
{
    static void Main()
    {
        // input string
        Console.Write("Please, enter a string: ");
        string word = Console.ReadLine();

        // input key
        Console.Write("Please, enter a KEY (sequence of random characters without spaces): ");
        string key = Console.ReadLine();

        // applying the Encrypt/Decrypt methods and printing
        Console.WriteLine("\nEncryption: {0}", Encrypt(word, key));
        Console.WriteLine("\nDecryption: {0}\n", Decrypt(Encrypt(word, key), key));
    }

    // string to key-sequence
    static string Encrypt(string word, string key)
    {
        StringBuilder cipher = new StringBuilder();
        for (int i = 0; i < word.Length; i++)
            cipher.Append((char)(word[i] ^ key[i % key.Length]));
        return cipher.ToString();
    }

    // key-sequence back to string
    static string Decrypt(string word, string key)
    {
        return Encrypt(word, key);
    }
}

