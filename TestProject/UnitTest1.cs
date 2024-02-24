using System.Diagnostics;
using TestMatrix.Utils;

namespace TestProject;

[TestClass]
public class UnitTest1
{
    private Matrix _matrix;
    private Matrix _secMatrix;

    static IEnumerable<object[]> arr1() {
        return new[] {
            new []{ new[,] { 
                { 3.0, 2.0, 1.0 },
                { 3.0, 2.0, 6.0 },
                { 3.0, 2.0, 5.0 } } }
        };
    }
    
    static IEnumerable<object[]> arr2() {
        return new[] {
            new []{ new[,]
            {
                { 2.5, 2.0, 1.0 },
                { 2.5, 2.0, 1.0 },
                { 2.5, 2.0, 1.0 },
                { 2.5, 3.0, 1.0 }
            } }
        };
    }
    
    static IEnumerable<object[]> arr3() {
        return new[] {
            new []{ new[,]
            {
                { 2.5, 2.0, 1.0, 2.2 },
                { 2.5, 2.3, 9.0, 5.2 },
                { 2.0, 2.0, 1.6, 1.5 }
            } }
        };
    }
    
    static IEnumerable<object[]> toTrianle1() {
        return new[] {
            new []
            { 
                new[,]
                {
                    { 2.5, 1.1, 1.0, 1.0 },
                    { 3.5, 2.2, 9.0, 10.0 },
                    { 7.5, 2.0, 8.7, 6.8 },
                    { 9.6, 8.3, 1.2, 2.0 }
                },
                new[,]
                {
                    {2.5, 1.1, 1,1},
                    {0, 0.66, 7.6, 8.6},
                    {0, 0, 20.67, 20.74},
                    {0, 0, 0, -5.21}
                }
            }
        };
    }
    
    static IEnumerable<object[]> toTrianle2() {
        return new[] {
            new []
            { 
                new[,]
                {
                    { 2.5, 1.1, 1.0, 1.0 },
                    { 3.5, 2.2, 9.0, 10.0 },
                    { 7.5, 2.0, 8.7, 6.8 },
                    { 9.6, 8.3, 1.2, 2.0 }
                },
                new[,]
                {
                    {2.5, 1.1, 1,1},
                    {0, 0.66, 7.6, 8.6},
                    {0, 0, 20.67, 20.74},
                    {0, 0, 0, -5.21}
                }
            }
        };
    }
    
    static IEnumerable<object[]> arrsToSum1()
    {
        return new[]
        {
            new[]
            {
                new[,]
                {
                    { 3.0, 2.0, 1.0, 6.5 },
                    { 3.0, 2.0, 6.0, 8.3 },
                    { 3.0, 2.0, 5.0, 10.0 },
                    { 1.0, 3.1, 5.5, 1.0 }
                },
                new[,]
                {
                    { 2.5, 1.1, 1.0, 1.0 },
                    { 3.5, 2.2, 9.0, 10.0 },
                    { 7.5, 2.0, 8.7, 6.8 },
                    { 9.6, 8.3, 1.2, 2.0 }
                }, 
                new[,]
                { 
                    { 5.5, 3.1, 2.0, 7.5 },
                    { 6.5, 4.2, 15.0, 18.3 },
                    { 10.5, 4.0, 13.7, 16.8 },
                    { 10.6, 11.4, 6.7, 3.0 }
                }
            }
        };
    }
    
    static IEnumerable<object[]> arrsToSum2()
    {
        return new[]
        {
            new[]
            {
                new[,]
                {
                    { 38.9, 80.9, 18.8 },
                    { 95.3, 7.5, 68.5 },
                    { 11.2, 95.2, 2.6 }
                },
                new[,]
                {
                    { 2, 3.5, 4.7 },
                    { 5.34, 126.7, 8.9 },
                    { 4.1, 1.8, 10.4 }
                }, 
                new[,]
                {
                    { 40.9, 84.4, 23.5 },
                    {100.64, 134.2, 77.4},
                    { 15.3, 97.0, 13.0 }
                }
            }
        };
    }
    
    static IEnumerable<object[]> arrsToMultiply1()
    {
        return new[]
        {
            new[]
            {
                new[,]
                {
                    { 2, 3.5, 4.7 },
                    { 5.34, 126.7, 8.9 },
                    { 4.1, 1.8, 10.4 }
                },
                new[,]
                {
                    { 38.9, 80.9, 18.8 },
                    { 95.3, 7.5, 68.5 },
                    { 11.2, 95.2, 2.6 }
                }, 
                new[,]
                {
                    {463.99,635.49,289.57},
                    {12381.92, 2229.54, 8802.48},
                    {447.51, 1335.27, 227.42}
                }
            }
        };
    }
    
    static IEnumerable<object[]> arrsToMultiply2()
    {
        return new[]
        {
            new[]
            {
                new[,]
                {
                    { 3.0, 2.0, 1.0, 6.5 },
                    { 3.0, 2.0, 6.0, 8.3 },
                    { 3.0, 2.0, 5.0, 10.0 },
                    { 1.0, 3.1, 5.5, 1.0 }
                },
                new[,]
                {
                    { 2.5, 1.1, 1.0, 1.0 },
                    { 3.5, 2.2, 9.0, 10.0 },
                    { 7.5, 2.0, 8.7, 6.8 },
                    { 9.6, 8.3, 1.2, 2.0 }
                }, 
                new[,]
                { 
                    {84.4, 63.65, 37.5, 42.8},
                    {139.18, 88.59, 83.16, 80.4},
                    {148.0, 100.7, 76.5, 77.0},
                    {64.2, 27.22, 77.95, 71.4}
                }
            }
        };
    }

    [TestMethod]   
    [DataRow (10, 10)]
    [DataRow (20, 20)]
    [DataRow (15, 10)]
    [DataRow (30, 30)]

    public void areRowsAndColumnsEqual(int rows1, int cols1)
    {
        _matrix = new Matrix(rows1, cols1);
        Assert.IsTrue(_matrix.CountCols == cols1 && _matrix.CountRows == rows1);
    }
    
    [TestMethod]
    [DynamicData(nameof(arr1), DynamicDataSourceType.Method)]
    [DynamicData(nameof(arr2), DynamicDataSourceType.Method)]
    [DynamicData(nameof(arr3), DynamicDataSourceType.Method)]
    
    public void IsArrayCorrect(double[,] arr)
    {
        _matrix = new Matrix(arr);
        Console.WriteLine(_matrix.ToString());
        Assert.IsTrue(_matrix is double[,]);
    }

    [TestMethod] 
    [DataRow (10, 10)]
    [DataRow (20, 20)]  
    [DataRow (3, 3)]  
    public void showMatrix(int rows1, int cols1)
    {
        _matrix = new Matrix(rows1, cols1);
        Console.WriteLine(_matrix.ToString());
        
    }

    [TestMethod] 
    [DataRow (10, 10, 8, 8)]
    [DataRow (8, 10, 7, 7)]  
    [DataRow (11, 11, 6, 6)]  

    public void areRowsAndColumnsNotEqualInSum(int rows1, int cols1, int rows2, int cols2)
    {
        _matrix = new Matrix(rows1, cols1);
        _secMatrix = new Matrix(rows2, cols2);

        Matrix result = Matrix.SumBy(_matrix, _secMatrix);
        Assert.IsTrue(rows1 == rows2 && cols1 == cols2);
    }

    [TestMethod] 
    [DynamicData(nameof(arrsToSum1), DynamicDataSourceType.Method)]
    [DynamicData(nameof(arrsToSum2), DynamicDataSourceType.Method)]

    public void SumMatrices(double[,] arr1, double[,] arr2, double[,] expected)
    {
        _matrix = new Matrix(arr1);
        _secMatrix = new Matrix(arr2);
        Matrix expectedMatrix = new Matrix(expected);

        Matrix result = Matrix.SumBy(_matrix, _secMatrix);
        Console.WriteLine(result.ToString());
        Assert.AreEqual(expectedMatrix.ToString(), result.ToString(), "суммы не совпадают!");
    }
    
    [TestMethod] 
    [DataRow (10, 10, 8, 8)]
    [DataRow (8, 10, 7, 7)]  

    public void areRowsAndColumnsNotEqualInMultiply(int rows1, int cols1, int rows2, int cols2)
    {
        _matrix = new Matrix(rows1, cols1);
        _secMatrix = new Matrix(rows2, cols2);

        Matrix result = Matrix.MultiplyBy(_matrix, _secMatrix);
    }
    
    [TestMethod] 
    [DataRow (10, 10, 10, 10)]
    [DataRow (7, 7, 7, 7)]  

    public void areResultRowsEqualToMMatrixultiply(int rows1, int cols1, int rows2, int cols2)
    {
        _matrix = new Matrix(rows1, cols1);
        _secMatrix = new Matrix(rows2, cols2);

        Matrix result = Matrix.MultiplyBy(_matrix, _secMatrix);
        Assert.IsTrue(result.CountRows == _matrix.CountCols && result.CountCols == _matrix.CountRows);
    }
    
    [TestMethod] 
    [DynamicData(nameof(arrsToMultiply1), DynamicDataSourceType.Method)]
    [DynamicData(nameof(arrsToMultiply2), DynamicDataSourceType.Method)]

    public void MultiplyMatrices(double[,] arr1, double[,] arr2, double[,] expected)
    {
        _matrix = new Matrix(arr1);
        _secMatrix = new Matrix(arr2);
        Matrix expectedMatrix = new Matrix(expected);

        Matrix result = Matrix.MultiplyBy(_matrix, _secMatrix);
        Console.WriteLine(result.ToString());
        Assert.AreEqual(expectedMatrix.ToString(), result.ToString(), "произведения не совпадают!");
    }
    
    [TestMethod]
    [DynamicData(nameof(toTrianle1), DynamicDataSourceType.Method)]


    public void transformToTriangleForm(double[,] matrix, double[,] expected)
    {
        Matrix matrixToTransform = new Matrix(matrix);
        Matrix toExpect = new Matrix(expected);
        Matrix.ToTriangleForm(matrixToTransform);
        
        Console.WriteLine(matrixToTransform.ToString());
        Assert.AreEqual(toExpect.ToString(), matrixToTransform.ToString(), "Матрица неправильно приведена к треугольной форме!");
    }
    
    [TestMethod]
    [DynamicData(nameof(arr1), DynamicDataSourceType.Method)]
    [DynamicData(nameof(arr2), DynamicDataSourceType.Method)]

    public void findDeterminal(double[,] matrix)
    {
        Matrix matrixToTransform = new Matrix(matrix);
        double determinal = matrixToTransform.Determinal();
        
        Console.WriteLine(determinal);
    }
    
    [TestMethod]
    [DynamicData(nameof(arr3), DynamicDataSourceType.Method)]
    [DynamicData(nameof(arr1), DynamicDataSourceType.Method)]

    public void findRoots(double[,] matrix)
    {
        Matrix matrixToFind = new Matrix(matrix);

        double[] roots = Matrix.findRoots(matrixToFind);
        foreach (double root in roots)
        {
            Console.Write(root + " ");
        }
    }
}