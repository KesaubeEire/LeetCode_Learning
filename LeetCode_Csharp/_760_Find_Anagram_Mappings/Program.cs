using System;
using System.Collections.Generic;
using System.Linq;

namespace _760_Find_Anagram_Mappings
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] A = {12, 28, 46, 32, 50};
            int[] B = {50, 12, 32, 46, 28};
            for (int i = 0; i < AnagramMappings(A, B).Length; i++)
            {
                Console.WriteLine(AnagramMappings(A, B)[i]);
            }

            Console.ReadKey();
        }

        private static int[] AnagramMappings(int[] A, int[] B)
        {
            var answer = new int[A.Length];
            for (var i = 0; i < answer.Length; i++)
            {
                answer[i] = -1;
            }

            if (A.Length != B.Length) return answer;
            bool notDouble = true;
            for (var i = 0; i < A.Length; i++)
            {
                for (var j = 0; j < A.Length; j++)
                {
                    if (A[i] == B[j])
                    {
                        for (int k = 0; k < answer.Length; k++)
                        {
                            if (answer[k].Equals(j))
                            {
                                notDouble = false;
                            }
                        }

                        if (notDouble)
                            answer[i] = j;
                    }
                }
            }

            return answer;
        }

        private static int[] AnagramMappings2(int[] A, int[] B)
        {
            var C = B.ToList();
            var result = new List<int>();
            A.ToList().ForEach
                (x => { result.Add(C.FindIndex(item => item == x)); });
            return result.ToArray();
        }
    }
}
/*
class Solution(object):
    def anagramMappings(self, A, B):
    D = {x: i for i, x in enumerate(B)}
return [D[x] for x in A]
*/


//Introduction
/*
Given two lists Aand B, and B is an anagram of A.B is an anagram of A means B is made by randomizing the order of the
elements in A.
We want to find an index mapping P, from A to B.A mapping P

[i] = j means the ith element in A appears in B at index j.
These lists A and B may contain duplicates.If there are multiple answers, output any of them.
For example, given
A = [12, 28, 46, 32, 50]
B = [50, 12, 32, 46, 28]
We should return
[1, 4, 3, 2, 0]
as P[0] = 1 because the 0th element of A appears at B[1], and P[1] =
4 because the 1st element of A appears at B[4], and so on.
Note:
A, B have equal lengths in range [1, 100].
A[i], B[i] are integers in range [0, 10^5].

*/