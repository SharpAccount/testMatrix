using TestMatrix.Utils;

namespace TestProject;

[TestClass]
public class UnitTest1
{
    private Matrix _matrix;

    [TestMethod]
    [DataRow ((sbyte)10, (sbyte)10, (sbyte)15, (sbyte)10)]
    public void TestMethod1(sbyte rows1, sbyte cols1, sbyte rows2, sbyte cols2)
    {
        _matrix = new Matrix(rows1, cols1);
        Assert.IsTrue(_matrix.CountCols == cols1 && _matrix.CountRows == rows1);
                _matrix = new Matrix(rows2, cols2);
        Assert.IsTrue(_matrix.CountCols == cols2 && _matrix.CountRows == rows2);
    }


    public void TestMethod2(double[,] testMatrix)
    {
        
    }
}