using System.Diagnostics;

namespace KnightsTour;

public class BoardManager
{
    private List<Board> Boards { get; set; } = [];
    private int Iteration { get; set; } = 0;
    private int FailedPathsCount { get; set; } = 0;
    private TimeSpan RunTime { get; set; } = TimeSpan.Zero;

    public BoardManager()
    {
        Boards.Add(new Board());
    }

    public void DepthFirstSearch()
    {
        var stopwatch = new Stopwatch();
        while (Boards.Count > 0 && !IsTourComplete())
        {
            stopwatch.Restart();
            var furthestBoard = Boards.Last();
            var nextMove = furthestBoard.GetNextMove();
            if (nextMove == null)
            {
                FailedPathsCount++;
                Boards.Remove(furthestBoard);
            }
            else
            {
                var nextBoard = new Board(furthestBoard, nextMove);
                Boards.Add(nextBoard);
            }
            Iteration++;
            if (Iteration % 1250 == 0)
                PrintCurrentBoard();
            stopwatch.Stop();
            RunTime = RunTime.Add(stopwatch.Elapsed);
        }

        PrintCurrentBoard();
        Console.WriteLine("Done 🤪🤪🤪🤪🤪");
    }

    private void PrintCurrentBoard()
    {
        if (Boards.Count == 0)
        {
            Console.WriteLine("No boards left; not tour found. ⛓️‍💥⛓️‍💥⛓️‍💥⛓️‍💥⛓️‍💥⛓️‍💥⛓️‍💥");
            return;
        }
        Console.WriteLine(Boards.Last().ToString());
        Console.WriteLine($"🎠 Iteration: {Iteration}");
        Console.WriteLine($"🏁 Boards {Boards.Count}");
        Console.WriteLine($"🗺️ Failed Paths: {FailedPathsCount}");
        Console.WriteLine($"⏳ Time Elapsed: {RunTime}");
    }

    private bool IsTourComplete()
    {
        if (Boards.FirstOrDefault(b => b.IsTourComplete()) == null) return false;
        Console.WriteLine("Complete tour found! 🚨🚨🚨🚨🚨🚨🚨🚨");
        return true;
    }
}