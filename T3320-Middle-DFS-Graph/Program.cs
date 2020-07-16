using System;
using System.Collections.Generic;

namespace T3320_Middle_DFS_Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public IList<string> FindItinerary(IList<IList<string>> tickets)
        {
            var dicTicket = new Dictionary<string, List<string>>();
            foreach(var ticket in tickets)
            {
                if (dicTicket.ContainsKey(ticket[0]))
                    dicTicket[ticket[0]].Add(ticket[1]);
                else
                    dicTicket.Add(ticket[0], new List<string> { ticket[1] });
            }
            var resls = new List<List<string>>();
            foreach(var to in dicTicket["JFK"])
            {
                var oneres="JFK"+
            }

        }
        public bool FindHelp(Dictionary<string, List<string>> dicTicket, string from)
        {

        }
    }
}
