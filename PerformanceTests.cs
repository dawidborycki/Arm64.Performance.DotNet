namespace Arm64.Performance
{
    public static class PerformanceTests
    {
        private static readonly Random random = new();

        private static readonly string loremIpsum = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. " +
            "Curabitur ut enim dapibus, pharetra lorem ut, accumsan massa. " +
            "Morbi et nisi feugiat magna dapibus finibus. Pellentesque habitant morbi " +
            "tristique senectus et netus et malesuada fames ac turpis egestas. Proin non luctus lectus, " +
            "vel sollicitudin ante. Nullam finibus lobortis venenatis. Nulla sit amet posuere magna, " +
            "a suscipit velit. Cras et commodo elit, nec vestibulum libero. " +
            "Cras at faucibus ex. Suspendisse ac nulla non massa aliquet sagittis. " +
            "Fusce tortor enim, feugiat ultricies ultricies at, viverra et neque. " +
            "Praesent dolor mauris, pellentesque euismod pharetra ut, interdum non velit. " +
            "Fusce vel nunc nibh. Sed mi tortor, tempor luctus tincidunt et, tristique id enim. " +
            "In nec pellentesque orci. Nulla efficitur, orci sit amet volutpat consectetur, " +
            "enim risus condimentum ex, ac tincidunt mi ipsum eu orci. Maecenas maximus nec massa in hendrerit.";

        public static void ListSorting()
        {
            var list = PrepareList();

            list.Sort();
        }

        public static void SquareMatrixMultiplication()
        {
            var matrix1 = GenerateRandomMatrix();
            var matrix2 = GenerateRandomMatrix();

            MatrixMultiplication(matrix1, matrix2);
        }

        public static void StringOperations()
        {
            loremIpsum.Split(' ');

            loremIpsum.Substring(loremIpsum.LastIndexOf("consectetur"));

            loremIpsum.Replace("nec", "orci");

            loremIpsum.ToLower();

            loremIpsum.ToUpper();
        }

        private static List<double> PrepareList()
        {
            const int listSize = 100000;

            return Enumerable.Range(0, listSize)
                        .Select(r => random.NextDouble())
                        .ToList();
        }

        private static double[,] GenerateRandomMatrix()
        {
            const int matrixSize = 500;

            var matrix = new double[matrixSize, matrixSize];

            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    matrix[i, j] = random.NextDouble();
                }
            }

            return matrix;
        }

        private static double[,] MatrixMultiplication(double[,] matrix1, double[,] matrix2)
        {
            if (matrix1.Length != matrix2.Length)
            {
                throw new ArgumentException("The matrices must be of equal size");
            }

            if (matrix1.GetLength(0) != matrix1.GetLength(1) || matrix2.GetLength(0) != matrix2.GetLength(1))
            {
                throw new ArgumentException("The matrices must be square");
            }

            int matrixSize = matrix2.GetLength(0);

            var result = new double[matrixSize, matrixSize];

            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    result[i, j] = 0;

                    for (int k = 0; k < matrixSize; k++)
                    {
                        result[i, j] += matrix1[i, k] * matrix2[k, j];
                    }
                }
            }

            return result;
        }
    }
}
