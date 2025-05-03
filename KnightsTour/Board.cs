namespace KnightsTour;

public class Board
{
    private int BoardSize { get; set; }
    private int [,] Cells { get; set; } // default is to initialize with zeros
    private int NumberOfMovesMade { get; set; }
    private Tuple<int, int> LastMoveIndex { get; set; }
    private Tuple<int, int> LastMove { get; set; }
    private List<Tuple<int, int>> PossibleMoves { get; set; }

    public Board(int boardSize = 5)
    {
        BoardSize = boardSize;
        Cells = new int[BoardSize, BoardSize];
        LastMove = new Tuple<int, int>(0, 0);
        PossibleMoves = GetPossibleMoves();
    }

    private List<Tuple<int, int>> GetPossibleMoves()
    {
        return
        [
            // right
            new Tuple<int, int>(LastMove.Item1 + 2, LastMove.Item2 + 1),
            new Tuple<int, int>(LastMove.Item1 + 2, LastMove.Item2 - 1),

            // left
            new Tuple<int, int>(LastMove.Item1 - 2, LastMove.Item2 - 1),
            new Tuple<int, int>(LastMove.Item1 - 2, LastMove.Item2 + 1),

            // down
            new Tuple<int, int>(LastMove.Item1 + 1, LastMove.Item2 + 2),
            new Tuple<int, int>(LastMove.Item1 - 1, LastMove.Item2 + 2),

            // up
            new Tuple<int, int>(LastMove.Item1 - 1, LastMove.Item2 - 2),
            new Tuple<int, int>(LastMove.Item1 + 1, LastMove.Item2 - 2)
        ];
    }
}