using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ijw {
    public static class IntegerExt {
        /// <summary>
        /// 返回由当前数字开始直到指定数字所组成的递增整数数组
        /// </summary>
        /// <param name="number">当前的数字</param>
        /// <param name="toNumber">结束的数字</param>
        /// <returns></returns>
        public static int[] To(this int number, int toNumber) {
            if (number >= toNumber) {
                throw new ArgumentException("fromNumber should be less than toNumber");
            }
            int count = toNumber - number;
            int[] seq = new int[count];

            for (int i = 0; i < count; i++) {
                seq[i] = i + number;
            }
            return seq;
        }

        /// <summary>
        /// 返回由当前数字及指定数目的后续整数一起所组成的递增整数数组. 例如: 11.ToNext(5) 将返回 [11, 12, 13, 14, 15, 16].
        /// </summary>
        /// <param name="number"></param>
        /// <param name="howManyNext"></param>
        /// <returns></returns>
        public static int[] ToNext(this int number, int howManyNext) {
            return number.To(number + howManyNext);
        }

        /// <summary>
        /// 返回从当前数字开始的指定长度的递增整数数组. 例如: 11.ToNext(5) 将返回 [11, 12, 13, 14, 15].
        /// </summary>
        /// <param name="number"></param>
        /// <param name="totalLength"></param>
        /// <returns></returns>
        public static int[] ToTotal(this int number, int totalLength) {
            return number.ToNext(number + totalLength - 1);
        }

        /// <summary>
        /// 随机打乱数组中元素的排列顺序, 返回新数组.
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public static int[] Shuffle(this int[] numbers) {
            int count = numbers.Length;
            if (count == 0) {
                return numbers;
            }
            Random r = new Random();
            for (int i = 0; i < r.Next(count / 2, count); i++) {
                int i1 = r.Next(count);
                int i2 = r.Next(count);
                var temp = numbers[i1];
                numbers[i1] = numbers[i2];
                numbers[i2] = temp;
            }
            return numbers;
        }

        public static int Pow(this int number, int power)
        {
            return (int)Math.Pow(number, power);
        }
    }
}
