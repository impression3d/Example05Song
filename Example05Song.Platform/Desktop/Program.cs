using System;
using Impression;

namespace Example05Song
{
    class Program
    {
        static void Main(string[] args)
		{
			using(var game = new Example05SongGame())
            {
                game.Run();
            }
		}
    }
}