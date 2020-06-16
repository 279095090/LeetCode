using System;
using System.Reflection;
using System.Linq;
namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var asmb = Assembly.GetExecutingAssembly();
            var types = asmb.GetTypes().Where(t => t.GetInterface(typeof(ISubject).FullName) != null).Select(t => GetType(t)).ToDictionary(x => x.SubjectNo);
            foreach (var t in types.Values)
            {
                Console.WriteLine($"Sub{t.SubjectNo.ToString("0000")}:{t.SubjectDescription}");
            }

            Console.WriteLine("请选择题目:");
            var input = Console.ReadLine(); var no = 0;
            while (!String.Equals(input, "q", StringComparison.CurrentCultureIgnoreCase))
            {
                if (Int32.TryParse(input, out no))
                {
                    Run(types[no].Type);
                }
                Console.WriteLine("请选择题目:");
                input = Console.ReadLine();
            }


            Console.WriteLine("任务结束");
        }


        static dynamic GetType(Type t)
        {
            var attr = t.GetCustomAttribute(typeof(SubjectAttrubute)) as SubjectAttrubute;
            return new
            {
                Type = t,
                SubjectNo = attr?.No,
                SubjectDescription = attr?.Desc,
                SubjectTags = attr?.Tags?.Aggregate((c, t) => $"{t},{c}"),
                SubjectUrl = attr?.Url
            };
        }

        static void Run(Type t)
        {
            var inc = Activator.CreateInstance(t) as ISubject;
            if (inc != null)
            {
                inc.Run();
            }
        }
    }
}
