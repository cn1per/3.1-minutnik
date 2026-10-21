using System;
using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Threading;

namespace minutnik;

public partial class MainWindow : Window
{
    private readonly DispatcherTimer _timer = new() { Interval = TimeSpan.FromMilliseconds(200) };
    private DateTimeOffset _deadline;
    private TimeSpan _remaining;
    private int _completedCycles;
    private bool _isBreak;
    private bool _isRunning;

    private readonly List<string> _history = new();

    public MainWindow()
    {
        InitializeComponent();

        WorkDurationInput.ValueChanged += OnDurationChanged;
        BreakDurationInput.ValueChanged += OnDurationChanged;
        _timer.Tick += OnTimerTick;

        _remaining = GetWorkDuration();
        UpdateDisplay();
    }

    private void OnStartPauseClick(object? sender, RoutedEventArgs e)
    {
        if (_isRunning)
        {
            _remaining = _deadline - DateTimeOffset.UtcNow;
            if (_remaining < TimeSpan.Zero)
            {
                _remaining = TimeSpan.Zero;
            }

            _isRunning = false;
            _timer.Stop();
        }
        else
        {
            _deadline = DateTimeOffset.UtcNow + _remaining;
            _isRunning = true;
            _timer.Start();
        }

        UpdateDisplay();
    }

    private void OnResetClick(object? sender, RoutedEventArgs e)
    {
        _timer.Stop();
        _isRunning = false;
        _isBreak = false;
        _completedCycles = 0;
        _history.Clear();
        HistoryList.ItemsSource = _history.ToArray();
        _remaining = GetWorkDuration();
        UpdateDisplay();
    }

    private void OnDurationChanged(object? sender, EventArgs e)
    {
        if (_isRunning)
        {
            return;
        }

        _remaining = GetCurrentDuration();
        UpdateDisplay();
    }

    private void OnTimerTick(object? sender, EventArgs e)
    {
        var now = DateTimeOffset.UtcNow;
        while (_isRunning && _deadline <= now)
        {
            if (_isBreak)
        {
        _isBreak = false;
        _completedCycles++;

        _history.Add($"{DateTime.Now:HH:mm} - cykl {_completedCycles}");
         HistoryList.ItemsSource = _history.ToArray();
        }
            else
        {
        _isBreak = true;
        }

            _deadline += GetCurrentDuration();
        }

        _remaining = _deadline - now;
        UpdateDisplay();
    }

    private TimeSpan GetCurrentDuration()
    {
        return _isBreak ? GetBreakDuration() : GetWorkDuration();
    }

    private TimeSpan GetWorkDuration()
    {
        return TimeSpan.FromMinutes((double)(WorkDurationInput.Value ?? 25m));
    }

    private TimeSpan GetBreakDuration()
    {
        return TimeSpan.FromMinutes((double)(BreakDurationInput.Value ?? 5m));
    }

    private void UpdateDisplay()
    {
        var totalSeconds = Math.Max(0, (int)Math.Ceiling(_remaining.TotalSeconds));
        var minutes = totalSeconds / 60;
        var seconds = totalSeconds % 60;

        TimeText.Text = $"{minutes:00}:{seconds:00}";
        PhaseText.Text = _isBreak ? "Czas na przerwę" : "Czas pracy";
        PhaseText.Foreground = _isBreak
            ? Avalonia.Media.Brushes.LightSkyBlue
            : Avalonia.Media.Brushes.LightGreen;
        CycleCountText.Text = _completedCycles.ToString();
        StartPauseButton.Content = _isRunning ? "Pauza" : "Start";
        WorkDurationInput.IsEnabled = !_isRunning;
        BreakDurationInput.IsEnabled = !_isRunning;
    }
    
}
