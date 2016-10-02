
namespace Telerik.ILS.Common
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;
   
    /// <summary>
    /// This class contains methods for string manipulation.
    /// </summary>

    public static class StringExtensions
    {
        /// <summary>
        /// This method performs string convertion of the input string to a hash.
        /// </summary>
        /// <return> Hash is in format hexadecimal string.</return>

        public static string ToMd5Hash(this string input)
        {
            var md5Hash = MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new StringBuilder to collect the bytes
            // and create a string.
            var builder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                builder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return builder.ToString();
        }

        /// <summary>
        /// This method checks, if string contains any of the given string array elements.
        /// </summary>
        /// <return> True, if the string contains any of the given string array elements
        /// and False, if it does not contain </return>

        public static bool ToBoolean(this string input)
        {
            var stringTrueValues = new[] { "true", "ok", "yes", "1", "да" };

            // Check if the created array contains the given string
            return stringTrueValues.Contains(input.ToLower());
        }

        /// <summary>
        /// This method checks, if string is valid short number.
        /// </summary>
        /// <return> String in format short, if it is valid short number. </return>

        public static short ToShort(this string input)
        {
            short shortValue;

            // Check if the input string is a valid short number and parse it to a short variable.
            short.TryParse(input, out shortValue);

            // if the string is a valid short number, it will be set to the variable shortValue. 
            return shortValue;
        }

        /// <summary>
        /// This method checks, if string is valid int number.
        /// </summary>
        /// <return> String in format int, if it is valid int number. </return>
        
        public static int ToInteger(this string input)
        {
            int integerValue;

            // Check if the input string is a valid integer number and parse it to an integer variable.
            int.TryParse(input, out integerValue);

            // if the string is a valid integer number, it will be set to the variable. 
            return integerValue;
        }

        /// <summary>
        /// This method checks, if string is valid long number.
        /// </summary>
        /// <return> String in format long, if it is valid long number. </return>

        public static long ToLong(this string input)
        {
            long longValue;

            // Check if the input string is a valid long number and parse it to a long variable.
            long.TryParse(input, out longValue);

            // if the string is a valid long number, it will be set to the variable. 
            return longValue;
        }

        /// <summary>
        /// This method checks, if string is valid DateTime.
        /// </summary>
        /// <return> String in format DateTime, if it is valid DateTime value. </return>
         
        public static DateTime ToDateTime(this string input)
        {
            DateTime dateTimeValue;

            // Check if the input string is a valid dateTime and parse it to a dateTime variable.
            DateTime.TryParse(input, out dateTimeValue);

            // if the string is a valid dateTime, it will be set to the variable. 
            return dateTimeValue;
        }

        /// <summary>
        /// This method transforms the string's first letter to a capital letter.
        /// </summary>
        /// <return> String with first capital letter. </return>

        public static string CapitalizeFirstLetter(this string input)
        {
            // Avoid receiving System.NullReferenceException , if string is null by retutrning the string.
            // Avoid receiving System.ArgumentOutOfRangeException , if string is empty "" by retutrning the string.  
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            // Return the string input with capitalized first letter.
            return input.Substring(0, 1).ToUpper(CultureInfo.CurrentCulture) + input.Substring(1, input.Length - 1);
        }

        /// <summary>
        /// This method gets the string between two other strings.
        /// </summary>
        /// <return> 1. In case input string does not contain startString or endString , returns empty string. 
        ///         2. The string between two strings as a string.      </return> 

        public static string GetStringBetween(this string input, string startString, string endString, int startFrom = 0)
        {
            // We take the whole input string
            input = input.Substring(startFrom);
            startFrom = 0;

            // In case input string does not contain startString or endString , there is no stringBetween to return.
            if (!input.Contains(startString) || !input.Contains(endString))
            {
                return string.Empty;
            }

            // Define the first position of the stringBetween, which is the end position of startString + 1. 
            // Return empty string, if string input does not contain startString.   
            var startPosition = input.IndexOf(startString, startFrom, StringComparison.Ordinal) + startString.Length;
            if (startPosition == -1)
            {
                return string.Empty;
            }

            // Define the start position of endString. 
            // Return empty string, if string input does not contain endString.
            var endPosition = input.IndexOf(endString, startPosition, StringComparison.Ordinal);
            if (endPosition == -1)
            {
                return string.Empty;
            }

            // Calculate the lenght of string between, which is the difference between 
            // the start position of endString and the end position of startString + 1.
            // Get the stringBetween as a string. 
            return input.Substring(startPosition, endPosition - startPosition);
        }

        /// <summary>
        /// This method converts string with cyrillic letters to a string with latin letters.
        /// </summary>
        /// <param name="input"> Insert string with cyrillic letters. </param>
        /// <return> String with latin letters. </return> 

        public static string ConvertCyrillicToLatinLetters(this string input)
        {
            var bulgarianLetters = new[]
                                       {
                                           "а", "б", "в", "г", "д", "е", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п",
                                           "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ь", "ю", "я"
                                       };
            var latinRepresentationsOfBulgarianLetters = new[]
                                                             {
                                                                 "a", "b", "v", "g", "d", "e", "j", "z", "i", "y", "k",
                                                                 "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "h",
                                                                 "c", "ch", "sh", "sht", "u", "i", "yu", "ya"
                                                             };

            // Loop tours over each letter of the word and replaces it with its latin letter
            for (var i = 0; i < bulgarianLetters.Length; i++)
            {
                input = input.Replace(bulgarianLetters[i], latinRepresentationsOfBulgarianLetters[i]);
                input = input.Replace(bulgarianLetters[i].ToUpper(), latinRepresentationsOfBulgarianLetters[i].CapitalizeFirstLetter());
            }

            return input;
        }

        /// <summary>
        /// This method converts string with latin letters to a string with cyrillic letters.
        /// </summary>
        /// <param name="input"> Insert string with latin letters. </param>
        /// <return> String with cyrillic letters. </return> 

        public static string ConvertLatinToCyrillicKeyboard(this string input)
        {
            var latinLetters = new[]
                                   {
                                       "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p",
                                       "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"
                                   };

            var bulgarianRepresentationOfLatinKeyboard = new[]
                                                             {
                                                                 "а", "б", "ц", "д", "е", "ф", "г", "х", "и", "й", "к",
                                                                 "л", "м", "н", "о", "п", "я", "р", "с", "т", "у", "ж",
                                                                 "в", "ь", "ъ", "з"
                                                             };

            // Loop tours over each letter of the word and replaces it with its bulgarian letter
            for (int i = 0; i < latinLetters.Length; i++)
            {
                input = input.Replace(latinLetters[i], bulgarianRepresentationOfLatinKeyboard[i]);
                input = input.Replace(latinLetters[i].ToUpper(), bulgarianRepresentationOfLatinKeyboard[i].ToUpper());
            }

            return input;
        }

        /// <summary>
        /// This method converts string with cyrillic letters to a string with latin letters and removes all characters from the string different from "a - z", "A - Z", "0-9","_\." .
        /// </summary>
        /// <param name="input"> Insert string with cyrillic or cyrillic and latin letters,numbers and symbols. </param>
        /// <return> String with latin letters, numbers and symbols. </return> 

        public static string ToValidUsername(this string input)
        {
            // Converts the string's cyrillic letters to latin letters
            input = input.ConvertCyrillicToLatinLetters();

            // Removes all characters from the string different from "a - z", "A - Z", "0-9","_\." .
            return Regex.Replace(input, @"[^a-zA-z0-9_\.]+", string.Empty);
        }

        /// <summary>
        /// This method converts string with cyrillic letters to a string with latin letters, converts " " with "-" and removes all characters from the string different from "a - z", "A - Z", "0-9","_\." .
        /// </summary>
        /// <param name="input"> Insert string with cyrillic or cyrillic and latin letters,numbers and symbols. </param>
        /// <return> String with latin letters, numbers and symbols. </return>

        public static string ToValidLatinFileName(this string input)
        {
            // Replaces the string's " " with "-". Converts the string's cyrillic letters to latin letters.
            input = input.Replace(" ", "-").ConvertCyrillicToLatinLetters();
            
            // Removes all characters from the string different from "a - z", "A - Z", "0-9","_\.-" .
            return Regex.Replace(input, @"[^a-zA-z0-9_\.\-]+", string.Empty);
        }

        /// <summary>
        /// This method extracts substring from the string starting from the beginning of the string, the extracted substring's lenght is equal to the number inputed for the parameter charsCount.
        /// </summary>
        /// <param name="input"> Insert string. </param>
        /// <param name="charsCount"> Insert valid integer number. </param>
        /// <return> Substring with the given lenght or the whole string, if the charsCount number is bigger than string's lenght. </return>

        public static string GetFirstCharacters(this string input, int charsCount)
        {
            // Returns the number of characters equal to the number of the charsCount variable from the beginning
            // of the string. If the charsCount number is greater than the string's length, returns the whole string.  
            return input.Substring(0, Math.Min(input.Length, charsCount));
        }

        /// <summary>
        /// This method splits the string into an array of strings by dot ".".
        /// </summary>
        /// <return> 1. Returns "" empty string, if string is null, whiteSpace or the last item in the array is not a string. 
        ///          2. String with no white spaces in the beginning or the end and with lowercase letters. </return>

        public static string GetFileExtension(this string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return string.Empty;
            }
            // Splits the string into an array of strings by dot "." 
            string[] fileParts = fileName.Split(new[] { "." }, StringSplitOptions.None);
            // In case we have one item in the array or the last item in the array is not a string, returns "" empty string
            if (fileParts.Count() == 1 || string.IsNullOrEmpty(fileParts.Last()))
            {
                return string.Empty;
            }
            // Returns the last item in the array as a string with no white spaces in the beginning or the end 
            // and with lowercase letters
            return fileParts.Last().Trim().ToLower();
        }

        /// <summary>
        /// This method checks,if string's value matches with a key value from the dictionary.
        /// </summary>
        /// <return> 1. If string's value matches with a key value from the dictionary, the content from the key is returned. 
        ///          2. When no match is found the string "application/octet-stream" is returned. </return>

        public static string ToContentType(this string fileExtension)
        {
            var fileExtensionToContentType = new Dictionary<string, string>
                                                 {
                                                     { "jpg", "image/jpeg" },
                                                     { "jpeg", "image/jpeg" },
                                                     { "png", "image/x-png" },
                                                     {
                                                         "docx",
                                                         "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
                                                     },
                                                     { "doc", "application/msword" },
                                                     { "pdf", "application/pdf" },
                                                     { "txt", "text/plain" },
                                                     { "rtf", "application/rtf" }
                                                 };
            // If string's value matches with a key value from the dictionary, the content from the key is returned. 
            if (fileExtensionToContentType.ContainsKey(fileExtension.Trim()))
            {
                return fileExtensionToContentType[fileExtension.Trim()];
            }

            // When no match is found the string below is returned.

            return "application/octet-stream";
        }

        /// <summary>
        /// This method creates a byte array with number of bytes equal to input.Length * sizeof(char).
        /// </summary>
        /// <return> Byte array with the string's bytes. </return>

        public static byte[] ToByteArray(this string input)
        {
            // Create a byte array with number of bytes equal to the below expression
            var bytesArray = new byte[input.Length * sizeof(char)];

            // Copy the bytes from the string to bytesArray
            Buffer.BlockCopy(input.ToCharArray(), 0, bytesArray, 0, bytesArray.Length);
            return bytesArray;
        }
    }
}