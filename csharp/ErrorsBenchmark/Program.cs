using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace ErrorsBenchmark;

public class ErrorHandlingBenchmark

{
    private const int TotalOperations = 100_000;

    [Benchmark]
    public void UsingExceptions()
    {
        for (int i = 0; i < TotalOperations; i++)
        {
            try
            {
                SimulateOperation(i % 10 == 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro {Message}", ex.Message);
            }
        }
    }

    [Benchmark]
    public void UsingSpecialReturnValue()
    {
        for (int i = 0; i < TotalOperations; i++)
        {
            var result = SimulateOperationWithReturn(i % 10 == 0);
            if (result == -1)
            {
                Console.WriteLine("Erro {result}", result);
            }
        }
    }

    [Benchmark]
    public void UsingResponseObject()
    {
        for (int i = 0; i < TotalOperations; i++)
        {
            var response = SimulateOperationWithResponse(i % 10 == 0); // 10% de erros
            if (!response.Success)
            {
                Console.WriteLine("Erro {Error}", response.Error);
            }
        }
    }

    private void SimulateOperation(bool throwError)
    {
        if (throwError)
        {
            throw new Exception("Erro simulado");
        }
    }

    private int SimulateOperationWithReturn(bool returnError)
    {
        return returnError ? -1 : 42;
    }

    private Response SimulateOperationWithResponse(bool returnError)
    {
        if (returnError)
        {
            return new Response { Success = false, Error = "Erro simulado" };
        }
        return new Response { Success = true, Result = 42 };
    }

    public class Response
    {
        public bool Success { get; set; }
        public string Error { get; set; }
        public int? Result { get; set; }
    }
}

public class Program
{
    static void Main(string[] args)
    {
        BenchmarkRunner.Run<ErrorHandlingBenchmark>();
    }
}