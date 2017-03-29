using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ijw;

namespace ijw.Demo.PotentialYieldReturnBug {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Potential bugs of yield return.");
            Console.WriteLine();
            Console.WriteLine("Example1: All 10 expected!");
            Console.Write("The results are: ");
            ChangeContentsBeforeEnum1();

            Console.WriteLine();
            Console.WriteLine("Example2: All 11 expected!");
            Console.Write("The results are: ");
            ChangeContentsBeforeEnum2();
        }

        //第一个例子
        private static void ChangeContentsBeforeEnum1() {
            int len = 9;

            //准备两个数组
            int[] ints1 = 1.ToTotal(len); //{ 1, 2, ..., 9 }
            int[] ints2 = 11.ToTotal(len); //{ 11, 12, ..., 19 }

            //使用一个yield return的枚举器, 使用了两个数组的元素值做差, 应该返回{ 10, 10,..., 10}
            //但是, 目前并没有真正进行计算
            IEnumerable<int> allTens = ForEachPair(ints1, ints2, (x, y) => {
                y = y - x;
                return y;
            });

            //结果执行了下面的操作, 这个操作改变了ints2中的值: +=1
            for (int i = 0; i < len; i++) {
                ints2[i] += 1;
            }

            //取回迭代器值, 这时候才进行真正的运算
            //但是ints2值已经被改变了, 所以输出 {11, 11, ..., 11}
           
            foreach (var ten in allTens) {
                Console.Write(ten.ToString() + " ");
            }

            //yield return会带来潜在的bug. 如果使用了yield return, 就必须尽快取回迭代器中的值, 以调用被延迟的计算操作, 防止这期间所调用的操作涉及的变量内容发生改变.
            Console.ReadLine();
        }

        //一个很简单的类
        class Obj {
            public int Value { get; set; }
        }

        //第二个例子
        private static void ChangeContentsBeforeEnum2() {
            int len = 9;

            //准备两个数组
            //数组1: 9个Obj对象, 每个元素的Value值分蘖是1, 2, ..., 9
            List<Obj> Objs1 = new List<Obj>();
            for (int i = 0; i < len; i++) {
                Objs1.Add(new Obj() { Value = i });
            }

            //数组2: 9个Obj对象, 每个元素的Value值分蘖是 11, 12, ..., 19
            List<Obj> Objs2 = new List<Obj>();
            for (int i = 0; i < len; i++) {
                Objs2.Add(new Obj() { Value = i + 10 });
            }

            //使用一个yield return的枚举器, 使用了两个数组中的Obj.Value元素值做差, 返回的Obj对象的Value应该都是10
            //但是, 目前并没有真正进行计算, 计算被延迟
            IEnumerable<Obj> ObjsWithTens = ForEachPair(Objs1, Objs2, (x, y) => {
                y.Value = y.Value - x.Value;
                return y;
            });

            //下面的操作希望改变Objs中对象的值, 同时返回一个新数组.
            //但是ForEachOne返回的是yield return. 所以自增计算并没有进行.
            var Objs3 = ForEachOne(Objs2, x => { x.Value += 1; return x; });

            //可以尝试将上面的语句替换成下面的ForEachObj, 传入的Func一模一样, 但是自增操作将会立即进行, 从而会影响结果.
            //var Objs3 = ForEachObj(Objs2, x => { x.Value += 1; return x; });

            //接着我们取回迭代器值, 这时候才进行真正的运算, 
            //然而Objs2值其实并没有被改变, 所以仍然输出 {10, 10, ..., 10}
            //于是和期望的也不一致
            
            foreach (var ten in ObjsWithTens) {
                Console.Write(ten.Value.ToString() + " ");
            }

            //调用的函数内部是否使用yield return这一实现方式, 将会带来逻辑上的不明确
            //而从函数名字上面, 我们无法得知其内部是如何实现. 如果同时缺少注释或者帮助, 函数调用结果将不明确, 从而引发潜在bug.
            Console.ReadLine();

            //所以建议所有内部使用yield return的函数的名称应该尽量反映这一事实, 比如以Lazy或者YieldReturn结尾.
        }

        //使用了yield return
        public static IEnumerable<TResult> ForEachPair<T1, T2, TResult>(IEnumerable<T1> collection1, IEnumerable<T2> collection2, Func<T1, T2, TResult> theFunction) {
            IEnumerator<T2> iter = collection2.GetEnumerator();
            foreach (var e1 in collection1) {
                iter.MoveNext();
                yield return theFunction(e1, iter.Current);
            }
        }

        //下面两个函数逻辑有很大不同, 但是无法从函数签名进行确定
        public static IEnumerable<TResult> ForEachOne<T, TResult>(IEnumerable<T> collection, Func<T, TResult> theFunc) {
            foreach (var item in collection) {
                yield return theFunc(item);
            }
        }

        public static IEnumerable<TResult> ForEachObj<T, TResult>(IEnumerable<T> collection, Func<T, TResult> theFunc) {
            List<TResult> result = new List<TResult>();
            foreach (var item in collection) {
                result.Add(theFunc(item));
            }
            return result;
        }

        //如果函数名以Lazy结尾, 逻辑变的清晰
        public static IEnumerable<TResult> ForEachOneLazy<T, TResult>(IEnumerable<T> collection, Func<T, TResult> theFunc) {
            foreach (var item in collection) {
                yield return theFunc(item);
            }
        }
    }
}
