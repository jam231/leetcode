using System;
using Xunit;

namespace Solution.Test
{
    public class FreqStackTest
    {
        [Fact]
        public void Push_Pop_Single()
        {
            var sut = new FreqStack();
            sut.Push(1);
            Assert.Equal(1, sut.Pop());
        }

        [Fact]
        public void Push_Pop_Sequence()
        {
            var sut = new FreqStack();
            // [5],[7],[5],[7],[4],[5]
            (string command, int? value, int? expectedValue)[] commands = new (string, int?, int?)[] 
            { 
                ("Push", 5, null), ("Push", 7, null), ("Push", 5, null),
                ("Push", 7, null), ("Push", 4, null), ("Push", 5, null),
                ("Pop", null, 5), ("Pop", null, 7), ("Pop", null, 5), ("Pop", null, 4)
            };

            // not quite the atomic test
            for(int i = 0; i < commands.Length; i++) {
                switch (commands[i]) {
                    case var (command, value, _) when command is "Push":
                        sut.Push(value.Value);
                        break;
                    case var (command, _, expectedValue) when command is "Pop":
                        Assert.Equal(expectedValue, sut.Pop());
                        break;
                }
            }
        }
    }
}
