using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace RecommenderSystem
{
    class Program
    {
        

        static void Assignment1()
        {
            RecommenderSystem rs = new RecommenderSystem();
            rs.Load("yelp_training_set_review.json", 0.95);
            rs.TrainBaseModel(10);
            Console.WriteLine("Predicted rating of user rLtl8ZkDX5vH5nAx9C3q5Q to item 88 using Pearson is " + Math.Round(rs.PredictRating(RecommenderSystem.PredictionMethod.Pearson, "rLtl8ZkDX5vH5nAx9C3q5Q", "69t2S1u7Rf6qM_c14b42xQ"), 4));
            Console.WriteLine("Predicted rating of user 6 to item 88 using Cosine is " + Math.Round(rs.PredictRating(RecommenderSystem.PredictionMethod.Cosine, "rLtl8ZkDX5vH5nAx9C3q5Q", "69t2S1u7Rf6qM_c14b42xQ"), 4));
            Console.WriteLine("Predicted rating of user 6 to item 88 using Random is " + Math.Round(rs.PredictRating(RecommenderSystem.PredictionMethod.Random, "rLtl8ZkDX5vH5nAx9C3q5Q", "69t2S1u7Rf6qM_c14b42xQ"), 4));
            Console.WriteLine("Predicted rating of user 6 to item 88 using MF is " + Math.Round(rs.PredictRating(RecommenderSystem.PredictionMethod.SVD, "rLtl8ZkDX5vH5nAx9C3q5Q", "69t2S1u7Rf6qM_c14b42xQ"), 4));
            List<RecommenderSystem.PredictionMethod> lMethods = new List<RecommenderSystem.PredictionMethod>();
            lMethods.Add(RecommenderSystem.PredictionMethod.SVD);
            lMethods.Add(RecommenderSystem.PredictionMethod.Pearson);
            lMethods.Add(RecommenderSystem.PredictionMethod.Cosine);
            lMethods.Add(RecommenderSystem.PredictionMethod.Random);
            DateTime dtStart = DateTime.Now;
            Dictionary<RecommenderSystem.PredictionMethod, Dictionary<RecommenderSystem.PredictionMethod, double>> dConfidence = null;
            Dictionary<RecommenderSystem.PredictionMethod, double> dResults = rs.ComputeRMSE(lMethods, out dConfidence);
            Console.WriteLine("RMSE scores for Pearson, Cosine, SVD, and Random are:");
            foreach (KeyValuePair<RecommenderSystem.PredictionMethod, double> p in dResults)
                Console.Write(p.Key + "=" + Math.Round(p.Value, 4) + ", ");
            Console.WriteLine("Confidence P-values are:");
            foreach (RecommenderSystem.PredictionMethod sFirst in dConfidence.Keys)
                foreach (RecommenderSystem.PredictionMethod sSecond in dConfidence[sFirst].Keys)
                    Console.WriteLine("p(" + sFirst + "=" + sSecond + ")=" + dConfidence[sFirst][sSecond].ToString("F3"));
            Console.WriteLine();
            Console.WriteLine("Execution time was " + Math.Round((DateTime.Now - dtStart).TotalSeconds, 0));
            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            Assignment1();
        }
    }
}
