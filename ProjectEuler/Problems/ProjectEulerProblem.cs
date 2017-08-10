using System;
using System.Text;
using ProjectEuler.Common;
using ProjectEuler.Problems;

namespace ProjectEuler
{
    public abstract class ProjectEulerProblem : IProblem
    {
        private long _solution;

        private bool _solutionExists;

        public ProjectEulerProblem()
        {
            _solutionExists = false;
        }

        public long Solution
        {
            get
            {
                if (!_solutionExists)
                    throw new InvalidOperationException("The solution cannot be accessed until the problem has been solved.");

                return _solution;
            }
            protected set
            {
                _solution = value;
                _solutionExists = true;
            }
        }

        public int Id { get; protected set; }

        public string Statement { get; protected set; }

        public abstract void Solve();

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine("Problem {0}: {1}", Id, Statement);

            if (_solutionExists)
                sb.AppendFormat("Solution: {0}", Solution);
            else
                sb.AppendFormat("The problem has not been solved yet.");

            return sb.ToString();
        }
    }
}