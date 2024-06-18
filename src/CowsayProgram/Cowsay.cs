using System.Diagnostics;

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

        public void Say(string message)
        {

            Process cowsay = InitCowsay();
            cowsay.StandardInput.WriteLine(message);
            cowsay.StandardInput.Close();


            string output = cowsay.StandardOutput.ReadToEnd();
            // string error = cowsay.StandardError.ReadToEnd();
            cowsay.WaitForExit();

            EventHandler<string>? raiseEvent = Reply;
            if (raiseEvent != null)
            {
                raiseEvent?.Invoke(this, output);
            }
        }
    }
}