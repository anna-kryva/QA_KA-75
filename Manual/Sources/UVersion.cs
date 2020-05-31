using System;

namespace Tasks
{
    public static class UVersion
    {
        public static int CompareVersions(string v1, string v2)
        {
            var versions1 = v1.Split('.');
            var versions2 = v2.Split('.');

            var len1 = versions1.Length;
            var len2 = versions2.Length;
            var max_len = Math.Max(len1, len2);

            for (int i = 0; i < max_len; ++i)
            {
                var fst = i < len1 ? int.Parse(versions1[i]) : 0;
                var snd = i < len2 ? int.Parse(versions2[i]) : 0;

                if (fst > snd) return 1;
                if (fst < snd) return -1;
            }

            return 0;
        }
    }
}
