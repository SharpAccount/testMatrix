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
    
    static IEnumerable<object[]> arr4() {
        return new[] {
            new []{ new[,]
            {
                { 2.5, 2.0 },
                { 2.5, 2.0 }
            } }
        };
    }
    
    static IEnumerable<object[]> arr5() {
        return new[] {
            new []{ new[,] { 
                { 3.0, 2.0, 1.0, 6.5 },
                { 3.0, 2.0, 6.0, 8.3 },
                { 3.0, 2.0, 5.0, 10.0 },
                { 1.0, 3.1, 5.5, 1.0 }
            } }
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
    [DynamicData(nameof(arr4), DynamicDataSourceType.Method)]
    
    public void IsArrayCorrect(double[,] arr)
    {
        _matrix = new Matrix(arr);
        Console.WriteLine(_matrix.ToString());
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
    }

    [TestMethod] 
    [DataRow (8, 8)]
    [DataRow (3, 3)]  

    public void SumMatrices(int rows1, int cols1)
    {
        _matrix = new Matrix(rows1, cols1);
        _secMatrix = new Matrix(rows1, cols1);

        Matrix result = Matrix.SumBy(_matrix, _secMatrix);
        Console.WriteLine(result.ToString());   
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
    [DataRow (10, 10, 8, 8)]
    [DataRow (8, 10, 7, 7)]  
    [DataRow (8, 7, 7, 8)]

    public void Multiply(int rows1, int cols1, int rows2, int cols2)
    {
        _matrix = new Matrix(rows1, cols1);
        _secMatrix = new Matrix(rows2, cols2);

        Matrix result = Matrix.MultiplyBy(_matrix, _secMatrix);
        Console.WriteLine(result.ToString());
    }
    
    [TestMethod]
    [DynamicData(nameof(arr1), DynamicDataSourceType.Method)]
    [DynamicData(nameof(arr5), DynamicDataSourceType.Method)]
    [DynamicData(nameof(arr3), DynamicDataSourceType.Method)]


    public void transformToTriangleForm(double[,] matrix)
    {
        Matrix matrixToTransform = new Matrix(matrix);
        Matrix.ToTriangleForm(matrixToTransform);
        
        Console.WriteLine(matrixToTransform.ToString());
    }
    
    [TestMethod]
    [DynamicData(nameof(arr1), DynamicDataSourceType.Method)]
    [DynamicData(nameof(arr5), DynamicDataSourceType.Method)]

    public void findDeterminal(double[,] matrix)
    {
        Matrix matrixToTransform = new Matrix(matrix);
        double determinal = Matrix.Determinal(matrixToTransform);
        
        Console.WriteLine(determinal);
    }
    
    [TestMethod]
    [DynamicData(nameof(arr3), DynamicDataSourceType.Method)]
    [DynamicData(nameof(arr5), DynamicDataSourceType.Method)]

    public void findRoots(double[,] matrix)
    {
        Matrix matrixToFind = new Matrix(matrix);
        matrixToFind = Matrix.ToTriangleForm(matrixToFind);

        double[] roots = Matrix.findRoots(matrixToFind);
        foreach (double root in roots)
        {
            Console.Write(root + " ");
        }
    }
}