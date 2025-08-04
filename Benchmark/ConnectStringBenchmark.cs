// For _dartboardList variable, that is initialized during Setup()
#pragma warning disable CS8618

using BenchmarkDotNet.Attributes;

namespace Benchmark;

[MemoryDiagnoser]
public class ConnectStringBenchmark
{
    private List<Dartboard> _dartboardList;

    [GlobalSetup]
    public void Setup()
    {
        _dartboardList = Enum.GetValues<Dartboard>().ToList();
    }

    [Benchmark]
    public string StringInterpolationViaForEach()
    {
        string result = "|";
        _dartboardList.ForEach(point => result = $"{result} {point.ToString()} |");
        return result;
    }

    [Benchmark]
    public string StackAllocWithSpan()
    {
        int size = 0;
        foreach (var dartboard in _dartboardList)
        {
            if (((int)dartboard >= 0 && (int)dartboard <= 8) ||
                ((int)dartboard >= 21 && (int)dartboard <= 29) ||
                ((int)dartboard >= 42 && (int)dartboard <= 50))
                size += 2;
            else
                size += 3;

            size += 3;
        }

        Span<char> result = stackalloc char[size];

        Span<char> emptyCharacter = stackalloc char[1];
        emptyCharacter[0] = ' ';

        Span<char> barCharacter = stackalloc char[1];
        barCharacter[0] = '|';

        barCharacter.CopyTo(result);

        int spanIndex = 1;

        foreach (var dartboard in _dartboardList)
        {
            if (dartboard is Dartboard.None or Dartboard.X)
                continue;

            emptyCharacter.CopyTo(result.Slice(spanIndex));
            spanIndex++;
            dartboard.ToString().AsSpan().CopyTo(result.Slice(spanIndex));

            if (((int)dartboard >= 0 && (int)dartboard <= 8) ||
                ((int)dartboard >= 21 && (int)dartboard <= 29) ||
                ((int)dartboard >= 42 && (int)dartboard <= 50))
                spanIndex += 2;
            else
                spanIndex += 3;

            emptyCharacter.CopyTo(result.Slice(spanIndex));
            spanIndex++;
            barCharacter.CopyTo(result.Slice(spanIndex));
            spanIndex++;
        }

        return new string(result);
    }

    [Benchmark]
    public string StackAllocWithSpanLinq()
    {
        int size = 0;
        foreach (var dartboard in _dartboardList)
        {
            if (((int)dartboard >= 0 && (int)dartboard <= 8) ||
                ((int)dartboard >= 21 && (int)dartboard <= 29) ||
                ((int)dartboard >= 42 && (int)dartboard <= 50))
                size += 2;
            else
                size += 3;

            size += 3;
        }

        Span<char> result = stackalloc char[size];

        Span<char> emptyCharacter = stackalloc char[1];
        emptyCharacter[0] = ' ';

        Span<char> barCharacter = stackalloc char[1];
        barCharacter[0] = '|';

        barCharacter.CopyTo(result);

        int spanIndex = 1;

        foreach (var dartboard in _dartboardList.Where(dartboard => dartboard != Dartboard.None && dartboard != Dartboard.X))
        {
            emptyCharacter.CopyTo(result.Slice(spanIndex));
            spanIndex++;
            dartboard.ToString().AsSpan().CopyTo(result.Slice(spanIndex));

            if (((int)dartboard >= 0 && (int)dartboard <= 8) ||
                ((int)dartboard >= 21 && (int)dartboard <= 29) ||
                ((int)dartboard >= 42 && (int)dartboard <= 50))
                spanIndex += 2;
            else
                spanIndex += 3;

            emptyCharacter.CopyTo(result.Slice(spanIndex));
            spanIndex++;
            barCharacter.CopyTo(result.Slice(spanIndex));
            spanIndex++;
        }

        return new string(result);
    }

    [Benchmark]
    public string StackAllocWithSpanRangeIndexer()
    {
        int size = 0;
        foreach (var dartboard in _dartboardList)
        {
            if (((int)dartboard >= 0 && (int)dartboard <= 8) ||
                ((int)dartboard >= 21 && (int)dartboard <= 29) ||
                ((int)dartboard >= 42 && (int)dartboard <= 50))
                size += 2;
            else
                size += 3;

            size += 3;
        }

        Span<char> result = stackalloc char[size];

        Span<char> emptyCharacter = stackalloc char[1];
        emptyCharacter[0] = ' ';

        Span<char> barCharacter = stackalloc char[1];
        barCharacter[0] = '|';

        barCharacter.CopyTo(result);

        int spanIndex = 1;

        foreach (var dartboard in _dartboardList)
        {
            if (dartboard is Dartboard.None or Dartboard.X)
                continue;

            emptyCharacter.CopyTo(result[spanIndex..]);
            spanIndex++;
            dartboard.ToString().AsSpan().CopyTo(result[spanIndex..]);

            if (((int)dartboard >= 0 && (int)dartboard <= 8) ||
                ((int)dartboard >= 21 && (int)dartboard <= 29) ||
                ((int)dartboard >= 42 && (int)dartboard <= 50))
                spanIndex += 2;
            else
                spanIndex += 3;

            emptyCharacter.CopyTo(result[spanIndex..]);
            spanIndex++;
            barCharacter.CopyTo(result[spanIndex..]);
            spanIndex++;
        }

        return new string(result);
    }

    [Benchmark]
    public string StackAllocWithSpanLinqRangeIndexer()
    {
        int size = 0;
        foreach (var dartboard in _dartboardList)
        {
            if (((int)dartboard >= 0 && (int)dartboard <= 8) ||
                ((int)dartboard >= 21 && (int)dartboard <= 29) ||
                ((int)dartboard >= 42 && (int)dartboard <= 50))
                size += 2;
            else
                size += 3;

            size += 3;
        }

        Span<char> result = stackalloc char[size];

        Span<char> emptyCharacter = stackalloc char[1];
        emptyCharacter[0] = ' ';

        Span<char> barCharacter = stackalloc char[1];
        barCharacter[0] = '|';

        barCharacter.CopyTo(result);

        int spanIndex = 1;

        foreach (var dartboard in _dartboardList.Where(dartboard => dartboard is not (Dartboard.None or Dartboard.X)))
        {
            emptyCharacter.CopyTo(result[spanIndex..]);
            spanIndex++;
            dartboard.ToString().AsSpan().CopyTo(result[spanIndex..]);

            if (((int)dartboard >= 0 && (int)dartboard <= 8) ||
                ((int)dartboard >= 21 && (int)dartboard <= 29) ||
                ((int)dartboard >= 42 && (int)dartboard <= 50))
                spanIndex += 2;
            else
                spanIndex += 3;

            emptyCharacter.CopyTo(result[spanIndex..]);
            spanIndex++;
            barCharacter.CopyTo(result[spanIndex..]);
            spanIndex++;
        }

        return new string(result);
    }
}
