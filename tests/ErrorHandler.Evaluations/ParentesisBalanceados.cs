using ArtForAll.Shared.ErrorHandler;
using ErrorHandler.Evaluations.helpers;

namespace ErrorHandler.Evaluations
{
    public class ParaentesisBalanceados
    {
        [Fact]
        public void Test1()
        {
            var input = "()";
            var eval = new Balancer();

            var evalResult = eval.Evaluate(input);
            Assert.True(evalResult);
        }

        [Fact]
        public void Test2()
        {
            var input = "({})";
            var eval = new Balancer();

            var evalResult = eval.Evaluate(input);
            Assert.True(evalResult);
        }

        [Fact]
        public void Test3()
        {
            var input = "{tgtt]";
            var eval = new Balancer();

            var evalResult = eval.Evaluate(input);

            Assert.False(evalResult);
        }

        [Fact]
        public void Test4()
        {
            var input = "(sdsds{[sdsd],,,})";
            var eval = new Balancer();

            var evalResult = eval.Evaluate(input);


            Assert.True(evalResult);
        }

        [Fact]
        public void Test5()
        {
            var input = "hola({[]}))";
            var eval = new Balancer();

            var evalResult = eval.Evaluate(input);

            Assert.False(evalResult);
        }

        [Fact]
        public void Test6()
        {
            var input = "{([])}";
            var eval = new Balancer();

            var evalResult = eval.Evaluate(input);

            Assert.False(evalResult);
        }

        [Fact]
        public void Test7()
        {
            var input = "[({})]";
            var eval = new Balancer();
            var evalResult = eval.Evaluate(input);

            Assert.False(evalResult);
        }
    }
}