namespace _657__Judge_Route_Circle
{
    internal class Program
    {
        public static void Main(string[] args)
        {
        }

        public bool JudgeCircle(string moves)
        {
            char[] cmd = moves.ToCharArray();
            int x = 0, y = 0;
            foreach (var VARIABLE in cmd)
            {
                if (VARIABLE == 'U') y++;
                if (VARIABLE == 'D') y--;
                if (VARIABLE == 'R') x++;
                if (VARIABLE == 'L') x++;
            }

            if (x == 0 && y == 0) return true;
            return false;
        }
    }
}
/*Initially, there is a Robot at position (0, 0). Given a sequence of its moves, judge if this robot makes a circle, which means it moves back to the original place.

The move sequence is represented by a string. And each move is represent by a character. The valid robot moves are R (Right), L (Left), U (Up) and D (down). The output should be true or false representing whether the robot makes a circle.

Example 1:
Input: "UD"
Output: true
Example 2:
Input: "LL"
Output: false
*/