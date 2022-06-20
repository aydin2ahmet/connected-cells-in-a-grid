List<List<int>> matrix = new List<List<int>>() { new List<int>() { 1, 1, 0, 0, 0 }, new List<int>() { 0, 1, 1, 0, 0 }, 
                                                 new List<int>() { 0, 0, 1, 0, 1 }, new List<int>() { 1, 0, 0, 0, 1 }, 
                                                 new List<int>() { 0, 1, 0, 1, 1 } };

var result = connectedCell(matrix);

Console.WriteLine(result);

int connectedCell(List<List<int>> matrix)
{
    Dictionary<int, int> regionElementsCount = new Dictionary<int, int>();
    int lastID = 1;

    int n = matrix.Count();
    int m = matrix[0].Count();

    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < m; j++)
        {
            if (matrix[i][j] != 1)
                continue;

            lastID += 1;
            regionElementsCount[lastID] = 1;

            var stack = new Stack<(int, int)>();

            stack.Push((i, j));
            var currentIndex = (i, j);

            matrix[currentIndex.i][currentIndex.j] = lastID;

            while (stack.Count() > 0)
            {
                if (isRight1(matrix, currentIndex.i, currentIndex.j, n, m))
                {
                    stack.Push((currentIndex.i, currentIndex.j + 1));
                    matrix[currentIndex.i][currentIndex.j + 1] = lastID;
                    regionElementsCount[lastID] += 1;
                    currentIndex = (currentIndex.i, currentIndex.j + 1);
                    continue;
                }

                if (isRightBottom1(matrix, currentIndex.i, currentIndex.j, n, m))
                {
                    stack.Push((currentIndex.i + 1, currentIndex.j + 1));
                    matrix[currentIndex.i + 1][currentIndex.j + 1] = lastID;
                    regionElementsCount[lastID] += 1;
                    currentIndex = (currentIndex.i + 1, currentIndex.j + 1);
                    continue;
                }

                if (isBottom1(matrix, currentIndex.i, currentIndex.j, n, m))
                {
                    stack.Push((currentIndex.i + 1, currentIndex.j));
                    matrix[currentIndex.i + 1][currentIndex.j] = lastID;
                    regionElementsCount[lastID] += 1;
                    currentIndex = (currentIndex.i + 1, currentIndex.j);
                    continue;
                }

                if (isBottomLeft1(matrix, currentIndex.i, currentIndex.j, n, m))
                {
                    stack.Push((currentIndex.i + 1, currentIndex.j - 1));
                    matrix[currentIndex.i + 1][currentIndex.j - 1] = lastID;
                    regionElementsCount[lastID] += 1;
                    currentIndex = (currentIndex.i + 1, currentIndex.j - 1);
                    continue;
                }

                if (isLeft1(matrix, currentIndex.i, currentIndex.j, n, m))
                {
                    stack.Push((currentIndex.i, currentIndex.j - 1));
                    matrix[currentIndex.i][currentIndex.j - 1] = lastID;
                    regionElementsCount[lastID] += 1;
                    currentIndex = (currentIndex.i, currentIndex.j - 1);
                    continue;
                }

                if (isLeftTop1(matrix, currentIndex.i, currentIndex.j, n, m))
                {
                    stack.Push((currentIndex.i - 1, currentIndex.j - 1));
                    matrix[currentIndex.i - 1][currentIndex.j - 1] = lastID;
                    regionElementsCount[lastID] += 1;
                    currentIndex = (currentIndex.i - 1, currentIndex.j - 1);
                    continue;
                }

                if (isTop1(matrix, currentIndex.i, currentIndex.j, n, m))
                {
                    stack.Push((currentIndex.i - 1, currentIndex.j));
                    matrix[currentIndex.i - 1][currentIndex.j] = lastID;
                    regionElementsCount[lastID] += 1;
                    currentIndex = (currentIndex.i - 1, currentIndex.j);
                    continue;
                }

                if (isTopRight1(matrix, currentIndex.i, currentIndex.j, n, m))
                {
                    stack.Push((currentIndex.i - 1, currentIndex.j + 1));
                    matrix[currentIndex.i - 1][currentIndex.j + 1] = lastID;
                    regionElementsCount[lastID] += 1;
                    currentIndex = (currentIndex.i - 1, currentIndex.j + 1);
                    continue;
                }

                currentIndex = stack.Pop();
            }
        }
    }

    var max = 0;

    foreach (var i in regionElementsCount)
    {
        if (max < i.Value)
            max = i.Value;
    }

    return max;
}

bool isRight1(List<List<int>> matrix, int i, int j, int n, int m)
{
    if (((j + 1) < m) && matrix[i][j + 1] == 1)
        return true;

    return false;
}

bool isRightBottom1(List<List<int>> matrix, int i, int j, int n, int m)
{
    if (((j + 1) < m) && ((i + 1) < n) && matrix[i + 1][j + 1] == 1)
        return true;

    return false;
}

bool isBottom1(List<List<int>> matrix, int i, int j, int n, int m)
{
    if (((i + 1) < n) && matrix[i + 1][j] == 1)
        return true;

    return false;
}

bool isBottomLeft1(List<List<int>> matrix, int i, int j, int n, int m)
{
    if (((i + 1) < n) && ((j - 1) >= 0) && matrix[i + 1][j - 1] == 1)
        return true;

    return false;
}

bool isLeft1(List<List<int>> matrix, int i, int j, int n, int m)
{
    if (((j - 1) >= 0) && matrix[i][j - 1] == 1)
        return true;

    return false;
}

bool isLeftTop1(List<List<int>> matrix, int i, int j, int n, int m)
{
    if (((i - 1) >= 0) && ((j - 1) >= 0) && matrix[i - 1][j - 1] == 1)
        return true;

    return false;
}

bool isTop1(List<List<int>> matrix, int i, int j, int n, int m)
{
    if (((i - 1) >= 0) && matrix[i - 1][j] == 1)
        return true;

    return false;
}

bool isTopRight1(List<List<int>> matrix, int i, int j, int n, int m)
{
    if (((j + 1) < m) && ((i - 1) >= 0) && matrix[i - 1][j + 1] == 1)
        return true;

    return false;
}