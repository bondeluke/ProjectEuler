using ProjectEuler.Common;

namespace ProjectEuler.Problems
{
    public class EvenFibonacciNumbers : ProjectEulerProblem
    {
        const long Limit = 4000000;

        public EvenFibonacciNumbers()
        {
            Id = 2;
            Statement = "By considering the terms in the Fibonacci sequence whose values do not exceed four million, find the sum of the even-valued terms.";
        }

        public override void Solve()
        {
            long sum = 0;

            var seq = new FibonacciSequence();

            foreach (var number in seq.UpTo(Limit))
                if (number.IsEven())
                    sum += number;

            Solution = sum;
        }
    }
}