using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ProjectEuler.Core
{
    public class ProblemCollection
    {
        public static IEnumerable<IProjectEulerProblem> GetProblems()
        {
            var ass = Assembly.GetEntryAssembly();

            foreach (var ti in ass.DefinedTypes)
            {
                if (ti.ImplementedInterfaces.Contains(typeof(IProjectEulerProblem)))
                {
                    yield return ass.CreateInstance(ti.FullName) as IProjectEulerProblem;
                }
            }
        }
    }
}
