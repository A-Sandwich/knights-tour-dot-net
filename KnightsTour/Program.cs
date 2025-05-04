// See https://aka.ms/new-console-template for more information

using System.Text;
using KnightsTour;
Console.OutputEncoding=Encoding.UTF8;
Console.WriteLine("Hello, World!");
var manager = new BoardManager(64);
manager.DepthFirstSearch();