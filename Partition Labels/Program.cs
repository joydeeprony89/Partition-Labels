using System;
using System.Collections.Generic;

namespace Partition_Labels
{
  class Program
  {
    static void Main(string[] args)
    {
      Solution s = new Solution();
      var answer = s.PartitionLabels("ababcbacadefegdehijhklij");
      foreach (var a in answer)
        Console.WriteLine(a);
    }
  }

  public class Solution
  {
    public IList<int> PartitionLabels(string s)
    {
      var result = new List<int>();
      if (string.IsNullOrWhiteSpace(s)) return result;
      int partitionBoundary = 0, start = 0;
      HashSet<char> visited = new HashSet<char>();
      for (int currentIndex = 0; currentIndex < s.Length; currentIndex++)
      {
        if (currentIndex > partitionBoundary)
        {
          result.Add(currentIndex - start);
          start = currentIndex;
        }
        if (!visited.Contains(s[currentIndex]))
        {
          visited.Add(s[currentIndex]);
          int foundAtIndex = LastAppearedIndex(s[currentIndex], s);
          partitionBoundary = Math.Max(partitionBoundary, foundAtIndex);
          if (foundAtIndex == s.Length - 1)
          {
            result.Add(partitionBoundary + 1 - start);
            return result;
          }
        }
      }
      return result;
    }

    int LastAppearedIndex(char c, string s)
    {
      return s.LastIndexOf(c);
    }
  }
}
