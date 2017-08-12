namespace ProjectEuler.Problems
{
    public class EvenFibonacciNumbers : IProjectEulerProblem
    {
        const long Limit = 4000000;

        public object Solve()
        {
            long sum = 0;

            var seq = new FibonacciSequence();

            foreach (var number in seq.UpTo(Limit))
                if (number.IsEven())
                    sum += number;

            return sum;
        }
    }
}