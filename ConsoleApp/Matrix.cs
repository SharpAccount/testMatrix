using System.Text;
    
namespace TestMatrix.Utils
{
    public class Matrix
    {

        private int _CountRows, _CountCols;
        private double[,]? _Matrix;
        Random _Random = new Random();
        
        public int CountRows
        {
            get => _CountRows;
            set => _CountRows = value;
        }

        public int CountCols
        {
            get => _CountCols;
            set => _CountCols = value;
        }

        public override string ToString()
        {
            StringBuilder builderMatrix = new StringBuilder();
            for (int i = 0; i < _Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < _Matrix.GetLength(1); j++)
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
            CountRows = _Matrix.GetLength(0);
            CountCols = _Matrix.GetLength(1);
        }

        public Matrix(int rows, int columns)
        {
            double[,] result = new double[rows,columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    result[i, j] = _Random.NextDouble();
                }
            }
            _Matrix = result;
            CountRows = rows;
            CountCols = columns;
        }
        public static Matrix MultiplyBy(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.CountCols != matrix2.CountRows) 
            {
                throw new ArithmeticException("Не равное количество строк и столбцов!");
            }
            
            Matrix result = new Matrix(matrix1.CountCols, matrix2.CountRows);

            for (int i = 0; i < result._Matrix.GetLength(0); i++)
                for (int j = 0; j < result._Matrix.GetLength(1); j++)
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
            for(int i = 0; i < result._Matrix.GetLength(0); i++)
            {
                for(int j = 0; j < result._Matrix.GetLength(1); j++)
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

            matrix = Matrix.ToTriangleForm(matrix);

            if (rows != cols)
            {
                throw new ArgumentException("Не равное количество строк и столбцов у определяемой матрицы!");
            }

            double determinant = 1.0;

            for (int i = 0; i < rows; i++)
            {
                determinant *= matrix._Matrix[i, i];
            }
            
            return Math.Round(determinant, 2);
        }
        
        static public Matrix ToTriangleForm(Matrix matrix)
        {
            int rows = matrix.CountRows;
            int cols = matrix.CountCols;

            for (int i = 0; i < Math.Min(rows, cols); i++)
            {
                int pivotRow = i;
                while (pivotRow < rows && matrix._Matrix[pivotRow, i] == 0)
                {
                    pivotRow++;
                }

                if (pivotRow == rows)
                {
                    continue;
                }

                for (int k = 0; k < cols; k++)
                {
                    double temp = matrix._Matrix[i, k];
                    matrix._Matrix[i, k] = matrix._Matrix[pivotRow, k];
                    matrix._Matrix[pivotRow, k] = temp;
                }

                for (int j = i + 1; j < rows; j++)
                {
                    double factor = matrix._Matrix[j, i] / matrix._Matrix[i, i];
                    for (int k = i; k < cols; k++)
                    {
                        matrix._Matrix[j, k] -= factor * matrix._Matrix[i, k];
                        matrix._Matrix[j, k] = Math.Round(matrix._Matrix[j, k], 2);
                    }
                }
            }

            return matrix;
        }

        static public double[] findRoots(Matrix equationSystem)
        {
            if (equationSystem.CountCols - equationSystem.CountRows != 1)
            {
                throw new ArithmeticException("Матрица не соответствует стандарту системы уравнений!");
            }

            int rows = equationSystem.CountRows;
            int cols = equationSystem.CountCols;
            
            double[] roots = new double[cols];

            for (int i = 0; i < rows; i++)
            {
                double sum = 0;
                for (int j = 0; j < i; j++)
                {
                    sum += equationSystem._Matrix[i, j] * roots[j];
                }

                roots[i] = Math.Round((equationSystem._Matrix[i, cols - 1] - sum) / equationSystem._Matrix[i, i], 2);
            }

            return roots;
        }
    }
}