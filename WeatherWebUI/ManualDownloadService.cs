using System.Threading;

public class ManualDownloadService
{
    private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(0, 1);

    public void SignalDownload()
    {
        if (_semaphore.CurrentCount == 0)
        {
            _semaphore.Release();
        }
    }
    public async Task WaitForDownloadSignal(CancellationToken cancellationToken)
    {
        await _semaphore.WaitAsync(cancellationToken);
    }
}