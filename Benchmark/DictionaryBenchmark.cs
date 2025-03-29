using System.Collections.Frozen;
using System.Collections.ObjectModel;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters.Csv;

namespace Benchmark;

internal enum Dartboard
{
    None = -1,
    S1,
    S2,
    S3,
    S4,
    S5,
    S6,
    S7,
    S8,
    S9,
    S10,
    S11,
    S12,
    S13,
    S14,
    S15,
    S16,
    S17,
    S18,
    S19,
    S20,
    S25,
    D1,
    D2,
    D3,
    D4,
    D5,
    D6,
    D7,
    D8,
    D9,
    D10,
    D11,
    D12,
    D13,
    D14,
    D15,
    D16,
    D17,
    D18,
    D19,
    D20,
    D25,
    T1,
    T2,
    T3,
    T4,
    T5,
    T6,
    T7,
    T8,
    T9,
    T10,
    T11,
    T12,
    T13,
    T14,
    T15,
    T16,
    T17,
    T18,
    T19,
    T20,
    X
}

public class CustomConfig : ManualConfig
{
    public CustomConfig()
    {
        AddExporter(CsvMeasurementsExporter.Default);
        // AddExporter(RPlotExporter.Default);
    }
}

[MemoryDiagnoser]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
[Config(typeof(CustomConfig))]
public class DictionaryBenchmark
{
    private readonly ReadOnlyCollection<Dictionary<Dartboard, int>> _rowButtonsData = new List<Dictionary<Dartboard, int>>
    {
        new()
        {
            { Dartboard.S1, 1 }, { Dartboard.S2, 2 }, { Dartboard.S3, 3 }, { Dartboard.S4, 4 }, { Dartboard.S5, 5 },
            { Dartboard.S6, 6 }, { Dartboard.S7, 7 }, { Dartboard.S8, 8 }, { Dartboard.S9, 9 }, { Dartboard.S10, 10 },
            { Dartboard.S11, 11 }, { Dartboard.S12, 12 }, { Dartboard.S13, 13 }, { Dartboard.S14, 14 }, { Dartboard.S15, 15 },
            { Dartboard.S16, 16 }, { Dartboard.S17, 17 }, { Dartboard.S18, 18 }, { Dartboard.S19, 19 }, { Dartboard.S20, 20 }, { Dartboard.S25, 25 }
        },
        new()
        {
            { Dartboard.D1, 2 }, { Dartboard.D2, 4 }, { Dartboard.D3, 6 }, { Dartboard.D4, 8 }, { Dartboard.D5, 10 },
            { Dartboard.D6, 12 }, { Dartboard.D7, 14 }, { Dartboard.D8, 16 }, { Dartboard.D9, 18 }, { Dartboard.D10, 20 },
            { Dartboard.D11, 22 }, { Dartboard.D12, 24 }, { Dartboard.D13, 26 }, { Dartboard.D14, 28 }, { Dartboard.D15, 30 },
            { Dartboard.D16, 32 }, { Dartboard.D17, 34 }, { Dartboard.D18, 36 }, { Dartboard.D19, 38 }, { Dartboard.D20, 40 }, { Dartboard.D25, 50 }
        },
        new()
        {
            { Dartboard.T1, 3 }, { Dartboard.T2, 6 }, { Dartboard.T3, 9 }, { Dartboard.T4, 12 }, { Dartboard.T5, 15 },
            { Dartboard.T6, 18 }, { Dartboard.T7, 21 }, { Dartboard.T8, 24 }, { Dartboard.T9, 27 }, { Dartboard.T10, 30 },
            { Dartboard.T11, 33 }, { Dartboard.T12, 36 }, { Dartboard.T13, 39 }, { Dartboard.T14, 42 }, { Dartboard.T15, 45 },
            { Dartboard.T16, 48 }, { Dartboard.T17, 51 }, { Dartboard.T18, 54 }, { Dartboard.T19, 57 }, { Dartboard.T20, 60 }, { Dartboard.X, 0 }
        }
    }.AsReadOnly();

    private readonly ReadOnlyCollection<FrozenDictionary<Dartboard, int>> _halfFrozenRowButtonsData =
        new List<FrozenDictionary<Dartboard, int>>{
            new Dictionary<Dartboard, int>
            {
                { Dartboard.S1, 1 }, { Dartboard.S2, 2 }, { Dartboard.S3, 3 }, { Dartboard.S4, 4 }, { Dartboard.S5, 5 },
                { Dartboard.S6, 6 }, { Dartboard.S7, 7 }, { Dartboard.S8, 8 }, { Dartboard.S9, 9 }, { Dartboard.S10, 10 },
                { Dartboard.S11, 11 }, { Dartboard.S12, 12 }, { Dartboard.S13, 13 }, { Dartboard.S14, 14 }, { Dartboard.S15, 15 },
                { Dartboard.S16, 16 }, { Dartboard.S17, 17 }, { Dartboard.S18, 18 }, { Dartboard.S19, 19 }, { Dartboard.S20, 20 }, { Dartboard.S25, 25 }
            }.ToFrozenDictionary(),
            new Dictionary<Dartboard, int>
            {
                { Dartboard.D1, 2 }, { Dartboard.D2, 4 }, { Dartboard.D3, 6 }, { Dartboard.D4, 8 }, { Dartboard.D5, 10 },
                { Dartboard.D6, 12 }, { Dartboard.D7, 14 }, { Dartboard.D8, 16 }, { Dartboard.D9, 18 }, { Dartboard.D10, 20 },
                { Dartboard.D11, 22 }, { Dartboard.D12, 24 }, { Dartboard.D13, 26 }, { Dartboard.D14, 28 }, { Dartboard.D15, 30 },
                { Dartboard.D16, 32 }, { Dartboard.D17, 34 }, { Dartboard.D18, 36 }, { Dartboard.D19, 38 }, { Dartboard.D20, 40 }, { Dartboard.D25, 50 }
            }.ToFrozenDictionary(),
            new Dictionary<Dartboard, int>
            {
                { Dartboard.T1, 3 }, { Dartboard.T2, 6 }, { Dartboard.T3, 9 }, { Dartboard.T4, 12 }, { Dartboard.T5, 15 },
                { Dartboard.T6, 18 }, { Dartboard.T7, 21 }, { Dartboard.T8, 24 }, { Dartboard.T9, 27 }, { Dartboard.T10, 30 },
                { Dartboard.T11, 33 }, { Dartboard.T12, 36 }, { Dartboard.T13, 39 }, { Dartboard.T14, 42 }, { Dartboard.T15, 45 },
                { Dartboard.T16, 48 }, { Dartboard.T17, 51 }, { Dartboard.T18, 54 }, { Dartboard.T19, 57 }, { Dartboard.T20, 60 }, { Dartboard.X, 0 }
            }.ToFrozenDictionary()
        }.AsReadOnly();

    private readonly FrozenSet<FrozenDictionary<Dartboard, int>> _frozenRowButtonsData =
        new List<FrozenDictionary<Dartboard, int>>{
            new Dictionary<Dartboard, int>
            {
                { Dartboard.S1, 1 }, { Dartboard.S2, 2 }, { Dartboard.S3, 3 }, { Dartboard.S4, 4 }, { Dartboard.S5, 5 },
                { Dartboard.S6, 6 }, { Dartboard.S7, 7 }, { Dartboard.S8, 8 }, { Dartboard.S9, 9 }, { Dartboard.S10, 10 },
                { Dartboard.S11, 11 }, { Dartboard.S12, 12 }, { Dartboard.S13, 13 }, { Dartboard.S14, 14 }, { Dartboard.S15, 15 },
                { Dartboard.S16, 16 }, { Dartboard.S17, 17 }, { Dartboard.S18, 18 }, { Dartboard.S19, 19 }, { Dartboard.S20, 20 }, { Dartboard.S25, 25 }
            }.ToFrozenDictionary(),
            new Dictionary<Dartboard, int>
            {
                { Dartboard.D1, 2 }, { Dartboard.D2, 4 }, { Dartboard.D3, 6 }, { Dartboard.D4, 8 }, { Dartboard.D5, 10 },
                { Dartboard.D6, 12 }, { Dartboard.D7, 14 }, { Dartboard.D8, 16 }, { Dartboard.D9, 18 }, { Dartboard.D10, 20 },
                { Dartboard.D11, 22 }, { Dartboard.D12, 24 }, { Dartboard.D13, 26 }, { Dartboard.D14, 28 }, { Dartboard.D15, 30 },
                { Dartboard.D16, 32 }, { Dartboard.D17, 34 }, { Dartboard.D18, 36 }, { Dartboard.D19, 38 }, { Dartboard.D20, 40 }, { Dartboard.D25, 50 }
            }.ToFrozenDictionary(),
            new Dictionary<Dartboard, int>
            {
                { Dartboard.T1, 3 }, { Dartboard.T2, 6 }, { Dartboard.T3, 9 }, { Dartboard.T4, 12 }, { Dartboard.T5, 15 },
                { Dartboard.T6, 18 }, { Dartboard.T7, 21 }, { Dartboard.T8, 24 }, { Dartboard.T9, 27 }, { Dartboard.T10, 30 },
                { Dartboard.T11, 33 }, { Dartboard.T12, 36 }, { Dartboard.T13, 39 }, { Dartboard.T14, 42 }, { Dartboard.T15, 45 },
                { Dartboard.T16, 48 }, { Dartboard.T17, 51 }, { Dartboard.T18, 54 }, { Dartboard.T19, 57 }, { Dartboard.T20, 60 }, { Dartboard.X, 0 }
            }.ToFrozenDictionary()
        }.ToFrozenSet();

    private readonly FrozenDictionary<Dartboard, int> _frozenDict = new Dictionary<Dartboard, int>
    {
        { Dartboard.S1, 1 }, { Dartboard.S2, 2 }, { Dartboard.S3, 3 }, { Dartboard.S4, 4 }, { Dartboard.S5, 5 },
        { Dartboard.S6, 6 }, { Dartboard.S7, 7 }, { Dartboard.S8, 8 }, { Dartboard.S9, 9 }, { Dartboard.S10, 10 },
        { Dartboard.S11, 11 }, { Dartboard.S12, 12 }, { Dartboard.S13, 13 }, { Dartboard.S14, 14 },
        { Dartboard.S15, 15 },
        { Dartboard.S16, 16 }, { Dartboard.S17, 17 }, { Dartboard.S18, 18 }, { Dartboard.S19, 19 },
        { Dartboard.S20, 20 }, { Dartboard.S25, 25 },
        { Dartboard.D1, 2 }, { Dartboard.D2, 4 }, { Dartboard.D3, 6 }, { Dartboard.D4, 8 }, { Dartboard.D5, 10 },
        { Dartboard.D6, 12 }, { Dartboard.D7, 14 }, { Dartboard.D8, 16 }, { Dartboard.D9, 18 }, { Dartboard.D10, 20 },
        { Dartboard.D11, 22 }, { Dartboard.D12, 24 }, { Dartboard.D13, 26 }, { Dartboard.D14, 28 },
        { Dartboard.D15, 30 },
        { Dartboard.D16, 32 }, { Dartboard.D17, 34 }, { Dartboard.D18, 36 }, { Dartboard.D19, 38 },
        { Dartboard.D20, 40 }, { Dartboard.D25, 50 },
        { Dartboard.T1, 3 }, { Dartboard.T2, 6 }, { Dartboard.T3, 9 }, { Dartboard.T4, 12 }, { Dartboard.T5, 15 },
        { Dartboard.T6, 18 }, { Dartboard.T7, 21 }, { Dartboard.T8, 24 }, { Dartboard.T9, 27 }, { Dartboard.T10, 30 },
        { Dartboard.T11, 33 }, { Dartboard.T12, 36 }, { Dartboard.T13, 39 }, { Dartboard.T14, 42 },
        { Dartboard.T15, 45 },
        { Dartboard.T16, 48 }, { Dartboard.T17, 51 }, { Dartboard.T18, 54 }, { Dartboard.T19, 57 },
        { Dartboard.T20, 60 }, { Dartboard.X, 0 }
    }.ToFrozenDictionary();

    private readonly int[] _pointsArray =
    [
        1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 25,
        2, 4, 6, 8, 10, 12, 14, 16, 18, 20, 22, 24, 26, 28, 30, 32, 34, 36, 38, 40, 50,
        3, 6, 9, 12, 15, 18, 21, 24, 27, 30, 33, 36, 39, 42, 45, 48, 51, 54, 57, 60, 0
    ];

    private Dartboard _dartboardValue;

    [GlobalSetup]
    public void Setup()
    {
        var number = new Random(500).Next(-1, 63);
        _dartboardValue = (Dartboard)number;
    }

    #region Dictionary

    [Benchmark]
    [BenchmarkCategory("Dictionary")]
    public int ForEachLoop_ReadOnlyCollection_Dictionary()
    {
        int result = 0;
        foreach (var dict in _rowButtonsData)
        {
            foreach (var value in dict)
            {
                result += value.Value;
            }
        }

        return result;
    }

    [Benchmark]
    [BenchmarkCategory("Dictionary")]
    public int ForLoop_ReadOnlyCollection_Dictionary()
    {
        int result = 0;
        for (int i = 0; i < 3; i++)
        {
            foreach (var value in _rowButtonsData[i])
            {
                result += value.Value;
            }
        }

        return result;
    }

    [Benchmark]
    [BenchmarkCategory("Dictionary")]
    public int TryGetValue_ReadOnlyCollection_Dictionary()
    {
        foreach (var dict in _rowButtonsData)
        {
            if (dict.TryGetValue(_dartboardValue, out var result))
                return result;
        }

        return -1;
    }

    [Benchmark]
    [BenchmarkCategory("Dictionary")]
    public bool IsDouble_ReadOnlyCollection_Dictionary()
    {
        return _rowButtonsData[1].TryGetValue(_dartboardValue, out _);
    }

    #endregion

    #region Half Frozen

    [Benchmark]
    [BenchmarkCategory("Half Frozen")]
    public int ForEachLoop_ReadOnlyCollection_FrozenDictionary()
    {
        int result = 0;
        foreach (var dict in _halfFrozenRowButtonsData)
        {
            foreach (var value in dict)
            {
                result += value.Value;
            }
        }

        return result;
    }

    [Benchmark]
    [BenchmarkCategory("Half Frozen")]
    public int ForLoop_ReadOnlyCollection_FrozenDictionary()
    {
        int result = 0;
        for (int i = 0; i < 3; i++)
        {
            foreach (var value in _halfFrozenRowButtonsData[i])
            {
                result += value.Value;
            }
        }

        return result;
    }

    [Benchmark]
    [BenchmarkCategory("Half Frozen")]
    public int TryGetValue_ReadOnlyCollection_FrozenDictionary()
    {
        foreach (var dict in _halfFrozenRowButtonsData)
        {
            if (dict.TryGetValue(_dartboardValue, out var result))
                return result;
        }

        return -1;
    }

    [Benchmark]
    [BenchmarkCategory("Half Frozen")]
    public bool IsDouble_ReadOnlyCollection_FrozenDictionary()
    {
        return _halfFrozenRowButtonsData[1].TryGetValue(_dartboardValue, out _);
    }

    #endregion

    #region Frozen

    [Benchmark]
    [BenchmarkCategory("Frozen")]
    public int ForEachLoop_FrozenSet_FrozenDictionary()
    {
        int result = 0;
        foreach (var dict in _frozenRowButtonsData)
        {
            foreach (var value in dict)
            {
                result += value.Value;
            }
        }

        return result;
    }

    [Benchmark]
    [BenchmarkCategory("Frozen")]
    public int ForLoop_FrozenSet_FrozenDictionary()
    {
        int result = 0;
        for (int i = 0; i < 3; i++)
        {
            foreach (var value in _frozenRowButtonsData.Items[i])
            {
                result += value.Value;
            }
        }

        return result;
    }

    [Benchmark]
    [BenchmarkCategory("Frozen")]
    public int TryGetValue_FrozenSet_FrozenDictionary()
    {
        foreach (var dict in _frozenRowButtonsData)
        {
            if (dict.TryGetValue(_dartboardValue, out var result))
                return result;
        }

        return -1;
    }

    [Benchmark]
    [BenchmarkCategory("Frozen")]
    public bool IsDouble_FrozenSet_FrozenDictionary()
    {
        return _frozenRowButtonsData.Items[1].TryGetValue(_dartboardValue, out _);
    }

    #endregion

    #region Frozen Dict

    [Benchmark]
    [BenchmarkCategory("Frozen Dictionary")]
    public int ForEachLoop_FrozenDictionary()
    {
        int result = 0;
        foreach (var value in _frozenDict)
        {
            result += value.Value;
        }

        return result;
    }

    // DON'T TRY THAT :)
    // [Benchmark]
    // public int ForLoop_FrozenDictionary()
    // {
    //     int result = 0;
    //     for (int i = 0; i < 63; i++)
    //     {
    //         result += _frozenDict.ElementAt(i).Value;
    //     }
    //
    //     return result;
    // }

    [Benchmark]
    [BenchmarkCategory("Frozen Dictionary")]
    public int TryGetValue_FrozenDictionary()
    {
        if (_frozenDict.TryGetValue(_dartboardValue, out var result))
            return result;

        return -1;
    }

    #endregion

    #region Array

    [Benchmark]
    [BenchmarkCategory("Array")]
    public int ForEachLoop_Array()
    {
        int result = 0;
        foreach (var value in _pointsArray)
            result += value;

        return result;
    }

    [Benchmark]
    [BenchmarkCategory("Array")]
    public int ForLoop_Array()
    {
        int result = 0;
        for (int i = 0; i < 63; i++)
            result += _pointsArray[i];

        return result;
    }

    [Benchmark]
    [BenchmarkCategory("Array")]
    public int TryGetValue_Array()
    {
        return _pointsArray[(int)_dartboardValue];
    }

    #endregion

    // Used for both Array and single dictionary approach
    [Benchmark]
    [BenchmarkCategory("IfStatement")]
    public bool IsDouble_IfStatement()
    {
        return (int)_dartboardValue > 20 && (int)_dartboardValue < 42;
    }
}

[MemoryDiagnoser]
[Config(typeof(CustomConfig))]
public class DictionaryBenchmark_ForEach
{
    private readonly ReadOnlyCollection<Dictionary<Dartboard, int>> _rowButtonsData = new List<Dictionary<Dartboard, int>>
    {
        new()
        {
            { Dartboard.S1, 1 }, { Dartboard.S2, 2 }, { Dartboard.S3, 3 }, { Dartboard.S4, 4 }, { Dartboard.S5, 5 },
            { Dartboard.S6, 6 }, { Dartboard.S7, 7 }, { Dartboard.S8, 8 }, { Dartboard.S9, 9 }, { Dartboard.S10, 10 },
            { Dartboard.S11, 11 }, { Dartboard.S12, 12 }, { Dartboard.S13, 13 }, { Dartboard.S14, 14 }, { Dartboard.S15, 15 },
            { Dartboard.S16, 16 }, { Dartboard.S17, 17 }, { Dartboard.S18, 18 }, { Dartboard.S19, 19 }, { Dartboard.S20, 20 }, { Dartboard.S25, 25 }
        },
        new()
        {
            { Dartboard.D1, 2 }, { Dartboard.D2, 4 }, { Dartboard.D3, 6 }, { Dartboard.D4, 8 }, { Dartboard.D5, 10 },
            { Dartboard.D6, 12 }, { Dartboard.D7, 14 }, { Dartboard.D8, 16 }, { Dartboard.D9, 18 }, { Dartboard.D10, 20 },
            { Dartboard.D11, 22 }, { Dartboard.D12, 24 }, { Dartboard.D13, 26 }, { Dartboard.D14, 28 }, { Dartboard.D15, 30 },
            { Dartboard.D16, 32 }, { Dartboard.D17, 34 }, { Dartboard.D18, 36 }, { Dartboard.D19, 38 }, { Dartboard.D20, 40 }, { Dartboard.D25, 50 }
        },
        new()
        {
            { Dartboard.T1, 3 }, { Dartboard.T2, 6 }, { Dartboard.T3, 9 }, { Dartboard.T4, 12 }, { Dartboard.T5, 15 },
            { Dartboard.T6, 18 }, { Dartboard.T7, 21 }, { Dartboard.T8, 24 }, { Dartboard.T9, 27 }, { Dartboard.T10, 30 },
            { Dartboard.T11, 33 }, { Dartboard.T12, 36 }, { Dartboard.T13, 39 }, { Dartboard.T14, 42 }, { Dartboard.T15, 45 },
            { Dartboard.T16, 48 }, { Dartboard.T17, 51 }, { Dartboard.T18, 54 }, { Dartboard.T19, 57 }, { Dartboard.T20, 60 }, { Dartboard.X, 0 }
        }
    }.AsReadOnly();

    private readonly ReadOnlyCollection<FrozenDictionary<Dartboard, int>> _halfFrozenRowButtonsData =
        new List<FrozenDictionary<Dartboard, int>>{
            new Dictionary<Dartboard, int>
            {
                { Dartboard.S1, 1 }, { Dartboard.S2, 2 }, { Dartboard.S3, 3 }, { Dartboard.S4, 4 }, { Dartboard.S5, 5 },
                { Dartboard.S6, 6 }, { Dartboard.S7, 7 }, { Dartboard.S8, 8 }, { Dartboard.S9, 9 }, { Dartboard.S10, 10 },
                { Dartboard.S11, 11 }, { Dartboard.S12, 12 }, { Dartboard.S13, 13 }, { Dartboard.S14, 14 }, { Dartboard.S15, 15 },
                { Dartboard.S16, 16 }, { Dartboard.S17, 17 }, { Dartboard.S18, 18 }, { Dartboard.S19, 19 }, { Dartboard.S20, 20 }, { Dartboard.S25, 25 }
            }.ToFrozenDictionary(),
            new Dictionary<Dartboard, int>
            {
                { Dartboard.D1, 2 }, { Dartboard.D2, 4 }, { Dartboard.D3, 6 }, { Dartboard.D4, 8 }, { Dartboard.D5, 10 },
                { Dartboard.D6, 12 }, { Dartboard.D7, 14 }, { Dartboard.D8, 16 }, { Dartboard.D9, 18 }, { Dartboard.D10, 20 },
                { Dartboard.D11, 22 }, { Dartboard.D12, 24 }, { Dartboard.D13, 26 }, { Dartboard.D14, 28 }, { Dartboard.D15, 30 },
                { Dartboard.D16, 32 }, { Dartboard.D17, 34 }, { Dartboard.D18, 36 }, { Dartboard.D19, 38 }, { Dartboard.D20, 40 }, { Dartboard.D25, 50 }
            }.ToFrozenDictionary(),
            new Dictionary<Dartboard, int>
            {
                { Dartboard.T1, 3 }, { Dartboard.T2, 6 }, { Dartboard.T3, 9 }, { Dartboard.T4, 12 }, { Dartboard.T5, 15 },
                { Dartboard.T6, 18 }, { Dartboard.T7, 21 }, { Dartboard.T8, 24 }, { Dartboard.T9, 27 }, { Dartboard.T10, 30 },
                { Dartboard.T11, 33 }, { Dartboard.T12, 36 }, { Dartboard.T13, 39 }, { Dartboard.T14, 42 }, { Dartboard.T15, 45 },
                { Dartboard.T16, 48 }, { Dartboard.T17, 51 }, { Dartboard.T18, 54 }, { Dartboard.T19, 57 }, { Dartboard.T20, 60 }, { Dartboard.X, 0 }
            }.ToFrozenDictionary()
        }.AsReadOnly();

    private readonly FrozenSet<FrozenDictionary<Dartboard, int>> _frozenRowButtonsData =
        new List<FrozenDictionary<Dartboard, int>>{
            new Dictionary<Dartboard, int>
            {
                { Dartboard.S1, 1 }, { Dartboard.S2, 2 }, { Dartboard.S3, 3 }, { Dartboard.S4, 4 }, { Dartboard.S5, 5 },
                { Dartboard.S6, 6 }, { Dartboard.S7, 7 }, { Dartboard.S8, 8 }, { Dartboard.S9, 9 }, { Dartboard.S10, 10 },
                { Dartboard.S11, 11 }, { Dartboard.S12, 12 }, { Dartboard.S13, 13 }, { Dartboard.S14, 14 }, { Dartboard.S15, 15 },
                { Dartboard.S16, 16 }, { Dartboard.S17, 17 }, { Dartboard.S18, 18 }, { Dartboard.S19, 19 }, { Dartboard.S20, 20 }, { Dartboard.S25, 25 }
            }.ToFrozenDictionary(),
            new Dictionary<Dartboard, int>
            {
                { Dartboard.D1, 2 }, { Dartboard.D2, 4 }, { Dartboard.D3, 6 }, { Dartboard.D4, 8 }, { Dartboard.D5, 10 },
                { Dartboard.D6, 12 }, { Dartboard.D7, 14 }, { Dartboard.D8, 16 }, { Dartboard.D9, 18 }, { Dartboard.D10, 20 },
                { Dartboard.D11, 22 }, { Dartboard.D12, 24 }, { Dartboard.D13, 26 }, { Dartboard.D14, 28 }, { Dartboard.D15, 30 },
                { Dartboard.D16, 32 }, { Dartboard.D17, 34 }, { Dartboard.D18, 36 }, { Dartboard.D19, 38 }, { Dartboard.D20, 40 }, { Dartboard.D25, 50 }
            }.ToFrozenDictionary(),
            new Dictionary<Dartboard, int>
            {
                { Dartboard.T1, 3 }, { Dartboard.T2, 6 }, { Dartboard.T3, 9 }, { Dartboard.T4, 12 }, { Dartboard.T5, 15 },
                { Dartboard.T6, 18 }, { Dartboard.T7, 21 }, { Dartboard.T8, 24 }, { Dartboard.T9, 27 }, { Dartboard.T10, 30 },
                { Dartboard.T11, 33 }, { Dartboard.T12, 36 }, { Dartboard.T13, 39 }, { Dartboard.T14, 42 }, { Dartboard.T15, 45 },
                { Dartboard.T16, 48 }, { Dartboard.T17, 51 }, { Dartboard.T18, 54 }, { Dartboard.T19, 57 }, { Dartboard.T20, 60 }, { Dartboard.X, 0 }
            }.ToFrozenDictionary()
        }.ToFrozenSet();

    private readonly FrozenDictionary<Dartboard, int> _frozenDict = new Dictionary<Dartboard, int>
    {
        { Dartboard.S1, 1 }, { Dartboard.S2, 2 }, { Dartboard.S3, 3 }, { Dartboard.S4, 4 }, { Dartboard.S5, 5 },
        { Dartboard.S6, 6 }, { Dartboard.S7, 7 }, { Dartboard.S8, 8 }, { Dartboard.S9, 9 }, { Dartboard.S10, 10 },
        { Dartboard.S11, 11 }, { Dartboard.S12, 12 }, { Dartboard.S13, 13 }, { Dartboard.S14, 14 },
        { Dartboard.S15, 15 },
        { Dartboard.S16, 16 }, { Dartboard.S17, 17 }, { Dartboard.S18, 18 }, { Dartboard.S19, 19 },
        { Dartboard.S20, 20 }, { Dartboard.S25, 25 },
        { Dartboard.D1, 2 }, { Dartboard.D2, 4 }, { Dartboard.D3, 6 }, { Dartboard.D4, 8 }, { Dartboard.D5, 10 },
        { Dartboard.D6, 12 }, { Dartboard.D7, 14 }, { Dartboard.D8, 16 }, { Dartboard.D9, 18 }, { Dartboard.D10, 20 },
        { Dartboard.D11, 22 }, { Dartboard.D12, 24 }, { Dartboard.D13, 26 }, { Dartboard.D14, 28 },
        { Dartboard.D15, 30 },
        { Dartboard.D16, 32 }, { Dartboard.D17, 34 }, { Dartboard.D18, 36 }, { Dartboard.D19, 38 },
        { Dartboard.D20, 40 }, { Dartboard.D25, 50 },
        { Dartboard.T1, 3 }, { Dartboard.T2, 6 }, { Dartboard.T3, 9 }, { Dartboard.T4, 12 }, { Dartboard.T5, 15 },
        { Dartboard.T6, 18 }, { Dartboard.T7, 21 }, { Dartboard.T8, 24 }, { Dartboard.T9, 27 }, { Dartboard.T10, 30 },
        { Dartboard.T11, 33 }, { Dartboard.T12, 36 }, { Dartboard.T13, 39 }, { Dartboard.T14, 42 },
        { Dartboard.T15, 45 },
        { Dartboard.T16, 48 }, { Dartboard.T17, 51 }, { Dartboard.T18, 54 }, { Dartboard.T19, 57 },
        { Dartboard.T20, 60 }, { Dartboard.X, 0 }
    }.ToFrozenDictionary();

    private readonly int[] _pointsArray =
    [
        1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 25,
        2, 4, 6, 8, 10, 12, 14, 16, 18, 20, 22, 24, 26, 28, 30, 32, 34, 36, 38, 40, 50,
        3, 6, 9, 12, 15, 18, 21, 24, 27, 30, 33, 36, 39, 42, 45, 48, 51, 54, 57, 60, 0
    ];

    private Dartboard _dartboardValue;

    [GlobalSetup]
    public void Setup()
    {
        var number = new Random(500).Next(-1, 63);
        _dartboardValue = (Dartboard)number;
    }

    [Benchmark]
    public int ForEachLoop_ReadOnlyCollection_Dictionary()
    {
        int result = 0;
        foreach (var dict in _rowButtonsData)
        {
            foreach (var value in dict)
            {
                result += value.Value;
            }
        }

        return result;
    }

    [Benchmark]
    public int ForEachLoop_ReadOnlyCollection_FrozenDictionary()
    {
        int result = 0;
        foreach (var dict in _halfFrozenRowButtonsData)
        {
            foreach (var value in dict)
            {
                result += value.Value;
            }
        }

        return result;
    }

    [Benchmark]
    public int ForEachLoop_FrozenSet_FrozenDictionary()
    {
        int result = 0;
        foreach (var dict in _frozenRowButtonsData)
        {
            foreach (var value in dict)
            {
                result += value.Value;
            }
        }

        return result;
    }

    [Benchmark]
    public int ForEachLoop_FrozenDictionary()
    {
        int result = 0;
        foreach (var value in _frozenDict)
        {
            result += value.Value;
        }

        return result;
    }

    [Benchmark]
    public int ForEachLoop_Array()
    {
        int result = 0;
        foreach (var value in _pointsArray)
            result += value;

        return result;
    }
}

[MemoryDiagnoser]
[Config(typeof(CustomConfig))]
public class DictionaryBenchmark_For
{
    private readonly ReadOnlyCollection<Dictionary<Dartboard, int>> _rowButtonsData = new List<Dictionary<Dartboard, int>>
    {
        new()
        {
            { Dartboard.S1, 1 }, { Dartboard.S2, 2 }, { Dartboard.S3, 3 }, { Dartboard.S4, 4 }, { Dartboard.S5, 5 },
            { Dartboard.S6, 6 }, { Dartboard.S7, 7 }, { Dartboard.S8, 8 }, { Dartboard.S9, 9 }, { Dartboard.S10, 10 },
            { Dartboard.S11, 11 }, { Dartboard.S12, 12 }, { Dartboard.S13, 13 }, { Dartboard.S14, 14 }, { Dartboard.S15, 15 },
            { Dartboard.S16, 16 }, { Dartboard.S17, 17 }, { Dartboard.S18, 18 }, { Dartboard.S19, 19 }, { Dartboard.S20, 20 }, { Dartboard.S25, 25 }
        },
        new()
        {
            { Dartboard.D1, 2 }, { Dartboard.D2, 4 }, { Dartboard.D3, 6 }, { Dartboard.D4, 8 }, { Dartboard.D5, 10 },
            { Dartboard.D6, 12 }, { Dartboard.D7, 14 }, { Dartboard.D8, 16 }, { Dartboard.D9, 18 }, { Dartboard.D10, 20 },
            { Dartboard.D11, 22 }, { Dartboard.D12, 24 }, { Dartboard.D13, 26 }, { Dartboard.D14, 28 }, { Dartboard.D15, 30 },
            { Dartboard.D16, 32 }, { Dartboard.D17, 34 }, { Dartboard.D18, 36 }, { Dartboard.D19, 38 }, { Dartboard.D20, 40 }, { Dartboard.D25, 50 }
        },
        new()
        {
            { Dartboard.T1, 3 }, { Dartboard.T2, 6 }, { Dartboard.T3, 9 }, { Dartboard.T4, 12 }, { Dartboard.T5, 15 },
            { Dartboard.T6, 18 }, { Dartboard.T7, 21 }, { Dartboard.T8, 24 }, { Dartboard.T9, 27 }, { Dartboard.T10, 30 },
            { Dartboard.T11, 33 }, { Dartboard.T12, 36 }, { Dartboard.T13, 39 }, { Dartboard.T14, 42 }, { Dartboard.T15, 45 },
            { Dartboard.T16, 48 }, { Dartboard.T17, 51 }, { Dartboard.T18, 54 }, { Dartboard.T19, 57 }, { Dartboard.T20, 60 }, { Dartboard.X, 0 }
        }
    }.AsReadOnly();

    private readonly ReadOnlyCollection<FrozenDictionary<Dartboard, int>> _halfFrozenRowButtonsData =
        new List<FrozenDictionary<Dartboard, int>>{
            new Dictionary<Dartboard, int>
            {
                { Dartboard.S1, 1 }, { Dartboard.S2, 2 }, { Dartboard.S3, 3 }, { Dartboard.S4, 4 }, { Dartboard.S5, 5 },
                { Dartboard.S6, 6 }, { Dartboard.S7, 7 }, { Dartboard.S8, 8 }, { Dartboard.S9, 9 }, { Dartboard.S10, 10 },
                { Dartboard.S11, 11 }, { Dartboard.S12, 12 }, { Dartboard.S13, 13 }, { Dartboard.S14, 14 }, { Dartboard.S15, 15 },
                { Dartboard.S16, 16 }, { Dartboard.S17, 17 }, { Dartboard.S18, 18 }, { Dartboard.S19, 19 }, { Dartboard.S20, 20 }, { Dartboard.S25, 25 }
            }.ToFrozenDictionary(),
            new Dictionary<Dartboard, int>
            {
                { Dartboard.D1, 2 }, { Dartboard.D2, 4 }, { Dartboard.D3, 6 }, { Dartboard.D4, 8 }, { Dartboard.D5, 10 },
                { Dartboard.D6, 12 }, { Dartboard.D7, 14 }, { Dartboard.D8, 16 }, { Dartboard.D9, 18 }, { Dartboard.D10, 20 },
                { Dartboard.D11, 22 }, { Dartboard.D12, 24 }, { Dartboard.D13, 26 }, { Dartboard.D14, 28 }, { Dartboard.D15, 30 },
                { Dartboard.D16, 32 }, { Dartboard.D17, 34 }, { Dartboard.D18, 36 }, { Dartboard.D19, 38 }, { Dartboard.D20, 40 }, { Dartboard.D25, 50 }
            }.ToFrozenDictionary(),
            new Dictionary<Dartboard, int>
            {
                { Dartboard.T1, 3 }, { Dartboard.T2, 6 }, { Dartboard.T3, 9 }, { Dartboard.T4, 12 }, { Dartboard.T5, 15 },
                { Dartboard.T6, 18 }, { Dartboard.T7, 21 }, { Dartboard.T8, 24 }, { Dartboard.T9, 27 }, { Dartboard.T10, 30 },
                { Dartboard.T11, 33 }, { Dartboard.T12, 36 }, { Dartboard.T13, 39 }, { Dartboard.T14, 42 }, { Dartboard.T15, 45 },
                { Dartboard.T16, 48 }, { Dartboard.T17, 51 }, { Dartboard.T18, 54 }, { Dartboard.T19, 57 }, { Dartboard.T20, 60 }, { Dartboard.X, 0 }
            }.ToFrozenDictionary()
        }.AsReadOnly();

    private readonly FrozenSet<FrozenDictionary<Dartboard, int>> _frozenRowButtonsData =
        new List<FrozenDictionary<Dartboard, int>>{
            new Dictionary<Dartboard, int>
            {
                { Dartboard.S1, 1 }, { Dartboard.S2, 2 }, { Dartboard.S3, 3 }, { Dartboard.S4, 4 }, { Dartboard.S5, 5 },
                { Dartboard.S6, 6 }, { Dartboard.S7, 7 }, { Dartboard.S8, 8 }, { Dartboard.S9, 9 }, { Dartboard.S10, 10 },
                { Dartboard.S11, 11 }, { Dartboard.S12, 12 }, { Dartboard.S13, 13 }, { Dartboard.S14, 14 }, { Dartboard.S15, 15 },
                { Dartboard.S16, 16 }, { Dartboard.S17, 17 }, { Dartboard.S18, 18 }, { Dartboard.S19, 19 }, { Dartboard.S20, 20 }, { Dartboard.S25, 25 }
            }.ToFrozenDictionary(),
            new Dictionary<Dartboard, int>
            {
                { Dartboard.D1, 2 }, { Dartboard.D2, 4 }, { Dartboard.D3, 6 }, { Dartboard.D4, 8 }, { Dartboard.D5, 10 },
                { Dartboard.D6, 12 }, { Dartboard.D7, 14 }, { Dartboard.D8, 16 }, { Dartboard.D9, 18 }, { Dartboard.D10, 20 },
                { Dartboard.D11, 22 }, { Dartboard.D12, 24 }, { Dartboard.D13, 26 }, { Dartboard.D14, 28 }, { Dartboard.D15, 30 },
                { Dartboard.D16, 32 }, { Dartboard.D17, 34 }, { Dartboard.D18, 36 }, { Dartboard.D19, 38 }, { Dartboard.D20, 40 }, { Dartboard.D25, 50 }
            }.ToFrozenDictionary(),
            new Dictionary<Dartboard, int>
            {
                { Dartboard.T1, 3 }, { Dartboard.T2, 6 }, { Dartboard.T3, 9 }, { Dartboard.T4, 12 }, { Dartboard.T5, 15 },
                { Dartboard.T6, 18 }, { Dartboard.T7, 21 }, { Dartboard.T8, 24 }, { Dartboard.T9, 27 }, { Dartboard.T10, 30 },
                { Dartboard.T11, 33 }, { Dartboard.T12, 36 }, { Dartboard.T13, 39 }, { Dartboard.T14, 42 }, { Dartboard.T15, 45 },
                { Dartboard.T16, 48 }, { Dartboard.T17, 51 }, { Dartboard.T18, 54 }, { Dartboard.T19, 57 }, { Dartboard.T20, 60 }, { Dartboard.X, 0 }
            }.ToFrozenDictionary()
        }.ToFrozenSet();

    private readonly FrozenDictionary<Dartboard, int> _frozenDict = new Dictionary<Dartboard, int>
    {
        { Dartboard.S1, 1 }, { Dartboard.S2, 2 }, { Dartboard.S3, 3 }, { Dartboard.S4, 4 }, { Dartboard.S5, 5 },
        { Dartboard.S6, 6 }, { Dartboard.S7, 7 }, { Dartboard.S8, 8 }, { Dartboard.S9, 9 }, { Dartboard.S10, 10 },
        { Dartboard.S11, 11 }, { Dartboard.S12, 12 }, { Dartboard.S13, 13 }, { Dartboard.S14, 14 },
        { Dartboard.S15, 15 },
        { Dartboard.S16, 16 }, { Dartboard.S17, 17 }, { Dartboard.S18, 18 }, { Dartboard.S19, 19 },
        { Dartboard.S20, 20 }, { Dartboard.S25, 25 },
        { Dartboard.D1, 2 }, { Dartboard.D2, 4 }, { Dartboard.D3, 6 }, { Dartboard.D4, 8 }, { Dartboard.D5, 10 },
        { Dartboard.D6, 12 }, { Dartboard.D7, 14 }, { Dartboard.D8, 16 }, { Dartboard.D9, 18 }, { Dartboard.D10, 20 },
        { Dartboard.D11, 22 }, { Dartboard.D12, 24 }, { Dartboard.D13, 26 }, { Dartboard.D14, 28 },
        { Dartboard.D15, 30 },
        { Dartboard.D16, 32 }, { Dartboard.D17, 34 }, { Dartboard.D18, 36 }, { Dartboard.D19, 38 },
        { Dartboard.D20, 40 }, { Dartboard.D25, 50 },
        { Dartboard.T1, 3 }, { Dartboard.T2, 6 }, { Dartboard.T3, 9 }, { Dartboard.T4, 12 }, { Dartboard.T5, 15 },
        { Dartboard.T6, 18 }, { Dartboard.T7, 21 }, { Dartboard.T8, 24 }, { Dartboard.T9, 27 }, { Dartboard.T10, 30 },
        { Dartboard.T11, 33 }, { Dartboard.T12, 36 }, { Dartboard.T13, 39 }, { Dartboard.T14, 42 },
        { Dartboard.T15, 45 },
        { Dartboard.T16, 48 }, { Dartboard.T17, 51 }, { Dartboard.T18, 54 }, { Dartboard.T19, 57 },
        { Dartboard.T20, 60 }, { Dartboard.X, 0 }
    }.ToFrozenDictionary();

    private readonly int[] _pointsArray =
    [
        1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 25,
        2, 4, 6, 8, 10, 12, 14, 16, 18, 20, 22, 24, 26, 28, 30, 32, 34, 36, 38, 40, 50,
        3, 6, 9, 12, 15, 18, 21, 24, 27, 30, 33, 36, 39, 42, 45, 48, 51, 54, 57, 60, 0
    ];

    private Dartboard _dartboardValue;

    [GlobalSetup]
    public void Setup()
    {
        var number = new Random(500).Next(-1, 63);
        _dartboardValue = (Dartboard)number;
    }

    [Benchmark]
    public int ForLoop_ReadOnlyCollection_Dictionary()
    {
        int result = 0;
        for (int i = 0; i < 3; i++)
        {
            foreach (var value in _rowButtonsData[i])
            {
                result += value.Value;
            }
        }

        return result;
    }

    [Benchmark]
    public int ForLoop_ReadOnlyCollection_FrozenDictionary()
    {
        int result = 0;
        for (int i = 0; i < 3; i++)
        {
            foreach (var value in _halfFrozenRowButtonsData[i])
            {
                result += value.Value;
            }
        }

        return result;
    }

    [Benchmark]
    public int ForLoop_FrozenSet_FrozenDictionary()
    {
        int result = 0;
        for (int i = 0; i < 3; i++)
        {
            foreach (var value in _frozenRowButtonsData.Items[i])
            {
                result += value.Value;
            }
        }

        return result;
    }

    [Benchmark]
    public int ForLoop_FrozenDictionary()
    {
        int result = 0;
        for (int i = 0; i < 63; i++)
        {
            result += _frozenDict.ElementAt(i).Value;
        }

        return result;
    }

    [Benchmark]
    public int ForLoop_Array()
    {
        int result = 0;
        for (int i = 0; i < 63; i++)
            result += _pointsArray[i];

        return result;
    }
}

[MemoryDiagnoser]
[Config(typeof(CustomConfig))]
public class DictionaryBenchmark_TryGetValue
{
    private readonly ReadOnlyCollection<Dictionary<Dartboard, int>> _rowButtonsData = new List<Dictionary<Dartboard, int>>
    {
        new()
        {
            { Dartboard.S1, 1 }, { Dartboard.S2, 2 }, { Dartboard.S3, 3 }, { Dartboard.S4, 4 }, { Dartboard.S5, 5 },
            { Dartboard.S6, 6 }, { Dartboard.S7, 7 }, { Dartboard.S8, 8 }, { Dartboard.S9, 9 }, { Dartboard.S10, 10 },
            { Dartboard.S11, 11 }, { Dartboard.S12, 12 }, { Dartboard.S13, 13 }, { Dartboard.S14, 14 }, { Dartboard.S15, 15 },
            { Dartboard.S16, 16 }, { Dartboard.S17, 17 }, { Dartboard.S18, 18 }, { Dartboard.S19, 19 }, { Dartboard.S20, 20 }, { Dartboard.S25, 25 }
        },
        new()
        {
            { Dartboard.D1, 2 }, { Dartboard.D2, 4 }, { Dartboard.D3, 6 }, { Dartboard.D4, 8 }, { Dartboard.D5, 10 },
            { Dartboard.D6, 12 }, { Dartboard.D7, 14 }, { Dartboard.D8, 16 }, { Dartboard.D9, 18 }, { Dartboard.D10, 20 },
            { Dartboard.D11, 22 }, { Dartboard.D12, 24 }, { Dartboard.D13, 26 }, { Dartboard.D14, 28 }, { Dartboard.D15, 30 },
            { Dartboard.D16, 32 }, { Dartboard.D17, 34 }, { Dartboard.D18, 36 }, { Dartboard.D19, 38 }, { Dartboard.D20, 40 }, { Dartboard.D25, 50 }
        },
        new()
        {
            { Dartboard.T1, 3 }, { Dartboard.T2, 6 }, { Dartboard.T3, 9 }, { Dartboard.T4, 12 }, { Dartboard.T5, 15 },
            { Dartboard.T6, 18 }, { Dartboard.T7, 21 }, { Dartboard.T8, 24 }, { Dartboard.T9, 27 }, { Dartboard.T10, 30 },
            { Dartboard.T11, 33 }, { Dartboard.T12, 36 }, { Dartboard.T13, 39 }, { Dartboard.T14, 42 }, { Dartboard.T15, 45 },
            { Dartboard.T16, 48 }, { Dartboard.T17, 51 }, { Dartboard.T18, 54 }, { Dartboard.T19, 57 }, { Dartboard.T20, 60 }, { Dartboard.X, 0 }
        }
    }.AsReadOnly();

    private readonly ReadOnlyCollection<FrozenDictionary<Dartboard, int>> _halfFrozenRowButtonsData =
        new List<FrozenDictionary<Dartboard, int>>{
            new Dictionary<Dartboard, int>
            {
                { Dartboard.S1, 1 }, { Dartboard.S2, 2 }, { Dartboard.S3, 3 }, { Dartboard.S4, 4 }, { Dartboard.S5, 5 },
                { Dartboard.S6, 6 }, { Dartboard.S7, 7 }, { Dartboard.S8, 8 }, { Dartboard.S9, 9 }, { Dartboard.S10, 10 },
                { Dartboard.S11, 11 }, { Dartboard.S12, 12 }, { Dartboard.S13, 13 }, { Dartboard.S14, 14 }, { Dartboard.S15, 15 },
                { Dartboard.S16, 16 }, { Dartboard.S17, 17 }, { Dartboard.S18, 18 }, { Dartboard.S19, 19 }, { Dartboard.S20, 20 }, { Dartboard.S25, 25 }
            }.ToFrozenDictionary(),
            new Dictionary<Dartboard, int>
            {
                { Dartboard.D1, 2 }, { Dartboard.D2, 4 }, { Dartboard.D3, 6 }, { Dartboard.D4, 8 }, { Dartboard.D5, 10 },
                { Dartboard.D6, 12 }, { Dartboard.D7, 14 }, { Dartboard.D8, 16 }, { Dartboard.D9, 18 }, { Dartboard.D10, 20 },
                { Dartboard.D11, 22 }, { Dartboard.D12, 24 }, { Dartboard.D13, 26 }, { Dartboard.D14, 28 }, { Dartboard.D15, 30 },
                { Dartboard.D16, 32 }, { Dartboard.D17, 34 }, { Dartboard.D18, 36 }, { Dartboard.D19, 38 }, { Dartboard.D20, 40 }, { Dartboard.D25, 50 }
            }.ToFrozenDictionary(),
            new Dictionary<Dartboard, int>
            {
                { Dartboard.T1, 3 }, { Dartboard.T2, 6 }, { Dartboard.T3, 9 }, { Dartboard.T4, 12 }, { Dartboard.T5, 15 },
                { Dartboard.T6, 18 }, { Dartboard.T7, 21 }, { Dartboard.T8, 24 }, { Dartboard.T9, 27 }, { Dartboard.T10, 30 },
                { Dartboard.T11, 33 }, { Dartboard.T12, 36 }, { Dartboard.T13, 39 }, { Dartboard.T14, 42 }, { Dartboard.T15, 45 },
                { Dartboard.T16, 48 }, { Dartboard.T17, 51 }, { Dartboard.T18, 54 }, { Dartboard.T19, 57 }, { Dartboard.T20, 60 }, { Dartboard.X, 0 }
            }.ToFrozenDictionary()
        }.AsReadOnly();

    private readonly FrozenSet<FrozenDictionary<Dartboard, int>> _frozenRowButtonsData =
        new List<FrozenDictionary<Dartboard, int>>{
            new Dictionary<Dartboard, int>
            {
                { Dartboard.S1, 1 }, { Dartboard.S2, 2 }, { Dartboard.S3, 3 }, { Dartboard.S4, 4 }, { Dartboard.S5, 5 },
                { Dartboard.S6, 6 }, { Dartboard.S7, 7 }, { Dartboard.S8, 8 }, { Dartboard.S9, 9 }, { Dartboard.S10, 10 },
                { Dartboard.S11, 11 }, { Dartboard.S12, 12 }, { Dartboard.S13, 13 }, { Dartboard.S14, 14 }, { Dartboard.S15, 15 },
                { Dartboard.S16, 16 }, { Dartboard.S17, 17 }, { Dartboard.S18, 18 }, { Dartboard.S19, 19 }, { Dartboard.S20, 20 }, { Dartboard.S25, 25 }
            }.ToFrozenDictionary(),
            new Dictionary<Dartboard, int>
            {
                { Dartboard.D1, 2 }, { Dartboard.D2, 4 }, { Dartboard.D3, 6 }, { Dartboard.D4, 8 }, { Dartboard.D5, 10 },
                { Dartboard.D6, 12 }, { Dartboard.D7, 14 }, { Dartboard.D8, 16 }, { Dartboard.D9, 18 }, { Dartboard.D10, 20 },
                { Dartboard.D11, 22 }, { Dartboard.D12, 24 }, { Dartboard.D13, 26 }, { Dartboard.D14, 28 }, { Dartboard.D15, 30 },
                { Dartboard.D16, 32 }, { Dartboard.D17, 34 }, { Dartboard.D18, 36 }, { Dartboard.D19, 38 }, { Dartboard.D20, 40 }, { Dartboard.D25, 50 }
            }.ToFrozenDictionary(),
            new Dictionary<Dartboard, int>
            {
                { Dartboard.T1, 3 }, { Dartboard.T2, 6 }, { Dartboard.T3, 9 }, { Dartboard.T4, 12 }, { Dartboard.T5, 15 },
                { Dartboard.T6, 18 }, { Dartboard.T7, 21 }, { Dartboard.T8, 24 }, { Dartboard.T9, 27 }, { Dartboard.T10, 30 },
                { Dartboard.T11, 33 }, { Dartboard.T12, 36 }, { Dartboard.T13, 39 }, { Dartboard.T14, 42 }, { Dartboard.T15, 45 },
                { Dartboard.T16, 48 }, { Dartboard.T17, 51 }, { Dartboard.T18, 54 }, { Dartboard.T19, 57 }, { Dartboard.T20, 60 }, { Dartboard.X, 0 }
            }.ToFrozenDictionary()
        }.ToFrozenSet();

    private readonly FrozenDictionary<Dartboard, int> _frozenDict = new Dictionary<Dartboard, int>
    {
        { Dartboard.S1, 1 }, { Dartboard.S2, 2 }, { Dartboard.S3, 3 }, { Dartboard.S4, 4 }, { Dartboard.S5, 5 },
        { Dartboard.S6, 6 }, { Dartboard.S7, 7 }, { Dartboard.S8, 8 }, { Dartboard.S9, 9 }, { Dartboard.S10, 10 },
        { Dartboard.S11, 11 }, { Dartboard.S12, 12 }, { Dartboard.S13, 13 }, { Dartboard.S14, 14 },
        { Dartboard.S15, 15 },
        { Dartboard.S16, 16 }, { Dartboard.S17, 17 }, { Dartboard.S18, 18 }, { Dartboard.S19, 19 },
        { Dartboard.S20, 20 }, { Dartboard.S25, 25 },
        { Dartboard.D1, 2 }, { Dartboard.D2, 4 }, { Dartboard.D3, 6 }, { Dartboard.D4, 8 }, { Dartboard.D5, 10 },
        { Dartboard.D6, 12 }, { Dartboard.D7, 14 }, { Dartboard.D8, 16 }, { Dartboard.D9, 18 }, { Dartboard.D10, 20 },
        { Dartboard.D11, 22 }, { Dartboard.D12, 24 }, { Dartboard.D13, 26 }, { Dartboard.D14, 28 },
        { Dartboard.D15, 30 },
        { Dartboard.D16, 32 }, { Dartboard.D17, 34 }, { Dartboard.D18, 36 }, { Dartboard.D19, 38 },
        { Dartboard.D20, 40 }, { Dartboard.D25, 50 },
        { Dartboard.T1, 3 }, { Dartboard.T2, 6 }, { Dartboard.T3, 9 }, { Dartboard.T4, 12 }, { Dartboard.T5, 15 },
        { Dartboard.T6, 18 }, { Dartboard.T7, 21 }, { Dartboard.T8, 24 }, { Dartboard.T9, 27 }, { Dartboard.T10, 30 },
        { Dartboard.T11, 33 }, { Dartboard.T12, 36 }, { Dartboard.T13, 39 }, { Dartboard.T14, 42 },
        { Dartboard.T15, 45 },
        { Dartboard.T16, 48 }, { Dartboard.T17, 51 }, { Dartboard.T18, 54 }, { Dartboard.T19, 57 },
        { Dartboard.T20, 60 }, { Dartboard.X, 0 }
    }.ToFrozenDictionary();

    private readonly int[] _pointsArray =
    [
        1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 25,
        2, 4, 6, 8, 10, 12, 14, 16, 18, 20, 22, 24, 26, 28, 30, 32, 34, 36, 38, 40, 50,
        3, 6, 9, 12, 15, 18, 21, 24, 27, 30, 33, 36, 39, 42, 45, 48, 51, 54, 57, 60, 0
    ];

    private Dartboard _dartboardValue;

    [GlobalSetup]
    public void Setup()
    {
        var number = new Random(500).Next(-1, 63);
        _dartboardValue = (Dartboard)number;
    }

    [Benchmark]
    public int TryGetValue_ReadOnlyCollection_Dictionary()
    {
        foreach (var dict in _rowButtonsData)
        {
            if (dict.TryGetValue(_dartboardValue, out var result))
                return result;
        }

        return -1;
    }

    [Benchmark]
    public int TryGetValue_ReadOnlyCollection_FrozenDictionary()
    {
        foreach (var dict in _halfFrozenRowButtonsData)
        {
            if (dict.TryGetValue(_dartboardValue, out var result))
                return result;
        }

        return -1;
    }

    [Benchmark]
    public int TryGetValue_FrozenSet_FrozenDictionary()
    {
        foreach (var dict in _frozenRowButtonsData)
        {
            if (dict.TryGetValue(_dartboardValue, out var result))
                return result;
        }

        return -1;
    }

    [Benchmark]
    public int TryGetValue_FrozenDictionary()
    {
        if (_frozenDict.TryGetValue(_dartboardValue, out var result))
            return result;

        return -1;
    }

    [Benchmark]
    public int TryGetValue_Array()
    {
        return _pointsArray[(int)_dartboardValue];
    }
}

[MemoryDiagnoser]
[Config(typeof(CustomConfig))]
public class DictionaryBenchmark_IsDouble
{
    private readonly ReadOnlyCollection<Dictionary<Dartboard, int>> _rowButtonsData = new List<Dictionary<Dartboard, int>>
    {
        new()
        {
            { Dartboard.S1, 1 }, { Dartboard.S2, 2 }, { Dartboard.S3, 3 }, { Dartboard.S4, 4 }, { Dartboard.S5, 5 },
            { Dartboard.S6, 6 }, { Dartboard.S7, 7 }, { Dartboard.S8, 8 }, { Dartboard.S9, 9 }, { Dartboard.S10, 10 },
            { Dartboard.S11, 11 }, { Dartboard.S12, 12 }, { Dartboard.S13, 13 }, { Dartboard.S14, 14 }, { Dartboard.S15, 15 },
            { Dartboard.S16, 16 }, { Dartboard.S17, 17 }, { Dartboard.S18, 18 }, { Dartboard.S19, 19 }, { Dartboard.S20, 20 }, { Dartboard.S25, 25 }
        },
        new()
        {
            { Dartboard.D1, 2 }, { Dartboard.D2, 4 }, { Dartboard.D3, 6 }, { Dartboard.D4, 8 }, { Dartboard.D5, 10 },
            { Dartboard.D6, 12 }, { Dartboard.D7, 14 }, { Dartboard.D8, 16 }, { Dartboard.D9, 18 }, { Dartboard.D10, 20 },
            { Dartboard.D11, 22 }, { Dartboard.D12, 24 }, { Dartboard.D13, 26 }, { Dartboard.D14, 28 }, { Dartboard.D15, 30 },
            { Dartboard.D16, 32 }, { Dartboard.D17, 34 }, { Dartboard.D18, 36 }, { Dartboard.D19, 38 }, { Dartboard.D20, 40 }, { Dartboard.D25, 50 }
        },
        new()
        {
            { Dartboard.T1, 3 }, { Dartboard.T2, 6 }, { Dartboard.T3, 9 }, { Dartboard.T4, 12 }, { Dartboard.T5, 15 },
            { Dartboard.T6, 18 }, { Dartboard.T7, 21 }, { Dartboard.T8, 24 }, { Dartboard.T9, 27 }, { Dartboard.T10, 30 },
            { Dartboard.T11, 33 }, { Dartboard.T12, 36 }, { Dartboard.T13, 39 }, { Dartboard.T14, 42 }, { Dartboard.T15, 45 },
            { Dartboard.T16, 48 }, { Dartboard.T17, 51 }, { Dartboard.T18, 54 }, { Dartboard.T19, 57 }, { Dartboard.T20, 60 }, { Dartboard.X, 0 }
        }
    }.AsReadOnly();

    private readonly ReadOnlyCollection<FrozenDictionary<Dartboard, int>> _halfFrozenRowButtonsData =
        new List<FrozenDictionary<Dartboard, int>>{
            new Dictionary<Dartboard, int>
            {
                { Dartboard.S1, 1 }, { Dartboard.S2, 2 }, { Dartboard.S3, 3 }, { Dartboard.S4, 4 }, { Dartboard.S5, 5 },
                { Dartboard.S6, 6 }, { Dartboard.S7, 7 }, { Dartboard.S8, 8 }, { Dartboard.S9, 9 }, { Dartboard.S10, 10 },
                { Dartboard.S11, 11 }, { Dartboard.S12, 12 }, { Dartboard.S13, 13 }, { Dartboard.S14, 14 }, { Dartboard.S15, 15 },
                { Dartboard.S16, 16 }, { Dartboard.S17, 17 }, { Dartboard.S18, 18 }, { Dartboard.S19, 19 }, { Dartboard.S20, 20 }, { Dartboard.S25, 25 }
            }.ToFrozenDictionary(),
            new Dictionary<Dartboard, int>
            {
                { Dartboard.D1, 2 }, { Dartboard.D2, 4 }, { Dartboard.D3, 6 }, { Dartboard.D4, 8 }, { Dartboard.D5, 10 },
                { Dartboard.D6, 12 }, { Dartboard.D7, 14 }, { Dartboard.D8, 16 }, { Dartboard.D9, 18 }, { Dartboard.D10, 20 },
                { Dartboard.D11, 22 }, { Dartboard.D12, 24 }, { Dartboard.D13, 26 }, { Dartboard.D14, 28 }, { Dartboard.D15, 30 },
                { Dartboard.D16, 32 }, { Dartboard.D17, 34 }, { Dartboard.D18, 36 }, { Dartboard.D19, 38 }, { Dartboard.D20, 40 }, { Dartboard.D25, 50 }
            }.ToFrozenDictionary(),
            new Dictionary<Dartboard, int>
            {
                { Dartboard.T1, 3 }, { Dartboard.T2, 6 }, { Dartboard.T3, 9 }, { Dartboard.T4, 12 }, { Dartboard.T5, 15 },
                { Dartboard.T6, 18 }, { Dartboard.T7, 21 }, { Dartboard.T8, 24 }, { Dartboard.T9, 27 }, { Dartboard.T10, 30 },
                { Dartboard.T11, 33 }, { Dartboard.T12, 36 }, { Dartboard.T13, 39 }, { Dartboard.T14, 42 }, { Dartboard.T15, 45 },
                { Dartboard.T16, 48 }, { Dartboard.T17, 51 }, { Dartboard.T18, 54 }, { Dartboard.T19, 57 }, { Dartboard.T20, 60 }, { Dartboard.X, 0 }
            }.ToFrozenDictionary()
        }.AsReadOnly();

    private readonly FrozenSet<FrozenDictionary<Dartboard, int>> _frozenRowButtonsData =
        new List<FrozenDictionary<Dartboard, int>>{
            new Dictionary<Dartboard, int>
            {
                { Dartboard.S1, 1 }, { Dartboard.S2, 2 }, { Dartboard.S3, 3 }, { Dartboard.S4, 4 }, { Dartboard.S5, 5 },
                { Dartboard.S6, 6 }, { Dartboard.S7, 7 }, { Dartboard.S8, 8 }, { Dartboard.S9, 9 }, { Dartboard.S10, 10 },
                { Dartboard.S11, 11 }, { Dartboard.S12, 12 }, { Dartboard.S13, 13 }, { Dartboard.S14, 14 }, { Dartboard.S15, 15 },
                { Dartboard.S16, 16 }, { Dartboard.S17, 17 }, { Dartboard.S18, 18 }, { Dartboard.S19, 19 }, { Dartboard.S20, 20 }, { Dartboard.S25, 25 }
            }.ToFrozenDictionary(),
            new Dictionary<Dartboard, int>
            {
                { Dartboard.D1, 2 }, { Dartboard.D2, 4 }, { Dartboard.D3, 6 }, { Dartboard.D4, 8 }, { Dartboard.D5, 10 },
                { Dartboard.D6, 12 }, { Dartboard.D7, 14 }, { Dartboard.D8, 16 }, { Dartboard.D9, 18 }, { Dartboard.D10, 20 },
                { Dartboard.D11, 22 }, { Dartboard.D12, 24 }, { Dartboard.D13, 26 }, { Dartboard.D14, 28 }, { Dartboard.D15, 30 },
                { Dartboard.D16, 32 }, { Dartboard.D17, 34 }, { Dartboard.D18, 36 }, { Dartboard.D19, 38 }, { Dartboard.D20, 40 }, { Dartboard.D25, 50 }
            }.ToFrozenDictionary(),
            new Dictionary<Dartboard, int>
            {
                { Dartboard.T1, 3 }, { Dartboard.T2, 6 }, { Dartboard.T3, 9 }, { Dartboard.T4, 12 }, { Dartboard.T5, 15 },
                { Dartboard.T6, 18 }, { Dartboard.T7, 21 }, { Dartboard.T8, 24 }, { Dartboard.T9, 27 }, { Dartboard.T10, 30 },
                { Dartboard.T11, 33 }, { Dartboard.T12, 36 }, { Dartboard.T13, 39 }, { Dartboard.T14, 42 }, { Dartboard.T15, 45 },
                { Dartboard.T16, 48 }, { Dartboard.T17, 51 }, { Dartboard.T18, 54 }, { Dartboard.T19, 57 }, { Dartboard.T20, 60 }, { Dartboard.X, 0 }
            }.ToFrozenDictionary()
        }.ToFrozenSet();

    private readonly FrozenDictionary<Dartboard, int> _frozenDict = new Dictionary<Dartboard, int>
    {
        { Dartboard.S1, 1 }, { Dartboard.S2, 2 }, { Dartboard.S3, 3 }, { Dartboard.S4, 4 }, { Dartboard.S5, 5 },
        { Dartboard.S6, 6 }, { Dartboard.S7, 7 }, { Dartboard.S8, 8 }, { Dartboard.S9, 9 }, { Dartboard.S10, 10 },
        { Dartboard.S11, 11 }, { Dartboard.S12, 12 }, { Dartboard.S13, 13 }, { Dartboard.S14, 14 },
        { Dartboard.S15, 15 },
        { Dartboard.S16, 16 }, { Dartboard.S17, 17 }, { Dartboard.S18, 18 }, { Dartboard.S19, 19 },
        { Dartboard.S20, 20 }, { Dartboard.S25, 25 },
        { Dartboard.D1, 2 }, { Dartboard.D2, 4 }, { Dartboard.D3, 6 }, { Dartboard.D4, 8 }, { Dartboard.D5, 10 },
        { Dartboard.D6, 12 }, { Dartboard.D7, 14 }, { Dartboard.D8, 16 }, { Dartboard.D9, 18 }, { Dartboard.D10, 20 },
        { Dartboard.D11, 22 }, { Dartboard.D12, 24 }, { Dartboard.D13, 26 }, { Dartboard.D14, 28 },
        { Dartboard.D15, 30 },
        { Dartboard.D16, 32 }, { Dartboard.D17, 34 }, { Dartboard.D18, 36 }, { Dartboard.D19, 38 },
        { Dartboard.D20, 40 }, { Dartboard.D25, 50 },
        { Dartboard.T1, 3 }, { Dartboard.T2, 6 }, { Dartboard.T3, 9 }, { Dartboard.T4, 12 }, { Dartboard.T5, 15 },
        { Dartboard.T6, 18 }, { Dartboard.T7, 21 }, { Dartboard.T8, 24 }, { Dartboard.T9, 27 }, { Dartboard.T10, 30 },
        { Dartboard.T11, 33 }, { Dartboard.T12, 36 }, { Dartboard.T13, 39 }, { Dartboard.T14, 42 },
        { Dartboard.T15, 45 },
        { Dartboard.T16, 48 }, { Dartboard.T17, 51 }, { Dartboard.T18, 54 }, { Dartboard.T19, 57 },
        { Dartboard.T20, 60 }, { Dartboard.X, 0 }
    }.ToFrozenDictionary();

    private readonly int[] _pointsArray =
    [
        1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 25,
        2, 4, 6, 8, 10, 12, 14, 16, 18, 20, 22, 24, 26, 28, 30, 32, 34, 36, 38, 40, 50,
        3, 6, 9, 12, 15, 18, 21, 24, 27, 30, 33, 36, 39, 42, 45, 48, 51, 54, 57, 60, 0
    ];

    private Dartboard _dartboardValue;

    [GlobalSetup]
    public void Setup()
    {
        var number = new Random(500).Next(-1, 63);
        _dartboardValue = (Dartboard)number;
    }

    [Benchmark]
    public bool IsDouble_ReadOnlyCollection_Dictionary()
    {
        return _rowButtonsData[1].TryGetValue(_dartboardValue, out _);
    }

    [Benchmark]
    public bool IsDouble_ReadOnlyCollection_FrozenDictionary()
    {
        return _halfFrozenRowButtonsData[1].TryGetValue(_dartboardValue, out _);
    }

    [Benchmark]
    public bool IsDouble_FrozenSet_FrozenDictionary()
    {
        return _frozenRowButtonsData.Items[1].TryGetValue(_dartboardValue, out _);
    }

    // Used for both Array and single dictionary approach
    [Benchmark]
    public bool IsDouble_IfStatement()
    {
        return (int)_dartboardValue > 20 && (int)_dartboardValue < 42;
    }
}
