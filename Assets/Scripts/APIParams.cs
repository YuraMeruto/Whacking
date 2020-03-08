
namespace APIParams
{
    public class RegistScore
    {
        public string name;
        public int score;
    }

    public class GetScoreList
    {
        public string name;
    }

    public class ResponseGetScoreList
    {
       public System.Collections.Generic.List<RegistScore> score_list = new System.Collections.Generic.List<RegistScore>();
    }
}