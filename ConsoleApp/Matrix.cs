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

        public static Matrix SumBy(Matrix matrix1, Matrix matrix2)
        {
            if ((matrix1.CountCols != matrix2.CountCols) || (matrix1.CountRows != matrix2.CountRows)) 
            {
                throw new ArithmeticException("Не равное количество строк и столбцов!");
            }
            Matrix result = new Matrix(matrix1.CountRows, matrix1.CountCols);
            for(int i = 0; i < result._CountRows; i++)
            {
                for(int j = 0; j < result._CountCols; i++)
                {
                    result._Matrix[i, j] = matrix1._Matrix[i, j] + matrix2._Matrix[i, j];
                }
            }
            return result;
        }

        public static double Determinal(Matrix matrix) //void
        {
            int rows = matrix.CountRows;
            int cols = matrix.CountCols;

            matrix = matrix.ToTriangularForm(matrix);

            if (rows != cols)
            {
                throw new ArgumentException("Не равное количество строк и столбцов у определяемой матрицы!");
            }

            double determinant = 1.0;

            for (int i = 0; i < rows; i++)
            {
                determinant *= matrix._Matrix[i, i];
            }

            return determinant;
        }

        private Matrix ToTriangularForm(Matrix matrix)
        {
            int rows = matrix.CountRows;
            int cols = matrix.CountCols;

            for (int k = 0; k < cols - 1; k++)
            {
                for (int i = k + 1; i < rows; i++)
                {
                    double factor = matrix._Matrix[i, k] / matrix._Matrix[k, k];

                    for (int j = k; j < cols; j++)
                    {
                        matrix._Matrix[i, j] -= factor * matrix._Matrix[k, j];
                    }
                }
            }
            return matrix;
        }
    }
}