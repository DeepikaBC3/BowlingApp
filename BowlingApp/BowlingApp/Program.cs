namespace BowlingApp
{
    public class Program
    {
        public static void Main(String[] args)
        {
            try
            {
                BowlingGame bowlingGameObj = new BowlingGame();
                //Normal
                bowlingGameObj.Roll(1);
                bowlingGameObj.Roll(2);
                //Spare Set
                bowlingGameObj.Roll(3);
                bowlingGameObj.Roll(10);
                bowlingGameObj.Roll(4);
                bowlingGameObj.Roll(5);
                //Spare Set
                //Strike Set
                bowlingGameObj.Roll(10);
                bowlingGameObj.Roll(6);
                bowlingGameObj.Roll(7);
                //Strike Set
                //Normal
                bowlingGameObj.Roll(1);
                bowlingGameObj.Roll(2);
                //Normal
                bowlingGameObj.Roll(1);
                bowlingGameObj.Roll(2);
                //Normal
                bowlingGameObj.Roll(1);
                bowlingGameObj.Roll(2);
                //Spare Set
                bowlingGameObj.Roll(3);
                bowlingGameObj.Roll(10);
                bowlingGameObj.Roll(4);
                bowlingGameObj.Roll(5);
                //Spare Set
                //Strike Set
                bowlingGameObj.Roll(10);
                bowlingGameObj.Roll(6);
                bowlingGameObj.Roll(7);
                //Strike Set
                //Normal
                bowlingGameObj.Roll(1);
                bowlingGameObj.Roll(2);
                //Normal
                //Normal
                bowlingGameObj.Roll(6);
                bowlingGameObj.Roll(6);
                //Normal
                bowlingGameObj.Score();
                //Normal
                bowlingGameObj.Roll(5);
                bowlingGameObj.Roll(7);
                //Normal
                bowlingGameObj.Score();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
