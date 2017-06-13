using System;

namespace Template.Core.Utilities
{
    public class RoundOption
    {
        public enum Mode
        {
            /** 切り捨て*/
            Down,
            /** 切り上げ */
            Up,
            /** 四捨五入 */
            HalfAdjust,
            /** 銀行丸め */
            HalfEven
        }


        /// <summary>
        /// 四捨五入
        /// </summary>
        /// <param name="value">処理前の値</param>
        /// <param name="iDigits">端数処理をする桁</param>
        /// <returns>処理後の値</returns>
        public static decimal ToHalfAdjust(decimal value, int digits)
        {
            return Math.Round(value, digits, MidpointRounding.AwayFromZero);
        }
        /// <summary>
        /// 銀行丸め
        /// </summary>
        /// <param name="value">処理前の値</param>
        /// <param name="iDigits">端数処理をする桁</param>
        /// <returns>処理後の値</returns>
        public static decimal ToHalfEven(decimal value, int digits)
        {
            return Math.Round(value, digits, MidpointRounding.ToEven);
        }

        /// <summary>
        /// 切上げ
        /// </summary>
        /// <param name="value">処理前の値</param>
        /// <param name="iDigits">端数処理をする桁</param>
        /// <returns>処理後の値</returns>
        public static decimal ToRoundUp(decimal value, int digits)
        {
            decimal coef = (decimal)Math.Pow(10, digits);
            if (0 < value)
            {
                return Math.Floor((value * coef) + 0.9m) / coef;
            }
            else
            {
                return Math.Ceiling((value * coef) - 0.9m) / coef;
            }
        }
        /// <summary>
        /// 切捨て
        /// </summary>
        /// <param name="value">処理前の値</param>
        /// <param name="iDigits">端数処理をする桁</param>
        /// <returns>処理後の値</returns>
        public static decimal ToRoundDown(decimal value, int digits)
        {
            decimal coef = (decimal)Math.Pow(10, digits);
            if (0 < value)
            {
                return Math.Floor(value * coef) / coef;
            }
            else
            {
                return Math.Ceiling(value * coef) / coef;
            }
        }

    }
}
