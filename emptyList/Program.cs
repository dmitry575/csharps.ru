using BenchmarkDotNet.Running;
using EmptyList;

//var resultNew = BenchmarkRunner.Run<TestListNew>();
//var resultList = BenchmarkRunner.Run<TestList>();
var resultEmty = BenchmarkRunner.Run<TestListEmpty>();
//var resultEmptyStatic = BenchmarkRunner.Run<TestListEmpty>();
