using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using SiteCalculator.Services.Models;

namespace SiteCalculator.Services
{
    public class InputDataProvider
    {
        public InputModel GetData(string jsonString)
        {
            if (string.IsNullOrEmpty(jsonString)) return null;
            var jObject = JObject.Parse(jsonString);
            var inputModel = Validate(jObject.ToObject<InputModel>());
            if (inputModel == null) throw new ApplicationException($"{jsonString} is Not a valid input!");
            return inputModel;
        }

        private InputModel Validate(InputModel inputModel)
        {
            if (inputModel?.site_config == null || inputModel.Width <= 0 || inputModel.Length <= 0) return null;
            return inputModel;
        }

        public IEnumerable<InputModel> GetDataList(string jsonString)
        {
            var result = new List<InputModel>();
            if (string.IsNullOrEmpty(jsonString)) yield break;

            var jArray = JArray.Parse(jsonString);

            foreach (var item in jArray.Children<JObject>())
            {
                yield return Validate(item.ToObject<InputModel>());
            }
        }

        public async Task<IEnumerable<InputModel>> GetInputDataFromFile(string inputFileFullPathName)
        {
            if (string.IsNullOrEmpty(inputFileFullPathName)) return null;
            string jsonString;

            using (var streamReader = new StreamReader(inputFileFullPathName))
            {
                jsonString = await streamReader.ReadToEndAsync();
            }

            return GetDataList(jsonString);
        }
        
    }
}