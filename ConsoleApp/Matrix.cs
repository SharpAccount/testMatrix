using System.Text;
    
namespace TestMatrix.Utils
{
    public class Matrix
    {

        private sbyte _CountRows, _CountCols;
        private double[,] _Matrix;
        Random _Random = new Random();
        public sbyte CountRows
        {
            get => _CountRows;
            set => _CountRows = value;
        }

        public sbyte CountCols
        {
            get => _CountCols;
            set => _CountCols = value;
        }

        public override string ToString()
        {
            StringBuilder builderMatrix = new StringBuilder();
            for (int i = 0; i < _Matrix.GetUpperBound(0); i++)
            {
                for (int j = 0; j < _Matrix.GetUpperBound(1); j++)
                {
                    builderMatrix.Append(_Matrix[i, j] + " ");
                }
                builderMatrix.AppendLine();
            }
            return builderMatrix.ToString();
        }

        public Matrix(double[,] Matrix)
        {
            _Matrix = Matrix;
        }

        public Matrix(sbyte rows, sbyte columns)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    _Matrix[i, j] = _Random.NextDouble();
                }
            }
        }
        public static Matrix MultiplyBy(Matrix matrix1, Matrix matrix2)
        {
            Matrix result = new Matrix(matrix1.CountRows, matrix2.CountCols);

            for (int i = 0; i < result.CountRows; i++)
                for (int j = 0; j < result.CountCols; j++)
                    result._Matrix[i, j] = Enumerable.Range(0, matrix1.CountCols)
                        .Select(k => matrix1._Matrix[i, k] * matrix2._Matrix[k, j])
                        .Sum();

            return result;
        }
    }
}