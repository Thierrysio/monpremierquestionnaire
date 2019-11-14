using monpremierquestionnaire.Modeles;
using monpremierquestionnaire.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace monpremierquestionnaire.VuesModeles
{
    class QuestionnaireVueModele : INotifyPropertyChanged
    {
       
        #region attributs
        private readonly ApiQuestionnaire _apiServices = new ApiQuestionnaire();
        private ObservableCollection<questionnaire> maListeQuestionnaire;

        private questionnaire _laquestion;
        private questionnaire _selectionChoix;
        #endregion
        #region constructeurs
        public QuestionnaireVueModele()
        {
            
            Task.Run(async () =>
            {
                MaListeQuestionnaire = await _apiServices.GetQuestionnaireAsync();
                LaQuestion = (questionnaire)questionnaire.CollClasseQuestionnaire[0];
            });

            selectioncommand = new Command(ActionItemSelected);

        }
        #endregion
        #region getters/setters

        public ObservableCollection<questionnaire> MaListeQuestionnaire
        {
            get
            {
                return maListeQuestionnaire;
            }
            set
            {
                maListeQuestionnaire = value;
                OnPropertyChanged(nameof(MaListeQuestionnaire));
            }
        }
        public questionnaire LaQuestion
        {
            get
            {
                return _laquestion;
            }
            set
            {
          _laquestion= value;
                OnPropertyChanged(nameof(LaQuestion));
            }
        }
        public questionnaire SelectionChoix
        {
            get
            {
                return _selectionChoix;
            }
            set
            {
                _selectionChoix = value;
                OnPropertyChanged(nameof(SelectionChoix));
            }

        }
        public ICommand selectioncommand { get; }
        #endregion
        #region methodes


        public void ActionPage()
        {
            int x = 5;
        }
        public void ActionItemSelected()
        {
            Task.Run(async () =>
            {
                await _apiServices.PutClasseAsync(this.SelectionChoix);
            });
        }
        #endregion

        #region notifications

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }

}
