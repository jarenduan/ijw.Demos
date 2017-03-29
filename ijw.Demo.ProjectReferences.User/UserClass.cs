
namespace ijw.Demo.ProjectReferences.User
{
    public class UserClass
    {
        public void Method() {
            //ijw.Demo.ProjectReferences.User项目只添加了对ClassLib2的引用.
            //因为代码中只使用了ClassLib2中的类,这看起来没有任何问题.
            //但现在立即编译, 会收到缺少对ClassLib1程序集引用的错误, 无法通过编译.
            //原因是:

            //ClassLib2.HeritedClassTwo的基类是ClassOne, ClassOne是在ClassLib1项目中
            //因此虽然没有直接使用ClassLib1中的类, 而且ClassLib2也引用了ClassLib1, 
            //但是User项目也必须添加ClassLib1的引用, 否则不会通过编译.
            
            ClassLib2.HeritedClassTwo hc2 = new ClassLib2.HeritedClassTwo();

            //如果注释掉上一行代码, 则不用添加对ClassLib1的引用, 下面这条也可以编译.
            ClassLib2.ClassTwo c2 = new ClassLib2.ClassTwo();

            //这是当然的啦
            //不过下面这条也可以编译:
            ClassLib2.ListClassOne lc1 = new ClassLib2.ListClassOne();

            //特殊的地方是: ClassLib2.ListClassOne的泛型参数是ClassLib1.ClassOne.
            //也就是说泛型参数并没有这种问题.
            
            //有趣的是, 编译成功之后的输出文件里面是包含 ClassLib1.dll 的. 
            //这说明VS不会自动帮我们管理这样的引用的, 明明是编译进来, 却还需要显式引用.
            //为了让VS自动帮我们加上程序集引用, 恐怕需要借助nuget之类的包管理器了.

            //这个Demo演示了这样一个问题: 程序集A中类的基类所在的程序集B也会被视作A的延伸, A的调用者C也必须显式添加对B的引用, 即使A已经引用了B, 否则也是无法通过编译的.
            //这看起来并不是什么严重的问题, 毕竟显式加上项目引用即可通过编译.

            //但带来的一个问题可能是软件工程意义上的: 有可能出现跨层的程序集引用, 破坏分层的隔离, 也会增加项目之间的耦合.
            //User知道了ClassLib1, 甚至可以直接使用ClassLib1中的类, 我们有可能本来希望是通过ClassLib2来隔离二者的.

            //对于编译器来讲, 上面的问题某种程度上是不成立的. 对于我们, 可能就是一个问题.
        }
    }
}