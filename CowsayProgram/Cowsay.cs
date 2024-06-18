using System.Diagnostics;
using System.Text;

namespace CowsayProgram
{
    public class Cowsay
    {
        public event EventHandler<string>? Reply;


        public void Say(string Message)
        {
            Process cowsay = InitCowsay();
            cowsay.StandardInput.WriteLine(Message);
            cowsay.StandardInput.Close();


            string output = cowsay.StandardOutput.ReadToEnd();
            OnReply(output);
            cowsay.WaitForExit();
        }

        protected virtual void OnReply(string reply)
        {
            Reply?.Invoke(this, reply);
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
}