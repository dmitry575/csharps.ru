using BenchmarkDotNet.Running;
using EmptyList;

//var resultNew = BenchmarkRunner.Run<TestListNew>();
//var resultList = BenchmarkRunner.Run<TestList>();
var resultEmptyStatic = BenchmarkRunner.Run<TestListEmptyStatic>();
Console.WriteLine(resultEmptyStatic?.Reports);
//var resultEmpty = BenchmarkRunner.Run<TestListEmpty>();

