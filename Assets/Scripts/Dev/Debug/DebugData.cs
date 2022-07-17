using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace BakuSou
{
    public static class DebugData
    {
        public static List<float> timinglist = new List<float>();
        public static List<float> averagelist = new List<float>();
        public static bool isPrint = false;
        public static void Add(float f)
        {
            timinglist.Add(f);
        }
        public static void print()
        {
            if(!isPrint)
            {
                float sum = 0;
                for (int i = 10; i < timinglist.Count - 10; i++)
                {
                    sum += timinglist[i];
                    if ((i + 1) % 10 == 0)
                    {
                        averagelist.Add(sum / 10);
                        Debug.Log("average:" + sum / 10);
                        sum = 0;
                    }
                }
                sum = 0;
                for (int i = 0; i < averagelist.Count; i++)
                {
                    sum += averagelist[i];
                }
                Debug.Log("totalAverage:" + sum / averagelist.Count);
                isPrint = true;
            }
        }
    }
}