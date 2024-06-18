using CowsayProgram;

class Subscriber
{
  private readonly Cowsay cowsay;
  public Subscriber(Cowsay cowsay)
  {
    this.cowsay = cowsay;
    this.cowsay.Reply += OnReply;
  }
  void OnReply(object? sender, string reply)
  {
    Console.WriteLine(reply);
  }
}