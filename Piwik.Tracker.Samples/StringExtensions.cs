using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Piwik.Tracker.Samples
{
    public static class StringExtensions
    {
        public static string RandomString(this string str, int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
