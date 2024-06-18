using System.Diagnostics;
using System.Text;

namespace Say;

public class Cowsay(string Message)
{
    // private string Message { get; } = Message;
    public StringBuilder sb = new();
    private event EventHandler<string>? Reply;


    public static void Say(string message)
    {
        Process cowsay = InitCowsay();
        cowsay.StandardInput.WriteLine(message);
        cowsay.StandardInput.Close();


        string output = cowsay.StandardOutput.ReadToEnd();
        Console.WriteLine(output);

        bool exited = cowsay.WaitForExit(0);
        if (!exited)
        {
            cowsay.Kill();
        }
    }

    public void OnReply()
    {
        Console.WriteLine(Message);
    }

    private static Process InitCowsay()
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
        return cowsay;
    }
}