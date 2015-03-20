using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RecommenderSystem
{
    class RecommenderSystem
    {
        public enum PredictionMethod { Pearson, Cosine, Random, SVD, Stereotypes };

        //class members here

        public RecommenderSystem()
        {
        }

        public void Load(string sFileName, double dTrainSetSize)
        {
            throw new NotImplementedException();
        }

        public void TrainBaseModel(int cFeatures)
        {
            throw new NotImplementedException();
        }

        public double GetRating(string sUID, string sIID)
        {
            throw new NotImplementedException();
        }

        public double PredictRating(PredictionMethod m, string sUID, string sIID)
        {
            throw new NotImplementedException();
        }


        public Dictionary<PredictionMethod, double> ComputeRMSE(List<PredictionMethod> lMethods, out Dictionary<PredictionMethod, Dictionary<PredictionMethod, double>> dConfidence)
        {
            throw new NotImplementedException();
        }
    }
}
