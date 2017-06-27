using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Risk;
using System.Linq;

namespace ActiveRiskInterviewTest
{
    public class FindRisk
    {
        
        private List<Risk> ListOfRisks; //private 
        
        public FindRisk()
        {
            RiskService Search;
            Search = new RiskService();
            ListOfRisks  = Search.GetRisks();
        }


        public void GetRiskByUser(string User)
        {
            ListOfRisks = ListOfRisks.Where(x => x.Owner.Name == User).ToList<Risk>();
        }

        public void GetRiskWithOtherStatus(RiskStatus Status)
        {
            var SearchResults = new List<Risk>();
          
            ListOfRisks = ListOfRisks.Where(x => x.Status != Status).ToList<Risk>();
        }

        public void GetRiskByTitle(string Title)
        {
           
           if (Title == null) throw new ArgumentNullException("Title cannot be null");

           ListOfRisks = ListOfRisks.Where(x => x.Title.ToLower().Contains(Title.ToLower())).ToList<Risk>();
        }

        public List<Risk> ResultsOfSearch()
        {
            var CopyOfResults = new List<Risk>();

            foreach (var risk in ListOfRisks)
            {
                CopyOfResults.Add(risk.Copy());
            }

            return CopyOfResults;  
        }
    }
}
