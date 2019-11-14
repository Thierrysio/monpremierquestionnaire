using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace monpremierquestionnaire.Modeles
{
    class questionnaire
    {
        #region Attributs
        public static ArrayList CollClasseQuestionnaire = new ArrayList();

        private int id;
        private string question;
        private string choix;
        private int reponse;


        #endregion

        #region Constructeurs
        public questionnaire(int id, string question, string choix, int reponse)
        {
            this.Id = id;
            this.Question = question;
            this.Choix = choix;
            this.Reponse = reponse;

            questionnaire.CollClasseQuestionnaire.Add(this);
        }
        #endregion

        #region Getters/Setters
        public int Id { get => id; set => id = value; }
        public string Question { get => question; set => question = value; }
        public string Choix { get => choix; set => choix = value; }
        public int Reponse { get => reponse; set => reponse = value; }
        #endregion

        #region Methodes
        public static ObservableCollection<questionnaire> GetListeQuestionnaire()
        {
            ObservableCollection<questionnaire> resultat = new ObservableCollection<questionnaire>();

            foreach (questionnaire leQuestionnaire in questionnaire.CollClasseQuestionnaire)
            {
                resultat.Add(leQuestionnaire);
            }

            return resultat;
        }
        #endregion
    }
}
