namespace BowlingApp
{
    public class FrameData
    {
        public int frameCount { get; set; }
        public int turnCount { get; set; }
        public int frameScore { get; set; }
        public bool isSpare { get; set; }
        public bool isStrike { get; set; }

    }
    public class BowlingGame : IGame
    {
        public const int totalFrames = 10;
        public const int pinsPerFrame = 10;
        public const int turnsPerFrame = 2;
        public const int spareWithTurnsPerFrame = 4;
        public const int strikeWithTurnsPerFrame = 3;
        public FrameData frameDataObj = new FrameData();
        public int noOfPinsRolled = 0;
        public List<int> scoreDetails = new List<int>();
        List<FrameData> frames = new List<FrameData>();
        int frameCount = 0;

        public void Roll(int noOfPins) 
        {
            try
            {
                if(frameDataObj.turnCount == 0)
                {
                    frameCount++;
                    frameDataObj.frameCount = frameCount;
                }
                scoreDetails.Add(noOfPins);
                frameDataObj.turnCount = frameDataObj.turnCount + 1;
                if (frameDataObj.frameCount <= totalFrames && frameDataObj.turnCount <= turnsPerFrame - 1 ||
                    (frameDataObj.isSpare == true && frameDataObj.turnCount <= spareWithTurnsPerFrame - 1) ||
                    (frameDataObj.isStrike == true && frameDataObj.turnCount <= strikeWithTurnsPerFrame - 1))
                {
                    if (noOfPins == pinsPerFrame && frameDataObj.turnCount == 1)
                    {
                        frameDataObj.isStrike = true;
                    }
                }
                else if (frameDataObj.frameCount < totalFrames && frameDataObj.turnCount == 2 && noOfPins == pinsPerFrame)
                {
                    frameDataObj.isSpare = true;
                }
                else if (frameDataObj.frameCount <= totalFrames && frameDataObj.turnCount == turnsPerFrame ||
                    (frameDataObj.isSpare == true && frameDataObj.turnCount == spareWithTurnsPerFrame) ||
                    (frameDataObj.isStrike == true && frameDataObj.turnCount == strikeWithTurnsPerFrame))
                {
                    CalculateScore();
                    frames.Add(frameDataObj);
                    frameDataObj = new FrameData();
                    scoreDetails = new List<int>();
                }
                else if(frameDataObj.frameCount > totalFrames)
                {
                    frameDataObj = new FrameData();
                    scoreDetails = new List<int>();
                    frames = new List<FrameData>();
                    frameCount = 0;
                    Console.WriteLine("Game Overrrrrrrrrrrrrrrrrrrrrr");
                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public void CalculateScore()
        {
            int score = 0;
            try
            {
                for (int i = 0; i < scoreDetails.Count; i++)
                {
                    if (frameDataObj.isSpare)
                    {
                        score = scoreDetails[0] + scoreDetails[1] + scoreDetails[2] + (scoreDetails[2] + scoreDetails[3]);
                    }

                    if (frameDataObj.isStrike)
                    {
                        score = scoreDetails[0] + scoreDetails[1] + scoreDetails[2] + (scoreDetails[1] + scoreDetails[2]);
                    }

                    if (!frameDataObj.isSpare && !frameDataObj.isStrike)
                    {
                        score = scoreDetails[0] + scoreDetails[1];
                    }
                }
                frameDataObj.frameScore = frameDataObj.frameScore + score;
            }
            catch(Exception e) { throw e; }
        }

        public void Score()
        {
            try
            {
                foreach (FrameData frame in frames)
                {
                    Console.WriteLine("Frame No: " + frame.frameCount);
                    //Console.WriteLine("Turn No: " + frame.turnCount);
                    Console.WriteLine("Frame Score: " + frame.frameScore);
                    if (frame.isSpare == true)
                    {
                        Console.WriteLine("Hurrayyyyyy it was a Spare");
                    }
                    if (frame.isStrike == true)
                    {
                        Console.WriteLine("Congoooooo it was a Strike");
                    }
                }
                Console.WriteLine("Total Score => " + frames.Sum(item => item.frameScore));
            }
            catch (Exception e) { throw e; }
        }
    }
}
