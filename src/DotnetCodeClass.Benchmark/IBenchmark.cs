namespace DotnetCodeClass.Benchmark
{
    public interface IBenchmark
    {
        bool IsEnabled();
        void Run();
    }
}
