using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    public class ManageList
    {
        private List<string> People = new List<string>(){"LiLei", "XiaoGang", "XiaoMing", "XiaoHong"};

        public string GetLongStringWithFind()
        {
            return People.Find(p => p.Length > 5);
        }

        public List<string> GetLongStringWithSelect()
        {
            People.Select(p => p.Length > 5).FirstOrDefault();

        }
    }
}
