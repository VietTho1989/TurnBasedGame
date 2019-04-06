using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ganss.Text;
using System.Linq;

public class TestAhoCorasick : MonoBehaviour
{

    void Start()
    {
        AhoCorasick ac = new AhoCorasick("a", "ab", "bab", "bc", "bca", "c", "caa");
        ac.Add("abccab");
        var results = ac.Search("abccab").ToList();
        foreach(WordMatch wordMatch in results)
        {
            Debug.LogError("wordMatch: " + wordMatch.Word);
        }
    }

}