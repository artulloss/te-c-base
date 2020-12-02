using Capstone.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public class FakeBoardDAO
    {
        private static List<Board> _list;
        public static List<Board> GetBoards()
        {

            if (_list == null)
            {
                _list = new List<Board>();

                try
                {
                    using (StreamReader sr = new StreamReader("kanban.json"))
                    {
                        string dontdothis = sr.ReadToEnd();

                        Rootobject root = JsonConvert.DeserializeObject<Rootobject>(dontdothis);
                        _list = root.boards.ToList<Board>();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("something wrong " + e.Message);
                }
                return _list;

            }
            else
            {
                return _list;
            }
        }

        public static Board GetSpecificBoard(int id)
        {
            if (_list == null)
            {
                GetBoards();
            }
            return _list.Find(b => b.id == id);
        }
    }
}
