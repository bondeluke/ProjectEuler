using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Problems
{
    public interface IProblem
    {
        long Solution { get; }

        int Id { get; }

        string Statement { get; }
    }
}
