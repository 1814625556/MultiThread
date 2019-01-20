using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadTask
{
    class Program
    {
        static void Main(string[] args)
        {
            var numTasks = 20;
            var state = new SharedState();
            var tasks = new Task[numTasks];

            #region 这里输出的结果是100，说明引用存放的只是一个地址而已,所有的Job对象存的都是都是一份相同的SharedState对象
            var entity1 = new Job(state);
            var entity2 = new Job(state);
            entity1._sharedState.State = 100;
            Console.WriteLine(entity2._sharedState.State);//这里输出的结果是100，说明引用存放的只是一个地址而已
            #endregion

            for (var i = 0; i < numTasks; i++)
            {
                tasks[i] = Task.Run(() => new Job(state).DoTheJob());
            }

            Task.WaitAll(tasks);

            Console.WriteLine($"summarized {state.State}");
            Console.ReadKey();
        }
    }
}
