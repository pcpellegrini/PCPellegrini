using UnityEngine;
using System.Collections;

static public class PMath {

    /// <summary>
    /// Returns a index of an array after calculate the probability of every array position
    /// </summary>
    /// <param name="p_percentages"> Inform an int array with the percentage of every item in the correct order ex:(20, 30, 50)</param>
    static public int CalculateProb(int[] p_percentages)
    {
        int __sum = 0;
        for (int i = 0; i < p_percentages.Length; i++)
        {
            int __num = i;
            __sum += p_percentages[__num];
        }
        int __rndChoose = Random.Range(0, __sum);
        int __tmpChance = 0;
        int __idx = 0;
        for (int i = 0; i < p_percentages.Length; i++)
        {
            int __num = i;
            __tmpChance += p_percentages[__num];
            if (__rndChoose < __tmpChance)
            {
                __idx = __num;
                break;
            }
        }
        return __idx;
    }
}
