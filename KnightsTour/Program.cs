// See https://aka.ms/new-console-template for more information

using KnightsTour;

Console.WriteLine("Hello, World!");
var manager = new BoardManager(64);
manager.DepthFirstSearch();