namespace MastermindLibrary
{
    public class Mastermind
    {
        private List<int> answer = new List<int>();

        public string Answer
        {
            get 
            { 
                string returnAnswer = string.Join("", answer); 
                return returnAnswer;
            }
        }

        private int maxAttempt = 10;

        public int MaxAttempt
        {
            get { return maxAttempt; }
            set { maxAttempt = value; }
        }

        private int minNumber = 1;

        public int MinNumber
        {
            get { return minNumber; }
            set { minNumber = value; }
        }

        private int maxNumber = 6;

        public int MaxNumber
        {
            get { return maxNumber; }
            set { maxNumber = value; }
        }

        private int length = 4;

        public int Length
        {
            get { return length; }
            set { length = value; }
        }

        public Mastermind()
        {
            GenerateAnswer();
        }

        public Mastermind(int length, int maxNum, int minNum, int maxAttempt)
        {
            this.length = length;
            this.maxNumber = maxNum;
            this.minNumber = minNum;
            this.maxAttempt = maxAttempt;
            GenerateAnswer();
        }

        public char[] CheckAnswer(int[] guess)
        {
            char[] results = new char[length];
            for(int i = 0; i < length; i++)
            {
                if (guess[i] == answer[i])
                {
                    //Answer is right and in right spot, show +
                    results[i] = '+';
                }
                else if (answer.Contains(guess[i]))
                {
                    //Answer is right but wrong spot, check if that spot already has a right answer, if there's even one that doesn't match, show that the answer is correct but wrong spot with -, otherwise there's no more duplicates of that answer and show blank
                    int[] matchingPos = answer.Select((answer, found) => answer == guess[i] ? found : -1).Where(found => found != -1).ToArray();
                    results[i] = ' '; 
                    foreach(int pos in matchingPos)
                    {
                        if (guess[pos] != answer[pos])
                        {
                            results[i] = '-';
                        }
                    }
                }
                else
                {
                    //Answer is wrong, show blank
                    results[i] = ' ';
                }
            }
            return results;
        }

        private void GenerateAnswer()
        {
            Random random = new Random();
            List<int> tempAnswer = new List<int>();
            for(int i = 0; i < length; i++)
            {
                tempAnswer.Add(random.Next(minNumber, maxNumber + 1));
            }
            answer = tempAnswer;
        }
    }
}