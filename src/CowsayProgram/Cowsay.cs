using System.Diagnostics;

namespace CowsayProgram;
public class Cowsay
{
    public event EventHandler<string>? Reply;

    private static Process InitCowsay() => new()
    {
        StartInfo = new ProcessStartInfo()
        {
            FileName = "cowsay",
            RedirectStandardInput = true,
            RedirectStandardOutput = true,
            UseShellExecute = false
        }
    };

    public void Say(string message)
    {
        Process cowsay = InitCowsay();
        cowsay.Start();

        cowsay.StandardInput.WriteLine(message);
        cowsay.StandardInput.Close();

        string output = cowsay.StandardOutput.ReadToEnd();
        cowsay.WaitForExit();

        Reply?.Invoke(this, output);
    }
}