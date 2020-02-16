using System;
using System.Collections.Generic;
using System.Linq;

namespace WeeklyCompetition175
{
    class Program
    {
        static void Main(string[] args)
        {
            var res1 = MinSteps("bab", "aba");
            var res5 = MinSteps("leetcode", "practice");
            var res0 = MinSteps("anagram", "mangaar");
            var res00 = MinSteps("xxyyzz", "xxyyzz");
            var res4 = MinSteps("friend", "family");
            //TweetCounts tweetCounts = new TweetCounts();
            //tweetCounts.RecordTweet("tweet3", 0);
            //tweetCounts.RecordTweet("tweet3", 60);
            //tweetCounts.RecordTweet("tweet3", 10);
            //var res2 = tweetCounts.GetTweetCountsPerFrequency("minute", "tweet3", 0, 59);
            //var res21= tweetCounts.GetTweetCountsPerFrequency("minute", "tweet3", 0, 60);
            //tweetCounts.RecordTweet("tweet3", 120);
            //var res4 = tweetCounts.GetTweetCountsPerFrequency("hour", "tweet3", 0, 210);
        }
        public static bool CheckIfExist(int[] arr)
        {
            var newarr = arr.Distinct();
            foreach (var item in newarr)
            {
                if (item == 0)
                { if( arr.Count(i => i == 0) > 1)
                    return true;
                } 
                else
                { if (newarr.Contains(2 * item))
                        return true; 
                }
            }
            return false;
        }

        public static int MinSteps(string s, string t)
        {
            if (s == t)
                return 0;
            else
            {
                Dictionary<char, int> dics = new Dictionary<char, int>();
                foreach(var ch in s)
                {
                    if (dics.ContainsKey(ch))
                        dics[ch] += 1;
                    else
                        dics.Add(ch, 1);
                }

                Dictionary<char, int> dict = new Dictionary<char, int>();
                foreach (var ch in t)
                {
                    if (dict.ContainsKey(ch))
                        dict[ch] += 1;
                    else
                        dict.Add(ch, 1);
                }

                var same = 0;
                foreach(var key in dics.Keys.Union(dict.Keys).Distinct())
                {
                    var vs = 0;
                    dics.TryGetValue(key, out vs);
                    var vt = 0;
                    dict.TryGetValue(key, out vt);
                    same += Math.Min(vs,vt);
                }


                return s.Length-same;
            }
        }
    }

    public class TweetCounts
    {
        Dictionary<string,List<int>> dicTweet;
        public TweetCounts()
        {
            dicTweet = new Dictionary<string, List<int>>();
        }

        public void RecordTweet(string tweetName, int time)
        {
            if (dicTweet.ContainsKey(tweetName))
                dicTweet[tweetName].Add(time);
            else
                dicTweet.Add(tweetName, new List<int> { time });
            
        }

        public IList<int> GetTweetCountsPerFrequency(string freq, string tweetName, int startTime, int endTime)
        {
            var freqnum = 0;
            if (freq == "minute")
                freqnum = 60;
            else if (freq == "hour")
                freqnum = 3600;
            else if (freq == "day")
                freqnum = 86400;

            var arr_res = new int[(endTime - startTime + 1) / freqnum + ((endTime - startTime + 1) % freqnum == 0 ? 0 : 1)];

            if (!dicTweet.ContainsKey(tweetName))
                return arr_res.ToList();
            else
            {
                foreach (var onetime in dicTweet[tweetName])
                {
                    if (onetime >= startTime && onetime <= endTime)
                    {
                        var place = (onetime - startTime) / freqnum;
                        arr_res[place] += 1;
                    }
                }
                return arr_res.ToList();
            }
        }
    }

    /**
     * Your TweetCounts object will be instantiated and called as such:
     * TweetCounts obj = new TweetCounts();
     * obj.RecordTweet(tweetName,time);
     * IList<int> param_2 = obj.GetTweetCountsPerFrequency(freq,tweetName,startTime,endTime);
     */
}
