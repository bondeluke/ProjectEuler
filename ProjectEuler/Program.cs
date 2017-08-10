using ProjectEuler.Problems;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using ProjectEuler.Common;

namespace ProjectEuler
{
    class Program
    {
        static void Main(string[] args)
        {
            var problems = GetProblems();

            Console.WriteLine("Which problem would you like to see? ({0})", problems.Select(prob => prob.Id.ToString()).Aggregate((x, y) => x + ',' + y));
            Console.Write("Problem: ");
            int Id = Convert.ToInt32(Console.ReadLine());

            var problem = problems.First(prob => prob.Id == Id);

            problem.Solve();

            Console.WriteLine(problem);

            Console.ReadLine();
        }

        static ICollection<ProjectEulerProblem> GetProblems()
        {
            return Assembly.GetExecutingAssembly().GetTypes().Where(type => type.IsSubclassOf(typeof(ProjectEulerProblem)))
                .Select(type => type.GetConstructor(new Type[] { }).Invoke(null)).Cast<ProjectEulerProblem>().OrderBy(prob => prob.Id).ToList();
        }
    }
}
