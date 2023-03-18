using MathBase.Matrixes;
using MathBase.MultidimensionalArrays;
using MathBase.Points;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathBase.Matrixes
{
    public static class MatrixExtensions
    {
        public static bool IsOutOfMatrix<T>(this Matrix<T> matrix, Vector2 point)
        {
            return D2ArraysHelper.IsOutOf2dArray(matrix.Width, matrix.Height, point);
        }

        #region Get Immediate Points
        public static IEnumerable<Vector2> GetImmediatePoints<T>(this Matrix<T> matrix, Vector2 point)
        {
            return D2ArraysHelper.GetImmediatePoints(matrix.Width, matrix.Height, point);
        }

        public static IEnumerable<Vector2> GetFullImmediatePoints<T>(this Matrix<T> matrix, Vector2 point)
        {
            return D2ArraysHelper.GetFullImmediatePoints(matrix.Width, matrix.Height, point);
        }

        public static IEnumerable<Vector2> GetImmediatePointsMirror<T>(this Matrix<T> matrix, Vector2 point)
        {
            return D2ArraysHelper.GetImmediatePointsMirror(matrix.Width, matrix.Height, point);
        }

        public static IEnumerable<Vector2> GetFullImmediatePointsMirror<T>(this Matrix<T> matrix, Vector2 point)
        {
            return D2ArraysHelper.GetFullImmediatePointsMirror(matrix.Width, matrix.Height, point);
        }
        #endregion
    }
}
