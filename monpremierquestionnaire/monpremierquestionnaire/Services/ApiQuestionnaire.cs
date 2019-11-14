using monpremierquestionnaire.Modeles;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace monpremierquestionnaire.Services
{
    class ApiQuestionnaire
    {
        #region Methodes
        public async Task<ObservableCollection<questionnaire>> GetQuestionnaireAsync()
        {
            try
            {
                var clientHttp = new HttpClient();
                var json = await clientHttp.GetStringAsync(Constantes.BaseApiAddress +
                    "api/GetQuestionnaires");
                JsonConvert.DeserializeObject<List<questionnaire>>(json);
            }
            catch (Exception ex)
            {
                // a coder
            }
            return questionnaire.GetListeQuestionnaire();
        }
        public async Task PutClasseAsync(questionnaire param)
        {
            var clientHttp = new HttpClient();

            var json = JsonConvert.SerializeObject(param);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            await clientHttp.PostAsync(Constantes.BaseApiAddress + "api/QuestionnairePut", content);
        }
    }
    #endregion
}
