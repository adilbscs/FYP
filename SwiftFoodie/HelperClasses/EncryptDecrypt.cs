using System;
using System.Security.Cryptography;
using System.Text;

/// <summary>
/// Summary description for EncryptDecrypt
/// </summary>
public class EncryptDecrypt
{
    #region Declarations
    public static string SPECIALCHARS = "@$*";//"#‘`$£!%&*[]/+-.?@~;:{}|=";
    public static string UPPERCASECHARS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    public static string LOWERCASECHARS = "abcdefghijklmnopqrstuvwxyz";
    public static string DIGITS = "0123456789";
    public static int MIN_ALPHA = 6;
    public static int MIN_DIGIT = 2;
    #endregion

    public EncryptDecrypt()
    {
    }

    public static string Encrypt(string toEncrypt, bool useHashing)
    {
        try
        {
            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

            string key = "Someth1ngSpeci@l";

            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                hashmd5.Clear();
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(key);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();

            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateEncryptor();

            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            tdes.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
        catch (Exception)
        {
            return null;
        }
    }

    public static string Decrypt(string cipherString, bool useHashing)
    {
        try
        {
            byte[] keyArray;
            byte[] toEncryptArray = Convert.FromBase64String(cipherString);

            string key = "Someth1ngSpeci@l";
            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                hashmd5.Clear();
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(key);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();

            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            tdes.Clear();
            return UTF8Encoding.UTF8.GetString(resultArray);
        }
        catch (Exception)
        {
            return null;
        }
    }

    #region GenerateRandomPasswordWithChars
    /// <summary>
    /// This method generates a random string comprising of characters from the specified charset.
    /// The generated string will be of the specified length.
    /// </summary>
    /// <param name="charset">A string representing the character set to use when generating a random string</param>
    /// <param name="length">The specified length that the generate string must conform to</param>
    /// <returns>A randomly generated string that is of the specified length</returns>
    public static string GenerateRandomPasswordWithChars()
    {
        string randomAlpha = GetRandomString(MIN_ALPHA - 1);
        string randomDigits = GetRandomString(DIGITS, MIN_DIGIT);
        string randomChar = GetRandomSpecialCharacters(1);
        string password = randomAlpha + randomDigits + randomChar;
        return password;
    }
    #endregion

    #region GetRandomString
    /// <summary>
    /// This method generates a random string comprising of characters from the specified charset.
    /// The generated string will be of the specified length.
    /// </summary>
    /// <param name="charset">A string representing the character set to use when generating a random string</param>
    /// <param name="length">The specified length that the generate string must conform to</param>
    /// <returns>A randomly generated string that is of the specified length</returns>
    public static string GetRandomString(string charset, int length)
    {
        //Random rnd = new Random( (Int32)DateTime.Now.TimeOfDay.TotalMilliseconds );
        Random rnd = new Random();
        StringBuilder sb = new StringBuilder(length);
        int nChars = charset.Length;
        int rndIdx;
        for (int i = 0; i < length; i++)
        {
            rndIdx = rnd.Next(nChars);
            string c = charset.Substring(rndIdx, 1);
            sb.Append(c);
        }
        return sb.ToString();
    }
    #endregion

    #region GetRandomString
    /// <summary>
    /// Utility method that uses getRandomString( string charset, int length ).
    /// This overloaded method will generate a random mix case string, that is the specified length
    /// </summary>
    /// <param name="length">The Length of the mixed case string to generate</param>
    /// <returns>A random mixed case string that is of the length specified</returns>
    public static string GetRandomString(int length)
    {
        return GetRandomString(LOWERCASECHARS + UPPERCASECHARS, length);
    }
    #endregion

    #region GetRandomSpecialCharacters
    /// <summary>
    /// Utility method that returns random string comprised of nonalphanumeric characters.
    /// </summary>
    /// <param name="length">The length of the string to generate</param>
    /// <returns>A random string of nonalphanumeric characters</returns>
    public static string GetRandomSpecialCharacters(int length)
    {
        return GetRandomString(SPECIALCHARS, length);
    }
    #endregion    

}
