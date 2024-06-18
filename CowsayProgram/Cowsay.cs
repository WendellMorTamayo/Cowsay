using System.Diagnostics;
using System.Text;

namespace CowsayProgram
{
    public class Cowsay
    {
        public event EventHandler<string>? Reply;

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

        public void Say(string Message)
        {

            Process cowsay = InitCowsay();
            cowsay.StandardInput.WriteLine(Message);
            cowsay.StandardInput.Close();


            string output = cowsay.StandardOutput.ReadToEnd();
            // string error = cowsay.StandardError.ReadToEnd();
            cowsay.WaitForExit();

            OnReply(this, output);
        }

        private void OnReply(object? sender, string reply)
        {
            Reply?.Invoke(this, reply);
        }
    }
}