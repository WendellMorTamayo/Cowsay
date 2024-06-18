using System.Diagnostics;

namespace Say;

public class Cowsay(string Message)
{
    private string Message { get; } = Message;
    public event EventHandler<string>? Reply;

    public static void Say()
    {

    }

    public void OnReply()
    {

    }

    public static void Process(string? Message)
    {
        var cowsay = new Process()
        {
            StartInfo = new ProcessStartInfo()
            {
                FileName = "cowsay",
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true,
            }
        };

        cowsay.Start();
        cowsay.StandardInput.WriteLine(Message);
        cowsay.StandardInput.Close();

        Message = cowsay.StandardOutput.ReadToEnd();

        bool exited = cowsay.WaitForExit(0);
        if (!exited)
        {
            cowsay.Kill();
        }
    }
}