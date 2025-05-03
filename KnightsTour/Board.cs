namespace KnightsTour;

public class Board
{
    private int BoardSize { get; set; }
    private int[,] Cells { get; set; } // default is to initialize with zeros
    private int NumberOfMovesMade { get; set; } = 1;
    private Tuple<int, int> LastMove { get; set; }
    private List<Tuple<int, int>> PossibleMoves { get; set; }

    public Board(int boardSize = 5)
    {
        BoardSize = boardSize;
        Cells = new int[BoardSize, BoardSize];
        Cells[0, 0] = NumberOfMovesMade;
        LastMove = new Tuple<int, int>(0, 0);
        PossibleMoves = GetPossibleMoves(LastMove);
    }

    public Board(Board board, Tuple<int, int> nextMove)
    {
        BoardSize = board.BoardSize;
        Cells = new int[BoardSize, BoardSize];
        Array.Copy(board.Cells, Cells, Cells.Length);
        NumberOfMovesMade = board.NumberOfMovesMade + 1;
        Cells[nextMove.Item1, nextMove.Item2] = NumberOfMovesMade;
        LastMove = nextMove;
        PossibleMoves = GetPossibleMoves(LastMove);
    }

    public Tuple<int, int>? GetNextMove()
    {
        PossibleMoves = PossibleMoves.Where(IsMoveValid).ToList();
        Tuple<int, int> selectedMove = null;
        var numberOfPossibleMoves = Int32.MaxValue;
        foreach (var possibleMove in PossibleMoves)
        {
            var movesFromLocation = GetPossibleMoves(possibleMove);
            movesFromLocation = movesFromLocation.Where(IsMoveValid).ToList();
            if (movesFromLocation.Count() < numberOfPossibleMoves)
            {
                numberOfPossibleMoves = movesFromLocation.Count();
                selectedMove = possibleMove;
            }
        }
        
        if (selectedMove != null)
            PossibleMoves.Remove(selectedMove);
        
        return selectedMove;
    }

    private bool IsMoveValid(Tuple<int, int> move)
    {
        if (move.Item1 >= BoardSize || move.Item1 < 0)
            return false;
        if (move.Item2 >= BoardSize || move.Item2 < 0)
            return false;

        if (Cells[move.Item1, move.Item2] != 0)
            return false;
        
        return true;
    }

    public override string ToString()
    {
        var index = 0;
        var result = "";
        foreach (var cell in Cells)
        {
            if (index % BoardSize == 0)
                result += "\n";
            result +=$"{cell:D2}|";
            index++;
        }
        return result;
    }

    public bool IsTourComplete()
    {
        return Cells.Cast<int>().All(cell => cell != 0);
    }
    
    private List<Tuple<int, int>> GetPossibleMoves(Tuple<int, int> move)
    {
        return
        [
            // right
            new Tuple<int, int>(move.Item1 + 2, move.Item2 + 1),
            new Tuple<int, int>(move.Item1 + 2, move.Item2 - 1),

            // left
            new Tuple<int, int>(move.Item1 - 2, move.Item2 - 1),
            new Tuple<int, int>(move.Item1 - 2, move.Item2 + 1),

            // down
            new Tuple<int, int>(move.Item1 + 1, move.Item2 + 2),
            new Tuple<int, int>(move.Item1 - 1, move.Item2 + 2),

            // up
            new Tuple<int, int>(move.Item1 - 1, move.Item2 - 2),
            new Tuple<int, int>(move.Item1 + 1, move.Item2 - 2)
        ];
    }
}